using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YogaManagement.Database.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
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
                name: "SystemWallet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Balance = table.Column<double>(type: "float", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemWallet", x => x.Id);
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
                name: "Wallets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Balance = table.Column<double>(type: "float", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wallets_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
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
                name: "YogaClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
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
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<double>(type: "float", nullable: false),
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
                    { 1, 0, "HCM", "9f0fe71e-5761-4b70-850d-a61e479aec1c", "member1@gmail.com", true, "Name1", "LastName1", false, null, "member1@gmail.com", "usermember1", "AQAAAAIAAYagAAAAEJ1LT2Kr4SLg2gGdK+2ivIkbZDuWcNxPJCBN1DIXZES76eJm926AuQCTUXz9uJkvTQ==", null, false, "", true, false, "UserMember1" },
                    { 2, 0, "HCM", "ce7052b7-4f5d-4425-af5a-3b96f23f3985", "member2@gmail.com", true, "Name2", "LastName2", false, null, "member2@gmail.com", "usermember2", "AQAAAAIAAYagAAAAEI/VuOlG/t+rFhkWD/beOnCZNPSxJ5ZtV4OfBiHhboiKRRdTDZEPC7xmwtYy/EtSXQ==", null, false, "", true, false, "UserMember2" },
                    { 3, 0, "HCM", "f8d6c796-b7b6-4f81-8225-5a42c307d058", "member3@gmail.com", true, "Name3", "LastName3", false, null, "member3@gmail.com", "usermember3", "AQAAAAIAAYagAAAAEP/eL/jtWIHPxPApIEz+6yZQQd2HQ0URydl/0msZWX2sBYod1YGyAbgkkaVCX9pR8w==", null, false, "", true, false, "UserMember3" },
                    { 4, 0, "HCM", "3d25b1a2-9020-468c-bdef-b13d3e137d07", "member4@gmail.com", true, "Name4", "LastName4", false, null, "member4@gmail.com", "usermember4", "AQAAAAIAAYagAAAAEFETYcsJsWh6sZBns5elMepgP+mDHgS+97nudoCfcAp4F14UpPmqPAyP/cqcsoDI2g==", null, false, "", true, false, "UserMember4" },
                    { 5, 0, "HCM", "437469f3-1e38-40db-90b8-cd37146c2c47", "member5@gmail.com", true, "Name5", "LastName5", false, null, "member5@gmail.com", "usermember5", "AQAAAAIAAYagAAAAECdrIz+BRafgshzvkP6iAA3F/cIXoz4m5eNBLbQhI7HAzhMyR8lCRkI1ZBCyMK/LQg==", null, false, "", true, false, "UserMember5" },
                    { 6, 0, "HCM", "bad45fa4-d2f2-43f2-858a-031f232c32e0", "member6@gmail.com", true, "Name6", "LastName6", false, null, "member6@gmail.com", "usermember6", "AQAAAAIAAYagAAAAEKAd5As6cmN0IFlKevUYy/+/Pz7IgEvmcNWO9/CmSdotqO2A95vkbpyaValiPzKj+A==", null, false, "", true, false, "UserMember6" },
                    { 7, 0, "HCM", "506d6096-0f4f-48ed-98ef-77e4f0a763e5", "member7@gmail.com", true, "Name7", "LastName7", false, null, "member7@gmail.com", "usermember7", "AQAAAAIAAYagAAAAECUS92u/soOvWLUWCCKTynPnANna8gQDvZzFXzXyQdix/YRyztMpXtyhWcvreAh9Dw==", null, false, "", true, false, "UserMember7" },
                    { 8, 0, "HCM", "308c733e-71f7-4121-be54-7162dde944ce", "member8@gmail.com", true, "Name8", "LastName8", false, null, "member8@gmail.com", "usermember8", "AQAAAAIAAYagAAAAEBWV6aH1boyDfBksO4Io9rurxyv/AFenPVYZplnhtzSACBmkaB+cdM+ZGManQ0gHgg==", null, false, "", true, false, "UserMember8" },
                    { 9, 0, "HCM", "a40d9551-0d9f-41d4-bfd7-4823bdf4b2f2", "member9@gmail.com", true, "Name9", "LastName9", false, null, "member9@gmail.com", "usermember9", "AQAAAAIAAYagAAAAEPbvdI3VABwglNuRiNjNaEbr4PJa188GSTodBUFDCV2tJglMkHO/qoXgsHeqvmhqvw==", null, false, "", true, false, "UserMember9" },
                    { 10, 0, "HCM", "f191c007-3ab8-4ec5-923f-9bfcf024bf7a", "member10@gmail.com", true, "Name10", "LastName10", false, null, "member10@gmail.com", "usermember10", "AQAAAAIAAYagAAAAEDehhXAnuyZlPzgGGkngvafhpdposD4/8qaQgWq8MWLaC8BOiheEaHCLYTYcraDfTg==", null, false, "", true, false, "UserMember10" },
                    { 11, 0, "HCM", "003a8cab-955b-437f-9130-3514948009a4", "member11@gmail.com", true, "Name11", "LastName11", false, null, "member11@gmail.com", "usermember11", "AQAAAAIAAYagAAAAEHydBbM3Sq2MSNl+N8zOWNwA6/2cuWK7JfRCNLa9h6z3O6veCrhkBf36RybSq2lcjA==", null, false, "", true, false, "UserMember11" },
                    { 12, 0, "HCM", "dbfa7490-0e3e-421e-92ea-3dc8ac2cdb22", "member12@gmail.com", true, "Name12", "LastName12", false, null, "member12@gmail.com", "usermember12", "AQAAAAIAAYagAAAAEE9v7ZUEAtWfe3ry180ycw3HRPG+n4fyqgzJZ2+QdCib5SE5TsYxdbdLu1XEi5QRrQ==", null, false, "", true, false, "UserMember12" },
                    { 13, 0, "HCM", "f558729f-55ce-4727-8009-a32369e5abb9", "member13@gmail.com", true, "Name13", "LastName13", false, null, "member13@gmail.com", "usermember13", "AQAAAAIAAYagAAAAEGqJakOQnNuvvykU4ZYyplqL9NVfce65EteG2GgUMr+2a10Q/Je7FDvQi65b/R2+hw==", null, false, "", true, false, "UserMember13" },
                    { 14, 0, "HCM", "4db936c3-7bd1-430a-9b6b-4bb69f546de0", "member14@gmail.com", true, "Name14", "LastName14", false, null, "member14@gmail.com", "usermember14", "AQAAAAIAAYagAAAAEAN8qLMTw5Bi702TDCRlq9JJIGKaSLEhU9ondGJqvAlTlv85dbtd1t4TLqn9HBDKwA==", null, false, "", true, false, "UserMember14" },
                    { 15, 0, "HCM", "e8097be9-1abc-4d6a-81c6-f90e4ae59fc9", "member15@gmail.com", true, "Name15", "LastName15", false, null, "member15@gmail.com", "usermember15", "AQAAAAIAAYagAAAAEFQI1M0+En1gnJZUD70u/yq+k18UVOk2YnDmGAJ5nALPH0xaLDMECq4wKNvmKtcaJw==", null, false, "", true, false, "UserMember15" },
                    { 16, 0, "HCM", "497c684b-06fe-47ab-b295-b2c7e6615be9", "member16@gmail.com", true, "Name16", "LastName16", false, null, "member16@gmail.com", "usermember16", "AQAAAAIAAYagAAAAEC+nogR83MMaxN7rTEEwIrV9Oouo1pEFM5Mr3rwgG1N13b9ykxw8HbftrEiiJe5vAg==", null, false, "", true, false, "UserMember16" },
                    { 17, 0, "HCM", "045a6dff-3956-4095-a49a-b4397134594a", "member17@gmail.com", true, "Name17", "LastName17", false, null, "member17@gmail.com", "usermember17", "AQAAAAIAAYagAAAAEKEeJQCPePSjBdvsMZ5Q8KjTruSET0yVkmF9gg62QjfDNjgsMNvVVsch3+g15MZcEg==", null, false, "", true, false, "UserMember17" },
                    { 18, 0, "HCM", "2becbae8-e9c8-4d94-990a-09162edd75dc", "member18@gmail.com", true, "Name18", "LastName18", false, null, "member18@gmail.com", "usermember18", "AQAAAAIAAYagAAAAEFu3clK/63Nv/0eqL3oajzorXp12vwazE5h3ayhV8Q3W4vlW9R5Gn0aafNX9XGapjw==", null, false, "", true, false, "UserMember18" },
                    { 19, 0, "HCM", "46de7948-c360-48cf-a527-b81ebec88fc1", "member19@gmail.com", true, "Name19", "LastName19", false, null, "member19@gmail.com", "usermember19", "AQAAAAIAAYagAAAAEJMoXvrGqRs4XqBvS2eeipZXMZdyKUaU4bDWLiuGnsXmCrBFK3wSupOxk8CU9DTtEQ==", null, false, "", true, false, "UserMember19" },
                    { 20, 0, "HCM", "1a3c36c1-683e-464e-bc66-1ecc6dbfb121", "member20@gmail.com", true, "Name20", "LastName20", false, null, "member20@gmail.com", "usermember20", "AQAAAAIAAYagAAAAEC5rQYPdmWdXQQZfilRenaPf9O8CcVWXn7ech+4tqB6jmx5atYyUHc6CZo/yktXnnA==", null, false, "", true, false, "UserMember20" },
                    { 21, 0, "HCM", "3d7195b1-ab41-4f71-9770-3b1ac14a711a", "member21@gmail.com", true, "Name21", "LastName21", false, null, "member21@gmail.com", "usermember21", "AQAAAAIAAYagAAAAENMwumiedQelIVHPVO9vpiyU9MaIkqYkqt2DichkwO8ZSaB+x9OLuVzzLjgd2c1RSg==", null, false, "", true, false, "UserMember21" },
                    { 22, 0, "HCM", "d149b744-0ab2-43d0-944d-57a880b7f8e7", "member22@gmail.com", true, "Name22", "LastName22", false, null, "member22@gmail.com", "usermember22", "AQAAAAIAAYagAAAAEBewo6S8TDM13MIBt3pGqSWAZgzYXgwV8gnypB0a0vLCVuHoHCUoObPUMWhOuVZQYw==", null, false, "", true, false, "UserMember22" },
                    { 23, 0, "HCM", "20241457-73a2-4af8-ad25-3282f989cbcc", "member23@gmail.com", true, "Name23", "LastName23", false, null, "member23@gmail.com", "usermember23", "AQAAAAIAAYagAAAAEE7uzuUkmlTeMTPxw2YB0A38s/ONz3XBWQBLT+gI7SmCm8SOQql1c6gSL5H7Ipw1qQ==", null, false, "", true, false, "UserMember23" },
                    { 24, 0, "HCM", "51c822af-49f4-40ae-b410-e11e4ecdc353", "member24@gmail.com", true, "Name24", "LastName24", false, null, "member24@gmail.com", "usermember24", "AQAAAAIAAYagAAAAEJq9ZuIeCWwz8MTIFE8ib4p3O8TnuY9/RoK7w4PDVxzmCs+V/5w7/d0TpvXO42XIow==", null, false, "", true, false, "UserMember24" },
                    { 25, 0, "HCM", "c779d322-5cf8-458c-b973-eeee17497fb0", "member25@gmail.com", true, "Name25", "LastName25", false, null, "member25@gmail.com", "usermember25", "AQAAAAIAAYagAAAAENrMA5uwzsOfP/fklYkIBr2b7UV/HtlIWxsTIbqvr/eajQxb1d3tLPhmgZaVLd0Lng==", null, false, "", true, false, "UserMember25" },
                    { 26, 0, "HCM", "cc2aeffc-6e70-460c-8393-e7d5506cc302", "member26@gmail.com", true, "Name26", "LastName26", false, null, "member26@gmail.com", "usermember26", "AQAAAAIAAYagAAAAEA5+QeBFWUwfE6Y0RksLSccNmtlDLlS8dikHIm3qUU5fb+GA+TRet0w5cEENKtAKEw==", null, false, "", true, false, "UserMember26" },
                    { 27, 0, "HCM", "529aaf27-055e-4a1c-a283-0531f5b660bf", "member27@gmail.com", true, "Name27", "LastName27", false, null, "member27@gmail.com", "usermember27", "AQAAAAIAAYagAAAAEFsTBF4ED4n8uYjxURjU2M222P/FU7gZf1Xz6TRlfUwAeKBABwYgzkGwbT3OTYeFqQ==", null, false, "", true, false, "UserMember27" },
                    { 28, 0, "HCM", "d8909912-da21-4e22-92e3-da11bcea36d0", "member28@gmail.com", true, "Name28", "LastName28", false, null, "member28@gmail.com", "usermember28", "AQAAAAIAAYagAAAAENn5sebM9o+REBsq2+IPDBh1w3F+dFK08IkJUV/midc7XXYLSWd4yybYsA833wRY6w==", null, false, "", true, false, "UserMember28" },
                    { 29, 0, "HCM", "dc408893-8411-4be3-87e2-d825facb3114", "member29@gmail.com", true, "Name29", "LastName29", false, null, "member29@gmail.com", "usermember29", "AQAAAAIAAYagAAAAEOrSj8PujvY69j8+DQFlUq9BcRNVNwSEPSj+2dF2koeAT6///vtvIg8+GhDFPRiulg==", null, false, "", true, false, "UserMember29" },
                    { 30, 0, "HCM", "ad4e1f97-54a5-4718-841f-44e4f7ca97f0", "member30@gmail.com", true, "Name30", "LastName30", false, null, "member30@gmail.com", "usermember30", "AQAAAAIAAYagAAAAEML8Hqg0ZIlNQhBXWJFJX/wJz25j3jeqb00y9B7EBbewMeKCehVy8HtZ+KRJY6tqZA==", null, false, "", true, false, "UserMember30" },
                    { 31, 0, "HCM", "cce636ea-7afd-47be-aaf8-0e4d08529233", "teacher31@gmail.com", true, "Name31", "LastName31", false, null, "teacher31@gmail.com", "userteacher31", "AQAAAAIAAYagAAAAECdlRnACeZqOyljK3HyMal7heHgLUz/EV+26Bg6fywAQ5kHkqnLAWN0IzRGvjNIDFg==", null, false, "", true, false, "UserTeacher31" },
                    { 32, 0, "HCM", "e0838b53-f8e5-4344-a8a1-dc7f3527e346", "teacher32@gmail.com", true, "Name32", "LastName32", false, null, "teacher32@gmail.com", "userteacher32", "AQAAAAIAAYagAAAAEEMjCOyMaSHGu4ax0V9h5k/yo9k6HGH5EpdqegXHeurCGCXHua5Z2aWtiQr88cCU+g==", null, false, "", true, false, "UserTeacher32" },
                    { 33, 0, "HCM", "c3a7e0ec-d4c0-4a05-bd45-2914f762080b", "teacher33@gmail.com", true, "Name33", "LastName33", false, null, "teacher33@gmail.com", "userteacher33", "AQAAAAIAAYagAAAAEHCg2qoPwLR19kRweHFxZY1RC/ClX2TSa8qfnRrPoc/CrFqxd0OGf8dc/8hOf8APMg==", null, false, "", true, false, "UserTeacher33" },
                    { 34, 0, "HCM", "3afbafb9-661a-48fb-a2e4-198477097a10", "teacher34@gmail.com", true, "Name34", "LastName34", false, null, "teacher34@gmail.com", "userteacher34", "AQAAAAIAAYagAAAAEEleW/QClfENA9VFwe3vVZWHuEs/U+0QZhufLgbtfu1oNULO25C+OygpUybSx106Fw==", null, false, "", true, false, "UserTeacher34" },
                    { 35, 0, "HCM", "939918db-5771-4910-985c-ae793c682bc5", "teacher35@gmail.com", true, "Name35", "LastName35", false, null, "teacher35@gmail.com", "userteacher35", "AQAAAAIAAYagAAAAEFIuuVxEpdltFcEZuo96BFSdDMbj/R15hC+j5z1TuV6QCjjqBenWNLWXur2ECYjc3Q==", null, false, "", true, false, "UserTeacher35" },
                    { 36, 0, "HCM", "f4b786c3-bdb4-44b0-bec6-cc573d3bf88d", "teacher36@gmail.com", true, "Name36", "LastName36", false, null, "teacher36@gmail.com", "userteacher36", "AQAAAAIAAYagAAAAEPaJKjoghxxQvHQtKYkGcWc+g3ccpVI0mXoWKAgp32kqcYsoYgzsomusBX83g/etcQ==", null, false, "", true, false, "UserTeacher36" },
                    { 37, 0, "HCM", "7ddc9bcc-726a-4353-acc1-19f86bb225bb", "teacher37@gmail.com", true, "Name37", "LastName37", false, null, "teacher37@gmail.com", "userteacher37", "AQAAAAIAAYagAAAAEGkpp82gyzo6TXf/fmI8gsbLzgYu4mX/tcEzIeNphyw/mvaao3D+M+a2q+El8DYydw==", null, false, "", true, false, "UserTeacher37" },
                    { 38, 0, "HCM", "f29cd98d-fb71-458a-a55f-28e03a686614", "teacher38@gmail.com", true, "Name38", "LastName38", false, null, "teacher38@gmail.com", "userteacher38", "AQAAAAIAAYagAAAAEGguZeNIpg7URJ8G/dPdA2BwiQh9tJjlXRMXcSgskT9FSxmXvMg4CYpdzaU6/nY+Tg==", null, false, "", true, false, "UserTeacher38" },
                    { 39, 0, "HCM", "78abeb40-9f28-4945-921f-dd42fcc8c274", "teacher39@gmail.com", true, "Name39", "LastName39", false, null, "teacher39@gmail.com", "userteacher39", "AQAAAAIAAYagAAAAEFVxnrV36wVzp4KlI29YPbLg1/RtKF6lo+y9owN98og6ibxsEBcXkMlu+zmwtYx/hQ==", null, false, "", true, false, "UserTeacher39" },
                    { 40, 0, "HCM", "f134cb14-4bc4-4c5c-bd26-e986c6314203", "teacher40@gmail.com", true, "Name40", "LastName40", false, null, "teacher40@gmail.com", "userteacher40", "AQAAAAIAAYagAAAAEMROBfFNL85L/DMV0emo58ybQ/PplVtK2MFxC9JSQ53sFoTBv5yA2GPMKEAhNrCvlg==", null, false, "", true, false, "UserTeacher40" },
                    { 41, 0, "HCM", "c753d101-4088-4e03-aa49-26f571060603", "staff41@gmail.com", true, "Name41", "LastName41", false, null, "staff41@gmail.com", "userstaff41", "AQAAAAIAAYagAAAAEOXZ0WO0dRqA7GDRPGhSKAr1uJCC0V/V/D6O+foOwq+K+NsUem05keLG+f9LmwWiog==", null, false, "", true, false, "UserStaff41" },
                    { 42, 0, "HCM", "23028a95-ecf4-42eb-a1a9-a0bfcc1fe819", "staff42@gmail.com", true, "Name42", "LastName42", false, null, "staff42@gmail.com", "userstaff42", "AQAAAAIAAYagAAAAEH5U6ioTdrRc6LniKYGBDazjCjUpK2OIxhq1WhSadjP4Em4GQIWhyDp923EUXyrEIw==", null, false, "", true, false, "UserStaff42" },
                    { 43, 0, "HCM", "be47ce73-dd7f-467c-89c3-a15e914f1568", "staff43@gmail.com", true, "Name43", "LastName43", false, null, "staff43@gmail.com", "userstaff43", "AQAAAAIAAYagAAAAEAQmOv1sBlJ2vwpFWLXq5YrW61PGpXTCeEmO4Z57QQ1DB7ykMy/qvrmbIILgz5RBmg==", null, false, "", true, false, "UserStaff43" },
                    { 44, 0, "HCM", "070fcc20-8dfd-49c4-85c1-ec1151e766c1", "staff44@gmail.com", true, "Name44", "LastName44", false, null, "staff44@gmail.com", "userstaff44", "AQAAAAIAAYagAAAAEI1KIXALJUaYEUY2xv3k6hpInbdK/GV2fpik3+1gIL6nx1AMU2TFKDru9wN8OGoPnA==", null, false, "", true, false, "UserStaff44" },
                    { 45, 0, "HCM", "4b29c1ef-04b9-4c04-9a53-dc3a88dee679", "staff45@gmail.com", true, "Name45", "LastName45", false, null, "staff45@gmail.com", "userstaff45", "AQAAAAIAAYagAAAAEHXxZ6qKk+HNheCNHt8VXdpdOI8b/ws8BeEUOTQosHCsSytI4xniS3VtH/wQ1g2wFA==", null, false, "", true, false, "UserStaff45" },
                    { 46, 0, "HCM", "0517a010-e212-4108-a7e0-736af91ad298", "admin46@gmail.com", true, "Name46", "LastName46", false, null, "admin46@gmail.com", "useradmin46", "AQAAAAIAAYagAAAAED6ola8OCflqN4SoUaRhgt0nfe9ZDt/0ryeb+4PU8GwmSXTcMhfWva/rjSwFu1krrA==", null, false, "", true, false, "UserAdmin46" }
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
                    { 1, 1, "Yoga course number 1", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course1", 100.0, new DateTime(2023, 6, 17, 20, 54, 8, 919, DateTimeKind.Local).AddTicks(1750) },
                    { 2, 2, "Yoga course number 2", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course2", 200.0, new DateTime(2023, 6, 17, 20, 54, 8, 919, DateTimeKind.Local).AddTicks(1772) },
                    { 3, 3, "Yoga course number 3", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course3", 300.0, new DateTime(2023, 6, 17, 20, 54, 8, 919, DateTimeKind.Local).AddTicks(1775) },
                    { 4, 4, "Yoga course number 4", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course4", 400.0, new DateTime(2023, 6, 17, 20, 54, 8, 919, DateTimeKind.Local).AddTicks(1779) },
                    { 5, 5, "Yoga course number 5", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course5", 500.0, new DateTime(2023, 6, 17, 20, 54, 8, 919, DateTimeKind.Local).AddTicks(1782) },
                    { 6, 6, "Yoga course number 6", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course6", 600.0, new DateTime(2023, 6, 17, 20, 54, 8, 919, DateTimeKind.Local).AddTicks(1888) },
                    { 7, 7, "Yoga course number 7", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course7", 700.0, new DateTime(2023, 6, 17, 20, 54, 8, 919, DateTimeKind.Local).AddTicks(1892) },
                    { 8, 8, "Yoga course number 8", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course8", 800.0, new DateTime(2023, 6, 17, 20, 54, 8, 919, DateTimeKind.Local).AddTicks(1895) },
                    { 9, 9, "Yoga course number 9", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course9", 900.0, new DateTime(2023, 6, 17, 20, 54, 8, 919, DateTimeKind.Local).AddTicks(1899) },
                    { 10, 10, "Yoga course number 10", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course10", 1000.0, new DateTime(2023, 6, 17, 20, 54, 8, 919, DateTimeKind.Local).AddTicks(1903) }
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
                table: "YogaClasses",
                columns: new[] { "Id", "CourseId", "Name", "Size", "Status" },
                values: new object[,]
                {
                    { 1, 1, "Class1", 19, true },
                    { 2, 2, "Class2", 18, true },
                    { 3, 3, "Class3", 17, true },
                    { 4, 4, "Class4", 16, true },
                    { 5, 5, "Class5", 15, true },
                    { 6, 6, "Class6", 14, true },
                    { 7, 7, "Class7", 13, true },
                    { 8, 8, "Class8", 12, true },
                    { 9, 9, "Class9", 11, true },
                    { 10, 10, "Class10", 10, true }
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
                name: "IX_TimeSlotYogaClass_YogaClassesId",
                table: "TimeSlotYogaClass",
                column: "YogaClassesId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_WalletId",
                table: "Transactions",
                column: "WalletId");

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_MemberId",
                table: "Wallets",
                column: "MemberId",
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
                name: "SystemWallet");

            migrationBuilder.DropTable(
                name: "TeacherEnrollments");

            migrationBuilder.DropTable(
                name: "TeacherProfileTimeSlot");

            migrationBuilder.DropTable(
                name: "TimeSlotYogaClass");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

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
                name: "Members");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
