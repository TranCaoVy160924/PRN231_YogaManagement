using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YogaManagement.Database.Migrations
{
    /// <inheritdoc />
    public partial class Ini : Migration
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
                    { 1, 0, "HCM", "88794026-afac-41de-90fd-4e2b18a540e5", "member1@gmail.com", true, "Name1", "LastName1", false, null, "member1@gmail.com", "member1@gmail.com", "AQAAAAIAAYagAAAAEDrXUzS2ZS7G/+wZXK4o2cSFyaOUjdrADbXRyHnXhXYIy2opMCpqbY0p7Gq1CO6ViQ==", null, false, "", true, false, "member1@gmail.com" },
                    { 2, 0, "HCM", "a8964c5c-4898-4045-8545-bfaf18aaf4c9", "member2@gmail.com", true, "Name2", "LastName2", false, null, "member2@gmail.com", "member2@gmail.com", "AQAAAAIAAYagAAAAEBTMZ+DOv2Snkq/M45xqOu+s7BRDEY7hak2sBcD1RIpEV4M7NuIFnRGKjr7ZOasDdA==", null, false, "", true, false, "member2@gmail.com" },
                    { 3, 0, "HCM", "e407acd9-a93e-4bd5-aaa0-6edb93928bdf", "member3@gmail.com", true, "Name3", "LastName3", false, null, "member3@gmail.com", "member3@gmail.com", "AQAAAAIAAYagAAAAELLX1C8fVrAQbol6x7uBF2FD/NOmCHass43r/+tYO2pere4nDtLBiQMFQV1pQBFs5Q==", null, false, "", true, false, "member3@gmail.com" },
                    { 4, 0, "HCM", "14ebc341-f695-4223-b14e-4ea84705bf63", "member4@gmail.com", true, "Name4", "LastName4", false, null, "member4@gmail.com", "member4@gmail.com", "AQAAAAIAAYagAAAAEEdQPCiRV216q4eoDu4GcL1nZs/cReyRCOHbWZUpRFo6OLq7L06BWc65/x1AyVy6Fw==", null, false, "", true, false, "member4@gmail.com" },
                    { 5, 0, "HCM", "86fa5527-82b4-4fc3-b9d5-205f469b36c2", "member5@gmail.com", true, "Name5", "LastName5", false, null, "member5@gmail.com", "member5@gmail.com", "AQAAAAIAAYagAAAAEDu2Ot0qPvDna/RGGWaFudwMklYEZ/NqSAs6JmYlDwCipAOZQhTZu7VzUjBj7bznJw==", null, false, "", true, false, "member5@gmail.com" },
                    { 6, 0, "HCM", "0f6e4419-edaf-4aa8-a3b2-b715bb7adbd1", "member6@gmail.com", true, "Name6", "LastName6", false, null, "member6@gmail.com", "member6@gmail.com", "AQAAAAIAAYagAAAAELSWWwaycrVBCJxnXMLmiTY7Pui4Mor8PHf+BNEtyAHZIE09+9kiedJS9BtFv/vozQ==", null, false, "", true, false, "member6@gmail.com" },
                    { 7, 0, "HCM", "507f3b73-97b4-46ed-af84-dc51e110a45a", "member7@gmail.com", true, "Name7", "LastName7", false, null, "member7@gmail.com", "member7@gmail.com", "AQAAAAIAAYagAAAAEPlPhHp5PVSKN0cei5Nq4N50R1htULHfALvYjaid0YMgCgHqd8JW6TnXbWLTQGpTpw==", null, false, "", true, false, "member7@gmail.com" },
                    { 8, 0, "HCM", "d377c20a-7fde-4b4b-bc4c-ef38721c1e1b", "member8@gmail.com", true, "Name8", "LastName8", false, null, "member8@gmail.com", "member8@gmail.com", "AQAAAAIAAYagAAAAEA3Zuh2d+9B22fcSYdWkdzO0ljCkRa24odEUqmXF0kXrIRH5rV+oL2vz1VaSt0bqcw==", null, false, "", true, false, "member8@gmail.com" },
                    { 9, 0, "HCM", "935a738f-4e06-4707-919f-56869871a429", "member9@gmail.com", true, "Name9", "LastName9", false, null, "member9@gmail.com", "member9@gmail.com", "AQAAAAIAAYagAAAAEMssRqDENBxv2+PKzkxNXxezvASQky6NFxZ2nW5FL5M1734Jl1JD4P73Ks2pPErIMw==", null, false, "", true, false, "member9@gmail.com" },
                    { 10, 0, "HCM", "694d8fe3-c2bb-480f-a203-5bb5a3508624", "member10@gmail.com", true, "Name10", "LastName10", false, null, "member10@gmail.com", "member10@gmail.com", "AQAAAAIAAYagAAAAEBaHVLDdOaGVjM9hyyoXrZtPmvv23sZYfxYyZFCITa7u8xcRsZt7z+KT6nVLJaCoMQ==", null, false, "", true, false, "member10@gmail.com" },
                    { 11, 0, "HCM", "4e6bd894-7577-48cc-82ce-b0f5a140f6e5", "member11@gmail.com", true, "Name11", "LastName11", false, null, "member11@gmail.com", "member11@gmail.com", "AQAAAAIAAYagAAAAEMyIWQBkjtuieDTPqfWab00pJJWODe0+n6p0XJhrLk5BJ61LRxsJqyR+DSRTINVN3g==", null, false, "", true, false, "member11@gmail.com" },
                    { 12, 0, "HCM", "82a35be5-0e34-474d-baec-6cbf4725f08e", "member12@gmail.com", true, "Name12", "LastName12", false, null, "member12@gmail.com", "member12@gmail.com", "AQAAAAIAAYagAAAAEDAXARGcO8/IPLMtlmABQn/JyPCBmXhCHYI2NZ/vGQ6BSIfA8jht0ZWVPEyda0mx7g==", null, false, "", true, false, "member12@gmail.com" },
                    { 13, 0, "HCM", "bab4b0fb-4e75-42d5-9c68-db1b0d32f78a", "member13@gmail.com", true, "Name13", "LastName13", false, null, "member13@gmail.com", "member13@gmail.com", "AQAAAAIAAYagAAAAEERXT+V/aTr4slEmsxAL4S6IVRksMUb1jLarb/UTNZvb/+geIAEPrpuSczTSGTarTw==", null, false, "", true, false, "member13@gmail.com" },
                    { 14, 0, "HCM", "241d3659-e5a1-451b-8e1d-9f1f91787c01", "member14@gmail.com", true, "Name14", "LastName14", false, null, "member14@gmail.com", "member14@gmail.com", "AQAAAAIAAYagAAAAEGL6LA+ZI2UWO97WTMAeOHfVVPST5pZCWpbEI0A1BD2isBaPyfTy4b4uhJcaVIVSkg==", null, false, "", true, false, "member14@gmail.com" },
                    { 15, 0, "HCM", "36be0f4e-7467-467c-a30f-53e750ec6862", "member15@gmail.com", true, "Name15", "LastName15", false, null, "member15@gmail.com", "member15@gmail.com", "AQAAAAIAAYagAAAAEJvxiDm397shBqnn6m+/A6GYqm/epIiQpVStGOLbYKnvZYRhAxzUiF+kNyQb0do2xA==", null, false, "", true, false, "member15@gmail.com" },
                    { 16, 0, "HCM", "c463c75f-cbd8-4651-89c9-ff6582801280", "member16@gmail.com", true, "Name16", "LastName16", false, null, "member16@gmail.com", "member16@gmail.com", "AQAAAAIAAYagAAAAEC4RgEFqZLEAJv274Bc73Su2dbzcn6jzFpHC8ABOENxgKEceaNplI/It1cy4TaOU0Q==", null, false, "", true, false, "member16@gmail.com" },
                    { 17, 0, "HCM", "27d1168b-3eb1-4a4e-bb25-1655cf944b0c", "member17@gmail.com", true, "Name17", "LastName17", false, null, "member17@gmail.com", "member17@gmail.com", "AQAAAAIAAYagAAAAEHknNOSqF3OpZM639IRdXlaAMT0jfOG2druLVvxWP55r91kOZ6z56ZNmzszBxftTTw==", null, false, "", true, false, "member17@gmail.com" },
                    { 18, 0, "HCM", "8d69007d-afe0-4d83-8411-502ec52a4f6f", "member18@gmail.com", true, "Name18", "LastName18", false, null, "member18@gmail.com", "member18@gmail.com", "AQAAAAIAAYagAAAAEPWLAB9cq+ZduL9oIu1C7mACl0L/04qbt2xt/9zoxTtQAbbAge3dyzmClPEuB4XFpg==", null, false, "", true, false, "member18@gmail.com" },
                    { 19, 0, "HCM", "1281066c-82dd-4cf3-9b8f-0d28a8ff935a", "member19@gmail.com", true, "Name19", "LastName19", false, null, "member19@gmail.com", "member19@gmail.com", "AQAAAAIAAYagAAAAEHZf/ux4BFGpnawSfTofmOb9Fkm2rYRsbXoYCkWjajO4QORm8Tegaq3q0qw5YhoKcQ==", null, false, "", true, false, "member19@gmail.com" },
                    { 20, 0, "HCM", "9d55b2d5-c4ca-4eda-8b6f-c55ea9ced939", "member20@gmail.com", true, "Name20", "LastName20", false, null, "member20@gmail.com", "member20@gmail.com", "AQAAAAIAAYagAAAAEFM4If5vxhIB/HECTWxwHAaIDdfFcJLc9DgGtIO9JV/uzr3CXY8wxf6Ot0XNQPmlZA==", null, false, "", true, false, "member20@gmail.com" },
                    { 21, 0, "HCM", "f60c84f3-7b3c-43c1-9be0-a4a4ad387370", "member21@gmail.com", true, "Name21", "LastName21", false, null, "member21@gmail.com", "member21@gmail.com", "AQAAAAIAAYagAAAAEAcnEhQB/kRhZKbSnRVpwqOlrVhLvvNNKZf95V4qSs7D4cSWJCaRRiyuXdDa/ORAuA==", null, false, "", true, false, "member21@gmail.com" },
                    { 22, 0, "HCM", "479b8fef-41af-44d7-8d52-659be02b3228", "member22@gmail.com", true, "Name22", "LastName22", false, null, "member22@gmail.com", "member22@gmail.com", "AQAAAAIAAYagAAAAELBkUxzlsV1Mn96JFsoortt7/Tgq1xtqgP1IsANOqbhaHCZHjJPA9Gnzde3jz2x2UA==", null, false, "", true, false, "member22@gmail.com" },
                    { 23, 0, "HCM", "c82e8068-cb38-4d6e-a1f9-c8de8114d99c", "member23@gmail.com", true, "Name23", "LastName23", false, null, "member23@gmail.com", "member23@gmail.com", "AQAAAAIAAYagAAAAENzwIlm3L/wnzApmi04TS5/vC7f01VitF6FxIhg9LZARDBJUp2hGZIVslwndJgsQEQ==", null, false, "", true, false, "member23@gmail.com" },
                    { 24, 0, "HCM", "dc71dd8c-e71c-468c-a602-c0dd9312af4d", "member24@gmail.com", true, "Name24", "LastName24", false, null, "member24@gmail.com", "member24@gmail.com", "AQAAAAIAAYagAAAAEM1lCTwlzrP0huCo43vKY0Ip0iLxpk6qJLyghjXWabeBDgfIIp03vzViBj4nWDHEqw==", null, false, "", true, false, "member24@gmail.com" },
                    { 25, 0, "HCM", "b61d0dff-78c9-4ac7-a0e6-599ba17123f4", "member25@gmail.com", true, "Name25", "LastName25", false, null, "member25@gmail.com", "member25@gmail.com", "AQAAAAIAAYagAAAAELUj73LtEplSkoUXoGXn/YJJlDzLVFdYPt2oFpn6UXu3kTh8/0FF5bRl0fekwDgJAQ==", null, false, "", true, false, "member25@gmail.com" },
                    { 26, 0, "HCM", "6d464f1a-b06b-4155-947e-a0ee4e57f8fa", "member26@gmail.com", true, "Name26", "LastName26", false, null, "member26@gmail.com", "member26@gmail.com", "AQAAAAIAAYagAAAAEJIEwvuhTESaAr4Bvc+NuxRsu1gZeVLeXcSmHHkdYEoWZoyU3k4KhcsczUxZiZbNeA==", null, false, "", true, false, "member26@gmail.com" },
                    { 27, 0, "HCM", "ac90ba31-aba2-4784-be11-fc00a5e22248", "member27@gmail.com", true, "Name27", "LastName27", false, null, "member27@gmail.com", "member27@gmail.com", "AQAAAAIAAYagAAAAEN9S8GgVo0ALcPLGD8wXnF/0CY2o5YAqD0S0PSdCtkXgLVgX5XokoNSHBDdp+6lZCQ==", null, false, "", true, false, "member27@gmail.com" },
                    { 28, 0, "HCM", "6196af0d-22be-4e1b-a456-0d433760746b", "member28@gmail.com", true, "Name28", "LastName28", false, null, "member28@gmail.com", "member28@gmail.com", "AQAAAAIAAYagAAAAEPMeSL3t9bfw/AvjgWKB9ygdLoy0gG4vEsEw85yDBVVzzc3vccddDlpt6F0sutSoqA==", null, false, "", true, false, "member28@gmail.com" },
                    { 29, 0, "HCM", "6c18f0ad-3db9-46f6-bbec-843a3ca54bc5", "member29@gmail.com", true, "Name29", "LastName29", false, null, "member29@gmail.com", "member29@gmail.com", "AQAAAAIAAYagAAAAEKRp6bd7RBswxfLmdYx3EUj2tqPJCVbdEQbeblwgqiZpRiooAnmNCLZnbXn7Yv9Fng==", null, false, "", true, false, "member29@gmail.com" },
                    { 30, 0, "HCM", "84e1b928-2f60-4767-8da6-d6d6112ab044", "member30@gmail.com", true, "Name30", "LastName30", false, null, "member30@gmail.com", "member30@gmail.com", "AQAAAAIAAYagAAAAEO7EAaUV2P06XhKaH2A+zWLXnyMUU5/2Z60/QMm6V7kjmNs8svYQbTjTLYhR3Qg9Lg==", null, false, "", true, false, "member30@gmail.com" },
                    { 31, 0, "HCM", "8d0db305-3e04-475e-b002-8077d30f8039", "teacher31@gmail.com", true, "Name31", "LastName31", false, null, "teacher31@gmail.com", "teacher31@gmail.com", "AQAAAAIAAYagAAAAEDvJocu/g3B+Polch19WYVbAJehF9TczMDnOeixr2IewIqZ8VsqwvwwiJpmV7j5lnw==", null, false, "", true, false, "teacher31@gmail.com" },
                    { 32, 0, "HCM", "6c5466c4-1ff8-426c-851c-14719fe819a9", "teacher32@gmail.com", true, "Name32", "LastName32", false, null, "teacher32@gmail.com", "teacher32@gmail.com", "AQAAAAIAAYagAAAAEM6KuurkNzBw7iakSD30uI8yNlnfz449kkGD45xArpdfUBK96ZccjivuG8XAsiSyaQ==", null, false, "", true, false, "teacher32@gmail.com" },
                    { 33, 0, "HCM", "86704686-202b-4470-9917-d72a08657ea1", "teacher33@gmail.com", true, "Name33", "LastName33", false, null, "teacher33@gmail.com", "teacher33@gmail.com", "AQAAAAIAAYagAAAAEJCuvF6FS0o0C25y5ctdc3Qvyvn1EDs8Gcdo0g8lDWpglBPZl0WgqAi7O7eeuoUWFA==", null, false, "", true, false, "teacher33@gmail.com" },
                    { 34, 0, "HCM", "da4f8ae3-5a48-4a64-9521-4d4b68863d65", "teacher34@gmail.com", true, "Name34", "LastName34", false, null, "teacher34@gmail.com", "teacher34@gmail.com", "AQAAAAIAAYagAAAAEESyzYal4SvkffQMbuKDQOoGCExKAJ0n4i3cQk+P/4jhtfH5VoYL2QfY8ADBex+6MQ==", null, false, "", true, false, "teacher34@gmail.com" },
                    { 35, 0, "HCM", "063ffee8-2097-4e3b-a3e0-ee67fe2599ff", "teacher35@gmail.com", true, "Name35", "LastName35", false, null, "teacher35@gmail.com", "teacher35@gmail.com", "AQAAAAIAAYagAAAAEGbqIpDy/YgQfE8XPrdeaPCBrdll5Zy6p9583VlLNil70lYMDEQYx8HDvaMIp9WC4Q==", null, false, "", true, false, "teacher35@gmail.com" },
                    { 36, 0, "HCM", "b79024c9-0312-4e51-8b63-94e558c7aae7", "teacher36@gmail.com", true, "Name36", "LastName36", false, null, "teacher36@gmail.com", "teacher36@gmail.com", "AQAAAAIAAYagAAAAEPQhfum9PkZ4m0ocSWV2e6oVEDzKGi0nQ9BB++sJmwS0mYbkeI/T2yMopzcirZbTMA==", null, false, "", true, false, "teacher36@gmail.com" },
                    { 37, 0, "HCM", "de9266f1-d904-438e-9efd-29ce1bc87930", "teacher37@gmail.com", true, "Name37", "LastName37", false, null, "teacher37@gmail.com", "teacher37@gmail.com", "AQAAAAIAAYagAAAAEMO9rsSANnS0n3MwGevKtzsnLFb8wLQC40HPVbmrbj2o2/zYLe8tyHEpIRvz+8jn1g==", null, false, "", true, false, "teacher37@gmail.com" },
                    { 38, 0, "HCM", "4963e7e1-af33-4ce8-8bc9-c3160835ea5c", "teacher38@gmail.com", true, "Name38", "LastName38", false, null, "teacher38@gmail.com", "teacher38@gmail.com", "AQAAAAIAAYagAAAAEObwLM0oVPB0u8yteJib83WIE4NVJ0i+iq9xVMzEPsB2C6cgblHfTSJxaGYC3HQabQ==", null, false, "", true, false, "teacher38@gmail.com" },
                    { 39, 0, "HCM", "f33469aa-ada8-4068-ba7e-963bf9629547", "teacher39@gmail.com", true, "Name39", "LastName39", false, null, "teacher39@gmail.com", "teacher39@gmail.com", "AQAAAAIAAYagAAAAEFNHtWzWpek/g/Kzk99PEKfQxp0XUA4MsMKE5lAswCg1bNVVvlAodk9nhWIbkaAfPQ==", null, false, "", true, false, "teacher39@gmail.com" },
                    { 40, 0, "HCM", "5087ca15-03ce-4805-9e9d-26ad2e148e9a", "teacher40@gmail.com", true, "Name40", "LastName40", false, null, "teacher40@gmail.com", "teacher40@gmail.com", "AQAAAAIAAYagAAAAEM+qfb8VUmpHlj5Li/PtVD6xm4QMgW9RI0Pnq+xX7UQC24J6178cS8tHLrCApD4i7g==", null, false, "", true, false, "teacher40@gmail.com" },
                    { 41, 0, "HCM", "a0b00c41-4028-487c-a52d-7529b4e29b17", "staff41@gmail.com", true, "Name41", "LastName41", false, null, "staff41@gmail.com", "staff41@gmail.com", "AQAAAAIAAYagAAAAEMbvqd0+II62fvTohnTHuppHUnPNLlYEiaOhMpvGTmOpCX+gisqfJ/bGwxcNUI4YvA==", null, false, "", true, false, "staff41@gmail.com" },
                    { 42, 0, "HCM", "a367f39f-5986-4796-9bca-f41f40881520", "staff42@gmail.com", true, "Name42", "LastName42", false, null, "staff42@gmail.com", "staff42@gmail.com", "AQAAAAIAAYagAAAAEBC6YDdKCmN7QzQ5v5ajEHQWlfhqv3A8Tw38qfOFuV6V2+FL0X/rDJkYgN9TFaUJPA==", null, false, "", true, false, "staff42@gmail.com" },
                    { 43, 0, "HCM", "ae5b3de8-bb2b-4d9c-a5dd-6bbe9707ada7", "staff43@gmail.com", true, "Name43", "LastName43", false, null, "staff43@gmail.com", "staff43@gmail.com", "AQAAAAIAAYagAAAAEJsxHuGJ4Wt5/AjhoMl7GmvY/YJnPPEgTnocgYzeNvA+AwQugNirK9O5zVld2noM2w==", null, false, "", true, false, "staff43@gmail.com" },
                    { 44, 0, "HCM", "666ac693-6c35-4896-83af-aaf11a79cff7", "staff44@gmail.com", true, "Name44", "LastName44", false, null, "staff44@gmail.com", "staff44@gmail.com", "AQAAAAIAAYagAAAAEDR36/62h3Gx3YZ0zLxKM/4TXZQ7pfXnhW5tCX18HLpeE/8fvHptjzApjxOSf+wxaw==", null, false, "", true, false, "staff44@gmail.com" },
                    { 45, 0, "HCM", "703275a4-000f-4005-ab3d-52df2a866e36", "staff45@gmail.com", true, "Name45", "LastName45", false, null, "staff45@gmail.com", "staff45@gmail.com", "AQAAAAIAAYagAAAAEF5C/s/A035EavcYZt8b5c7El03CMPkR1zFTcZ2fhRVM0qKia+L37Al7/a/i3GPRiQ==", null, false, "", true, false, "staff45@gmail.com" },
                    { 46, 0, "HCM", "54764013-50f6-4359-b3c0-ee53278dbfab", "admin46@gmail.com", true, "Name46", "LastName46", false, null, "admin46@gmail.com", "admin46@gmail.com", "AQAAAAIAAYagAAAAEF2bkMghfCEHtyIacOLy9d3GqXxvbOOabng8D/rNvf6eZ2ZXOdWTXpnLZeHcm7vXwA==", null, false, "", true, false, "admin46@gmail.com" }
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
                    { 11, 1, new DateTime(1, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), 101, new DateTime(1, 1, 1, 6, 30, 0, 0, DateTimeKind.Unspecified), true },
                    { 12, 2, new DateTime(1, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), 101, new DateTime(1, 1, 1, 6, 30, 0, 0, DateTimeKind.Unspecified), true },
                    { 13, 3, new DateTime(1, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), 101, new DateTime(1, 1, 1, 6, 30, 0, 0, DateTimeKind.Unspecified), true },
                    { 14, 4, new DateTime(1, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), 101, new DateTime(1, 1, 1, 6, 30, 0, 0, DateTimeKind.Unspecified), true },
                    { 15, 5, new DateTime(1, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), 101, new DateTime(1, 1, 1, 6, 30, 0, 0, DateTimeKind.Unspecified), true },
                    { 16, 6, new DateTime(1, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), 101, new DateTime(1, 1, 1, 6, 30, 0, 0, DateTimeKind.Unspecified), true },
                    { 17, 0, new DateTime(1, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), 101, new DateTime(1, 1, 1, 6, 30, 0, 0, DateTimeKind.Unspecified), true },
                    { 21, 1, new DateTime(1, 1, 1, 10, 30, 0, 0, DateTimeKind.Unspecified), 202, new DateTime(1, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 22, 2, new DateTime(1, 1, 1, 10, 30, 0, 0, DateTimeKind.Unspecified), 202, new DateTime(1, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 23, 3, new DateTime(1, 1, 1, 10, 30, 0, 0, DateTimeKind.Unspecified), 202, new DateTime(1, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 24, 4, new DateTime(1, 1, 1, 10, 30, 0, 0, DateTimeKind.Unspecified), 202, new DateTime(1, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 25, 5, new DateTime(1, 1, 1, 10, 30, 0, 0, DateTimeKind.Unspecified), 202, new DateTime(1, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 26, 6, new DateTime(1, 1, 1, 10, 30, 0, 0, DateTimeKind.Unspecified), 202, new DateTime(1, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 27, 0, new DateTime(1, 1, 1, 10, 30, 0, 0, DateTimeKind.Unspecified), 202, new DateTime(1, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 31, 1, new DateTime(1, 1, 1, 16, 30, 0, 0, DateTimeKind.Unspecified), 303, new DateTime(1, 1, 1, 15, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 32, 2, new DateTime(1, 1, 1, 16, 30, 0, 0, DateTimeKind.Unspecified), 303, new DateTime(1, 1, 1, 15, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 33, 3, new DateTime(1, 1, 1, 16, 30, 0, 0, DateTimeKind.Unspecified), 303, new DateTime(1, 1, 1, 15, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 34, 4, new DateTime(1, 1, 1, 16, 30, 0, 0, DateTimeKind.Unspecified), 303, new DateTime(1, 1, 1, 15, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 35, 5, new DateTime(1, 1, 1, 16, 30, 0, 0, DateTimeKind.Unspecified), 303, new DateTime(1, 1, 1, 15, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 36, 6, new DateTime(1, 1, 1, 16, 30, 0, 0, DateTimeKind.Unspecified), 303, new DateTime(1, 1, 1, 15, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 37, 0, new DateTime(1, 1, 1, 16, 30, 0, 0, DateTimeKind.Unspecified), 303, new DateTime(1, 1, 1, 15, 0, 0, 0, DateTimeKind.Unspecified), true }
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
                    { 1, 1, "Yoga course number 1", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course1", 100.0, new DateTime(2023, 6, 26, 23, 1, 1, 47, DateTimeKind.Local).AddTicks(4191) },
                    { 2, 2, "Yoga course number 2", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course2", 200.0, new DateTime(2023, 6, 26, 23, 1, 1, 47, DateTimeKind.Local).AddTicks(4212) },
                    { 3, 3, "Yoga course number 3", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course3", 300.0, new DateTime(2023, 6, 26, 23, 1, 1, 47, DateTimeKind.Local).AddTicks(4215) },
                    { 4, 4, "Yoga course number 4", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course4", 400.0, new DateTime(2023, 6, 26, 23, 1, 1, 47, DateTimeKind.Local).AddTicks(4219) },
                    { 5, 5, "Yoga course number 5", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course5", 500.0, new DateTime(2023, 6, 26, 23, 1, 1, 47, DateTimeKind.Local).AddTicks(4223) },
                    { 6, 6, "Yoga course number 6", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course6", 600.0, new DateTime(2023, 6, 26, 23, 1, 1, 47, DateTimeKind.Local).AddTicks(4227) },
                    { 7, 7, "Yoga course number 7", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course7", 700.0, new DateTime(2023, 6, 26, 23, 1, 1, 47, DateTimeKind.Local).AddTicks(4388) },
                    { 8, 8, "Yoga course number 8", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course8", 800.0, new DateTime(2023, 6, 26, 23, 1, 1, 47, DateTimeKind.Local).AddTicks(4393) },
                    { 9, 9, "Yoga course number 9", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course9", 900.0, new DateTime(2023, 6, 26, 23, 1, 1, 47, DateTimeKind.Local).AddTicks(4396) },
                    { 10, 10, "Yoga course number 10", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course10", 1000.0, new DateTime(2023, 6, 26, 23, 1, 1, 47, DateTimeKind.Local).AddTicks(4400) }
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
