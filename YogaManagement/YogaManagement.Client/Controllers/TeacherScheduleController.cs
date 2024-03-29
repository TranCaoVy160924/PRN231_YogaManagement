﻿using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YogaManagement.Client.Helper;
using YogaManagement.Client.Models;
using YogaManagement.Client.OdataClient.Default;
using YogaManagement.Client.OdataClient.YogaManagement.Contracts.TimeSlot;
using DayOfWeek = YogaManagement.Client.OdataClient.System.DayOfWeek;

namespace YogaManagement.Client.Controllers;

[Authorize(Roles = "Teacher")]
public class TeacherScheduleController : Controller
{
    private readonly Container _context;
    private readonly INotyfService _notyf;
    private readonly JwtManager _jwtManager;

    public TeacherScheduleController(Container context,
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
    public IActionResult Index()
    {
        int TeacherId = _jwtManager.GetProfileId();
        try
        {
            var teacherSchedule = _context.TeacherSchedules
            .Where(x => x.TeacherProfileId == TeacherId)
            .ToList()
            .Select(x => x.TimeSlotId);

            var teacherTimeSlots = _context.TimeSlots
                .Where(x => teacherSchedule.Contains(x.Id))
                .ToList();

            ViewData["teacherId"] = TeacherId;
            return View(teacherTimeSlots);
        }
        catch (InvalidOperationException ex)
        {
            return RedirectToAction(nameof(Create), new { id = TeacherId }); ;
        }
        catch (Exception ex)
        {
            _notyf.Error(ex.Message);
            return RedirectToAction("Index", "Home");
        }
    }

    // GET: ClassSchedule/Create
    [Authorize(Roles = "Teacher")]
    public async Task<IActionResult> Create(int? id)
    {
        if (id == null)
        {
            _notyf.Error("Not found");
            return RedirectToAction(nameof(Index), new { id = id });
        }

        var teacherSchedules = _context.TeacherSchedules
            .Where(x => x.TeacherProfileId == id)
            .ToList();

        var scheduleId = teacherSchedules.Select(x => x.TimeSlotId);

        var teacherTimeSlots = _context.TimeSlots
            .OrderBy(x => x.DayOfWeek)
            .ToList();
        List<TimeSlotDTO> takenTimeSlot = new List<TimeSlotDTO>();
        foreach (var timeSlot in teacherTimeSlots)
        {
            timeSlot.Status = false;
            if (scheduleId.Contains(timeSlot.Id))
            {
                var teacherSchdule = teacherSchedules
                    .SingleOrDefault(x => x.TimeSlotId == timeSlot.Id);
                if (teacherSchdule.IsTaken)
                {
                   takenTimeSlot.Add(timeSlot);
                }
                else
                {
                    timeSlot.Status = true;
                }
            }
        }

        foreach(var timeSlot in takenTimeSlot)
        {
            teacherTimeSlots.Remove(timeSlot);
        }

        var model = new ScheduleViewModel
        {
            Id = id.Value
        };
        model.TimeSlots.AddRange(teacherTimeSlots);

        ViewData["teacherId"] = id;
        return View(model);
    }

    // POST: ClassSchedule/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [Authorize(Roles = "Teacher")]
    public async Task<IActionResult> Create(ScheduleViewModel model)
    {
        try
        {
            var originalSchedule = _context.TeacherSchedules
                .Where(x => x.TeacherProfileId == model.Id).ToList();

            foreach (var oldSchedule in originalSchedule)
            {
                if (!oldSchedule.IsTaken)
                {
                    _context.DeleteObject(oldSchedule);
                }
            }

            var schedule = model.TimeSlots
                .Where(x => x.Status)
                .Select(x => new TeacherScheduleDTO
                {
                    TimeSlotId = x.Id,
                    TeacherProfileId = model.Id,
                    IsTaken = false
                });

            foreach (var timeslot in schedule)
            {
                _context.AddToTeacherSchedules(timeslot);
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
