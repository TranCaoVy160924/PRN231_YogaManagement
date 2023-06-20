using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using YogaManagement.Application.Utilities;
using YogaManagement.Business.Repositories;
using YogaManagement.Contracts.Course;
using YogaManagement.Domain.Enums;
using YogaManagement.Domain.Models;

namespace YogaManagement.Application.Controllers;

public class CoursesController : ODataController
{
    private readonly IMapper _mapper;
    private readonly CourseRepository _courseRepo;
    private readonly CategoryRepository _categoryRepo;

    public CoursesController(CourseRepository courseRepository, CategoryRepository categoryRepository, IMapper mapper)
    {
        _mapper = mapper;
        _courseRepo = courseRepository;
        _categoryRepo = categoryRepository;
    }

    [Authorize]
    public ActionResult<IQueryable<CourseDTO>> Get()
    {
        return Ok(_mapper.ProjectTo<CourseDTO>(_courseRepo.GetAll()));
    }

    [EnableQuery]
    [Authorize]
    public async Task<ActionResult<CourseDTO>> Get([FromRoute] int key)
    {
        var course = await _courseRepo.Get(key);
        var category = await _categoryRepo.Get(course.CategoryId);
        course.Category = category;
        if (course == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<CourseDTO>(course));
    }

    [Authorize(Roles = "Staff")]
    public async Task<IActionResult> Post([FromBody] CourseDTO createRequest)
    {
        try
        {
            ModelState.ValidateRequest();
            var newCourse = _mapper.Map<Course>(createRequest);
            newCourse.IsActive = true;
            await _courseRepo.CreateAsync(newCourse);
            return Created(createRequest);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [Authorize(Roles = "Staff")]
    public async Task<IActionResult> Patch([FromRoute] int key, [FromBody] Delta<CourseDTO> delta)
    {
        var updateRequest = delta.GetInstance();
        var existCourse = await _courseRepo.Get(key);
        if (existCourse == null)
        {
            return NotFound();
        }
        else
        {
            try
            {
                var course = _mapper.Map(updateRequest, existCourse);
                await _courseRepo.UpdateAsync(course);
                return Updated(updateRequest);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

    [Authorize(Roles = "Staff")]
    public async Task<IActionResult> Delete([FromRoute] int key)
    {
        var existCourse = await _courseRepo.Get(key);
        if (existCourse == null)
        {
            return NotFound();
        }
        try
        {
            if (existCourse.YogaClasses.Any(c => c.YogaClassStatus == YogaClassStatus.Active))
            {
                throw new Exception("Course have ongoing class");
            }

            if (existCourse.IsActive)
            {
                existCourse.IsActive = false;
            }

            await _courseRepo.UpdateAsync(existCourse);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
