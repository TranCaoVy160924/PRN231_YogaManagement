using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
}
