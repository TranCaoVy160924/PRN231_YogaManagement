using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using YogaManagement.Business.Repositories;
using YogaManagement.Contracts.Member.Response;
using YogaManagement.Domain.Models;

namespace YogaManagement.Application.Controllers;

public class MembersController : ODataController
{
    private readonly MemberRepository _memberRepo;
    private readonly UserManager<AppUser> _userManager;
    private readonly IMapper _mapper;

    public MembersController(MemberRepository memberRepo,
        UserManager<AppUser> userManager,
        IMapper mapper)
    {
        _memberRepo = memberRepo;
        _userManager = userManager;
        _mapper = mapper;
    }

    [EnableQuery]
    public ActionResult<IQueryable<Member>> Get()
    {
        return Ok(_mapper.ProjectTo<MemberResponse>(_memberRepo.GetAll()));
    }

    [EnableQuery]
    public async Task<ActionResult<MemberResponse>> Get([FromRoute] int key)
    {
        //var member = _memberRepo.GetAll()
        //    .SingleOrDefault(m => m.Id.Equals(key));

        var member = await _userManager.FindByIdAsync(key.ToString());

        if (member == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<MemberResponse>(member));
    }
}
