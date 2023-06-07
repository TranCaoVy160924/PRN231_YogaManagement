using AutoMapper;
using YogaManagement.Contracts.Authority.Response;
using YogaManagement.Domain.Models;

namespace YogaManagement.Application.MapperConfig;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        #region AppUser
        CreateMap<Domain.Models.AppUser, UserResponse>()
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => GetUserRoleName(src)));
        #endregion
    }

    private static string GetUserRoleName(AppUser user)
    {
        string role = "Staff";
        if (user.TeacherProfile != null)
        {
            role = "Teacher";
        }
        if (user.Member != null)
        {
            role = "Member";
        }

        return role;
    }
}
