using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using YogaManagement.Client.Helper;
using YogaManagement.Client.Models;
using YogaManagement.Client.OdataClient.Default;
using YogaManagement.Client.OdataClient.System;
using YogaManagement.Client.OdataClient.YogaManagement.Contracts.TimeSlot;
using DayOfWeek = YogaManagement.Client.OdataClient.System.DayOfWeek;

namespace YogaManagement.Client.Controllers;

public class ClassScheduleController : Controller
{
    private readonly Container _context;
    private readonly INotyfService _notyf;

    public ClassScheduleController(Container context, INotyfService notyf)
    {
        _context = context;
        _notyf = notyf;
    }

    // GET: ClassSchedule
    public IActionResult Index(int? id)
    {
        try
        {
            if (id == null)
            {
                throw new Exception("Not found");
            }
            var classSchedule = _context.Schedules
            .Where(x => x.YogaClassId == id)
            .ToList()
            .Select(x => x.TimeSlotId);

            var classTimeSlots = _context.TimeSlots
                .Where(x => classSchedule.Contains(x.Id))
                .ToList();

            ViewData["classId"] = id;
            return View(classTimeSlots);
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

    //// GET: ClassSchedule/Details/5
    //public async Task<IActionResult> Details(int? id)
    //{
    //    if (id == null || _context.TimeSlots == null)
    //    {
    //        return NotFound();
    //    }

    //    var timeSlot = await _context.TimeSlots
    //        .FirstOrDefaultAsync(m => m.Id == id);
    //    if (timeSlot == null)
    //    {
    //        return NotFound();
    //    }

    //    return View(timeSlot);
    //}

    // GET: ClassSchedule/Create
    public async Task<IActionResult> Create(int? id)
    {
        if (id == null)
        {
            _notyf.Error("Not found");
            return RedirectToAction(nameof(Index), new { id = id });
        }

        var classSchedule = _context.Schedules
            .Where(x => x.YogaClassId == id)
            .ToList()
            .Select(x => x.TimeSlotId);

        var classTimeSlots =  _context.TimeSlots
            .OrderBy(x => x.DayOfWeek)
            .ToList();
        foreach (var timeSlot in classTimeSlots)
        {
            timeSlot.Status = false;
            if (classSchedule.Contains(timeSlot.Id))
            {
                timeSlot.Status = true;
            }
        }

        var model = new ScheduleViewModel
        {
            Id = id.Value
        };
        model.TimeSlots.AddRange(classTimeSlots);

        ViewData["classId"] = id;
        return View(model);
    }

    // POST: ClassSchedule/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    public async Task<IActionResult> Create(ScheduleViewModel model)
    {
        try
        {
            foreach (var day in Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>())
            {
                var slotInDay = model.TimeSlots
                    .Where(x => x.DayOfWeek == day && x.Status)
                    .ToList();
                if (slotInDay.Count() > 1)
                {
                    throw new Exception("Can have more than one slot in a day");
                }
            }

            var originalSchedule = _context.Schedules
                .Where(x => x.YogaClassId == model.Id).ToList();

            foreach (var oldSchedule in originalSchedule)
            {
                _context.DeleteObject(oldSchedule);
            }

            var schedule = model.TimeSlots
                .Where(x => x.Status)
                .Select(x => new ScheduleDTO
                {
                    TimeSlotId = x.Id,
                    YogaClassId = model.Id
                });

            foreach (var timeslot in schedule)
            {
                _context.AddToSchedules(timeslot);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index), new { id = model.Id });
        }
        catch (InvalidOperationException ex)
        {
            _notyf.Error(ex.ReadOdataErrorMessage());
            return RedirectToAction(nameof(Create), new { id = model.Id });
        }
        catch (Exception ex)
        {
            _notyf.Error(ex.Message);
            return RedirectToAction(nameof(Create), new { id = model.Id });
        }
    }

    //// GET: ClassSchedule/Edit/5
    //public async Task<IActionResult> Edit(int? id)
    //{
    //    if (id == null || _context.TimeSlots == null)
    //    {
    //        return NotFound();
    //    }

    //    var timeSlot = await _context.TimeSlots.FindAsync(id);
    //    if (timeSlot == null)
    //    {
    //        return NotFound();
    //    }
    //    return View(timeSlot);
    //}

    //// POST: ClassSchedule/Edit/5
    //// To protect from overposting attacks, enable the specific properties you want to bind to.
    //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public async Task<IActionResult> Edit(int id, [Bind("Id,DayOfWeek,StartTime,EndTime,Room,Status")] TimeSlot timeSlot)
    //{
    //    if (id != timeSlot.Id)
    //    {
    //        return NotFound();
    //    }

    //    if (ModelState.IsValid)
    //    {
    //        try
    //        {
    //            _context.Update(timeSlot);
    //            await _context.SaveChangesAsync();
    //        }
    //        catch (DbUpdateConcurrencyException)
    //        {
    //            if (!TimeSlotExists(timeSlot.Id))
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
    //    return View(timeSlot);
    //}

    //// GET: ClassSchedule/Delete/5
    //public async Task<IActionResult> Delete(int? id)
    //{
    //    if (id == null || _context.TimeSlots == null)
    //    {
    //        return NotFound();
    //    }

    //    var timeSlot = await _context.TimeSlots
    //        .FirstOrDefaultAsync(m => m.Id == id);
    //    if (timeSlot == null)
    //    {
    //        return NotFound();
    //    }

    //    return View(timeSlot);
    //}

    //// POST: ClassSchedule/Delete/5
    //[HttpPost, ActionName("Delete")]
    //[ValidateAntiForgeryToken]
    //public async Task<IActionResult> DeleteConfirmed(int id)
    //{
    //    if (_context.TimeSlots == null)
    //    {
    //        return Problem("Entity set 'YogaManagementDbContext.TimeSlots'  is null.");
    //    }
    //    var timeSlot = await _context.TimeSlots.FindAsync(id);
    //    if (timeSlot != null)
    //    {
    //        _context.TimeSlots.Remove(timeSlot);
    //    }

    //    await _context.SaveChangesAsync();
    //    return RedirectToAction(nameof(Index));
    //}

    //private bool TimeSlotExists(int id)
    //{
    //    return (_context.TimeSlots?.Any(e => e.Id == id)).GetValueOrDefault();
    //}
}
