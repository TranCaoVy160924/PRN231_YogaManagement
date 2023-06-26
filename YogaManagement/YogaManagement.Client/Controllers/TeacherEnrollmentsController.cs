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
    public class TeacherEnrollmentsController : Controller
    {
        private readonly YogaManagementDbContext _context;

        public TeacherEnrollmentsController(YogaManagementDbContext context)
        {
            _context = context;
        }

        // GET: TeacherEnrollments
        public async Task<IActionResult> Index()
        {
            var yogaManagementDbContext = _context.TeacherEnrollments.Include(t => t.TeacherProfile).Include(t => t.YogaClass);
            return View(await yogaManagementDbContext.ToListAsync());
        }

        // GET: TeacherEnrollments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TeacherEnrollments == null)
            {
                return NotFound();
            }

            var teacherEnrollment = await _context.TeacherEnrollments
                .Include(t => t.TeacherProfile)
                .Include(t => t.YogaClass)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teacherEnrollment == null)
            {
                return NotFound();
            }

            return View(teacherEnrollment);
        }

        // GET: TeacherEnrollments/Create
        public IActionResult Create()
        {
            ViewData["TeacherProfileId"] = new SelectList(_context.TeacherProfiles, "Id", "Id");
            ViewData["YogaClassId"] = new SelectList(_context.YogaClasses, "Id", "Name");
            return View();
        }

        // POST: TeacherEnrollments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IsActive,StartDate,EndDate,TeacherProfileId,YogaClassId")] TeacherEnrollment teacherEnrollment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teacherEnrollment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TeacherProfileId"] = new SelectList(_context.TeacherProfiles, "Id", "Id", teacherEnrollment.TeacherProfileId);
            ViewData["YogaClassId"] = new SelectList(_context.YogaClasses, "Id", "Name", teacherEnrollment.YogaClassId);
            return View(teacherEnrollment);
        }

        // GET: TeacherEnrollments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TeacherEnrollments == null)
            {
                return NotFound();
            }

            var teacherEnrollment = await _context.TeacherEnrollments.FindAsync(id);
            if (teacherEnrollment == null)
            {
                return NotFound();
            }
            ViewData["TeacherProfileId"] = new SelectList(_context.TeacherProfiles, "Id", "Id", teacherEnrollment.TeacherProfileId);
            ViewData["YogaClassId"] = new SelectList(_context.YogaClasses, "Id", "Name", teacherEnrollment.YogaClassId);
            return View(teacherEnrollment);
        }

        // POST: TeacherEnrollments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IsActive,StartDate,EndDate,TeacherProfileId,YogaClassId")] TeacherEnrollment teacherEnrollment)
        {
            if (id != teacherEnrollment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teacherEnrollment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherEnrollmentExists(teacherEnrollment.Id))
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
            ViewData["TeacherProfileId"] = new SelectList(_context.TeacherProfiles, "Id", "Id", teacherEnrollment.TeacherProfileId);
            ViewData["YogaClassId"] = new SelectList(_context.YogaClasses, "Id", "Name", teacherEnrollment.YogaClassId);
            return View(teacherEnrollment);
        }

        // GET: TeacherEnrollments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TeacherEnrollments == null)
            {
                return NotFound();
            }

            var teacherEnrollment = await _context.TeacherEnrollments
                .Include(t => t.TeacherProfile)
                .Include(t => t.YogaClass)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teacherEnrollment == null)
            {
                return NotFound();
            }

            return View(teacherEnrollment);
        }

        // POST: TeacherEnrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TeacherEnrollments == null)
            {
                return Problem("Entity set 'YogaManagementDbContext.TeacherEnrollments'  is null.");
            }
            var teacherEnrollment = await _context.TeacherEnrollments.FindAsync(id);
            if (teacherEnrollment != null)
            {
                _context.TeacherEnrollments.Remove(teacherEnrollment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherEnrollmentExists(int id)
        {
          return (_context.TeacherEnrollments?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
