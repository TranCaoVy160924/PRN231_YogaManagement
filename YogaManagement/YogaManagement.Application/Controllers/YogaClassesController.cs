using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using YogaManagement.Application.Utilities;
using YogaManagement.Business.Repositories;
using YogaManagement.Contracts.YogaClass;
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
    public ActionResult<IQueryable<YogaClassDTO>> Get()
    {
        return Ok(_mapper.ProjectTo<YogaClassDTO>(_ygClassRepo.GetAll()));
    }

    [EnableQuery]
    public async Task<ActionResult<YogaClassDTO>> Get([FromRoute] int key)
    {
        var ygClass = await _ygClassRepo.Get(key);

        if (ygClass == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<YogaClassDTO>(ygClass));
    }

    public async Task<IActionResult> Post([FromBody] YogaClassDTO createRequest)
    {
        try
        {
            ModelState.ValidateRequest();
            var newYgClass = _mapper.Map<YogaClass>(createRequest);
            newYgClass.Status = true;
            await _ygClassRepo.CreateAsync(newYgClass);
            return Created(newYgClass);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

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
                var ygClass = _mapper.Map(updateRequest, existClass);
                await _ygClassRepo.UpdateAsync(ygClass);
                return Updated(ygClass);
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
        if (existClass == null)
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
