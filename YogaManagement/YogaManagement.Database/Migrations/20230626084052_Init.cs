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
                    { 1, 0, "HCM", "be0c06ed-6852-48aa-b765-3bc13f5a4435", "member1@gmail.com", true, "Name1", "LastName1", false, null, "member1@gmail.com", "member1@gmail.com", "AQAAAAIAAYagAAAAENPmrAHFyVOtMj1/38vh4D3zXTtcsh/1AmrxiLeTB/A7+zs1jhy/HesTUSHvnqK2Xg==", null, false, "", true, false, "member1@gmail.com" },
                    { 2, 0, "HCM", "6b94bc50-dfd0-49d9-9d50-9a937adedb53", "member2@gmail.com", true, "Name2", "LastName2", false, null, "member2@gmail.com", "member2@gmail.com", "AQAAAAIAAYagAAAAEI8dIIa+wGzGDBkRRAZBYBLl+rTg0QJso5HV9Pc6EnbX00gGhb/ZA9b1UjHvW7QlCA==", null, false, "", true, false, "member2@gmail.com" },
                    { 3, 0, "HCM", "a5addb3e-0ed3-413c-a887-261ac9faf752", "member3@gmail.com", true, "Name3", "LastName3", false, null, "member3@gmail.com", "member3@gmail.com", "AQAAAAIAAYagAAAAEAGV/oxpx9WafFtR7O2UU8oFtfcokOTsWpi4QejQMJo0W4kZDUufqZTYpnaRj6nXJQ==", null, false, "", true, false, "member3@gmail.com" },
                    { 4, 0, "HCM", "52cb0684-9b97-46b7-8178-1dec9da569d7", "member4@gmail.com", true, "Name4", "LastName4", false, null, "member4@gmail.com", "member4@gmail.com", "AQAAAAIAAYagAAAAEAOWaMdWXAbh/3GO3RF1tr8FN33SoX7UH1fanb59ll/FNuMv2SIiiDd7MVl4TS/ilQ==", null, false, "", true, false, "member4@gmail.com" },
                    { 5, 0, "HCM", "059f983f-c196-4b1d-9320-1b8fbf8864bc", "member5@gmail.com", true, "Name5", "LastName5", false, null, "member5@gmail.com", "member5@gmail.com", "AQAAAAIAAYagAAAAEIWXFA3pJPpB+rQQJzx42y6bOFaRBR6NIkDYnsHC3TNziQ/j/Czqfxs3qvnOyTbUpQ==", null, false, "", true, false, "member5@gmail.com" },
                    { 6, 0, "HCM", "b43c3a1b-5f20-4704-b794-6ecc2146d629", "member6@gmail.com", true, "Name6", "LastName6", false, null, "member6@gmail.com", "member6@gmail.com", "AQAAAAIAAYagAAAAEG8Ybq3PSpzJxTgByW2Y/clZbwB5qrV9pZPeBwbh/5QuiW8Dv1Vy4gvjwPp/FkiFyg==", null, false, "", true, false, "member6@gmail.com" },
                    { 7, 0, "HCM", "e7ce239e-d3ac-439e-97cf-a72d78d10020", "member7@gmail.com", true, "Name7", "LastName7", false, null, "member7@gmail.com", "member7@gmail.com", "AQAAAAIAAYagAAAAEAw9gQQN8yWtmgaZu4Qox6Trgzkx+Cu5JZFvT0O0Jpa3f2hHDFK6Lix8OgGKFV+nvw==", null, false, "", true, false, "member7@gmail.com" },
                    { 8, 0, "HCM", "ab217589-90be-482a-aedf-9cee6a4e4ca5", "member8@gmail.com", true, "Name8", "LastName8", false, null, "member8@gmail.com", "member8@gmail.com", "AQAAAAIAAYagAAAAEEV0ABa4G6T5t0MAigluLra8MV/CbFNuFmqJ4HCPuy45gbdVUgOgzsq5QjYD18yxKA==", null, false, "", true, false, "member8@gmail.com" },
                    { 9, 0, "HCM", "2ed0b6d7-1c83-4431-90fd-a05aa1384b13", "member9@gmail.com", true, "Name9", "LastName9", false, null, "member9@gmail.com", "member9@gmail.com", "AQAAAAIAAYagAAAAEA+Xeo7x5DsyF6qRMZG+qNC1WIHK806ruAJ8jUrR1D5hjy7Ku6Asjf5hkrQe5aJ/4g==", null, false, "", true, false, "member9@gmail.com" },
                    { 10, 0, "HCM", "6b9fde0c-6102-4a5b-a773-545480fe5a6a", "member10@gmail.com", true, "Name10", "LastName10", false, null, "member10@gmail.com", "member10@gmail.com", "AQAAAAIAAYagAAAAEBKXTMBjUIFhBgAHBZhy3/8CWmkN1Q0YuaxZOETzlBvZwxndA+LH40BAeyGHz16JXg==", null, false, "", true, false, "member10@gmail.com" },
                    { 11, 0, "HCM", "78cc0cce-92e9-4c57-9afe-6502cbf81281", "member11@gmail.com", true, "Name11", "LastName11", false, null, "member11@gmail.com", "member11@gmail.com", "AQAAAAIAAYagAAAAEEEf9wmPOU8MWJlzudh0lNrCtpN6oWhPTN0aagms2JMZs1TXtL+QVts1P9/QQHZkSw==", null, false, "", true, false, "member11@gmail.com" },
                    { 12, 0, "HCM", "2bccb9f0-ce68-4294-8b5e-ff627709c22f", "member12@gmail.com", true, "Name12", "LastName12", false, null, "member12@gmail.com", "member12@gmail.com", "AQAAAAIAAYagAAAAEAwp/6rC/0yjxk5VL9p7ZaXFavI1UCeuC7Ra0hqMrJhHw8QKjg4vvIghGeWe3xohuw==", null, false, "", true, false, "member12@gmail.com" },
                    { 13, 0, "HCM", "9182e7c8-37c2-46e0-b610-cdbb836841dc", "member13@gmail.com", true, "Name13", "LastName13", false, null, "member13@gmail.com", "member13@gmail.com", "AQAAAAIAAYagAAAAEMClfMKPlGYBYD4frKKjXp8O2TlZts1fIBA3Sav2kJApyP6m7UQJw/bC4J9yIEf6sg==", null, false, "", true, false, "member13@gmail.com" },
                    { 14, 0, "HCM", "7a73ccb0-e02b-4c83-a49c-52ad10e58582", "member14@gmail.com", true, "Name14", "LastName14", false, null, "member14@gmail.com", "member14@gmail.com", "AQAAAAIAAYagAAAAEFs9IylO5U6ekVvKw6Wt2agFU/Gm+ZAnu3ebbnpW8Ixo8iIyCW+La5IXwo3axo/C1w==", null, false, "", true, false, "member14@gmail.com" },
                    { 15, 0, "HCM", "58f4a986-ac94-4d8b-8b05-ed5758b3e4ce", "member15@gmail.com", true, "Name15", "LastName15", false, null, "member15@gmail.com", "member15@gmail.com", "AQAAAAIAAYagAAAAEHDOsx43/bJIFZXLPHg+vbjuu8XSYodiXB7Akd3hfK19SlhHkI9ZX206YIifPp6ZJA==", null, false, "", true, false, "member15@gmail.com" },
                    { 16, 0, "HCM", "97dffe62-66be-4e23-9577-37836176b548", "member16@gmail.com", true, "Name16", "LastName16", false, null, "member16@gmail.com", "member16@gmail.com", "AQAAAAIAAYagAAAAEBwGqSC1YAsNvtUWuKhJfSlj77rYQvFFomLKvqvaTV2ztKv9UDnzfWotSgooH/BNgg==", null, false, "", true, false, "member16@gmail.com" },
                    { 17, 0, "HCM", "79d3b3f5-e5da-42d8-bd6d-af023b854ef2", "member17@gmail.com", true, "Name17", "LastName17", false, null, "member17@gmail.com", "member17@gmail.com", "AQAAAAIAAYagAAAAEJZ23avCdhK0xorQHVcfjTsuGziK+O+r0RDgYqHEgF/fpKUA7CffQ2ZLDAbJi2G8Yg==", null, false, "", true, false, "member17@gmail.com" },
                    { 18, 0, "HCM", "532f89ab-172a-4dde-a98d-5f6f5514b0fc", "member18@gmail.com", true, "Name18", "LastName18", false, null, "member18@gmail.com", "member18@gmail.com", "AQAAAAIAAYagAAAAEGBUjp/Z0DAYupVrKuRdlKpu0fHYBtuJ/AWpq7L9XY8VejcKbg20aOCpfcAMQbrA3A==", null, false, "", true, false, "member18@gmail.com" },
                    { 19, 0, "HCM", "6ab24874-512b-4932-b5e4-7001d405e1e5", "member19@gmail.com", true, "Name19", "LastName19", false, null, "member19@gmail.com", "member19@gmail.com", "AQAAAAIAAYagAAAAELe6E4x75IWq8pScZgqaT3tBOxYtZivL0UtcbgTWrEs/BqU54ORj8DhM+6IRIgbAcw==", null, false, "", true, false, "member19@gmail.com" },
                    { 20, 0, "HCM", "07ea2b45-30ce-4ad0-97e5-dbdb38e9f864", "member20@gmail.com", true, "Name20", "LastName20", false, null, "member20@gmail.com", "member20@gmail.com", "AQAAAAIAAYagAAAAEBOcyOmXjYNOmPXn+yoTJ06/U9ySwDRzJCxSVvax/YIVPnx6yU2w19qenQxHA7Urnw==", null, false, "", true, false, "member20@gmail.com" },
                    { 21, 0, "HCM", "d75f863b-24ee-414c-b749-06892841dc2c", "member21@gmail.com", true, "Name21", "LastName21", false, null, "member21@gmail.com", "member21@gmail.com", "AQAAAAIAAYagAAAAEHF7W8B7k/6v7mf1f/9fONxB6olxhGdY6bcXfk8PapTKwqsddRBSlV125hDad6bi4A==", null, false, "", true, false, "member21@gmail.com" },
                    { 22, 0, "HCM", "bf53cee3-7409-4591-b8d2-e1b2c7d10987", "member22@gmail.com", true, "Name22", "LastName22", false, null, "member22@gmail.com", "member22@gmail.com", "AQAAAAIAAYagAAAAENonEsVwp7KLQoDjWAIzmmMNbGm5wsgzecT0cL/90kpxaR0rtrojfOnM+ahmyekk+Q==", null, false, "", true, false, "member22@gmail.com" },
                    { 23, 0, "HCM", "5284e7cb-0659-4042-895a-b6c7a2575a7e", "member23@gmail.com", true, "Name23", "LastName23", false, null, "member23@gmail.com", "member23@gmail.com", "AQAAAAIAAYagAAAAEPjGZ5eeHUnJbSilkeTLw8HgD1lu6Znw0GQCOwDiEf6KWC5sgtVFlXC+SqsIMu8amg==", null, false, "", true, false, "member23@gmail.com" },
                    { 24, 0, "HCM", "bed74e72-363b-47b4-8fd2-ff0c36c8329e", "member24@gmail.com", true, "Name24", "LastName24", false, null, "member24@gmail.com", "member24@gmail.com", "AQAAAAIAAYagAAAAEP+moj+9kJ8O/O7G+Y6S8uUznjh1fJNMxtgyjtA6CiRkbO9RpXclOl/O4Vt911i7Eg==", null, false, "", true, false, "member24@gmail.com" },
                    { 25, 0, "HCM", "ddc37910-d04a-465d-bc8d-15a927ec51e4", "member25@gmail.com", true, "Name25", "LastName25", false, null, "member25@gmail.com", "member25@gmail.com", "AQAAAAIAAYagAAAAEFAM0EOLEIEOHcFQ6bzCbpQaQIi91RTX79jHh2Jud5SW90LvO72fWb8OnhjqAFYdHg==", null, false, "", true, false, "member25@gmail.com" },
                    { 26, 0, "HCM", "fc6278b5-e3ef-435c-972b-880441ebf01c", "member26@gmail.com", true, "Name26", "LastName26", false, null, "member26@gmail.com", "member26@gmail.com", "AQAAAAIAAYagAAAAEBME44ema1ttiy1NZpXwbIXS2s0ft2510BOZ5YzC5sUhePDgZxJkyKaBiFkGlD2XVQ==", null, false, "", true, false, "member26@gmail.com" },
                    { 27, 0, "HCM", "f74aaf16-d48c-4e2e-9a95-b843b269a4d3", "member27@gmail.com", true, "Name27", "LastName27", false, null, "member27@gmail.com", "member27@gmail.com", "AQAAAAIAAYagAAAAEK/e3+7lmH66FIko383GIC5H2f7v00tkPb4vXpyy7OhMRGfNQ/vMu7PnEPOEfBOSrg==", null, false, "", true, false, "member27@gmail.com" },
                    { 28, 0, "HCM", "dfb79c7a-e758-4b2f-afe8-c1f7e94822a7", "member28@gmail.com", true, "Name28", "LastName28", false, null, "member28@gmail.com", "member28@gmail.com", "AQAAAAIAAYagAAAAELsqjHQM2oxCMOkIgM7v6L7H/w9jvT2yo0urt4xG+NTxGrTkQKlvcTjlpt/0Y2pDBg==", null, false, "", true, false, "member28@gmail.com" },
                    { 29, 0, "HCM", "647ce047-a112-4e43-8acd-b33d0dbe5792", "member29@gmail.com", true, "Name29", "LastName29", false, null, "member29@gmail.com", "member29@gmail.com", "AQAAAAIAAYagAAAAEHUKENDuXG/cPpYCZ8+jOqx1/mKcn3Sl0s58E3l9bGr5PCkRXydRVulDd8CRI3eBLQ==", null, false, "", true, false, "member29@gmail.com" },
                    { 30, 0, "HCM", "2509f312-00df-4388-87e5-84281c90efec", "member30@gmail.com", true, "Name30", "LastName30", false, null, "member30@gmail.com", "member30@gmail.com", "AQAAAAIAAYagAAAAEN779KsET4uYnAZ0kmU0yoP4UZumkcgpyXg6bw2Y04XA6RVHO20MDTYswv8IkDccLA==", null, false, "", true, false, "member30@gmail.com" },
                    { 31, 0, "HCM", "7bcf7594-4640-4f62-9297-b7eb42e1a43f", "teacher31@gmail.com", true, "Name31", "LastName31", false, null, "teacher31@gmail.com", "teacher31@gmail.com", "AQAAAAIAAYagAAAAEOhG5ILGtfXRGCV+gLsd4AOruFKGceKe6+aBAcaflIe6SdQycVrFrjVOobV8RSs68g==", null, false, "", true, false, "teacher31@gmail.com" },
                    { 32, 0, "HCM", "a04674da-67ba-4fa4-a25d-dc9ca1f52125", "teacher32@gmail.com", true, "Name32", "LastName32", false, null, "teacher32@gmail.com", "teacher32@gmail.com", "AQAAAAIAAYagAAAAEEohZ7dvj1velsHlTZnhdtBXK3qiT8LRbrKgPxfXT6No58qeUpSp0qST1BTdZd4zdg==", null, false, "", true, false, "teacher32@gmail.com" },
                    { 33, 0, "HCM", "022f5492-9d41-4d4a-94f2-ce1eb59a7493", "teacher33@gmail.com", true, "Name33", "LastName33", false, null, "teacher33@gmail.com", "teacher33@gmail.com", "AQAAAAIAAYagAAAAEDNTjXx4T8O9hjCv0qjveJSYKRu7Kd70jTGNw41uICpLMF+Dk7PG7BJJC5M7g+EqWQ==", null, false, "", true, false, "teacher33@gmail.com" },
                    { 34, 0, "HCM", "236239c7-d540-4199-9721-8cf3fe5a6e4a", "teacher34@gmail.com", true, "Name34", "LastName34", false, null, "teacher34@gmail.com", "teacher34@gmail.com", "AQAAAAIAAYagAAAAEJ+kjnBYBfIVXltIXs1JoXbQ0RlOecEGmrF4dntwVK2sglYo7sJk80e8KGxY09APQA==", null, false, "", true, false, "teacher34@gmail.com" },
                    { 35, 0, "HCM", "5461d00b-107e-46fa-829c-da66d202177a", "teacher35@gmail.com", true, "Name35", "LastName35", false, null, "teacher35@gmail.com", "teacher35@gmail.com", "AQAAAAIAAYagAAAAEPFb0eytf302R3KkPNUqI612PjxAudSNgMGyIZ1WTGxgHKYY8IK46DwtMWIrNAkKQg==", null, false, "", true, false, "teacher35@gmail.com" },
                    { 36, 0, "HCM", "05b80b97-bce4-47e7-a480-9f3a8eae6c7e", "teacher36@gmail.com", true, "Name36", "LastName36", false, null, "teacher36@gmail.com", "teacher36@gmail.com", "AQAAAAIAAYagAAAAEPE6oNYXjmbIW03Hw8/+lZsf/Ec5muyJAT+/2Hks5rq/IS6z6WDjeNxg+bwVjUjeuw==", null, false, "", true, false, "teacher36@gmail.com" },
                    { 37, 0, "HCM", "3b25e520-f332-464c-9919-765a7cb3a46b", "teacher37@gmail.com", true, "Name37", "LastName37", false, null, "teacher37@gmail.com", "teacher37@gmail.com", "AQAAAAIAAYagAAAAEGNOLD67hv+QrsRRQLcp16kkaYo9HGUlqKrI6ayfzvLZe2/zUn5eoB1u0+tswG119g==", null, false, "", true, false, "teacher37@gmail.com" },
                    { 38, 0, "HCM", "e904606a-ed22-4f85-b2ea-de59e3c8d03e", "teacher38@gmail.com", true, "Name38", "LastName38", false, null, "teacher38@gmail.com", "teacher38@gmail.com", "AQAAAAIAAYagAAAAEENWEJW332fCFyLLpPFUOdEVkpY+LiZCMJoSfKQop0Qs4KTf95cjLkVCDWK0mSUG7Q==", null, false, "", true, false, "teacher38@gmail.com" },
                    { 39, 0, "HCM", "23fc9c2b-aed6-4e6c-99f9-1f4e37717a9c", "teacher39@gmail.com", true, "Name39", "LastName39", false, null, "teacher39@gmail.com", "teacher39@gmail.com", "AQAAAAIAAYagAAAAEPTVsS2XDDWYq5uRn3Jb8bjrGuqkG3R0iBXqR4Fktz4GMy5vg9h3oO86aPldjeH/6g==", null, false, "", true, false, "teacher39@gmail.com" },
                    { 40, 0, "HCM", "6db2c054-3d39-4b78-997a-0ff8f27edc18", "teacher40@gmail.com", true, "Name40", "LastName40", false, null, "teacher40@gmail.com", "teacher40@gmail.com", "AQAAAAIAAYagAAAAEAZv6BGWbHBHB1QifdTB5WQ4Aez64L3BqoVu5XqACxtd9o/HZery6gGGwFtgNeCLnA==", null, false, "", true, false, "teacher40@gmail.com" },
                    { 41, 0, "HCM", "b270c761-ac57-42bf-83d9-6ede8a3b02a4", "staff41@gmail.com", true, "Name41", "LastName41", false, null, "staff41@gmail.com", "staff41@gmail.com", "AQAAAAIAAYagAAAAEC0hf3ezoeif/cnKlUkW0d9IkvHF9d0G53MArtCrk43lQmE5r+2qUpvbK1HeYXytmQ==", null, false, "", true, false, "staff41@gmail.com" },
                    { 42, 0, "HCM", "335207dc-9f21-4e30-9a5b-085cdd678858", "staff42@gmail.com", true, "Name42", "LastName42", false, null, "staff42@gmail.com", "staff42@gmail.com", "AQAAAAIAAYagAAAAEC6XlJmiQPNvU3bybdKjq9P2ZdEitAPWxaC5k8v3t5lhb+xh9Xb6vF0WIfdKMg3WYQ==", null, false, "", true, false, "staff42@gmail.com" },
                    { 43, 0, "HCM", "f71a073d-09ed-4b5a-aec9-9627457a8ce1", "staff43@gmail.com", true, "Name43", "LastName43", false, null, "staff43@gmail.com", "staff43@gmail.com", "AQAAAAIAAYagAAAAEC4AD3crIp9wQkgmrRr06rMeafU0kA2EAv0KZc2pgKgl1fshZM4HSpVtPxuvnMuHmQ==", null, false, "", true, false, "staff43@gmail.com" },
                    { 44, 0, "HCM", "e18a465a-2d8c-4331-b983-c92c840efb53", "staff44@gmail.com", true, "Name44", "LastName44", false, null, "staff44@gmail.com", "staff44@gmail.com", "AQAAAAIAAYagAAAAEKNbtv2cn+Nx01408/kI/mmCWG3wlgR1rBYc90TLUs5BT5qr+98ti+g3byd/PmnIfw==", null, false, "", true, false, "staff44@gmail.com" },
                    { 45, 0, "HCM", "313298bb-007e-4af9-be0c-60deef43952c", "staff45@gmail.com", true, "Name45", "LastName45", false, null, "staff45@gmail.com", "staff45@gmail.com", "AQAAAAIAAYagAAAAEJJoC4sz7D0r8B/ppSljI41/mY3aVjiu1mrDE17aLsF8rziMVEVcxPbMkU0/hXLuww==", null, false, "", true, false, "staff45@gmail.com" },
                    { 46, 0, "HCM", "26acc167-977a-4a40-b40e-bb881c51c1b7", "admin46@gmail.com", true, "Name46", "LastName46", false, null, "admin46@gmail.com", "admin46@gmail.com", "AQAAAAIAAYagAAAAEElFnJZEI537jH3JoRzMOsHo2SWiQ3aR0Aj9Cury2G5PHx4TeRmDnHyWpvcEKMTUdg==", null, false, "", true, false, "admin46@gmail.com" }
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
                    { 1, 1, "Yoga course number 1", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course1", 100.0, new DateTime(2023, 6, 26, 15, 40, 52, 441, DateTimeKind.Local).AddTicks(8586) },
                    { 2, 2, "Yoga course number 2", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course2", 200.0, new DateTime(2023, 6, 26, 15, 40, 52, 441, DateTimeKind.Local).AddTicks(8607) },
                    { 3, 3, "Yoga course number 3", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course3", 300.0, new DateTime(2023, 6, 26, 15, 40, 52, 441, DateTimeKind.Local).AddTicks(8611) },
                    { 4, 4, "Yoga course number 4", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course4", 400.0, new DateTime(2023, 6, 26, 15, 40, 52, 441, DateTimeKind.Local).AddTicks(8615) },
                    { 5, 5, "Yoga course number 5", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course5", 500.0, new DateTime(2023, 6, 26, 15, 40, 52, 441, DateTimeKind.Local).AddTicks(8618) },
                    { 6, 6, "Yoga course number 6", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course6", 600.0, new DateTime(2023, 6, 26, 15, 40, 52, 441, DateTimeKind.Local).AddTicks(8622) },
                    { 7, 7, "Yoga course number 7", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course7", 700.0, new DateTime(2023, 6, 26, 15, 40, 52, 441, DateTimeKind.Local).AddTicks(8626) },
                    { 8, 8, "Yoga course number 8", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course8", 800.0, new DateTime(2023, 6, 26, 15, 40, 52, 441, DateTimeKind.Local).AddTicks(8630) },
                    { 9, 9, "Yoga course number 9", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course9", 900.0, new DateTime(2023, 6, 26, 15, 40, 52, 441, DateTimeKind.Local).AddTicks(8633) },
                    { 10, 10, "Yoga course number 10", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course10", 1000.0, new DateTime(2023, 6, 26, 15, 40, 52, 441, DateTimeKind.Local).AddTicks(8638) }
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
