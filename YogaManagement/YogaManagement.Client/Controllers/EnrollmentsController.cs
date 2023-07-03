using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using YogaManagement.Client.Helper;
using YogaManagement.Client.OdataClient.Default;
using YogaManagement.Client.OdataClient.YogaManagement.Contracts.Enrollment;
using YogaManagement.Client.OdataClient.YogaManagement.Contracts.Transaction;
using YogaManagement.Database.EF;
using YogaManagement.Domain.Models;

namespace YogaManagement.Client.Controllers;
[Authorize(Roles = "Member")]
public class EnrollmentsController : Controller
{
    private readonly Container _context;
    private readonly JwtManager _jwtManager;
    private readonly INotyfService _notyf;

    public EnrollmentsController(Container context,
        JwtManager jwtManager,
        INotyfService notyf)
    {
        _context = context;
        _notyf = notyf;
        _jwtManager = jwtManager;
        _context.BuildingRequest += (sender, e) => _jwtManager.OnBuildingRequest(sender, e);
    }

    // GET: Enrollments/Create
    // ClassId
    public IActionResult Create(int? id)
    {
        try
        {
            if (id == null)
            {
                throw new Exception("Not found");
            }

            var enrolled = _context.Enrollments.ToList()
                .Any(x => x.YogaClassId == id && x.MemberId == _jwtManager.GetProfileId());
            if (enrolled)
            {
                throw new Exception("Already enrolled");
            }

            var ygClass = _context.YogaClasses
                .Where(x => x.Id == id).Single();

            double totalDeposit = _jwtManager.GetTotalDeposit();
            var privilege = _context.MemberLevels.ToList().Single();
            var condition = _context.MemberLevelConditons.ToList().Single();
            double discount = 0;

            if (totalDeposit > condition.Platinum)
            {
                discount = privilege.Platinum / 100;
            }
            else if (totalDeposit > condition.Gold)
            {
                discount = privilege.Gold / 100;
            }
            else if (totalDeposit > condition.Silver)
            {
                discount = privilege.Silver / 100;
            }

            var enrollment = new EnrollmentDTO
            {
                YogaClassId = id.Value,
                MemberId = _jwtManager.GetProfileId(),
                MemberName = _jwtManager.GetEmail(),
                YogaClassName = ygClass.Name,
                CourseId = ygClass.CourseId,
                Discount = discount,
                EnrollDate = DateTime.Today
            };

            return View(enrollment);
        }
        catch (InvalidOperationException ex)
        {
            _notyf.Error(ex.ReadOdataErrorMessage());
        }
        catch (Exception ex)
        {
            _notyf.Error(ex.Message);
        }

        return RedirectToAction("Index", "YogaClasses");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(EnrollmentDTO enrollment)
    {
        try
        {
            var course = _context.Courses
                .Where(x => x.Id == enrollment.CourseId)
                .Single();

            var wallet = _context.Wallets
                .Where(x => x.AppUserId == _jwtManager.GetUserId())
                .Single();

            double amount = course.Price * (1 - enrollment.Discount);

            if (amount > wallet.Balance)
            {
                throw new Exception("Not enough money in wallet");
            }

            var sameClassEnrollment = _context.Enrollments
                .Where(x => x.CourseId == enrollment.CourseId
                    && x.MemberId == enrollment.MemberId)
                .ToList();

            var transaction = new TransactionDTO
            {
                Amount = amount,
                Content = "Enroll to class " + enrollment.YogaClassName,
                CreatedDate = DateTime.Today,
                TransactionType = "Payment",
                WalletId = wallet.Id
            };

            if (sameClassEnrollment.Count == 0)
            {
                _context.AddToTransactions(transaction);
            }
            _context.AddToEnrollments(enrollment);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "YogaClasses", new { id = enrollment.CourseId });
        }
        catch (InvalidOperationException ex)
        {
            _notyf.Error(ex.ReadOdataErrorMessage());
        }
        catch (Exception ex)
        {
            _notyf.Error(ex.Message);
        }

        return View(enrollment);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int? id)
    {
        try
        {
            if (id == null || _context.Enrollments == null)
            {
                return NotFound();
            }

            var enrollment = _context.Enrollments
                .Where(x => x.YogaClassId == id
                    && x.MemberId == _jwtManager.GetProfileId())
                .Single();

            return View(enrollment);
        }
        catch (InvalidOperationException ex)
        {
            _notyf.Error(ex.ReadOdataErrorMessage());
        }
        catch (Exception ex)
        {
            _notyf.Error(ex.Message);
        }

        return RedirectToAction("Index", "YogaClasses");
    }

    // POST: Enrollments/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int memberId, int yogaClassId)
    {
        try
        {
            var enrollment = _context.Enrollments
                .Where(x => x.MemberId == memberId
                    && x.YogaClassId == yogaClassId)
                .Single();

            var course = _context.Courses
                .Where(x => x.Id == enrollment.CourseId)
                .Single();

            var wallet = _context.Wallets
                .Where(x => x.AppUserId == _jwtManager.GetUserId())
                .Single();

            double amount = course.Price * (1 - enrollment.Discount);

            var transaction = new TransactionDTO
            {
                Amount = amount,
                Content = "Refund enrollment to class " + enrollment.YogaClassName,
                CreatedDate = DateTime.Today,
                TransactionType = "Refund",
                WalletId = wallet.Id
            };

            _context.AddToTransactions(transaction);
            _context.DeleteObject(enrollment);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "YogaClasses");
        }
        catch (InvalidOperationException ex)
        {
            _notyf.Error(ex.ReadOdataErrorMessage());
        }
        catch (Exception ex)
        {
            _notyf.Error(ex.Message);
        }

        return RedirectToAction("Index", "YogaClasses");
    }
}
