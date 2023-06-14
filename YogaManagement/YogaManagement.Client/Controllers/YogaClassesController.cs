using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using YogaManagement.Database.EF;
using YogaManagement.Domain.Models;

namespace YogaManagement.Client.Controllers
{
    public class YogaClassesController : Controller
    {
        private readonly YogaManagementDbContext _context;

        public YogaClassesController(YogaManagementDbContext context)
        {
            _context = context;
        }

        // GET: YogaClasses
        public async Task<IActionResult> Index()
        {
            var yogaManagementDbContext = _context.YogaClasses.Include(y => y.Course);
            return View(await yogaManagementDbContext.ToListAsync());
        }

        // GET: YogaClasses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.YogaClasses == null)
            {
                return NotFound();
            }

            var yogaClass = await _context.YogaClasses
                .Include(y => y.Course)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (yogaClass == null)
            {
                return NotFound();
            }

            return View(yogaClass);
        }

        // GET: YogaClasses/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Description");
            return View();
        }

        // POST: YogaClasses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Size,Status,CourseId")] YogaClass yogaClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yogaClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Description", yogaClass.CourseId);
            return View(yogaClass);
        }

        // GET: YogaClasses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.YogaClasses == null)
            {
                return NotFound();
            }

            var yogaClass = await _context.YogaClasses.FindAsync(id);
            if (yogaClass == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Description", yogaClass.CourseId);
            return View(yogaClass);
        }

        // POST: YogaClasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Size,Status,CourseId")] YogaClass yogaClass)
        {
            if (id != yogaClass.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yogaClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YogaClassExists(yogaClass.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Description", yogaClass.CourseId);
            return View(yogaClass);
        }

        // GET: YogaClasses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.YogaClasses == null)
            {
                return NotFound();
            }

            var yogaClass = await _context.YogaClasses
                .Include(y => y.Course)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (yogaClass == null)
            {
                return NotFound();
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
                return Problem("Entity set 'YogaManagementDbContext.YogaClasses'  is null.");
            }
            var yogaClass = await _context.YogaClasses.FindAsync(id);
            if (yogaClass != null)
            {
                _context.YogaClasses.Remove(yogaClass);
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
