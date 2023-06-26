using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using YogaManagement.Application.Utilities;
using YogaManagement.Business.Repositories;
using YogaManagement.Contracts.TimeSlot;
using YogaManagement.Domain.Models;

namespace YogaManagement.Application.Controllers;
public class TimeSlotsController : ODataController
{
    private readonly IMapper _mapper;
    private readonly TimeSlotRepository _tSlotRepo;

    public TimeSlotsController(TimeSlotRepository tSlotRepo, IMapper mapper)
    {
        _mapper = mapper;
        _tSlotRepo = tSlotRepo;
    }

    [EnableQuery]
    public ActionResult<IQueryable<TimeSlotDTO>> Get()
    {
        var dateTimes = _tSlotRepo.GetAll().ToList();
        return Ok(_mapper.Map<List<TimeSlotDTO>>(dateTimes));
    }

    [EnableQuery]
    public async Task<ActionResult<TimeSlotDTO>> Get([FromRoute] int key)
    {
        var timeSlot = await _tSlotRepo.Get(key);

        if (timeSlot == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<TimeSlotDTO>(timeSlot));
    }
    //public async Task<IActionResult> Post([FromBody] TimeSlotDTO createRequest)
    //{
    //    try
    //    {
    //        ModelState.ValidateRequest();
    //        var newTimeSlot = _mapper.Map<TimeSlot>(createRequest);
    //        newTimeSlot.Status = true;
    //        await _tSlotRepo.CreateAsync(newTimeSlot);
    //        return Created(createRequest);
    //    }
    //    catch (Exception ex)
    //    {
    //        return BadRequest(ex.Message);
    //    }
    //}
    //public async Task<IActionResult> Patch([FromRoute] int key, [FromBody] Delta<TimeSlotDTO> delta)
    //{
    //    var updateRequest = delta.GetInstance();
    //    var existTimeSlot = await _tSlotRepo.Get(key);
    //    if (existTimeSlot == null)
    //    {
    //        return NotFound();
    //    }
    //    else
    //    {
    //        try
    //        {
    //            var timeSlot = _mapper.Map(updateRequest, existTimeSlot);
    //            await _tSlotRepo.UpdateAsync(timeSlot);
    //            return Updated(updateRequest);
    //        }
    //        catch (Exception ex)
    //        {
    //            return BadRequest(ex.Message);
    //        }
    //    }
    //}
    //public async Task<IActionResult> Delete([FromRoute] int key)
    //{
    //    var existTimeSlot = await _tSlotRepo.Get(key);
    //    if (existTimeSlot == null)
    //    {
    //        return NotFound();
    //    }
    //    try
    //    {
    //        existTimeSlot.Status = false;
    //        await _tSlotRepo.UpdateAsync(existTimeSlot);
    //        return NoContent();
    //    }
    //    catch (Exception ex)
    //    {
    //        return BadRequest(ex.Message);
    //    }
    //}
}
