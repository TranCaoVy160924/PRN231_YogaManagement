using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YogaManagement.Database.Migrations
{
    /// <inheritdoc />
    public partial class inti : Migration
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
                    { 1, 0, "HCM", "66b5924d-47d2-4fc5-8864-3e39bc1bf7d9", "member1@gmail.com", true, "Name1", "LastName1", false, null, "member1@gmail.com", "member1@gmail.com", "AQAAAAIAAYagAAAAEFU8vtPCt4OTa3DTPwsfnGs0UeeFIkz/hA7rMlK/o4vYwIE3IeuPNGwmG3DPxKgmkQ==", null, false, "", true, false, "member1@gmail.com" },
                    { 2, 0, "HCM", "5f63c4db-8be5-4f42-a50f-01c86b173978", "member2@gmail.com", true, "Name2", "LastName2", false, null, "member2@gmail.com", "member2@gmail.com", "AQAAAAIAAYagAAAAEPftqgG0nhbsCRkLyAc7i4QtBOwC9FsH9zAAOSKFwud4NexhqxX4RQPAGIeBF19hRg==", null, false, "", true, false, "member2@gmail.com" },
                    { 3, 0, "HCM", "973a6833-7299-4ef6-9252-18360007ef01", "member3@gmail.com", true, "Name3", "LastName3", false, null, "member3@gmail.com", "member3@gmail.com", "AQAAAAIAAYagAAAAEDXIHHl62Cv7eJZ7o3ufa3Zda1Rf0kuN3rel7eHTAgwC69EZgr4GdxFh+vAC5plUvQ==", null, false, "", true, false, "member3@gmail.com" },
                    { 4, 0, "HCM", "c71868b2-4cbe-4574-993d-961b5f07ac5c", "member4@gmail.com", true, "Name4", "LastName4", false, null, "member4@gmail.com", "member4@gmail.com", "AQAAAAIAAYagAAAAEKXIBDvUL1LnZKsZ3TlNuFtMeXt9Z7yJkKxBbsgDAFm0Y/RkTA/bj1wDD3IhtsXYIQ==", null, false, "", true, false, "member4@gmail.com" },
                    { 5, 0, "HCM", "858d8246-1494-4709-8c48-49729b71da64", "member5@gmail.com", true, "Name5", "LastName5", false, null, "member5@gmail.com", "member5@gmail.com", "AQAAAAIAAYagAAAAEJ0scvHzPMSLs2IvH637luLYa9W66Cy5axDaNklRi4ccUiKp7WvCbUVka/NtjMfyCA==", null, false, "", true, false, "member5@gmail.com" },
                    { 6, 0, "HCM", "c1e67145-f589-44d6-886a-1cac3b5037db", "member6@gmail.com", true, "Name6", "LastName6", false, null, "member6@gmail.com", "member6@gmail.com", "AQAAAAIAAYagAAAAELnl/quC152KdgiWVTVMvCmDMOP1PmEZJWvfHRQc8c3YAo2Z94VlIv4atFobsE1U2w==", null, false, "", true, false, "member6@gmail.com" },
                    { 7, 0, "HCM", "2229f45c-48cc-4f10-b5df-608dc0cf6183", "member7@gmail.com", true, "Name7", "LastName7", false, null, "member7@gmail.com", "member7@gmail.com", "AQAAAAIAAYagAAAAEAU1eB8JiXTcjkb8hM/O38XSZ6nnNS/Qnk0AGASJK/wtNFH33PJCVEQCeeEXpPjLiQ==", null, false, "", true, false, "member7@gmail.com" },
                    { 8, 0, "HCM", "c283ef8d-c64d-43da-9f52-9329670f1557", "member8@gmail.com", true, "Name8", "LastName8", false, null, "member8@gmail.com", "member8@gmail.com", "AQAAAAIAAYagAAAAEIIaIdHefAotw5vPnKetEbDTuJhiJP8F5xek4Yqsb+N+cQu0YHFwUaFNANeD3Ofb0g==", null, false, "", true, false, "member8@gmail.com" },
                    { 9, 0, "HCM", "9cbbef21-69ba-4d3e-9414-819ce9c699f4", "member9@gmail.com", true, "Name9", "LastName9", false, null, "member9@gmail.com", "member9@gmail.com", "AQAAAAIAAYagAAAAEOgBL/c97rYOco0zXXnk46R6whSZRinVw+ZnKrBlaFZUtEyg0NjvU3JIEFCny1k54g==", null, false, "", true, false, "member9@gmail.com" },
                    { 10, 0, "HCM", "a28c87f1-89cd-40dd-adbc-242f238c4ca6", "member10@gmail.com", true, "Name10", "LastName10", false, null, "member10@gmail.com", "member10@gmail.com", "AQAAAAIAAYagAAAAEDNHXdsaWmjIer3yfsxKhlr9I6M0rhuLlOa11coKi+gL58rlkkHg+sIMyu5N56dHYg==", null, false, "", true, false, "member10@gmail.com" },
                    { 11, 0, "HCM", "2e7451cb-b6f9-440e-b01f-bb79b2e219c7", "member11@gmail.com", true, "Name11", "LastName11", false, null, "member11@gmail.com", "member11@gmail.com", "AQAAAAIAAYagAAAAEFFkceBdBcmSXSzmtTkMUPZxjjT3krP2+PIIH6pQAtNtyKX9WuV2qOrl0eAYdusxVA==", null, false, "", true, false, "member11@gmail.com" },
                    { 12, 0, "HCM", "cc65cbc8-3940-4960-a02c-b08c5b1b7cf7", "member12@gmail.com", true, "Name12", "LastName12", false, null, "member12@gmail.com", "member12@gmail.com", "AQAAAAIAAYagAAAAEHOIYaTK+vt+6ERScIcvMwEmjP6Icqs4QssGGpVAmGGCk+WOdVvb9gLd1QmsTtyzlA==", null, false, "", true, false, "member12@gmail.com" },
                    { 13, 0, "HCM", "c3b84919-3ae0-4946-a82c-4c465a07d33b", "member13@gmail.com", true, "Name13", "LastName13", false, null, "member13@gmail.com", "member13@gmail.com", "AQAAAAIAAYagAAAAEFbsfkZZ30uSyzc/CeCJUXNrOUww7PGcrg2WPgnJLcdUF3fk8v1ikwkzUMSTV6R9VA==", null, false, "", true, false, "member13@gmail.com" },
                    { 14, 0, "HCM", "b811296b-c6f8-4fdc-8087-dacd5b4463fb", "member14@gmail.com", true, "Name14", "LastName14", false, null, "member14@gmail.com", "member14@gmail.com", "AQAAAAIAAYagAAAAEAi7IjttkHOuZs9UlDptOLMFHtSFdWLXZptywOKnklkZXeuGQ+9Gmq9tWQOWfJ0Pdw==", null, false, "", true, false, "member14@gmail.com" },
                    { 15, 0, "HCM", "8d7925a1-469f-4b59-9856-6a92b5c1acdd", "member15@gmail.com", true, "Name15", "LastName15", false, null, "member15@gmail.com", "member15@gmail.com", "AQAAAAIAAYagAAAAEOdkR69Ac42DX3V+c58nCOlQfPgt5e+xgZ6Mj7g/UKYAhjw6WE9KYERyat8hg+A2sA==", null, false, "", true, false, "member15@gmail.com" },
                    { 16, 0, "HCM", "e3a3eb02-0e28-417f-937a-39a6055f00f1", "member16@gmail.com", true, "Name16", "LastName16", false, null, "member16@gmail.com", "member16@gmail.com", "AQAAAAIAAYagAAAAEAXtvAwR2u5rxPmFO0j5+RjEJmpFD1VQViEy+tTMZ5C4LTFF1kEkOGLkaruea25Ofw==", null, false, "", true, false, "member16@gmail.com" },
                    { 17, 0, "HCM", "13c527b9-8626-43e9-8a0c-0e5efbddddd6", "member17@gmail.com", true, "Name17", "LastName17", false, null, "member17@gmail.com", "member17@gmail.com", "AQAAAAIAAYagAAAAEPR/7mEA7CEIqwznQHtXayPnMlsWsIeL+Y+2LACgZwEwQMVXJNpKULfmaA/8RPLD9Q==", null, false, "", true, false, "member17@gmail.com" },
                    { 18, 0, "HCM", "8d10cbe9-3b12-40f4-82dd-70ced8e61863", "member18@gmail.com", true, "Name18", "LastName18", false, null, "member18@gmail.com", "member18@gmail.com", "AQAAAAIAAYagAAAAEMtIJ9LJay2sxy6EDGVvUmTxs78u3idwQTCbRUg/XpGfASBCACeCqnVHTID+eoxSZw==", null, false, "", true, false, "member18@gmail.com" },
                    { 19, 0, "HCM", "b8ce13d5-c954-473a-9c05-a961cfb0af62", "member19@gmail.com", true, "Name19", "LastName19", false, null, "member19@gmail.com", "member19@gmail.com", "AQAAAAIAAYagAAAAEPha9/4ClhtVt4aXeDJwJ4I40fems5S8RYRRfygS9ShDTAhKdeBMGAsOISC+WCnfMw==", null, false, "", true, false, "member19@gmail.com" },
                    { 20, 0, "HCM", "23438368-7ee9-40ba-9487-ffac9d9df5ab", "member20@gmail.com", true, "Name20", "LastName20", false, null, "member20@gmail.com", "member20@gmail.com", "AQAAAAIAAYagAAAAEOv2jPCodUg4wNDDVr0eV7oGEyiXSutE7Pbli/ZM6qKwKBzJErZMqQvxUwZptVr4ag==", null, false, "", true, false, "member20@gmail.com" },
                    { 21, 0, "HCM", "0acdba3e-296a-4d66-8778-57d2045e1ecc", "member21@gmail.com", true, "Name21", "LastName21", false, null, "member21@gmail.com", "member21@gmail.com", "AQAAAAIAAYagAAAAEC0+VU1en7I+lsMLmD/OJZgyGbFXVi+4GUn63EC5VW+h0NFI5ZsnTGrYNJArLA9erQ==", null, false, "", true, false, "member21@gmail.com" },
                    { 22, 0, "HCM", "7d997ee2-9b6e-4b77-90cb-b661b77662a3", "member22@gmail.com", true, "Name22", "LastName22", false, null, "member22@gmail.com", "member22@gmail.com", "AQAAAAIAAYagAAAAEKgOVXL+WYqtTEAOkxZm3GUCdpzKgiH7ImO7Hc2SrgU4d+a5VnPD/Xf9pr2B2dWuMg==", null, false, "", true, false, "member22@gmail.com" },
                    { 23, 0, "HCM", "1a0a7035-6e86-4bad-8799-71f450449a4f", "member23@gmail.com", true, "Name23", "LastName23", false, null, "member23@gmail.com", "member23@gmail.com", "AQAAAAIAAYagAAAAELG9pK2R/bfxO1kH6Pmd6dLwLac+Fb0Q2TKGcPmAhGlNkJ9kaos/FTexjmTr6xG82w==", null, false, "", true, false, "member23@gmail.com" },
                    { 24, 0, "HCM", "91f5a8c8-b7b5-47b9-9dc3-e4c06d58eb01", "member24@gmail.com", true, "Name24", "LastName24", false, null, "member24@gmail.com", "member24@gmail.com", "AQAAAAIAAYagAAAAEHmuCBeuksHG5c8T+Or3N1eKSxBSSEQwlgPOq2wTx4b/MZwMCYciTN2RBbb2irfl3w==", null, false, "", true, false, "member24@gmail.com" },
                    { 25, 0, "HCM", "375a25a1-ccd2-4461-bcb0-d5e537cac1c1", "member25@gmail.com", true, "Name25", "LastName25", false, null, "member25@gmail.com", "member25@gmail.com", "AQAAAAIAAYagAAAAEIqDumpYpDpTYXlDaGkh331lDJ8vD+KrkY156fhAH/qt0hOQ1PKnaBZKvaH1l5oyMA==", null, false, "", true, false, "member25@gmail.com" },
                    { 26, 0, "HCM", "efdb1fef-a6cf-42d4-918a-b00031a95c8e", "member26@gmail.com", true, "Name26", "LastName26", false, null, "member26@gmail.com", "member26@gmail.com", "AQAAAAIAAYagAAAAEOUP6wc79CbjD42yNh2pAG7T11DBgiRNQeUIG9JWAlJ4D6czU53wBe+Tr2Fj322nAA==", null, false, "", true, false, "member26@gmail.com" },
                    { 27, 0, "HCM", "e585ca09-0e18-4f70-b7a6-759e893d619a", "member27@gmail.com", true, "Name27", "LastName27", false, null, "member27@gmail.com", "member27@gmail.com", "AQAAAAIAAYagAAAAEMzzJzEXafZY/rJCKyNNfHgqf9D+2vWfAr0wplT0cOc/IzxFiob1cqkSgILpGFnk+w==", null, false, "", true, false, "member27@gmail.com" },
                    { 28, 0, "HCM", "9bdf70df-cd08-4845-ace6-f18b9688f6dc", "member28@gmail.com", true, "Name28", "LastName28", false, null, "member28@gmail.com", "member28@gmail.com", "AQAAAAIAAYagAAAAEI/2zzZuzLhSJrPMV718PdfTI3ZF6VPIMwU0HMKxvbH+NPLmsxrTI5i71PAbOPk2Jg==", null, false, "", true, false, "member28@gmail.com" },
                    { 29, 0, "HCM", "ac4ff436-53f0-4738-9521-39b16d2c4a0a", "member29@gmail.com", true, "Name29", "LastName29", false, null, "member29@gmail.com", "member29@gmail.com", "AQAAAAIAAYagAAAAEJHUcvMGW+x8gbBDxnTbi2ObB4+Hq7UBbgofFA1ZTqpbb55eMnU9YcT5Pwe7LiK2VA==", null, false, "", true, false, "member29@gmail.com" },
                    { 30, 0, "HCM", "0df2a8b8-2aa4-4c22-8af1-b1bbe54482a6", "member30@gmail.com", true, "Name30", "LastName30", false, null, "member30@gmail.com", "member30@gmail.com", "AQAAAAIAAYagAAAAEJ1uq9JYnLlcvNjBuMZk6SN3vSH/tHEMj7vCk4hwxjyUSLz9EcbDYHi58dYNipR6iA==", null, false, "", true, false, "member30@gmail.com" },
                    { 31, 0, "HCM", "743a825d-5c6b-45f5-a446-0279aef6c14e", "teacher31@gmail.com", true, "Name31", "LastName31", false, null, "teacher31@gmail.com", "teacher31@gmail.com", "AQAAAAIAAYagAAAAELDUfuXhOWBBYp2tjWPsVrFSxQrLBwWVbruSl/X91eJT6id512p9oliuVvr9uyEoxw==", null, false, "", true, false, "teacher31@gmail.com" },
                    { 32, 0, "HCM", "ea32d1a7-b029-414c-a87c-517e46cfa3f9", "teacher32@gmail.com", true, "Name32", "LastName32", false, null, "teacher32@gmail.com", "teacher32@gmail.com", "AQAAAAIAAYagAAAAEC6Bi3mgTQBVIScejZuELe0jwY3QLnL8KGUunTf6bL3ggBsqouBO2C0ICO2JZ4Z4Iw==", null, false, "", true, false, "teacher32@gmail.com" },
                    { 33, 0, "HCM", "a3506262-53b4-40f1-85bb-1da5e6e73ebd", "teacher33@gmail.com", true, "Name33", "LastName33", false, null, "teacher33@gmail.com", "teacher33@gmail.com", "AQAAAAIAAYagAAAAEFLicXMKE8j82pK61O6Fn0NRdPCxQ1rqL7og9r8X6DHyiX9495VAIzvt0prxkGxblg==", null, false, "", true, false, "teacher33@gmail.com" },
                    { 34, 0, "HCM", "b7886391-da88-4f34-8c35-4e63ee0ebc44", "teacher34@gmail.com", true, "Name34", "LastName34", false, null, "teacher34@gmail.com", "teacher34@gmail.com", "AQAAAAIAAYagAAAAEJsQGxuLm8FIDcrvunOeQzYvw199b3ykiz8T9gIanyPuCrXwqcdWCHws739G0KlPHQ==", null, false, "", true, false, "teacher34@gmail.com" },
                    { 35, 0, "HCM", "07488d3a-05be-4610-9792-a50cd68ff9e4", "teacher35@gmail.com", true, "Name35", "LastName35", false, null, "teacher35@gmail.com", "teacher35@gmail.com", "AQAAAAIAAYagAAAAEGhfjcXT3yQFVUTdUrjMdPZItsjDw5UFLNMRFoMiHTpG2ko1JVYTSBJJSHu7GPJ+7w==", null, false, "", true, false, "teacher35@gmail.com" },
                    { 36, 0, "HCM", "5dab55fb-f8fd-48e1-9544-6aafa4e091eb", "teacher36@gmail.com", true, "Name36", "LastName36", false, null, "teacher36@gmail.com", "teacher36@gmail.com", "AQAAAAIAAYagAAAAEKvd8z13G97E6GsjRfzM4zuyGBSMc4clDSq76bxg4Ua0FhU2D1cDxXiNzg+TYoDmYQ==", null, false, "", true, false, "teacher36@gmail.com" },
                    { 37, 0, "HCM", "2d09d0c5-6c79-4e8f-9442-2fbe04efc8c3", "teacher37@gmail.com", true, "Name37", "LastName37", false, null, "teacher37@gmail.com", "teacher37@gmail.com", "AQAAAAIAAYagAAAAEJloZ75cx0cGMt42XsJFg7zQDavW4akuzlQMVPm2+3CrHj8SYHTks1gpJv+ktmPpsA==", null, false, "", true, false, "teacher37@gmail.com" },
                    { 38, 0, "HCM", "5591bd48-abdb-4d07-bf12-8cdf881f4437", "teacher38@gmail.com", true, "Name38", "LastName38", false, null, "teacher38@gmail.com", "teacher38@gmail.com", "AQAAAAIAAYagAAAAEIkcegoe7h8jogw1nXoeOh5FR+BWKc+Mg+TGso1LutoG19UHAQnnEiuXf46xmRpE9w==", null, false, "", true, false, "teacher38@gmail.com" },
                    { 39, 0, "HCM", "144a9842-5305-4c7f-8b98-276336a725c8", "teacher39@gmail.com", true, "Name39", "LastName39", false, null, "teacher39@gmail.com", "teacher39@gmail.com", "AQAAAAIAAYagAAAAEO3oy7qjTLrC9cfNqXOirTCi/JN+jM/46bZNYgqZry+QzfjBoCg8ERRrPaNVlP82gg==", null, false, "", true, false, "teacher39@gmail.com" },
                    { 40, 0, "HCM", "0c280a45-4868-4697-ad93-36a68a5a5d68", "teacher40@gmail.com", true, "Name40", "LastName40", false, null, "teacher40@gmail.com", "teacher40@gmail.com", "AQAAAAIAAYagAAAAEClyKZbXLzxONuZsKXBP1pMj9lLbgTa0vOZqLSoaRfSWw4ZuDUpP7mrOTk6+7m7eJw==", null, false, "", true, false, "teacher40@gmail.com" },
                    { 41, 0, "HCM", "af2752d6-c57c-4be3-aafa-ee4464a1439d", "staff41@gmail.com", true, "Name41", "LastName41", false, null, "staff41@gmail.com", "staff41@gmail.com", "AQAAAAIAAYagAAAAEEf71KdeFZoNo719OTTux5Fz+WvoTadN205N07Cc4+JcidEBd4VSJozCZ1fukRD56w==", null, false, "", true, false, "staff41@gmail.com" },
                    { 42, 0, "HCM", "73e3f15b-2f2e-4979-8839-8ce766767f69", "staff42@gmail.com", true, "Name42", "LastName42", false, null, "staff42@gmail.com", "staff42@gmail.com", "AQAAAAIAAYagAAAAEG0zKX0GR5bkSYPgH+H/y55s0+Y6MFxGxwH001vZ62/5paP1vDlNNtDAozPyclDrbA==", null, false, "", true, false, "staff42@gmail.com" },
                    { 43, 0, "HCM", "279b7636-f32d-4f3f-9360-50d471c51806", "staff43@gmail.com", true, "Name43", "LastName43", false, null, "staff43@gmail.com", "staff43@gmail.com", "AQAAAAIAAYagAAAAEK1QDM0Kn/GUPnVZo4PohJ9pUKDL6VRzTOT0d2km8cQ94JNBA+GI6Wj1L3fsYQCRCg==", null, false, "", true, false, "staff43@gmail.com" },
                    { 44, 0, "HCM", "7b8a1d68-ee9c-4193-a4bc-32bbe42b787f", "staff44@gmail.com", true, "Name44", "LastName44", false, null, "staff44@gmail.com", "staff44@gmail.com", "AQAAAAIAAYagAAAAELLKkqK56Z/qfhyd5wx7D+TBXBC4z6TFf6PBkTTGyd1qqs0GtdonJI9rN9PGfV8Q1w==", null, false, "", true, false, "staff44@gmail.com" },
                    { 45, 0, "HCM", "1abb60b5-e06d-4b64-a92b-467cae0aca89", "staff45@gmail.com", true, "Name45", "LastName45", false, null, "staff45@gmail.com", "staff45@gmail.com", "AQAAAAIAAYagAAAAEGvZKnvw7S0mo52Mw7cKgCEm8OZOB0koY3aTMrYFWHZoixBTeMk69fvkf+7AxhR3Iw==", null, false, "", true, false, "staff45@gmail.com" },
                    { 46, 0, "HCM", "b1821535-a63e-41e9-acbe-f19c25ecbebb", "admin46@gmail.com", true, "Name46", "LastName46", false, null, "admin46@gmail.com", "admin46@gmail.com", "AQAAAAIAAYagAAAAED9hWNY+44HL7h60I6YcXyagOEryMQ+xUqLdhDbeOXSsx61LaAngqlula/KvaH+WBQ==", null, false, "", true, false, "admin46@gmail.com" }
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
                    { 1, 1, "Yoga course number 1", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course1", 100.0, new DateTime(2023, 6, 26, 17, 14, 49, 672, DateTimeKind.Local).AddTicks(5961) },
                    { 2, 2, "Yoga course number 2", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course2", 200.0, new DateTime(2023, 6, 26, 17, 14, 49, 672, DateTimeKind.Local).AddTicks(5998) },
                    { 3, 3, "Yoga course number 3", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course3", 300.0, new DateTime(2023, 6, 26, 17, 14, 49, 672, DateTimeKind.Local).AddTicks(6007) },
                    { 4, 4, "Yoga course number 4", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course4", 400.0, new DateTime(2023, 6, 26, 17, 14, 49, 672, DateTimeKind.Local).AddTicks(6013) },
                    { 5, 5, "Yoga course number 5", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course5", 500.0, new DateTime(2023, 6, 26, 17, 14, 49, 672, DateTimeKind.Local).AddTicks(6018) },
                    { 6, 6, "Yoga course number 6", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course6", 600.0, new DateTime(2023, 6, 26, 17, 14, 49, 672, DateTimeKind.Local).AddTicks(6025) },
                    { 7, 7, "Yoga course number 7", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course7", 700.0, new DateTime(2023, 6, 26, 17, 14, 49, 672, DateTimeKind.Local).AddTicks(6031) },
                    { 8, 8, "Yoga course number 8", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course8", 800.0, new DateTime(2023, 6, 26, 17, 14, 49, 672, DateTimeKind.Local).AddTicks(6037) },
                    { 9, 9, "Yoga course number 9", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course9", 900.0, new DateTime(2023, 6, 26, 17, 14, 49, 672, DateTimeKind.Local).AddTicks(6043) },
                    { 10, 10, "Yoga course number 10", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course10", 1000.0, new DateTime(2023, 6, 26, 17, 14, 49, 672, DateTimeKind.Local).AddTicks(6172) }
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
