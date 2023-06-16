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
                    Discount = table.Column<double>(type: "float", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false)
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
                    { 1, 0, "HCM", "e3326fbd-bc1b-464c-9969-2f678e9886bf", "member1@gmail.com", true, "Name1", "LastName1", false, null, "member1@gmail.com", "usermember1", "AQAAAAIAAYagAAAAEE7fwwmQ4QDAGxp1nTx5hEyfeOT44eux3t5R5m/TGHjXocofxw0eDP6wLhXytiAHNg==", null, false, "", false, false, "UserMember1" },
                    { 2, 0, "HCM", "387aff09-d7cb-4a9d-84c3-e0c45d21f870", "member2@gmail.com", true, "Name2", "LastName2", false, null, "member2@gmail.com", "usermember2", "AQAAAAIAAYagAAAAEJnJG+aukmln4P41F8HO7HvO/pYUJw6yw5I3ueDPncR9OdF30+1UB5wr3a6oKnuQ0Q==", null, false, "", false, false, "UserMember2" },
                    { 3, 0, "HCM", "1faad31e-8a6d-48b9-8835-b986b06ac9f0", "member3@gmail.com", true, "Name3", "LastName3", false, null, "member3@gmail.com", "usermember3", "AQAAAAIAAYagAAAAEIVe0vVgZ/XorCdOpNM3Z6qBSt+i/TJFZPZ+RppEnW2jN+2JtlOtJrjy+JiMXSpLeg==", null, false, "", false, false, "UserMember3" },
                    { 4, 0, "HCM", "3c4859e2-f1e6-462e-8eaf-77ffc85a81e2", "member4@gmail.com", true, "Name4", "LastName4", false, null, "member4@gmail.com", "usermember4", "AQAAAAIAAYagAAAAEB8o9OkluwpaQUaX/mrSnlahJ/e1Pc/mZ8uFeWe7xDdUVb1TIGBSkygyAOyWiQZgXQ==", null, false, "", false, false, "UserMember4" },
                    { 5, 0, "HCM", "f70539a8-a2f4-421e-a270-77248579182b", "member5@gmail.com", true, "Name5", "LastName5", false, null, "member5@gmail.com", "usermember5", "AQAAAAIAAYagAAAAEHFjotLHlon1tK0UFhSo2kcayMV1FLAPJ3vsEL7xXyNiDC567fjcG2nnG59m0cu5MQ==", null, false, "", false, false, "UserMember5" },
                    { 6, 0, "HCM", "1d7fe282-da22-472a-83cf-4346256b2edb", "member6@gmail.com", true, "Name6", "LastName6", false, null, "member6@gmail.com", "usermember6", "AQAAAAIAAYagAAAAEO7ObrvOWxXCu2EIbcUaR3oYEB2h92HFcv4cHZlkZB8MiRq+aprGilLAblCJmFBZ7A==", null, false, "", false, false, "UserMember6" },
                    { 7, 0, "HCM", "764b24b3-e289-4e41-b796-a24d1ac359ea", "member7@gmail.com", true, "Name7", "LastName7", false, null, "member7@gmail.com", "usermember7", "AQAAAAIAAYagAAAAEPTxzG0LGb2F2nQCsFbEdwLeiaDvpwYtTOGTd1mZEW98RJoziLs9mkR96KC3lVrC0w==", null, false, "", false, false, "UserMember7" },
                    { 8, 0, "HCM", "e55d603c-c40b-47e5-a3af-6aa9c4813d17", "member8@gmail.com", true, "Name8", "LastName8", false, null, "member8@gmail.com", "usermember8", "AQAAAAIAAYagAAAAEOG734asZ3DHaPVfEZDCLCzRHOKODWpmLLHeUIg04qfC5paTmDVBpccP2PgoNZo6iQ==", null, false, "", false, false, "UserMember8" },
                    { 9, 0, "HCM", "10e3549f-cd8e-4568-8996-b441c40de1e2", "member9@gmail.com", true, "Name9", "LastName9", false, null, "member9@gmail.com", "usermember9", "AQAAAAIAAYagAAAAEElEOLZPVa0DhSRQ9b0x547qjcAUApCQJG6bCXLsWV0UBH1TW8zauIU3DOjVZcD4eA==", null, false, "", false, false, "UserMember9" },
                    { 10, 0, "HCM", "66fcb9cd-4b59-4352-92f2-f74a328fdefe", "member10@gmail.com", true, "Name10", "LastName10", false, null, "member10@gmail.com", "usermember10", "AQAAAAIAAYagAAAAEOAu6xWNibBchDwHeRPpXOkaUO85VjBl98i1WvLok4BUfZNjODLXyRyOw48OL7mlmQ==", null, false, "", false, false, "UserMember10" },
                    { 11, 0, "HCM", "11606e8b-8085-49e0-a967-4f48aa68d9c1", "member11@gmail.com", true, "Name11", "LastName11", false, null, "member11@gmail.com", "usermember11", "AQAAAAIAAYagAAAAEMzuW9QWst81w9TOWpJsVMM+MVAanUgo1aLCYb3jMm4auz4dlt2ZJr4yBl9RPGUQAg==", null, false, "", false, false, "UserMember11" },
                    { 12, 0, "HCM", "cf79daeb-d307-4445-92d7-7da80b170ad9", "member12@gmail.com", true, "Name12", "LastName12", false, null, "member12@gmail.com", "usermember12", "AQAAAAIAAYagAAAAEEVX6d22FPLSWZXnLe82hvnQzChmzlWgoJE4rf2oAP3IMK7ie3e1/J1w19Ss5X+lkA==", null, false, "", false, false, "UserMember12" },
                    { 13, 0, "HCM", "8dc2de6c-b084-49ee-95b5-c4669fa1a1fb", "member13@gmail.com", true, "Name13", "LastName13", false, null, "member13@gmail.com", "usermember13", "AQAAAAIAAYagAAAAEHco6+D9C+sNJj7C0dQ8Qm4UZSHK1S7MKj/5SPABmCxyodGfZwBbsUCSsnpGBRfv0Q==", null, false, "", false, false, "UserMember13" },
                    { 14, 0, "HCM", "b9f080d7-8ebb-480f-9b77-9b060ff89f88", "member14@gmail.com", true, "Name14", "LastName14", false, null, "member14@gmail.com", "usermember14", "AQAAAAIAAYagAAAAEAxj1yoXf5b7lnamEhoeYYUXtyz4BlxxxsFISQ0qmphjsT1BDDEblIYKMIphShKkJw==", null, false, "", false, false, "UserMember14" },
                    { 15, 0, "HCM", "b9ffac78-2717-43fa-bc08-1a8ecf638fe7", "member15@gmail.com", true, "Name15", "LastName15", false, null, "member15@gmail.com", "usermember15", "AQAAAAIAAYagAAAAEBymr7t+DAPubT9Fp+SQ2A62AiagsA+wnaDh2IvKCtgPkPOAXu6pR6LvTj27K87IVQ==", null, false, "", false, false, "UserMember15" },
                    { 16, 0, "HCM", "f3fc0515-f56f-401c-8921-0543b4efeaed", "member16@gmail.com", true, "Name16", "LastName16", false, null, "member16@gmail.com", "usermember16", "AQAAAAIAAYagAAAAEOcpopOqu2hVr4KsSkMPCHaUa763puUOXjxadsXtWepCYbPf96nKsK518D2kPTTaOg==", null, false, "", false, false, "UserMember16" },
                    { 17, 0, "HCM", "4754db0c-0772-433d-95a6-ccb2de1d0131", "member17@gmail.com", true, "Name17", "LastName17", false, null, "member17@gmail.com", "usermember17", "AQAAAAIAAYagAAAAEHAm/L/8DHvfmOBNoyotvt5+ukPGKahuzTi6mhQPLD/92h92bdO0vSdvUo0YfF5qCg==", null, false, "", false, false, "UserMember17" },
                    { 18, 0, "HCM", "7f83bda3-c150-481b-9d99-b0c9e788663f", "member18@gmail.com", true, "Name18", "LastName18", false, null, "member18@gmail.com", "usermember18", "AQAAAAIAAYagAAAAEB81rah7ultKKzU+bVd7jDRo71AY7kYsNcVkxF/LCKX2/Ye9XSHwwUcHS0qww+lErA==", null, false, "", false, false, "UserMember18" },
                    { 19, 0, "HCM", "4fdede92-2197-4510-a5e5-d104473c3350", "member19@gmail.com", true, "Name19", "LastName19", false, null, "member19@gmail.com", "usermember19", "AQAAAAIAAYagAAAAEBiflrlSH3UX963muRb6EdUy47dRYKo67u2WrDj8Ofuw45lUmGKmtwviyF2GLiFmyQ==", null, false, "", false, false, "UserMember19" },
                    { 20, 0, "HCM", "9d1e51ec-0897-49a8-af86-6769923ac91e", "member20@gmail.com", true, "Name20", "LastName20", false, null, "member20@gmail.com", "usermember20", "AQAAAAIAAYagAAAAEMdjcVcFkoJnHbG92CwRWW8gTCG4tdBl8cOGHjeya6AVz2+/kpHI//QEXdcgRlMqog==", null, false, "", false, false, "UserMember20" },
                    { 21, 0, "HCM", "7425d9b6-1272-4571-8543-bdc3078b6a0d", "member21@gmail.com", true, "Name21", "LastName21", false, null, "member21@gmail.com", "usermember21", "AQAAAAIAAYagAAAAEMawTRWf9UWeuztnnxdvXvZTh80vgZ0ygOZD9TLNG2cFrh127IsOUmpt0h3uWGoWpA==", null, false, "", false, false, "UserMember21" },
                    { 22, 0, "HCM", "04e5f49b-c7c3-4f0d-bbeb-c03f82e7e6a6", "member22@gmail.com", true, "Name22", "LastName22", false, null, "member22@gmail.com", "usermember22", "AQAAAAIAAYagAAAAEOZNG0YoMK6M8/CC4Wc8pIn+QhFcenk4dNesc20Zdz+e0crj0pVrtQP9cMC3f81ZVg==", null, false, "", false, false, "UserMember22" },
                    { 23, 0, "HCM", "50b24b74-420a-4bb2-a47f-d88869f00072", "member23@gmail.com", true, "Name23", "LastName23", false, null, "member23@gmail.com", "usermember23", "AQAAAAIAAYagAAAAEF6L22mAMcZgPD2i5uFzR7bf5DoLirMt1pDjgbeCRvvIv7NltSJM5DnNWmDMrtEVXg==", null, false, "", false, false, "UserMember23" },
                    { 24, 0, "HCM", "7d2f30ae-99e2-4ab3-bfb8-f19797c4de85", "member24@gmail.com", true, "Name24", "LastName24", false, null, "member24@gmail.com", "usermember24", "AQAAAAIAAYagAAAAELWv3s7w0zfl+shTyYKwV5XKOZE9JRIf/ho+KPC9Imz9j7hR/SNwzKggGVfi9z9ATg==", null, false, "", false, false, "UserMember24" },
                    { 25, 0, "HCM", "b064004d-d366-4d8c-a9b6-9dc2e5b74940", "member25@gmail.com", true, "Name25", "LastName25", false, null, "member25@gmail.com", "usermember25", "AQAAAAIAAYagAAAAELzZZ37qVVGzsCsH2pcPjsNezhVu0kRg20WWm4ZUqJQMFWCtNoo5HrLicDMR6p8qEg==", null, false, "", false, false, "UserMember25" },
                    { 26, 0, "HCM", "253b578f-9c6e-4b62-8b7c-27bfdcfe7660", "member26@gmail.com", true, "Name26", "LastName26", false, null, "member26@gmail.com", "usermember26", "AQAAAAIAAYagAAAAEKyOfYzfoNdhob6RjByZVK7IhE8PqyyJfJhrDb/UnP9/UZ3l1SUUdYvahNZHoNbfeQ==", null, false, "", false, false, "UserMember26" },
                    { 27, 0, "HCM", "d8150e3f-8b39-4b3f-b865-e87aaf764caa", "member27@gmail.com", true, "Name27", "LastName27", false, null, "member27@gmail.com", "usermember27", "AQAAAAIAAYagAAAAENbHkxL3QbiBZ7i9YeqkYOTuPINjeEV9lwt89jXr11WmgrWTqRlwaEJeGl8j9FRonw==", null, false, "", false, false, "UserMember27" },
                    { 28, 0, "HCM", "c623031c-2c1c-4b6b-985d-bce801a25780", "member28@gmail.com", true, "Name28", "LastName28", false, null, "member28@gmail.com", "usermember28", "AQAAAAIAAYagAAAAEEPxN3vxHCl0XiMN182hPqly4lwedc1OXQD7sueil2O1QHpSaoXls2dpvqg4XpFfjg==", null, false, "", false, false, "UserMember28" },
                    { 29, 0, "HCM", "77cb1bf5-585a-444d-bd21-419a99208321", "member29@gmail.com", true, "Name29", "LastName29", false, null, "member29@gmail.com", "usermember29", "AQAAAAIAAYagAAAAEFYvjbhXDvaUZhCkAU2VHiLKzm96+hvSHVuM/DhpkVPJ1/eoRDkYOu1R6/62lYy0xA==", null, false, "", false, false, "UserMember29" },
                    { 30, 0, "HCM", "8efd5b52-d3d3-49dd-910f-d0d9beba1d39", "member30@gmail.com", true, "Name30", "LastName30", false, null, "member30@gmail.com", "usermember30", "AQAAAAIAAYagAAAAEAnF5dHbeninZ2p44OZd27He7Ne+vhgbG5WsZk1UifnGWXWO584az2YL+SXq+45SVw==", null, false, "", false, false, "UserMember30" },
                    { 31, 0, "HCM", "ec4254d2-792a-4f8b-8137-1c3b222c9f8e", "teacher31@gmail.com", true, "Name31", "LastName31", false, null, "teacher31@gmail.com", "userteacher31", "AQAAAAIAAYagAAAAEEpIiAleEAj7iWhmih6ETXUx2JzHfqSHWaX1BtIuEroXY5MFzH9ETiKTy1Tj7d/eGg==", null, false, "", false, false, "UserTeacher31" },
                    { 32, 0, "HCM", "341d12f8-9917-474c-90fc-759f069861ab", "teacher32@gmail.com", true, "Name32", "LastName32", false, null, "teacher32@gmail.com", "userteacher32", "AQAAAAIAAYagAAAAEHXaNtfEZIDhQ2rH1JiQ5Nkzb2M1CBXOdD0m6I/02B8E340q8YjNbJH6AuHQvi0UAg==", null, false, "", false, false, "UserTeacher32" },
                    { 33, 0, "HCM", "e5b5e7b3-b65c-4a5e-a565-bda6e706be23", "teacher33@gmail.com", true, "Name33", "LastName33", false, null, "teacher33@gmail.com", "userteacher33", "AQAAAAIAAYagAAAAEOnHRKHD4L+eOoYHk0KlvpvMcQw30y6uMhBEojTopXzyJ/+znX35H+Pf0IbM8mTxKg==", null, false, "", false, false, "UserTeacher33" },
                    { 34, 0, "HCM", "24fc858c-4c26-49ef-9bdc-d0343697efc8", "teacher34@gmail.com", true, "Name34", "LastName34", false, null, "teacher34@gmail.com", "userteacher34", "AQAAAAIAAYagAAAAEG6euWIO5q5jutHXBg5dq+0BLBbhmyWcNBisePOjRZt8QggacutoeFefgb6ARu1A2g==", null, false, "", false, false, "UserTeacher34" },
                    { 35, 0, "HCM", "9fe5e2a4-82e5-4a5b-ba66-3450597f377a", "teacher35@gmail.com", true, "Name35", "LastName35", false, null, "teacher35@gmail.com", "userteacher35", "AQAAAAIAAYagAAAAEM4NLugbKY5ciCi0/w7m9qPcch2GyCvdBCjzCtknlwK3qr0tkao+is/HP7VCgIOtoA==", null, false, "", false, false, "UserTeacher35" },
                    { 36, 0, "HCM", "80b90325-d48f-474a-8909-72603150dced", "teacher36@gmail.com", true, "Name36", "LastName36", false, null, "teacher36@gmail.com", "userteacher36", "AQAAAAIAAYagAAAAEL0Ganh4xVVPug1wGTvBQF7zLBG+AgZm381bDzfj+NuZrSF7ODJQbhGGtQZAqoOYYQ==", null, false, "", false, false, "UserTeacher36" },
                    { 37, 0, "HCM", "d73efe0e-1d8c-48c3-a281-16412a796062", "teacher37@gmail.com", true, "Name37", "LastName37", false, null, "teacher37@gmail.com", "userteacher37", "AQAAAAIAAYagAAAAECuHRMDzjvltmEIHtyZx4IiZIIEXgpJ9tBBTMxqHSeA0Wi2CYmxN+gNHi4wq0BMI1Q==", null, false, "", false, false, "UserTeacher37" },
                    { 38, 0, "HCM", "d4be2121-9c0e-40bc-92e5-3227398da332", "teacher38@gmail.com", true, "Name38", "LastName38", false, null, "teacher38@gmail.com", "userteacher38", "AQAAAAIAAYagAAAAEI16NMvFKPG4IXI99fHG5U89Y+g5RUal8ILqT7y60UAYAsEmkdbtPBrPWVMIy06KNg==", null, false, "", false, false, "UserTeacher38" },
                    { 39, 0, "HCM", "4f2dcb70-4051-4caa-b9bb-7fe12928c3ee", "teacher39@gmail.com", true, "Name39", "LastName39", false, null, "teacher39@gmail.com", "userteacher39", "AQAAAAIAAYagAAAAENl9PJJWr0i8cdt6uUfuqz+7h3nSj+qu9ExYkWd8ywFrhEw4on+REg7CFlcYm1vZuA==", null, false, "", false, false, "UserTeacher39" },
                    { 40, 0, "HCM", "0b009e44-01e2-45e5-ac6f-d89539c5a3eb", "teacher40@gmail.com", true, "Name40", "LastName40", false, null, "teacher40@gmail.com", "userteacher40", "AQAAAAIAAYagAAAAEChVaXWfzbRLQrqTCHYbsGmVBimGXZFaupVK4NWwvqA3EqnybnxE3FgUwDAODV4sGA==", null, false, "", false, false, "UserTeacher40" },
                    { 41, 0, "HCM", "479dafaf-9dbb-4614-b5c8-aca8d1efacc8", "staff41@gmail.com", true, "Name41", "LastName41", false, null, "staff41@gmail.com", "userstaff41", "AQAAAAIAAYagAAAAEGp2RvaHwF0ks5QOoWz3NcnrFw2oZ5xnHV4IVo63P2W57gA1i857q9lWfr7Q60DaXw==", null, false, "", false, false, "UserStaff41" },
                    { 42, 0, "HCM", "eff0a403-6718-4a21-88cf-10a33c8c8116", "staff42@gmail.com", true, "Name42", "LastName42", false, null, "staff42@gmail.com", "userstaff42", "AQAAAAIAAYagAAAAEFvCYa1P6N6c2y9tNl8Lpxc5vw7QFqB84nwwc0L9b5ibC2vXEF4GH3YFua2yFbcJDQ==", null, false, "", false, false, "UserStaff42" },
                    { 43, 0, "HCM", "c8c7b032-5eb7-4208-964b-78a3032a4ba2", "staff43@gmail.com", true, "Name43", "LastName43", false, null, "staff43@gmail.com", "userstaff43", "AQAAAAIAAYagAAAAEJaFMrQyglqRO/U79zFcAG3tzQAT/Z/F9j1DXf03EBl5jxsPpU5qFvxlF5mpNdL3YA==", null, false, "", false, false, "UserStaff43" },
                    { 44, 0, "HCM", "db57ae90-c9e5-44fc-94eb-41542d6e79fe", "staff44@gmail.com", true, "Name44", "LastName44", false, null, "staff44@gmail.com", "userstaff44", "AQAAAAIAAYagAAAAENIgQiK6kta+npln7qr3xS6yUPk6hRmm8/Q+e4BcNxhB9qSFp1jl4jedEX/ImCROWA==", null, false, "", false, false, "UserStaff44" },
                    { 45, 0, "HCM", "65350705-87ff-4e4e-afeb-a88e2088009f", "staff45@gmail.com", true, "Name45", "LastName45", false, null, "staff45@gmail.com", "userstaff45", "AQAAAAIAAYagAAAAEKg8BQrkesnm74Hbn+fuEmw8mpvfXgpqZvV1i1qDz9XmEmtq62ejI+aL9HSe+V//2A==", null, false, "", false, false, "UserStaff45" },
                    { 46, 0, "HCM", "3075136b-6e22-47b2-9fb2-27ce31806319", "admin46@gmail.com", true, "Name46", "LastName46", false, null, "admin46@gmail.com", "useradmin46", "AQAAAAIAAYagAAAAEFSxWMos4C5NcnjRSzAkysajrzu4+fjersR83T7/KnRVFXK106/Qbvmw3v5Wz8LK9g==", null, false, "", false, false, "UserAdmin46" }
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
                    { 1, 1, "Yoga course number 1", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course1", 100.0, new DateTime(2023, 6, 9, 13, 23, 26, 832, DateTimeKind.Local).AddTicks(5773) },
                    { 2, 2, "Yoga course number 2", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course2", 200.0, new DateTime(2023, 6, 9, 13, 23, 26, 832, DateTimeKind.Local).AddTicks(5807) },
                    { 3, 3, "Yoga course number 3", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course3", 300.0, new DateTime(2023, 6, 9, 13, 23, 26, 832, DateTimeKind.Local).AddTicks(5814) },
                    { 4, 4, "Yoga course number 4", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course4", 400.0, new DateTime(2023, 6, 9, 13, 23, 26, 832, DateTimeKind.Local).AddTicks(5820) },
                    { 5, 5, "Yoga course number 5", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course5", 500.0, new DateTime(2023, 6, 9, 13, 23, 26, 832, DateTimeKind.Local).AddTicks(5827) },
                    { 6, 6, "Yoga course number 6", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course6", 600.0, new DateTime(2023, 6, 9, 13, 23, 26, 832, DateTimeKind.Local).AddTicks(5835) },
                    { 7, 7, "Yoga course number 7", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course7", 700.0, new DateTime(2023, 6, 9, 13, 23, 26, 832, DateTimeKind.Local).AddTicks(5841) },
                    { 8, 8, "Yoga course number 8", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course8", 800.0, new DateTime(2023, 6, 9, 13, 23, 26, 832, DateTimeKind.Local).AddTicks(5848) },
                    { 9, 9, "Yoga course number 9", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course9", 900.0, new DateTime(2023, 6, 9, 13, 23, 26, 832, DateTimeKind.Local).AddTicks(5854) },
                    { 10, 10, "Yoga course number 10", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course10", 1000.0, new DateTime(2023, 6, 9, 13, 23, 26, 832, DateTimeKind.Local).AddTicks(5862) }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "AppUserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 8, 8 },
                    { 9, 9 },
                    { 10, 10 },
                    { 11, 11 },
                    { 12, 12 },
                    { 13, 13 },
                    { 14, 14 },
                    { 15, 15 },
                    { 16, 16 },
                    { 17, 17 },
                    { 18, 18 },
                    { 19, 19 },
                    { 20, 20 },
                    { 21, 21 },
                    { 22, 22 },
                    { 23, 23 },
                    { 24, 24 },
                    { 25, 25 },
                    { 26, 26 },
                    { 27, 27 },
                    { 28, 28 },
                    { 29, 29 },
                    { 30, 30 }
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
