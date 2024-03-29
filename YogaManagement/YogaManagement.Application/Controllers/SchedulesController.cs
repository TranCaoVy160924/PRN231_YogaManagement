﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using YogaManagement.Application.Utilities;
using YogaManagement.Business.Repositories;
using YogaManagement.Contracts.TimeSlot;
using YogaManagement.Domain.Enums;
using YogaManagement.Domain.Models;

namespace YogaManagement.Application.Controllers;

[Authorize]
public class SchedulesController : ODataController
{
    private readonly IMapper _mapper;
    private readonly ScheduleRepository _scheduleRepo;
    private readonly YogaClassRepository _ygClassRepo;
    private readonly TeacherEnrollmentRepository _tcEnrollRepo;

    public SchedulesController(ScheduleRepository Repo,
        YogaClassRepository ygClassRepo,
        TeacherEnrollmentRepository tcEnrollRepo,
        IMapper mapper)
    {
        _mapper = mapper;
        _scheduleRepo = Repo;
        _ygClassRepo = ygClassRepo;
        _tcEnrollRepo = tcEnrollRepo;
    }

    [EnableQuery]
    public ActionResult<IQueryable<ScheduleDTO>> Get()
    {
        return Ok(_mapper.ProjectTo<ScheduleDTO>(_scheduleRepo.GetAll()));
    }

    [Authorize(Roles = "Staff")]
    public async Task<IActionResult> Post([FromBody] ScheduleDTO createRequest)
    {
        var existClass = await _ygClassRepo.Get(createRequest.YogaClassId);
        if (existClass == null)
        {
            return NotFound();
        }

        var existTcEnroll = await _tcEnrollRepo.GetAll()
            .Where(x => x.YogaClassId == createRequest.YogaClassId
                && x.IsActive)
            .ToListAsync();

        try
        {
            if (existClass.YogaClassStatus == YogaClassStatus.Active && existClass.Course.EnddDate < DateTime.Today)
            {
                throw new Exception("Cannot edit ongoing class");
            }

            if (existTcEnroll.Count > 0)
            {
                throw new Exception("Class have teacher enrolled! Schedule cannot be change");
            }
            
            ModelState.ValidateRequest();
            var newSchedule = _mapper.Map<Schedule>(createRequest);
            await _scheduleRepo.CreateAsync(newSchedule);
            return Created(createRequest);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [Authorize(Roles = "Staff")]
    public async Task<IActionResult> Delete([FromRoute] int keyTimeSlotId, [FromRoute] int keyYogaClassId)
    {
        var existClass = await _ygClassRepo.Get(keyYogaClassId);
        if (existClass == null)
        {
            return NotFound();
        }

        var existSchedule = _scheduleRepo.GetSchedule(keyTimeSlotId, keyYogaClassId);
        if (existSchedule == null)
        {
            return NotFound();
        }
        try
        {
            if (existClass.YogaClassStatus == YogaClassStatus.Active && existClass.Course.EnddDate < DateTime.Today)
            {
                throw new Exception("Cannot delete ongoing class");
            }

            await _scheduleRepo.DeleteAsync(existSchedule);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
