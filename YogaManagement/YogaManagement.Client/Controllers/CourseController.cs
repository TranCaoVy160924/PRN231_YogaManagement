using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using YogaManagement.Client.Helper;
using YogaManagement.Client.OdataClient.Default;
using YogaManagement.Client.OdataClient.YogaManagement.Contracts.Authority;
using YogaManagement.Client.OdataClient.YogaManagement.Contracts.Course;

namespace YogaManagement.Client.Controllers;

[Authorize(Roles = "Member,Staff")]
public class CourseController : Controller
{
    private readonly Container _context;
    private readonly INotyfService _notyf;
    private readonly JwtManager _jwtManager;

    public CourseController(Container context,
        INotyfService notyf,
        JwtManager jwtManager)
    {
        _context = context;
        _notyf = notyf;
        _jwtManager = jwtManager;
        _context.BuildingRequest += (sender, e) => _jwtManager.OnBuildingRequest(sender, e);
    }

    // GET: Courses
    public async Task<IActionResult> Index()
    {
        var coursesDbContext = _context.Courses.
            Where(x => x.IsActive);
        return View(coursesDbContext);
    }

    // GET: Courses/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        try
        {
            if (id == null || _context.Courses == null)
            {
                throw new Exception("Not found");
            }

            var course = await _context.Courses.ByKey(id.Value).GetValueAsync();
            if (course == null)
            {
                throw new Exception("Not found");
            }

            return View(course);
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

    // GET: Courses/Create
    [Authorize(Roles = "Staff")]
    public async Task<IActionResult> Create()
    {
        var categories = await _context.Categories.ExecuteAsync();
        ViewBag.Categories = new SelectList(categories, "Id", "Name");
        return View();
    }

    // POST: AppUsers/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Staff")]
    public async Task<IActionResult> Create([Bind("Id,Name,Description,Price, StartDate,EnddDate,IsActive,CategoryId")] CourseDTO course)
    {
        try
        {
            var categories = await _context.Categories.ExecuteAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            ModelState.Remove("CategoryName");
            if (!ModelState.IsValid)
            {
                throw new Exception("Invalid input");
            }
            course.CategoryName = "";
            _context.AddToCourses(course);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        catch (InvalidOperationException ex)
        {
            _notyf.Error(ex.ReadOdataErrorMessage());
            return View(course);
        }
        catch (Exception ex)
        {
            _notyf.Error(ex.Message);
            return View(course);
        }
    }

    // GET: Courses/Edit/5
    [Authorize(Roles = "Staff")]
    public async Task<IActionResult> Edit(int? id)
    {
        try
        {
            if (id == null || _context.Courses == null)
            {
                throw new Exception("Not found");
            }

            var course = await _context.Courses.ByKey(id.Value).GetValueAsync();
            if (course == null)
            {
                throw new Exception("Not found");
            }
            return View(course);
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

    // POST: Courses/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Staff")]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price, StartDate,EnddDate,IsActive,CategoryId")] CourseDTO course)
    {
        if (id != course.Id)
        {
            _notyf.Error("Not found");
            return RedirectToAction(nameof(Index));
        }

        try
        {
            ModelState.Remove("CategoryName");
            if (!ModelState.IsValid)
            {
                throw new Exception("Invalid input");
            }

            var initCourse = _context.Courses.ByKey(id).GetValue();
            initCourse.Name = course.Name;
            initCourse.Description = course.Description;
            initCourse.Price = course.Price;
            initCourse.StartDate = course.StartDate;
            initCourse.EnddDate = course.EnddDate;
            initCourse.IsActive = course.IsActive;
            initCourse.CategoryId = course.CategoryId;

            _context.UpdateObject(initCourse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        catch (InvalidOperationException ex)
        {

            _notyf.Error(ex.ReadOdataErrorMessage());
            return View(course);
        }
        catch (Exception ex)
        {
            _notyf.Error(ex.Message);
            return View(course);
        }
    }

    // GET: Courses/Delete/5
    [Authorize(Roles = "Staff")]
    public async Task<IActionResult> Delete(int? id)
    {
        try
        {
            if (id == null || _context.Courses == null)
            {
                throw new Exception("Not found");
            }

            var course = await _context.Courses.ByKey(id.Value).GetValueAsync();
            if (course == null)
            {
                throw new Exception("Not found");
            }

            return View(course);
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

    // POST: Courses/Delete/5
    [Authorize(Roles = "Staff")]
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        try
        {
            var course = _context.Courses.ByKey(id).GetValue();
            if (course != null)
            {
                _context.DeleteObject(course);
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
