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
                    { 1, 0, "HCM", "cc8f2029-a8d2-49dd-baa2-d9ea9adc1c91", "member1@gmail.com", true, "Name1", "LastName1", false, null, "member1@gmail.com", "member1@gmail.com", "AQAAAAIAAYagAAAAEEx4mjnsd8FZpuL3L/WrSmd+j7tgWZMGbSBKoqO+0jBoILm0/76LJsW7cfLm7PavrQ==", null, false, "", true, false, "member1@gmail.com" },
                    { 2, 0, "HCM", "b865cec4-d28f-4bd0-8a2b-55d337bb568a", "member2@gmail.com", true, "Name2", "LastName2", false, null, "member2@gmail.com", "member2@gmail.com", "AQAAAAIAAYagAAAAEBYDs64VuruKvyhxRhuqmRMHxSFyueeSg8gc1KyYSMuQBCrdAivYjs9ZKXBaj/JylA==", null, false, "", true, false, "member2@gmail.com" },
                    { 3, 0, "HCM", "7eceddd2-3022-4106-9cc8-de81115d1314", "member3@gmail.com", true, "Name3", "LastName3", false, null, "member3@gmail.com", "member3@gmail.com", "AQAAAAIAAYagAAAAEJvu+DXxuNXDkZH6SQw68Cx6diMjQEJLSYOxvA7+EBQDG7gZ4EY3k2LLPc2R8gk4lw==", null, false, "", true, false, "member3@gmail.com" },
                    { 4, 0, "HCM", "62536042-dfe8-41f8-89bc-b6cbc98bffce", "member4@gmail.com", true, "Name4", "LastName4", false, null, "member4@gmail.com", "member4@gmail.com", "AQAAAAIAAYagAAAAEI7ZBpdW1dBGCXVW/+H7kFCoAOqPnU9hGfWAw2C3+xRRE8+JlC31TpSLYR3PrNPr/Q==", null, false, "", true, false, "member4@gmail.com" },
                    { 5, 0, "HCM", "42a171bb-a623-44e9-b729-14a4df911d48", "member5@gmail.com", true, "Name5", "LastName5", false, null, "member5@gmail.com", "member5@gmail.com", "AQAAAAIAAYagAAAAEN4DhELoXbVcl5UwqMHPoC9nm5S6WTCMDd8xW2syqGrZ8u0HRdR6i+tFMDhLa+f2KA==", null, false, "", true, false, "member5@gmail.com" },
                    { 6, 0, "HCM", "8d4dd902-e5b0-4110-beee-57948f49cd8f", "member6@gmail.com", true, "Name6", "LastName6", false, null, "member6@gmail.com", "member6@gmail.com", "AQAAAAIAAYagAAAAEB1L2lTM+ATgQWA9OH97BcW9Mr2iVUME4CBMm+71Ydp0a/Hd2Ph/D/JkKyjbIv2v7w==", null, false, "", true, false, "member6@gmail.com" },
                    { 7, 0, "HCM", "965c75f3-2dd8-48c4-bb78-2f456ac33244", "member7@gmail.com", true, "Name7", "LastName7", false, null, "member7@gmail.com", "member7@gmail.com", "AQAAAAIAAYagAAAAEDIZkyagSyHTPbzZwHnTXRgOb6gSIsHJsf4j+XQ1tTuspRX2KOixpCJZCnXY2jNtbQ==", null, false, "", true, false, "member7@gmail.com" },
                    { 8, 0, "HCM", "aab83e8e-3720-4012-a76c-8949a48f1b25", "member8@gmail.com", true, "Name8", "LastName8", false, null, "member8@gmail.com", "member8@gmail.com", "AQAAAAIAAYagAAAAEFvsTj9Nh0A5uLCiXVShue1MPksZfiVsj52eo8e95R47091s/C1i6FJ/Rn/IpAEglA==", null, false, "", true, false, "member8@gmail.com" },
                    { 9, 0, "HCM", "dbdc010d-a367-4ae1-a3ea-05595db171b4", "member9@gmail.com", true, "Name9", "LastName9", false, null, "member9@gmail.com", "member9@gmail.com", "AQAAAAIAAYagAAAAENAJ9zHcxDJnccV/3CjGpqP7p70r/ScqtgUosM3NJfICKHAA7prsremLvJAWFXJbFQ==", null, false, "", true, false, "member9@gmail.com" },
                    { 10, 0, "HCM", "560e5f59-b7c1-430c-a1b8-3a1f07f12ba6", "member10@gmail.com", true, "Name10", "LastName10", false, null, "member10@gmail.com", "member10@gmail.com", "AQAAAAIAAYagAAAAEANSSmOIsHOkA2sRQ7NX8FnyBTzTzRqjcWy40EHXhVP03cDapFnTtGbPPfMk9wznIQ==", null, false, "", true, false, "member10@gmail.com" },
                    { 11, 0, "HCM", "69246b46-26e0-4071-b4ee-62ab26bd6437", "member11@gmail.com", true, "Name11", "LastName11", false, null, "member11@gmail.com", "member11@gmail.com", "AQAAAAIAAYagAAAAED5BOoh9gh2RjsXrudBezq1JulGU8kh7Udf2FrIpUFd2dPW1oelvJgXshD5MCWlJ4A==", null, false, "", true, false, "member11@gmail.com" },
                    { 12, 0, "HCM", "895cede5-74f0-423e-95f8-4ae7a58daf83", "member12@gmail.com", true, "Name12", "LastName12", false, null, "member12@gmail.com", "member12@gmail.com", "AQAAAAIAAYagAAAAEAwqHEe4BWaIP7dhnDDCN4NYsueqvcc3hk5ka+AsMW3N4UVplgFDbCLIXk6BTjwmhw==", null, false, "", true, false, "member12@gmail.com" },
                    { 13, 0, "HCM", "8422d426-61e5-4593-ae71-07bf056e5c4f", "member13@gmail.com", true, "Name13", "LastName13", false, null, "member13@gmail.com", "member13@gmail.com", "AQAAAAIAAYagAAAAEDqf8MMk+bRRImOQl+IC+qBUZVyeEnCr85JbgIcXsXiWaCDZ2O6523S7orD4caBHFg==", null, false, "", true, false, "member13@gmail.com" },
                    { 14, 0, "HCM", "eccad797-05ab-48ca-97f6-3f2bdf6633f0", "member14@gmail.com", true, "Name14", "LastName14", false, null, "member14@gmail.com", "member14@gmail.com", "AQAAAAIAAYagAAAAEP3EhfGhZ5Pqw0nF/fIaMSxe5tp8r98n/UtuMTDFZEr7lwJ1GgsyWW6Nvvxw5/81Nw==", null, false, "", true, false, "member14@gmail.com" },
                    { 15, 0, "HCM", "7ee6e075-733d-40a0-8b61-1715197dfe01", "member15@gmail.com", true, "Name15", "LastName15", false, null, "member15@gmail.com", "member15@gmail.com", "AQAAAAIAAYagAAAAEEDlGV2WCWAuDP500+o1BUKQQQObayYZTUdTIwPAPsaMekRhwqBaaykkIMgg83E8ig==", null, false, "", true, false, "member15@gmail.com" },
                    { 16, 0, "HCM", "f5ea3a45-5528-46c2-b216-78b7aa0a5052", "member16@gmail.com", true, "Name16", "LastName16", false, null, "member16@gmail.com", "member16@gmail.com", "AQAAAAIAAYagAAAAEGGUvo/zBfhebShRoS60DI1P3g3MlfVMYwx+AOxlz6bMk7L+AHIzedOxBvSb465dbg==", null, false, "", true, false, "member16@gmail.com" },
                    { 17, 0, "HCM", "b58bf21c-536e-47e7-a992-6b16e67be131", "member17@gmail.com", true, "Name17", "LastName17", false, null, "member17@gmail.com", "member17@gmail.com", "AQAAAAIAAYagAAAAEEm50jOpqLWlEjo/HsBkiSzMz7A1kDGvf9J8lOlRPwe7oFpiReOsTuMyJvdWm9dwCw==", null, false, "", true, false, "member17@gmail.com" },
                    { 18, 0, "HCM", "9245d8cf-18fb-4590-8f22-83e8952ba660", "member18@gmail.com", true, "Name18", "LastName18", false, null, "member18@gmail.com", "member18@gmail.com", "AQAAAAIAAYagAAAAECSC/T75VQkgOgulJvoLUUclcC0fUdIDRME9cJx88lcbDeJx/jnV9uqM940xESLrvA==", null, false, "", true, false, "member18@gmail.com" },
                    { 19, 0, "HCM", "ec1b1ebd-dac1-4a93-a340-475dca39ea39", "member19@gmail.com", true, "Name19", "LastName19", false, null, "member19@gmail.com", "member19@gmail.com", "AQAAAAIAAYagAAAAEMASRcATRUI2sUlAAl/fK+l9Ww0EgAjxmI7+sMNWkbCg0Xvzc+mVEQUuXaSckCSKSg==", null, false, "", true, false, "member19@gmail.com" },
                    { 20, 0, "HCM", "afceecfa-c828-4e57-aeee-da0ad3880a06", "member20@gmail.com", true, "Name20", "LastName20", false, null, "member20@gmail.com", "member20@gmail.com", "AQAAAAIAAYagAAAAEM4TSRUibrAR+IMGybBGEC9hwYZKTMuf3nBA4otFBZtxSVNRzAC/PjwEdQEVOs+WPw==", null, false, "", true, false, "member20@gmail.com" },
                    { 21, 0, "HCM", "bb5420bd-a2be-4758-a486-eea11495c863", "member21@gmail.com", true, "Name21", "LastName21", false, null, "member21@gmail.com", "member21@gmail.com", "AQAAAAIAAYagAAAAEBeMw+8qNuFR0qMNOqHnCtMLqDCvqbhoUNRetde3MM33sug+tbN//8ZlZAuFptyrHA==", null, false, "", true, false, "member21@gmail.com" },
                    { 22, 0, "HCM", "0447b575-6e6b-4bbd-ba9c-7424e3b2cd75", "member22@gmail.com", true, "Name22", "LastName22", false, null, "member22@gmail.com", "member22@gmail.com", "AQAAAAIAAYagAAAAEBShV6gPlbDjSaDwhpJKN580jkwpMS8J/RDaR2w04RCC6yem+8AMr8RClACgR0pyiw==", null, false, "", true, false, "member22@gmail.com" },
                    { 23, 0, "HCM", "462c6514-6143-4679-8bfa-a49ba8a45860", "member23@gmail.com", true, "Name23", "LastName23", false, null, "member23@gmail.com", "member23@gmail.com", "AQAAAAIAAYagAAAAEAOckl/cJ4iBBIdCQaIVNdnk/g6OrNLCjjZgUm9ATRmdTebKDQx4LVdFX5MsK3oCQg==", null, false, "", true, false, "member23@gmail.com" },
                    { 24, 0, "HCM", "b68a6fbb-f095-4317-8198-bc8aff790e38", "member24@gmail.com", true, "Name24", "LastName24", false, null, "member24@gmail.com", "member24@gmail.com", "AQAAAAIAAYagAAAAEMK5eZpjEH0yiOr4o3Sdj2jsdGuSeQkncYTFnVN/uTxin/yy4GBybkuDSKC6+btRLg==", null, false, "", true, false, "member24@gmail.com" },
                    { 25, 0, "HCM", "cc921b97-7eb9-4646-81e2-f58633bc42bb", "member25@gmail.com", true, "Name25", "LastName25", false, null, "member25@gmail.com", "member25@gmail.com", "AQAAAAIAAYagAAAAECwpM8jF+IGKP+DM5jrs8pdhWhVG75H79EMhyuupvbzQZTZ/1AWY9iB9IxWZ3tHgGA==", null, false, "", true, false, "member25@gmail.com" },
                    { 26, 0, "HCM", "e6735d26-6db9-43c5-a19e-78d9fa090dd5", "member26@gmail.com", true, "Name26", "LastName26", false, null, "member26@gmail.com", "member26@gmail.com", "AQAAAAIAAYagAAAAEBYnC9XpXSWABbJM90tEDjsGASuboTEs6FdSc4ff2etS0rvb06/L+um+V7egL6CBwQ==", null, false, "", true, false, "member26@gmail.com" },
                    { 27, 0, "HCM", "68d16fad-c2ac-48f8-986a-9626b5ffbe84", "member27@gmail.com", true, "Name27", "LastName27", false, null, "member27@gmail.com", "member27@gmail.com", "AQAAAAIAAYagAAAAEAt1KJZm/5jGzoZPtFG073hCEXNi4et1XIjkwQkuucz4ciGMXfCwof/5oIn+uuN1Dw==", null, false, "", true, false, "member27@gmail.com" },
                    { 28, 0, "HCM", "678d02dd-0726-43e9-a228-956e60c5e05e", "member28@gmail.com", true, "Name28", "LastName28", false, null, "member28@gmail.com", "member28@gmail.com", "AQAAAAIAAYagAAAAEIKDnsm0T+3OO18BG6vCTZz67sKwTx204qBfBFxEGNahD0xtRCcclL29TGM+RUaEdw==", null, false, "", true, false, "member28@gmail.com" },
                    { 29, 0, "HCM", "10c70826-ad77-4aff-89c5-690070da47d2", "member29@gmail.com", true, "Name29", "LastName29", false, null, "member29@gmail.com", "member29@gmail.com", "AQAAAAIAAYagAAAAEFDh+5wFFxJ5/aSI1GHCBRQ38hhsEwFGtZe04GRuo3bVXd6mZWvwn/KVcuc0n1zQ9A==", null, false, "", true, false, "member29@gmail.com" },
                    { 30, 0, "HCM", "fa8ac6e8-e657-4eb8-842d-9f5e4cb760f4", "member30@gmail.com", true, "Name30", "LastName30", false, null, "member30@gmail.com", "member30@gmail.com", "AQAAAAIAAYagAAAAEBTEgqptiOg62RzxAsDpnC4Xhg7H8GOlLu9xq9EHciFc8z6HjqNGfCkzFoVNQYJ01A==", null, false, "", true, false, "member30@gmail.com" },
                    { 31, 0, "HCM", "891265cb-4658-4aff-a8ec-582f90c3ec8c", "teacher31@gmail.com", true, "Name31", "LastName31", false, null, "teacher31@gmail.com", "teacher31@gmail.com", "AQAAAAIAAYagAAAAEH3UHPeQXe+OZESzWdAt/+Z8u0egm5Wn1QwWrT15Ms0zGtyOrQb0R/298W+AflYC6w==", null, false, "", true, false, "teacher31@gmail.com" },
                    { 32, 0, "HCM", "0eb5c42c-16f5-4f4c-a039-a430168f2d11", "teacher32@gmail.com", true, "Name32", "LastName32", false, null, "teacher32@gmail.com", "teacher32@gmail.com", "AQAAAAIAAYagAAAAEAFJaXPV9MQVb++DeFDBjsSUahWS6cl8FnGLAgGRCFZ4e7m6rIXFfV0FREhyAM0V1A==", null, false, "", true, false, "teacher32@gmail.com" },
                    { 33, 0, "HCM", "9ca257ff-dc6b-45c8-b850-d506efc6ce25", "teacher33@gmail.com", true, "Name33", "LastName33", false, null, "teacher33@gmail.com", "teacher33@gmail.com", "AQAAAAIAAYagAAAAEAK/uuC1uodlf/s7Zs+Rl8mRxpLUgy704d38RVTDy5OYL6/fWE1Ua8QJ93vyne5Bzg==", null, false, "", true, false, "teacher33@gmail.com" },
                    { 34, 0, "HCM", "7491c59c-1053-4e2f-8013-28a3901f9bf0", "teacher34@gmail.com", true, "Name34", "LastName34", false, null, "teacher34@gmail.com", "teacher34@gmail.com", "AQAAAAIAAYagAAAAEMA8e40D7xha1lIUaTJcQPJIllorDAsWITHciBfVnYHcJq3GiQv/FX7/eKUA48782g==", null, false, "", true, false, "teacher34@gmail.com" },
                    { 35, 0, "HCM", "a1f81f34-b0e7-40ae-a578-785881cf1bf7", "teacher35@gmail.com", true, "Name35", "LastName35", false, null, "teacher35@gmail.com", "teacher35@gmail.com", "AQAAAAIAAYagAAAAEAvrMa3HVAR54fwflJ7QbJ+lTsDXNYWrUskJdYF38JjDVoscTqqIUmlelHC7sIBVLg==", null, false, "", true, false, "teacher35@gmail.com" },
                    { 36, 0, "HCM", "de45ef5e-0025-4265-ae63-0128dea6a2fa", "teacher36@gmail.com", true, "Name36", "LastName36", false, null, "teacher36@gmail.com", "teacher36@gmail.com", "AQAAAAIAAYagAAAAENWUe7WmxUgyJPzLXwK2iSNi9MO4tjoi+niFCa/gP3FHSAZ6cTE+pnRaBkyNWH+bQA==", null, false, "", true, false, "teacher36@gmail.com" },
                    { 37, 0, "HCM", "a27a09e1-b86a-4b8c-96ee-9c2e0fb149b4", "teacher37@gmail.com", true, "Name37", "LastName37", false, null, "teacher37@gmail.com", "teacher37@gmail.com", "AQAAAAIAAYagAAAAEPnRUyqDamFVbjOvFAGNFBB9t+bL9/iqp9ECgzqaZv5LsbFcKc//jdg4URPyJg9NEg==", null, false, "", true, false, "teacher37@gmail.com" },
                    { 38, 0, "HCM", "80ab48af-7064-431b-92da-e20971f91ccf", "teacher38@gmail.com", true, "Name38", "LastName38", false, null, "teacher38@gmail.com", "teacher38@gmail.com", "AQAAAAIAAYagAAAAEK7TUW9hR0G+kdtoI8Ekqz0XKBxshM/7xP5PzTyZH5bl66LxDcG4w6joewVNve0ASw==", null, false, "", true, false, "teacher38@gmail.com" },
                    { 39, 0, "HCM", "df9637c1-72f9-4e8f-9454-7694b2ac38cf", "teacher39@gmail.com", true, "Name39", "LastName39", false, null, "teacher39@gmail.com", "teacher39@gmail.com", "AQAAAAIAAYagAAAAEODyOPbyMFQwa+yZEW3MZLfCVS5Elnluadcpms+5DqSrag532k+mdYMMhfgE821eFQ==", null, false, "", true, false, "teacher39@gmail.com" },
                    { 40, 0, "HCM", "e9d8a329-1948-47e7-bde9-778f734442b8", "teacher40@gmail.com", true, "Name40", "LastName40", false, null, "teacher40@gmail.com", "teacher40@gmail.com", "AQAAAAIAAYagAAAAENPLSkKl/rfpq8V8IoIAayuRyJ8M0JPsqHJBaKSh+19eJss1spzhEWnRdEKBRHE9lQ==", null, false, "", true, false, "teacher40@gmail.com" },
                    { 41, 0, "HCM", "512b41a4-c43a-4fb6-ba2e-85b514bf5e3d", "staff41@gmail.com", true, "Name41", "LastName41", false, null, "staff41@gmail.com", "staff41@gmail.com", "AQAAAAIAAYagAAAAEO0c2m1EtAAFp1ufLgHDwvLVFEKKW9qYFYqjUcjJopVOlBFE/GRxhSjKrza9f6UfVw==", null, false, "", true, false, "staff41@gmail.com" },
                    { 42, 0, "HCM", "59456c0a-5b53-45b6-83e9-a9c1f50718eb", "staff42@gmail.com", true, "Name42", "LastName42", false, null, "staff42@gmail.com", "staff42@gmail.com", "AQAAAAIAAYagAAAAEGgIqMM+jY3JK7/f1JxjHnjQK6oyNQj0lny9OMGJdL0MuRKRopOHiwYLFWjD8B/cxQ==", null, false, "", true, false, "staff42@gmail.com" },
                    { 43, 0, "HCM", "80675e04-a84d-4099-94c6-17323da973fc", "staff43@gmail.com", true, "Name43", "LastName43", false, null, "staff43@gmail.com", "staff43@gmail.com", "AQAAAAIAAYagAAAAEKPQhJTMT9F+disz3nA8IANszfBBqAac26I8ELTAdez7JjLOsDlrHo3nXDQOjeTAzg==", null, false, "", true, false, "staff43@gmail.com" },
                    { 44, 0, "HCM", "da503933-2f98-48e5-aa76-128e9a5b0b20", "staff44@gmail.com", true, "Name44", "LastName44", false, null, "staff44@gmail.com", "staff44@gmail.com", "AQAAAAIAAYagAAAAEIGKLmjbIsocH705JZUVE/O/GqQNmZm9nxGU+DGNvhU2Qpbscmejt53yOpP3yd+ZTQ==", null, false, "", true, false, "staff44@gmail.com" },
                    { 45, 0, "HCM", "adab0745-ca89-4b13-b4dd-2ef763da0e7b", "staff45@gmail.com", true, "Name45", "LastName45", false, null, "staff45@gmail.com", "staff45@gmail.com", "AQAAAAIAAYagAAAAEBoJRQqvU4pvEqegWUj4vz+Gs0CSssd0IA3UxuuiXlztOi73sybCF5NfsWENnzoa5A==", null, false, "", true, false, "staff45@gmail.com" },
                    { 46, 0, "HCM", "8df2893a-73f6-4d82-8af0-7a17efdfdabd", "admin46@gmail.com", true, "Name46", "LastName46", false, null, "admin46@gmail.com", "admin46@gmail.com", "AQAAAAIAAYagAAAAEDEY+motos3UcPDqj7KSMUnz1YlZNfKniUIY04GyeKaFaeAh6zLVna7shkqPcS9jbg==", null, false, "", true, false, "admin46@gmail.com" }
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
                    { 1, 1, "Yoga course number 1", new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Local), true, "Course1", 100.0, new DateTime(2023, 7, 8, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 2, 2, "Yoga course number 2", new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Local), true, "Course2", 200.0, new DateTime(2023, 7, 8, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 3, 3, "Yoga course number 3", new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Local), true, "Course3", 300.0, new DateTime(2023, 7, 8, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 4, 4, "Yoga course number 4", new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Local), true, "Course4", 400.0, new DateTime(2023, 7, 8, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 5, 5, "Yoga course number 5", new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Local), true, "Course5", 500.0, new DateTime(2023, 7, 8, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 6, 6, "Yoga course number 6", new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Local), true, "Course6", 600.0, new DateTime(2023, 7, 8, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 7, 7, "Yoga course number 7", new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Local), true, "Course7", 700.0, new DateTime(2023, 7, 8, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 8, 8, "Yoga course number 8", new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Local), true, "Course8", 800.0, new DateTime(2023, 7, 8, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 9, 9, "Yoga course number 9", new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Local), true, "Course9", 900.0, new DateTime(2023, 7, 8, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 10, 10, "Yoga course number 10", new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Local), true, "Course10", 1000.0, new DateTime(2023, 7, 8, 0, 0, 0, 0, DateTimeKind.Local) }
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
                table: "TeacherSchedule",
                columns: new[] { "TeacherProfileId", "TimeSlotId", "IsTaken" },
                values: new object[,]
                {
                    { 31, 11, false },
                    { 32, 11, false },
                    { 33, 11, false },
                    { 34, 11, false },
                    { 35, 11, false },
                    { 36, 11, false },
                    { 37, 11, false },
                    { 38, 11, false },
                    { 39, 11, false },
                    { 40, 11, false },
                    { 31, 12, false },
                    { 32, 12, false },
                    { 33, 12, false },
                    { 34, 12, false },
                    { 35, 12, false },
                    { 36, 12, false },
                    { 37, 12, false },
                    { 38, 12, false },
                    { 39, 12, false },
                    { 40, 12, false },
                    { 31, 13, false },
                    { 32, 13, false },
                    { 33, 13, false },
                    { 34, 13, false },
                    { 35, 13, false },
                    { 36, 13, false },
                    { 37, 13, false },
                    { 38, 13, false },
                    { 39, 13, false },
                    { 40, 13, false },
                    { 31, 14, false },
                    { 32, 14, false },
                    { 33, 14, false },
                    { 34, 14, false },
                    { 35, 14, false },
                    { 36, 14, false },
                    { 37, 14, false },
                    { 38, 14, false },
                    { 39, 14, false },
                    { 40, 14, false },
                    { 31, 15, false },
                    { 32, 15, false },
                    { 33, 15, false },
                    { 34, 15, false },
                    { 35, 15, false },
                    { 36, 15, false },
                    { 37, 15, false },
                    { 38, 15, false },
                    { 39, 15, false },
                    { 40, 15, false },
                    { 31, 16, false },
                    { 32, 16, false },
                    { 33, 16, false },
                    { 34, 16, false },
                    { 35, 16, false },
                    { 36, 16, false },
                    { 37, 16, false },
                    { 38, 16, false },
                    { 39, 16, false },
                    { 40, 16, false },
                    { 31, 17, false },
                    { 32, 17, false },
                    { 33, 17, false },
                    { 34, 17, false },
                    { 35, 17, false },
                    { 36, 17, false },
                    { 37, 17, false },
                    { 38, 17, false },
                    { 39, 17, false },
                    { 40, 17, false },
                    { 31, 21, false },
                    { 32, 21, false },
                    { 33, 21, false },
                    { 34, 21, false },
                    { 35, 21, false },
                    { 36, 21, false },
                    { 37, 21, false },
                    { 38, 21, false },
                    { 39, 21, false },
                    { 40, 21, false },
                    { 31, 22, false },
                    { 32, 22, false },
                    { 33, 22, false },
                    { 34, 22, false },
                    { 35, 22, false },
                    { 36, 22, false },
                    { 37, 22, false },
                    { 38, 22, false },
                    { 39, 22, false },
                    { 40, 22, false },
                    { 31, 23, false },
                    { 32, 23, false },
                    { 33, 23, false },
                    { 34, 23, false },
                    { 35, 23, false },
                    { 36, 23, false },
                    { 37, 23, false },
                    { 38, 23, false },
                    { 39, 23, false },
                    { 40, 23, false },
                    { 31, 24, false },
                    { 32, 24, false },
                    { 33, 24, false },
                    { 34, 24, false },
                    { 35, 24, false },
                    { 36, 24, false },
                    { 37, 24, false },
                    { 38, 24, false },
                    { 39, 24, false },
                    { 40, 24, false },
                    { 31, 25, false },
                    { 32, 25, false },
                    { 33, 25, false },
                    { 34, 25, false },
                    { 35, 25, false },
                    { 36, 25, false },
                    { 37, 25, false },
                    { 38, 25, false },
                    { 39, 25, false },
                    { 40, 25, false },
                    { 31, 26, false },
                    { 32, 26, false },
                    { 33, 26, false },
                    { 34, 26, false },
                    { 35, 26, false },
                    { 36, 26, false },
                    { 37, 26, false },
                    { 38, 26, false },
                    { 39, 26, false },
                    { 40, 26, false },
                    { 31, 27, false },
                    { 32, 27, false },
                    { 33, 27, false },
                    { 34, 27, false },
                    { 35, 27, false },
                    { 36, 27, false },
                    { 37, 27, false },
                    { 38, 27, false },
                    { 39, 27, false },
                    { 40, 27, false },
                    { 31, 31, false },
                    { 32, 31, false },
                    { 33, 31, false },
                    { 34, 31, false },
                    { 35, 31, false },
                    { 36, 31, false },
                    { 37, 31, false },
                    { 38, 31, false },
                    { 39, 31, false },
                    { 40, 31, false },
                    { 31, 32, false },
                    { 32, 32, false },
                    { 33, 32, false },
                    { 34, 32, false },
                    { 35, 32, false },
                    { 36, 32, false },
                    { 37, 32, false },
                    { 38, 32, false },
                    { 39, 32, false },
                    { 40, 32, false },
                    { 31, 33, false },
                    { 32, 33, false },
                    { 33, 33, false },
                    { 34, 33, false },
                    { 35, 33, false },
                    { 36, 33, false },
                    { 37, 33, false },
                    { 38, 33, false },
                    { 39, 33, false },
                    { 40, 33, false },
                    { 31, 34, false },
                    { 32, 34, false },
                    { 33, 34, false },
                    { 34, 34, false },
                    { 35, 34, false },
                    { 36, 34, false },
                    { 37, 34, false },
                    { 38, 34, false },
                    { 39, 34, false },
                    { 40, 34, false },
                    { 31, 35, false },
                    { 32, 35, false },
                    { 33, 35, false },
                    { 34, 35, false },
                    { 35, 35, false },
                    { 36, 35, false },
                    { 37, 35, false },
                    { 38, 35, false },
                    { 39, 35, false },
                    { 40, 35, false },
                    { 31, 36, false },
                    { 32, 36, false },
                    { 33, 36, false },
                    { 34, 36, false },
                    { 35, 36, false },
                    { 36, 36, false },
                    { 37, 36, false },
                    { 38, 36, false },
                    { 39, 36, false },
                    { 40, 36, false },
                    { 31, 37, false },
                    { 32, 37, false },
                    { 33, 37, false },
                    { 34, 37, false },
                    { 35, 37, false },
                    { 36, 37, false },
                    { 37, 37, false },
                    { 38, 37, false },
                    { 39, 37, false },
                    { 40, 37, false }
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
                table: "Enrollments",
                columns: new[] { "MemberId", "YogaClassId", "Discount", "EnrollDate" },
                values: new object[,]
                {
                    { 1, 4, 0.0, new DateTime(2023, 7, 9, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 2, 2, 0.0, new DateTime(2023, 7, 9, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 3, 4, 0.0, new DateTime(2023, 7, 9, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 4, 2, 0.0, new DateTime(2023, 7, 9, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 5, 4, 0.0, new DateTime(2023, 7, 9, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 6, 2, 0.0, new DateTime(2023, 7, 9, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 7, 4, 0.0, new DateTime(2023, 7, 9, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 8, 2, 0.0, new DateTime(2023, 7, 9, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 9, 4, 0.0, new DateTime(2023, 7, 9, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 10, 2, 0.0, new DateTime(2023, 7, 9, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 11, 4, 0.0, new DateTime(2023, 7, 9, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 12, 2, 0.0, new DateTime(2023, 7, 9, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 13, 4, 0.0, new DateTime(2023, 7, 9, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 14, 2, 0.0, new DateTime(2023, 7, 9, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 15, 4, 0.0, new DateTime(2023, 7, 9, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 16, 6, 0.0, new DateTime(2023, 7, 9, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 17, 8, 0.0, new DateTime(2023, 7, 9, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 18, 6, 0.0, new DateTime(2023, 7, 9, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 19, 8, 0.0, new DateTime(2023, 7, 9, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 20, 6, 0.0, new DateTime(2023, 7, 9, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 21, 8, 0.0, new DateTime(2023, 7, 9, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 22, 6, 0.0, new DateTime(2023, 7, 9, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 23, 8, 0.0, new DateTime(2023, 7, 9, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 24, 6, 0.0, new DateTime(2023, 7, 9, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 25, 8, 0.0, new DateTime(2023, 7, 9, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 26, 6, 0.0, new DateTime(2023, 7, 9, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 27, 8, 0.0, new DateTime(2023, 7, 9, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 28, 6, 0.0, new DateTime(2023, 7, 9, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 29, 8, 0.0, new DateTime(2023, 7, 9, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 30, 6, 0.0, new DateTime(2023, 7, 9, 0, 0, 0, 0, DateTimeKind.Local) }
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

            migrationBuilder.InsertData(
                table: "TeacherEnrollments",
                columns: new[] { "Id", "EndDate", "IsActive", "StartDate", "TeacherProfileId", "YogaClassId" },
                values: new object[,]
                {
                    { 31, new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2023, 7, 9, 0, 0, 0, 0, DateTimeKind.Local), 31, 4 },
                    { 32, new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2023, 7, 9, 0, 0, 0, 0, DateTimeKind.Local), 32, 2 },
                    { 33, new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2023, 7, 9, 0, 0, 0, 0, DateTimeKind.Local), 33, 4 },
                    { 34, new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2023, 7, 9, 0, 0, 0, 0, DateTimeKind.Local), 34, 2 },
                    { 35, new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2023, 7, 9, 0, 0, 0, 0, DateTimeKind.Local), 35, 4 }
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
