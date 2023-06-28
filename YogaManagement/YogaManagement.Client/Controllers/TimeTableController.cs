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
            var studyingClass = _context.Enrollments
                .Where(x => x.MemberId == memberId)
                .ToList()
                .Select(x => x.YogaClassName);

            var timetable = _context.ClassTimeSlot
                .Where(x => studyingClass.Contains(x.ClassName));

            return View(timetable);
        }
        catch (InvalidOperationException ex)
        {
            return RedirectToAction("Index", "Home");
        }
        catch (Exception ex)
        {
            _notyf.Error(ex.Message);
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
