﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using YogaManagement.Application.Utilities;
using YogaManagement.Business.Repositories;
using YogaManagement.Contracts.Enrollment;
using YogaManagement.Contracts.TeacherEnrollment;
using YogaManagement.Contracts.YogaClass;
using YogaManagement.Domain.Models;

namespace YogaManagement.Application.Controllers;
public class EnrollmentsController : ODataController
{
    private readonly IMapper _mapper;
    private readonly EnrollmentRepository _Repo;

    public EnrollmentsController(IMapper mapper, EnrollmentRepository repo)
    {
        _mapper = mapper;
        _Repo = repo;
    }

    [EnableQuery]
    public ActionResult<IQueryable<EnrollmentDTO>> Get()
    {
        return Ok(_mapper.ProjectTo<EnrollmentDTO>(_Repo.GetAll()));
    }
    [EnableQuery]
    public async Task<ActionResult<EnrollmentDTO>> Get([FromRoute] int key)
    {
        var Enr = await _Repo.Get(key);

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
            await _Repo.CreateAsync(newEnr);
            return Created(createRequest);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    public async Task<IActionResult> Patch([FromRoute] int key, [FromBody] Delta<EnrollmentDTO> delta)
    {
        var updateRequest = delta.GetInstance();
        var existEnroll = await _Repo.Get(key);
        if (existEnroll == null)
        {
            return NotFound();
        }
        else
        {
            try
            {
                //var tcEnroll = _mapper.Map(updateRequest, existEnroll);
                existEnroll.EnrollDate = updateRequest.EnrollDate;
                existEnroll.Discount = updateRequest.Discount;
                existEnroll.MemberId = updateRequest.MemberId;
                existEnroll.YogaClassId = updateRequest.YogaClassId;
                await _Repo.UpdateAsync(existEnroll);
                return Updated(existEnroll);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
    [HttpDelete()]
    public async Task<IActionResult> Delete(int key)
    {
        var existEnroll = await _Repo.Get(key);
        if (existEnroll == null)
        {
            return NotFound();
        }
        try
        {
            await _Repo.DeleteAsync(existEnroll);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
