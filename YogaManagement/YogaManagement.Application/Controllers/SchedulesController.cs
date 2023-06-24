using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using YogaManagement.Application.Utilities;
using YogaManagement.Business.Repositories;
using YogaManagement.Contracts.TimeSlot;
using YogaManagement.Domain.Models;

namespace YogaManagement.Application.Controllers;
public class SchedulesController : ODataController
{
    private readonly IMapper _mapper;
    private readonly ScheduleRepository _Repo;

    public SchedulesController(ScheduleRepository Repo, IMapper mapper)
    {
        _mapper = mapper;
        _Repo = Repo;
    }
    //get schedules of a class
    [EnableQuery]
    public ActionResult<IQueryable<ScheduleDTO>> Get(int YogaClassId)
    {
        return Ok(_mapper.ProjectTo<ScheduleDTO>(_Repo.GetScheduleOfAClass(YogaClassId)));
    }
    public async Task<IActionResult> Post([FromBody] ScheduleDTO createRequest)
    {
        try
        {
            ModelState.ValidateRequest();
            var newSchedule = _mapper.Map<Schedule>(createRequest);
            await _Repo.CreateAsync(newSchedule);
            return Created(createRequest);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    // delete 1 slot 
    public async Task<IActionResult> Delete([FromRoute] int keyTimeSlotId, [FromRoute] int keyYogaClassId)
    {
        var existSchedule = _Repo.GetSchedule(keyTimeSlotId,keyYogaClassId);
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
    [HttpDelete("odata/Schedules/yogaClassId")]
    public async Task<IActionResult> Delete(int keyYogaClassId)
    {
        var listSchedule = _Repo.GetScheduleOfAClass(keyYogaClassId);
        if (listSchedule == null)
        {
            return NotFound();
        }
        try
        {
            foreach(var schedule in listSchedule)
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
