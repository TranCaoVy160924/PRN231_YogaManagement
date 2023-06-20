using AutoMapper;
using YogaManagement.Contracts.Authority;
using YogaManagement.Contracts.Category;
using YogaManagement.Contracts.Course;
using YogaManagement.Contracts.TimeSlot;
using YogaManagement.Contracts.YogaClass;
using YogaManagement.Domain.Models;

namespace YogaManagement.Application.MapperConfig;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        #region YogaClass
        CreateMap<YogaClass, YogaClassDTO>().ForMember(dest => dest.CourseName, otp =>
        {
            otp.MapFrom(src => src.Course.Name);
        });
        CreateMap<YogaClassDTO, YogaClass>();
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

        #region TimeSlot
        CreateMap<TimeSlot, TimeSlotDTO>();
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
