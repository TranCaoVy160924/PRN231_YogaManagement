using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using YogaManagement.Client.Helper;
using YogaManagement.Client.OdataClient.Default;

namespace YogaManagement.Client.Controllers;
public class TimeTableController : Controller
{
    private readonly Container _context;
    private readonly INotyfService _notyf;
    private readonly JwtManager _jwtManager;

    public TimeTableController(Container context,
        INotyfService notyf,
        JwtManager jwtManager)
    {
        _context = context;
        _notyf = notyf;
        _jwtManager = jwtManager;
        _context.BuildingRequest += (sender, e) => _jwtManager.OnBuildingRequest(sender, e);
    }

    public IActionResult Member()
    {
        try
        {
            var memberId = _jwtManager.GetProfileId();
            if (memberId == 0)
            {
                throw new Exception("User not exist");
            }
            var enrollments = _context.Enrollments
                .Where(x => x.MemberId == memberId)
                .ToList();

            if (enrollments.Count > 0)
            {
                var studyingClass = enrollments
                    .Select(x => x.YogaClassName);

                var timetable = _context.ClassTimeSlot
                    .Where(x => studyingClass.Contains(x.ClassName));

                return View(timetable);
            }
            else
            {
                throw new Exception("You have not enroll in any class");
            }
        }
        catch (InvalidOperationException ex)
        {
            return RedirectToAction("Index", "Home");
        }
        catch (Exception ex)
        {
            _notyf.Warning(ex.Message);
            return RedirectToAction("Index", "Home");
        }
    }

    public IActionResult Teacher()
    {
        try
        {
            var teacherId = _jwtManager.GetProfileId();
            if (teacherId == 0)
            {
                throw new Exception("User not exist");
            }
            var teachingClass = _context.TeacherEnrollments
                .Where(x => x.TeacherProfileId == teacherId)
                .ToList()
                .Select(x => x.ClassName);

            if (teachingClass.Count() <= 0)
            {
                throw new Exception("You have not been assign to a class");
            }

            var timetable = _context.ClassTimeSlot
            .Where(x => teachingClass.Contains(x.ClassName));

            return View(timetable);

        }
        catch (InvalidOperationException ex)
        {
            return RedirectToAction("Index", "Home");
        }
        catch (Exception ex)
        {
            _notyf.Warning(ex.Message);
            return RedirectToAction("Index", "Home");
        }
    }
}
