using AutoMapper;
using AutoMapper.Execution;
using YogaManagement.Domain.Models;
using YogaManagement.Contracts.Member.Response;

namespace YogaManagement.Application.MapperConfig;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        #region Member
        CreateMap<Domain.Models.Member, MemberResponse>()
            .ForMember(dest => dest.AppUserName, opt => opt.MapFrom(src => src.AppUser.UserName));
        #endregion
    }
}
