using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YogaManagement.Database.Migrations
{
    /// <inheritdoc />
    public partial class TransacContent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b2345285-301e-4719-82bf-353029e64d1b", "AQAAAAIAAYagAAAAEMysA6pScCW313arJ9nQV6NSEPIfA8VK9NeCKu7uUjMymvVslCLOkUwRvN0C8D7LAw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "531b6f16-c00b-43ed-b60d-27ccff7e97e7", "AQAAAAIAAYagAAAAEPqSMf0EJAOiVuHHIbypcLq14w472n6qImEWdTXCIntE5l0Av89m6SaYHMwCDM6L4A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "99add81d-a74e-46f9-b56a-84a509add9b7", "AQAAAAIAAYagAAAAEMzvEiVMy9A6UUKItvYsk8j8sCsf1LUq+q7DSlnTZBX21KdoesRd45QtlmUpOqFwoQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "305e84ca-68a6-41ab-a2bf-6dc4cc8d636c", "AQAAAAIAAYagAAAAEOmSczLwv0gD5k98Xdms2lgGztxAGI63ZG7EKbR4fKHoEr+KKCf5UN1igXSvASC+NQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8697d82a-6eed-4f71-8a5f-11e52458aedc", "AQAAAAIAAYagAAAAEPjAMwEyGaEqzkAzWSFwkoxvyU7rq6n5HqCS04CCueqiqUHnz4LncjFNz5CN9w2IoQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d60b2178-f3cc-433f-b7e7-0b872cb66cb1", "AQAAAAIAAYagAAAAEBWA0DJyfhc7796NzkyKGRdMM2F/gdbTm3CJ68TPUcpTjlYiBgK33ReV3Fa/kUpUyg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "091c5d36-3e7d-452e-a26f-7c0e21e1c3de", "AQAAAAIAAYagAAAAELXEFnvy8aU5k4oKdB2Ax7HAhE7jLQvg+yl30wVcqUYdhILEbc/W5aOLCOv2xCoirQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fac7ec8c-395f-4dbd-abfe-99576bc24654", "AQAAAAIAAYagAAAAEBEhCLY6ATqmLvxuTb/LUnngAk5UXK82BWuvE0kjkgDDs/tz8+yA0FJgEjigyxkU5g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f8c8dd0f-fcf8-4be3-b32a-ce2ccbc823ff", "AQAAAAIAAYagAAAAEBTJI9clPdayNsM21LDRgTCNPmilBf65zur0oam/NmTm2pS1R73L8dOukaVsjjJA4Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "454c3bc0-ea12-4bb2-b277-c9c7b60b042c", "AQAAAAIAAYagAAAAELLB1PcxWbIeHdakk7xMebA4QdOiORoIIkFFp2ZJlCQcSRoPxCLmj7tMhZ0OPnzuzA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4a072037-544e-4430-813e-89cd87b8654c", "AQAAAAIAAYagAAAAEJZ4p4k5nqdvy4UCgZiwa/xaIGxz5xJ7Y3AtC7XTipNMBR1o0JOMd00jNs4WPbWpYw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "dd63f166-abbd-468e-ae9e-0c3b7ce41cfe", "AQAAAAIAAYagAAAAEIRzhYpCGovmSYJ0pgXeBA5B3FMLLt8/aW7uCyXdx+8zvmY1MlM/WaGb9VoPNyl2xw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9b22e6de-edc5-4e41-881d-a07608947e27", "AQAAAAIAAYagAAAAEKHbNI1YgK18+pWrfGbOC2xS1EKPw+qnZJ2tyEhZs1Tvv86ip0WU+yMF7WizWQBGkA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e169656a-bbc4-4dc9-b201-3b86a54ff034", "AQAAAAIAAYagAAAAEEFjTnxFkuWwtxSY8ORdwFATPIRWsJ4tctGsk32xnNmM5/hTwxwvaAZAoq5dQuIC8w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b7862bda-8f41-4bc4-97d7-86ab21536157", "AQAAAAIAAYagAAAAEA78FVt39Mkr6EBoLwdLGLxTGn2lJYM6ekkVJRmIIKWwjKWFdG/7NcRa6Rexlja8bg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c37e110b-1117-4090-a5dc-44e38ab7e745", "AQAAAAIAAYagAAAAEHfOv9UyjZsqRtj7HS1zOmFZH4pWuruQGhN5Ohe/aZffGjIK5KlAHXVokCZ5wUr4jg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "253b54c9-f521-47fc-9456-74f166c60522", "AQAAAAIAAYagAAAAEFU1spt/bd0pJnrSyL+2D6p2R6mQCJGgDJaKKmDkYci/fHYhSFymzoIsXrIqIlhlfQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cfb52038-5f1b-4a0e-ad00-e3f77d192ced", "AQAAAAIAAYagAAAAEA+cQqFs7NBfh7XXPsGEPEJi/HyvzY3uinY3X90Z4rPwYgH1DRrzZmHZLFGBXe67DA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4a44ecd0-2512-4e2e-8242-e94f1fd42c21", "AQAAAAIAAYagAAAAEHzcAswxoGvDZ+Iil4RQ83HVaT5B+Au+k2t0r3gMNzEsU6tPc8qexiIR5nZNOJoX5A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5f6955ec-3100-486f-90f1-9cd8320c2098", "AQAAAAIAAYagAAAAEI91oONT2L0yTFe7oXkxye36qu3Vpio6L1Jw7bwWecN1COpi8LCs+Do86pcNzvLntA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0f541f79-4b39-4de8-9386-d7e455c50a37", "AQAAAAIAAYagAAAAEOEXJRYjom7BkjlLaLJs4UocUiH9APp9CDDN2Qu/qWQ+r2zRegBDKj0+BJ+fTHiD1w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e52455c2-a51e-453f-b851-a655ed221f3e", "AQAAAAIAAYagAAAAEEoQV5YBiQSRxx93tSl7frw505nzu+2i8rh0TXkTNN2i1ZEIr41OlZyBIKb1DNX86A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4bdb71b0-7b0f-49c6-ae13-6b11a8439824", "AQAAAAIAAYagAAAAEGmkQI2nBKdSUTFmDCPr2JwySHiDtDXlmERCqYV0Hmg+eYkjYCD6v37XcUB6spyumQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "59702247-f08f-4e93-a2ff-358c8568f983", "AQAAAAIAAYagAAAAEKq31DXGrvPSBBk+6JQ3w3vUbFQOVfEVyMAE1c344vOLq97bbIOM5uqPt0H8PSrzYg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "974c1007-0663-405c-9d77-b61b061e68ff", "AQAAAAIAAYagAAAAEHsEfi2hCe5DcgdV8HMV8OfK1LFMU4GQc58E/dOyx+6tj74kzx2INTPs3jgfEaZS+g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e13e28ed-aca5-46d8-87fd-8109816b25be", "AQAAAAIAAYagAAAAEJQfd05UcwS8Ytiljbsa80db2U9MXQzkl8FRTqSpG/ybCDg5AajlJt6ldlMUa0ep/g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5a927b14-4c93-4566-b54c-cee54c671ead", "AQAAAAIAAYagAAAAENN372feQP8meE+f9j3ezWH9bv0HjjpJZlIFUfafE6bU/ARJUnsCI6FYyyH5WIGnHQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e0e6d911-ab6d-4d3a-bbdd-0f88fc6ff6b9", "AQAAAAIAAYagAAAAELG8PQK0pQP49Ab++w/yXnNOKzc4DUf42UR6lBsZvRtQlq0HrnQUxSGDmKKywVhYlQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8bf0aad8-3e52-4494-b4c6-c7df87955dce", "AQAAAAIAAYagAAAAEM0gmAw/7rHDj2BsiaK2KRB8DzPzgyo0Ibh1bDb69GcVgJ1EDefeHKz+/28N6z+pUQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5185623e-761c-4b4c-91ad-cef38082a8c3", "AQAAAAIAAYagAAAAEJF1UZuYzP1m30hG7dbTu1BBI/xI42vIQQUEn0K5ZbL+RyltO+T7mQRfywdceoGxqA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "22ae1d8d-c617-409b-835d-e575ce3ccb4c", "AQAAAAIAAYagAAAAEGUlDJX5HxypkJ7GWGZ+DtH7cT+bIP0RdSmoj6wtdPMzdtWq6QrzPhD98uBaCi3cFA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f6906ad8-988b-4fc7-b9ed-722008c2e67e", "AQAAAAIAAYagAAAAEKJ5CDiM1Gs7LECKQTw8MS0UWyyBUPDFmfeytR7qy/safijhzD1yblTYzf+XpZVcmg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "13ac2d49-88f4-4a36-afb9-b1b3137df527", "AQAAAAIAAYagAAAAEAW5xChz04O4baZuLqhe6c8yUOxXDEmraYlNdnNGB26pquEJTvIAtWl+r/YUcAHqPQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "af82c9a7-2d63-41ac-9072-8ef7cd908892", "AQAAAAIAAYagAAAAENhN1MWJ5LHrblBgXDIz5bFii69xdanjgUML19cgaOlCxqrtcQPoxxDdoOgKw+sHhw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0eb4db3c-3fa1-4b55-b979-39c539c579b4", "AQAAAAIAAYagAAAAEOY+YuDAceJfVEtQusd1FjDQSyuHvGITk6qRVPkx5Dka+u1aLNj1SSMYo/2KXbzwcA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "eed8ec64-8372-43da-94d8-347d22cf1c34", "AQAAAAIAAYagAAAAEHjAbGeUAoaoaAyxTyc1Y/PmASb7wkU6rXDJ0IzHXuulPsBDEeyC7TDmP7xiL/xyHQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "691b7f00-4c4f-422a-8d81-e01a90235a9a", "AQAAAAIAAYagAAAAEI8IdBsvorPaLkzYqcUmFpysjq8/Ol9UyDzsvmrPKAPpPG8TMYztM1w2w2U69/c55A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f79dda4c-a231-4b69-8f1a-a27a087d2528", "AQAAAAIAAYagAAAAEH++guL0yPncfWD3ngPbC+kkCxkgvII4vSL7k/GOsl7AKbDg6DTEKCamkjONEL57rQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3e490b68-0031-4766-a4fe-237c13afe038", "AQAAAAIAAYagAAAAEP14TaPltFMp34MHoTHuBVongsF0UXo0uEM7oz1+03kqvQR8UWoLR4pN2JiKERZjLQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bccdb28a-2956-422a-bbb0-a93d84e2ea90", "AQAAAAIAAYagAAAAEE/tjbV0SJoEmgOp0CZbhCCu/AI1Rq7r67xvjEnpLoEIULf59Xg5UgAFyJunDnH2bQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "40073cbe-fba2-4523-a389-364fb5818adb", "AQAAAAIAAYagAAAAEOVOJgWmCx/nK+YXsJp6ztO2W+TcU6JNWE2+k89zmFx7pT5q3z/ZZ+5vBedyB57UaQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5bad07bf-b458-4e61-a4f0-6d5fff82e755", "AQAAAAIAAYagAAAAEJ86pR/AF7IKc4hfeUEznr15Apn1MDvWoEZBJfH99Wsn+BldVnlVHrRtwMDR2dCWPw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e7268dc8-3f2a-48e8-95dc-37d1b8bd7a7a", "AQAAAAIAAYagAAAAENb2bPjrR8ZE+wO3RSX8TWEOFtLE/eZeR6MQkooTJMJaHGJlRjvhtzNRI/s8hEnPEg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e7c8b729-79d9-4399-a370-f40740a0f44a", "AQAAAAIAAYagAAAAEFNA6zOmxLyJbUohGgmb5BbtYeH3jhYUcgP7Or4p2RyNKBKZ3edYzHL7tWJU8nBs9w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5fa0f33b-4332-43c3-8a42-0e0cdb8bd44e", "AQAAAAIAAYagAAAAEA4FF0O8tUbQO4Kp4g5Wbp48c7lcZeEHoslBHj+z5DpmJROTeO54DDrRlUr0cV91pA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "32c032a1-6d19-4e2c-8c14-0c6129d37f18", "AQAAAAIAAYagAAAAEBCcu3Qv0R+Jd7FQN9eCexznTvy8HYdDrVZDvAuRUWwkqY+cR2Gh/QfByPbw/sqMrg==" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2023, 6, 25, 22, 35, 23, 722, DateTimeKind.Local).AddTicks(8074));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartDate",
                value: new DateTime(2023, 6, 25, 22, 35, 23, 722, DateTimeKind.Local).AddTicks(8103));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                column: "StartDate",
                value: new DateTime(2023, 6, 25, 22, 35, 23, 722, DateTimeKind.Local).AddTicks(8107));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartDate",
                value: new DateTime(2023, 6, 25, 22, 35, 23, 722, DateTimeKind.Local).AddTicks(8111));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5,
                column: "StartDate",
                value: new DateTime(2023, 6, 25, 22, 35, 23, 722, DateTimeKind.Local).AddTicks(8114));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartDate",
                value: new DateTime(2023, 6, 25, 22, 35, 23, 722, DateTimeKind.Local).AddTicks(8118));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 7,
                column: "StartDate",
                value: new DateTime(2023, 6, 25, 22, 35, 23, 722, DateTimeKind.Local).AddTicks(8122));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 8,
                column: "StartDate",
                value: new DateTime(2023, 6, 25, 22, 35, 23, 722, DateTimeKind.Local).AddTicks(8125));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 9,
                column: "StartDate",
                value: new DateTime(2023, 6, 25, 22, 35, 23, 722, DateTimeKind.Local).AddTicks(8129));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 10,
                column: "StartDate",
                value: new DateTime(2023, 6, 25, 22, 35, 23, 722, DateTimeKind.Local).AddTicks(8141));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "Transactions");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "00063496-d7dc-4b5a-9205-0c9d49fc676a", "AQAAAAIAAYagAAAAEDQceKVRclJYFF4J9bXkpcKofYk2yGCWR1+BnFqV/VbSkqcx3BkKg8zmaKY949s2Tg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "42dc4dc8-101c-44b1-a87e-5bee21497b49", "AQAAAAIAAYagAAAAEFlO5Y3C1ubGBEJYvY/QORXXsMJ+mXOIIaD/GjibHdZBDwWmfmD1vYNklkNFcTHgmA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6f408455-498e-4ff4-a351-5097f6d3036e", "AQAAAAIAAYagAAAAEOa0ekCF3Rv0Ud2VOzHS6ZpJnwWEEd7uSIgP4jGz69duw63oopENAnkbognoeklTAw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "153375df-e149-4688-bb6f-81b7782286f6", "AQAAAAIAAYagAAAAEGGRSQyfZB6qmcrAwtg1ucCSx14JvTaaacxVtEBdmGwjR2SONR1AU2lcwAzaF1sB5g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7911aad0-7eec-4474-afe5-c4268b8141b9", "AQAAAAIAAYagAAAAEChiRFzPvxwN0IWCHubTwuZGAzWma08IsfiEUyPV2KzozgbTI4WfOEanRNaNhro/8g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6bf57b89-7564-4bb5-9e75-87f9034687cf", "AQAAAAIAAYagAAAAELlYEIixC+V43ionBKz3FJ1gGy+vzqpPQjdwwICQMRBKA2cwQ5EscJ6M4HBohQ7+QA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "57c7198b-9379-4fcb-9d54-6865c24eb31f", "AQAAAAIAAYagAAAAEJGnnwIoQtILd9bjv1NXTXdygIgtyoau5HV9LXgWiXBdS70U38iMt71aT1gKkuB7qg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d9123567-cf30-4f03-8fb4-b795193cd377", "AQAAAAIAAYagAAAAEPTP9xorIbTsBfaGlV3Fp8R4IYoKrAp5SDvG7ufJAk85HnDSOOpLDyfiC+hVje23kQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c5abd038-b4b5-4e74-9dce-4d6cdff84d08", "AQAAAAIAAYagAAAAEJNNT7xszlYxbQEGF0VyJu0ogOtEdn29Lh5vnryyl/+6Q7f5zXq8AKJ1jACEIp+XkQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6fef127a-3c8e-4252-8789-602c38b88bc8", "AQAAAAIAAYagAAAAEDhbIpozgSCZ1vR8T3Ex2wWWAtT9WCu/2JakRcIpLPwBodCa/BWydLy20KdVIC3T/A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d7b08a73-4294-4ebc-bc7f-f709957b7def", "AQAAAAIAAYagAAAAEMW4mkf5e4ooTvKeyLxohwsnv2LrjfBqOAFvy8J9cuMEoni+ngi17x4smune/igQ2Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4e59a5b5-c0de-436b-a033-b323cc0b2125", "AQAAAAIAAYagAAAAEBFuR9zFoBcWckIpEuuCm+HYwoXBMnMrxu1KhnsoRQAQKe2mI8zqLsOhb926n5RGqw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6af89b31-9d9d-4855-8f34-9d83ab78be85", "AQAAAAIAAYagAAAAEFU64MfuqyEtT/OEkbZNGe6rgBpShoWREP6Aeu5f15FIeO1MHBi+fethsKU4z1DEpw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3ab0b0e1-fa27-4783-b9af-c35d83cb88d7", "AQAAAAIAAYagAAAAEBDyxVxYTAT/VoE6WXJ1kCiv4RH2J1yTbpADjWjhTbKujjcSUZFLXxM7yHYQWe9VlA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a5759b3e-0377-4661-923c-cc3f5c8ac6a6", "AQAAAAIAAYagAAAAEEGL04OVLIagCLemWuOcNv+FUZoq4h2TGtAaQn8qsKPRCXTo56YHRayHKwJiS/bRuQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f5ce02b2-441d-4516-b0ae-6b5f4b5c5c7f", "AQAAAAIAAYagAAAAEBSL8m2W2KuqIwt6QqpWo/lnmgdq2g5bBa/I7WAKv+mrhhDbQ7aN//QwzifpPvLMSg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d2917ad8-3868-49ad-9690-8be6ab374617", "AQAAAAIAAYagAAAAEKu1Oh88Hp2dfJCrbw9bnrm+HQ7ugB/3omZf9qD/KUsaDeGNnYBN9LcJ15TYPdwX/A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fc9cf225-449d-4ff7-b1ba-a90cea5e4801", "AQAAAAIAAYagAAAAEN/tcM/BAJBX+DPRmFLJXD5XLfUuwCG8X1m7zflOorG7mGuQgW86L2iSlPm29PbVkA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b9d8f060-1d5c-417c-a1d5-1600d09193c9", "AQAAAAIAAYagAAAAEJ6AHZc9He1213tQwextovJPr0mMrH3s6/XmokxwHonu6xv+pA7s4Ef/N3RebXMvuQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "48a70410-8cdb-445a-8785-d3d757098e5a", "AQAAAAIAAYagAAAAEDT/EllsqI4EzxQbwsK4zNVFdTaCzbpMkDx3WKs5pQQqdr8XRd4PnGA67YkpCUghxg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2955e0bb-3b19-4513-8ddc-28cde8ce3f78", "AQAAAAIAAYagAAAAEN69fv8QaXvBgxs+v40r0Zeyg4RpX6ts7bNmx0L8+U0zpNlNtvJKIg4F3xSk1yR53g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "31244400-f542-4e80-872c-e81af7dc151c", "AQAAAAIAAYagAAAAEAnx+MZhgY6Ye9zoOfh61CDiVs5YmLBR5ww/W+8zDz7DeMlm8YsVxvjg5LHPmrQJqg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "971f0368-b1b5-4c21-97e1-3db8badfe7a3", "AQAAAAIAAYagAAAAEMmclIRnLy9UbST2DqL/Ax+s3Z/HIpkBGMGgRBr2NaWpgGTNEUnvIhKHmIR/XT7jnA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9750eec7-2a23-4f59-ab29-588dd261a70d", "AQAAAAIAAYagAAAAEP+bMYPnzzVrAa1u8XMxXYP5IcKZvQRP+fKMSIHBgBaUtfMyZUCwbbOOefrrOYscAQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5e8a4d95-bb9a-4143-a42b-39fd6dceaed5", "AQAAAAIAAYagAAAAENM1blaCzr7rryNlPSCqRFlGFbgxTs5l14qExJ7QBvaqeeJQAtZzyrP1hOOBGkQHmg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "512b2371-967d-4f06-8301-fdc2cf8bceb5", "AQAAAAIAAYagAAAAEMazRgwYRiV5AAvaKeiBlxA5lqELSClz7B/MWhaoMG58kY1YhJKGoZj9uyKFZT3lWA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "88946553-231b-4d6f-ac18-dfadf0513227", "AQAAAAIAAYagAAAAEODfl1ZAczWeeDjl4lqxg5PZ+3kYWozL/eJF4yOvjcfMjNNlv9ul/zQoqq1qFE/0dA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0b06f302-bb19-4b08-9c5d-811fe95750d0", "AQAAAAIAAYagAAAAELQZLEIYUuq/7tKGX5RFdt/fEgu98vnCmLxwBmBEhmqy7ivsVWX+JMWtZNvvT4IIQQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "655497ef-02e1-4649-badc-c0b3ceaef78d", "AQAAAAIAAYagAAAAEASSHsXsPQzdqADMSHg3ySJJT0pEL88wmvKtKeHzhu1JzpaV8t5FSyt0ii8XUb+uhA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "de9afc44-bef9-459a-a9c4-1fac5940df64", "AQAAAAIAAYagAAAAEAhRH2o/LkOChkJBtDSwLT3z+5P4C19/yYgyYvxNFgmzOVWZuD54yfFxJWbKqAJA/Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "837b8e56-14bb-4697-9f1a-dc37be40f5ed", "AQAAAAIAAYagAAAAECugEnLHvqCL+tCuSdjtD7gKQcZK0w3KR8Qi+g6S/5qWyNkTJQqLn+zbBYDlR+GWsg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9352b851-9379-4e08-8b58-f34490df710e", "AQAAAAIAAYagAAAAEIO2eM1AO19cgjDyGYBZ7hUFB0kEzlwypoUZvawK9L9sbGYZtskGsYybQa5Ta3v6fQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4ae48c40-ec82-4c52-9dd0-a7ee480c70f1", "AQAAAAIAAYagAAAAEJiilP15xDNRaPARgJZnpGB4KXMJBddWaNjZrUi8yUL28cVj4byeHuRrmacWJ2gSaA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "26cb8aa9-9ec4-46e0-9842-09052d5e4c3a", "AQAAAAIAAYagAAAAEGwwjCIhCgAKFa+EZ1aoamPG7fgtDECiF3lNNA4ABH+I9ugMD2AJeYuLy4cpnBtObg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3d51e462-89fc-4614-ae33-40232b60cf6b", "AQAAAAIAAYagAAAAEInN4aq1ZWKiq+VyDy+KzlYuIFEvFWfVmniwpRRLmtvJ2o2Yj9/1Zpgf2V713GkMqw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8627d890-3c76-4780-b191-d5c698300542", "AQAAAAIAAYagAAAAEHTuAMOLHF2HD3BRuoXqjAz5nnjwKfSwVIyV3wMaq4Sc1LgnOxSKOXZpTYdYKCj7jA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "51093e21-36ae-4821-9664-b36d2babb2bb", "AQAAAAIAAYagAAAAEH7CrirEHft/3qNBsWQpaEzgopY6QpwSZVqDgCbhuUdT8Q3e/PMvSXhcHJr8o/wE9Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b43ec5b5-b852-4040-8140-7b8d7c2974d7", "AQAAAAIAAYagAAAAEHi5i5odPNVbO+0NTMae3df/ZYtHZy2dYHWVUzrtSBSgo3Cc4zP/SbH3ARLBe//8jw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2ce8f4e4-18dc-48fb-8cb6-69cda1909b42", "AQAAAAIAAYagAAAAEHPHN1rLm+4AkdXH+QEpW9IK+kGWRpTSXIbbzzz8zSSqWmw05Dkb1W+xYmJBSG8p2A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d7f7fe07-6092-41d8-8948-3b27010db427", "AQAAAAIAAYagAAAAEO1mRlSl7c7fYOm5aRaawQCNdpkhDuK1cf0fd5CujMMeAGJNquUDx/t9b0c+8FlV5w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ce65c398-09eb-4e10-9819-2282049cc556", "AQAAAAIAAYagAAAAEN5flHEDVU1PT4G7LB8cpgfzhbuw+wy7cNeXRjDqGopsv/uxSNOQBBzG4gxc2CjQFA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "be37147e-8891-41c0-8f08-f167a6da7596", "AQAAAAIAAYagAAAAEOMxjdvauN8HEslmyk4bc0qQ099JTbggEYVYlmD/wHd+z5ldk5Pnu82FwZ4jGdY7rQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1f652fda-44fc-449f-976c-f059a7840109", "AQAAAAIAAYagAAAAENqI8+ttaMljHa1VSo2bhPfFf8Whv5kfQfl7awj21TkhphcbZPlaTxZe/WQWqViQtQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a213b0d2-f479-4f42-b99d-c4829640846e", "AQAAAAIAAYagAAAAEKN0NIljzkhfimtn4jWvCGfOpfv2Rs3Rc3cn1aDkrxgvIWKm9oiqqpwyriAAQPi7bA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1101dfff-d96d-4617-aab2-40bb97da63ab", "AQAAAAIAAYagAAAAEFOpDF4HdGrt4OEVnsct6wiNb1izOyxAQXfLox+kvfnpp2V+I8Cx5hif6SiDUnqMVw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "273ddcd0-0e6d-4f4c-b730-bc2f2ad800e5", "AQAAAAIAAYagAAAAEFKutU3ld/8HNDUrpmbCqFBLgG4i62qZfwN2rGuPhxDxq51sCOJ2VL0IcKrnEJtYzg==" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2023, 6, 24, 21, 26, 2, 613, DateTimeKind.Local).AddTicks(2904));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartDate",
                value: new DateTime(2023, 6, 24, 21, 26, 2, 613, DateTimeKind.Local).AddTicks(2924));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                column: "StartDate",
                value: new DateTime(2023, 6, 24, 21, 26, 2, 613, DateTimeKind.Local).AddTicks(2928));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartDate",
                value: new DateTime(2023, 6, 24, 21, 26, 2, 613, DateTimeKind.Local).AddTicks(2931));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5,
                column: "StartDate",
                value: new DateTime(2023, 6, 24, 21, 26, 2, 613, DateTimeKind.Local).AddTicks(2959));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartDate",
                value: new DateTime(2023, 6, 24, 21, 26, 2, 613, DateTimeKind.Local).AddTicks(2964));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 7,
                column: "StartDate",
                value: new DateTime(2023, 6, 24, 21, 26, 2, 613, DateTimeKind.Local).AddTicks(2967));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 8,
                column: "StartDate",
                value: new DateTime(2023, 6, 24, 21, 26, 2, 613, DateTimeKind.Local).AddTicks(2971));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 9,
                column: "StartDate",
                value: new DateTime(2023, 6, 24, 21, 26, 2, 613, DateTimeKind.Local).AddTicks(2974));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 10,
                column: "StartDate",
                value: new DateTime(2023, 6, 24, 21, 26, 2, 613, DateTimeKind.Local).AddTicks(2978));
        }
    }
}
