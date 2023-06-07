using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using System.Reflection.Metadata;
using YogaManagement.Business.Repositories;
using YogaManagement.Contracts.Member.Response;
using YogaManagement.Domain.Models;

namespace YogaManagement.Application.Controllers;

public class MembersController : ODataController
{
    private readonly MemberRepository _memberRepo;
    private readonly IMapper _mapper;

    public MembersController(MemberRepository memberRepo, IMapper mapper)
    {
        _memberRepo = memberRepo;
        _mapper = mapper;
    }
    [EnableQuery]
    public ActionResult<IQueryable<Member>> Get()
    {
        return Ok(_memberRepo.GetAll());
    }

    [EnableQuery]
    public ActionResult<Member> Get([FromRoute] int key)
    {
        var member = _memberRepo.GetAll()
            .SingleOrDefault(d => d.Id.Equals(key));

        if (member == null)
        {
            return NotFound();
        }

        return Ok(member);
    }
}
