using AutoMapper;
using YogaManagement.Contracts.Authority;
using YogaManagement.Contracts.Category;
using YogaManagement.Contracts.Course;
using YogaManagement.Contracts.YogaClass;
using YogaManagement.Domain.Enums;
using YogaManagement.Domain.Models;

namespace YogaManagement.Application.MapperConfig;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        #region YogaClass
        CreateMap<YogaClass, YogaClassDTO>()
            .ForMember(dest => dest.CourseName, otp => otp.MapFrom(src => src.Course.Name))
            .ForMember(dest => dest.YogaClassStatus, otp => otp.MapFrom(src => src.YogaClassStatus.ToString()));
        CreateMap<YogaClassDTO, YogaClass>()
            .ForMember(dest => dest.YogaClassStatus, otp => otp.MapFrom(src => GetYogaClassStatus(src.YogaClassStatus)));
        #endregion

        #region AppUser
        CreateMap<Domain.Models.AppUser, UserDTO>()
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => GetUserRoleName(src)));
        CreateMap<UserDTO, Domain.Models.AppUser>();
        #endregion

        #region Course
        CreateMap<Course, CourseDTO>().ForMember(dest => dest.CategoryName, otp =>
        {
            otp.MapFrom(src => src.Category.Name);
        });
        CreateMap<CourseDTO, Course>();
        #endregion

        #region Category
        CreateMap<Category, CategoryDTO>();
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

    private static YogaClassStatus GetYogaClassStatus(string statusString)
    {
        Enum.TryParse(statusString, out YogaClassStatus yogaClassStatus);
        return yogaClassStatus;
    }
}
