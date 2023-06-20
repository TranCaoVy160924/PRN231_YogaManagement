using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using YogaManagement.Application.Utilities;
using YogaManagement.Business.Repositories;
using YogaManagement.Contracts.YogaClass;
using YogaManagement.Domain.Enums;
using YogaManagement.Domain.Models;

namespace YogaManagement.Application.Controllers;
public class YogaClassesController : ODataController
{
    private readonly IMapper _mapper;
    private readonly YogaClassRepository _ygClassRepo;
    private readonly CourseRepository _courseRepo;

    public YogaClassesController(YogaClassRepository yogaClassRepository,
        IMapper mapper,
        CourseRepository courseRepo)
    {
        _mapper = mapper;
        _ygClassRepo = yogaClassRepository;
        _courseRepo = courseRepo;
    }

    [EnableQuery]
    [Authorize]
    public ActionResult<IQueryable<YogaClassDTO>> Get()
    {
        return Ok(_mapper.ProjectTo<YogaClassDTO>(_ygClassRepo.GetAll()));
    }

    [EnableQuery]
    [Authorize]
    public async Task<ActionResult<YogaClassDTO>> Get([FromRoute] int key)
    {
        var ygClass = await _ygClassRepo.Get(key);

        if (ygClass == null)
        {
            return NotFound();
        }
        //var ygclassout = _mapper.Map<YogaClassDTO>(ygClass);

        return Ok(_mapper.Map<YogaClassDTO>(ygClass));
    }

    [Authorize(Roles = "Staff")]
    public async Task<IActionResult> Post([FromBody] YogaClassDTO createRequest)
    {
        try
        {
            ModelState.Remove("CourseName");
            ModelState.ValidateRequest();

            Course course = await _courseRepo.Get(createRequest.CourseId);
            if (!course.IsActive)
            {
                throw new Exception("Course is inactive");
            }
            if (course.StartDate < DateTime.Today && course.EnddDate > DateTime.Today)
            {
                throw new Exception("Course already started");
            }
            if (course.EnddDate < DateTime.Today)
            {
                throw new Exception("Course already ended");
            }

            var newYgClass = _mapper.Map<YogaClass>(createRequest);
            newYgClass.YogaClassStatus = YogaClassStatus.Pending;
            await _ygClassRepo.CreateAsync(newYgClass);
            return Created(createRequest);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [Authorize(Roles = "Staff")]
    public async Task<IActionResult> Patch([FromRoute] int key, [FromBody] Delta<YogaClassDTO> delta)
    {
        var updateRequest = delta.GetInstance();
        var existClass = await _ygClassRepo.Get(key);
        if (existClass == null)
        {
            return NotFound();
        }
        else
        {
            try
            {
                if (updateRequest.CourseId != existClass.CourseId)
                {
                    throw new Exception("Course cannot be change");
                }

                existClass.Status = updateRequest.Status;
                existClass.Size = updateRequest.Size;
                existClass.Name = updateRequest.Name;
                await _ygClassRepo.UpdateAsync(existClass);
                return Updated(existClass);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

    [Authorize(Roles = "Staff")]
    public async Task<IActionResult> Delete(int key)
    {
        var existClass = await _ygClassRepo.Get(key);
        if (existClass == null)
        {
            return NotFound();
        }

        try
        {
            if (existClass.YogaClassStatus == YogaClassStatus.Active && existClass.Course.EnddDate < DateTime.Today)
            {
                throw new Exception("Cannot delete ongoing class");
            }

            existClass.YogaClassStatus = YogaClassStatus.Inactive;
            await _ygClassRepo.UpdateAsync(existClass);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
