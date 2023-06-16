using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using YogaManagement.Client.OdataClient.Default;
using YogaManagement.Client.OdataClient.YogaManagement.Contracts.Authority;
using YogaManagement.Client.OdataClient.YogaManagement.Contracts.Course;
using YogaManagement.Database.EF;
using YogaManagement.Domain.Models;

namespace YogaManagement.Client.Controllers;
public class CourseController : Controller
{
    private readonly Container _context;

    public CourseController(Container context)
    {
        _context = context;
    }
    // GET: Courses
    public async Task<IActionResult> Index()
    {
        var coursesDbContext = await _context.Courses
            .ExecuteAsync();
        return View(coursesDbContext);
    }
    // GET: Courses/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null || _context.Courses == null)
        {
            RedirectToAction(nameof(Index));
        }

        var course = await _context.Courses
            .ByKey(id.Value).GetValueAsync();
        if (course == null)
        {
            RedirectToAction(nameof(Index));
        }

        return View(course);
    }
    // GET: Courses/Create
    public async Task<IActionResult> Create()
    {
        var categories = await _context.Categories
                    .ExecuteAsync();
        ViewBag.Categories = new SelectList(categories, "Id", "Name");
        return View();
    }

    // POST: AppUsers/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Description,Price, StartDate,EnddDate,IsActive,CategoryId")] CourseDTO course)
    {
        try
        {
                var categories = await _context.Categories
                    .ExecuteAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            ModelState.Remove("CategoryName");
            if (!ModelState.IsValid)
            {
                throw new Exception("Invalid input");
            }
            course.CategoryName= "";
            _context.AddToCourses(course);

            await _context.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ViewData["Error"] = ex.Message;
            return View(course);
        }
    }
    // GET: Courses/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null || _context.Courses == null)
        {
            RedirectToAction(nameof(Index));
        }

        var course = await _context.Courses.ByKey(id.Value).GetValueAsync();
        var categories = await _context.Categories
                    .ExecuteAsync();
        ViewBag.Categories = new SelectList(categories, "Id", "Name");
        if (course == null)
        {
            RedirectToAction(nameof(Index));
        }
        return View(course);
    }
    // POST: Courses/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price, StartDate,EnddDate,IsActive,CategoryId")] CourseDTO course)
    {
        if (id != course.Id)
        {
            RedirectToAction(nameof(Index));
        }
        var categories = await _context.Categories
                    .ExecuteAsync();
        ViewBag.Categories = new SelectList(categories, "Id", "Name");
        ModelState.Remove("CategoryName");
        if (!ModelState.IsValid)
        {
            ViewData["Error"] = "Invalid input";
            return View(course);
        }
        else 
        {
            try
            {              
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
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(course.Id))
                {
                    RedirectToAction(nameof(Index));
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(course);
    }
    // GET: Courses/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null || _context.Courses == null)
        {
            RedirectToAction(nameof(Index));
        }

        var course = await _context.Courses
            .ByKey(id.Value).GetValueAsync();
        if (course == null)
        {
            RedirectToAction(nameof(Index));
        }

        return View(course);
    }

    // POST: Courses/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var course = _context.Courses.ByKey(id).GetValue();
        if (course != null)
        {
            _context.DeleteObject(course);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    private bool CourseExists(int id)
    {
        return (_context.Courses?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
