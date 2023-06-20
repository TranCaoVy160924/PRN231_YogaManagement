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
                    { 1, 0, "HCM", "2dd85fa4-2f9a-4823-a64f-ec624e2b226d", "member1@gmail.com", true, "Name1", "LastName1", false, null, "member1@gmail.com", "usermember1", "AQAAAAIAAYagAAAAEP5DIn7MtV9Z+9DZclY9FMCzrzhEHYFewuf0Kv6313R8CJHSzfujT7Oe8XCeKox/nQ==", null, false, "", true, false, "UserMember1" },
                    { 2, 0, "HCM", "a30a375f-ef11-44aa-acbc-e9e941c07c68", "member2@gmail.com", true, "Name2", "LastName2", false, null, "member2@gmail.com", "usermember2", "AQAAAAIAAYagAAAAEJcUhq9RkBwtCoe0nya9HVKoYC0E6Ps1GHzdux2rOStrPvNpyllRhnevEyBkHAIoLw==", null, false, "", true, false, "UserMember2" },
                    { 3, 0, "HCM", "41b2c4a6-b0a4-497a-81ee-dea00b7862c8", "member3@gmail.com", true, "Name3", "LastName3", false, null, "member3@gmail.com", "usermember3", "AQAAAAIAAYagAAAAEFDSY0DpgOubUfTGVixkVgHDNLClZHNGC9GlRVqyZD/I0xrwVZYxxbuweyUC+CjW/g==", null, false, "", true, false, "UserMember3" },
                    { 4, 0, "HCM", "fc88223c-941d-4404-9074-21fd5acad5b4", "member4@gmail.com", true, "Name4", "LastName4", false, null, "member4@gmail.com", "usermember4", "AQAAAAIAAYagAAAAEGEzH9kABU6BDtuYYQ9lkoH8QzWhLzTAGKESe6rjQ8CSn/kW6Mug8uA3/NRwHreosw==", null, false, "", true, false, "UserMember4" },
                    { 5, 0, "HCM", "a9c79425-ce59-4fd9-8a35-9714b5105867", "member5@gmail.com", true, "Name5", "LastName5", false, null, "member5@gmail.com", "usermember5", "AQAAAAIAAYagAAAAEDDJroH+HxUJPgXl0WWVOVINV0vYuKX3Il9WaKTUWFYqL/BDECUoqPipdBlQyHpwAQ==", null, false, "", true, false, "UserMember5" },
                    { 6, 0, "HCM", "f86fb4cb-d876-4cf2-9bcc-8d7b082c9580", "member6@gmail.com", true, "Name6", "LastName6", false, null, "member6@gmail.com", "usermember6", "AQAAAAIAAYagAAAAEJ+jJIHL6lm1F7aohVTzA3obxg19sHBNb0fsaN4zDAcvsk/dG8Eey/e/5XZTfdiUiQ==", null, false, "", true, false, "UserMember6" },
                    { 7, 0, "HCM", "6bc7c26e-227e-42fa-9ddd-8f6aed906315", "member7@gmail.com", true, "Name7", "LastName7", false, null, "member7@gmail.com", "usermember7", "AQAAAAIAAYagAAAAEPMctP/MOHW7W8ebv+VHakbv3eO+/Q5Wi67btwv/rrsmJD+10R2jPMcr1dGlE02Xow==", null, false, "", true, false, "UserMember7" },
                    { 8, 0, "HCM", "77cd4fe3-a03d-4d8e-adf0-f5fa7a843a66", "member8@gmail.com", true, "Name8", "LastName8", false, null, "member8@gmail.com", "usermember8", "AQAAAAIAAYagAAAAEOvoJNzeO++BHgjcffuU3umJY7bERqn6frRtg6TvLa3EONkcBT5yZX/mE6i3D9RkyQ==", null, false, "", true, false, "UserMember8" },
                    { 9, 0, "HCM", "564d8453-ff09-40f4-b5e7-729dd7ae899d", "member9@gmail.com", true, "Name9", "LastName9", false, null, "member9@gmail.com", "usermember9", "AQAAAAIAAYagAAAAELo9jF5bFPeU+amK1X0oIf7JYnu2//QzPTQuzJgdLvkKOkzHpL/R+TL3sZ3u8ygrAA==", null, false, "", true, false, "UserMember9" },
                    { 10, 0, "HCM", "d8b1cb2b-1e40-4dde-98a8-982f5b0a9a1e", "member10@gmail.com", true, "Name10", "LastName10", false, null, "member10@gmail.com", "usermember10", "AQAAAAIAAYagAAAAECoHN/vbFAIZNRwe1Pg8LjXNIyFmIdUeeJGJlr9wCkTVRZ/LDBnXC+xQ8GzKiID49Q==", null, false, "", true, false, "UserMember10" },
                    { 11, 0, "HCM", "4fdd8db8-a5e3-423d-9a46-81c23b294fe5", "member11@gmail.com", true, "Name11", "LastName11", false, null, "member11@gmail.com", "usermember11", "AQAAAAIAAYagAAAAEFOeP2wQJ0uNPO1+xJHJEDr6nd2+cQWQZ6w7OKSSaGJks/hm94Yk7ggw88WMXe+u1g==", null, false, "", true, false, "UserMember11" },
                    { 12, 0, "HCM", "bb2e6e5c-7d01-414d-952a-d540c7377af5", "member12@gmail.com", true, "Name12", "LastName12", false, null, "member12@gmail.com", "usermember12", "AQAAAAIAAYagAAAAEL23YTWxVtJCrZjzQsVBZFnA6YlFW9NeZgQJ04wwaVW03BH1EQ5LI//0CywPqRgrPg==", null, false, "", true, false, "UserMember12" },
                    { 13, 0, "HCM", "db32b366-ced7-4ae3-b4f8-aa433b157791", "member13@gmail.com", true, "Name13", "LastName13", false, null, "member13@gmail.com", "usermember13", "AQAAAAIAAYagAAAAEHH8zkWWinROHByMG2rXI/1aL6h9ccs5YxFSnt4Q0+qaspDOk9ZL2GKCy3Tlhboj5Q==", null, false, "", true, false, "UserMember13" },
                    { 14, 0, "HCM", "e93e2a35-9bfe-4bae-84fb-00ae6b6bf745", "member14@gmail.com", true, "Name14", "LastName14", false, null, "member14@gmail.com", "usermember14", "AQAAAAIAAYagAAAAECupYzuHtbBuCURn8EMWvX6G9qcTNqVztTJUnLOC5+eHGeu3P6BTQX0aaXJLEYN1Kg==", null, false, "", true, false, "UserMember14" },
                    { 15, 0, "HCM", "4c36b2b5-cdd2-419e-bbd9-f9589e659e55", "member15@gmail.com", true, "Name15", "LastName15", false, null, "member15@gmail.com", "usermember15", "AQAAAAIAAYagAAAAEPuyHrL1CAtPS3pnVtZG1elyo04CKcrtzT2KGm7UW22MeX7/a2P+/miLN2D9bAjxXA==", null, false, "", true, false, "UserMember15" },
                    { 16, 0, "HCM", "286707db-3ea7-4a6e-8e4a-2d1e3eb8981a", "member16@gmail.com", true, "Name16", "LastName16", false, null, "member16@gmail.com", "usermember16", "AQAAAAIAAYagAAAAELVsN4XHaOXL9x40cr7QaPLgPRqPqaFQ4b0I4i+k3W/r5rQyyqBmUbZkDga/P3ZYcQ==", null, false, "", true, false, "UserMember16" },
                    { 17, 0, "HCM", "68e3e9c7-d1c5-4e7c-ae29-ef68cee699a9", "member17@gmail.com", true, "Name17", "LastName17", false, null, "member17@gmail.com", "usermember17", "AQAAAAIAAYagAAAAEI+7O9ryeVZvNkRX3kAgnmDttMLYxZJWXQml7Stkumt8wQaRhhESQS89g8aCQluaVA==", null, false, "", true, false, "UserMember17" },
                    { 18, 0, "HCM", "53698c6d-db75-468d-8bfd-43cfbf470361", "member18@gmail.com", true, "Name18", "LastName18", false, null, "member18@gmail.com", "usermember18", "AQAAAAIAAYagAAAAEGYb9T6sAlebETZXkEHv4PjbmnLw97uBKcekP1ZxZ25jB/gwCRkjhMij9UslYy2PXQ==", null, false, "", true, false, "UserMember18" },
                    { 19, 0, "HCM", "d3177431-1fe8-44a4-b28e-fd762be7731c", "member19@gmail.com", true, "Name19", "LastName19", false, null, "member19@gmail.com", "usermember19", "AQAAAAIAAYagAAAAEDkQProAYNgFo+MopBaT6Jz31XW/QgqNwKcSR/5a4ynNpsgD9rBclXQuNtgpApP+eA==", null, false, "", true, false, "UserMember19" },
                    { 20, 0, "HCM", "eb3d5156-0374-4f12-a061-bfa133fce504", "member20@gmail.com", true, "Name20", "LastName20", false, null, "member20@gmail.com", "usermember20", "AQAAAAIAAYagAAAAEKYd+F7+DijbBKcSmHfC5SA4/4kmCE2EiM9ljtZCr/DYP2Rog1F29fGEYKbO/uFNCA==", null, false, "", true, false, "UserMember20" },
                    { 21, 0, "HCM", "d5fb8044-1544-4026-88af-fd8fec3a82cc", "member21@gmail.com", true, "Name21", "LastName21", false, null, "member21@gmail.com", "usermember21", "AQAAAAIAAYagAAAAEBNXJINvQjJF3LsM82Ja2r+eBPSzVscOyr4ipnolXvn1nuAZ9+EIIZJpNguVGD9dlw==", null, false, "", true, false, "UserMember21" },
                    { 22, 0, "HCM", "c288507a-337c-495d-842b-7b13fcf5503d", "member22@gmail.com", true, "Name22", "LastName22", false, null, "member22@gmail.com", "usermember22", "AQAAAAIAAYagAAAAEMhQ+EQkttIgS0x5cgKy5+U7GZ9l/CZWDOO6SSULQF/ATyae0qzYL/AO+2K+yOOWlQ==", null, false, "", true, false, "UserMember22" },
                    { 23, 0, "HCM", "bc661a04-cd49-436d-9a8c-9b5fdf78f64b", "member23@gmail.com", true, "Name23", "LastName23", false, null, "member23@gmail.com", "usermember23", "AQAAAAIAAYagAAAAEK7v3IdaEKJeTmwc/GH7vfxCubcVEIvOFdweNriVy9ZDspzMe4X+GFiaVhMHxlvbxw==", null, false, "", true, false, "UserMember23" },
                    { 24, 0, "HCM", "419dee0f-c446-4505-8c11-e0ee7c312f91", "member24@gmail.com", true, "Name24", "LastName24", false, null, "member24@gmail.com", "usermember24", "AQAAAAIAAYagAAAAEOegBFK/mizO46Jgv1hKec9rVbkZz7C2G3TMjkCSZ6oPHgUa74/qDBbo7YPeC3bUew==", null, false, "", true, false, "UserMember24" },
                    { 25, 0, "HCM", "ec111eb8-090a-4553-862f-d0a26acc1d91", "member25@gmail.com", true, "Name25", "LastName25", false, null, "member25@gmail.com", "usermember25", "AQAAAAIAAYagAAAAEJX/bFh3uv8gjP5q2Ayhm90BNPyHPaGocJFnS9WRGWDi/eHHadIIMXjHP87Xt5ViMQ==", null, false, "", true, false, "UserMember25" },
                    { 26, 0, "HCM", "ef6d80d2-baa1-4af2-b076-657a6e61a7e8", "member26@gmail.com", true, "Name26", "LastName26", false, null, "member26@gmail.com", "usermember26", "AQAAAAIAAYagAAAAEGnYu7zMNGrJbYVmwrPhbNkRvGenvtXdTuRrf46pa4s1n9ea0rCDGNIWX5r2YAmoSA==", null, false, "", true, false, "UserMember26" },
                    { 27, 0, "HCM", "1edaeb68-cce0-4474-9983-1cd49f5f9a92", "member27@gmail.com", true, "Name27", "LastName27", false, null, "member27@gmail.com", "usermember27", "AQAAAAIAAYagAAAAEIUXDEezCqeUaMtitgKLkmtKYSP5+KjAokUm6wzqYGE8+8s9HyHHHkbvQ5mOWeMkkg==", null, false, "", true, false, "UserMember27" },
                    { 28, 0, "HCM", "164685c0-503c-42d1-8f18-0168b8108959", "member28@gmail.com", true, "Name28", "LastName28", false, null, "member28@gmail.com", "usermember28", "AQAAAAIAAYagAAAAEPxa3wR9ig3sWAcPG/+VjNt+KJI4FA5f/dzFj3uyiLhdbjpUZE65lOXuRlzOVpBYLA==", null, false, "", true, false, "UserMember28" },
                    { 29, 0, "HCM", "d5f41529-6683-4ede-ade8-8c8efb1f7c7d", "member29@gmail.com", true, "Name29", "LastName29", false, null, "member29@gmail.com", "usermember29", "AQAAAAIAAYagAAAAEIzBQNYmffY5RprZCRRie5Mc/hHiixIBXzLGPZ+qUenKT6Wzce0yv80W6rSH/SosWQ==", null, false, "", true, false, "UserMember29" },
                    { 30, 0, "HCM", "65a1e19c-17f5-4ead-a9ab-964a3e818291", "member30@gmail.com", true, "Name30", "LastName30", false, null, "member30@gmail.com", "usermember30", "AQAAAAIAAYagAAAAEDGBusIo0AgBa7lCM6JEdJT1TOOGLQNhydwfG2R2eYdNmEWbueR8CmKMOh6pAlepqg==", null, false, "", true, false, "UserMember30" },
                    { 31, 0, "HCM", "7d204102-4537-4e17-8079-6b654519249c", "teacher31@gmail.com", true, "Name31", "LastName31", false, null, "teacher31@gmail.com", "userteacher31", "AQAAAAIAAYagAAAAEH4r6JBcR95sUIjrbBzEUB1VrXsgbC6vGFESDAi6oOKgE0N9bklmid7ZA/oCmHPdZw==", null, false, "", true, false, "UserTeacher31" },
                    { 32, 0, "HCM", "d9eb7147-0106-4baa-81f0-6571c9b0cc83", "teacher32@gmail.com", true, "Name32", "LastName32", false, null, "teacher32@gmail.com", "userteacher32", "AQAAAAIAAYagAAAAEEMD3HbwfntBvkVBPercnbaw32/GAZr6TOxkeiGpf0+wgJfFNqGX0E1cgjkicBVw8w==", null, false, "", true, false, "UserTeacher32" },
                    { 33, 0, "HCM", "941e400f-debb-4804-8e58-c227a2bda4f0", "teacher33@gmail.com", true, "Name33", "LastName33", false, null, "teacher33@gmail.com", "userteacher33", "AQAAAAIAAYagAAAAEB1qVOsFB5UWbSrqxouUEcWMZ0xk8Ka08zf0AvA1pTJhF7EroD2yX6t86dpYOG0gpA==", null, false, "", true, false, "UserTeacher33" },
                    { 34, 0, "HCM", "590cff63-b3a5-48be-9faa-f5e927b60a81", "teacher34@gmail.com", true, "Name34", "LastName34", false, null, "teacher34@gmail.com", "userteacher34", "AQAAAAIAAYagAAAAEPhLChTAScoO1tDhDYS3BvIhVoKQQB7OIm0Vz9i5APirK5JxGagm7rHArBI0KZ1eOw==", null, false, "", true, false, "UserTeacher34" },
                    { 35, 0, "HCM", "9acd71d0-1c1d-4ac9-aad0-236277737e6d", "teacher35@gmail.com", true, "Name35", "LastName35", false, null, "teacher35@gmail.com", "userteacher35", "AQAAAAIAAYagAAAAEJUAyaGCw08Ur1mELDh/ccH1M9Aj+j8y16WI+mtKIrdUdjlN3eqWWIroRny9ZHtn9A==", null, false, "", true, false, "UserTeacher35" },
                    { 36, 0, "HCM", "1db59955-60f2-4c8a-a6be-ff44103238b1", "teacher36@gmail.com", true, "Name36", "LastName36", false, null, "teacher36@gmail.com", "userteacher36", "AQAAAAIAAYagAAAAEHUit7m9WnEIXdjSEjZX/6wCoTLGGzxNS8K/wrqAKQ8pKHj+LrqPeccNoGCOAcqmGw==", null, false, "", true, false, "UserTeacher36" },
                    { 37, 0, "HCM", "2f686828-54aa-416f-9366-e04b41a35bb8", "teacher37@gmail.com", true, "Name37", "LastName37", false, null, "teacher37@gmail.com", "userteacher37", "AQAAAAIAAYagAAAAEBn/aWNMjPx3v2gc//UkhkqRxjvR00WqvGx/Au+bVZ78n8tCDf638apgiK9EUgXAIA==", null, false, "", true, false, "UserTeacher37" },
                    { 38, 0, "HCM", "aaa9feee-f013-42b4-8491-2bbf313f2e6c", "teacher38@gmail.com", true, "Name38", "LastName38", false, null, "teacher38@gmail.com", "userteacher38", "AQAAAAIAAYagAAAAEOyUzeJQ5+YuXjanRWGfvQwDhh56/6NRU1l20YVRLGEnoFsMWUGIz5+9JeoVEk8d/g==", null, false, "", true, false, "UserTeacher38" },
                    { 39, 0, "HCM", "ac6c5d7e-68b5-4cbe-9eb5-10b4e9aa2160", "teacher39@gmail.com", true, "Name39", "LastName39", false, null, "teacher39@gmail.com", "userteacher39", "AQAAAAIAAYagAAAAEEOB73fuU7Cxp4Z59Q+NWua0CM0xLBHKX9A0svhjQ4zBkZzjSlE/kvsQLXiA8Pa4Dw==", null, false, "", true, false, "UserTeacher39" },
                    { 40, 0, "HCM", "599ce621-dd14-4cbb-b9bb-84a7efe3b40d", "teacher40@gmail.com", true, "Name40", "LastName40", false, null, "teacher40@gmail.com", "userteacher40", "AQAAAAIAAYagAAAAEBbcVmelRnhMf7z34g5HgJ6bS7nLAhBcYNdpPb1VzPIK/Ayt8Vz3VguqYPjVr2BxgA==", null, false, "", true, false, "UserTeacher40" },
                    { 41, 0, "HCM", "b05680af-3d30-4213-acc0-f4dae052c647", "staff41@gmail.com", true, "Name41", "LastName41", false, null, "staff41@gmail.com", "userstaff41", "AQAAAAIAAYagAAAAECdxmJL913scXpY/m9dDd+FEniyJcH3gAXHLH8p+T/arCKen9CnEUo4c50nflxcyrw==", null, false, "", true, false, "UserStaff41" },
                    { 42, 0, "HCM", "df2ca78f-ed08-42e7-bc48-5c9c96d163a8", "staff42@gmail.com", true, "Name42", "LastName42", false, null, "staff42@gmail.com", "userstaff42", "AQAAAAIAAYagAAAAEIsG7hVhFiqpHK5/+1gKaTT3Ruw8CrMfN3EtXSaTxqm+Q8P1EuQ2KXfiJW5RPS8dFQ==", null, false, "", true, false, "UserStaff42" },
                    { 43, 0, "HCM", "76d9967f-6cfc-4d25-9428-d1f72bfe8956", "staff43@gmail.com", true, "Name43", "LastName43", false, null, "staff43@gmail.com", "userstaff43", "AQAAAAIAAYagAAAAEL390xXcH5GQxJ2fR3ij1IAWdPUWo0HDHXmWp+jzlpy7MT3FnBoxz82iEL66eLZaNQ==", null, false, "", true, false, "UserStaff43" },
                    { 44, 0, "HCM", "be2dc729-c3fd-460b-8a44-37a7df14a671", "staff44@gmail.com", true, "Name44", "LastName44", false, null, "staff44@gmail.com", "userstaff44", "AQAAAAIAAYagAAAAEIU4bfTJ6Q9CXgVH3yLsgsuCe3WJbnldOdTA7g1rNAyhYVXe1/x7Fo+i1LfKrdz/WQ==", null, false, "", true, false, "UserStaff44" },
                    { 45, 0, "HCM", "0fc30724-e6ab-449e-a67d-47164c2b0068", "staff45@gmail.com", true, "Name45", "LastName45", false, null, "staff45@gmail.com", "userstaff45", "AQAAAAIAAYagAAAAEEHO/otjAd1jI+3rJbA4+++6Cx148cKfJAp4SPI81RthGjs0l0hFIVvks0eebHLe0Q==", null, false, "", true, false, "UserStaff45" },
                    { 46, 0, "HCM", "5d9a91e3-cd08-47a3-ac11-9fda8208106c", "admin46@gmail.com", true, "Name46", "LastName46", false, null, "admin46@gmail.com", "useradmin46", "AQAAAAIAAYagAAAAEIHW7PYbs1lfDd8LF3Ekb7U20CbH9O3wpddyLSF6de45qadVRWYf5rBY/bYDF7LkfA==", null, false, "", true, false, "UserAdmin46" }
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
                    { 1, 1, "Yoga course number 1", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course1", 100.0, new DateTime(2023, 6, 20, 13, 38, 25, 3, DateTimeKind.Local).AddTicks(1924) },
                    { 2, 2, "Yoga course number 2", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course2", 200.0, new DateTime(2023, 6, 20, 13, 38, 25, 3, DateTimeKind.Local).AddTicks(1952) },
                    { 3, 3, "Yoga course number 3", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course3", 300.0, new DateTime(2023, 6, 20, 13, 38, 25, 3, DateTimeKind.Local).AddTicks(1959) },
                    { 4, 4, "Yoga course number 4", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course4", 400.0, new DateTime(2023, 6, 20, 13, 38, 25, 3, DateTimeKind.Local).AddTicks(1965) },
                    { 5, 5, "Yoga course number 5", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course5", 500.0, new DateTime(2023, 6, 20, 13, 38, 25, 3, DateTimeKind.Local).AddTicks(1971) },
                    { 6, 6, "Yoga course number 6", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course6", 600.0, new DateTime(2023, 6, 20, 13, 38, 25, 3, DateTimeKind.Local).AddTicks(1978) },
                    { 7, 7, "Yoga course number 7", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course7", 700.0, new DateTime(2023, 6, 20, 13, 38, 25, 3, DateTimeKind.Local).AddTicks(1985) },
                    { 8, 8, "Yoga course number 8", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course8", 800.0, new DateTime(2023, 6, 20, 13, 38, 25, 3, DateTimeKind.Local).AddTicks(1991) },
                    { 9, 9, "Yoga course number 9", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course9", 900.0, new DateTime(2023, 6, 20, 13, 38, 25, 3, DateTimeKind.Local).AddTicks(1997) },
                    { 10, 10, "Yoga course number 10", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course10", 1000.0, new DateTime(2023, 6, 20, 13, 38, 25, 3, DateTimeKind.Local).AddTicks(2005) }
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
