using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using YogaManagement.Business.Repositories;
using YogaManagement.Contracts.Category;
using YogaManagement.Contracts.Course;
using YogaManagement.Contracts.MemberLevel;

namespace YogaManagement.Application.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MemberLevelsController : ControllerBase
{
    private readonly MemberLevelDiscountRepository _mldRepo;

    public MemberLevelsController(MemberLevelDiscountRepository mldRepo)
    {
        _mldRepo = mldRepo;
    }

    [HttpGet]
    public ActionResult<MemberLevelDiscountDTO> Get()
    {
        var memberLevel = _mldRepo.Get();

        return Ok(memberLevel);
    }

    [HttpPatch]
    public IActionResult Patch([FromRoute] int key, [FromBody] Delta<MemberLevelDiscountDTO> delta)
    {
        var updateRequest = delta.GetInstance();

        _mldRepo.Edit(updateRequest);
        
        return Ok(updateRequest);
    }
}
