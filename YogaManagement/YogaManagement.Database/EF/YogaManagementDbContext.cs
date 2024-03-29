﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using YogaManagement.Data.Extensions;
using YogaManagement.Domain.Models;

namespace YogaManagement.Database.EF;
public class YogaManagementDbContext : IdentityDbContext<AppUser, AppRole, int>
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

        IConfigurationRoot configuration = builder.Build();

        optionsBuilder.UseSqlServer(configuration.GetConnectionString("YogaManagement"),
            b => b.MigrationsAssembly("YogaManagement.Database"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Enrollment>()
            .HasKey(sc => new { sc.MemberId, sc.YogaClassId });
        modelBuilder.Entity<Schedule>()
            .HasKey(sc => new { sc.TimeSlotId, sc.YogaClassId });
        modelBuilder.Entity<TeacherSchedule>()
            .HasKey(sc => new { sc.TimeSlotId, sc.TeacherProfileId });
        modelBuilder.Seed();
    }

    public DbSet<AppRole> AppRoles { get; set; }
    public DbSet<AppUser> AppUsers { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<TeacherProfile> TeacherProfiles { get; set; }
    public DbSet<TimeSlot> TimeSlots { get; set; }
    public DbSet<Wallet> Wallets { get; set; }
    public DbSet<YogaClass> YogaClasses { get; set; }
    public DbSet<TeacherEnrollment> TeacherEnrollments { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Schedule> Schedule { get; set; }
    public DbSet<TeacherSchedule> TeacherSchedule { get; set; }
}
