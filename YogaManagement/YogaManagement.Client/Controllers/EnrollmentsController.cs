//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using YogaManagement.Client.Helper;
//using YogaManagement.Database.EF;
//using YogaManagement.Domain.Models;

//namespace YogaManagement.Client.Controllers;
//[Authorize]
//public class EnrollmentsController : Controller
//{
//    private readonly YogaManagementDbContext _context;
//    private readonly JwtManager _jwtManager;

//    public EnrollmentsController(YogaManagementDbContext context,
//        JwtManager jwtManager)
//    {
//        _context = context;
//        _jwtManager = jwtManager;
//        _context.BuildingRequest += (sender, e) => _jwtManager.OnBuildingRequest(sender, e);
//    }

//    // GET: Enrollments
//    public async Task<IActionResult> Index()
//    {
//        var yogaManagementDbContext = _context.Enrollments.Include(e => e.Member).Include(e => e.YogaClass);
//        return View(await yogaManagementDbContext.ToListAsync());
//    }

//    // GET: Enrollments/Details/5
//    public async Task<IActionResult> Details(int? id)
//    {
//        if (id == null || _context.Enrollments == null)
//        {
//            return NotFound();
//        }

//        var enrollment = await _context.Enrollments
//            .Include(e => e.Member)
//            .Include(e => e.YogaClass)
//            .FirstOrDefaultAsync(m => m.MemberId == id);
//        if (enrollment == null)
//        {
//            return NotFound();
//        }

//        return View(enrollment);
//    }

//    // GET: Enrollments/Create
//    public IActionResult Create()
//    {
//        ViewData["MemberId"] = new SelectList(_context.Members, "Id", "Id");
//        ViewData["YogaClassId"] = new SelectList(_context.YogaClasses, "Id", "Name");
//        return View();
//    }

//    // POST: Enrollments/Create
//    // To protect from overposting attacks, enable the specific properties you want to bind to.
//    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//    [HttpPost]
//    [ValidateAntiForgeryToken]
//    public async Task<IActionResult> Create([Bind("EnrollDate,Discount,MemberId,YogaClassId")] Enrollment enrollment)
//    {
//        if (ModelState.IsValid)
//        {
//            _context.Add(enrollment);
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }
//        ViewData["MemberId"] = new SelectList(_context.Members, "Id", "Id", enrollment.MemberId);
//        ViewData["YogaClassId"] = new SelectList(_context.YogaClasses, "Id", "Name", enrollment.YogaClassId);
//        return View(enrollment);
//    }

//    // GET: Enrollments/Edit/5
//    public async Task<IActionResult> Edit(int? id)
//    {
//        if (id == null || _context.Enrollments == null)
//        {
//            return NotFound();
//        }

//        var enrollment = await _context.Enrollments.FindAsync(id);
//        if (enrollment == null)
//        {
//            return NotFound();
//        }
//        ViewData["MemberId"] = new SelectList(_context.Members, "Id", "Id", enrollment.MemberId);
//        ViewData["YogaClassId"] = new SelectList(_context.YogaClasses, "Id", "Name", enrollment.YogaClassId);
//        return View(enrollment);
//    }

//    // POST: Enrollments/Edit/5
//    // To protect from overposting attacks, enable the specific properties you want to bind to.
//    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//    [HttpPost]
//    [ValidateAntiForgeryToken]
//    public async Task<IActionResult> Edit(int id, [Bind("EnrollDate,Discount,MemberId,YogaClassId")] Enrollment enrollment)
//    {
//        if (id != enrollment.MemberId)
//        {
//            return NotFound();
//        }

//        if (ModelState.IsValid)
//        {
//            try
//            {
//                _context.Update(enrollment);
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!EnrollmentExists(enrollment.MemberId))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }
//            return RedirectToAction(nameof(Index));
//        }
//        ViewData["MemberId"] = new SelectList(_context.Members, "Id", "Id", enrollment.MemberId);
//        ViewData["YogaClassId"] = new SelectList(_context.YogaClasses, "Id", "Name", enrollment.YogaClassId);
//        return View(enrollment);
//    }

//    // GET: Enrollments/Delete/5
//    public async Task<IActionResult> Delete(int? id)
//    {
//        if (id == null || _context.Enrollments == null)
//        {
//            return NotFound();
//        }

//        var enrollment = await _context.Enrollments
//            .Include(e => e.Member)
//            .Include(e => e.YogaClass)
//            .FirstOrDefaultAsync(m => m.MemberId == id);
//        if (enrollment == null)
//        {
//            return NotFound();
//        }

//        return View(enrollment);
//    }

//    // POST: Enrollments/Delete/5
//    [HttpPost, ActionName("Delete")]
//    [ValidateAntiForgeryToken]
//    public async Task<IActionResult> DeleteConfirmed(int id)
//    {
//        if (_context.Enrollments == null)
//        {
//            return Problem("Entity set 'YogaManagementDbContext.Enrollments'  is null.");
//        }
//        var enrollment = await _context.Enrollments.FindAsync(id);
//        if (enrollment != null)
//        {
//            _context.Enrollments.Remove(enrollment);
//        }

//        await _context.SaveChangesAsync();
//        return RedirectToAction(nameof(Index));
//    }

//    private bool EnrollmentExists(int id)
//    {
//        return (_context.Enrollments?.Any(e => e.MemberId == id)).GetValueOrDefault();
//    }
//}
