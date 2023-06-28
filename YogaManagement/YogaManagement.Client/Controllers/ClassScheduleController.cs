using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
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
    private readonly JwtManager _jwtManager;

    public ClassScheduleController(Container context, 
        INotyfService notyf,
        JwtManager jwtManager)
    {
        _context = context;
        _notyf = notyf;
        _jwtManager = jwtManager;
        _context.BuildingRequest += (sender, e) => _jwtManager.OnBuildingRequest(sender, e);
    }

    // GET: ClassSchedule
    [Authorize]
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

    // GET: ClassSchedule/Create
    [Authorize(Roles = "Staff")]
    public async Task<IActionResult> Create(int? id)
    {
        if (id == null)
        {
            _notyf.Error("Not found");
            return RedirectToAction(nameof(Index), new { id = id });
        }

        var ygClass = _context.YogaClasses
            .Where(x => x.Id == id).SingleOrDefault();
        if (ygClass.YogaClassStatus != "Pending")
        {
            _notyf.Warning("Only pending class's schedule can be edit");
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
    [Authorize(Roles = "Staff")]
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
}
