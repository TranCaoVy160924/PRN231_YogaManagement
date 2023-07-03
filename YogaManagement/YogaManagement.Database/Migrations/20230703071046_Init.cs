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
                    TotalDeposit = table.Column<double>(type: "float", nullable: false),
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
                    { 1, 0, "HCM", "ab36278c-3ad2-4a42-a86c-1eccf70b4132", "member1@gmail.com", true, "Name1", "LastName1", false, null, "member1@gmail.com", "member1@gmail.com", "AQAAAAIAAYagAAAAECmHEOqeemv6qUKEYSZv8Tt1VJOSarrRcAbHzhfKDg0KlgwSmAG9/NqdZ8P3ALNFEA==", null, false, "", true, false, "member1@gmail.com" },
                    { 2, 0, "HCM", "0a04bf71-3363-4eeb-94db-111efb5f68f1", "member2@gmail.com", true, "Name2", "LastName2", false, null, "member2@gmail.com", "member2@gmail.com", "AQAAAAIAAYagAAAAEJEClG936B2a3TwJeRMxQX7barfj1BeqpK4kBIIzqKzkUI1GgwUZ/QgvmekeTq+hww==", null, false, "", true, false, "member2@gmail.com" },
                    { 3, 0, "HCM", "fd166624-5140-47de-a4d6-43236bb4bf3c", "member3@gmail.com", true, "Name3", "LastName3", false, null, "member3@gmail.com", "member3@gmail.com", "AQAAAAIAAYagAAAAEFkrIgyXD2B/ukFkCMqcyYgXJJzHJY3epZWV/9VVad+OYpupmhrFFk9Ahty6qmXceA==", null, false, "", true, false, "member3@gmail.com" },
                    { 4, 0, "HCM", "bd7b55ce-0eb0-48ac-906f-45e1d7767e17", "member4@gmail.com", true, "Name4", "LastName4", false, null, "member4@gmail.com", "member4@gmail.com", "AQAAAAIAAYagAAAAEK5IA4ZVRC/nGgNbtOoBL7Q2PeexOym4AKOz5Cg1Z9LzByYmPLdO8zN7RA2u+5qc6w==", null, false, "", true, false, "member4@gmail.com" },
                    { 5, 0, "HCM", "5fd8d9dc-868b-4f7b-b013-0cea68052c0c", "member5@gmail.com", true, "Name5", "LastName5", false, null, "member5@gmail.com", "member5@gmail.com", "AQAAAAIAAYagAAAAEDzYh0Vaz4NQveGqgtbXhww+MiJBPgLVC0Plg7emI7yvYTNKvIe2Am4jWtQM/Dxzig==", null, false, "", true, false, "member5@gmail.com" },
                    { 6, 0, "HCM", "f66ff583-bafc-45d6-8c78-d5e3d5d60e27", "member6@gmail.com", true, "Name6", "LastName6", false, null, "member6@gmail.com", "member6@gmail.com", "AQAAAAIAAYagAAAAEGFehKE20ArbVbxIHhMW+Nhs6CS62K72j47iiWJhTroNYhDXjd5lksLrdSU6VOIT4g==", null, false, "", true, false, "member6@gmail.com" },
                    { 7, 0, "HCM", "6fc3e1d6-42d4-4c6f-9da9-9ab71bcda354", "member7@gmail.com", true, "Name7", "LastName7", false, null, "member7@gmail.com", "member7@gmail.com", "AQAAAAIAAYagAAAAEDYgAiu126Jzxwo3V01Mo0Yct+m1qhlaYxRRJzenvt9MF6ff3F1QyYwP/BPXlJcE5w==", null, false, "", true, false, "member7@gmail.com" },
                    { 8, 0, "HCM", "9a700062-3b90-4bd7-817b-0192ee78bae5", "member8@gmail.com", true, "Name8", "LastName8", false, null, "member8@gmail.com", "member8@gmail.com", "AQAAAAIAAYagAAAAEGVx4zfYfdKMSgSI9TILuxE+Wx+vQ4uLPZuFDvnEW2Aw4O7F4yA9vYSQKyYDHUQvIg==", null, false, "", true, false, "member8@gmail.com" },
                    { 9, 0, "HCM", "bdc198ea-f127-4e21-9426-845eec806072", "member9@gmail.com", true, "Name9", "LastName9", false, null, "member9@gmail.com", "member9@gmail.com", "AQAAAAIAAYagAAAAEB0vJG2RP/1j7BtTj3YRo4l1hJt9HAJx06QEzK4aSwpAjlbmsapwkCJdrE+Y6GTAng==", null, false, "", true, false, "member9@gmail.com" },
                    { 10, 0, "HCM", "d83ddcfc-e540-4165-af0f-5fbf5644eec4", "member10@gmail.com", true, "Name10", "LastName10", false, null, "member10@gmail.com", "member10@gmail.com", "AQAAAAIAAYagAAAAENTXn/Vo/7VGs9KGMs+3xFiXNFatYrDOb3ZJN/FE3xIHDhGdJfbhUFfGHtW2gl98vQ==", null, false, "", true, false, "member10@gmail.com" },
                    { 11, 0, "HCM", "721628fe-59ea-45e9-b39a-7e8c9a3f783f", "member11@gmail.com", true, "Name11", "LastName11", false, null, "member11@gmail.com", "member11@gmail.com", "AQAAAAIAAYagAAAAEBQbjbRk6nqhFemoIhDFvO+VBWQ4DoNeG9GEMuUDw1uJMV5mHgTyq9DbwxVLdiEK2A==", null, false, "", true, false, "member11@gmail.com" },
                    { 12, 0, "HCM", "07206be0-49a3-44ea-a6f4-f000f99b0ceb", "member12@gmail.com", true, "Name12", "LastName12", false, null, "member12@gmail.com", "member12@gmail.com", "AQAAAAIAAYagAAAAEI82KXFa0qz50LWKiTKcp+CPAt+SX06xqSPBSBesEV28MkX2tNIaeFszw2kwtrrzKw==", null, false, "", true, false, "member12@gmail.com" },
                    { 13, 0, "HCM", "a6809122-6df7-4e9b-9892-5bd803a690ea", "member13@gmail.com", true, "Name13", "LastName13", false, null, "member13@gmail.com", "member13@gmail.com", "AQAAAAIAAYagAAAAEJWhQFDUhX9QyPPAfvOHAKKB7rGCfsAPgK1aWav7Bs6QjAVPWNt0kdq8SPnVX1mvCA==", null, false, "", true, false, "member13@gmail.com" },
                    { 14, 0, "HCM", "59257aef-898e-40db-a840-9c4b3f83750c", "member14@gmail.com", true, "Name14", "LastName14", false, null, "member14@gmail.com", "member14@gmail.com", "AQAAAAIAAYagAAAAEJU1LhU4YPWo5yrswJnPERLgz8yuP42G3OSic/3VN2qltvzZijkTBOrBbISTaB0YYA==", null, false, "", true, false, "member14@gmail.com" },
                    { 15, 0, "HCM", "6e2ff243-415b-4450-8032-5a77b169722a", "member15@gmail.com", true, "Name15", "LastName15", false, null, "member15@gmail.com", "member15@gmail.com", "AQAAAAIAAYagAAAAEL44MXAh95qrlYaUvYaFX0b+zhZwKsASOrrjopj1KH5jEyapuEIA1Zm1/i/WDgL5nw==", null, false, "", true, false, "member15@gmail.com" },
                    { 16, 0, "HCM", "dcc09394-cf22-472a-9133-767c380fa955", "member16@gmail.com", true, "Name16", "LastName16", false, null, "member16@gmail.com", "member16@gmail.com", "AQAAAAIAAYagAAAAEPTqw20f5ECotI3zPSMwfTFCzuoM4+PoEpeTl/Yjf9DZsalAzkBxvicA2EtdylcxIw==", null, false, "", true, false, "member16@gmail.com" },
                    { 17, 0, "HCM", "bba7e4ae-b7af-4b6e-95a5-c2a582f20eba", "member17@gmail.com", true, "Name17", "LastName17", false, null, "member17@gmail.com", "member17@gmail.com", "AQAAAAIAAYagAAAAEHCQa4T1hpaIo7e1oG+8rRhBidu/GuvSHiq/4NHGVyw+fcag594OGEAZNFC7kV8Qrw==", null, false, "", true, false, "member17@gmail.com" },
                    { 18, 0, "HCM", "19207dea-6532-450b-8c1c-69abd5b7ba53", "member18@gmail.com", true, "Name18", "LastName18", false, null, "member18@gmail.com", "member18@gmail.com", "AQAAAAIAAYagAAAAEMFy0Vxg7IuSmOC19aeYws98P2EbmkJNiLaEBTBkH0rOjgz7mcqR5HC5hZO5WWqxOw==", null, false, "", true, false, "member18@gmail.com" },
                    { 19, 0, "HCM", "58930076-1271-4a39-93ba-209f3e5cc118", "member19@gmail.com", true, "Name19", "LastName19", false, null, "member19@gmail.com", "member19@gmail.com", "AQAAAAIAAYagAAAAED7BgLSWvRFq8ZgV/oH7jQvuIdGEtLxErubcSWR/XABsuMS3Xb5WfEYpNp0zgI8yCw==", null, false, "", true, false, "member19@gmail.com" },
                    { 20, 0, "HCM", "2d69825e-3e74-4e9b-8fea-c470acb49fd1", "member20@gmail.com", true, "Name20", "LastName20", false, null, "member20@gmail.com", "member20@gmail.com", "AQAAAAIAAYagAAAAEArM5CzFgzJotzmNqLKwwYQfQG+0mMZHqQh56XBYeAmxlkeW6IAPCrQKIJlpjsOlMA==", null, false, "", true, false, "member20@gmail.com" },
                    { 21, 0, "HCM", "40716dee-32cd-4ab4-af45-0c8454c69640", "member21@gmail.com", true, "Name21", "LastName21", false, null, "member21@gmail.com", "member21@gmail.com", "AQAAAAIAAYagAAAAEOL1AzdTz6uWBjLRFWm8aMJ0U6bh1t58H3Pphr+VGtJkUtY0EKhi7+Rc5CzfIShQmw==", null, false, "", true, false, "member21@gmail.com" },
                    { 22, 0, "HCM", "1cfda307-100d-47c7-9406-3891e9f034e0", "member22@gmail.com", true, "Name22", "LastName22", false, null, "member22@gmail.com", "member22@gmail.com", "AQAAAAIAAYagAAAAED9FBZxL+WilWCS+s3EXZNHuJ3MLoJU0RoJt79i1XCwjGQZxp2IvzUjT9APlPTyLjQ==", null, false, "", true, false, "member22@gmail.com" },
                    { 23, 0, "HCM", "344150f5-3ce4-4a24-87a9-49bd98b54174", "member23@gmail.com", true, "Name23", "LastName23", false, null, "member23@gmail.com", "member23@gmail.com", "AQAAAAIAAYagAAAAEIIXHRpx9waokb1ZQmpF5dVyfgtPlUMwZPqGcfcZYSJQrS03bV/HElaty/PVSTe1Yw==", null, false, "", true, false, "member23@gmail.com" },
                    { 24, 0, "HCM", "5539a583-9a0c-40ca-8c48-e2a72deb3d5d", "member24@gmail.com", true, "Name24", "LastName24", false, null, "member24@gmail.com", "member24@gmail.com", "AQAAAAIAAYagAAAAEOXhPhbsmck8zK47T572w+BdE7qRa7zaD55+Ag8dui2dd2h67MrPPXqOl6+CAcFb+g==", null, false, "", true, false, "member24@gmail.com" },
                    { 25, 0, "HCM", "30d74b90-9ae3-4047-86ae-31c73725ad30", "member25@gmail.com", true, "Name25", "LastName25", false, null, "member25@gmail.com", "member25@gmail.com", "AQAAAAIAAYagAAAAEKRBWAzCZZ3Eo11OvDpT0SgY+nk5WefDvmZBJoJCez0sP2CkSZ2iwtQW/UMlRUhPzQ==", null, false, "", true, false, "member25@gmail.com" },
                    { 26, 0, "HCM", "5f80bf70-4a37-4f4d-97c7-93b70725f741", "member26@gmail.com", true, "Name26", "LastName26", false, null, "member26@gmail.com", "member26@gmail.com", "AQAAAAIAAYagAAAAEBxLKee8bTNuopSOxWenGlz4I/wM9magNcSCQ0MqTMa1OuFXbRyzx9/UtjF2jriuiQ==", null, false, "", true, false, "member26@gmail.com" },
                    { 27, 0, "HCM", "1c33e53c-ceee-45fe-87ce-707d2f8e0b3a", "member27@gmail.com", true, "Name27", "LastName27", false, null, "member27@gmail.com", "member27@gmail.com", "AQAAAAIAAYagAAAAEDAIoLkOpd1nD9jshDG9Qm1g66TdtQ8kKZqw4Tuzr3hOjcu1mb+hYRxhVlR14ftwhQ==", null, false, "", true, false, "member27@gmail.com" },
                    { 28, 0, "HCM", "396515ad-287b-47f2-9e16-672ec66dafbf", "member28@gmail.com", true, "Name28", "LastName28", false, null, "member28@gmail.com", "member28@gmail.com", "AQAAAAIAAYagAAAAEKUf9NOlk3fnUovhPjIKvZsKdr1woxQdrn53f8cHcqxux0S1mg54bAvudEcSZOI2+Q==", null, false, "", true, false, "member28@gmail.com" },
                    { 29, 0, "HCM", "9f721388-3288-4c43-80d6-6634c4f46a61", "member29@gmail.com", true, "Name29", "LastName29", false, null, "member29@gmail.com", "member29@gmail.com", "AQAAAAIAAYagAAAAENOPS16fuC67W03so1G+kO5JEBeaMa9J2byS3+vYgMDdyKNZ8QUZeHEbTDf6yovC3Q==", null, false, "", true, false, "member29@gmail.com" },
                    { 30, 0, "HCM", "8aca9250-9755-41aa-8044-6e7025f66914", "member30@gmail.com", true, "Name30", "LastName30", false, null, "member30@gmail.com", "member30@gmail.com", "AQAAAAIAAYagAAAAEFFT1ObV+F8qpmPJDBHelR5Yy2glu9bGm9MAbpTaoH4mHVWKN9QpUIHGUruw+lsrMQ==", null, false, "", true, false, "member30@gmail.com" },
                    { 31, 0, "HCM", "29008300-3a28-4bbd-b47b-4699664b3b16", "teacher31@gmail.com", true, "Name31", "LastName31", false, null, "teacher31@gmail.com", "teacher31@gmail.com", "AQAAAAIAAYagAAAAEGtxRPZtEhTW+H1haxe3dA60QTy/gxvM/W7Ahq8yWqovm/WRUjNIf4BFcBitIVXlkg==", null, false, "", true, false, "teacher31@gmail.com" },
                    { 32, 0, "HCM", "e9cb74ed-7f91-4834-b271-3aaaa6c36850", "teacher32@gmail.com", true, "Name32", "LastName32", false, null, "teacher32@gmail.com", "teacher32@gmail.com", "AQAAAAIAAYagAAAAEBj2yM14VCF42agxB+Jz98T2GdVp5cZ8EoUwWim+ryeRM3v9fPI2NhpbYUciZ0snuw==", null, false, "", true, false, "teacher32@gmail.com" },
                    { 33, 0, "HCM", "4624ac43-3755-4923-9051-3aae977dac41", "teacher33@gmail.com", true, "Name33", "LastName33", false, null, "teacher33@gmail.com", "teacher33@gmail.com", "AQAAAAIAAYagAAAAEKn5nLEuJC0WZiMDOEgGSWRka+UYLO+ir39jl3A/GnuYVSRIxokIDt/a5hT57LHb5g==", null, false, "", true, false, "teacher33@gmail.com" },
                    { 34, 0, "HCM", "52532a24-2fde-428a-93b5-940961527ff0", "teacher34@gmail.com", true, "Name34", "LastName34", false, null, "teacher34@gmail.com", "teacher34@gmail.com", "AQAAAAIAAYagAAAAEK68gDNWon3UPGk3hWl4aiNRHc7rJ+g79cAIbeeV+X/b3xv0gMn05fY5iOfmu+sxrg==", null, false, "", true, false, "teacher34@gmail.com" },
                    { 35, 0, "HCM", "8bbf4f96-3148-4974-b730-6cec2cdb428a", "teacher35@gmail.com", true, "Name35", "LastName35", false, null, "teacher35@gmail.com", "teacher35@gmail.com", "AQAAAAIAAYagAAAAEDpq3aNOwK+GSP+wvNnwLyiYjpQ5QgHtRxV4BmWFg1B784SiWMvCb47/0/2VJ17KOA==", null, false, "", true, false, "teacher35@gmail.com" },
                    { 36, 0, "HCM", "7e2fab2d-9e22-4711-b5b0-d6aea4721a53", "teacher36@gmail.com", true, "Name36", "LastName36", false, null, "teacher36@gmail.com", "teacher36@gmail.com", "AQAAAAIAAYagAAAAEJAACLZTBZw3xXnOLrg4U7INu8C7EbbZyBD+Ufa2MLARI1RSGbataxd9uOI5kPMqHQ==", null, false, "", true, false, "teacher36@gmail.com" },
                    { 37, 0, "HCM", "5ab68b88-d245-4cb7-ad80-b3d77c7a9f08", "teacher37@gmail.com", true, "Name37", "LastName37", false, null, "teacher37@gmail.com", "teacher37@gmail.com", "AQAAAAIAAYagAAAAEIezWPmU1VrqMJhxxnYxozCBgtWiPaqa3fqkZmU4mc82Uwao3/Iny4ooGfThYrx3RA==", null, false, "", true, false, "teacher37@gmail.com" },
                    { 38, 0, "HCM", "d5788f99-0f3d-4f36-90f5-da49e3cb05c1", "teacher38@gmail.com", true, "Name38", "LastName38", false, null, "teacher38@gmail.com", "teacher38@gmail.com", "AQAAAAIAAYagAAAAEPKfI3PoLmClY0Qu2gqJ4NWj9uohsvZDcXwHdG90yDsR0gilfX997vEeahXKe+pPbQ==", null, false, "", true, false, "teacher38@gmail.com" },
                    { 39, 0, "HCM", "c86d6742-7cdc-434f-a16f-76831d85b568", "teacher39@gmail.com", true, "Name39", "LastName39", false, null, "teacher39@gmail.com", "teacher39@gmail.com", "AQAAAAIAAYagAAAAEJUWsXBfYanT0yiBxfznwolBp3+fxRC/Qs5/bxk0+DPglpfiknmgyVQtxb3Ac/EQMA==", null, false, "", true, false, "teacher39@gmail.com" },
                    { 40, 0, "HCM", "1699d32b-380d-438b-9119-c136d3f929ef", "teacher40@gmail.com", true, "Name40", "LastName40", false, null, "teacher40@gmail.com", "teacher40@gmail.com", "AQAAAAIAAYagAAAAEBRgsSVxpoiFs77EsPh8OA1nC5+IP6FfShSzDwBars4uZIIQa+IeGazBXtgXyk+lbg==", null, false, "", true, false, "teacher40@gmail.com" },
                    { 41, 0, "HCM", "3426f008-bdac-4fa0-8cf2-e26e1864b782", "staff41@gmail.com", true, "Name41", "LastName41", false, null, "staff41@gmail.com", "staff41@gmail.com", "AQAAAAIAAYagAAAAEHEMgEY7p60mwK59vyJ8z2Q5zalUqd+sOqJpIUVeenCTufUcoVtsJJfUchoV4fBcgw==", null, false, "", true, false, "staff41@gmail.com" },
                    { 42, 0, "HCM", "6bc3b28a-4f9c-4c4b-8e83-20bd552d95f9", "staff42@gmail.com", true, "Name42", "LastName42", false, null, "staff42@gmail.com", "staff42@gmail.com", "AQAAAAIAAYagAAAAEO08EmOkQjl0WdDNkQ95OWTqD2npv3P6WOOtqiZUklUjSqN7DyiBI2ZVnf5cEixk8A==", null, false, "", true, false, "staff42@gmail.com" },
                    { 43, 0, "HCM", "9a4c373c-03a3-4f66-b7a2-5684c7475585", "staff43@gmail.com", true, "Name43", "LastName43", false, null, "staff43@gmail.com", "staff43@gmail.com", "AQAAAAIAAYagAAAAEMdBedzxLfz/WJUToh4JMFEVgW0BpDiGOIC95icMBMZVB0lDO4XqyPTBCcks4TAdZw==", null, false, "", true, false, "staff43@gmail.com" },
                    { 44, 0, "HCM", "e4aa1155-e5ca-43a5-8757-7223dbe76271", "staff44@gmail.com", true, "Name44", "LastName44", false, null, "staff44@gmail.com", "staff44@gmail.com", "AQAAAAIAAYagAAAAELNK3UaDh5t+jSx499bQ4yx84NIIxaAUTG1Q2ow++4uhLVPHOhFIWoz9C1puw37+3Q==", null, false, "", true, false, "staff44@gmail.com" },
                    { 45, 0, "HCM", "d644876e-a797-4039-a91c-2be253e07dcb", "staff45@gmail.com", true, "Name45", "LastName45", false, null, "staff45@gmail.com", "staff45@gmail.com", "AQAAAAIAAYagAAAAEFxIJxooamuct7NM+qF80y0dXFacEhyHwgInnIa6eQJXWei2omdTvHW+GrJYqrilWA==", null, false, "", true, false, "staff45@gmail.com" },
                    { 46, 0, "HCM", "a9e3d3c7-a9a0-44da-b0d2-391e308b0b00", "admin46@gmail.com", true, "Name46", "LastName46", false, null, "admin46@gmail.com", "admin46@gmail.com", "AQAAAAIAAYagAAAAEPvaeLyvT0qOAjN07c4EtdXKShO5UBwgD23CSOzMRQUHaTAgUWrwC+N5CVQGlTQ0lA==", null, false, "", true, false, "admin46@gmail.com" }
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
                    { 1, 1, "Yoga course number 1", new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Local), true, "Course1", 100.0, new DateTime(2023, 7, 10, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 2, 2, "Yoga course number 2", new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Local), true, "Course2", 200.0, new DateTime(2023, 7, 10, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 3, 3, "Yoga course number 3", new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Local), true, "Course3", 300.0, new DateTime(2023, 7, 10, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 4, 4, "Yoga course number 4", new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Local), true, "Course4", 400.0, new DateTime(2023, 7, 10, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 5, 5, "Yoga course number 5", new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Local), true, "Course5", 500.0, new DateTime(2023, 7, 10, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 6, 6, "Yoga course number 6", new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Local), true, "Course6", 600.0, new DateTime(2023, 7, 10, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 7, 7, "Yoga course number 7", new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Local), true, "Course7", 700.0, new DateTime(2023, 7, 10, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 8, 8, "Yoga course number 8", new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Local), true, "Course8", 800.0, new DateTime(2023, 7, 10, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 9, 9, "Yoga course number 9", new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Local), true, "Course9", 900.0, new DateTime(2023, 7, 10, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 10, 10, "Yoga course number 10", new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Local), true, "Course10", 1000.0, new DateTime(2023, 7, 10, 0, 0, 0, 0, DateTimeKind.Local) }
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
                columns: new[] { "Id", "AppUserId", "Balance", "IsAdminWallet", "TotalDeposit" },
                values: new object[,]
                {
                    { 1, 1, 0.0, false, 0.0 },
                    { 2, 2, 0.0, false, 0.0 },
                    { 3, 3, 0.0, false, 0.0 },
                    { 4, 4, 0.0, false, 0.0 },
                    { 5, 5, 0.0, false, 0.0 },
                    { 6, 6, 0.0, false, 0.0 },
                    { 7, 7, 0.0, false, 0.0 },
                    { 8, 8, 0.0, false, 0.0 },
                    { 9, 9, 0.0, false, 0.0 },
                    { 10, 10, 0.0, false, 0.0 },
                    { 11, 11, 0.0, false, 0.0 },
                    { 12, 12, 0.0, false, 0.0 },
                    { 13, 13, 0.0, false, 0.0 },
                    { 14, 14, 0.0, false, 0.0 },
                    { 15, 15, 0.0, false, 0.0 },
                    { 16, 16, 0.0, false, 0.0 },
                    { 17, 17, 0.0, false, 0.0 },
                    { 18, 18, 0.0, false, 0.0 },
                    { 19, 19, 0.0, false, 0.0 },
                    { 20, 20, 0.0, false, 0.0 },
                    { 21, 21, 0.0, false, 0.0 },
                    { 22, 22, 0.0, false, 0.0 },
                    { 23, 23, 0.0, false, 0.0 },
                    { 24, 24, 0.0, false, 0.0 },
                    { 25, 25, 0.0, false, 0.0 },
                    { 26, 26, 0.0, false, 0.0 },
                    { 27, 27, 0.0, false, 0.0 },
                    { 28, 28, 0.0, false, 0.0 },
                    { 29, 29, 0.0, false, 0.0 },
                    { 30, 30, 0.0, false, 0.0 },
                    { 31, 31, 0.0, false, 0.0 },
                    { 32, 32, 0.0, false, 0.0 },
                    { 33, 33, 0.0, false, 0.0 },
                    { 34, 34, 0.0, false, 0.0 },
                    { 35, 35, 0.0, false, 0.0 },
                    { 36, 36, 0.0, false, 0.0 },
                    { 37, 37, 0.0, false, 0.0 },
                    { 38, 38, 0.0, false, 0.0 },
                    { 39, 39, 0.0, false, 0.0 },
                    { 40, 40, 0.0, false, 0.0 },
                    { 41, 41, 0.0, false, 0.0 },
                    { 42, 42, 0.0, false, 0.0 },
                    { 43, 43, 0.0, false, 0.0 },
                    { 44, 44, 0.0, false, 0.0 },
                    { 45, 45, 0.0, false, 0.0 },
                    { 46, 46, 0.0, true, 0.0 }
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
                    { 1, 1, "Class1", 19, 1 },
                    { 2, 2, "Class2", 18, 1 },
                    { 3, 3, "Class3", 17, 1 },
                    { 4, 4, "Class4", 16, 1 },
                    { 5, 5, "Class5", 15, 1 },
                    { 6, 6, "Class6", 14, 1 },
                    { 7, 7, "Class7", 13, 1 },
                    { 8, 8, "Class8", 12, 1 },
                    { 9, 9, "Class9", 11, 1 },
                    { 10, 10, "Class10", 10, 1 }
                });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "MemberId", "YogaClassId", "Discount", "EnrollDate" },
                values: new object[,]
                {
                    { 1, 4, 0.0, new DateTime(2023, 7, 11, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 2, 2, 0.0, new DateTime(2023, 7, 11, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 3, 4, 0.0, new DateTime(2023, 7, 11, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 4, 2, 0.0, new DateTime(2023, 7, 11, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 5, 4, 0.0, new DateTime(2023, 7, 11, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 6, 2, 0.0, new DateTime(2023, 7, 11, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 7, 4, 0.0, new DateTime(2023, 7, 11, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 8, 2, 0.0, new DateTime(2023, 7, 11, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 9, 4, 0.0, new DateTime(2023, 7, 11, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 10, 2, 0.0, new DateTime(2023, 7, 11, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 11, 8, 0.0, new DateTime(2023, 7, 11, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 12, 6, 0.0, new DateTime(2023, 7, 11, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 13, 8, 0.0, new DateTime(2023, 7, 11, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 14, 6, 0.0, new DateTime(2023, 7, 11, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 15, 8, 0.0, new DateTime(2023, 7, 11, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 16, 6, 0.0, new DateTime(2023, 7, 11, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 17, 8, 0.0, new DateTime(2023, 7, 11, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 18, 6, 0.0, new DateTime(2023, 7, 11, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 19, 8, 0.0, new DateTime(2023, 7, 11, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 20, 6, 0.0, new DateTime(2023, 7, 11, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 21, 3, 0.0, new DateTime(2023, 7, 11, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 22, 1, 0.0, new DateTime(2023, 7, 11, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 23, 3, 0.0, new DateTime(2023, 7, 11, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 24, 1, 0.0, new DateTime(2023, 7, 11, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 25, 3, 0.0, new DateTime(2023, 7, 11, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 26, 1, 0.0, new DateTime(2023, 7, 11, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 27, 3, 0.0, new DateTime(2023, 7, 11, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 28, 1, 0.0, new DateTime(2023, 7, 11, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 29, 3, 0.0, new DateTime(2023, 7, 11, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 30, 1, 0.0, new DateTime(2023, 7, 11, 0, 0, 0, 0, DateTimeKind.Local) }
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
                    { 31, new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2023, 7, 11, 0, 0, 0, 0, DateTimeKind.Local), 31, 4 },
                    { 32, new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2023, 7, 11, 0, 0, 0, 0, DateTimeKind.Local), 32, 2 },
                    { 33, new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2023, 7, 11, 0, 0, 0, 0, DateTimeKind.Local), 33, 4 },
                    { 34, new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2023, 7, 11, 0, 0, 0, 0, DateTimeKind.Local), 34, 2 },
                    { 35, new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2023, 7, 11, 0, 0, 0, 0, DateTimeKind.Local), 35, 4 }
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
