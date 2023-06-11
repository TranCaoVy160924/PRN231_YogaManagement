using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using YogaManagement.Business.Repositories;
using YogaManagement.Contracts.Course.Request;
using YogaManagement.Contracts.Course.Response;
using YogaManagement.Contracts.YogaClass.Request;
using YogaManagement.Contracts.YogaClass.Response;
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

    [EnableQuery(PageSize = 10)]
    public ActionResult<IQueryable<CourseResponse>> Get()
    {
        return Ok(_mapper.ProjectTo<CourseResponse>(_courseRepo.GetAll()));
    }
    [EnableQuery]
    public async Task<ActionResult<CourseResponse>> Get([FromRoute] int key)
    {
        var course = await _courseRepo.Get(key);
        var category = await _categoryRepo.Get(course.CategoryId);
        course.Category = category;
        if (course == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<CourseResponse>(course));
    }

    //[HttpPost("odata/[controller]")]
    public async Task<IActionResult> Post([FromBody] CourseCreateRequest courseRequest)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                var errorMessages = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();
                throw new Exception($"Invalid input format. Errors: {string.Join(", ", errorMessages)}");
            }
            else
            {
                var newCourse = _mapper.Map<Course>(courseRequest);
                newCourse.IsActive = true;
                await _courseRepo.CreateAsync(newCourse);
                return Created(newCourse);
            }
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    //[HttpPut("odata/[controller]")]
    public async Task<IActionResult> Put([FromRoute] int key, [FromBody] CourseCreateRequest courseRequest)
    {
        var existCourse = await _courseRepo.Get(key);
        if (existCourse == null)
        {
            return NotFound();
        }
        else
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errorMessages = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
                    throw new Exception($"Invalid input format. Errors: {string.Join(", ", errorMessages)}");
                }
                else
                {
                    
                    var course = _mapper.Map(courseRequest, existCourse);
                    await _courseRepo.UpdateAsync(course);
                    return Updated(course);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

    //[HttpDelete("odata/[controller]")]
    public async Task<IActionResult> Delete([FromRoute] int key)
    {
        var existCourse = await _courseRepo.Get(key);
        if (existCourse == null)
        {
            return NotFound();
        }
        try
        {
            if (existCourse.IsActive == true)
            {
                existCourse.IsActive = false;
            }
            else
            {
                existCourse.IsActive = true;
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
