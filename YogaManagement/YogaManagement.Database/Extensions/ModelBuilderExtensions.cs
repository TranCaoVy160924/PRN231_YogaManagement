using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using System.Globalization;
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
                UserName = "member" + i.ToString() + "@gmail.com",
                NormalizedUserName = "member" + i.ToString() + "@gmail.com",
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
                UserName = "teacher" + i.ToString() + "@gmail.com",
                NormalizedUserName = "teacher" + i.ToString() + "@gmail.com",
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
                UserName = "staff" + i.ToString() + "@gmail.com",
                NormalizedUserName = "staff" + i.ToString() + "@gmail.com",
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
            UserName = "admin46" + "@gmail.com",
            NormalizedUserName = "admin46" + "@gmail.com",
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
                StartDate = DateTime.Now.AddDays(7),
                EnddDate = DateTime.Now.AddDays(7).AddMonths(1),
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
                YogaClassStatus = i % 2 == 0 ? YogaClassStatus.Pending : YogaClassStatus.Active,
                CourseId = i
            });
        }
        #endregion

        #region Time slot

        var StartTime = inputTime("06:30:00");
        var EndTime = inputTime("08:00:00");

        DateTime inputTime(string time)
        {
            string timeInput = time;
            DateTime defaultDate = DateTime.MinValue; // or any other desired default date

            string combinedDateTimeInput = defaultDate.ToString("yyyy-MM-dd") + " " + timeInput;
            DateTime dateTime = DateTime.ParseExact(combinedDateTimeInput, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            return dateTime;
        }

        for (int i = 1; i <= 3; i++)
        {
            switch (i)
            {
                case 2: { StartTime = inputTime("09:00:00"); EndTime = inputTime("10:30:00"); }; break;
                case 3: { StartTime = inputTime("15:00:00"); EndTime = inputTime("16:30:00"); }; break;
            }

            modelBuilder.Entity<TimeSlot>().HasData(new TimeSlot
            {
                Id = i * 10 + 1,
                DayOfWeek = DayOfWeek.Monday,
                StartTime = StartTime,
                EndTime = EndTime,
                Status = true
            });

            modelBuilder.Entity<TimeSlot>().HasData(new TimeSlot
            {
                Id = i * 10 + 2,
                DayOfWeek = DayOfWeek.Tuesday,
                StartTime = StartTime,
                EndTime = EndTime,
                Status = true
            });

            modelBuilder.Entity<TimeSlot>().HasData(new TimeSlot
            {
                Id = i * 10 + 3,
                DayOfWeek = DayOfWeek.Wednesday,
                StartTime = StartTime,
                EndTime = EndTime,
                Status = true
            });

            modelBuilder.Entity<TimeSlot>().HasData(new TimeSlot
            {
                Id = i * 10 + 4,
                DayOfWeek = DayOfWeek.Thursday,
                StartTime = StartTime,
                EndTime = EndTime,
                Status = true
            });

            modelBuilder.Entity<TimeSlot>().HasData(new TimeSlot
            {
                Id = i * 10 + 5,
                DayOfWeek = DayOfWeek.Friday,
                StartTime = StartTime,
                EndTime = EndTime,
                Status = true
            });

            modelBuilder.Entity<TimeSlot>().HasData(new TimeSlot
            {
                Id = i * 10 + 6,
                DayOfWeek = DayOfWeek.Saturday,
                StartTime = StartTime,
                EndTime = EndTime,
                Status = true
            });

            modelBuilder.Entity<TimeSlot>().HasData(new TimeSlot
            {
                Id = i * 10 + 7,
                DayOfWeek = DayOfWeek.Sunday,
                StartTime = StartTime,
                EndTime = EndTime,
                Status = true
            });
        }
        #endregion

        #region Schedule
        //1
        modelBuilder.Entity<Schedule>().HasData(new Schedule
        {
            YogaClassId = 1,
            TimeSlotId = 11,
        });
        modelBuilder.Entity<Schedule>().HasData(new Schedule
        {
            YogaClassId = 1,
            TimeSlotId = 13,
        });
        modelBuilder.Entity<Schedule>().HasData(new Schedule
        {
            YogaClassId = 1,
            TimeSlotId = 15,
        });
        modelBuilder.Entity<Schedule>().HasData(new Schedule
        {
            YogaClassId = 2,
            TimeSlotId = 12,
        });
        modelBuilder.Entity<Schedule>().HasData(new Schedule
        {
            YogaClassId = 2,
            TimeSlotId = 14,
        });
        modelBuilder.Entity<Schedule>().HasData(new Schedule
        {
            YogaClassId = 3,
            TimeSlotId = 21,
        });
        modelBuilder.Entity<Schedule>().HasData(new Schedule
        {
            YogaClassId = 3,
            TimeSlotId = 23,
        });
        modelBuilder.Entity<Schedule>().HasData(new Schedule
        {
            YogaClassId = 3,
            TimeSlotId = 25,
        });
        modelBuilder.Entity<Schedule>().HasData(new Schedule
        {
            YogaClassId = 4,
            TimeSlotId = 22,
        });
        modelBuilder.Entity<Schedule>().HasData(new Schedule
        {
            YogaClassId = 4,
            TimeSlotId = 24,
        });
        modelBuilder.Entity<Schedule>().HasData(new Schedule
        {
            YogaClassId = 5,
            TimeSlotId = 31,
        });
        modelBuilder.Entity<Schedule>().HasData(new Schedule
        {
            YogaClassId = 5,
            TimeSlotId = 33,
        });
        modelBuilder.Entity<Schedule>().HasData(new Schedule
        {
            YogaClassId = 5,
            TimeSlotId = 35,
        });
        modelBuilder.Entity<Schedule>().HasData(new Schedule
        {
            YogaClassId = 6,
            TimeSlotId = 32,
        });
        modelBuilder.Entity<Schedule>().HasData(new Schedule
        {
            YogaClassId = 6,
            TimeSlotId = 34,
        });
        modelBuilder.Entity<Schedule>().HasData(new Schedule
        {
            YogaClassId = 7,
            TimeSlotId = 16,
        });
        modelBuilder.Entity<Schedule>().HasData(new Schedule
        {
            YogaClassId = 7,
            TimeSlotId = 17,
        });
        modelBuilder.Entity<Schedule>().HasData(new Schedule
        {
            YogaClassId = 8,
            TimeSlotId = 26,
        });
        modelBuilder.Entity<Schedule>().HasData(new Schedule
        {
            YogaClassId = 8,
            TimeSlotId = 27,
        });
        modelBuilder.Entity<Schedule>().HasData(new Schedule
        {
            YogaClassId = 9,
            TimeSlotId = 36,
        });
        modelBuilder.Entity<Schedule>().HasData(new Schedule
        {
            YogaClassId = 10,
            TimeSlotId = 37,
        });
        #endregion

        #region Wallet
        for (int i = 1; i <= 46; i++)
        {
            modelBuilder.Entity<Wallet>().HasData(new Wallet
            {
                Id = i,
                Balance = 0,
                IsAdminWallet = i == 46 ? true : false,
                AppUserId = i
            });
        }
        #endregion
    }
}
