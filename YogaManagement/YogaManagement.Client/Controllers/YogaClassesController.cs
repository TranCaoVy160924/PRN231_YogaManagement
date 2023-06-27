using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using YogaManagement.Client.Helper;
using YogaManagement.Client.OdataClient.Default;
using YogaManagement.Client.OdataClient.YogaManagement.Contracts.YogaClass;

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
            ygClasses = await _context.YogaClasses.ExecuteAsync();
        }
        else
        {
            ygClasses = _context.YogaClasses
                .Where(x => x.CourseId == id);
        }

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
        var course = await _context.Courses.ExecuteAsync();
        ViewBag.Courses = new SelectList(course, "Id", "Name");
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
            var course = await _context.Courses.ExecuteAsync();
            ViewBag.Courses = new SelectList(course, "Id", "Name");
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

    // GET: YogaClasses/Edit/5
    [Authorize(Roles = "Staff")]
    public async Task<IActionResult> Edit(int? id)
    {
        try
        {
            if (id == null || _context.YogaClasses == null)
            {
                throw new Exception("Invalid class");
            }

            var yogaClass = await _context.YogaClasses.ByKey(id.Value).GetValueAsync();
            var course = await _context.Courses.ExecuteAsync();
            ViewBag.Courses = new SelectList(course, "Id", "Name");
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

    // POST: YogaClasses/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Staff")]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Size,YogaClassStatus,CourseId")] YogaClassDTO yogaClass)
    {
        if (id != yogaClass.Id || yogaClass.YogaClassStatus == "Active")
        {
            _notyf.Error("Class cannot be update");
            return RedirectToAction(nameof(Index));
        }

        try
        {
            var course = await _context.Courses.ExecuteAsync();
            ViewBag.Courses = new SelectList(course, "Id", "Name");
            ModelState.Remove("CourseName");
            if (!ModelState.IsValid)
            {
                throw new Exception("Invalid input");
            }
            var ygClass = _context.YogaClasses.ByKey(id).GetValue();
            ygClass.Name = yogaClass.Name;
            ygClass.YogaClassStatus = yogaClass.YogaClassStatus;
            ygClass.Size = yogaClass.Size;

            _context.UpdateObject(ygClass);
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
            if (yogaClass != null)
            {
                _context.DeleteObject(yogaClass);
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
