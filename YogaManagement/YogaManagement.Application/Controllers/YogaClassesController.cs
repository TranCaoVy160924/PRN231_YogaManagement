using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using YogaManagement.Business.Repositories;
using YogaManagement.Contracts.YogaClass.Request;
using YogaManagement.Contracts.YogaClass.Response;
using YogaManagement.Domain.Models;

namespace YogaManagement.Application.Controllers;
public class YogaClassesController : ODataController
{
    private readonly IMapper _mapper;
    private readonly YogaClassRepository _ygClassRepo;

    public YogaClassesController(YogaClassRepository yogaClassRepository, IMapper mapper)
    {
        _mapper = mapper;
        _ygClassRepo = yogaClassRepository;
    }

    [EnableQuery(PageSize = 10)]
    public ActionResult<IQueryable<YogaClassResponse>> Get()
    {
        return Ok(_mapper.ProjectTo<YogaClassResponse>(_ygClassRepo.GetAll()));
    }

    [EnableQuery]
    public async Task<ActionResult<YogaClassResponse>> Get([FromRoute] int key)
    {
        var ygclass = await _ygClassRepo.Get(key);

        if (ygclass == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<YogaClassResponse>(ygclass));
    }

    [HttpPost("odata/[controller]")]
    public async Task<IActionResult> CreateAsync([FromBody] YogaClassCreateRequest ygclassrequest)
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
                var newYgClass = _mapper.Map<YogaClass>(ygclassrequest);
                newYgClass.Status = true;
                await _ygClassRepo.CreateAsync(newYgClass);
                return Created(newYgClass);
            }
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("odata/[controller]")]
    public async Task<IActionResult> UpdateAsync([FromBody] YogaClassUpdateRequest ygClassRequest)
    {
        var existClass = await _ygClassRepo.Get(ygClassRequest.Id);
        if (existClass == null)
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
                    var ygClass = _mapper.Map(ygClassRequest, existClass);
                    await _ygClassRepo.UpdateAsync(ygClass);
                    return Updated(ygClass);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

    [HttpDelete("odata/[controller]")]
    public async Task<IActionResult> DeleteAsync(int key)
    {
        var existClass = await _ygClassRepo.Get(key);
        if(existClass == null)
        {
            return NotFound();
        }
        try
        {
            existClass.Status = false;
            await _ygClassRepo.UpdateAsync(existClass);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
