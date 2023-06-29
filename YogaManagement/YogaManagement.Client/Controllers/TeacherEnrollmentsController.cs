using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using YogaManagement.Client.Helper;
using YogaManagement.Client.OdataClient.Default;
using YogaManagement.Client.OdataClient.YogaManagement.Contracts.TeacherEnrollment;
using YogaManagement.Database.EF;
using YogaManagement.Domain.Models;

namespace YogaManagement.Client.Controllers
{
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
                return RedirectToAction(nameof(Create), new { id = id });
            }
            catch (Exception ex)
            {
                _notyf.Error(ex.Message);
                return RedirectToAction("Index", "YogaClasses", id);
            }
        }

        // GET: TeacherEnrollments/Create
        public IActionResult Create(int? id)
        {
            try
            {
                var ygClass = _context.YogaClasses
                    .Where(x => x.Id == id).Single()
                    ?? throw new Exception("Class not exist");

                ViewData["TeacherProfileId"] = new SelectList(_context.TeacherProfiles.Execute(), "Id", "Name");
                var course = _context.Courses
                    .Where(x => x.Id == ygClass.CourseId).Single();
                return View(new TeacherEnrollmentDTO
                {
                    StartDate = course.StartDate.DateTime,
                    EndDate = course.EnddDate.DateTime
                });
            }
            catch (InvalidOperationException ex)
            {
                _notyf.Error(ex.Message);
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
        public async Task<IActionResult> Create(TeacherEnrollmentDTO teacherEnrollment)
        {
            //if (ModelState.IsValid)
            //{
            //    _context.Add(teacherEnrollment);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            var ygClass = _context.YogaClasses
                    .Where(x => x.Id == teacherEnrollment.YogaClassId).Single()
                    ?? throw new Exception("Class not exist");

            ViewData["TeacherProfileId"] = new SelectList(_context.TeacherProfiles.Execute(), "Id", "Name");

            return View(teacherEnrollment);
        }

        //// GET: TeacherEnrollments/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.TeacherEnrollments == null)
        //    {
        //        return NotFound();
        //    }

        //    var teacherEnrollment = await _context.TeacherEnrollments.FindAsync(id);
        //    if (teacherEnrollment == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["TeacherProfileId"] = new SelectList(_context.TeacherProfiles, "Id", "Id", teacherEnrollment.TeacherProfileId);
        //    ViewData["YogaClassId"] = new SelectList(_context.YogaClasses, "Id", "Name", teacherEnrollment.YogaClassId);
        //    return View(teacherEnrollment);
        //}

        //// POST: TeacherEnrollments/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,IsActive,StartDate,EndDate,TeacherProfileId,YogaClassId")] TeacherEnrollment teacherEnrollment)
        //{
        //    if (id != teacherEnrollment.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(teacherEnrollment);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!TeacherEnrollmentExists(teacherEnrollment.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["TeacherProfileId"] = new SelectList(_context.TeacherProfiles, "Id", "Id", teacherEnrollment.TeacherProfileId);
        //    ViewData["YogaClassId"] = new SelectList(_context.YogaClasses, "Id", "Name", teacherEnrollment.YogaClassId);
        //    return View(teacherEnrollment);
        //}

        //// GET: TeacherEnrollments/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.TeacherEnrollments == null)
        //    {
        //        return NotFound();
        //    }

        //    var teacherEnrollment = await _context.TeacherEnrollments
        //        .Include(t => t.TeacherProfile)
        //        .Include(t => t.YogaClass)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (teacherEnrollment == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(teacherEnrollment);
        //}

        //// POST: TeacherEnrollments/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.TeacherEnrollments == null)
        //    {
        //        return Problem("Entity set 'YogaManagementDbContext.TeacherEnrollments'  is null.");
        //    }
        //    var teacherEnrollment = await _context.TeacherEnrollments.FindAsync(id);
        //    if (teacherEnrollment != null)
        //    {
        //        _context.TeacherEnrollments.Remove(teacherEnrollment);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool TeacherEnrollmentExists(int id)
        //{
        //    return (_context.TeacherEnrollments?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
