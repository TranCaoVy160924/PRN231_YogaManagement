using AutoMapper;
using YogaManagement.Contracts.YogaClass.Request;
using YogaManagement.Contracts.YogaClass.Response;
using YogaManagement.Domain.Models;

namespace YogaManagement.Application.MapperConfig;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        //#region Job
        //CreateMap<Job, JobResponse>()
        //    .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.Categories.Select(c => c.CategoryId)))
        //    .ForMember(dest => dest.BusinessName, opt => opt.MapFrom(src => src.BusinessProfile.BusinessName));
        //#endregion
        CreateMap<YogaClassCreateRequest, YogaClass>();
        CreateMap<YogaClass, YogaClassResponse>().ForMember(dest => dest.CourseName, otp =>
        {
            otp.MapFrom(src => src.Course.Name);
        });
        
    }
}
