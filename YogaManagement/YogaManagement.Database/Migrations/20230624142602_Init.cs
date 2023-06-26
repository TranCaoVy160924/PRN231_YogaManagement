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
                    { 1, 0, "HCM", "00063496-d7dc-4b5a-9205-0c9d49fc676a", "member1@gmail.com", true, "Name1", "LastName1", false, null, "member1@gmail.com", "member1@gmail.com", "AQAAAAIAAYagAAAAEDQceKVRclJYFF4J9bXkpcKofYk2yGCWR1+BnFqV/VbSkqcx3BkKg8zmaKY949s2Tg==", null, false, "", true, false, "member1@gmail.com" },
                    { 2, 0, "HCM", "42dc4dc8-101c-44b1-a87e-5bee21497b49", "member2@gmail.com", true, "Name2", "LastName2", false, null, "member2@gmail.com", "member2@gmail.com", "AQAAAAIAAYagAAAAEFlO5Y3C1ubGBEJYvY/QORXXsMJ+mXOIIaD/GjibHdZBDwWmfmD1vYNklkNFcTHgmA==", null, false, "", true, false, "member2@gmail.com" },
                    { 3, 0, "HCM", "6f408455-498e-4ff4-a351-5097f6d3036e", "member3@gmail.com", true, "Name3", "LastName3", false, null, "member3@gmail.com", "member3@gmail.com", "AQAAAAIAAYagAAAAEOa0ekCF3Rv0Ud2VOzHS6ZpJnwWEEd7uSIgP4jGz69duw63oopENAnkbognoeklTAw==", null, false, "", true, false, "member3@gmail.com" },
                    { 4, 0, "HCM", "153375df-e149-4688-bb6f-81b7782286f6", "member4@gmail.com", true, "Name4", "LastName4", false, null, "member4@gmail.com", "member4@gmail.com", "AQAAAAIAAYagAAAAEGGRSQyfZB6qmcrAwtg1ucCSx14JvTaaacxVtEBdmGwjR2SONR1AU2lcwAzaF1sB5g==", null, false, "", true, false, "member4@gmail.com" },
                    { 5, 0, "HCM", "7911aad0-7eec-4474-afe5-c4268b8141b9", "member5@gmail.com", true, "Name5", "LastName5", false, null, "member5@gmail.com", "member5@gmail.com", "AQAAAAIAAYagAAAAEChiRFzPvxwN0IWCHubTwuZGAzWma08IsfiEUyPV2KzozgbTI4WfOEanRNaNhro/8g==", null, false, "", true, false, "member5@gmail.com" },
                    { 6, 0, "HCM", "6bf57b89-7564-4bb5-9e75-87f9034687cf", "member6@gmail.com", true, "Name6", "LastName6", false, null, "member6@gmail.com", "member6@gmail.com", "AQAAAAIAAYagAAAAELlYEIixC+V43ionBKz3FJ1gGy+vzqpPQjdwwICQMRBKA2cwQ5EscJ6M4HBohQ7+QA==", null, false, "", true, false, "member6@gmail.com" },
                    { 7, 0, "HCM", "57c7198b-9379-4fcb-9d54-6865c24eb31f", "member7@gmail.com", true, "Name7", "LastName7", false, null, "member7@gmail.com", "member7@gmail.com", "AQAAAAIAAYagAAAAEJGnnwIoQtILd9bjv1NXTXdygIgtyoau5HV9LXgWiXBdS70U38iMt71aT1gKkuB7qg==", null, false, "", true, false, "member7@gmail.com" },
                    { 8, 0, "HCM", "d9123567-cf30-4f03-8fb4-b795193cd377", "member8@gmail.com", true, "Name8", "LastName8", false, null, "member8@gmail.com", "member8@gmail.com", "AQAAAAIAAYagAAAAEPTP9xorIbTsBfaGlV3Fp8R4IYoKrAp5SDvG7ufJAk85HnDSOOpLDyfiC+hVje23kQ==", null, false, "", true, false, "member8@gmail.com" },
                    { 9, 0, "HCM", "c5abd038-b4b5-4e74-9dce-4d6cdff84d08", "member9@gmail.com", true, "Name9", "LastName9", false, null, "member9@gmail.com", "member9@gmail.com", "AQAAAAIAAYagAAAAEJNNT7xszlYxbQEGF0VyJu0ogOtEdn29Lh5vnryyl/+6Q7f5zXq8AKJ1jACEIp+XkQ==", null, false, "", true, false, "member9@gmail.com" },
                    { 10, 0, "HCM", "6fef127a-3c8e-4252-8789-602c38b88bc8", "member10@gmail.com", true, "Name10", "LastName10", false, null, "member10@gmail.com", "member10@gmail.com", "AQAAAAIAAYagAAAAEDhbIpozgSCZ1vR8T3Ex2wWWAtT9WCu/2JakRcIpLPwBodCa/BWydLy20KdVIC3T/A==", null, false, "", true, false, "member10@gmail.com" },
                    { 11, 0, "HCM", "d7b08a73-4294-4ebc-bc7f-f709957b7def", "member11@gmail.com", true, "Name11", "LastName11", false, null, "member11@gmail.com", "member11@gmail.com", "AQAAAAIAAYagAAAAEMW4mkf5e4ooTvKeyLxohwsnv2LrjfBqOAFvy8J9cuMEoni+ngi17x4smune/igQ2Q==", null, false, "", true, false, "member11@gmail.com" },
                    { 12, 0, "HCM", "4e59a5b5-c0de-436b-a033-b323cc0b2125", "member12@gmail.com", true, "Name12", "LastName12", false, null, "member12@gmail.com", "member12@gmail.com", "AQAAAAIAAYagAAAAEBFuR9zFoBcWckIpEuuCm+HYwoXBMnMrxu1KhnsoRQAQKe2mI8zqLsOhb926n5RGqw==", null, false, "", true, false, "member12@gmail.com" },
                    { 13, 0, "HCM", "6af89b31-9d9d-4855-8f34-9d83ab78be85", "member13@gmail.com", true, "Name13", "LastName13", false, null, "member13@gmail.com", "member13@gmail.com", "AQAAAAIAAYagAAAAEFU64MfuqyEtT/OEkbZNGe6rgBpShoWREP6Aeu5f15FIeO1MHBi+fethsKU4z1DEpw==", null, false, "", true, false, "member13@gmail.com" },
                    { 14, 0, "HCM", "3ab0b0e1-fa27-4783-b9af-c35d83cb88d7", "member14@gmail.com", true, "Name14", "LastName14", false, null, "member14@gmail.com", "member14@gmail.com", "AQAAAAIAAYagAAAAEBDyxVxYTAT/VoE6WXJ1kCiv4RH2J1yTbpADjWjhTbKujjcSUZFLXxM7yHYQWe9VlA==", null, false, "", true, false, "member14@gmail.com" },
                    { 15, 0, "HCM", "a5759b3e-0377-4661-923c-cc3f5c8ac6a6", "member15@gmail.com", true, "Name15", "LastName15", false, null, "member15@gmail.com", "member15@gmail.com", "AQAAAAIAAYagAAAAEEGL04OVLIagCLemWuOcNv+FUZoq4h2TGtAaQn8qsKPRCXTo56YHRayHKwJiS/bRuQ==", null, false, "", true, false, "member15@gmail.com" },
                    { 16, 0, "HCM", "f5ce02b2-441d-4516-b0ae-6b5f4b5c5c7f", "member16@gmail.com", true, "Name16", "LastName16", false, null, "member16@gmail.com", "member16@gmail.com", "AQAAAAIAAYagAAAAEBSL8m2W2KuqIwt6QqpWo/lnmgdq2g5bBa/I7WAKv+mrhhDbQ7aN//QwzifpPvLMSg==", null, false, "", true, false, "member16@gmail.com" },
                    { 17, 0, "HCM", "d2917ad8-3868-49ad-9690-8be6ab374617", "member17@gmail.com", true, "Name17", "LastName17", false, null, "member17@gmail.com", "member17@gmail.com", "AQAAAAIAAYagAAAAEKu1Oh88Hp2dfJCrbw9bnrm+HQ7ugB/3omZf9qD/KUsaDeGNnYBN9LcJ15TYPdwX/A==", null, false, "", true, false, "member17@gmail.com" },
                    { 18, 0, "HCM", "fc9cf225-449d-4ff7-b1ba-a90cea5e4801", "member18@gmail.com", true, "Name18", "LastName18", false, null, "member18@gmail.com", "member18@gmail.com", "AQAAAAIAAYagAAAAEN/tcM/BAJBX+DPRmFLJXD5XLfUuwCG8X1m7zflOorG7mGuQgW86L2iSlPm29PbVkA==", null, false, "", true, false, "member18@gmail.com" },
                    { 19, 0, "HCM", "b9d8f060-1d5c-417c-a1d5-1600d09193c9", "member19@gmail.com", true, "Name19", "LastName19", false, null, "member19@gmail.com", "member19@gmail.com", "AQAAAAIAAYagAAAAEJ6AHZc9He1213tQwextovJPr0mMrH3s6/XmokxwHonu6xv+pA7s4Ef/N3RebXMvuQ==", null, false, "", true, false, "member19@gmail.com" },
                    { 20, 0, "HCM", "48a70410-8cdb-445a-8785-d3d757098e5a", "member20@gmail.com", true, "Name20", "LastName20", false, null, "member20@gmail.com", "member20@gmail.com", "AQAAAAIAAYagAAAAEDT/EllsqI4EzxQbwsK4zNVFdTaCzbpMkDx3WKs5pQQqdr8XRd4PnGA67YkpCUghxg==", null, false, "", true, false, "member20@gmail.com" },
                    { 21, 0, "HCM", "2955e0bb-3b19-4513-8ddc-28cde8ce3f78", "member21@gmail.com", true, "Name21", "LastName21", false, null, "member21@gmail.com", "member21@gmail.com", "AQAAAAIAAYagAAAAEN69fv8QaXvBgxs+v40r0Zeyg4RpX6ts7bNmx0L8+U0zpNlNtvJKIg4F3xSk1yR53g==", null, false, "", true, false, "member21@gmail.com" },
                    { 22, 0, "HCM", "31244400-f542-4e80-872c-e81af7dc151c", "member22@gmail.com", true, "Name22", "LastName22", false, null, "member22@gmail.com", "member22@gmail.com", "AQAAAAIAAYagAAAAEAnx+MZhgY6Ye9zoOfh61CDiVs5YmLBR5ww/W+8zDz7DeMlm8YsVxvjg5LHPmrQJqg==", null, false, "", true, false, "member22@gmail.com" },
                    { 23, 0, "HCM", "971f0368-b1b5-4c21-97e1-3db8badfe7a3", "member23@gmail.com", true, "Name23", "LastName23", false, null, "member23@gmail.com", "member23@gmail.com", "AQAAAAIAAYagAAAAEMmclIRnLy9UbST2DqL/Ax+s3Z/HIpkBGMGgRBr2NaWpgGTNEUnvIhKHmIR/XT7jnA==", null, false, "", true, false, "member23@gmail.com" },
                    { 24, 0, "HCM", "9750eec7-2a23-4f59-ab29-588dd261a70d", "member24@gmail.com", true, "Name24", "LastName24", false, null, "member24@gmail.com", "member24@gmail.com", "AQAAAAIAAYagAAAAEP+bMYPnzzVrAa1u8XMxXYP5IcKZvQRP+fKMSIHBgBaUtfMyZUCwbbOOefrrOYscAQ==", null, false, "", true, false, "member24@gmail.com" },
                    { 25, 0, "HCM", "5e8a4d95-bb9a-4143-a42b-39fd6dceaed5", "member25@gmail.com", true, "Name25", "LastName25", false, null, "member25@gmail.com", "member25@gmail.com", "AQAAAAIAAYagAAAAENM1blaCzr7rryNlPSCqRFlGFbgxTs5l14qExJ7QBvaqeeJQAtZzyrP1hOOBGkQHmg==", null, false, "", true, false, "member25@gmail.com" },
                    { 26, 0, "HCM", "512b2371-967d-4f06-8301-fdc2cf8bceb5", "member26@gmail.com", true, "Name26", "LastName26", false, null, "member26@gmail.com", "member26@gmail.com", "AQAAAAIAAYagAAAAEMazRgwYRiV5AAvaKeiBlxA5lqELSClz7B/MWhaoMG58kY1YhJKGoZj9uyKFZT3lWA==", null, false, "", true, false, "member26@gmail.com" },
                    { 27, 0, "HCM", "88946553-231b-4d6f-ac18-dfadf0513227", "member27@gmail.com", true, "Name27", "LastName27", false, null, "member27@gmail.com", "member27@gmail.com", "AQAAAAIAAYagAAAAEODfl1ZAczWeeDjl4lqxg5PZ+3kYWozL/eJF4yOvjcfMjNNlv9ul/zQoqq1qFE/0dA==", null, false, "", true, false, "member27@gmail.com" },
                    { 28, 0, "HCM", "0b06f302-bb19-4b08-9c5d-811fe95750d0", "member28@gmail.com", true, "Name28", "LastName28", false, null, "member28@gmail.com", "member28@gmail.com", "AQAAAAIAAYagAAAAELQZLEIYUuq/7tKGX5RFdt/fEgu98vnCmLxwBmBEhmqy7ivsVWX+JMWtZNvvT4IIQQ==", null, false, "", true, false, "member28@gmail.com" },
                    { 29, 0, "HCM", "655497ef-02e1-4649-badc-c0b3ceaef78d", "member29@gmail.com", true, "Name29", "LastName29", false, null, "member29@gmail.com", "member29@gmail.com", "AQAAAAIAAYagAAAAEASSHsXsPQzdqADMSHg3ySJJT0pEL88wmvKtKeHzhu1JzpaV8t5FSyt0ii8XUb+uhA==", null, false, "", true, false, "member29@gmail.com" },
                    { 30, 0, "HCM", "de9afc44-bef9-459a-a9c4-1fac5940df64", "member30@gmail.com", true, "Name30", "LastName30", false, null, "member30@gmail.com", "member30@gmail.com", "AQAAAAIAAYagAAAAEAhRH2o/LkOChkJBtDSwLT3z+5P4C19/yYgyYvxNFgmzOVWZuD54yfFxJWbKqAJA/Q==", null, false, "", true, false, "member30@gmail.com" },
                    { 31, 0, "HCM", "837b8e56-14bb-4697-9f1a-dc37be40f5ed", "teacher31@gmail.com", true, "Name31", "LastName31", false, null, "teacher31@gmail.com", "teacher31@gmail.com", "AQAAAAIAAYagAAAAECugEnLHvqCL+tCuSdjtD7gKQcZK0w3KR8Qi+g6S/5qWyNkTJQqLn+zbBYDlR+GWsg==", null, false, "", true, false, "teacher31@gmail.com" },
                    { 32, 0, "HCM", "9352b851-9379-4e08-8b58-f34490df710e", "teacher32@gmail.com", true, "Name32", "LastName32", false, null, "teacher32@gmail.com", "teacher32@gmail.com", "AQAAAAIAAYagAAAAEIO2eM1AO19cgjDyGYBZ7hUFB0kEzlwypoUZvawK9L9sbGYZtskGsYybQa5Ta3v6fQ==", null, false, "", true, false, "teacher32@gmail.com" },
                    { 33, 0, "HCM", "4ae48c40-ec82-4c52-9dd0-a7ee480c70f1", "teacher33@gmail.com", true, "Name33", "LastName33", false, null, "teacher33@gmail.com", "teacher33@gmail.com", "AQAAAAIAAYagAAAAEJiilP15xDNRaPARgJZnpGB4KXMJBddWaNjZrUi8yUL28cVj4byeHuRrmacWJ2gSaA==", null, false, "", true, false, "teacher33@gmail.com" },
                    { 34, 0, "HCM", "26cb8aa9-9ec4-46e0-9842-09052d5e4c3a", "teacher34@gmail.com", true, "Name34", "LastName34", false, null, "teacher34@gmail.com", "teacher34@gmail.com", "AQAAAAIAAYagAAAAEGwwjCIhCgAKFa+EZ1aoamPG7fgtDECiF3lNNA4ABH+I9ugMD2AJeYuLy4cpnBtObg==", null, false, "", true, false, "teacher34@gmail.com" },
                    { 35, 0, "HCM", "3d51e462-89fc-4614-ae33-40232b60cf6b", "teacher35@gmail.com", true, "Name35", "LastName35", false, null, "teacher35@gmail.com", "teacher35@gmail.com", "AQAAAAIAAYagAAAAEInN4aq1ZWKiq+VyDy+KzlYuIFEvFWfVmniwpRRLmtvJ2o2Yj9/1Zpgf2V713GkMqw==", null, false, "", true, false, "teacher35@gmail.com" },
                    { 36, 0, "HCM", "8627d890-3c76-4780-b191-d5c698300542", "teacher36@gmail.com", true, "Name36", "LastName36", false, null, "teacher36@gmail.com", "teacher36@gmail.com", "AQAAAAIAAYagAAAAEHTuAMOLHF2HD3BRuoXqjAz5nnjwKfSwVIyV3wMaq4Sc1LgnOxSKOXZpTYdYKCj7jA==", null, false, "", true, false, "teacher36@gmail.com" },
                    { 37, 0, "HCM", "51093e21-36ae-4821-9664-b36d2babb2bb", "teacher37@gmail.com", true, "Name37", "LastName37", false, null, "teacher37@gmail.com", "teacher37@gmail.com", "AQAAAAIAAYagAAAAEH7CrirEHft/3qNBsWQpaEzgopY6QpwSZVqDgCbhuUdT8Q3e/PMvSXhcHJr8o/wE9Q==", null, false, "", true, false, "teacher37@gmail.com" },
                    { 38, 0, "HCM", "b43ec5b5-b852-4040-8140-7b8d7c2974d7", "teacher38@gmail.com", true, "Name38", "LastName38", false, null, "teacher38@gmail.com", "teacher38@gmail.com", "AQAAAAIAAYagAAAAEHi5i5odPNVbO+0NTMae3df/ZYtHZy2dYHWVUzrtSBSgo3Cc4zP/SbH3ARLBe//8jw==", null, false, "", true, false, "teacher38@gmail.com" },
                    { 39, 0, "HCM", "2ce8f4e4-18dc-48fb-8cb6-69cda1909b42", "teacher39@gmail.com", true, "Name39", "LastName39", false, null, "teacher39@gmail.com", "teacher39@gmail.com", "AQAAAAIAAYagAAAAEHPHN1rLm+4AkdXH+QEpW9IK+kGWRpTSXIbbzzz8zSSqWmw05Dkb1W+xYmJBSG8p2A==", null, false, "", true, false, "teacher39@gmail.com" },
                    { 40, 0, "HCM", "d7f7fe07-6092-41d8-8948-3b27010db427", "teacher40@gmail.com", true, "Name40", "LastName40", false, null, "teacher40@gmail.com", "teacher40@gmail.com", "AQAAAAIAAYagAAAAEO1mRlSl7c7fYOm5aRaawQCNdpkhDuK1cf0fd5CujMMeAGJNquUDx/t9b0c+8FlV5w==", null, false, "", true, false, "teacher40@gmail.com" },
                    { 41, 0, "HCM", "ce65c398-09eb-4e10-9819-2282049cc556", "staff41@gmail.com", true, "Name41", "LastName41", false, null, "staff41@gmail.com", "staff41@gmail.com", "AQAAAAIAAYagAAAAEN5flHEDVU1PT4G7LB8cpgfzhbuw+wy7cNeXRjDqGopsv/uxSNOQBBzG4gxc2CjQFA==", null, false, "", true, false, "staff41@gmail.com" },
                    { 42, 0, "HCM", "be37147e-8891-41c0-8f08-f167a6da7596", "staff42@gmail.com", true, "Name42", "LastName42", false, null, "staff42@gmail.com", "staff42@gmail.com", "AQAAAAIAAYagAAAAEOMxjdvauN8HEslmyk4bc0qQ099JTbggEYVYlmD/wHd+z5ldk5Pnu82FwZ4jGdY7rQ==", null, false, "", true, false, "staff42@gmail.com" },
                    { 43, 0, "HCM", "1f652fda-44fc-449f-976c-f059a7840109", "staff43@gmail.com", true, "Name43", "LastName43", false, null, "staff43@gmail.com", "staff43@gmail.com", "AQAAAAIAAYagAAAAENqI8+ttaMljHa1VSo2bhPfFf8Whv5kfQfl7awj21TkhphcbZPlaTxZe/WQWqViQtQ==", null, false, "", true, false, "staff43@gmail.com" },
                    { 44, 0, "HCM", "a213b0d2-f479-4f42-b99d-c4829640846e", "staff44@gmail.com", true, "Name44", "LastName44", false, null, "staff44@gmail.com", "staff44@gmail.com", "AQAAAAIAAYagAAAAEKN0NIljzkhfimtn4jWvCGfOpfv2Rs3Rc3cn1aDkrxgvIWKm9oiqqpwyriAAQPi7bA==", null, false, "", true, false, "staff44@gmail.com" },
                    { 45, 0, "HCM", "1101dfff-d96d-4617-aab2-40bb97da63ab", "staff45@gmail.com", true, "Name45", "LastName45", false, null, "staff45@gmail.com", "staff45@gmail.com", "AQAAAAIAAYagAAAAEFOpDF4HdGrt4OEVnsct6wiNb1izOyxAQXfLox+kvfnpp2V+I8Cx5hif6SiDUnqMVw==", null, false, "", true, false, "staff45@gmail.com" },
                    { 46, 0, "HCM", "273ddcd0-0e6d-4f4c-b730-bc2f2ad800e5", "admin46@gmail.com", true, "Name46", "LastName46", false, null, "admin46@gmail.com", "admin46@gmail.com", "AQAAAAIAAYagAAAAEFKutU3ld/8HNDUrpmbCqFBLgG4i62qZfwN2rGuPhxDxq51sCOJ2VL0IcKrnEJtYzg==", null, false, "", true, false, "admin46@gmail.com" }
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
                    { 1, 1, "Yoga course number 1", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course1", 100.0, new DateTime(2023, 6, 24, 21, 26, 2, 613, DateTimeKind.Local).AddTicks(2904) },
                    { 2, 2, "Yoga course number 2", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course2", 200.0, new DateTime(2023, 6, 24, 21, 26, 2, 613, DateTimeKind.Local).AddTicks(2924) },
                    { 3, 3, "Yoga course number 3", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course3", 300.0, new DateTime(2023, 6, 24, 21, 26, 2, 613, DateTimeKind.Local).AddTicks(2928) },
                    { 4, 4, "Yoga course number 4", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course4", 400.0, new DateTime(2023, 6, 24, 21, 26, 2, 613, DateTimeKind.Local).AddTicks(2931) },
                    { 5, 5, "Yoga course number 5", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course5", 500.0, new DateTime(2023, 6, 24, 21, 26, 2, 613, DateTimeKind.Local).AddTicks(2959) },
                    { 6, 6, "Yoga course number 6", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course6", 600.0, new DateTime(2023, 6, 24, 21, 26, 2, 613, DateTimeKind.Local).AddTicks(2964) },
                    { 7, 7, "Yoga course number 7", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course7", 700.0, new DateTime(2023, 6, 24, 21, 26, 2, 613, DateTimeKind.Local).AddTicks(2967) },
                    { 8, 8, "Yoga course number 8", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course8", 800.0, new DateTime(2023, 6, 24, 21, 26, 2, 613, DateTimeKind.Local).AddTicks(2971) },
                    { 9, 9, "Yoga course number 9", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course9", 900.0, new DateTime(2023, 6, 24, 21, 26, 2, 613, DateTimeKind.Local).AddTicks(2974) },
                    { 10, 10, "Yoga course number 10", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course10", 1000.0, new DateTime(2023, 6, 24, 21, 26, 2, 613, DateTimeKind.Local).AddTicks(2978) }
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
