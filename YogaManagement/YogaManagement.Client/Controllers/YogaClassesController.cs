using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using YogaManagement.Client.OdataClient.Default;
using YogaManagement.Client.OdataClient.YogaManagement.Contracts.YogaClass;

namespace YogaManagement.Client.Controllers;

[Authorize(Roles = "Member,Staff")]
public class YogaClassesController : Controller
{
    private readonly Container _context;

    public YogaClassesController(Container context)
    {
        _context = context;
    }

    // GET: YogaClasses
    public async Task<IActionResult> Index()
    {
        var ygClasses = await _context.YogaClasses.ExecuteAsync();
        return View(ygClasses.ToList());
    }

    // GET: YogaClasses/Details/5
    public IActionResult Details(int? id)
    {
        if (id == null || _context.YogaClasses == null)
        {
            return RedirectToAction(nameof(Index));
        }

        var yogaClass = _context.YogaClasses
           .Where(y => y.Id == id).SingleOrDefault();
        if (yogaClass == null)
        {
            return RedirectToAction(nameof(Index));
        }

        return View(yogaClass);
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
        catch (Exception ex)
        {
            ViewData["Error"] = ex.Message;
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
        catch (Exception ex)
        {
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
        if (id != yogaClass.Id)
        {
            return RedirectToAction(nameof(Index));
        }

        if (yogaClass.YogaClassStatus == "Active")
        {
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

        }
        catch (Exception ex)
        {
            ViewData["Error"] = ex.Message;
            return View(yogaClass);
        }
        return RedirectToAction(nameof(Index));
    }

    // GET: YogaClasses/Delete/5
    [Authorize(Roles = "Staff")]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null || _context.YogaClasses == null)
        {
            return RedirectToAction(nameof(Index));
        }

        var yogaClass = await _context.YogaClasses.ByKey(id.Value).GetValueAsync();

        if (yogaClass == null)
        {
            return RedirectToAction(nameof(Index));
        }

        return View(yogaClass);
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
        catch (Exception ex)
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
