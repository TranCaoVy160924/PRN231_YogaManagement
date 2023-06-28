using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using YogaManagement.Application.Utilities;
using YogaManagement.Business.Repositories;
using YogaManagement.Contracts.TeacherEnrollment;
using YogaManagement.Domain.Models;

namespace YogaManagement.Application.Controllers;
public class TeacherEnrollmentsController : ODataController
{
    private readonly IMapper _mapper;
    private readonly TeacherEnrollmentRepository _tcErRepo;
    private readonly TeacherScheduleRepository _tcScheduleRepo;
    private readonly ScheduleRepository _scheduleRepo;

    public TeacherEnrollmentsController(IMapper mapper,
        TeacherEnrollmentRepository tcrepo,
        TeacherScheduleRepository tcScheduleRepo,
        ScheduleRepository scheduleRepo)
    {
        _mapper = mapper;
        _tcErRepo = tcrepo;
        _tcScheduleRepo = tcScheduleRepo;
        _scheduleRepo = scheduleRepo;
    }

    [EnableQuery]
    public ActionResult<IQueryable<TeacherEnrollmentDTO>> Get()
    {
        return Ok(_mapper.ProjectTo<TeacherEnrollmentDTO>(_tcErRepo.GetAll()));
    }

    [EnableQuery]
    public async Task<ActionResult<TeacherEnrollmentDTO>> Get([FromRoute] int key)
    {
        var tcEnr = await _tcErRepo.Get(key);

        if (tcEnr == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<TeacherEnrollmentDTO>(tcEnr));
    }

    public async Task<IActionResult> Post([FromBody] TeacherEnrollmentDTO createRequest)
    {
        try
        {
            ModelState.Remove("TeacherName");
            ModelState.Remove("ClassName");
            ModelState.ValidateRequest();

            var tcSchedule = _tcScheduleRepo.GetAll()
                .Include(x => x.TimeSlot)
                .Where(x => x.TeacherProfileId == createRequest.TeacherProfileId
                    && !x.IsTaken)
                .ToList();

            var classSchedule = _scheduleRepo.GetAll()
                .Include(x => x.TimeSlot)   
                .Where(x => x.YogaClassId == createRequest.YogaClassId)
                .ToList().Select(x => x.TimeSlotId);

            foreach (var timeSlot in classSchedule)
            {
                if (!tcSchedule.Select(x => x.TimeSlotId).Contains(timeSlot))
                {
                    throw new Exception("Teacher dont have available time slot for class");
                }
            }

            var newTcEnr = _mapper.Map<TeacherEnrollment>(createRequest);
            newTcEnr.IsActive = true;
            await _tcErRepo.CreateAsync(newTcEnr);

            foreach (var timeSlot in classSchedule)
            {
                var teacherTimeSlot = tcSchedule
                    .SingleOrDefault(x => x.TimeSlotId == timeSlot);
                teacherTimeSlot.IsTaken = true;
                await _tcScheduleRepo.UpdateAsync(teacherTimeSlot);
            }
            return Created(createRequest);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    public async Task<IActionResult> Delete(int key)
    {
        var existEnroll = await _tcErRepo.Get(key);
        if (existEnroll == null)
        {
            return NotFound();
        }
        try
        {
            var tcSchedule = _tcScheduleRepo.GetAll()
                .Include(x => x.TimeSlot)
                .Where(x => x.TeacherProfileId == existEnroll.TeacherProfileId
                    && !x.IsTaken)
                .ToList();

            var classSchedule = _scheduleRepo.GetAll()
                .Include(x => x.TimeSlot)
                .Where(x => x.YogaClassId == existEnroll.YogaClassId)
                .ToList().Select(x => x.TimeSlotId);

            existEnroll.IsActive = false;
            await _tcErRepo.UpdateAsync(existEnroll);

            foreach (var timeSlot in classSchedule)
            {
                var teacherTimeSlot = tcSchedule
                    .SingleOrDefault(x => x.TimeSlotId == timeSlot);
                teacherTimeSlot.IsTaken = false;
                await _tcScheduleRepo.UpdateAsync(teacherTimeSlot);
            }
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
