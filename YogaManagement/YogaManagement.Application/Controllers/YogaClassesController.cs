using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using YogaManagement.Business.Repositories;
using YogaManagement.Contracts.YogaClass.Request;
using YogaManagement.Contracts.YogaClass.Response;
using YogaManagement.Domain.Models;

namespace YogaManagement.Application.Controllers;

//[ApiController]
//[Route("[controller]")]
public class YogaClassesController : ODataController
{
    private readonly IMapper _mapper;
    private readonly YogaClassRepository _ygclassrepo;

    public YogaClassesController(YogaClassRepository yogaClassRepository, IMapper mapper)
    {
        _mapper = mapper;
        _ygclassrepo = yogaClassRepository;
    }

    [EnableQuery]
    public ActionResult<IQueryable<YogaClass>> Get()
    {
        return Ok(_mapper.ProjectTo<YogaClassResponse>(_ygclassrepo.GetAll()));
    }

    [HttpGet("{key}")]
    public async Task<ActionResult<YogaClassResponse>> Get([FromRoute] int key)
    {     
        var ygclass = await _ygclassrepo.Get(key);

        if (ygclass == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<YogaClassResponse>(ygclass));
    }

    [HttpPost("create")]
    public async Task<IActionResult> Post([FromBody] YogaClassCreateRequest ygclassrequest)
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
                return NoContent();
            }
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("update")]
    public async Task<IActionResult> Put([FromBody] YogaClassCreateRequest ygclassrequest, int key)
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

    [HttpDelete("delete")]
    public async Task<IActionResult> Delete(int key)
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
