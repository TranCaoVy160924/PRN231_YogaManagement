using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using YogaManagement.Domain.Enums;
using YogaManagement.Domain.Models;

namespace YogaManagement.Data.Extensions;
public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        var memberRoleId = 1;
        var teacherRoleId = 2;
        var staffRoleId = 3;
        var AdminRoleId = 4;

        var hasher = new PasswordHasher<AppUser>();

        #region Role
        modelBuilder.Entity<AppRole>().HasData(new AppRole
        {
            Id = memberRoleId,
            Name = "Member",
            NormalizedName = "member",
            Description = "MEMBER"
        });

        modelBuilder.Entity<AppRole>().HasData(new AppRole
        {
            Id = teacherRoleId,
            Name = "Teacher",
            NormalizedName = "teacher",
            Description = "TEACHER"
        });

        modelBuilder.Entity<AppRole>().HasData(new AppRole
        {
            Id = staffRoleId,
            Name = "Staff",
            NormalizedName = "staff",
            Description = "STAFF"
        });

        modelBuilder.Entity<AppRole>().HasData(new AppRole
        {
            Id = AdminRoleId,
            Name = "Admin",
            NormalizedName = "admin",
            Description = "ADMIN"
        });
        #endregion

        #region Member
        for (int i = 1; i <= 30; i++)
        {
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = i,
                UserName = "UserMember" + i.ToString(),
                NormalizedUserName = "usermember" + i.ToString(),
                Email = "member" + i.ToString() + "@gmail.com",
                NormalizedEmail = "member" + i.ToString() + "@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "12345678"),
                SecurityStamp = string.Empty,
                Firstname = "Name" + i.ToString(),
                Lastname = "LastName" + i.ToString(),
                Address = "HCM",
                Status = true,
            });

            modelBuilder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>
            {
                RoleId = memberRoleId,
                UserId = i
            });

            modelBuilder.Entity<Member>().HasData(new Member
            {
                Id = i,
                AppUserId = i,
                MemberLevel = MemberLevel.None
            });
        }
        #endregion

        #region Teacher
        for (int i = 31; i <= 40; i++)
        {
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = i,
                UserName = "UserTeacher" + i.ToString(),
                NormalizedUserName = "userteacher" + i.ToString(),
                Email = "teacher" + i.ToString() + "@gmail.com",
                NormalizedEmail = "teacher" + i.ToString() + "@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "12345678"),
                SecurityStamp = string.Empty,
                Firstname = "Name" + i.ToString(),
                Lastname = "LastName" + i.ToString(),
                Address = "HCM",
                Status = true,
            });

            modelBuilder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>
            {
                RoleId = teacherRoleId,
                UserId = i
            });

            modelBuilder.Entity<TeacherProfile>().HasData(new TeacherProfile
            {
                Id = i,
                AppUserId = i
            });
        }
        #endregion

        #region Staff
        for (int i = 41; i <= 45; i++)
        {
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = i,
                UserName = "UserStaff" + i.ToString(),
                NormalizedUserName = "userstaff" + i.ToString(),
                Email = "staff" + i.ToString() + "@gmail.com",
                NormalizedEmail = "staff" + i.ToString() + "@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "12345678"),
                SecurityStamp = string.Empty,
                Firstname = "Name" + i.ToString(),
                Lastname = "LastName" + i.ToString(),
                Address = "HCM",
                Status = true,
            });

            modelBuilder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>
            {
                RoleId = staffRoleId,
                UserId = i
            });
        }
        #endregion

        #region Admin
        modelBuilder.Entity<AppUser>().HasData(new AppUser
        {
            Id = 46,
            UserName = "UserAdmin46",
            NormalizedUserName = "useradmin46",
            Email = "admin46" + "@gmail.com",
            NormalizedEmail = "admin46" + "@gmail.com",
            EmailConfirmed = true,
            PasswordHash = hasher.HashPassword(null, "12345678"),
            SecurityStamp = string.Empty,
            Firstname = "Name46",
            Lastname = "LastName46",
            Address = "HCM",
            Status = true,
        });

        modelBuilder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>
        {
            RoleId = AdminRoleId,
            UserId = 46
        });
        #endregion

        #region Category
        for (int i = 1; i <= 10; i++)
        {
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = i,
                Name = "Category" + i.ToString(),
                IsActive = true
            });
        }
        #endregion

        #region Course
        for (int i = 1; i <= 10; i++)
        {
            modelBuilder.Entity<Course>().HasData(new Course
            {
                Id = i,
                Name = "Course" + i.ToString(),
                Description = "Yoga course number " + i.ToString(),
                Price = i * 100,
                StartDate = DateTime.Now,
                EnddDate = DateTime.MaxValue,
                IsActive = true,
                CategoryId = i
            });
        }
        #endregion

        #region Class
        for (int i = 1; i <= 10; i++)
        {
            modelBuilder.Entity<YogaClass>().HasData(new YogaClass
            {
                Id = i,
                Name = "Class" + i.ToString(),
                Size = 20 - i,
                Status = true,
                CourseId = i
            });
        }
        #endregion
    }
}
