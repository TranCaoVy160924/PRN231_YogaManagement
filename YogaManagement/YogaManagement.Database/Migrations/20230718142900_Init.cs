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
                    { 1, 0, "HCM", "8e835082-004b-401f-afc3-603f5a08dba1", "member1@gmail.com", true, "Name1", "LastName1", false, null, "member1@gmail.com", "member1@gmail.com", "AQAAAAIAAYagAAAAEMt6spBpHs4wtWhuUuO2VB+WGIiqOc6YNZTS+CBFmgm84e8lCbYvdL2LD+zh8G/OKQ==", null, false, "", true, false, "member1@gmail.com" },
                    { 2, 0, "HCM", "80aaaa5f-31d4-4476-8a13-5e816e6a7f38", "member2@gmail.com", true, "Name2", "LastName2", false, null, "member2@gmail.com", "member2@gmail.com", "AQAAAAIAAYagAAAAEPShdWNmYEEGerIxXcYyy5o7YAiJTlQKswzHiKfGTsPsUPk+QtOkAqtGEH7RgObjWA==", null, false, "", true, false, "member2@gmail.com" },
                    { 3, 0, "HCM", "2133144f-0ade-45fd-99b1-a6c8a3392860", "member3@gmail.com", true, "Name3", "LastName3", false, null, "member3@gmail.com", "member3@gmail.com", "AQAAAAIAAYagAAAAEKQ7wpjanknUlN2tbkfKrmTZdKPz+VmYi36w+NKCTFjPQ59WsIBBt/qJIxXJEgaALQ==", null, false, "", true, false, "member3@gmail.com" },
                    { 4, 0, "HCM", "a071fff9-98c4-480e-9728-bc63fb395454", "member4@gmail.com", true, "Name4", "LastName4", false, null, "member4@gmail.com", "member4@gmail.com", "AQAAAAIAAYagAAAAEHCCXBsbYP4uRTdA73wSQ5gmGTaBssiJyLGUwQT0lUTdWGLEldIEuWMHvGMjGfP8wQ==", null, false, "", true, false, "member4@gmail.com" },
                    { 5, 0, "HCM", "0c7faf05-6d08-4eec-9765-1d12e52fcafd", "member5@gmail.com", true, "Name5", "LastName5", false, null, "member5@gmail.com", "member5@gmail.com", "AQAAAAIAAYagAAAAEMQ15+jkJTCT0lT9czb6PXwTyS+MdsIuvKIb3J2sTSimBjtxsfuZgRjCQ7M3P3EZsw==", null, false, "", true, false, "member5@gmail.com" },
                    { 6, 0, "HCM", "66d0dea8-56cd-40df-bea7-975f9d762931", "member6@gmail.com", true, "Name6", "LastName6", false, null, "member6@gmail.com", "member6@gmail.com", "AQAAAAIAAYagAAAAEEGPlgkXXZyV6VklIMawcFmT3GMskalW1PHX9NTydSdU2CzMRY8h6wSCCi5trDwYNA==", null, false, "", true, false, "member6@gmail.com" },
                    { 7, 0, "HCM", "89ee9953-49c7-4abb-ba14-42621ab6b984", "member7@gmail.com", true, "Name7", "LastName7", false, null, "member7@gmail.com", "member7@gmail.com", "AQAAAAIAAYagAAAAEH3TN7b4/DwWR+K1XwCRFDgPIX7+TDojJqXvIr8ixR3jX36BgLCSvy4MH93yCku7pw==", null, false, "", true, false, "member7@gmail.com" },
                    { 8, 0, "HCM", "8801e715-0db6-4431-9ad2-05a857221e5a", "member8@gmail.com", true, "Name8", "LastName8", false, null, "member8@gmail.com", "member8@gmail.com", "AQAAAAIAAYagAAAAEBfwqYoRDpDhAPiQyiburTSGSfHk3F61osIi4+yH2bcSlQD/xMFTF4bKhuvh4jNoWQ==", null, false, "", true, false, "member8@gmail.com" },
                    { 9, 0, "HCM", "ea4b2d31-7281-4f2b-9ad9-e20780375490", "member9@gmail.com", true, "Name9", "LastName9", false, null, "member9@gmail.com", "member9@gmail.com", "AQAAAAIAAYagAAAAEF1aSF6abPlwz42TIEbzxK6Fr/SZxDr/ZlOawQ9TL9MyF4j8bN6vUyamERyeQDPrnQ==", null, false, "", true, false, "member9@gmail.com" },
                    { 10, 0, "HCM", "bd50706d-9802-40e8-9036-339e55447ce8", "member10@gmail.com", true, "Name10", "LastName10", false, null, "member10@gmail.com", "member10@gmail.com", "AQAAAAIAAYagAAAAEHZpjNIkpNmW6SvqagwHBtEXtO/h5zxIRS/pAgkD/YqXvqg7UQQn2pvkvCoP6geaKQ==", null, false, "", true, false, "member10@gmail.com" },
                    { 11, 0, "HCM", "4ac038dc-41ea-450c-b9ef-8e8a96ac9982", "member11@gmail.com", true, "Name11", "LastName11", false, null, "member11@gmail.com", "member11@gmail.com", "AQAAAAIAAYagAAAAEJnkJQhL9ETQVvhB7wJl/7I0X2sP1ExhAI2hIdu36qULWgpbCwv3hPnQkrSde2aNnQ==", null, false, "", true, false, "member11@gmail.com" },
                    { 12, 0, "HCM", "b0cef192-8cea-4246-bc25-4658094c2228", "member12@gmail.com", true, "Name12", "LastName12", false, null, "member12@gmail.com", "member12@gmail.com", "AQAAAAIAAYagAAAAEMjxZPtiFNuzrWMsvoKePNgMciDn76YWWR6CS3fYbv9S69/dgl7ws535NZQTU/bGpg==", null, false, "", true, false, "member12@gmail.com" },
                    { 13, 0, "HCM", "7ce7a857-9598-4ea2-98c3-23d9ce911530", "member13@gmail.com", true, "Name13", "LastName13", false, null, "member13@gmail.com", "member13@gmail.com", "AQAAAAIAAYagAAAAEFcagRUZuLuZwdsHDv4bmDmMB3dwLV0xWLJZX3T9gIntRzGOHPSKJ9aS+79I2ufSFQ==", null, false, "", true, false, "member13@gmail.com" },
                    { 14, 0, "HCM", "9f63cfe7-c35b-4188-8f56-52da0924e4f9", "member14@gmail.com", true, "Name14", "LastName14", false, null, "member14@gmail.com", "member14@gmail.com", "AQAAAAIAAYagAAAAEKfOsUkFaq+DJhchvj577GGc1z8Qo8SP+xLqIO/zzL/5AKiuXU5zFybC4F+wpHxn0w==", null, false, "", true, false, "member14@gmail.com" },
                    { 15, 0, "HCM", "0d74508f-1109-4e5a-8910-1c916d3c8a3f", "member15@gmail.com", true, "Name15", "LastName15", false, null, "member15@gmail.com", "member15@gmail.com", "AQAAAAIAAYagAAAAEKF64iuCWdT9LuGgykJr5NpEFvFbdcoIkaycHHaNNj1jZ7QZxWikyka/V9l81ZHLQA==", null, false, "", true, false, "member15@gmail.com" },
                    { 16, 0, "HCM", "0504f766-5b3e-4c68-a245-6204e5c7c7c2", "member16@gmail.com", true, "Name16", "LastName16", false, null, "member16@gmail.com", "member16@gmail.com", "AQAAAAIAAYagAAAAEIZA0ImdEk3S0BsV/GzrIuLSXz9aao0uynRz3nZuSA3Y1AMFV/lo/WoDiK/rfkYk+g==", null, false, "", true, false, "member16@gmail.com" },
                    { 17, 0, "HCM", "b2cb47c6-3d9b-476e-b1d1-00d9806a4d79", "member17@gmail.com", true, "Name17", "LastName17", false, null, "member17@gmail.com", "member17@gmail.com", "AQAAAAIAAYagAAAAEDjvI3fcKCWRONshw4i9PD2V8XJpcYROvToAZmriBFD/yPFbwYnQkQXKC/LeTOTRDg==", null, false, "", true, false, "member17@gmail.com" },
                    { 18, 0, "HCM", "ff136ebc-4607-458f-b464-5e19136ff429", "member18@gmail.com", true, "Name18", "LastName18", false, null, "member18@gmail.com", "member18@gmail.com", "AQAAAAIAAYagAAAAEC6XedRutSIWSa/K8qQKPE/kBhr2sUpHi3w79ZOas+U5w055mYFBhOm6phePUv14Lw==", null, false, "", true, false, "member18@gmail.com" },
                    { 19, 0, "HCM", "52a296d0-29ab-4fa2-8b82-fd939b6d29d9", "member19@gmail.com", true, "Name19", "LastName19", false, null, "member19@gmail.com", "member19@gmail.com", "AQAAAAIAAYagAAAAEMN061PgFKlpBS16ujYU+fM7b25V5LT3yrnqsycZ75v1zTHBqwIzdSc1FZ27emDE1A==", null, false, "", true, false, "member19@gmail.com" },
                    { 20, 0, "HCM", "509a0bec-176f-4094-b9f3-89dbdd4ed793", "member20@gmail.com", true, "Name20", "LastName20", false, null, "member20@gmail.com", "member20@gmail.com", "AQAAAAIAAYagAAAAEGPympkccn4p9ci2iZQnmYmn5Do/m8/eSQ5riBO9ZWm6scxyDZB3YvskBGh/4uvKjw==", null, false, "", true, false, "member20@gmail.com" },
                    { 21, 0, "HCM", "b1c6d9ba-6af5-4f83-b8d4-96d5ed254117", "member21@gmail.com", true, "Name21", "LastName21", false, null, "member21@gmail.com", "member21@gmail.com", "AQAAAAIAAYagAAAAEKPL9L5l9WKQP2lm1lhH2m4BtbLrVwyN/Y1g02ZpeADNr4AxiDttgSS1dJlDDfFy2w==", null, false, "", true, false, "member21@gmail.com" },
                    { 22, 0, "HCM", "e56f69c3-3cb6-4300-9e45-32804cbd5fc0", "member22@gmail.com", true, "Name22", "LastName22", false, null, "member22@gmail.com", "member22@gmail.com", "AQAAAAIAAYagAAAAEJn4sJMsqcY0aHRA//CAbXhRgauIslbbfRvmMjHpIA51dB76yk+YSTEgyixjSWQiFA==", null, false, "", true, false, "member22@gmail.com" },
                    { 23, 0, "HCM", "e92f2710-df1f-4f4f-a03f-7b9bc8a1c04a", "member23@gmail.com", true, "Name23", "LastName23", false, null, "member23@gmail.com", "member23@gmail.com", "AQAAAAIAAYagAAAAELtZ4blVOUe8BIXTVK1h/UjQKecMgp8pr9AXNmDa4kqkt5n77bXM0vd0HXm1x6pliQ==", null, false, "", true, false, "member23@gmail.com" },
                    { 24, 0, "HCM", "8c48ce07-18ea-4b69-ac2b-39712c3de233", "member24@gmail.com", true, "Name24", "LastName24", false, null, "member24@gmail.com", "member24@gmail.com", "AQAAAAIAAYagAAAAEGusEHGJUIRFpRwTwNIGFfdblMTMmNLrqr7ql9Biz2PxQjZJebx0tXCloRrBu9MqgA==", null, false, "", true, false, "member24@gmail.com" },
                    { 25, 0, "HCM", "750bb73b-48db-4d2e-811e-83294c49395a", "member25@gmail.com", true, "Name25", "LastName25", false, null, "member25@gmail.com", "member25@gmail.com", "AQAAAAIAAYagAAAAEKAChzca7+3tXVN2qbcoKSsZbMLRo6/zRycZxcQcjeiZv4OZ72zp34eKMlLgys2PiQ==", null, false, "", true, false, "member25@gmail.com" },
                    { 26, 0, "HCM", "ef7e65a9-d401-43b3-9b20-82edaed4abff", "member26@gmail.com", true, "Name26", "LastName26", false, null, "member26@gmail.com", "member26@gmail.com", "AQAAAAIAAYagAAAAEF2feyZNyoyNefYRXnRfM+5s0LR80Sb1VqXyb3O8+NeVrf1m5qhUVr/Q2HEFsYBOjw==", null, false, "", true, false, "member26@gmail.com" },
                    { 27, 0, "HCM", "a6e0f54e-c752-4d2d-a157-c2e2c61e4dec", "member27@gmail.com", true, "Name27", "LastName27", false, null, "member27@gmail.com", "member27@gmail.com", "AQAAAAIAAYagAAAAEKDtiENF8qievVL0cF42XCG9/wKQlnX/m+ZsfkLkpUsGwq5TtjKRVinbSz3iFoKZYQ==", null, false, "", true, false, "member27@gmail.com" },
                    { 28, 0, "HCM", "479f4b89-03b0-4ff0-be7c-73d9be69eb9b", "member28@gmail.com", true, "Name28", "LastName28", false, null, "member28@gmail.com", "member28@gmail.com", "AQAAAAIAAYagAAAAEPHTjZUoaC6wrkIzSQA2D47liSwqQJi/WaQxXHPa5+5t0YPZHe+BZBdH2sDUzG16NA==", null, false, "", true, false, "member28@gmail.com" },
                    { 29, 0, "HCM", "e9b14843-5638-49ab-a2a3-f012f213ab62", "member29@gmail.com", true, "Name29", "LastName29", false, null, "member29@gmail.com", "member29@gmail.com", "AQAAAAIAAYagAAAAEBkUyTD6mS85/e0mGS6juQBhzUjw59WH5qZcRcbQ4CbRjhzIEN3RXFp8sJDLnFHmVg==", null, false, "", true, false, "member29@gmail.com" },
                    { 30, 0, "HCM", "738f89b0-818f-4f85-8999-6f17089b6749", "member30@gmail.com", true, "Name30", "LastName30", false, null, "member30@gmail.com", "member30@gmail.com", "AQAAAAIAAYagAAAAEGYSJ/Pi6yPA0ptsYYoRdLAiQvT4c6Qzk4s6v8TFdu54xURQAY2FRt3RiVJJXEUW6A==", null, false, "", true, false, "member30@gmail.com" },
                    { 31, 0, "HCM", "6db2861a-6904-4732-8272-19ec25a53a67", "teacher31@gmail.com", true, "Name31", "LastName31", false, null, "teacher31@gmail.com", "teacher31@gmail.com", "AQAAAAIAAYagAAAAEOKMHGewDTbhZWCviP2tovp/g1XOim02ow32I+T9R414QnytpRIuuToDsRBe4CCsDA==", null, false, "", true, false, "teacher31@gmail.com" },
                    { 32, 0, "HCM", "b13323c7-f09f-461b-ba25-3253137c3583", "teacher32@gmail.com", true, "Name32", "LastName32", false, null, "teacher32@gmail.com", "teacher32@gmail.com", "AQAAAAIAAYagAAAAEBBeBN9ciKytanserUC7pPjhArYY+ovePJEelQJGjasybmLmyvX2bjriTJI/CE/tag==", null, false, "", true, false, "teacher32@gmail.com" },
                    { 33, 0, "HCM", "93a208ff-1fd3-4c02-8829-1e12b0690432", "teacher33@gmail.com", true, "Name33", "LastName33", false, null, "teacher33@gmail.com", "teacher33@gmail.com", "AQAAAAIAAYagAAAAEPrmAs9aXQoWB13ozfmEKJKxtieJAOKFVQ53J+YzYkECxbjl/UfP7olYZpPB+EFnig==", null, false, "", true, false, "teacher33@gmail.com" },
                    { 34, 0, "HCM", "62ce623d-11f2-4b2a-b7b7-28cc0e3c3141", "teacher34@gmail.com", true, "Name34", "LastName34", false, null, "teacher34@gmail.com", "teacher34@gmail.com", "AQAAAAIAAYagAAAAEPhmB9t6GhdgojgHUZ8HFDj0vBaDNSrFVT6TZLA4gZz80JL2SxmVu83mT5E+tdDbCA==", null, false, "", true, false, "teacher34@gmail.com" },
                    { 35, 0, "HCM", "57c41ce8-cf57-43b0-bab7-75a6c90022cb", "teacher35@gmail.com", true, "Name35", "LastName35", false, null, "teacher35@gmail.com", "teacher35@gmail.com", "AQAAAAIAAYagAAAAEAcvCyEkMsnUPz4+e1EfAiOwnWa4oCC6qJxw1+KHxq97Az2Y6nuJn8mgawk2vPo0fg==", null, false, "", true, false, "teacher35@gmail.com" },
                    { 36, 0, "HCM", "b4270598-1f72-4dc6-8e69-65ba4730cc76", "teacher36@gmail.com", true, "Name36", "LastName36", false, null, "teacher36@gmail.com", "teacher36@gmail.com", "AQAAAAIAAYagAAAAEPiySYr4nhHAbZxoRAYeJB/CDxnkimSWs8hx99iB6vgTz7iVC1xIPy2v060c/qU1tA==", null, false, "", true, false, "teacher36@gmail.com" },
                    { 37, 0, "HCM", "f626fead-2fa3-4f0a-9cc5-f30598c9df90", "teacher37@gmail.com", true, "Name37", "LastName37", false, null, "teacher37@gmail.com", "teacher37@gmail.com", "AQAAAAIAAYagAAAAENh94MbIChpGQ4WpFsbUD/Xqg1MXQ2kLFsgYgncyNEbJS6uktSFgIwH3sFWJcGnpIw==", null, false, "", true, false, "teacher37@gmail.com" },
                    { 38, 0, "HCM", "3a052510-0d67-43c1-9298-59ad0efc2d3a", "teacher38@gmail.com", true, "Name38", "LastName38", false, null, "teacher38@gmail.com", "teacher38@gmail.com", "AQAAAAIAAYagAAAAEIrR37E2BG3mRicmj1MM4xELaCg46Xg51sCcGVqxM9LdlK90IYdAqTSvHPrLEaMiaA==", null, false, "", true, false, "teacher38@gmail.com" },
                    { 39, 0, "HCM", "ff05a906-6774-4a9d-a084-b77c97a615a1", "teacher39@gmail.com", true, "Name39", "LastName39", false, null, "teacher39@gmail.com", "teacher39@gmail.com", "AQAAAAIAAYagAAAAEIzqM7Rg5mHeyWuTem0kmmbOBzrfdBnFMuVBtpc9zEJW1jdiJrKgp3hSDgsWIQUbYw==", null, false, "", true, false, "teacher39@gmail.com" },
                    { 40, 0, "HCM", "4784c23d-744b-4ab9-8711-38e81c87a294", "teacher40@gmail.com", true, "Name40", "LastName40", false, null, "teacher40@gmail.com", "teacher40@gmail.com", "AQAAAAIAAYagAAAAEKbMu7EzFlvks4iwFRiQTeeS7iv3s5puDsBon0G/pBcgw/V1KeEDv7oNZQucUgcNuQ==", null, false, "", true, false, "teacher40@gmail.com" },
                    { 41, 0, "HCM", "1257a6b7-c6d5-4900-a1ba-848db7d7164f", "staff41@gmail.com", true, "Name41", "LastName41", false, null, "staff41@gmail.com", "staff41@gmail.com", "AQAAAAIAAYagAAAAELa6b2QlyCAYDdwPJNIMoEgEK3HLJ0qXHlhIsGbXUXZIW7u5rkQ/u0UrEVFZ8NjxUw==", null, false, "", true, false, "staff41@gmail.com" },
                    { 42, 0, "HCM", "2adc7d71-10e7-446b-aa4a-7922f73de02b", "staff42@gmail.com", true, "Name42", "LastName42", false, null, "staff42@gmail.com", "staff42@gmail.com", "AQAAAAIAAYagAAAAEPSbQX8+r32Pvhlnoz67IS1WF2VOrKLaynJx60MeEr4a0MQfCs1SbHTrbAJTOBrZsQ==", null, false, "", true, false, "staff42@gmail.com" },
                    { 43, 0, "HCM", "eebc14ca-1de2-46c3-98f0-ff8270b959b0", "staff43@gmail.com", true, "Name43", "LastName43", false, null, "staff43@gmail.com", "staff43@gmail.com", "AQAAAAIAAYagAAAAEJgLp+gmxSOWRousYaJNKThtAxv6RIMP+jNmtFzHNZHNEBmsc196KEoCVBEBpthCag==", null, false, "", true, false, "staff43@gmail.com" },
                    { 44, 0, "HCM", "60236553-4f03-483b-abfb-ee5a92f20326", "staff44@gmail.com", true, "Name44", "LastName44", false, null, "staff44@gmail.com", "staff44@gmail.com", "AQAAAAIAAYagAAAAEATFBuuamPcrBWhBxCuQZ2qw5/a8J61pA/5YguPRHPf81fqCgdVfVBDQ07f51CJKfg==", null, false, "", true, false, "staff44@gmail.com" },
                    { 45, 0, "HCM", "da2f001c-260f-48f2-acfd-b6042bb6e2f4", "staff45@gmail.com", true, "Name45", "LastName45", false, null, "staff45@gmail.com", "staff45@gmail.com", "AQAAAAIAAYagAAAAEClXvT0+2eAuQAaNwNiIEkNXWLOoVPIActJNJLHuHfPhUqYgc+Sh4nyidsFO9PCAaA==", null, false, "", true, false, "staff45@gmail.com" },
                    { 46, 0, "HCM", "b9a559bd-5ed4-4e20-b3ab-cc5e82bec5e9", "admin46@gmail.com", true, "Name46", "LastName46", false, null, "admin46@gmail.com", "admin46@gmail.com", "AQAAAAIAAYagAAAAEOOeBTLi6Ka8Zv2vppI76vI9PmvBLfb9zGA67MOrn1LzfZy3s2LMN9AS+UbY+abh9w==", null, false, "", true, false, "admin46@gmail.com" }
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
                    { 1, 1, "Yoga course number 1", new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Local), true, "Course1", 100.0, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 2, 2, "Yoga course number 2", new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Local), true, "Course2", 200.0, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 3, 3, "Yoga course number 3", new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Local), true, "Course3", 300.0, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 4, 4, "Yoga course number 4", new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Local), true, "Course4", 400.0, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 5, 5, "Yoga course number 5", new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Local), true, "Course5", 500.0, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 6, 6, "Yoga course number 6", new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Local), true, "Course6", 600.0, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 7, 7, "Yoga course number 7", new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Local), true, "Course7", 700.0, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 8, 8, "Yoga course number 8", new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Local), true, "Course8", 800.0, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 9, 9, "Yoga course number 9", new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Local), true, "Course9", 900.0, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 10, 10, "Yoga course number 10", new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Local), true, "Course10", 1000.0, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Local) }
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
                    { 1, 4, 0.0, new DateTime(2023, 7, 26, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 2, 2, 0.0, new DateTime(2023, 7, 26, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 3, 4, 0.0, new DateTime(2023, 7, 26, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 4, 2, 0.0, new DateTime(2023, 7, 26, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 5, 4, 0.0, new DateTime(2023, 7, 26, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 6, 2, 0.0, new DateTime(2023, 7, 26, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 7, 4, 0.0, new DateTime(2023, 7, 26, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 8, 2, 0.0, new DateTime(2023, 7, 26, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 9, 4, 0.0, new DateTime(2023, 7, 26, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 10, 2, 0.0, new DateTime(2023, 7, 26, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 11, 8, 0.0, new DateTime(2023, 7, 26, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 12, 6, 0.0, new DateTime(2023, 7, 26, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 13, 8, 0.0, new DateTime(2023, 7, 26, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 14, 6, 0.0, new DateTime(2023, 7, 26, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 15, 8, 0.0, new DateTime(2023, 7, 26, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 16, 6, 0.0, new DateTime(2023, 7, 26, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 17, 8, 0.0, new DateTime(2023, 7, 26, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 18, 6, 0.0, new DateTime(2023, 7, 26, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 19, 8, 0.0, new DateTime(2023, 7, 26, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 20, 6, 0.0, new DateTime(2023, 7, 26, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 21, 3, 0.0, new DateTime(2023, 7, 26, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 22, 1, 0.0, new DateTime(2023, 7, 26, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 23, 3, 0.0, new DateTime(2023, 7, 26, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 24, 1, 0.0, new DateTime(2023, 7, 26, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 25, 3, 0.0, new DateTime(2023, 7, 26, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 26, 1, 0.0, new DateTime(2023, 7, 26, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 27, 3, 0.0, new DateTime(2023, 7, 26, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 28, 1, 0.0, new DateTime(2023, 7, 26, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 29, 3, 0.0, new DateTime(2023, 7, 26, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 30, 1, 0.0, new DateTime(2023, 7, 26, 0, 0, 0, 0, DateTimeKind.Local) }
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
                    { 31, new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2023, 7, 26, 0, 0, 0, 0, DateTimeKind.Local), 31, 4 },
                    { 32, new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2023, 7, 26, 0, 0, 0, 0, DateTimeKind.Local), 32, 2 },
                    { 33, new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2023, 7, 26, 0, 0, 0, 0, DateTimeKind.Local), 33, 4 },
                    { 34, new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2023, 7, 26, 0, 0, 0, 0, DateTimeKind.Local), 34, 2 },
                    { 35, new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2023, 7, 26, 0, 0, 0, 0, DateTimeKind.Local), 35, 4 }
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
