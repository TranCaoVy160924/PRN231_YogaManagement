using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using YogaManagement.Business.Repositories;
using YogaManagement.Contracts.TimeSlot;

namespace YogaManagement.Application.Controllers;
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
        return Ok(_mapper.ProjectTo<ClassTimeSlotDTO>(_scheduleRepo.GetAllInclude()));
    }
}
