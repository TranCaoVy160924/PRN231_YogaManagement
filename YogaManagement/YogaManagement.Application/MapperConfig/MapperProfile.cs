using AutoMapper;
using YogaManagement.Contracts.YogaClass.Request;
using YogaManagement.Contracts.YogaClass.Response;
using YogaManagement.Contracts.Authority.Response;
using YogaManagement.Domain.Models;
using YogaManagement.Contracts.Authority;

namespace YogaManagement.Application.MapperConfig;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        #region YogaClass
        CreateMap<YogaClassCreateRequest, YogaClass>();
        CreateMap<YogaClassUpdateRequest, YogaClass>();
        CreateMap<YogaClass, YogaClassResponse>().ForMember(dest => dest.CourseName, otp =>
        {
            otp.MapFrom(src => src.Course.Name);
        });
        #endregion

        #region AppUser
        CreateMap<Domain.Models.AppUser, UserDTO>()
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
