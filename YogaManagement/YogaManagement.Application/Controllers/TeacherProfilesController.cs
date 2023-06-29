using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using YogaManagement.Business.Repositories;
using YogaManagement.Contracts.Course;
using YogaManagement.Contracts.TeacherProfile;

namespace YogaManagement.Application.Controllers;
[Authorize]
public class TeacherProfilesController : ODataController
{
    private readonly IMapper _mapper;
    private readonly TeacherProfileRepository _tcProfileRepo;

    public ActionResult<IQueryable<TeacherProfileDTO>> Get()
    {
        return Ok(_mapper.ProjectTo<TeacherProfileDTO>(_tcProfileRepo.GetAll()));
    }

    [EnableQuery]
    public async Task<ActionResult<TeacherProfileDTO>> Get([FromRoute] int key)
    {
        var teacher = _tcProfileRepo.GetAll()
            .SingleOrDefault(x => x.Id == key);

        return Ok(_mapper.Map<TeacherProfileDTO>(teacher));
    }
}
