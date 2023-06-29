using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YogaManagement.Database.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimeSlots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSlots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberLevel = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Members_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherProfiles_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wallets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Balance = table.Column<double>(type: "float", nullable: false),
                    IsAdminWallet = table.Column<bool>(type: "bit", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wallets_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EnddDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherProfileTimeSlot",
                columns: table => new
                {
                    AvailableSlotId = table.Column<int>(type: "int", nullable: false),
                    AvailableTeacherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherProfileTimeSlot", x => new { x.AvailableSlotId, x.AvailableTeacherId });
                    table.ForeignKey(
                        name: "FK_TeacherProfileTimeSlot_TeacherProfiles_AvailableTeacherId",
                        column: x => x.AvailableTeacherId,
                        principalTable: "TeacherProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherProfileTimeSlot_TimeSlots_AvailableSlotId",
                        column: x => x.AvailableSlotId,
                        principalTable: "TimeSlots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherSchedule",
                columns: table => new
                {
                    TimeSlotId = table.Column<int>(type: "int", nullable: false),
                    TeacherProfileId = table.Column<int>(type: "int", nullable: false),
                    IsTaken = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherSchedule", x => new { x.TimeSlotId, x.TeacherProfileId });
                    table.ForeignKey(
                        name: "FK_TeacherSchedule_TeacherProfiles_TeacherProfileId",
                        column: x => x.TeacherProfileId,
                        principalTable: "TeacherProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherSchedule_TimeSlots_TimeSlotId",
                        column: x => x.TimeSlotId,
                        principalTable: "TimeSlots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionType = table.Column<int>(type: "int", nullable: false),
                    WalletId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Wallets_WalletId",
                        column: x => x.WalletId,
                        principalTable: "Wallets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "YogaClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    YogaClassStatus = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YogaClasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_YogaClasses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    YogaClassId = table.Column<int>(type: "int", nullable: false),
                    EnrollDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => new { x.MemberId, x.YogaClassId });
                    table.ForeignKey(
                        name: "FK_Enrollments_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_YogaClasses_YogaClassId",
                        column: x => x.YogaClassId,
                        principalTable: "YogaClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    TimeSlotId = table.Column<int>(type: "int", nullable: false),
                    YogaClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => new { x.TimeSlotId, x.YogaClassId });
                    table.ForeignKey(
                        name: "FK_Schedule_TimeSlots_TimeSlotId",
                        column: x => x.TimeSlotId,
                        principalTable: "TimeSlots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Schedule_YogaClasses_YogaClassId",
                        column: x => x.YogaClassId,
                        principalTable: "YogaClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherEnrollments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TeacherProfileId = table.Column<int>(type: "int", nullable: false),
                    YogaClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherEnrollments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherEnrollments_TeacherProfiles_TeacherProfileId",
                        column: x => x.TeacherProfileId,
                        principalTable: "TeacherProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherEnrollments_YogaClasses_YogaClassId",
                        column: x => x.YogaClassId,
                        principalTable: "YogaClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, null, "MEMBER", "Member", "member" },
                    { 2, null, "TEACHER", "Teacher", "teacher" },
                    { 3, null, "STAFF", "Staff", "staff" },
                    { 4, null, "ADMIN", "Admin", "admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "Firstname", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "HCM", "a5a76ad6-c4a4-4697-8ad4-08fb54c6facc", "member1@gmail.com", true, "Name1", "LastName1", false, null, "member1@gmail.com", "member1@gmail.com", "AQAAAAIAAYagAAAAEJMj+jj3BoLG1C2bBCVzlVrG5NzpcDjheXk4BTOOdDQMEksaeSUs+T+RKmwEyF4cJQ==", null, false, "", true, false, "member1@gmail.com" },
                    { 2, 0, "HCM", "fa6cbbea-91ce-439d-ad7b-80e72c0a59ef", "member2@gmail.com", true, "Name2", "LastName2", false, null, "member2@gmail.com", "member2@gmail.com", "AQAAAAIAAYagAAAAEANngFQ5JTVdMv7jHAUvkwKlmRAwUivJmXS6/q3GTMGg3q7s9ZcANnYTe+QSmPEgeA==", null, false, "", true, false, "member2@gmail.com" },
                    { 3, 0, "HCM", "96cfd296-1f56-45a0-8c21-deeaf4db1d6e", "member3@gmail.com", true, "Name3", "LastName3", false, null, "member3@gmail.com", "member3@gmail.com", "AQAAAAIAAYagAAAAEKorHL0X84PZrSOs65uJ/8KQ2IFP82rixrozvb1QzlJ+i4HdVr8ozRKBLM82SaGxng==", null, false, "", true, false, "member3@gmail.com" },
                    { 4, 0, "HCM", "5821193c-a326-469d-8289-2ae44b4e1b8a", "member4@gmail.com", true, "Name4", "LastName4", false, null, "member4@gmail.com", "member4@gmail.com", "AQAAAAIAAYagAAAAEGzXXA9dS8CsG/B2F5owpOFOHdHxW8TpxRGhWN6YIqzQId8BqFnNoD8IYMqShq0jAA==", null, false, "", true, false, "member4@gmail.com" },
                    { 5, 0, "HCM", "d7697ed6-ef94-4cad-8c0e-7c1d33a07b5f", "member5@gmail.com", true, "Name5", "LastName5", false, null, "member5@gmail.com", "member5@gmail.com", "AQAAAAIAAYagAAAAEDJZAN74adweyG5VsEZK+hg4hmFfB+Jhj/NWksn/52ZwPDYiRDFk7lkVLt2zEO1USQ==", null, false, "", true, false, "member5@gmail.com" },
                    { 6, 0, "HCM", "d471050b-8c92-4782-ab08-85fcdb2514ec", "member6@gmail.com", true, "Name6", "LastName6", false, null, "member6@gmail.com", "member6@gmail.com", "AQAAAAIAAYagAAAAEDybM6Bj8OewoRWIFLJQ+9Aya3Vo4+Exxzg3MBiSqkDCWTODpc3j2eah3LH2aH7gAw==", null, false, "", true, false, "member6@gmail.com" },
                    { 7, 0, "HCM", "0a662518-e1c2-4e3e-9de8-e9fe0e789812", "member7@gmail.com", true, "Name7", "LastName7", false, null, "member7@gmail.com", "member7@gmail.com", "AQAAAAIAAYagAAAAEB7/VjAby/tvPiIwOYnb+ThAkKk+3OSSdeBn5uY0PJ6qWwMTj86mhj9eAQBcwzerxA==", null, false, "", true, false, "member7@gmail.com" },
                    { 8, 0, "HCM", "6ed6dc2a-fdcb-43b3-9410-ebbb84a1c89d", "member8@gmail.com", true, "Name8", "LastName8", false, null, "member8@gmail.com", "member8@gmail.com", "AQAAAAIAAYagAAAAEKN87RF1HR7/mfMvSc2ntjQW12dN44Wx/nMAH5Xv6xu9xgK39tdI8Czzfr013KDiGw==", null, false, "", true, false, "member8@gmail.com" },
                    { 9, 0, "HCM", "1777b4a2-1041-4930-b5e8-086d8c0d2a5e", "member9@gmail.com", true, "Name9", "LastName9", false, null, "member9@gmail.com", "member9@gmail.com", "AQAAAAIAAYagAAAAEBmtmETC8RSZ/4g9xujklqVeBZL72aEWejj+asDBEwxwbEM6y0DWs75a763S4zsfYQ==", null, false, "", true, false, "member9@gmail.com" },
                    { 10, 0, "HCM", "e8bb8a9a-d901-469d-bd98-2ffd95afe509", "member10@gmail.com", true, "Name10", "LastName10", false, null, "member10@gmail.com", "member10@gmail.com", "AQAAAAIAAYagAAAAEHU1WPI+fBP1kwThXpsqjStul96iLNfC8iFHd+vfPRm9sZad/uVTFNomL56SXZOFwg==", null, false, "", true, false, "member10@gmail.com" },
                    { 11, 0, "HCM", "73548848-4f95-4b40-b3d4-ac407c41abba", "member11@gmail.com", true, "Name11", "LastName11", false, null, "member11@gmail.com", "member11@gmail.com", "AQAAAAIAAYagAAAAEOkaSrZI1+BJ2cARO5zUBDFNvZSe8HIWfsjDUU3ImS14qeju8DhjRNFnH/45Tjlvyg==", null, false, "", true, false, "member11@gmail.com" },
                    { 12, 0, "HCM", "8500a2b7-9443-4aec-9939-8113ac2391a1", "member12@gmail.com", true, "Name12", "LastName12", false, null, "member12@gmail.com", "member12@gmail.com", "AQAAAAIAAYagAAAAEIt+soYz/riiDhYxl8XEUYxrQlu5NQpvimqnCfo1IjLZ9vgXJNBuke1gM7lg7NVNng==", null, false, "", true, false, "member12@gmail.com" },
                    { 13, 0, "HCM", "0c7a7fc8-e5a2-48e7-b381-b14a79a92b69", "member13@gmail.com", true, "Name13", "LastName13", false, null, "member13@gmail.com", "member13@gmail.com", "AQAAAAIAAYagAAAAEONRmWSH0b2SbnMl2SMY9EioD836kSC+NGqBgqGue5PFRma2NiKAxZCR77eTtTBmRQ==", null, false, "", true, false, "member13@gmail.com" },
                    { 14, 0, "HCM", "18eb17b9-cf2f-4af5-9518-02a4e94f73e8", "member14@gmail.com", true, "Name14", "LastName14", false, null, "member14@gmail.com", "member14@gmail.com", "AQAAAAIAAYagAAAAEFZueWlLVgvzRX19EFYjqPN2YeafBo2aG+CEZFrPWTTtkNiV2sGgTcVLUh9XmVHpRA==", null, false, "", true, false, "member14@gmail.com" },
                    { 15, 0, "HCM", "d67a8ca2-a4fb-4775-9d5d-e8532681463c", "member15@gmail.com", true, "Name15", "LastName15", false, null, "member15@gmail.com", "member15@gmail.com", "AQAAAAIAAYagAAAAECygqY7DyEVlAFHcBOZQg0tArTokgitjSDZfw789ob1xdqKufeOYG3i8KkwXKUw8kA==", null, false, "", true, false, "member15@gmail.com" },
                    { 16, 0, "HCM", "ee995934-6046-4219-b3a7-9da2c23693db", "member16@gmail.com", true, "Name16", "LastName16", false, null, "member16@gmail.com", "member16@gmail.com", "AQAAAAIAAYagAAAAEDWLRtlFWo1S/lcjmGRZO5QST6betE+5QiHF1SzUvJ59+7sspSDGReJVlQbCqYOkRw==", null, false, "", true, false, "member16@gmail.com" },
                    { 17, 0, "HCM", "36c19868-d639-4d87-a145-b5d4476023a7", "member17@gmail.com", true, "Name17", "LastName17", false, null, "member17@gmail.com", "member17@gmail.com", "AQAAAAIAAYagAAAAEE5vj0udMIFZ4K4EhA8v9kOpiDIEZmN0aqLXeRWh2xMCNrzl3Dmkb2PLVMjzYm9gTA==", null, false, "", true, false, "member17@gmail.com" },
                    { 18, 0, "HCM", "a4f30e34-828b-4327-84c8-ca88709928a7", "member18@gmail.com", true, "Name18", "LastName18", false, null, "member18@gmail.com", "member18@gmail.com", "AQAAAAIAAYagAAAAEBnA2KJDmYMlrGo73give/72TVQrjbOfD8kGor9TKx+Dz+QCaLrTTnqKdM/wcjSvNQ==", null, false, "", true, false, "member18@gmail.com" },
                    { 19, 0, "HCM", "11f19db8-d4b5-43c9-af4d-e7e5107c1c0d", "member19@gmail.com", true, "Name19", "LastName19", false, null, "member19@gmail.com", "member19@gmail.com", "AQAAAAIAAYagAAAAELTKo1dDJWMB1+FBpxhJBXNViQMRuwmfxU50CgXOR2epL4tyWQtGN7IAjdATrCy6mg==", null, false, "", true, false, "member19@gmail.com" },
                    { 20, 0, "HCM", "3bb2130b-1bc6-4cc1-91c5-3f7bfc483b2d", "member20@gmail.com", true, "Name20", "LastName20", false, null, "member20@gmail.com", "member20@gmail.com", "AQAAAAIAAYagAAAAEBDv8Y0x+lHjGnCpp60vXRd7AXbfKESFsWESIAZOg1vhsYUGiuRo7ZYMeMJ1VjaqMg==", null, false, "", true, false, "member20@gmail.com" },
                    { 21, 0, "HCM", "b5f3be7c-103b-4907-b17e-eb28761fe88a", "member21@gmail.com", true, "Name21", "LastName21", false, null, "member21@gmail.com", "member21@gmail.com", "AQAAAAIAAYagAAAAECBvzJE0OTGHRUkztN4y7HoTGj6sKryP7qclM6AfWfRGETRogbGZ9xp9+1N1mPh8lg==", null, false, "", true, false, "member21@gmail.com" },
                    { 22, 0, "HCM", "557395d6-5463-48f5-821a-1f27291adc8f", "member22@gmail.com", true, "Name22", "LastName22", false, null, "member22@gmail.com", "member22@gmail.com", "AQAAAAIAAYagAAAAEEfjWBn5arRTST0/4Ga3aDfEo7hgeGoIMqMrcGm/2DBdaYmWpgc5ukDs2knB/U8xXQ==", null, false, "", true, false, "member22@gmail.com" },
                    { 23, 0, "HCM", "f3c4b940-2701-440f-a037-bf97781fb591", "member23@gmail.com", true, "Name23", "LastName23", false, null, "member23@gmail.com", "member23@gmail.com", "AQAAAAIAAYagAAAAEFx8VN+y057kmQPtxiB53bltTfR6ywfjkFU80UFgHPFizZipPy6j9z8KPPDBYwHZZQ==", null, false, "", true, false, "member23@gmail.com" },
                    { 24, 0, "HCM", "588b7d16-823f-43c3-a9bd-375d18202d46", "member24@gmail.com", true, "Name24", "LastName24", false, null, "member24@gmail.com", "member24@gmail.com", "AQAAAAIAAYagAAAAEL51YHyVPaj8g1WQ5npxJoWIIx3pjoMFvxmdHKEvZ04HuAyfInFCwc3CYBGqog9iIA==", null, false, "", true, false, "member24@gmail.com" },
                    { 25, 0, "HCM", "655b0615-940a-47de-bd10-5bc711b820ba", "member25@gmail.com", true, "Name25", "LastName25", false, null, "member25@gmail.com", "member25@gmail.com", "AQAAAAIAAYagAAAAEMxcjjqLAH1gHDlxcctbdxKoIyCKlEtlO2gE6v2AU4J9pIKY6oQ5O0tpuCksC4a0vA==", null, false, "", true, false, "member25@gmail.com" },
                    { 26, 0, "HCM", "77084158-2157-42ad-9b5b-624fadf14d26", "member26@gmail.com", true, "Name26", "LastName26", false, null, "member26@gmail.com", "member26@gmail.com", "AQAAAAIAAYagAAAAEIrN9MpIuMYq/3gRS4YIg04mwX0LplchZWcdYyYT7wf5PrUBfDHkuC0BJJw6bQV7vw==", null, false, "", true, false, "member26@gmail.com" },
                    { 27, 0, "HCM", "67d9064d-2abc-4a78-a884-7ebc396ea570", "member27@gmail.com", true, "Name27", "LastName27", false, null, "member27@gmail.com", "member27@gmail.com", "AQAAAAIAAYagAAAAEE169XTjX0iXH6qC+XplezoZznoxUkyqFdTKagVH6zlXNasv1ysnmELyUB9EeLrBmA==", null, false, "", true, false, "member27@gmail.com" },
                    { 28, 0, "HCM", "e1c4be41-a8f5-4a98-92fa-7af6bc9be2ba", "member28@gmail.com", true, "Name28", "LastName28", false, null, "member28@gmail.com", "member28@gmail.com", "AQAAAAIAAYagAAAAEIonJjuPF9Wn2qT+PgVEKscCu27kh9MjuRt8cXIagRk/33FznmJgZDA5gGsk2iZKuw==", null, false, "", true, false, "member28@gmail.com" },
                    { 29, 0, "HCM", "221a04cc-6f06-4d32-b9a7-dc2658505b6b", "member29@gmail.com", true, "Name29", "LastName29", false, null, "member29@gmail.com", "member29@gmail.com", "AQAAAAIAAYagAAAAENl3ViZK69aKugfmmuwIWXsxEiKtx6lw8x9AeWA6aDst8bUsKsc+BwLSFJYmw+93Gg==", null, false, "", true, false, "member29@gmail.com" },
                    { 30, 0, "HCM", "f6e63ed3-b515-4cbc-bde6-5df8c0f2d546", "member30@gmail.com", true, "Name30", "LastName30", false, null, "member30@gmail.com", "member30@gmail.com", "AQAAAAIAAYagAAAAELcKAkdajDhG1dnpPZ2TXqzgcoFrXPtaNQG7uRlO/2Kngpo4i+oXpv9QaxgKd9ngxA==", null, false, "", true, false, "member30@gmail.com" },
                    { 31, 0, "HCM", "35a3280d-0fc8-49f0-933a-bed4ccf8aa5f", "teacher31@gmail.com", true, "Name31", "LastName31", false, null, "teacher31@gmail.com", "teacher31@gmail.com", "AQAAAAIAAYagAAAAECqcWbCWF4TNFr/W3qWhUkXSaG38YeQncxD/60HiwE5VJJ0J3lWYiuMy6lVnpv5FBQ==", null, false, "", true, false, "teacher31@gmail.com" },
                    { 32, 0, "HCM", "00e4c226-35f6-4305-905e-6b7bb89020fa", "teacher32@gmail.com", true, "Name32", "LastName32", false, null, "teacher32@gmail.com", "teacher32@gmail.com", "AQAAAAIAAYagAAAAEOe4NxzC84SLI28LrxSVK01OtZ2Dni++/qnnjQEzaQdLHTaD4auiKrMY4r2X4Wn3tw==", null, false, "", true, false, "teacher32@gmail.com" },
                    { 33, 0, "HCM", "bc83c7be-135d-4ba8-8b45-ce1966d7d8d4", "teacher33@gmail.com", true, "Name33", "LastName33", false, null, "teacher33@gmail.com", "teacher33@gmail.com", "AQAAAAIAAYagAAAAEEbS2LviQ98sHeiVSewBP2fKdaj4VbYuGP0G4aBW6WPUZQNdLAk0J2rzaPfbfFWaig==", null, false, "", true, false, "teacher33@gmail.com" },
                    { 34, 0, "HCM", "6979ced1-da66-435a-ac75-07e059bc9ab2", "teacher34@gmail.com", true, "Name34", "LastName34", false, null, "teacher34@gmail.com", "teacher34@gmail.com", "AQAAAAIAAYagAAAAEDuaHH/FU3Rug75Nub4ojERdhgoL4cq9us+nCijxvC+bBVdMA5PjupXbl0JzvpF9HQ==", null, false, "", true, false, "teacher34@gmail.com" },
                    { 35, 0, "HCM", "322391fc-918e-4f66-876d-b9db55bc4ac6", "teacher35@gmail.com", true, "Name35", "LastName35", false, null, "teacher35@gmail.com", "teacher35@gmail.com", "AQAAAAIAAYagAAAAEKQkVPe/OUNhRVXjTjbrpTJoXvSMUjSZZJGqQH3BjgSnFFfTIz9EZDB6tydDk5ZhtQ==", null, false, "", true, false, "teacher35@gmail.com" },
                    { 36, 0, "HCM", "f8f6a2a1-163c-45c0-bf90-944964f76f0a", "teacher36@gmail.com", true, "Name36", "LastName36", false, null, "teacher36@gmail.com", "teacher36@gmail.com", "AQAAAAIAAYagAAAAEExa3ezC+xoLaN5dXkBiWTo9VNKRT/gNRNyed7Uvq0LaIk2fpjqnAEQzSFdSCgwt5w==", null, false, "", true, false, "teacher36@gmail.com" },
                    { 37, 0, "HCM", "ac1974a2-7f17-4118-bcee-23fd5d49d2cf", "teacher37@gmail.com", true, "Name37", "LastName37", false, null, "teacher37@gmail.com", "teacher37@gmail.com", "AQAAAAIAAYagAAAAEKCX1DZ6FeZ6i0Tq8YpVn5maKonTaRSoIpFWLNEjNyBD+2et0KegwSRBzQPMv4JRXA==", null, false, "", true, false, "teacher37@gmail.com" },
                    { 38, 0, "HCM", "74e2158b-4fde-4c2e-a508-5ec01cae2485", "teacher38@gmail.com", true, "Name38", "LastName38", false, null, "teacher38@gmail.com", "teacher38@gmail.com", "AQAAAAIAAYagAAAAECNaKniNuWXpH1IsKukPCdLUuQT8E4vOwQML/3y2a8ZVrqZTde45a7uBb2gpzzbULw==", null, false, "", true, false, "teacher38@gmail.com" },
                    { 39, 0, "HCM", "c0f035af-e40f-4f39-acd2-e5b411c5301b", "teacher39@gmail.com", true, "Name39", "LastName39", false, null, "teacher39@gmail.com", "teacher39@gmail.com", "AQAAAAIAAYagAAAAEG+iSqm8pRt2h9tG6V+YL/gxRwYipOrWE5Rbm+QXEGIV2x2uu2riOIc4QN+Io5pczQ==", null, false, "", true, false, "teacher39@gmail.com" },
                    { 40, 0, "HCM", "95e74065-6713-4e25-a40e-eb6e26100b3e", "teacher40@gmail.com", true, "Name40", "LastName40", false, null, "teacher40@gmail.com", "teacher40@gmail.com", "AQAAAAIAAYagAAAAECIIR2baBDy8Ma80zp9ccEjVDcYubCzsIzUypxDD0d/dIGiUbhbfjssWGp+H7gMSVw==", null, false, "", true, false, "teacher40@gmail.com" },
                    { 41, 0, "HCM", "d2c69233-dbc0-457d-bc2b-4b1c33733a15", "staff41@gmail.com", true, "Name41", "LastName41", false, null, "staff41@gmail.com", "staff41@gmail.com", "AQAAAAIAAYagAAAAEAHydZ6JLOt6EdvB6DLRpzlv7+l74nplDfR5KkkVlzDZljdpLzlWBpZfrD3Q5Ofhug==", null, false, "", true, false, "staff41@gmail.com" },
                    { 42, 0, "HCM", "5bfae5cf-506e-47b8-8b73-94a8f0d2d163", "staff42@gmail.com", true, "Name42", "LastName42", false, null, "staff42@gmail.com", "staff42@gmail.com", "AQAAAAIAAYagAAAAECc1DiAJgDCHDNvu38TMOSfqPPRLBQUgS6pGYjGRiD3uhgybPeCaG/3DUB2cbfUlkg==", null, false, "", true, false, "staff42@gmail.com" },
                    { 43, 0, "HCM", "43cec95d-86e7-4e4c-961f-81b6f27c97ac", "staff43@gmail.com", true, "Name43", "LastName43", false, null, "staff43@gmail.com", "staff43@gmail.com", "AQAAAAIAAYagAAAAEHcIoo2fIAI2GCSu5Ly3QlLPvB/Gb6u1stRUAj/B4lNkdyqc4f5EH93GUJmozQX6hg==", null, false, "", true, false, "staff43@gmail.com" },
                    { 44, 0, "HCM", "7c25e12a-9b7a-46b2-a121-f440785d9b56", "staff44@gmail.com", true, "Name44", "LastName44", false, null, "staff44@gmail.com", "staff44@gmail.com", "AQAAAAIAAYagAAAAEGUZO5jxagBxyx1qcxhfuiutIZUQOqKpo3ncl1V0H70TE67Mcd9QK60c/nzLBc+nNw==", null, false, "", true, false, "staff44@gmail.com" },
                    { 45, 0, "HCM", "382b7111-3dc9-41e4-a440-29899268f868", "staff45@gmail.com", true, "Name45", "LastName45", false, null, "staff45@gmail.com", "staff45@gmail.com", "AQAAAAIAAYagAAAAEN5sGdIA18iRavARLlllAqTNDiCXglGasUxOskmbG0uBMceZWIKjGV30y/Qry0Jleg==", null, false, "", true, false, "staff45@gmail.com" },
                    { 46, 0, "HCM", "1f592271-bd03-4577-8b13-b3ae80126ff9", "admin46@gmail.com", true, "Name46", "LastName46", false, null, "admin46@gmail.com", "admin46@gmail.com", "AQAAAAIAAYagAAAAEEKgjU3VajBr/GmkBPddxf9PIJAN7qy8tVt4RCtQpm2e23XMy8q066yxhXyUJFRc9g==", null, false, "", true, false, "admin46@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, true, "Category1" },
                    { 2, true, "Category2" },
                    { 3, true, "Category3" },
                    { 4, true, "Category4" },
                    { 5, true, "Category5" },
                    { 6, true, "Category6" },
                    { 7, true, "Category7" },
                    { 8, true, "Category8" },
                    { 9, true, "Category9" },
                    { 10, true, "Category10" }
                });

            migrationBuilder.InsertData(
                table: "TimeSlots",
                columns: new[] { "Id", "DayOfWeek", "EndTime", "StartTime", "Status" },
                values: new object[,]
                {
                    { 11, 1, new DateTime(1, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 6, 30, 0, 0, DateTimeKind.Unspecified), true },
                    { 12, 2, new DateTime(1, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 6, 30, 0, 0, DateTimeKind.Unspecified), true },
                    { 13, 3, new DateTime(1, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 6, 30, 0, 0, DateTimeKind.Unspecified), true },
                    { 14, 4, new DateTime(1, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 6, 30, 0, 0, DateTimeKind.Unspecified), true },
                    { 15, 5, new DateTime(1, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 6, 30, 0, 0, DateTimeKind.Unspecified), true },
                    { 16, 6, new DateTime(1, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 6, 30, 0, 0, DateTimeKind.Unspecified), true },
                    { 17, 0, new DateTime(1, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 6, 30, 0, 0, DateTimeKind.Unspecified), true },
                    { 21, 1, new DateTime(1, 1, 1, 10, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 22, 2, new DateTime(1, 1, 1, 10, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 23, 3, new DateTime(1, 1, 1, 10, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 24, 4, new DateTime(1, 1, 1, 10, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 25, 5, new DateTime(1, 1, 1, 10, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 26, 6, new DateTime(1, 1, 1, 10, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 27, 0, new DateTime(1, 1, 1, 10, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 31, 1, new DateTime(1, 1, 1, 16, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 15, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 32, 2, new DateTime(1, 1, 1, 16, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 15, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 33, 3, new DateTime(1, 1, 1, 16, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 15, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 34, 4, new DateTime(1, 1, 1, 16, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 15, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 35, 5, new DateTime(1, 1, 1, 16, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 15, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 36, 6, new DateTime(1, 1, 1, 16, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 15, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 37, 0, new DateTime(1, 1, 1, 16, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 15, 0, 0, 0, DateTimeKind.Unspecified), true }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 1, 5 },
                    { 1, 6 },
                    { 1, 7 },
                    { 1, 8 },
                    { 1, 9 },
                    { 1, 10 },
                    { 1, 11 },
                    { 1, 12 },
                    { 1, 13 },
                    { 1, 14 },
                    { 1, 15 },
                    { 1, 16 },
                    { 1, 17 },
                    { 1, 18 },
                    { 1, 19 },
                    { 1, 20 },
                    { 1, 21 },
                    { 1, 22 },
                    { 1, 23 },
                    { 1, 24 },
                    { 1, 25 },
                    { 1, 26 },
                    { 1, 27 },
                    { 1, 28 },
                    { 1, 29 },
                    { 1, 30 },
                    { 2, 31 },
                    { 2, 32 },
                    { 2, 33 },
                    { 2, 34 },
                    { 2, 35 },
                    { 2, 36 },
                    { 2, 37 },
                    { 2, 38 },
                    { 2, 39 },
                    { 2, 40 },
                    { 3, 41 },
                    { 3, 42 },
                    { 3, 43 },
                    { 3, 44 },
                    { 3, 45 },
                    { 4, 46 }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "Description", "EnddDate", "IsActive", "Name", "Price", "StartDate" },
                values: new object[,]
                {
                    { 1, 1, "Yoga course number 1", new DateTime(2023, 8, 6, 10, 56, 14, 772, DateTimeKind.Local).AddTicks(7816), true, "Course1", 100.0, new DateTime(2023, 7, 6, 10, 56, 14, 772, DateTimeKind.Local).AddTicks(7797) },
                    { 2, 2, "Yoga course number 2", new DateTime(2023, 8, 6, 10, 56, 14, 772, DateTimeKind.Local).AddTicks(7829), true, "Course2", 200.0, new DateTime(2023, 7, 6, 10, 56, 14, 772, DateTimeKind.Local).AddTicks(7829) },
                    { 3, 3, "Yoga course number 3", new DateTime(2023, 8, 6, 10, 56, 14, 772, DateTimeKind.Local).AddTicks(7924), true, "Course3", 300.0, new DateTime(2023, 7, 6, 10, 56, 14, 772, DateTimeKind.Local).AddTicks(7924) },
                    { 4, 4, "Yoga course number 4", new DateTime(2023, 8, 6, 10, 56, 14, 772, DateTimeKind.Local).AddTicks(8005), true, "Course4", 400.0, new DateTime(2023, 7, 6, 10, 56, 14, 772, DateTimeKind.Local).AddTicks(8004) },
                    { 5, 5, "Yoga course number 5", new DateTime(2023, 8, 6, 10, 56, 14, 772, DateTimeKind.Local).AddTicks(8011), true, "Course5", 500.0, new DateTime(2023, 7, 6, 10, 56, 14, 772, DateTimeKind.Local).AddTicks(8010) },
                    { 6, 6, "Yoga course number 6", new DateTime(2023, 8, 6, 10, 56, 14, 772, DateTimeKind.Local).AddTicks(8016), true, "Course6", 600.0, new DateTime(2023, 7, 6, 10, 56, 14, 772, DateTimeKind.Local).AddTicks(8015) },
                    { 7, 7, "Yoga course number 7", new DateTime(2023, 8, 6, 10, 56, 14, 772, DateTimeKind.Local).AddTicks(8020), true, "Course7", 700.0, new DateTime(2023, 7, 6, 10, 56, 14, 772, DateTimeKind.Local).AddTicks(8020) },
                    { 8, 8, "Yoga course number 8", new DateTime(2023, 8, 6, 10, 56, 14, 772, DateTimeKind.Local).AddTicks(8024), true, "Course8", 800.0, new DateTime(2023, 7, 6, 10, 56, 14, 772, DateTimeKind.Local).AddTicks(8023) },
                    { 9, 9, "Yoga course number 9", new DateTime(2023, 8, 6, 10, 56, 14, 772, DateTimeKind.Local).AddTicks(8028), true, "Course9", 900.0, new DateTime(2023, 7, 6, 10, 56, 14, 772, DateTimeKind.Local).AddTicks(8028) },
                    { 10, 10, "Yoga course number 10", new DateTime(2023, 8, 6, 10, 56, 14, 772, DateTimeKind.Local).AddTicks(8033), true, "Course10", 1000.0, new DateTime(2023, 7, 6, 10, 56, 14, 772, DateTimeKind.Local).AddTicks(8033) }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "AppUserId", "MemberLevel" },
                values: new object[,]
                {
                    { 1, 1, 0 },
                    { 2, 2, 0 },
                    { 3, 3, 0 },
                    { 4, 4, 0 },
                    { 5, 5, 0 },
                    { 6, 6, 0 },
                    { 7, 7, 0 },
                    { 8, 8, 0 },
                    { 9, 9, 0 },
                    { 10, 10, 0 },
                    { 11, 11, 0 },
                    { 12, 12, 0 },
                    { 13, 13, 0 },
                    { 14, 14, 0 },
                    { 15, 15, 0 },
                    { 16, 16, 0 },
                    { 17, 17, 0 },
                    { 18, 18, 0 },
                    { 19, 19, 0 },
                    { 20, 20, 0 },
                    { 21, 21, 0 },
                    { 22, 22, 0 },
                    { 23, 23, 0 },
                    { 24, 24, 0 },
                    { 25, 25, 0 },
                    { 26, 26, 0 },
                    { 27, 27, 0 },
                    { 28, 28, 0 },
                    { 29, 29, 0 },
                    { 30, 30, 0 }
                });

            migrationBuilder.InsertData(
                table: "TeacherProfiles",
                columns: new[] { "Id", "AppUserId" },
                values: new object[,]
                {
                    { 31, 31 },
                    { 32, 32 },
                    { 33, 33 },
                    { 34, 34 },
                    { 35, 35 },
                    { 36, 36 },
                    { 37, 37 },
                    { 38, 38 },
                    { 39, 39 },
                    { 40, 40 }
                });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "Id", "AppUserId", "Balance", "IsAdminWallet" },
                values: new object[,]
                {
                    { 1, 1, 0.0, false },
                    { 2, 2, 0.0, false },
                    { 3, 3, 0.0, false },
                    { 4, 4, 0.0, false },
                    { 5, 5, 0.0, false },
                    { 6, 6, 0.0, false },
                    { 7, 7, 0.0, false },
                    { 8, 8, 0.0, false },
                    { 9, 9, 0.0, false },
                    { 10, 10, 0.0, false },
                    { 11, 11, 0.0, false },
                    { 12, 12, 0.0, false },
                    { 13, 13, 0.0, false },
                    { 14, 14, 0.0, false },
                    { 15, 15, 0.0, false },
                    { 16, 16, 0.0, false },
                    { 17, 17, 0.0, false },
                    { 18, 18, 0.0, false },
                    { 19, 19, 0.0, false },
                    { 20, 20, 0.0, false },
                    { 21, 21, 0.0, false },
                    { 22, 22, 0.0, false },
                    { 23, 23, 0.0, false },
                    { 24, 24, 0.0, false },
                    { 25, 25, 0.0, false },
                    { 26, 26, 0.0, false },
                    { 27, 27, 0.0, false },
                    { 28, 28, 0.0, false },
                    { 29, 29, 0.0, false },
                    { 30, 30, 0.0, false },
                    { 31, 31, 0.0, false },
                    { 32, 32, 0.0, false },
                    { 33, 33, 0.0, false },
                    { 34, 34, 0.0, false },
                    { 35, 35, 0.0, false },
                    { 36, 36, 0.0, false },
                    { 37, 37, 0.0, false },
                    { 38, 38, 0.0, false },
                    { 39, 39, 0.0, false },
                    { 40, 40, 0.0, false },
                    { 41, 41, 0.0, false },
                    { 42, 42, 0.0, false },
                    { 43, 43, 0.0, false },
                    { 44, 44, 0.0, false },
                    { 45, 45, 0.0, false },
                    { 46, 46, 0.0, true }
                });

            migrationBuilder.InsertData(
                table: "YogaClasses",
                columns: new[] { "Id", "CourseId", "Name", "Size", "YogaClassStatus" },
                values: new object[,]
                {
                    { 1, 1, "Class1", 19, 2 },
                    { 2, 2, "Class2", 18, 1 },
                    { 3, 3, "Class3", 17, 2 },
                    { 4, 4, "Class4", 16, 1 },
                    { 5, 5, "Class5", 15, 2 },
                    { 6, 6, "Class6", 14, 1 },
                    { 7, 7, "Class7", 13, 2 },
                    { 8, 8, "Class8", 12, 1 },
                    { 9, 9, "Class9", 11, 2 },
                    { 10, 10, "Class10", 10, 1 }
                });

            migrationBuilder.InsertData(
                table: "Schedule",
                columns: new[] { "TimeSlotId", "YogaClassId" },
                values: new object[,]
                {
                    { 11, 1 },
                    { 12, 2 },
                    { 13, 1 },
                    { 14, 2 },
                    { 15, 1 },
                    { 16, 7 },
                    { 17, 7 },
                    { 21, 3 },
                    { 22, 4 },
                    { 23, 3 },
                    { 24, 4 },
                    { 25, 3 },
                    { 26, 8 },
                    { 27, 8 },
                    { 31, 5 },
                    { 32, 6 },
                    { 33, 5 },
                    { 34, 6 },
                    { 35, 5 },
                    { 36, 9 },
                    { 37, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CategoryId",
                table: "Courses",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_YogaClassId",
                table: "Enrollments",
                column: "YogaClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_AppUserId",
                table: "Members",
                column: "AppUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_YogaClassId",
                table: "Schedule",
                column: "YogaClassId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherEnrollments_TeacherProfileId",
                table: "TeacherEnrollments",
                column: "TeacherProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherEnrollments_YogaClassId",
                table: "TeacherEnrollments",
                column: "YogaClassId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherProfiles_AppUserId",
                table: "TeacherProfiles",
                column: "AppUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeacherProfileTimeSlot_AvailableTeacherId",
                table: "TeacherProfileTimeSlot",
                column: "AvailableTeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSchedule_TeacherProfileId",
                table: "TeacherSchedule",
                column: "TeacherProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_WalletId",
                table: "Transactions",
                column: "WalletId");

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_AppUserId",
                table: "Wallets",
                column: "AppUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_YogaClasses_CourseId",
                table: "YogaClasses",
                column: "CourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "TeacherEnrollments");

            migrationBuilder.DropTable(
                name: "TeacherProfileTimeSlot");

            migrationBuilder.DropTable(
                name: "TeacherSchedule");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "YogaClasses");

            migrationBuilder.DropTable(
                name: "TeacherProfiles");

            migrationBuilder.DropTable(
                name: "TimeSlots");

            migrationBuilder.DropTable(
                name: "Wallets");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
