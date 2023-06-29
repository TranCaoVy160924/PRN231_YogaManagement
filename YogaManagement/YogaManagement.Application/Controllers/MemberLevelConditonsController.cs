using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using YogaManagement.Business.Repositories;
using YogaManagement.Contracts.MemberLevel;

namespace YogaManagement.Application.Controllers;
[Authorize(Roles = "Admin")]
public class MemberLevelConditonsController : ODataController
{
    private readonly MemberLevelConditonRepository _mldRepo;

    public MemberLevelConditonsController(MemberLevelConditonRepository mldRepo)
    {
        _mldRepo = mldRepo;
    }

    public ActionResult<MemberLevelDiscountDTO> Get()
    {
        var memberLevel = _mldRepo.Get();

        return Ok(memberLevel);
    }

    public ActionResult<MemberLevelDiscountDTO> Get([FromRoute] int key)
    {
        var memberLevel = _mldRepo.Get();

        return Ok(memberLevel);
    }

    public IActionResult Patch([FromRoute] int key, [FromBody] Delta<MemberLevelDiscountDTO> delta)
    {
        var updateRequest = delta.GetInstance();

        _mldRepo.Edit(updateRequest);

        return Ok(updateRequest);
    }
}