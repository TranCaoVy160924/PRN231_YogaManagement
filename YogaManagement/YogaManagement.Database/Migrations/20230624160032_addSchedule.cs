using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YogaManagement.Database.Migrations
{
    /// <inheritdoc />
    public partial class addSchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name : "TeacherProfileTimeSlot"
                );
            migrationBuilder.DropTable(
                name: "TimeSlotYogaClass"
                );
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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "046248a0-04d4-4e56-af13-ceeda65a3008", "AQAAAAIAAYagAAAAECIBpJUgNa445M+wrovHuDR4BE6deyIKdSLEwKj5IGxLPHBIXmPOP6Ds48Ju4zjanw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8e4bf79b-c338-4d85-8074-ea0861b1cd29", "AQAAAAIAAYagAAAAELFOEd+/ymvwPet4NMN5j257OE0Lju2cADTHmIzaeA0KFBiIeHAguqxfSsbeTosBIw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4e01288f-c194-440a-89df-4f5d96f7e3fe", "AQAAAAIAAYagAAAAEHbiRFojOLeXAPCftIhPHvcV1clRiorTYf+gmV92lqtl6KAwPnVDRly0jHzWGlHedQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8f380d86-77d8-4eeb-b1b0-86a782b11df6", "AQAAAAIAAYagAAAAEEvenkf2oxsk0XW/KPFJYYm+jlxOP8Qdq6iD75oNGX/3e4gE6A4SL5JqurKApy2FAw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7156ee2b-1738-40cb-9f2e-2ffe8e7b4432", "AQAAAAIAAYagAAAAEMloUHbpHFiXwnvqkXT+W0HQ4c++f4oB51SAAULMi0jVGiNHnm801+RH2kagoFccjQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6b997486-0a46-424b-b04e-ce9b3b385797", "AQAAAAIAAYagAAAAEN5QyJXZdFVBZSRWVLpUOZHrA/7qHT0Xo0w0p3gwT21Md47nfxqZhuK0V+p/Yg86jA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e7c1d7e4-99bb-4e18-9a0d-47a5694088dd", "AQAAAAIAAYagAAAAEFkYDdTdWSJyGu9kkf15D7OzDPqwqqzSD+6qQQ+JeXhgbHgRoxuqgubpYR6EuwsfOg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ccb32da1-037c-4bbf-b239-a9baa50eea24", "AQAAAAIAAYagAAAAEIpLlLpXZYUrrEVrin2EW78Qjd2xMXK3Wci0jT1jrH6cegQx0C03m3/NhyM+a6v/7w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "50b09f13-42f5-4bbe-9912-66a4b6853637", "AQAAAAIAAYagAAAAEH7YNRYwGyIZ+I5douihc4UJGh/W5WpuuxSI5OkFbU9Qa3UpnPmy06rDWKJG3H2Lmg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "38283aa1-37f6-42b2-84e2-2e52784242d2", "AQAAAAIAAYagAAAAEOAnKD5lK2AIdKu3lDRyt/HqcjK9s5kG2LTWPBPEymjE5Po48eovggTdGzyrDOnk6w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d8d9478b-bcbd-4836-b1b1-0264adee1483", "AQAAAAIAAYagAAAAEKU9kfQqaPFzurpno+T79FmLs0uBHUznGHgQuWQZwLdaJLLofQDJ8glCbv0sbZMRtw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1687ea3a-c29a-4db9-93b3-c2b84e07aac4", "AQAAAAIAAYagAAAAEBNaepSc8DdPr0YMI8QPYsIsltoU1vD8pH4ZlsFxJM+d4he0LTEwaWrip3UJO32sdA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "47559eec-932a-432d-9659-a1fa99e9be04", "AQAAAAIAAYagAAAAEMo0ECrSJRTkGyaLPl5D0EIbFeLcf9SbIt1UTDqNJYS4HyqNXVMkIeR8jC3g+ir83w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "64bc4d15-b7a5-4ecd-8aaf-e23832e9cab2", "AQAAAAIAAYagAAAAEKoozP0QZS9vgZ74Du6xDOm3gYPo5PlxfXcHpTL+uGNeM7+yZNg/6GV4qdOrLJBUmw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "752b3c01-f5a0-430f-9a87-a00e961e126f", "AQAAAAIAAYagAAAAEBZLgV++OJuyY3aN0Gk/4ufsnLQ9gxJ3NAPWz5axFTmZfrjYiXiw0LCZtAlKencx2Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "87e58fb9-1edb-4451-a1bc-85a34ccbdb02", "AQAAAAIAAYagAAAAEFV7Nvkg6z44exyGm71iJ6s4ZNa95NN7h/NnnCy8Ca+t56VJMuWhxgz415xGt+XlWw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "867ac273-ae45-4672-a116-6f7cc11f5537", "AQAAAAIAAYagAAAAEKYyni45wVaqVD73eqr/TxNAvwtxTcym7ai/bNwU05uCHTPuNhwGB69POLHhNw2NVw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2860f6e4-7eeb-473c-84f0-c568131ce605", "AQAAAAIAAYagAAAAEDgG19oNVDQ9vL6CW7Vg9xWrBtEBKr+QduECrH/g5nJxU+0TEPlyTTPuw5PnToOLPA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5d60e145-072b-401c-9761-3d73d649f993", "AQAAAAIAAYagAAAAEIVdYYtOGdk69YEi/2qpGp5zZ5IZSavAvwdLLBgvSmZ4OaPO9eg+nKB9cRhLXOyKjg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d243a3b7-f0b8-4367-9ebd-12a2f1a6b770", "AQAAAAIAAYagAAAAELfEE0zC/KNbKPPqLHNBT0mVnpHh/ya8dteaxjYQ6wqXpO0CqcOUVPex4d1GDJKjhg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2e4eeb23-e23a-4852-bcc7-9a4cfbc41093", "AQAAAAIAAYagAAAAEKfQH9ouQHZg17f1HenhoXb69TcTla46CDeEZ2NPQu65KWd959IT722O1dHaIx4J9g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "045f10bc-3309-465c-bfb1-a652c8708c3f", "AQAAAAIAAYagAAAAEK6ih4VNRAVb8ml8S+Ji82Y8XKon0cH4f+xiloVdibjWr4K5mTnD+cy/+aLeXgUItA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3c55e70a-e5b6-40f5-a7c2-93b1425dad1c", "AQAAAAIAAYagAAAAEJ2O0X7yHxR1uZL6Gk/xxB+7P66MfKqYaaXVU38oVKAu6PYRvx2tgV/917u9LmcKgA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7b618448-f086-46c0-a663-f919450dd774", "AQAAAAIAAYagAAAAEOoXUmos/4F1ZQQLtDlLYOwVumwyNWxOK54HJIYBRbVNv/+aHdGYB1pZ/FGF2XmzVA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4c29eb03-964b-4be3-8557-994cccbb7994", "AQAAAAIAAYagAAAAEEqVC9Fnco2gHiPYqC/95eKfjkCEpzXS7l09nAvIxXor4l7eGSwdMlMCRTF467y2vA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "282b07ef-48ee-477f-b9b4-d4ba87642647", "AQAAAAIAAYagAAAAED7ztG7XJO7Uttw6CUoLlcDswhnCHhvyGtJQJJBG/AsJyIgycsElRhi/gKvt5NRZlw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ec317b9a-63fa-485e-9897-225686c2c985", "AQAAAAIAAYagAAAAEPobMHbay7xFcP3UK5SlFhxNyTT+ly+TPhN7+3334YYuoYt/h5wHSxypTXCbbAMPpg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "103bd972-6e50-41e1-b7c8-0091e5e695cd", "AQAAAAIAAYagAAAAEL5H8kPmNIU7QuOD6d48wtDzqMZP9xnxfThvEr3KA/bdVZ4UWIps+gqUjVQtX8eyfw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2e32530f-ecad-4dd0-b24d-64095056e26e", "AQAAAAIAAYagAAAAEIp5exnJy+dW7tmaczBKEfD1RzMXqEHKld8c11jJ0ETXN+w6xdArzqcb3gUuK/zgPQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3df8bc1c-2edb-4d4a-bf80-e026c34c171e", "AQAAAAIAAYagAAAAEP67Dw6ZwlNfF2fLON/UvKmjhHpfUANVKa2YBGiAuF3ErkuOVwMjarohjoI2LyfRZw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6242f667-c3e7-43af-8c4a-1a582f502f1d", "AQAAAAIAAYagAAAAEOp4gVW7HGw31uu8nQaygN+hkwhjhQZLCtM7wRTDdxj8vtW6dRhMiDdPEfIDeTyihw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9508762a-6864-40bb-9670-02198a447c22", "AQAAAAIAAYagAAAAEMYfnYZ98dTxr1PDMhmPDrUKFXMHi7l4JxsoCnuNfOYpz1ZX1LSuxeFi/QiYuZfhKA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1e7806e4-9a54-4767-8e5a-39e9da402b14", "AQAAAAIAAYagAAAAEAPh6DAcSMcZ6dWo/5zmFivLZkY/Su1fzT7chAyVBl/M1Rjju+Zs8bbxGDvwwghTAg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "693841d5-9d09-44b6-8e8d-82a6cba93ec7", "AQAAAAIAAYagAAAAEOGQdbCPKBIxNjn8mWTqHxue197kSH/MsUkHtWUiJUIzHMeFcOu3gf0Fd2hhw+JEUw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "619fa294-02f2-4a1e-a26a-058111a202a0", "AQAAAAIAAYagAAAAEOlA5++6dghcd2AXo6TmoMXFyfxRyz0wc6hvFYIsgAnz9KVjGxhSged9rJVoInzqlA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2d2fd81a-e1b4-434b-a0e3-f73a10417f0e", "AQAAAAIAAYagAAAAEIXPhVxuFdLuPhQW+HsXLeRa2f9jw2zi9YLMkkf4+v/IXdxbYwq+uwqTAktksWwr+Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3a82a3bb-6779-4416-8f87-c6cd4403640e", "AQAAAAIAAYagAAAAEG+bEXvx5fqpgPOFq7qbo4uzajffRGzxf4llSjPWpi+82I3PyEQvoIXKtCKIvBiP5w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3c65938e-4d4a-4421-a8f4-d594f8a1150a", "AQAAAAIAAYagAAAAEGkE1hy8KVUiguqOVJglon4UKt/f9aXY4uRGpS9lMJLGJaCA9kc7hcCYo1s5d9fTRA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "14c21dd3-5ac9-4560-b8b1-b87b3003c4e3", "AQAAAAIAAYagAAAAEAwmvL0OllCUJuVAe1li+PtMeLPChCg4H7GPgAZ3Ep9FFypY+kXV6bFcIMrPdTavAQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "dfd68b5d-1e95-449c-9e0e-7c68478e1dcb", "AQAAAAIAAYagAAAAEHx+Qs3FrLQdWMkZj9pcB+66KqRY4lQBFswACMYA/lVRh4e0l9qm5yA3F1YSTPxziw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "26b088f5-fffe-412a-aa9c-0b047b0062c4", "AQAAAAIAAYagAAAAEPCjQVEkKP6QX2c3MtzRdXA99eeCtkpLYN9gsGTIc0VMHL2Q1COgQKoROvqzkA6aDA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "854ac7f4-a95e-42cd-b92e-5eaec7670417", "AQAAAAIAAYagAAAAEIJziZkecagTYXz1abFZ85i34vg9hJrQYNX+b/5/xNnW7g3uEGq+tGmyQNB6J/DnYA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9c85b71d-3829-4208-9727-d01afc0ae269", "AQAAAAIAAYagAAAAEAbR8iGHdQac0NQmidij7UqaZJkWezmdT+w4scGJ3W2ZVtu6aG1octd2PmTOdDC9bw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "75dde971-e226-46e5-b1bd-26043e6a1538", "AQAAAAIAAYagAAAAEFFOeFQEImLTd2Ne/3X0cAVt061QbxzCvg4lYfCnPN2pZHMJ7KRMAYhgDmU5cF6llw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fae07912-1954-4d93-9332-eb6fd5cf8152", "AQAAAAIAAYagAAAAEJIXGZdAz/Dc3CVcpb+NMNYln1LhFlPwUiJEuJglizxuJSplGK9zX1la+cuBGn9K6w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cce27029-3867-4363-a50a-68421d23fc4e", "AQAAAAIAAYagAAAAEKL+xeTDy8WZlb0OnYh82GBmBqRGhR01LaRUztY43IyNBPTqL141w4U39f/nIQrMpA==" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2023, 6, 24, 23, 0, 32, 637, DateTimeKind.Local).AddTicks(8589));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartDate",
                value: new DateTime(2023, 6, 24, 23, 0, 32, 637, DateTimeKind.Local).AddTicks(8612));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                column: "StartDate",
                value: new DateTime(2023, 6, 24, 23, 0, 32, 637, DateTimeKind.Local).AddTicks(8617));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartDate",
                value: new DateTime(2023, 6, 24, 23, 0, 32, 637, DateTimeKind.Local).AddTicks(8622));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5,
                column: "StartDate",
                value: new DateTime(2023, 6, 24, 23, 0, 32, 637, DateTimeKind.Local).AddTicks(8627));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartDate",
                value: new DateTime(2023, 6, 24, 23, 0, 32, 637, DateTimeKind.Local).AddTicks(8632));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 7,
                column: "StartDate",
                value: new DateTime(2023, 6, 24, 23, 0, 32, 637, DateTimeKind.Local).AddTicks(8637));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 8,
                column: "StartDate",
                value: new DateTime(2023, 6, 24, 23, 0, 32, 637, DateTimeKind.Local).AddTicks(8642));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 9,
                column: "StartDate",
                value: new DateTime(2023, 6, 24, 23, 0, 32, 637, DateTimeKind.Local).AddTicks(8647));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 10,
                column: "StartDate",
                value: new DateTime(2023, 6, 24, 23, 0, 32, 637, DateTimeKind.Local).AddTicks(8653));

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_YogaClassId",
                table: "Schedule",
                column: "YogaClassId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSchedule_TeacherProfileId",
                table: "TeacherSchedule",
                column: "TeacherProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "TeacherSchedule");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bd7fcb46-e408-45e1-8083-9915f5d02ef3", "AQAAAAIAAYagAAAAEHUzQjgTc/9rR25KUMo3agSrXMQmRU1RDZphtLPbs1CG7cu7JIYfL6PSJ/0G5eLRRw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "385a12cf-a5e1-478d-acd2-40a330e53238", "AQAAAAIAAYagAAAAEMbxzki2gtDH0TB0w25rPnn++yfnbeUoFwzcPlJgotYkiWqI0CfwIvreO5J32VHjNQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "26cdd77b-fedd-4c0b-9ccb-c9dc3f96830d", "AQAAAAIAAYagAAAAEKgBaE2zveXjTC7DqGiGi3v3k0qDYimOpBSd+Pgc+dlLi0Z9a3iA9g9ZAPnuvFyR7Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7e716e72-fadc-496f-8d07-93c9d29f99a0", "AQAAAAIAAYagAAAAEEyan6YmSFPKPnyvzrbCm8A7pQLMAnLFlZCPIPoWhAx1lAPu+tbp8Nc4bjeoCRLe8Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e0d33bb8-1bbf-47ee-b07e-c2ce7e4e4ab7", "AQAAAAIAAYagAAAAEPkPqJf/aJHtRW3zODKQX+7RijjTnqqrpxCagwsEGoNO6zvw+KfiJDMF/kgCk9G2zA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f26b9db9-fa9d-4d3e-adc6-57d12fa61412", "AQAAAAIAAYagAAAAEHZ9a+jM/Yq+vFkZsD4UCCETKcltBUx9c7jH2cW+zdFNn5ad29/cXqFLdViJIo/h2Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c1e6a298-fb4e-4b05-ba4b-bdf897820dac", "AQAAAAIAAYagAAAAELawv7UVVYAw6MWeCwvMPC1BTgr4FLNQkEo5DGPi2Rdi//REclqYb79aoLIb+7FWww==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e8dafd8f-8ef7-4f6c-82b3-c279365c021f", "AQAAAAIAAYagAAAAEK7v9VT9K/oLLtwl64tXFx0hG0pzZ4bVU+xWjnIQpjeX121wWlHIW7t7dKLFpXGU6w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "736f64ec-1405-4f56-a7ab-48f336aa4837", "AQAAAAIAAYagAAAAEFVC8SyCg9yHSzVKF14IGBNg5N03TZJGr4aLBudMoxlhG1TBYxbA1CggBF4slzT3BQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1979c92b-c17c-48d2-8677-2e3f829ca197", "AQAAAAIAAYagAAAAEDe6N9qU8+a2c+GGCVkRE321hTf6JvNprErRKviXMCL2n4AqiiQ833rTHNZ3VBJqAg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7412c117-6440-4270-adec-8cb81658dd26", "AQAAAAIAAYagAAAAEBDQeMtwHrooPE8T9XF+hk2KDEAxP7Mim8LXzEI/fJ1KhxEzhr/eP6eGJCWROBAvfg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7b4d5b2d-fe4b-4bb1-9d35-9b9335f27124", "AQAAAAIAAYagAAAAEHAcfaNxVrEAHHWpRkVNmh9hd8YtnIjdI3FR4sWeVcVYv2CUwrKEdbVqfx9ebng8MQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a55cc3b9-5a8e-4562-a4a0-65e54779590b", "AQAAAAIAAYagAAAAEKCS0mPN5MZzZPyx3NIoqvPNiaBqYUJGxdMGzGjZJrIs0Ikuvv0DURArFeTjdMwI8g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "96c70c84-e7ee-4264-b4f8-a45dc2463c21", "AQAAAAIAAYagAAAAEHKo/+ZVkgl+zsBWd7ubyHD+FismTsXrc+rnJTjBWLbsCKIvK9Y2KTD4vqs9qs3uUA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "97cfad26-32fb-4b89-9cf6-8e1b88b7738f", "AQAAAAIAAYagAAAAEB1oaH2mlrr4AP82GvimoO/KBBTlqEzOKgfyW3xgVDNKqA5vr9AlpXle64fK9T4LAA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d82ea0d3-8ed7-4b78-8156-2ca2d1f626af", "AQAAAAIAAYagAAAAEFzLIL7OThI4tZOScwhSisAoAYfWHjgYf2KnsORrrf8c6v2ysmdP2jmqfMAAMCiirg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c0a48a39-c7d0-4a64-a357-080f921e38a5", "AQAAAAIAAYagAAAAEIP0j9kyy2G8BxNi7VSGZpp9Gig+VDupWXyz2qMw8mciY0wBjl2fh6DzZ+nH9Ak7nw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "59d5414f-3224-4c34-a903-f815c0d0e996", "AQAAAAIAAYagAAAAEJ/yUPlEyk0GHp0mtGt1vJQoG8u0Rg5KO07oRrYfAV7hmB8ov3virlXo8qbetTezgA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "310e6e5e-ebd5-4574-ac43-58b5ff34dd0b", "AQAAAAIAAYagAAAAEFBveSVgbBRaxLje758ey9poCiMqF78s5If5mKuPHqWrNlPYViv0as7gp2B/AcT3Bw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3ded92cf-9248-4993-9f9b-9d6245996896", "AQAAAAIAAYagAAAAEOKvRX5l/6MrgRS2kCmWxTyCfJjpbWSgY52zgphps8hWUjRrEw4GVBWExKmZkoO+GA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c999a425-5da0-4d04-903f-6006f480af06", "AQAAAAIAAYagAAAAEDhc60yj4eCVuo6tU4inDuMNUD75pRRwEQ+AOPPikas62pCTF7T5zVflAuTCywEt4g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "88f8e998-7fef-4cd8-98b5-0c43d933e6a7", "AQAAAAIAAYagAAAAEI3OzdfqHx3B1rX1wRJsxloKGUHRqhBmB6ZTfcRdEguu/G/AO97JfKS+KEPqWeNdEQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ffa4f3a8-ae65-4672-af7f-ea2022610f5d", "AQAAAAIAAYagAAAAENXeeL3O/PHX3/SspyazVVw9LUmAqmGDcJnFqKMPliQUfNt5L7UTXL4Oc9B4se74sA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8665ee62-f34a-44b8-a675-e468619433fa", "AQAAAAIAAYagAAAAEI9BHYw+fqmJvYutcKZ3DUXHiBruKNpBTihorq6JhF5SKVtFmGfCej70BJqDWll6/g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "abc6adbd-0076-4c00-b53e-988610346180", "AQAAAAIAAYagAAAAEJoc4kZBTyfLnZciCqAcIlJHfUsIIFmdQ1EfxEw9aSrFQACOqbtNDH4H+6Xbiinm3w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f3251ee0-7816-44d6-bed7-9232b31d22f0", "AQAAAAIAAYagAAAAEF5m4R91bn8xoabKpHYXCZvyQ/bIINmXofu+oLDg5pWNIyflcPJ2vVM5KIRJLwI7+Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "376b036d-6bfc-47ec-b7ce-775b3ceac0a7", "AQAAAAIAAYagAAAAEAjpw3hK3QAwmfKyEHQT0o7qDEoM48VLa8mOBuxB8cRgocjCW5wkrMtxWw0yTFyI1w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "df1bbf33-cfe0-4ecb-ab34-a5dbb501dd09", "AQAAAAIAAYagAAAAECND02eV06a5VUe5843AJ5IodCyaUJyssqZxJ6i8EvbNwMNw6JxgTBun0xzUESPeeA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "119c6dc2-5792-4118-b893-1ffbc0192e1d", "AQAAAAIAAYagAAAAEI4wtAoBnaf2bCtfVOkKrRtXHupYm8Y96o5v8fEkJTIGoa8va0lBWSZBOlAO8VDr1A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "115fb386-c116-44ab-882b-a3bdb873226a", "AQAAAAIAAYagAAAAEEws9+sB4vqlUBVZyZoTiRHr4Rzum60dNaWOENHpLbYjgoYdwt6c3k5pHba8VaFn4g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "725364d1-571d-46a9-b28f-b4c9dd52f06c", "AQAAAAIAAYagAAAAEE7+GHI306E+9VobRUQ+vopsruNdv+Pw3vjofJxXmuqXqsFPDgslR8ppFalBg/uCsA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "07f0dcf0-c747-448c-8135-fe59263929cc", "AQAAAAIAAYagAAAAEPy9xeJxUsKe5qzgYyjf1a/PwvwlMG7XiiieVoTcbJeYFv7x7Ze85XD15CGhZdHr/g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cd630657-2878-41e5-aaeb-d95e02f79801", "AQAAAAIAAYagAAAAEEnW7ch0HbidUCJXeF+tcYc9brxlML3qJv9f8PaSp1gPAQvXknASOIOozUDEi+Iy0g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e3547adf-ea85-4734-a0a9-7fec240044ca", "AQAAAAIAAYagAAAAED+x8Q2s8d6C/o0M2O+2fBfEquG/btsAO6+12kPs3D5sQQCQnN/3PEkUz1zemdfQDA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "760607c9-054e-4bb8-9c09-d43f91ba697f", "AQAAAAIAAYagAAAAEGIPjeE6HAxSFy9gR+j313d45C4hYL7opCq8Hx03LZ+5MC+nj0eEnY+EjrQytsjXBA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d02ed2d5-38b5-40d2-bef8-712aa7ee4bbe", "AQAAAAIAAYagAAAAECjcvK2w6xDowomIVL4OLAWAUk5RCybVTjyUasjUmAwyD943Q9TiPYxE0RlukUaKCQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2b0add6c-0793-47f6-a8dc-2f0f1c7a0746", "AQAAAAIAAYagAAAAEJAK9jRjXrN86mGUljprCBc3wzpTpGixQD2f6vVH+uA9fT3d+jHNP//fLHulyOtaQA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "95bf334d-e5b8-4ab0-a0f5-f69ddad38f64", "AQAAAAIAAYagAAAAEGlGn427G6NuQ1aM0IKGfXiq4MdBAlHt8BOBAdEOC1bgNqNAQU9X84h8vJUhvd4lyA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a980153e-0003-45c0-8b70-0c7e17dfcb78", "AQAAAAIAAYagAAAAELSEIARBYV+gj3z4NNM0Nt2iFBrIlnX7RpSmgNSGFdVv3XfwUfi3DOHshsdBVnhJag==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "71c86720-8cc3-4972-ba57-4472c729ec3a", "AQAAAAIAAYagAAAAEI6mnpJwcyDBCnBQsST5xujMgevtx198izov/5jwOY3YJMMiq7iElcsGbCEdHfO8gA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6596cf56-e93b-42b3-aaab-5cedf754bd05", "AQAAAAIAAYagAAAAEGIXHeBocQp4mp+WnyQyZGZYQeeoUjkbySs+NbAwQ6hjJ/xH51Gsey1DrD4uHSo3GQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7b42ea8f-5510-462c-8153-0cdfa4237d69", "AQAAAAIAAYagAAAAEC1OLjpu38aymbQi8Cgxf+YHdj+jXvEyHlEFRW8xIROw6yupPAaGvn+2LCg92nx0kQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "93463931-0ab7-4c81-a5ab-4d60d7d881a2", "AQAAAAIAAYagAAAAELz/WhQtXtXkkwKbjTWNbs8UicucQNd9lXUdUe1dLG2HLK9lErtFMGSFeUzDYpm6pw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bd58f579-246c-4449-8e8d-4291906c3046", "AQAAAAIAAYagAAAAEFukPNlnmZfYWe0JAJdUuIJBCMh6npoz6wggDVKxsyY4NKR9c1SBM6iqfDjk8VTXrw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ed46c752-7766-4776-82bb-99cdf5fb2792", "AQAAAAIAAYagAAAAEHBkDoI68gmdc4QKovX3sos8NPFopMZOEY2+X0EkthCw9imX1wshjgZ3VfCC5btRsA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a5f89084-6d93-4d8f-ac08-4ca94a477713", "AQAAAAIAAYagAAAAEAJ9HdyvzU/NKgieT0GquzoxX4At8cvSw5f3Z/dIc1JixJKL8PwrjnWPEPUQ4rN9WA==" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2023, 6, 24, 22, 57, 12, 840, DateTimeKind.Local).AddTicks(2904));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartDate",
                value: new DateTime(2023, 6, 24, 22, 57, 12, 840, DateTimeKind.Local).AddTicks(2932));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                column: "StartDate",
                value: new DateTime(2023, 6, 24, 22, 57, 12, 840, DateTimeKind.Local).AddTicks(2937));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartDate",
                value: new DateTime(2023, 6, 24, 22, 57, 12, 840, DateTimeKind.Local).AddTicks(2941));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5,
                column: "StartDate",
                value: new DateTime(2023, 6, 24, 22, 57, 12, 840, DateTimeKind.Local).AddTicks(2946));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartDate",
                value: new DateTime(2023, 6, 24, 22, 57, 12, 840, DateTimeKind.Local).AddTicks(2951));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 7,
                column: "StartDate",
                value: new DateTime(2023, 6, 24, 22, 57, 12, 840, DateTimeKind.Local).AddTicks(2956));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 8,
                column: "StartDate",
                value: new DateTime(2023, 6, 24, 22, 57, 12, 840, DateTimeKind.Local).AddTicks(2960));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 9,
                column: "StartDate",
                value: new DateTime(2023, 6, 24, 22, 57, 12, 840, DateTimeKind.Local).AddTicks(2964));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 10,
                column: "StartDate",
                value: new DateTime(2023, 6, 24, 22, 57, 12, 840, DateTimeKind.Local).AddTicks(2971));
        }
    }
}
