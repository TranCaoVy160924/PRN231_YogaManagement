using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using YogaManagement.Domain.Models;
using System;

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

        Random random = new Random();

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

        modelBuilder.Entity<AppUser>().HasData(new AppUser
        {
            Id = 1,
            UserName = "1",
            NormalizedUserName = "1",
            Email = "adminhcm@gmail.com",
            NormalizedEmail = "adminhcm@gmail.com",
            EmailConfirmed = true,
            PasswordHash = hasher.HashPassword(null, "12345678"),
            SecurityStamp = string.Empty,
            Firstname = "Toan",
            Lastname = "Bach",
            Address = "HCM"
        });

        modelBuilder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>
        {
            RoleId = memberRoleId,
            UserId = 1
        });
    }
}
