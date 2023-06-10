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

[ApiController]
[Route("odata/[controller]")]
public class YogaClassesController : ODataController
{
    private readonly IMapper _mapper;
    private readonly YogaClassRepository _ygclassrepo;

    public YogaClassesController(YogaClassRepository yogaClassRepository, IMapper mapper)
    {
        _mapper = mapper;
        _ygclassrepo = yogaClassRepository;
    }

    [HttpGet]
    [EnableQuery]
    public ActionResult<IQueryable<YogaClassResponse>> GetAll()
    {
        return Ok(_mapper.ProjectTo<YogaClassResponse>(_ygclassrepo.GetAll()));
    }

    [HttpGet("{key}")]
    public async Task<ActionResult<YogaClassResponse>> GetOneAsync([FromRoute] int key)
    {     
        var ygclass = await _ygclassrepo.Get(key);

        if (ygclass == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<YogaClassResponse>(ygclass));
    }

    [HttpPost]
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
                var newygclass = _mapper.Map<YogaClass>(ygclassrequest);
                newygclass.Status = true;
                await _ygclassrepo.CreateAsync(newygclass);
                return Created(newygclass);
            }
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] YogaClassCreateRequest ygclassrequest, int key)
    {
        var existclass = await _ygclassrepo.Get(key);
        if (existclass == null)
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
                    var newygclass = _mapper.Map(ygclassrequest, existclass);
                    await _ygclassrepo.UpdateAsync(newygclass);
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(int key)
    {
        var existclass = await _ygclassrepo.Get(key);
        if(existclass == null)
        {
            return NotFound();
        }
        try
        {
            existclass.Status = false;
            await _ygclassrepo.UpdateAsync(existclass);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
