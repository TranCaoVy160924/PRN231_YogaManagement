using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Formats.Asn1;
using YogaManagement.Client.Helper;
using YogaManagement.Client.OdataClient.Default;
using YogaManagement.Client.OdataClient.YogaManagement.Contracts.TeacherEnrollment;
using YogaManagement.Database.EF;
using YogaManagement.Domain.Models;

namespace YogaManagement.Client.Controllers;

[Authorize]
public class TeacherEnrollmentsController : Controller
{
    private readonly Container _context;
    private readonly INotyfService _notyf;
    private readonly JwtManager _jwtManager;

    public TeacherEnrollmentsController(Container context,
        INotyfService notyf,
        JwtManager jwtManager)
    {
        _context = context;
        _notyf = notyf;
        _jwtManager = jwtManager;
        _context.BuildingRequest += (sender, e) => _jwtManager.OnBuildingRequest(sender, e);
    }

    // GET: TeacherEnrollments
    public async Task<IActionResult> Index(int? id)
    {
        try
        {
            if (id == null)
            {
                throw new Exception("Not found");
            }

            var tcEnrollments = _context.TeacherEnrollments
                .Where(x => x.YogaClassId == id);

            ViewData["classId"] = id;
            return View(tcEnrollments);
        }
        catch (InvalidOperationException ex)
        {
            return RedirectToAction(nameof(Create), new { id });
        }
        catch (Exception ex)
        {
            _notyf.Error(ex.Message);
            return RedirectToAction("Index", "YogaClasses", new { id });
        }
    }

    [Authorize(Roles = "Staff")]
    // GET: TeacherEnrollments/Create
    public IActionResult Create(int? id)
    {
        try
        {
            if (id == null)
            {
                throw new Exception("Not found");
            }

            var ygClass = _context.YogaClasses
                .Where(x => x.Id == id).Single()
                ?? throw new Exception("Class not exist");

            ViewData["TeacherProfileId"] = new SelectList(_context.TeacherProfiles.Execute(), "Id", "Name");
            var course = _context.Courses
                .Where(x => x.Id == ygClass.CourseId).Single();

            if (course.StartDate > DateTime.Now.AddDays(7))
            {
                throw new Exception("Can only assign teacher to class of course that will start in a week from now");
            }

            ViewData["classId"] = id;
            return View(new TeacherEnrollmentDTO
            {
                YogaClassId = id.Value,
                StartDate = course.StartDate.DateTime,
                EndDate = course.EnddDate.DateTime
            });
        }
        catch (InvalidOperationException ex)
        {
            _notyf.Error(ex.ReadOdataErrorMessage());
            return RedirectToAction("Index", "TeacherEnrollments", new { id });
        }
        catch (Exception ex)
        {
            _notyf.Error(ex.Message);
            return RedirectToAction("Index", "TeacherEnrollments", new { id });
        }
    }

    // POST: TeacherEnrollments/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Staff")]
    public async Task<IActionResult> Create(TeacherEnrollmentDTO teacherEnrollment)
    {
        try
        {
            var ygClass = _context.YogaClasses
                .Where(x => x.Id == teacherEnrollment.YogaClassId).Single()
                ?? throw new Exception("Class not exist");

            ViewData["TeacherProfileId"] = new SelectList(_context.TeacherProfiles.Execute(), "Id", "Name");

            if (!ModelState.IsValid)
            {
                throw new Exception("Invalid input");
            }

            _context.AddToTeacherEnrollments(teacherEnrollment);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index), new { id = teacherEnrollment.YogaClassId });
        }
        catch (InvalidOperationException ex)
        {
            _notyf.Error(ex.ReadOdataErrorMessage());
            return View(teacherEnrollment);
        }
        catch (Exception ex)
        {
            _notyf.Error(ex.Message);
            return View(teacherEnrollment);
        }
    }

    public async Task<IActionResult> Delete(int? id)
    {
        try
        {
            if (id == null || _context.TeacherEnrollments == null)
            {
                throw new Exception("Not found");
            }

            var teacherEnrollment = _context.TeacherEnrollments
                .Where(x => x.Id == id)
                .Single();
            if (teacherEnrollment == null)
            {
                throw new Exception("Teacher enrollment not exist");
            }

            return View(teacherEnrollment);
        }
        catch (InvalidOperationException ex)
        {
            _notyf.Error(ex.ReadOdataErrorMessage());
            return RedirectToAction(nameof(Index), new { id });
        }
        catch (Exception ex)
        {
            _notyf.Error(ex.Message);
            return RedirectToAction(nameof(Index), new { id });
        }
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        try
        {
            if (id == null || _context.TeacherEnrollments == null)
            {
                throw new Exception("Not found");
            }

            var teacherEnrollment = _context.TeacherEnrollments
                .Where(x => x.Id == id).Single()
                ?? throw new Exception("Teacher enrollment not exist");
            _context.DeleteObject(teacherEnrollment);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index), new { id });
        }
        catch (InvalidOperationException ex)
        {
            _notyf.Error(ex.ReadOdataErrorMessage());
        }
        catch (Exception ex)
        {
            _notyf.Error(ex.Message);
        }

        return RedirectToAction(nameof(Delete), new { id });
    }
}
