using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YogaManagement.Database.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
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
                    Room = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "TimeSlotYogaClass",
                columns: table => new
                {
                    TimeSlotsId = table.Column<int>(type: "int", nullable: false),
                    YogaClassesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSlotYogaClass", x => new { x.TimeSlotsId, x.YogaClassesId });
                    table.ForeignKey(
                        name: "FK_TimeSlotYogaClass_TimeSlots_TimeSlotsId",
                        column: x => x.TimeSlotsId,
                        principalTable: "TimeSlots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeSlotYogaClass_YogaClasses_YogaClassesId",
                        column: x => x.YogaClassesId,
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
                    { 1, 0, "HCM", "139f5ba1-9386-4f64-acbd-b93e11c00372", "member1@gmail.com", true, "Name1", "LastName1", false, null, "member1@gmail.com", "member1@gmail.com", "AQAAAAIAAYagAAAAEDHzNzKumH9jBeMK+9DvRs+Wm8eaBN5vH3uKXCA+D6UalsaL24ZnKyoXNaH3Ydn0mg==", null, false, "", true, false, "member1@gmail.com" },
                    { 2, 0, "HCM", "5b858200-0343-4f81-9e4c-7b84ea981f10", "member2@gmail.com", true, "Name2", "LastName2", false, null, "member2@gmail.com", "member2@gmail.com", "AQAAAAIAAYagAAAAEKLSv+HdTICy5RdgNFfd/nAwSvLpkPhGrWktsLiSLvHtS3MgjsBCoOSMdspOHz5Prg==", null, false, "", true, false, "member2@gmail.com" },
                    { 3, 0, "HCM", "b2dad1b7-1d73-4c40-952f-fb30458fc569", "member3@gmail.com", true, "Name3", "LastName3", false, null, "member3@gmail.com", "member3@gmail.com", "AQAAAAIAAYagAAAAEMCuHvwqriwj496mCcP/9YpmHxrqtSEv+Rchmf+9TcuzUMceshVi6J/BaaAvJ7WxCg==", null, false, "", true, false, "member3@gmail.com" },
                    { 4, 0, "HCM", "5c050754-8b2e-4799-8b42-6f4bf66d619e", "member4@gmail.com", true, "Name4", "LastName4", false, null, "member4@gmail.com", "member4@gmail.com", "AQAAAAIAAYagAAAAENGIu/10hGzInTXhJ57TjXf8A/smX0TC/fC3XnClsaQLPH0lkzVHMKmExzjvkSeLCQ==", null, false, "", true, false, "member4@gmail.com" },
                    { 5, 0, "HCM", "b77b6cb4-c1d7-44af-8909-0090d7820578", "member5@gmail.com", true, "Name5", "LastName5", false, null, "member5@gmail.com", "member5@gmail.com", "AQAAAAIAAYagAAAAEEyEHDEzsnEhudKjNJIdCWPQE9uj18lhHW3aXz7rHKLrziawl+eI3xhhgR1avaXvXw==", null, false, "", true, false, "member5@gmail.com" },
                    { 6, 0, "HCM", "1b015ef8-b1be-41f2-9983-9aae499c3dad", "member6@gmail.com", true, "Name6", "LastName6", false, null, "member6@gmail.com", "member6@gmail.com", "AQAAAAIAAYagAAAAELEzJgfgo2nOWXJqmw36h9HiOkzL/rlQb+l0TOJ7iA264XeaHQX1eVxxGH1X9ari3w==", null, false, "", true, false, "member6@gmail.com" },
                    { 7, 0, "HCM", "e86d0abf-4a6b-4c28-9512-39a046f8dda1", "member7@gmail.com", true, "Name7", "LastName7", false, null, "member7@gmail.com", "member7@gmail.com", "AQAAAAIAAYagAAAAEFrRAFqGHAYZUhmV1RbdEOvjkz2Icjey6iaJV0lYz8wd1XHmebBNfGVRdna9bUZa1Q==", null, false, "", true, false, "member7@gmail.com" },
                    { 8, 0, "HCM", "74d9ecb0-2d8c-46eb-ad23-08010f345fb9", "member8@gmail.com", true, "Name8", "LastName8", false, null, "member8@gmail.com", "member8@gmail.com", "AQAAAAIAAYagAAAAEIObcpvTNl1JPQiXReo40GM/MjMnwk3YU2ScSS42GOj9nxEg3f3X1sTXS7ibeK5whA==", null, false, "", true, false, "member8@gmail.com" },
                    { 9, 0, "HCM", "68ab2bc7-bf62-4a9a-9db2-819c493865c9", "member9@gmail.com", true, "Name9", "LastName9", false, null, "member9@gmail.com", "member9@gmail.com", "AQAAAAIAAYagAAAAEADkVz/RbBC8UadoONH/gnPc/LxxxL7x5FQ6D4QlO2KecHz0kfC3BddkK0AYEE2uUg==", null, false, "", true, false, "member9@gmail.com" },
                    { 10, 0, "HCM", "c9929512-5be4-4563-83a2-e40602876023", "member10@gmail.com", true, "Name10", "LastName10", false, null, "member10@gmail.com", "member10@gmail.com", "AQAAAAIAAYagAAAAEBEzc5th+2wsvWGdabMiQMd57E1dqIG0kdqGgDbSONOCg2WNi21PCOwwXeT6KHMD/w==", null, false, "", true, false, "member10@gmail.com" },
                    { 11, 0, "HCM", "c6dd02bf-820c-45e2-84d2-773016ec62e8", "member11@gmail.com", true, "Name11", "LastName11", false, null, "member11@gmail.com", "member11@gmail.com", "AQAAAAIAAYagAAAAEDrRInok0ZY7UnmLIaINqhGuI1ghrAn/K/yC5UkXDcKVJfto/zmsLt3gbrVvRMVy4w==", null, false, "", true, false, "member11@gmail.com" },
                    { 12, 0, "HCM", "14e545a9-b44e-43a8-a023-2d6c35bd77be", "member12@gmail.com", true, "Name12", "LastName12", false, null, "member12@gmail.com", "member12@gmail.com", "AQAAAAIAAYagAAAAEMrDF8bEzcaBBC99QB+RsYJMonJJUqdJ6YLlpDhTEwIdtQCYxxjoWisOnP3n78DJUw==", null, false, "", true, false, "member12@gmail.com" },
                    { 13, 0, "HCM", "3706e1bb-7b72-4436-9e1d-3e9f4d6dc5ab", "member13@gmail.com", true, "Name13", "LastName13", false, null, "member13@gmail.com", "member13@gmail.com", "AQAAAAIAAYagAAAAEC4Nay8R0wSpqFI6ZiEbKqKYKTVcMUXg5O2xktuwb+ieFV+D/M+7ks+unNxKDhEK0g==", null, false, "", true, false, "member13@gmail.com" },
                    { 14, 0, "HCM", "405fafae-c0d5-44c8-b81d-3c7b6bfeaad1", "member14@gmail.com", true, "Name14", "LastName14", false, null, "member14@gmail.com", "member14@gmail.com", "AQAAAAIAAYagAAAAEA8JmgXu70lhgKx65FpA4ojMhhWz/2r+YTQLt/4utAlvFJw2OkIRb9mRrOXPleAJXQ==", null, false, "", true, false, "member14@gmail.com" },
                    { 15, 0, "HCM", "531bb520-bb6b-43ec-a1df-3621afc0d8ec", "member15@gmail.com", true, "Name15", "LastName15", false, null, "member15@gmail.com", "member15@gmail.com", "AQAAAAIAAYagAAAAEKv6JVBnm0nG22LHYVoBUUkFaSUTozMDN6O/FaC45/gfIzD9Ws/d+eHV9McCqcpZUA==", null, false, "", true, false, "member15@gmail.com" },
                    { 16, 0, "HCM", "70cfa7a5-0979-43bf-a1e0-3f73593f3471", "member16@gmail.com", true, "Name16", "LastName16", false, null, "member16@gmail.com", "member16@gmail.com", "AQAAAAIAAYagAAAAEAcQiUG4UjduehwHDXzEX1etjFdh2vsBWWU6imGl960au9A7oFcTbx+ZZM3HeiNF6g==", null, false, "", true, false, "member16@gmail.com" },
                    { 17, 0, "HCM", "5f3ac3c2-316a-4c95-9d87-de87999716e1", "member17@gmail.com", true, "Name17", "LastName17", false, null, "member17@gmail.com", "member17@gmail.com", "AQAAAAIAAYagAAAAEC19LhCQhUxV3xg/lBSvJluajg36qImf5dIfCHgrZIPaz94AWWqWqYl9AWzXg+mTFA==", null, false, "", true, false, "member17@gmail.com" },
                    { 18, 0, "HCM", "a0454a41-6e64-4660-a6e1-5f11ef7a1a3a", "member18@gmail.com", true, "Name18", "LastName18", false, null, "member18@gmail.com", "member18@gmail.com", "AQAAAAIAAYagAAAAEIHsQJ/4KXsRI+rHEO3IUNZ58rtgI8G4iqz1m7fD2GZ6U/WPChBDhpkQVfXiGKJoFw==", null, false, "", true, false, "member18@gmail.com" },
                    { 19, 0, "HCM", "1e608faf-3497-44f9-99e5-373fa9acc4e6", "member19@gmail.com", true, "Name19", "LastName19", false, null, "member19@gmail.com", "member19@gmail.com", "AQAAAAIAAYagAAAAECSNsiNXEX9WsSdlfL3Jt5MALjlo6I87ShWDtzNA7zC6dmkrIooMeESFVEbYhbSKfw==", null, false, "", true, false, "member19@gmail.com" },
                    { 20, 0, "HCM", "aa70541b-c7a3-48e2-a7dd-621ad5480394", "member20@gmail.com", true, "Name20", "LastName20", false, null, "member20@gmail.com", "member20@gmail.com", "AQAAAAIAAYagAAAAEM7DMOD/0zG6EvL4VC/Srg5PVyR2oWneLSg4z9fZ24YxoHXryYQATosNsOBttt9WOw==", null, false, "", true, false, "member20@gmail.com" },
                    { 21, 0, "HCM", "0f71bd8a-b1a1-42ab-abfb-a0e2a7897805", "member21@gmail.com", true, "Name21", "LastName21", false, null, "member21@gmail.com", "member21@gmail.com", "AQAAAAIAAYagAAAAEFvEQKolouWnS1jn5HrgC8Y3c5ye6WXFl+f9HYLxyAK+8i5b5kqp7/Rc1kBPYoyoiQ==", null, false, "", true, false, "member21@gmail.com" },
                    { 22, 0, "HCM", "74adf266-b3cc-489e-979a-37b6c5b6da85", "member22@gmail.com", true, "Name22", "LastName22", false, null, "member22@gmail.com", "member22@gmail.com", "AQAAAAIAAYagAAAAEIgPxx3/9/u9aRBGnGIjIfG0L0gPhVou6z1gUBenx2e9WhyMCQegM/1C8+uIJ2BUhw==", null, false, "", true, false, "member22@gmail.com" },
                    { 23, 0, "HCM", "1762be2f-d356-40c7-9758-2f852d3151b9", "member23@gmail.com", true, "Name23", "LastName23", false, null, "member23@gmail.com", "member23@gmail.com", "AQAAAAIAAYagAAAAELNO9RyDoDepwBBpM9DCKUCWQIg0945HDG+p5CjvtyB26rJw2HZsEFDZHUZWnNDo5w==", null, false, "", true, false, "member23@gmail.com" },
                    { 24, 0, "HCM", "d41db394-ffbc-4a57-97ae-7a0b6a4b3182", "member24@gmail.com", true, "Name24", "LastName24", false, null, "member24@gmail.com", "member24@gmail.com", "AQAAAAIAAYagAAAAEMMIS41881uaeq9QKd+8TD/dB9jBdMxDRGlVgaNOdiFhsH2k/bdxu+sHuTKnb+ub6g==", null, false, "", true, false, "member24@gmail.com" },
                    { 25, 0, "HCM", "a21a4ca0-95fe-41af-9138-3700843b8234", "member25@gmail.com", true, "Name25", "LastName25", false, null, "member25@gmail.com", "member25@gmail.com", "AQAAAAIAAYagAAAAEPKHttGWnYROeGosohIt5f7qK90Pvf1/YuCIr5RO/mzS1OfiXS8uNcnKFkwKesA/og==", null, false, "", true, false, "member25@gmail.com" },
                    { 26, 0, "HCM", "649ccad2-ed51-4c53-a9a0-ec8c59ac36bd", "member26@gmail.com", true, "Name26", "LastName26", false, null, "member26@gmail.com", "member26@gmail.com", "AQAAAAIAAYagAAAAEPu300bCOb6L/Sgwo2w4Q2ia5jZ6QIASqpUpIqGAM1tiCstaX5MFSE8xbFNm4zp9Zg==", null, false, "", true, false, "member26@gmail.com" },
                    { 27, 0, "HCM", "25b192aa-b23d-4d63-9ade-957101920cc1", "member27@gmail.com", true, "Name27", "LastName27", false, null, "member27@gmail.com", "member27@gmail.com", "AQAAAAIAAYagAAAAENJDo8A0vamQrsqBcKaVzqJzvpQWOoYz3iv0NLNTYWb9NBAzSZJvUU9SOhj3mC3LDg==", null, false, "", true, false, "member27@gmail.com" },
                    { 28, 0, "HCM", "030219a6-930d-4188-860f-d61583065b06", "member28@gmail.com", true, "Name28", "LastName28", false, null, "member28@gmail.com", "member28@gmail.com", "AQAAAAIAAYagAAAAEAoINZ0eXEUTXhqywl0BlHdgASVbgPWOCeUCYYG1m3WzDMu9jR74aXq/irdYcDKlgA==", null, false, "", true, false, "member28@gmail.com" },
                    { 29, 0, "HCM", "73c1111e-1511-4747-bb42-b5b9e3ab91ba", "member29@gmail.com", true, "Name29", "LastName29", false, null, "member29@gmail.com", "member29@gmail.com", "AQAAAAIAAYagAAAAELfSRu3rZFqyzVYQ96Peks3eMpJgMwPDMlQ3wcnjbqYnLeMzx9LX48yg/mLC47bneA==", null, false, "", true, false, "member29@gmail.com" },
                    { 30, 0, "HCM", "b3389dd1-aade-4f2d-9e93-b5aea431f17b", "member30@gmail.com", true, "Name30", "LastName30", false, null, "member30@gmail.com", "member30@gmail.com", "AQAAAAIAAYagAAAAEA9PZOjIuDa+EbLkN+4WptkyiEI6B3ozGZgvQJm3umqwD8ltwlZl9rDuYQHlCMCM4w==", null, false, "", true, false, "member30@gmail.com" },
                    { 31, 0, "HCM", "2c59bf3d-ede7-4a8f-9c58-8e8e58fe0b5c", "teacher31@gmail.com", true, "Name31", "LastName31", false, null, "teacher31@gmail.com", "teacher31@gmail.com", "AQAAAAIAAYagAAAAEDs6j7IsJRqcUnIsuuVqNuxtquoxn54XUHA8ldIg4mlkwNZSd9j4bbiA9z7pQLTl2A==", null, false, "", true, false, "teacher31@gmail.com" },
                    { 32, 0, "HCM", "34ad4ad0-8a7b-42d2-8e8d-ef99dedbad25", "teacher32@gmail.com", true, "Name32", "LastName32", false, null, "teacher32@gmail.com", "teacher32@gmail.com", "AQAAAAIAAYagAAAAEOvWDh4YRJS83iUTZzl1o1uau8KG227D4iKEm3TQK7lUhB8jfMF+EQwdAmKsYP4DYg==", null, false, "", true, false, "teacher32@gmail.com" },
                    { 33, 0, "HCM", "e339e708-f501-4096-912e-71b6d7aceb8b", "teacher33@gmail.com", true, "Name33", "LastName33", false, null, "teacher33@gmail.com", "teacher33@gmail.com", "AQAAAAIAAYagAAAAEGI/yDcc2IQVOYcJC/HpbcJ5CoZZHTFNJO4lQ3LLd1RMjMWQJodmmTrqWo2XLRdqUQ==", null, false, "", true, false, "teacher33@gmail.com" },
                    { 34, 0, "HCM", "2230e46e-5cf1-4619-8417-f97b50c5ec3f", "teacher34@gmail.com", true, "Name34", "LastName34", false, null, "teacher34@gmail.com", "teacher34@gmail.com", "AQAAAAIAAYagAAAAECxV+BmIwqvduOEj9fw1i9isgrAPb5DkD/ZWcs6LhzLhGbyEORgEIWAdDTL9mDH7Gw==", null, false, "", true, false, "teacher34@gmail.com" },
                    { 35, 0, "HCM", "82580fb5-46c4-4192-ae7b-9b919f5b99d2", "teacher35@gmail.com", true, "Name35", "LastName35", false, null, "teacher35@gmail.com", "teacher35@gmail.com", "AQAAAAIAAYagAAAAEIsR/fxNQEegFhJ2dY6upwPXbHim0+SrUERi2xhdYpQfc9VaPwfig3vuqySLK6yKJg==", null, false, "", true, false, "teacher35@gmail.com" },
                    { 36, 0, "HCM", "9ac40ff1-1175-45c8-87f2-02dc811df5c9", "teacher36@gmail.com", true, "Name36", "LastName36", false, null, "teacher36@gmail.com", "teacher36@gmail.com", "AQAAAAIAAYagAAAAEINEp9vLoNBIHn3ky4CTr8qjpdMimDnXR/2kGxSFXBJT0Q6PlK4k8Fd/ytFP7ylSDg==", null, false, "", true, false, "teacher36@gmail.com" },
                    { 37, 0, "HCM", "e2bfe579-04d0-41b4-a408-2047d42697cf", "teacher37@gmail.com", true, "Name37", "LastName37", false, null, "teacher37@gmail.com", "teacher37@gmail.com", "AQAAAAIAAYagAAAAEPBfXbBzx23G8ZMkna9oy6wwxty54QUnGXmZD/e4Vd0WXYIaCYTexPldscWwRqRHKA==", null, false, "", true, false, "teacher37@gmail.com" },
                    { 38, 0, "HCM", "ea5445c7-b828-44f7-bf41-e518cdc32818", "teacher38@gmail.com", true, "Name38", "LastName38", false, null, "teacher38@gmail.com", "teacher38@gmail.com", "AQAAAAIAAYagAAAAENYcW1yi07X/mJzUz+FZw+g4SZIHqQwzF8vpp6Vl6Bf/j1BPOET8waG3bTi1H/n1iA==", null, false, "", true, false, "teacher38@gmail.com" },
                    { 39, 0, "HCM", "4d351ff8-eaa5-4435-ad47-45235d0a2b97", "teacher39@gmail.com", true, "Name39", "LastName39", false, null, "teacher39@gmail.com", "teacher39@gmail.com", "AQAAAAIAAYagAAAAELZHYm5XDHnPn1PkfGKRWCyjMBG7q0PNWbVQEifJ0ypTmqSAoaIr1Orl3ElLC78L1A==", null, false, "", true, false, "teacher39@gmail.com" },
                    { 40, 0, "HCM", "8d2528f6-3aa4-4aad-9d12-c6936406f3ad", "teacher40@gmail.com", true, "Name40", "LastName40", false, null, "teacher40@gmail.com", "teacher40@gmail.com", "AQAAAAIAAYagAAAAEO1bO3G3RqrEpjq5qIMwyJ2VG4czcyB/tw003wR6u+8y/Q+SADynLq2trYcdUyRCwA==", null, false, "", true, false, "teacher40@gmail.com" },
                    { 41, 0, "HCM", "5018a2a8-13f8-4681-9041-4355bfaf164e", "staff41@gmail.com", true, "Name41", "LastName41", false, null, "staff41@gmail.com", "staff41@gmail.com", "AQAAAAIAAYagAAAAEG8vxo5CtX7suspHR1mSXvPKyPU0OUad8zpeWAH8rMAPW1c2KG6uVUPDNFhtGRpK4w==", null, false, "", true, false, "staff41@gmail.com" },
                    { 42, 0, "HCM", "906e52a4-e98d-4fd5-9775-961a157d465a", "staff42@gmail.com", true, "Name42", "LastName42", false, null, "staff42@gmail.com", "staff42@gmail.com", "AQAAAAIAAYagAAAAEIRQ+Y7JSPjb73tCPdcBbpeORkigqDSEtN0a0D1Bv1t19WVLbWKx2YzzLuYoSnhQ8w==", null, false, "", true, false, "staff42@gmail.com" },
                    { 43, 0, "HCM", "ed96ccb5-2b6d-4dcb-9bba-00fc2bf8f991", "staff43@gmail.com", true, "Name43", "LastName43", false, null, "staff43@gmail.com", "staff43@gmail.com", "AQAAAAIAAYagAAAAELhOtBL91lR6okWCV2kx6WUhGPIRuN9utgSd82KJHXC/gIX5swETAvAA1pNV0k4dfA==", null, false, "", true, false, "staff43@gmail.com" },
                    { 44, 0, "HCM", "d079e19f-8495-4a47-bd2b-947d2f584c68", "staff44@gmail.com", true, "Name44", "LastName44", false, null, "staff44@gmail.com", "staff44@gmail.com", "AQAAAAIAAYagAAAAENZXb6m9dbK08NG3rN3helB9ivRtZB5sCh7Hfb96N86Ec4AjNu5xji9XmEKLjSBM1Q==", null, false, "", true, false, "staff44@gmail.com" },
                    { 45, 0, "HCM", "3625c748-80cc-4653-b80b-225f4e2f3f9a", "staff45@gmail.com", true, "Name45", "LastName45", false, null, "staff45@gmail.com", "staff45@gmail.com", "AQAAAAIAAYagAAAAEA3UPa34RFwkQwtUqWGZo9VjAKnvunXwgSzC3TiJlVDJm1OTEy1dSBQVrh6imetGcA==", null, false, "", true, false, "staff45@gmail.com" },
                    { 46, 0, "HCM", "48a5eea6-b256-4b51-a6a1-2dac5cf7df44", "admin46@gmail.com", true, "Name46", "LastName46", false, null, "admin46@gmail.com", "admin46@gmail.com", "AQAAAAIAAYagAAAAECs5QXStN5xItlJI7tWbq+iF3fPw2k0cBT/QTz39ZFQLSlsL3bwVARoAAdybhboRsw==", null, false, "", true, false, "admin46@gmail.com" }
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
                columns: new[] { "Id", "DayOfWeek", "EndTime", "Room", "StartTime", "Status" },
                values: new object[,]
                {
                    { 11, 1, new DateTime(1, 1, 1, 7, 0, 0, 0, DateTimeKind.Unspecified), 101, new DateTime(1, 1, 1, 6, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 12, 1, new DateTime(1, 1, 1, 8, 30, 0, 0, DateTimeKind.Unspecified), 202, new DateTime(1, 1, 1, 7, 30, 0, 0, DateTimeKind.Unspecified), true },
                    { 13, 1, new DateTime(1, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), 303, new DateTime(1, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 14, 1, new DateTime(1, 1, 1, 16, 30, 0, 0, DateTimeKind.Unspecified), 404, new DateTime(1, 1, 1, 15, 30, 0, 0, DateTimeKind.Unspecified), true },
                    { 15, 1, new DateTime(1, 1, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), 505, new DateTime(1, 1, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 16, 1, new DateTime(1, 1, 1, 19, 30, 0, 0, DateTimeKind.Unspecified), 606, new DateTime(1, 1, 1, 18, 30, 0, 0, DateTimeKind.Unspecified), true },
                    { 17, 1, new DateTime(1, 1, 1, 21, 0, 0, 0, DateTimeKind.Unspecified), 707, new DateTime(1, 1, 1, 20, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 21, 2, new DateTime(1, 1, 1, 7, 0, 0, 0, DateTimeKind.Unspecified), 101, new DateTime(1, 1, 1, 6, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 22, 2, new DateTime(1, 1, 1, 8, 30, 0, 0, DateTimeKind.Unspecified), 202, new DateTime(1, 1, 1, 7, 30, 0, 0, DateTimeKind.Unspecified), true },
                    { 23, 2, new DateTime(1, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), 303, new DateTime(1, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 24, 2, new DateTime(1, 1, 1, 16, 30, 0, 0, DateTimeKind.Unspecified), 404, new DateTime(1, 1, 1, 15, 30, 0, 0, DateTimeKind.Unspecified), true },
                    { 25, 2, new DateTime(1, 1, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), 505, new DateTime(1, 1, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 26, 2, new DateTime(1, 1, 1, 19, 30, 0, 0, DateTimeKind.Unspecified), 606, new DateTime(1, 1, 1, 18, 30, 0, 0, DateTimeKind.Unspecified), true },
                    { 27, 2, new DateTime(1, 1, 1, 21, 0, 0, 0, DateTimeKind.Unspecified), 707, new DateTime(1, 1, 1, 20, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 31, 3, new DateTime(1, 1, 1, 7, 0, 0, 0, DateTimeKind.Unspecified), 101, new DateTime(1, 1, 1, 6, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 32, 3, new DateTime(1, 1, 1, 8, 30, 0, 0, DateTimeKind.Unspecified), 202, new DateTime(1, 1, 1, 7, 30, 0, 0, DateTimeKind.Unspecified), true },
                    { 33, 3, new DateTime(1, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), 303, new DateTime(1, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 34, 3, new DateTime(1, 1, 1, 16, 30, 0, 0, DateTimeKind.Unspecified), 404, new DateTime(1, 1, 1, 15, 30, 0, 0, DateTimeKind.Unspecified), true },
                    { 35, 3, new DateTime(1, 1, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), 505, new DateTime(1, 1, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 36, 3, new DateTime(1, 1, 1, 19, 30, 0, 0, DateTimeKind.Unspecified), 606, new DateTime(1, 1, 1, 18, 30, 0, 0, DateTimeKind.Unspecified), true },
                    { 37, 3, new DateTime(1, 1, 1, 21, 0, 0, 0, DateTimeKind.Unspecified), 707, new DateTime(1, 1, 1, 20, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 41, 4, new DateTime(1, 1, 1, 7, 0, 0, 0, DateTimeKind.Unspecified), 101, new DateTime(1, 1, 1, 6, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 42, 4, new DateTime(1, 1, 1, 8, 30, 0, 0, DateTimeKind.Unspecified), 202, new DateTime(1, 1, 1, 7, 30, 0, 0, DateTimeKind.Unspecified), true },
                    { 43, 4, new DateTime(1, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), 303, new DateTime(1, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 44, 4, new DateTime(1, 1, 1, 16, 30, 0, 0, DateTimeKind.Unspecified), 404, new DateTime(1, 1, 1, 15, 30, 0, 0, DateTimeKind.Unspecified), true },
                    { 45, 4, new DateTime(1, 1, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), 505, new DateTime(1, 1, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 46, 4, new DateTime(1, 1, 1, 19, 30, 0, 0, DateTimeKind.Unspecified), 606, new DateTime(1, 1, 1, 18, 30, 0, 0, DateTimeKind.Unspecified), true },
                    { 47, 4, new DateTime(1, 1, 1, 21, 0, 0, 0, DateTimeKind.Unspecified), 707, new DateTime(1, 1, 1, 20, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 51, 5, new DateTime(1, 1, 1, 7, 0, 0, 0, DateTimeKind.Unspecified), 101, new DateTime(1, 1, 1, 6, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 52, 5, new DateTime(1, 1, 1, 8, 30, 0, 0, DateTimeKind.Unspecified), 202, new DateTime(1, 1, 1, 7, 30, 0, 0, DateTimeKind.Unspecified), true },
                    { 53, 5, new DateTime(1, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), 303, new DateTime(1, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 54, 5, new DateTime(1, 1, 1, 16, 30, 0, 0, DateTimeKind.Unspecified), 404, new DateTime(1, 1, 1, 15, 30, 0, 0, DateTimeKind.Unspecified), true },
                    { 55, 5, new DateTime(1, 1, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), 505, new DateTime(1, 1, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 56, 5, new DateTime(1, 1, 1, 19, 30, 0, 0, DateTimeKind.Unspecified), 606, new DateTime(1, 1, 1, 18, 30, 0, 0, DateTimeKind.Unspecified), true },
                    { 57, 5, new DateTime(1, 1, 1, 21, 0, 0, 0, DateTimeKind.Unspecified), 707, new DateTime(1, 1, 1, 20, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 61, 6, new DateTime(1, 1, 1, 7, 0, 0, 0, DateTimeKind.Unspecified), 101, new DateTime(1, 1, 1, 6, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 62, 6, new DateTime(1, 1, 1, 8, 30, 0, 0, DateTimeKind.Unspecified), 202, new DateTime(1, 1, 1, 7, 30, 0, 0, DateTimeKind.Unspecified), true },
                    { 63, 6, new DateTime(1, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), 303, new DateTime(1, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 64, 6, new DateTime(1, 1, 1, 16, 30, 0, 0, DateTimeKind.Unspecified), 404, new DateTime(1, 1, 1, 15, 30, 0, 0, DateTimeKind.Unspecified), true },
                    { 65, 6, new DateTime(1, 1, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), 505, new DateTime(1, 1, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 66, 6, new DateTime(1, 1, 1, 19, 30, 0, 0, DateTimeKind.Unspecified), 606, new DateTime(1, 1, 1, 18, 30, 0, 0, DateTimeKind.Unspecified), true },
                    { 67, 6, new DateTime(1, 1, 1, 21, 0, 0, 0, DateTimeKind.Unspecified), 707, new DateTime(1, 1, 1, 20, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 71, 0, new DateTime(1, 1, 1, 7, 0, 0, 0, DateTimeKind.Unspecified), 101, new DateTime(1, 1, 1, 6, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 72, 0, new DateTime(1, 1, 1, 8, 30, 0, 0, DateTimeKind.Unspecified), 202, new DateTime(1, 1, 1, 7, 30, 0, 0, DateTimeKind.Unspecified), true },
                    { 73, 0, new DateTime(1, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), 303, new DateTime(1, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 74, 0, new DateTime(1, 1, 1, 16, 30, 0, 0, DateTimeKind.Unspecified), 404, new DateTime(1, 1, 1, 15, 30, 0, 0, DateTimeKind.Unspecified), true },
                    { 75, 0, new DateTime(1, 1, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), 505, new DateTime(1, 1, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 76, 0, new DateTime(1, 1, 1, 19, 30, 0, 0, DateTimeKind.Unspecified), 606, new DateTime(1, 1, 1, 18, 30, 0, 0, DateTimeKind.Unspecified), true },
                    { 77, 0, new DateTime(1, 1, 1, 21, 0, 0, 0, DateTimeKind.Unspecified), 707, new DateTime(1, 1, 1, 20, 0, 0, 0, DateTimeKind.Unspecified), true }
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
                    { 1, 1, "Yoga course number 1", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course1", 100.0, new DateTime(2023, 6, 26, 16, 16, 39, 284, DateTimeKind.Local).AddTicks(4746) },
                    { 2, 2, "Yoga course number 2", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course2", 200.0, new DateTime(2023, 6, 26, 16, 16, 39, 284, DateTimeKind.Local).AddTicks(4788) },
                    { 3, 3, "Yoga course number 3", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course3", 300.0, new DateTime(2023, 6, 26, 16, 16, 39, 284, DateTimeKind.Local).AddTicks(4795) },
                    { 4, 4, "Yoga course number 4", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course4", 400.0, new DateTime(2023, 6, 26, 16, 16, 39, 284, DateTimeKind.Local).AddTicks(4801) },
                    { 5, 5, "Yoga course number 5", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course5", 500.0, new DateTime(2023, 6, 26, 16, 16, 39, 284, DateTimeKind.Local).AddTicks(4807) },
                    { 6, 6, "Yoga course number 6", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course6", 600.0, new DateTime(2023, 6, 26, 16, 16, 39, 284, DateTimeKind.Local).AddTicks(4814) },
                    { 7, 7, "Yoga course number 7", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course7", 700.0, new DateTime(2023, 6, 26, 16, 16, 39, 284, DateTimeKind.Local).AddTicks(4820) },
                    { 8, 8, "Yoga course number 8", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course8", 800.0, new DateTime(2023, 6, 26, 16, 16, 39, 284, DateTimeKind.Local).AddTicks(4826) },
                    { 9, 9, "Yoga course number 9", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course9", 900.0, new DateTime(2023, 6, 26, 16, 16, 39, 284, DateTimeKind.Local).AddTicks(4832) },
                    { 10, 10, "Yoga course number 10", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course10", 1000.0, new DateTime(2023, 6, 26, 16, 16, 39, 284, DateTimeKind.Local).AddTicks(4840) }
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
                    { 12, 2 },
                    { 14, 4 },
                    { 16, 6 },
                    { 21, 1 },
                    { 23, 3 },
                    { 25, 5 },
                    { 27, 7 },
                    { 32, 2 },
                    { 34, 4 },
                    { 36, 6 },
                    { 41, 1 },
                    { 43, 3 },
                    { 45, 5 },
                    { 47, 7 },
                    { 52, 2 },
                    { 54, 4 },
                    { 56, 6 },
                    { 61, 1 },
                    { 61, 10 },
                    { 62, 9 },
                    { 63, 3 },
                    { 63, 8 },
                    { 65, 5 },
                    { 67, 7 },
                    { 71, 10 },
                    { 72, 9 },
                    { 73, 8 }
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
                name: "IX_TimeSlotYogaClass_YogaClassesId",
                table: "TimeSlotYogaClass",
                column: "YogaClassesId");

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
                name: "TimeSlotYogaClass");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "TeacherProfiles");

            migrationBuilder.DropTable(
                name: "TimeSlots");

            migrationBuilder.DropTable(
                name: "YogaClasses");

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
