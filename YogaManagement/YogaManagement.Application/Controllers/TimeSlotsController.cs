using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using YogaManagement.Business.Repositories;
using YogaManagement.Contracts.Category;
using YogaManagement.Contracts.TimeSlot;

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
        return Ok(_mapper.ProjectTo<TimeSlotDTO>(_tSlotRepo.GetAll()));
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
}
