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

    public EnrollmentsController(IMapper mapper, EnrollmentRepository repo)
    {
        _mapper = mapper;
        _enrollmentRepo = repo;
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
            var newEnr = _mapper.Map<Enrollment>(createRequest);
            await _enrollmentRepo.CreateAsync(newEnr);
            return Created(createRequest);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    public async Task<IActionResult> Patch([FromRoute] int keyMemberId, [FromRoute] int keyYogaClassId, [FromBody] Delta<EnrollmentDTO> delta)
    {
        var updateRequest = delta.GetInstance();
        var existEnroll = _enrollmentRepo.GetEnrollment(keyMemberId, keyYogaClassId);
        if (existEnroll == null)
        {
            return NotFound();
        }
        else
        {
            try
            {
                var Enroll = _mapper.Map(updateRequest, existEnroll);
                //existEnroll.EnrollDate = updateRequest.EnrollDate;
                //existEnroll.Discount = updateRequest.Discount;
                //existEnroll.MemberId = updateRequest.MemberId;
                //existEnroll.YogaClassId = updateRequest.YogaClassId;
                await _enrollmentRepo.UpdateAsync(Enroll);
                return Updated(updateRequest);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
