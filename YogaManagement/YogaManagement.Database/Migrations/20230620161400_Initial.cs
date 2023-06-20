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
                    { 1, 0, "HCM", "c225d397-faa0-44ee-bff2-299bbb5972d8", "member1@gmail.com", true, "Name1", "LastName1", false, null, "member1@gmail.com", "usermember1", "AQAAAAIAAYagAAAAEC4I1z7W5PrryTtQpXEownYVTHn4YtoDBLj5NeY9tBhixocEi99zeZBoGY/BkUCYuw==", null, false, "", true, false, "UserMember1" },
                    { 2, 0, "HCM", "397090ce-6e96-49ae-8c1d-3bf5c5dbda31", "member2@gmail.com", true, "Name2", "LastName2", false, null, "member2@gmail.com", "usermember2", "AQAAAAIAAYagAAAAECrmByJ5HQEsi1NA0zbQx8wcWuhDJwjUK6iSTabemEPc1eoHs93Niwqxq2QSEqjzRw==", null, false, "", true, false, "UserMember2" },
                    { 3, 0, "HCM", "63962fdb-34d6-474d-8d48-e1a85dee0bcc", "member3@gmail.com", true, "Name3", "LastName3", false, null, "member3@gmail.com", "usermember3", "AQAAAAIAAYagAAAAEHiQOmCGTFoeW10TNHcXhmnFFMYgs3ezyHHOxfqyU0EvkovJt5VKShuwZmdHN+Hadg==", null, false, "", true, false, "UserMember3" },
                    { 4, 0, "HCM", "ac522d43-e48b-4b87-88fc-b427f52c7a2a", "member4@gmail.com", true, "Name4", "LastName4", false, null, "member4@gmail.com", "usermember4", "AQAAAAIAAYagAAAAEEA9ICsPTpdVw3+1WAKOfXze3VZewOGH9dcEgQHplcAc/i1Ceqh5lseswKMfN3i6ag==", null, false, "", true, false, "UserMember4" },
                    { 5, 0, "HCM", "768375aa-cdb2-4694-bb17-9dfbe40339b0", "member5@gmail.com", true, "Name5", "LastName5", false, null, "member5@gmail.com", "usermember5", "AQAAAAIAAYagAAAAEH59NshKAk3nsLazOcdYh/J5ykMjA0iO46lKX+V6SfOtVU8YXBQ2sLknPWsX99KwxA==", null, false, "", true, false, "UserMember5" },
                    { 6, 0, "HCM", "e35488f7-4f45-427f-af37-5747edfe6826", "member6@gmail.com", true, "Name6", "LastName6", false, null, "member6@gmail.com", "usermember6", "AQAAAAIAAYagAAAAEFTWzT65nuClZt+RuXf7D0//n+ZWhkYJvj7ZejQdhZs8mB2PGnfosxgOoho5RBwn0w==", null, false, "", true, false, "UserMember6" },
                    { 7, 0, "HCM", "9d8ed0af-af76-4952-bc42-9e25f072fd7c", "member7@gmail.com", true, "Name7", "LastName7", false, null, "member7@gmail.com", "usermember7", "AQAAAAIAAYagAAAAEIc7boMFRhJIDl9daBi9qj/8Wl1w+8Ac17QhZ8GqNJLVcC0VA1i2wYuJZ3y+2TJ8Pg==", null, false, "", true, false, "UserMember7" },
                    { 8, 0, "HCM", "5751bcfb-6cc1-40d5-a287-e9a84792086a", "member8@gmail.com", true, "Name8", "LastName8", false, null, "member8@gmail.com", "usermember8", "AQAAAAIAAYagAAAAEFI8kIJ479z7cW8shBUsV07IanuV6XQUTDPqb3+zf0KbgAGMQTheYM/IWGs58/8Ozg==", null, false, "", true, false, "UserMember8" },
                    { 9, 0, "HCM", "55236333-a97d-4d5e-ba79-035aa8b361e5", "member9@gmail.com", true, "Name9", "LastName9", false, null, "member9@gmail.com", "usermember9", "AQAAAAIAAYagAAAAEM8s8tLv0k1DJ6FE8wfhC2sS4oG1vt1C8D6BDDqBMfAYhBcCWT2AwwPSYhK1tXeAmQ==", null, false, "", true, false, "UserMember9" },
                    { 10, 0, "HCM", "a2908bc9-8030-4434-b6cc-c53815de5a61", "member10@gmail.com", true, "Name10", "LastName10", false, null, "member10@gmail.com", "usermember10", "AQAAAAIAAYagAAAAECamzwy9zOyly1nw4fkWprYodiwFn5FaDuNG8+FivxJeCk25/X0BeMiOhTsIQk1OEw==", null, false, "", true, false, "UserMember10" },
                    { 11, 0, "HCM", "81087c83-f45b-468d-a35a-1a058153a533", "member11@gmail.com", true, "Name11", "LastName11", false, null, "member11@gmail.com", "usermember11", "AQAAAAIAAYagAAAAED2rvqHpKt7yPHhsNvsiuK18mvF+fDTj+Dc0E4fn1ouE0cMPc/eQrDAbhIYrR6p2yA==", null, false, "", true, false, "UserMember11" },
                    { 12, 0, "HCM", "c194ea3d-7f83-4b69-a7e5-a7ffc3e583e1", "member12@gmail.com", true, "Name12", "LastName12", false, null, "member12@gmail.com", "usermember12", "AQAAAAIAAYagAAAAEI/Wr0ubRTex7BQHeEcdd1Dwq0JzBSa/TJinhKBuY72V2pl3xiYZESRSa8Wq8AzmYQ==", null, false, "", true, false, "UserMember12" },
                    { 13, 0, "HCM", "cffd9ed4-a7b7-46ce-9bad-d8a54b4dfe2c", "member13@gmail.com", true, "Name13", "LastName13", false, null, "member13@gmail.com", "usermember13", "AQAAAAIAAYagAAAAEMUiRr1ptljIHndrHRrMtRW3FmUkQm5YKHvhsImcP+abeq1cFVcVP8ui34bz2YCdvA==", null, false, "", true, false, "UserMember13" },
                    { 14, 0, "HCM", "18689702-db88-4c2e-8ac8-219d128de8a9", "member14@gmail.com", true, "Name14", "LastName14", false, null, "member14@gmail.com", "usermember14", "AQAAAAIAAYagAAAAEMGc9iJjlV+Sr0dlm8+/zm5neXkyC4OSXp38BD66xCqsScpGlHuBojR8y7oH0vDbpg==", null, false, "", true, false, "UserMember14" },
                    { 15, 0, "HCM", "66042d8a-40bc-4ae4-bb5b-42c1d385eb14", "member15@gmail.com", true, "Name15", "LastName15", false, null, "member15@gmail.com", "usermember15", "AQAAAAIAAYagAAAAEO7d30fa9Kj1EjrmeSswU2dq4uFu5X6N8E5GqSVZ+zIuO8y7nRMpqCfbcmXxnpp1/A==", null, false, "", true, false, "UserMember15" },
                    { 16, 0, "HCM", "a2c29440-23b0-41f0-bb12-db9f32f0ed15", "member16@gmail.com", true, "Name16", "LastName16", false, null, "member16@gmail.com", "usermember16", "AQAAAAIAAYagAAAAEFOTcfmjog2gJkEtLLcNvLTQt2CYHAxVXxpx42p4Qtx0RSN6UIg6rQyLNXCVp9svlQ==", null, false, "", true, false, "UserMember16" },
                    { 17, 0, "HCM", "81c71f8d-094d-4517-8cf4-ddd664094c5c", "member17@gmail.com", true, "Name17", "LastName17", false, null, "member17@gmail.com", "usermember17", "AQAAAAIAAYagAAAAEBaTTbrkRnNGRtLlP5gipt2LEqLILcQUUHitf/vnPoiOXsRz4CLhsTpI7frrQ0hszA==", null, false, "", true, false, "UserMember17" },
                    { 18, 0, "HCM", "348dc881-054b-4507-9af4-e9f8ea95abea", "member18@gmail.com", true, "Name18", "LastName18", false, null, "member18@gmail.com", "usermember18", "AQAAAAIAAYagAAAAENUKJHiMVTvoBrve58P7Usm5vf9eag6lXcCNOdLHrrdhRZ88FLOovIz2eIEQmY6flQ==", null, false, "", true, false, "UserMember18" },
                    { 19, 0, "HCM", "fb8e08ca-1a47-422d-81c0-2e6b8a1e228a", "member19@gmail.com", true, "Name19", "LastName19", false, null, "member19@gmail.com", "usermember19", "AQAAAAIAAYagAAAAEFg8pHmjRVWHaNUyBJfTkkHBqri2KMZFQRORVMQPcSas2A/31A+3o5oEwVbzjJl56A==", null, false, "", true, false, "UserMember19" },
                    { 20, 0, "HCM", "281f458b-5982-4376-b050-0197e89c81a5", "member20@gmail.com", true, "Name20", "LastName20", false, null, "member20@gmail.com", "usermember20", "AQAAAAIAAYagAAAAEMdphJKBC1Neq/VXP21NaF1PmSvF8VFncjqa7KjeSwYG2w+Wrx1ge2Sj+/N3Tlkcrw==", null, false, "", true, false, "UserMember20" },
                    { 21, 0, "HCM", "6d237951-46f7-40d7-ab10-96485e0f7235", "member21@gmail.com", true, "Name21", "LastName21", false, null, "member21@gmail.com", "usermember21", "AQAAAAIAAYagAAAAEDX1QaXRliv6rMwglAkCqex38mxWX0yN/dUqX8Z1RuLG4mjxIQVHyosIr64ttGUdrA==", null, false, "", true, false, "UserMember21" },
                    { 22, 0, "HCM", "390d8bea-77a4-4538-8217-0cab5b10bb66", "member22@gmail.com", true, "Name22", "LastName22", false, null, "member22@gmail.com", "usermember22", "AQAAAAIAAYagAAAAEF15ZRSO8H6PzyrhuniVnDLILPBDtzVYNLn6y6JjoEKTbxmps0wIT9nfGzCxzBOy3A==", null, false, "", true, false, "UserMember22" },
                    { 23, 0, "HCM", "60f3e8a6-6ef5-4ba9-b5ca-aa68dd100d39", "member23@gmail.com", true, "Name23", "LastName23", false, null, "member23@gmail.com", "usermember23", "AQAAAAIAAYagAAAAEJp2Dca5JgV9fn+qCDpY15PgE+UqfqNwcWNU7nDbHXYZ52XfrcbBmq54no9DoV1Icw==", null, false, "", true, false, "UserMember23" },
                    { 24, 0, "HCM", "40097d09-03fe-4b69-880c-0954f4cd2ff7", "member24@gmail.com", true, "Name24", "LastName24", false, null, "member24@gmail.com", "usermember24", "AQAAAAIAAYagAAAAELXL6sfHEwFXsMBHP4tPMF8wfKKPvsrZSdj5QwuH7AKYNd8/HDwZ7AnkthZCDR+w9w==", null, false, "", true, false, "UserMember24" },
                    { 25, 0, "HCM", "e5d57c93-c97a-4318-ac03-c9dfde669c37", "member25@gmail.com", true, "Name25", "LastName25", false, null, "member25@gmail.com", "usermember25", "AQAAAAIAAYagAAAAEG4RiECn/2zy6BUDLcm3ui4mIUj8nXfm/SPOiTms0hQUKfVFDsnQAbHQszosG8bVOw==", null, false, "", true, false, "UserMember25" },
                    { 26, 0, "HCM", "9b10fc5f-456a-4ad3-b628-73f69a61b655", "member26@gmail.com", true, "Name26", "LastName26", false, null, "member26@gmail.com", "usermember26", "AQAAAAIAAYagAAAAEAgynsZXMutrBa0iWvDfp61bLK2JzExL1X4gNnzJZ3myJRRxp9ykwbmJ13g7PvxbZg==", null, false, "", true, false, "UserMember26" },
                    { 27, 0, "HCM", "52cb90ba-2500-4c15-b812-a9ecfd444b6c", "member27@gmail.com", true, "Name27", "LastName27", false, null, "member27@gmail.com", "usermember27", "AQAAAAIAAYagAAAAEHnKj1nbl4xSNtm86miSFzQ9Ei8fVqzNgh4OfN3bNgNA8RWN5g96dOvxIt4x/DawcQ==", null, false, "", true, false, "UserMember27" },
                    { 28, 0, "HCM", "59c40c2e-c357-42c0-8049-e49ed0de33bc", "member28@gmail.com", true, "Name28", "LastName28", false, null, "member28@gmail.com", "usermember28", "AQAAAAIAAYagAAAAEAaz59uLgCWNBcCUFWx0UJO3tdGwLAGo/13HfgLseYz9sXWJurdUwrLhHhuK9xEtgQ==", null, false, "", true, false, "UserMember28" },
                    { 29, 0, "HCM", "04d46b7d-cda1-427d-a3c1-ff0b6de9e213", "member29@gmail.com", true, "Name29", "LastName29", false, null, "member29@gmail.com", "usermember29", "AQAAAAIAAYagAAAAEAlkeEppFoJ7OqaoQiSvtsE5Keyv8QJ6ZBHCtOmZeHYnfwf5hYjdi1aZ0hdOo7xhHQ==", null, false, "", true, false, "UserMember29" },
                    { 30, 0, "HCM", "fad9af76-5774-42f7-82b5-e83a7361fbc7", "member30@gmail.com", true, "Name30", "LastName30", false, null, "member30@gmail.com", "usermember30", "AQAAAAIAAYagAAAAEKb3b/X+2VAbzDZx1jncxE960117liQxxDNtDsJmheQrI/I36SAmAtWZf/Q45B/lMg==", null, false, "", true, false, "UserMember30" },
                    { 31, 0, "HCM", "15b77a1a-537d-4d67-b871-5dd8d1a5b517", "teacher31@gmail.com", true, "Name31", "LastName31", false, null, "teacher31@gmail.com", "userteacher31", "AQAAAAIAAYagAAAAEGPjuYEysmemr9/uAABWm2UkzwI0TJ1WXtD5tqJKaVtLAkVHwZsITpjjU17ebwFHJA==", null, false, "", true, false, "UserTeacher31" },
                    { 32, 0, "HCM", "a2f16274-8698-4815-8a14-8bfdfd7b824f", "teacher32@gmail.com", true, "Name32", "LastName32", false, null, "teacher32@gmail.com", "userteacher32", "AQAAAAIAAYagAAAAEMprAwdWHiK8jeNgLvyaWX0tK8ZiLdRKvY0MrrE1ipnIp1KMrg7T48nYQ2D6ASWOvQ==", null, false, "", true, false, "UserTeacher32" },
                    { 33, 0, "HCM", "469fbc0e-8ec8-48bd-8b64-26669a00ddfd", "teacher33@gmail.com", true, "Name33", "LastName33", false, null, "teacher33@gmail.com", "userteacher33", "AQAAAAIAAYagAAAAEJBHyV12MZKPKLXKuW1BdG4juUQt4QdO4FdzyGfxeCbdjodux+MA17jnXPqbHLLA4A==", null, false, "", true, false, "UserTeacher33" },
                    { 34, 0, "HCM", "bb50f826-1d9b-40b8-9708-a26060d7f102", "teacher34@gmail.com", true, "Name34", "LastName34", false, null, "teacher34@gmail.com", "userteacher34", "AQAAAAIAAYagAAAAENgzN/mACcuDZEAaRDngiqsh2EQWtM4wfWzFs6qtdsRQa1pZcvkHJ05uiT10q1lzAg==", null, false, "", true, false, "UserTeacher34" },
                    { 35, 0, "HCM", "afbe7b6a-6cdc-4d99-a191-bcf7ec96ee79", "teacher35@gmail.com", true, "Name35", "LastName35", false, null, "teacher35@gmail.com", "userteacher35", "AQAAAAIAAYagAAAAEDWXFOGVSGOrLKrF6O+vyzgRhx70JlcO6+j+nZiL7KNA2pUdKLXVS7jjtht3ZZ9oPA==", null, false, "", true, false, "UserTeacher35" },
                    { 36, 0, "HCM", "1cb04979-21f2-4247-b2ad-008a7f176c58", "teacher36@gmail.com", true, "Name36", "LastName36", false, null, "teacher36@gmail.com", "userteacher36", "AQAAAAIAAYagAAAAEJZtLDXgjTYOmlBKxT2VlI1ibKt3wv1PFm79+p+eXa/gRBUXalL9glflkxpnihe3kg==", null, false, "", true, false, "UserTeacher36" },
                    { 37, 0, "HCM", "7015266c-6bb5-4ba8-a93f-a02d621867d0", "teacher37@gmail.com", true, "Name37", "LastName37", false, null, "teacher37@gmail.com", "userteacher37", "AQAAAAIAAYagAAAAEO0z4bFoUU5DXJOf2+EQW/XV3/ZOQiwJL2qhUES56gJ6eE6qUhT7twc5FcAR9J9YIg==", null, false, "", true, false, "UserTeacher37" },
                    { 38, 0, "HCM", "fece090f-d940-433d-824f-096d9427a733", "teacher38@gmail.com", true, "Name38", "LastName38", false, null, "teacher38@gmail.com", "userteacher38", "AQAAAAIAAYagAAAAEOzYQbsPQAF0vaMsuXOiTuRY7aGf8GmahljqFuBPVRRf2iaRczujQ8g+AQeuBocWqQ==", null, false, "", true, false, "UserTeacher38" },
                    { 39, 0, "HCM", "944840a2-1d43-468a-ac45-1995acd745b5", "teacher39@gmail.com", true, "Name39", "LastName39", false, null, "teacher39@gmail.com", "userteacher39", "AQAAAAIAAYagAAAAEE2ha3K53RWQrJGVAUibhFKSx291Cc7sJJhKnUk/QOo2NszOKr3g6WZElYtYgSK00A==", null, false, "", true, false, "UserTeacher39" },
                    { 40, 0, "HCM", "bb6c5ee0-f5fe-419b-bb29-7f440614665a", "teacher40@gmail.com", true, "Name40", "LastName40", false, null, "teacher40@gmail.com", "userteacher40", "AQAAAAIAAYagAAAAEIAymWo80Ol6ieFhlaqdodc90Gx7t5rpbd3iY6sP9gMHTvabL7enVvm03liaZGKCxg==", null, false, "", true, false, "UserTeacher40" },
                    { 41, 0, "HCM", "ff9af491-28bf-4571-93eb-b496012604c5", "staff41@gmail.com", true, "Name41", "LastName41", false, null, "staff41@gmail.com", "userstaff41", "AQAAAAIAAYagAAAAECdhqOQGBaMdtSPFCvihJZ7FbDkqvuyKw2uNu++BXy6w2BqHDxSmKddYwMFCQ3/a6g==", null, false, "", true, false, "UserStaff41" },
                    { 42, 0, "HCM", "e905d94d-18ff-432a-b17c-a4bd26bb6794", "staff42@gmail.com", true, "Name42", "LastName42", false, null, "staff42@gmail.com", "userstaff42", "AQAAAAIAAYagAAAAEEwCza9KTEPaE16H6jluYNmZaZ2Wd7EpQb0vX9v9v2ueKefZIjhgnUiDSaKblN0Axg==", null, false, "", true, false, "UserStaff42" },
                    { 43, 0, "HCM", "98e9dc71-fffa-4874-9df1-01f5be68d4c0", "staff43@gmail.com", true, "Name43", "LastName43", false, null, "staff43@gmail.com", "userstaff43", "AQAAAAIAAYagAAAAEIHrVJRwlHRBGIE84Ua3WclQWynx2I0fmrB8KH9w/Dcn/0eJSR7xhwLMhyJAhcmnBw==", null, false, "", true, false, "UserStaff43" },
                    { 44, 0, "HCM", "19a6a070-ea78-49cf-9d3b-7c29ac9d549f", "staff44@gmail.com", true, "Name44", "LastName44", false, null, "staff44@gmail.com", "userstaff44", "AQAAAAIAAYagAAAAEHn6YKRQYrcP9YkJd4Qf5Lpf5Hl527el8vDburGae3eDEKhgmMtlJkIa+xf3d2lvXg==", null, false, "", true, false, "UserStaff44" },
                    { 45, 0, "HCM", "f2d285a8-0ca7-483c-a0f5-99ba2c842e76", "staff45@gmail.com", true, "Name45", "LastName45", false, null, "staff45@gmail.com", "userstaff45", "AQAAAAIAAYagAAAAEDh1JOqxnce9h40+Ohd3PCe0MdH3uoQHPeiRAPQxh4oQdrXBkt0V+Bby6davZ+6TNw==", null, false, "", true, false, "UserStaff45" },
                    { 46, 0, "HCM", "782038e0-ebb1-4b64-b735-8545c6cfc3f5", "admin46@gmail.com", true, "Name46", "LastName46", false, null, "admin46@gmail.com", "useradmin46", "AQAAAAIAAYagAAAAEK4Rr5fv7J3ltPFenMgcpwu5W0jpOhXgopGXjCHQk3GC4Ka7Yf4B0CH6Hw8ZUQVw0Q==", null, false, "", true, false, "UserAdmin46" }
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
                    { 1, 1, "Yoga course number 1", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course1", 100.0, new DateTime(2023, 6, 20, 23, 14, 0, 584, DateTimeKind.Local).AddTicks(6358) },
                    { 2, 2, "Yoga course number 2", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course2", 200.0, new DateTime(2023, 6, 20, 23, 14, 0, 584, DateTimeKind.Local).AddTicks(6378) },
                    { 3, 3, "Yoga course number 3", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course3", 300.0, new DateTime(2023, 6, 20, 23, 14, 0, 584, DateTimeKind.Local).AddTicks(6382) },
                    { 4, 4, "Yoga course number 4", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course4", 400.0, new DateTime(2023, 6, 20, 23, 14, 0, 584, DateTimeKind.Local).AddTicks(6386) },
                    { 5, 5, "Yoga course number 5", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course5", 500.0, new DateTime(2023, 6, 20, 23, 14, 0, 584, DateTimeKind.Local).AddTicks(6389) },
                    { 6, 6, "Yoga course number 6", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course6", 600.0, new DateTime(2023, 6, 20, 23, 14, 0, 584, DateTimeKind.Local).AddTicks(6393) },
                    { 7, 7, "Yoga course number 7", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course7", 700.0, new DateTime(2023, 6, 20, 23, 14, 0, 584, DateTimeKind.Local).AddTicks(6396) },
                    { 8, 8, "Yoga course number 8", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course8", 800.0, new DateTime(2023, 6, 20, 23, 14, 0, 584, DateTimeKind.Local).AddTicks(6400) },
                    { 9, 9, "Yoga course number 9", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course9", 900.0, new DateTime(2023, 6, 20, 23, 14, 0, 584, DateTimeKind.Local).AddTicks(6403) },
                    { 10, 10, "Yoga course number 10", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), true, "Course10", 1000.0, new DateTime(2023, 6, 20, 23, 14, 0, 584, DateTimeKind.Local).AddTicks(6408) }
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
