﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using YogaManagement.Business.Repositories;
using YogaManagement.Contracts.TimeSlot;

namespace YogaManagement.Application.Controllers;

[Authorize]
public class ClassTimeSlotController : ODataController
{
    private readonly IMapper _mapper;
    private readonly ScheduleRepository _scheduleRepo;

    public ClassTimeSlotController(ScheduleRepository Repo,
        IMapper mapper)
    {
        _mapper = mapper;
        _scheduleRepo = Repo;
    }
    //get schedules of a class
    [EnableQuery]
    public ActionResult<IQueryable<ClassTimeSlotDTO>> Get()
    {
        var result = _mapper.Map<List<ClassTimeSlotDTO>>(_scheduleRepo.GetAllInclude().ToList());
        return Ok(result);
    }
}
