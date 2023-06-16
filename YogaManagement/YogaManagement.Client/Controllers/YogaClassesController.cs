using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using YogaManagement.Client.OdataClient.Default;
using YogaManagement.Client.OdataClient.YogaManagement.Contracts.YogaClass;
using YogaManagement.Database.EF;
using YogaManagement.Domain.Models;

namespace YogaManagement.Client.Controllers
{
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
            return View(ygClasses);
        }

        // GET: YogaClasses/Details/5
        public async Task<IActionResult> Details(int? id)
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
        public async Task<IActionResult> Create([Bind("Id,Name,Size,Status,CourseId")] YogaClassDTO yogaClass)
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

            }catch (Exception ex)
            {
                ViewData["Error"] = ex.Message;
                return View(yogaClass);
            }
        }

        // GET: YogaClasses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.YogaClasses == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var yogaClass = await _context.YogaClasses.ByKey(id.Value).GetValueAsync();
            var course = await _context.Courses.ExecuteAsync();
            ViewBag.Courses = new SelectList(course, "Id", "Name");
            if (yogaClass == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(yogaClass);
        }

        // POST: YogaClasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Size,Status,CourseId")] YogaClassDTO UyogaClass)
        {
            if (id != UyogaClass.Id)
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
                ygClass.Name = UyogaClass.Name;
                ygClass.Status = UyogaClass.Status;
                ygClass.Size = UyogaClass.Size;
                ygClass.CourseId = UyogaClass.CourseId;          

                _context.UpdateObject(ygClass);
                await _context.SaveChangesAsync();

            }catch (Exception ex)
            {
                if(!YogaClassExists(UyogaClass.Id))
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: YogaClasses/Delete/5
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
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.YogaClasses == null)
            {
                return RedirectToAction(nameof(Index));
            }
            var yogaClass = _context.YogaClasses.ByKey(id).GetValue();
            if (yogaClass != null)
            {
                _context.DeleteObject(yogaClass);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YogaClassExists(int id)
        {
            return (_context.YogaClasses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
