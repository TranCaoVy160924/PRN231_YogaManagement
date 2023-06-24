﻿using AutoMapper;
using YogaManagement.Contracts.Authority;
using YogaManagement.Contracts.Category;
using YogaManagement.Contracts.Course;
using YogaManagement.Contracts.TeacherEnrollment;
using YogaManagement.Contracts.TimeSlot;
using YogaManagement.Contracts.Transaction;
using YogaManagement.Contracts.Wallet;
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

        #region TeacherEnrollment
        CreateMap<TeacherEnrollment, TeacherEnrollmentDTO>()
            .ForMember(dest => dest.TeacherName, otp =>
        {
            otp.MapFrom(src => src.TeacherProfile.AppUser.Firstname + " " + src.TeacherProfile.AppUser.Lastname);
        })
            .ForMember(dest => dest.ClassName, otp =>
        {
            otp.MapFrom(src => src.YogaClass.Name);
        });
        CreateMap<TeacherEnrollmentDTO, TeacherEnrollment>();
         #endregion
        
        #region TimeSlot
        CreateMap<TimeSlot, TimeSlotDTO>();
        #endregion

        #region Transaction
        CreateMap<Transaction, TransactionDTO>()
            .ForMember(dest => dest.TransactionType, otp => otp.MapFrom(src => src.TransactionType.ToString()));
        CreateMap<TransactionDTO, Transaction>()
            .ForMember(dest => dest.TransactionType, otp => otp.MapFrom(src => GetTransactionType(src.TransactionType)));
        #endregion

        #region Wallet
        CreateMap<Wallet, WalletDTO>();
        CreateMap<WalletDTO, Wallet>();
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
        if (user.Email.Contains("admin"))
        {
            role = "Admin";
        }

        return role;
    }

    private static YogaClassStatus GetYogaClassStatus(string statusString)
    {
        Enum.TryParse(statusString, out YogaClassStatus yogaClassStatus);
        return yogaClassStatus;
    }

    private static TransactionType GetTransactionType(string transacTypeString)
    {
        Enum.TryParse(transacTypeString, out TransactionType transactionType);
        return transactionType;
    }
}
