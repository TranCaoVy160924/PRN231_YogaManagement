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

    [EnableQuery]
    public async Task<ActionResult<YogaClassResponse>> Get([FromRoute] int id)
    {     
        var ygclass = await _ygclassrepo.Get(id);

        if (ygclass == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<YogaClassResponse>(ygclass));
    }

    public async Task<IActionResult> Post([FromBody] YogaClassCreateRequest ygclassrequest)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("Some fields might be inputted wrong format");
            }
            else
            {
                var newygclass = _mapper.Map<YogaClass>(ygclassrequest);
                newygclass.Status = true;
                await _ygclassrepo.CreateAsync(newygclass);
                return NoContent();
            }
        }catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        
    }

    public async Task<IActionResult> Put([FromBody] YogaClassCreateRequest ygclassrequest, [FromRoute] int id)
    {
        var existclass = await _ygclassrepo.Get(id); 
        if (existclass == null)
        {
            return NotFound();
        }
        try
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("Some fields might be inputted wrong format");
            }
            else
            {
                var newygclass = _mapper.Map<YogaClass>(ygclassrequest);
                await _ygclassrepo.UpdateAsync(newygclass);
                return NoContent();
            }
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var existclass = await _ygclassrepo.Get(id);
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
