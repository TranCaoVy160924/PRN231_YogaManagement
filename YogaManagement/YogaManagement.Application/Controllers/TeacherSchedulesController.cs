using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using YogaManagement.Application.Utilities;
using YogaManagement.Business.Repositories;
using YogaManagement.Contracts.TimeSlot;
using YogaManagement.Domain.Models;

namespace YogaManagement.Application.Controllers;
public class TeacherSchedulesController : ODataController
{
    private readonly IMapper _mapper;
    private readonly TeacherScheduleRepository _Repo;

    public TeacherSchedulesController(TeacherScheduleRepository Repo, IMapper mapper)
    {
        _mapper = mapper;
        _Repo = Repo;
    }

    [EnableQuery]
    public ActionResult<IQueryable<TeacherScheduleDTO>> Get()
    {
        return Ok(_mapper.ProjectTo<TeacherScheduleDTO>(_Repo.GetAll()));
    }

    public async Task<IActionResult> Post([FromBody] TeacherScheduleDTO createRequest)
    {
        try
        {
            createRequest.IsTaken = false;
            ModelState.ValidateRequest();
            var newTeacherSchedule = _mapper.Map<TeacherSchedule>(createRequest);
            await _Repo.CreateAsync(newTeacherSchedule);
            return Created(createRequest);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    public async Task<IActionResult> Delete([FromRoute] int keyTimeSlotId, [FromRoute] int keyTeacherProfileId)
    {
        var existSchedule = _Repo.GetSchedule(keyTimeSlotId, keyTeacherProfileId);
        if (existSchedule == null)
        {
            return NotFound();
        }
        try
        {
            await _Repo.DeleteAsync(existSchedule);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
