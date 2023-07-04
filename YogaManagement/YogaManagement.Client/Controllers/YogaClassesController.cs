using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Diagnostics;
using YogaManagement.Client.Helper;
using YogaManagement.Client.OdataClient.Default;
using YogaManagement.Client.OdataClient.YogaManagement.Contracts.YogaClass;
using YogaManagement.Client.OdataClient.YogaManagement.Contracts.Enrollment;

namespace YogaManagement.Client.Controllers;

[Authorize(Roles = "Member,Staff")]
public class YogaClassesController : Controller
{
    private readonly Container _context;
    private readonly INotyfService _notyf;
    private readonly JwtManager _jwtManager;

    public YogaClassesController(Container context,
        INotyfService notyf,
        JwtManager jwtManager)
    {
        _context = context;
        _jwtManager = jwtManager;
        _notyf = notyf;
        _context.BuildingRequest += (sender, e) => _jwtManager.OnBuildingRequest(sender, e);
    }

    // GET: YogaClasses
    public async Task<IActionResult> Index(int? id)
    {
        IEnumerable<YogaClassDTO> ygClasses;
        if (id == null)
        {
            ygClasses = _context.YogaClasses.Execute()
                .Where(x => x.YogaClassStatus == "Pending" ||
                    x.YogaClassStatus == "Active");

            ViewData["CourseEnrolled"] = false;
        }
        else
        {
            ygClasses = _context.YogaClasses
                .Where(x => x.CourseId == id);

            ViewData["CourseEnrolled"] = _context.Enrollments.ToList()
                .Any(x => x.CourseId == id 
                    && x.MemberId == _jwtManager.GetProfileId());
        }

        var enrollments = _context.Enrollments.ToList();
        ViewData["EnrolledMember"] = enrollments;

        return View(ygClasses.ToList()
            .OrderByDescending(x => x.YogaClassStatus)
            .ThenBy(x => x.CourseId));
    }

    // GET: YogaClasses/Details/5
    public IActionResult Details(int? id)
    {
        try
        {
            if (id == null || _context.YogaClasses == null)
            {
                throw new Exception("Not found");
            }

            var yogaClass = _context.YogaClasses
               .Where(y => y.Id == id).SingleOrDefault();
            if (yogaClass == null)
            {
                throw new Exception("Not found");
            }

            return View(yogaClass);
        }
        catch (InvalidOperationException ex)
        {
            _notyf.Error(ex.ReadOdataErrorMessage());
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            _notyf.Error(ex.Message);
            return RedirectToAction(nameof(Index));
        }
    }

    // GET: YogaClasses/Create
    [Authorize(Roles = "Staff")]
    public async Task<IActionResult> Create()
    {
        var courses = _context.Courses.Execute()
            .Where(x => x.IsActive
                && x.StartDate > DateTime.Today
                && x.EnddDate > DateTime.Today)
            .ToList();
        if (courses.Count == 0)
        {
            _notyf.Error("No available course");
            return RedirectToAction(nameof(Index));
        }

        ViewBag.Courses = new SelectList(courses, "Id", "Name");
        return View();
    }

    // POST: YogaClasses/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Staff")]
    public async Task<IActionResult> Create([Bind("Id,Name,Size,YogaClassStatus,CourseId")] YogaClassDTO yogaClass)
    {
        try
        {
            var courses = _context.Courses.Execute()
            .Where(x => x.IsActive
                && x.StartDate > DateTime.Today
                && x.EnddDate > DateTime.Today)
            .ToList();
            if (courses.Count == 0)
            {
                _notyf.Error("No available course");
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Courses = new SelectList(courses, "Id", "Name");
            ModelState.Remove("CourseName");
            if (!ModelState.IsValid)
            {
                throw new Exception("Invalid Input");
            }
            yogaClass.CourseName = "";
            _context.AddToYogaClasses(yogaClass);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        catch (InvalidOperationException ex)
        {
            _notyf.Error(ex.ReadOdataErrorMessage());
            return View(yogaClass);
        }
        catch (Exception ex)
        {
            _notyf.Error(ex.Message);
            return View(yogaClass);
        }
    }

    // GET: YogaClasses/Delete/5
    [Authorize(Roles = "Staff")]
    public async Task<IActionResult> Delete(int? id)
    {
        try
        {
            if (id == null || _context.YogaClasses == null)
            {
                throw new Exception("Invalid class");
            }

            var yogaClass = await _context.YogaClasses.ByKey(id.Value).GetValueAsync();
            if (yogaClass == null)
            {
                throw new Exception("No class found");
            }
            if (yogaClass.YogaClassStatus == "Active")
            {
                throw new Exception("Cannot update ongoing class");
            }
            return View(yogaClass);
        }
        catch (InvalidOperationException ex)
        {
            _notyf.Error(ex.ReadOdataErrorMessage());
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            _notyf.Error(ex.Message);
            return RedirectToAction(nameof(Index));
        }
    }

    // POST: YogaClasses/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Staff")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (_context.YogaClasses == null)
        {
            return RedirectToAction(nameof(Index));
        }

        try
        {
            var yogaClass = _context.YogaClasses.ByKey(id).GetValue();
            var tcEnrollments = _context.TeacherEnrollments
                .Where(x => x.YogaClassId == yogaClass.Id)
                .ToList();
            if (yogaClass != null)
            {
                _context.DeleteObject(yogaClass);

                foreach (var tcEnrollment in tcEnrollments)
                {
                    _context.DeleteObject(tcEnrollment);
                }
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        catch (InvalidOperationException ex)
        {
            _notyf.Error(ex.ReadOdataErrorMessage());
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            _notyf.Error(ex.Message);
            return RedirectToAction(nameof(Index));
        }
    }

    [Authorize(Roles = "Staff")]
    public async Task<IActionResult> Activate(int? id)
    {
        try
        {
            if (id == null || _context.YogaClasses == null)
            {
                throw new Exception("Invalid class");
            }

            var yogaClass = _context.YogaClasses
                .Where(x => x.Id == id.Value).Single();
            if (yogaClass == null)
            {
                throw new Exception("No class found");
            }

            if (yogaClass.YogaClassStatus != "Pending")
            {
                throw new Exception("Only pending class can be activated");
            }
            return View(yogaClass);
        }
        catch (InvalidOperationException ex)
        {
            _notyf.Error(ex.ReadOdataErrorMessage());
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            _notyf.Error(ex.Message);
            return RedirectToAction(nameof(Index));
        }
    }

    // POST: YogaClasses/Delete/5
    [HttpPost, ActionName("Activate")]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Staff")]
    public async Task<IActionResult> ActivateConfirm(int id)
    {
        if (_context.YogaClasses == null)
        {
            return RedirectToAction(nameof(Index));
        }

        try
        {
            var yogaClass = _context.YogaClasses.ByKey(id).GetValue();;
            if (yogaClass != null)
            {
                _context.UpdateObject(yogaClass);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        catch (InvalidOperationException ex)
        {
            _notyf.Error(ex.ReadOdataErrorMessage());
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            _notyf.Error(ex.Message);
            return RedirectToAction(nameof(Index));
        }
    }
}
