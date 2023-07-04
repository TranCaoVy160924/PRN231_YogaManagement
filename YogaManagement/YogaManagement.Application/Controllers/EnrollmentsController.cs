using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using YogaManagement.Application.Utilities;
using YogaManagement.Business.Repositories;
using YogaManagement.Contracts.Enrollment;
using YogaManagement.Domain.Models;

namespace YogaManagement.Application.Controllers;

[Authorize]
public class EnrollmentsController : ODataController
{
    private readonly IMapper _mapper;
    private readonly EnrollmentRepository _enrollmentRepo;
    private readonly CourseRepository _courseRepo;
    private readonly YogaClassRepository _yogaClassRepo;

    public EnrollmentsController(IMapper mapper, EnrollmentRepository repo,
        CourseRepository courseRepo,
        YogaClassRepository yogaClassRepo)
    {
        _mapper = mapper;
        _enrollmentRepo = repo;
        _courseRepo = courseRepo;
        _yogaClassRepo = yogaClassRepo;
    }

    [EnableQuery]
    public ActionResult<IQueryable<EnrollmentDTO>> Get()
    {
        var enrollments = _enrollmentRepo.GetAll()
            .Include(x => x.YogaClass)
            .ThenInclude(x => x.Course);
        return Ok(_mapper.ProjectTo<EnrollmentDTO>(enrollments));
    }

    [EnableQuery]
    public async Task<ActionResult<EnrollmentDTO>> Get([FromRoute] int keyMemberId, [FromRoute] int keyYogaClassId)
    {
        var Enr = _enrollmentRepo.GetAll()
            .Include(x => x.YogaClass)
            .ThenInclude(x => x.Course)
            .Where(x => x.YogaClassId == keyYogaClassId && x.MemberId == keyMemberId)
            .SingleOrDefault();

        if (Enr == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<EnrollmentDTO>(Enr));
    }

    public async Task<IActionResult> Post([FromBody] EnrollmentDTO createRequest)
    {
        try
        {
            ModelState.Remove("MemberName");
            ModelState.Remove("YogaClassName");
            ModelState.ValidateRequest();

            var existEnrollment = _enrollmentRepo.GetAll()
                .SingleOrDefault(x => x.YogaClassId == createRequest.YogaClassId
                    && x.MemberId == createRequest.MemberId);

            var course = _courseRepo.GetAll()
                .Single(x => x.Id == createRequest.CourseId);

            var ygClass = _yogaClassRepo.GetAll()
                .Single(x => x.Id == createRequest.YogaClassId);

            var classEnrollCount = _enrollmentRepo.GetAll()
                .Where(x => x.YogaClassId == createRequest.YogaClassId)
                .ToList().Count;

            if (existEnrollment != null)
            {
                throw new Exception("Already enrolled");
            }

            if (createRequest.EnrollDate > course.StartDate)
            {
                throw new Exception("Course already start");
            }

            if (classEnrollCount > ygClass.Size)
            {
                throw new Exception("Class is full");
            }

            var sameCourseEnrollment = _enrollmentRepo.GetAll()
                .SingleOrDefault(x => x.YogaClass.Course.Id == createRequest.CourseId
                    && x.MemberId == createRequest.MemberId);

            if (sameCourseEnrollment != null)
            {
                await _enrollmentRepo.DeleteAsync(sameCourseEnrollment);
            }

            var newEnr = _mapper.Map<Enrollment>(createRequest);
            await _enrollmentRepo.CreateAsync(newEnr);
            return Created(createRequest);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    public async Task<IActionResult> Delete([FromRoute] int keyMemberId, [FromRoute] int keyYogaClassId)
    {
        var existEnroll = _enrollmentRepo.GetEnrollment(keyMemberId, keyYogaClassId);
        if (existEnroll == null)
        {
            return NotFound();
        }
        try
        {
            await _enrollmentRepo.DeleteAsync(existEnroll);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
