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
    //get schedules teacher
    [EnableQuery]
    public ActionResult<IQueryable<TeacherScheduleDTO>> Get()
    {
        return Ok(_mapper.ProjectTo<TeacherScheduleDTO>(_Repo.GetAll()));
    }

    //get schedules of a teacher
    //public ActionResult<IQueryable<TeacherScheduleDTO>> Get(int keyTeacherProfileId)
    //{
    //    return Ok(_mapper.ProjectTo<TeacherScheduleDTO>(_Repo.GetScheduleOfATeacher(keyTeacherProfileId)));
    //}

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
    //update istaken when a teacher is asgined to a  class
    [HttpPut("odata/TeacherSchedules")]
    public async Task<IActionResult> Update(int keyTimeSlotId, int keyTeacherProfileId)
    {
        var existSchedule = _Repo.GetSchedule(keyTimeSlotId, keyTeacherProfileId);
        if (existSchedule == null)
        {
            return NotFound();
        }
        try
        {
            existSchedule.IsTaken = true;
            await _Repo.UpdateAsync(existSchedule);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    // delete 1 slot 
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
    // delete all time slot of 1 class
    [HttpDelete("odata/TeacherSchedules/TeacherProfileId")]
    public async Task<IActionResult> Delete(int keyTeacherProfileId)
    {
        var listSchedule = _Repo.GetScheduleOfATeacher(keyTeacherProfileId);
        if (listSchedule == null)
        {
            return NotFound();
        }
        try
        {
            foreach (var schedule in listSchedule)
            {
                await _Repo.DeleteAsync(schedule);
            }
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
