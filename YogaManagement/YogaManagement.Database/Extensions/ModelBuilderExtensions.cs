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
                YogaClassStatus = i % 2 == 0 ? YogaClassStatus.Pending : YogaClassStatus.Active,
                CourseId = i
            });
        }
        #endregion

        #region Time slot

        var day = DayOfWeek.Monday;

        DateTime inputTime(string time)
        {
            string timeInput = time;
            DateTime defaultDate = DateTime.MinValue; // or any other desired default date

            string combinedDateTimeInput = defaultDate.ToString("yyyy-MM-dd") + " " + timeInput;
            DateTime dateTime = DateTime.ParseExact(combinedDateTimeInput, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            return dateTime;
        }

        for (int i = 1; i <= 7; i++)
        {
            switch (i)
            {
                case 2: { day = DayOfWeek.Tuesday; }; break;
                case 3: { day = DayOfWeek.Wednesday; }; break;
                case 4: { day = DayOfWeek.Thursday; }; break;
                case 5: { day = DayOfWeek.Friday; }; break;
                case 6: { day = DayOfWeek.Saturday; }; break;
                case 7: { day = DayOfWeek.Sunday; }; break;
            }

            modelBuilder.Entity<TimeSlot>().HasData(new TimeSlot
            {
                Id = i * 10 + 1,
                DayOfWeek = day,
                StartTime = inputTime("06:00:00"),
                EndTime = inputTime("07:00:00"),
                Room = 101,
                Status = true
            });

            modelBuilder.Entity<TimeSlot>().HasData(new TimeSlot
            {
                Id = i * 10 + 2,
                DayOfWeek = day,
                StartTime = inputTime("07:30:00"),
                EndTime = inputTime("08:30:00"),
                Room = 202,
                Status = true
            });

            modelBuilder.Entity<TimeSlot>().HasData(new TimeSlot
            {
                Id = i * 10 + 3,
                DayOfWeek = day,
                StartTime = inputTime("09:00:00"),
                EndTime = inputTime("10:00:00"),
                Room = 303,
                Status = true
            });

            modelBuilder.Entity<TimeSlot>().HasData(new TimeSlot
            {
                Id = i * 10 + 4,
                DayOfWeek = day,
                StartTime = inputTime("15:30:00"),
                EndTime = inputTime("16:30:00"),
                Room = 404,
                Status = true
            });

            modelBuilder.Entity<TimeSlot>().HasData(new TimeSlot
            {
                Id = i * 10 + 5,
                DayOfWeek = day,
                StartTime = inputTime("17:00:00"),
                EndTime = inputTime("18:00:00"),
                Room = 505,
                Status = true
            });

            modelBuilder.Entity<TimeSlot>().HasData(new TimeSlot
            {
                Id = i * 10 + 6,
                DayOfWeek = day,
                StartTime = inputTime("18:30:00"),
                EndTime = inputTime("19:30:00"),
                Room = 606,
                Status = true
            });

            modelBuilder.Entity<TimeSlot>().HasData(new TimeSlot
            {
                Id = i * 10 + 7,
                DayOfWeek = day,
                StartTime = inputTime("20:00:00"),
                EndTime = inputTime("21:00:00"),
                Room = 707,
                Status = true
            });
        }
        #endregion

        #region Schedule
        var timeSlotId = 0;
        for (int i = 1; i <= 10; i++)
        {
            if (i < 8 && i % 2 == 0)
            {
                timeSlotId = 10 + i;
            }
            else if (i < 8 && i % 2 != 0)
            {
                timeSlotId = 20 + i;
            }
            else
            {
                timeSlotId = 60 + 10-i + 1;
            }

            modelBuilder.Entity<Schedule>().HasData(new Schedule
            {
                YogaClassId = i,
                TimeSlotId = timeSlotId,
            });

            if (i < 8 && i % 2 == 0)
            {
                timeSlotId = 30 + i;
            }
            else if (i < 8 && i % 2 != 0)
            {
                timeSlotId = 40 + i;
            }
            else
            {
                timeSlotId = 70 + 10 - i + 1;
            }

            modelBuilder.Entity<Schedule>().HasData(new Schedule
            {
                YogaClassId = i,
                TimeSlotId = timeSlotId,
            });
            
            if(i < 8)
            {
                if (i % 2 == 0)
                {
                    timeSlotId = 50 + i;
                }
                else if (i % 2 != 0)
                {
                    timeSlotId = 60 + i;
                }

                modelBuilder.Entity<Schedule>().HasData(new Schedule
                {
                    YogaClassId = i,
                    TimeSlotId = timeSlotId,
                });
            }
        }
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
