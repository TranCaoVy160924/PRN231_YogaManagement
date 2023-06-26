using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using YogaManagement.Application.Utilities;
using YogaManagement.Business.Repositories;
using YogaManagement.Contracts.TeacherEnrollment;
using YogaManagement.Domain.Models;

namespace YogaManagement.Application.Controllers;
public class TeacherEnrollmentsController : ODataController
{
    private readonly IMapper _mapper;
    private readonly TeacherEnrollmentRepository _tcErRepo;

    public TeacherEnrollmentsController(IMapper mapper, TeacherEnrollmentRepository tcrepo)
    {
        _mapper = mapper;
        _tcErRepo = tcrepo;
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
            var newTcEnr = _mapper.Map<TeacherEnrollment>(createRequest);
            newTcEnr.IsActive = true;
            await _tcErRepo.CreateAsync(newTcEnr);
            return Created(createRequest);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    public async Task<IActionResult> Patch([FromRoute] int key, [FromBody] Delta<TeacherEnrollmentDTO> delta)
    {
        var updateRequest = delta.GetInstance();
        var existEnroll = await _tcErRepo.Get(key);
        if (existEnroll == null)
        {
            return NotFound();
        }
        else
        {
            try
            {
                //var tcEnroll = _mapper.Map(updateRequest, existEnroll);
                existEnroll.StartDate = updateRequest.StartDate;
                existEnroll.EndDate = updateRequest.EndDate;
                existEnroll.TeacherProfileId = updateRequest.TeacherProfileId;
                existEnroll.YogaClassId = updateRequest.YogaClassId;
                existEnroll.IsActive = updateRequest.IsActive;
                await _tcErRepo.UpdateAsync(existEnroll);
                return Updated(existEnroll);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
            existEnroll.IsActive = false;
            await _tcErRepo.UpdateAsync(existEnroll);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
