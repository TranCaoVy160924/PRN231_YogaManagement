using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace YogaCenterLibrary.Models;

public partial class YogaCenterContext : DbContext
{
    public YogaCenterContext()
    {
    }

    public YogaCenterContext(DbContextOptions<YogaCenterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Blog> Blogs { get; set; }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<ClassDetail> ClassDetails { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Level> Levels { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Setting> Settings { get; set; }

    public virtual DbSet<Slot> Slots { get; set; }

    public virtual DbSet<TimeFrame> TimeFrames { get; set; }

    public virtual DbSet<Timetable> Timetables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfiguration config = new ConfigurationBuilder()
                          .SetBasePath(Directory.GetCurrentDirectory())
                          .AddJsonFile("appsettings.json", true, true)
                          .Build();
        string cs = config["ConnectionStrings:DB"];
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(cs);
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Account__3213E83F30DB66AF");

            entity.ToTable("Account");

            entity.HasIndex(e => e.PhoneNumber, "UQ__Account__85FB4E38D115776D").IsUnique();

            entity.HasIndex(e => e.PhoneNumber, "UQ__Account__85FB4E38EC904EA3").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Account__A9D105345B6DD801").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Account__A9D1053499507F75").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Deleted).HasDefaultValueSql("((0))");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Firstname).HasMaxLength(20);
            entity.Property(e => e.Img).HasColumnType("text");
            entity.Property(e => e.Lastname).HasMaxLength(20);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ValidationCode)
                .HasMaxLength(5)
                .IsUnicode(false);

            entity.HasOne(d => d.Role).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Account__RoleId__571DF1D5");
        });

        modelBuilder.Entity<Blog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Blog__3213E83F1BE3783E");

            entity.ToTable("Blog");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Content).HasColumnType("text");
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.Header).HasMaxLength(255);
            entity.Property(e => e.Img)
                .HasColumnType("text")
                .HasColumnName("img");

            entity.HasOne(d => d.User).WithMany(p => p.Blogs)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Blog__UserId__5812160E");
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Booking__3213E83F95B6C4F1");

            entity.ToTable("Booking");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.BookingDate).HasColumnType("datetime");
            entity.Property(e => e.PayDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentTransactionId)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.RefundDate).HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("((0))")
                .HasColumnName("status");

            entity.HasOne(d => d.Account).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__Booking__Account__59063A47");

            entity.HasOne(d => d.Class).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK__Booking__ClassId__5AEE82B9");

            entity.HasOne(d => d.Course).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__Booking__CourseI__59FA5E80");
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Class__3213E83F91CDE9AB");

            entity.ToTable("Class");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClassName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.EndDate).HasColumnType("date");
            entity.Property(e => e.Finished).HasDefaultValueSql("((0))");
            entity.Property(e => e.Room)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.StartDate).HasColumnType("date");

            entity.HasOne(d => d.Course).WithMany(p => p.Classes)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__Class__CourseId__5BE2A6F2");

            entity.HasOne(d => d.Trainer).WithMany(p => p.Classes)
                .HasForeignKey(d => d.TrainerId)
                .HasConstraintName("FK__Class__TrainerId__5CD6CB2B");
        });

        modelBuilder.Entity<ClassDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ClassDet__3213E83F06862464");

            entity.ToTable("ClassDetail");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.HasOne(d => d.Class).WithMany(p => p.ClassDetails)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK__ClassDeta__Class__5DCAEF64");

            entity.HasOne(d => d.Trainee).WithMany(p => p.ClassDetails)
                .HasForeignKey(d => d.TraineeId)
                .HasConstraintName("FK__ClassDeta__Train__5EBF139D");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Course__3213E83F4A29BC38");

            entity.ToTable("Course");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CourseName).HasMaxLength(50);
            entity.Property(e => e.Deleted).HasDefaultValueSql("((0))");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Img).HasColumnType("text");

            entity.HasOne(d => d.Level).WithMany(p => p.Courses)
                .HasForeignKey(d => d.LevelId)
                .HasConstraintName("FK__Course__LevelId__5FB337D6");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Feedback__3213E83FCE751E65");

            entity.ToTable("Feedback");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Status).HasDefaultValueSql("((0))");

            entity.HasOne(d => d.Course).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__Feedback__Course__60A75C0F");

            entity.HasOne(d => d.Trainee).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.TraineeId)
                .HasConstraintName("FK__Feedback__Traine__619B8048");
        });

        modelBuilder.Entity<Level>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Level__3213E83FB8ED4D0E");

            entity.ToTable("Level");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.LevelName).HasMaxLength(20);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Role__3213E83F33F20830");

            entity.ToTable("Role");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Setting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Setting__3213E83F89690878");

            entity.ToTable("Setting");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ActiveDate).HasColumnType("datetime");
            entity.Property(e => e.SettingName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Slot>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Slot__3213E83F29AC7050");

            entity.ToTable("Slot");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DayOfWeek).HasMaxLength(255);

            entity.HasOne(d => d.TimeFrame).WithMany(p => p.Slots)
                .HasForeignKey(d => d.TimeFrameId)
                .HasConstraintName("FK__Slot__TimeFrameI__628FA481");

            entity.HasOne(d => d.Timetable).WithMany(p => p.Slots)
                .HasForeignKey(d => d.TimetableId)
                .HasConstraintName("FK__Slot__TimetableI__6383C8BA");
        });

        modelBuilder.Entity<TimeFrame>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TimeFram__3213E83F973B2520");

            entity.ToTable("TimeFrame");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.TimeFrame1)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("timeFrame");
        });

        modelBuilder.Entity<Timetable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Timetabl__3213E83F2DE843EE");

            entity.ToTable("Timetable");

            entity.HasIndex(e => e.ClassId, "UQ__Timetabl__CB1927C10061321A").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");

            entity.HasOne(d => d.Class).WithOne(p => p.Timetable)
                .HasForeignKey<Timetable>(d => d.ClassId)
                .HasConstraintName("FK__Timetable__Class__6477ECF3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
