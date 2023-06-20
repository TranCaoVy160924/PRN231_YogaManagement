using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YogaManagement.Database.Migrations
{
    /// <inheritdoc />
    public partial class ClassStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "YogaClasses");

            migrationBuilder.AddColumn<int>(
                name: "YogaClassStatus",
                table: "YogaClasses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fdafbb99-348f-47d1-87fc-7105e6e3095e", "AQAAAAIAAYagAAAAEOckDzhZn1Aj82lfJbHHt2h+1M8m+cNgM03NjWmg67beJvITeJNK1cq2R080St6Nkg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "78b42ecf-baaf-47ac-a6dc-490e373641f7", "AQAAAAIAAYagAAAAEBtDGuk3SdkPbgKPzT+MgElbjpQOY0AyYF+hajm3nzKpK17DM3Q8Mpw1XcwgpA0izw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6cfa5c3b-b0c0-4f9c-8aea-4074e6201c21", "AQAAAAIAAYagAAAAEAAaudVBiMQQezhmYxZt4LRl2/ajFy+OLpMsWAuQFCsb5O2VnF8shuoZQ2dgMRr5Ig==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "63f5e5d4-0704-4a66-92f0-c0c3e5e59270", "AQAAAAIAAYagAAAAEF0t2CBtLTU6pABGQV6KKKRlkFPAJQv5v98yAbFIcYDD6oEncwSodDD3pEZM7Nug3g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d4a69183-d21c-4bc9-ada8-1b73f3b6e880", "AQAAAAIAAYagAAAAEL/IPjEw88MzkKL+PvyST+PhSwpg8gQ9aUfxfHzL8We3ST/8/yOW9zpbWMsrBDav5w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "41bca441-c828-4012-b9d2-2dacfbbf6933", "AQAAAAIAAYagAAAAEE1wBBopEnCFoq21E1i0zZ4x/cW9IDMmyK9GbV2osWf7WJU+BMBuFAoTI6PAZxnjuQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "99b0bd7d-8602-4ba5-a665-ceb6c6d2f7af", "AQAAAAIAAYagAAAAEGLMkAPwVFBp2t53A+Z2T4aULH4xoeSRtbfPjpnSFswrBQSfEr5GEj1urk72C7x+BQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b5a0d4b4-8fa4-4a1f-9598-48fc3d973556", "AQAAAAIAAYagAAAAEM56LBG5oz2CxUTQFstHLUycM63PvRCWJi+S5av4QRqNTySqao3lGjIevoXYzflXwQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e5429bce-b2cd-47a5-a755-d4c1e9417ae4", "AQAAAAIAAYagAAAAENMRapL1Upanx3QcJHWUqvvNpF6uXarDyLwwvS4fU7B0bCXb3gqyl3choK00OVRIpQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "209930f9-a0d6-4e8d-bc7d-5a6ad7b9ab8a", "AQAAAAIAAYagAAAAEJlb4C6JGS8LSBGFzBA3R79RXu7M2VkLDqXkhiZI6oerrr46EtfxoDlLHJTz8q1kNQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "94fcdfdd-3663-4037-95ce-10c35853f1cd", "AQAAAAIAAYagAAAAEPWUFWTn93ikz7lsSdVvpK0zfePeyPO76Vd3V7pTdXNNpMKBh1wnK+AOVgtbrN5iXg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "aa45de2e-fc37-49ef-8036-2b21d366a56e", "AQAAAAIAAYagAAAAENXRCKdMavuwCKhreJoxx/B0CQqQJw6SluE3uhvQy4cP+o1tpiU8X3isxDYSgX9d1w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "98d8d9be-98ca-490f-a786-3875f9792350", "AQAAAAIAAYagAAAAEKi5WBSvvMhwv39gZWGWPiW1990Z/sRGgWX/ODNZKW22alHGorrbNRrGwux7celR4A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1f501ecb-60b8-480a-9bb8-a952f5deb1c6", "AQAAAAIAAYagAAAAEICY10j2cLAlLUsUZ0Aue2pnH0c8g0j/CmRgMdx93I+Q11QuVyWK7hOWpGQa9G5MXg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "819897fc-ac15-4cdc-a042-5bb964087f7e", "AQAAAAIAAYagAAAAEPNIH89VuLMZiET+iIM1j+fsrNV5OACPlk/fWAFUYVDVaYXlixWSkaLgGJcERXy1+A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ba22e297-4026-49ca-806f-01bffd046efe", "AQAAAAIAAYagAAAAEMkFBDYuum2L69glZcJFCm15nt6BvmYzSmWE5L+ju583X6rOds9r6kPjD9LU2rq1oQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7401a07a-2787-4a27-a870-855b40385934", "AQAAAAIAAYagAAAAENP8XP1M49M+UxFUKt4Vlk7zMtmO/Xrf4zm0fnxFjnchRP4q9Ms1pvJBBnsCsPDnoQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "524790f3-c0ee-4d8b-9655-efd0a3d09ce8", "AQAAAAIAAYagAAAAEMfQErszccqf3wdFgKvHtcYb3/944hfjK4AtE/Om3rBgvjXqAdy15HhzqnWK4V/P7A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7a3d8824-533b-45da-94c4-68eb99417344", "AQAAAAIAAYagAAAAECIJ/xos8aeOvHuZdy7K0Dz6Zyz/LQNDRYMsPThOqH3H71fc3Lj/0kc4ZKb84riJOQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "38dab200-d4f4-4e36-a746-b7fbabf1b938", "AQAAAAIAAYagAAAAEOu4kwZO3ldoYY18gJX5ahvtOuYky0f0QjGn58QNMk5kb75PJK/gM2BcMvrg6bi1MQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "86a53ff6-e86b-4196-ab3a-e46e4a874814", "AQAAAAIAAYagAAAAEJjLAGtMEb6hwQZVR01PsuNg6E5JhiVxIiMs+EinllRBHoiJOu1UKFnYAFOgBVFFJQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "dbfa1b77-99e7-4672-aef7-899aa8050265", "AQAAAAIAAYagAAAAEPOPAHH3eDof/+OzEuGqvfnKdIMLnCPvB+eyvSEcV6J8/GD/SfUDtNOnV3YpTcJlwQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4a73d583-656f-4839-88ca-b9834ffc9a40", "AQAAAAIAAYagAAAAEF1ml42Zi7JZU7IvMGeKayGwiDkJqI/Eb8Hi3mUR2bDzqTIBRbytBDzCdOI6cbFnOw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a34b81fe-196a-4b27-b932-0192aa0e610c", "AQAAAAIAAYagAAAAEAD3I5QLC/+l9uglbdh1Bu/lr3TQ24q+7xmt2XeNVkPUT1Xxo0CKoF0PCZ2mVdYUMw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b139cd73-e670-487a-9c90-219490d1690e", "AQAAAAIAAYagAAAAEFQQWF+XbjpFJyejbl2cm9bEGvkQ78QKrr0F5y9JYwdxwifVS5nGmvJ/UT28+8l9Nw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "60ec90db-baa4-4122-9252-f22b45cc921c", "AQAAAAIAAYagAAAAEPLO/bNRwVutLDZtV8GbGu6gQ6peqD0fQqw+pip+goRlCDF30D48K9//RhLEcF7HOg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "19c7e767-954f-48ba-b7ba-e7a635bdb52a", "AQAAAAIAAYagAAAAEHT0clrSmC49OyFVaEbrw27ck24vdIFmJUEJDNSMBBB9w8p3JVjQP3vWuAbruwfZJA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f5069def-bda2-4267-80a3-77a3f3015fc7", "AQAAAAIAAYagAAAAEGLPdj8uX0CyjTS6ZsXhtDxYz46XHAseK2/ZmqmSk8vS5LsijtiaIsNib3nt7+RUIg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ead3807a-2d24-47c3-8bae-d71bd6600d57", "AQAAAAIAAYagAAAAEDHmoL8BosTMvDCW/CI9tKb5QXk4MOHBOP1Qocqa/xh4sfjxCJ6BI+qi+D2e6npYPA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "67d4a9b1-e834-4aa4-aa8f-6a49acdef5a9", "AQAAAAIAAYagAAAAEIa3YkIvnYBGuEW9XyZWYKwVg1472/J8ySSb09Z13YcTXjg3zkDdBBA2mIndhp8nLw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c81bab77-6c7e-416d-bf70-ad0df0bd27e1", "AQAAAAIAAYagAAAAEMqgmKbLoYE2TMaqH/M81Uk7b2QJ9+7pLyiSHP5MPSW1q+rPHghdezYqfBC2uE/LOw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "953bb74b-2a02-42cf-a85b-9f28368555fc", "AQAAAAIAAYagAAAAEAEeEUD9zD1SMTxIyDt9xryTWXQxKLZeg0iGn8yWluIrnOqvG8rFlQojOJa5JWebyg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "43a7470d-0ef9-442c-bc9b-9e5a717be7fa", "AQAAAAIAAYagAAAAEKxHX4a6nujJaZWCh+iYtdCmwB/2OZbD/p3azKviAbLnBGSGdd2XOtTzH5k2kMsLLA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0a8be2fc-5843-4f67-a766-c2a4b7b94118", "AQAAAAIAAYagAAAAEDesVrh9Yl0zQBJB1xoVJfhItNUwCnl2QJup6cdoj7lJlmxL6jTVWX+n3BZ2FpiIug==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "dd741904-a58c-43a3-8471-61a32b5f619b", "AQAAAAIAAYagAAAAEI6xEWObONrZXBozKqSTyuY0z3/Lp/s5EQPKytgJuLiD/sxjkvrMPKEVeagwQzewIg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3b5bbfbd-249d-49e6-89df-4e73c728a0df", "AQAAAAIAAYagAAAAELK9VKfEU/LuPnhBaPKRDa512FxqI17aCcJcKkhK3dWdLurZeBclAGfI3DYeBtaRMw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c035be8f-5e1c-4fea-b1b3-dec1d0b9ae02", "AQAAAAIAAYagAAAAEIi1qKMROl8bjTt/VRpTWBPM+oq4xLGyRDx12zOo3T+rSXDLCWGiAxRViDCRcKWgPA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5e3718c1-ae81-4c90-b852-7730e71a60c9", "AQAAAAIAAYagAAAAELD4w9XR+z33uVFm5w3v7nZpPQPA392roab2FM7Cbxoqiv7HJq/9o1WWJt3SFtvsYw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "41c23093-0ef9-42e0-b66a-81f635d0c34e", "AQAAAAIAAYagAAAAEOZ91wuAMxn2H3q4Fr0Ip8yjSoD5Os4afpyHw5tT8FtJLlZlKTgpUHMH3jEMt2ouLw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1c6868cd-ae8e-4611-b28e-80bd9eb33d52", "AQAAAAIAAYagAAAAEAwkFT65NaURyEiNbZlZRgweQum3L2TUTc51hyaX+5QSITe4w+bt8sTjdj05NUVODQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b4b07828-8cdd-4c5c-8503-3d00e2257b4d", "AQAAAAIAAYagAAAAEA/OaDTngq0k7X8jBjhVnvNfPtI5VEjqDK0wGW6yCSV2TgKSIORVdE/NXmYf04pWzg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "87c4c261-07e2-4a06-a2b2-79a9e0a31668", "AQAAAAIAAYagAAAAEPbS3KUlCK+edArgTpXD7V7vJZyh+YLYuiPzIuoKPy74z7LPfx5DVS1VKDgNX/DHpg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "79353c4b-3d64-4c01-90db-0d9717fa2be6", "AQAAAAIAAYagAAAAEH6MUcd2QnrqLM+KAr5cON6S8xA/AK6KapJSXBCfi3RHjw8Ay/aSYrfUcj1DbUdlUQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "867a1d41-9d24-48b3-8354-e5723d5c480c", "AQAAAAIAAYagAAAAEOrFxlSYHA7HqfGF1MbXqnBfIQreabosOWKlG1ZptF2lpYiHpSOA2hPsac2aTeYVZg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "774eba3d-3307-4a16-b43c-9bfd2e2d9720", "AQAAAAIAAYagAAAAEMH+QO08Tgq1rML4tKanLYcx8aZY7e7N5LorfMQO0u4syEmNOKhH2cnTPdmJal77Nw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f94a4b0b-36a5-4225-a07e-6dd49f656deb", "AQAAAAIAAYagAAAAEBSZ/lAaK9YUfL6/mRccOBXv/ZYBvwJDZChbWhJ5sfaQUQab94flJkryb6bZAbzkGw==" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2023, 6, 20, 9, 4, 26, 19, DateTimeKind.Local).AddTicks(7907));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartDate",
                value: new DateTime(2023, 6, 20, 9, 4, 26, 19, DateTimeKind.Local).AddTicks(7926));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                column: "StartDate",
                value: new DateTime(2023, 6, 20, 9, 4, 26, 19, DateTimeKind.Local).AddTicks(7930));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartDate",
                value: new DateTime(2023, 6, 20, 9, 4, 26, 19, DateTimeKind.Local).AddTicks(7934));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5,
                column: "StartDate",
                value: new DateTime(2023, 6, 20, 9, 4, 26, 19, DateTimeKind.Local).AddTicks(7938));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartDate",
                value: new DateTime(2023, 6, 20, 9, 4, 26, 19, DateTimeKind.Local).AddTicks(7942));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 7,
                column: "StartDate",
                value: new DateTime(2023, 6, 20, 9, 4, 26, 19, DateTimeKind.Local).AddTicks(7946));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 8,
                column: "StartDate",
                value: new DateTime(2023, 6, 20, 9, 4, 26, 19, DateTimeKind.Local).AddTicks(7950));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 9,
                column: "StartDate",
                value: new DateTime(2023, 6, 20, 9, 4, 26, 19, DateTimeKind.Local).AddTicks(7953));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 10,
                column: "StartDate",
                value: new DateTime(2023, 6, 20, 9, 4, 26, 19, DateTimeKind.Local).AddTicks(7958));

            migrationBuilder.UpdateData(
                table: "YogaClasses",
                keyColumn: "Id",
                keyValue: 1,
                column: "YogaClassStatus",
                value: 2);

            migrationBuilder.UpdateData(
                table: "YogaClasses",
                keyColumn: "Id",
                keyValue: 2,
                column: "YogaClassStatus",
                value: 1);

            migrationBuilder.UpdateData(
                table: "YogaClasses",
                keyColumn: "Id",
                keyValue: 3,
                column: "YogaClassStatus",
                value: 2);

            migrationBuilder.UpdateData(
                table: "YogaClasses",
                keyColumn: "Id",
                keyValue: 4,
                column: "YogaClassStatus",
                value: 1);

            migrationBuilder.UpdateData(
                table: "YogaClasses",
                keyColumn: "Id",
                keyValue: 5,
                column: "YogaClassStatus",
                value: 2);

            migrationBuilder.UpdateData(
                table: "YogaClasses",
                keyColumn: "Id",
                keyValue: 6,
                column: "YogaClassStatus",
                value: 1);

            migrationBuilder.UpdateData(
                table: "YogaClasses",
                keyColumn: "Id",
                keyValue: 7,
                column: "YogaClassStatus",
                value: 2);

            migrationBuilder.UpdateData(
                table: "YogaClasses",
                keyColumn: "Id",
                keyValue: 8,
                column: "YogaClassStatus",
                value: 1);

            migrationBuilder.UpdateData(
                table: "YogaClasses",
                keyColumn: "Id",
                keyValue: 9,
                column: "YogaClassStatus",
                value: 2);

            migrationBuilder.UpdateData(
                table: "YogaClasses",
                keyColumn: "Id",
                keyValue: 10,
                column: "YogaClassStatus",
                value: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YogaClassStatus",
                table: "YogaClasses");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "YogaClasses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9f0fe71e-5761-4b70-850d-a61e479aec1c", "AQAAAAIAAYagAAAAEJ1LT2Kr4SLg2gGdK+2ivIkbZDuWcNxPJCBN1DIXZES76eJm926AuQCTUXz9uJkvTQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ce7052b7-4f5d-4425-af5a-3b96f23f3985", "AQAAAAIAAYagAAAAEI/VuOlG/t+rFhkWD/beOnCZNPSxJ5ZtV4OfBiHhboiKRRdTDZEPC7xmwtYy/EtSXQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f8d6c796-b7b6-4f81-8225-5a42c307d058", "AQAAAAIAAYagAAAAEP/eL/jtWIHPxPApIEz+6yZQQd2HQ0URydl/0msZWX2sBYod1YGyAbgkkaVCX9pR8w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3d25b1a2-9020-468c-bdef-b13d3e137d07", "AQAAAAIAAYagAAAAEFETYcsJsWh6sZBns5elMepgP+mDHgS+97nudoCfcAp4F14UpPmqPAyP/cqcsoDI2g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "437469f3-1e38-40db-90b8-cd37146c2c47", "AQAAAAIAAYagAAAAECdrIz+BRafgshzvkP6iAA3F/cIXoz4m5eNBLbQhI7HAzhMyR8lCRkI1ZBCyMK/LQg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bad45fa4-d2f2-43f2-858a-031f232c32e0", "AQAAAAIAAYagAAAAEKAd5As6cmN0IFlKevUYy/+/Pz7IgEvmcNWO9/CmSdotqO2A95vkbpyaValiPzKj+A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "506d6096-0f4f-48ed-98ef-77e4f0a763e5", "AQAAAAIAAYagAAAAECUS92u/soOvWLUWCCKTynPnANna8gQDvZzFXzXyQdix/YRyztMpXtyhWcvreAh9Dw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "308c733e-71f7-4121-be54-7162dde944ce", "AQAAAAIAAYagAAAAEBWV6aH1boyDfBksO4Io9rurxyv/AFenPVYZplnhtzSACBmkaB+cdM+ZGManQ0gHgg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a40d9551-0d9f-41d4-bfd7-4823bdf4b2f2", "AQAAAAIAAYagAAAAEPbvdI3VABwglNuRiNjNaEbr4PJa188GSTodBUFDCV2tJglMkHO/qoXgsHeqvmhqvw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f191c007-3ab8-4ec5-923f-9bfcf024bf7a", "AQAAAAIAAYagAAAAEDehhXAnuyZlPzgGGkngvafhpdposD4/8qaQgWq8MWLaC8BOiheEaHCLYTYcraDfTg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "003a8cab-955b-437f-9130-3514948009a4", "AQAAAAIAAYagAAAAEHydBbM3Sq2MSNl+N8zOWNwA6/2cuWK7JfRCNLa9h6z3O6veCrhkBf36RybSq2lcjA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "dbfa7490-0e3e-421e-92ea-3dc8ac2cdb22", "AQAAAAIAAYagAAAAEE9v7ZUEAtWfe3ry180ycw3HRPG+n4fyqgzJZ2+QdCib5SE5TsYxdbdLu1XEi5QRrQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f558729f-55ce-4727-8009-a32369e5abb9", "AQAAAAIAAYagAAAAEGqJakOQnNuvvykU4ZYyplqL9NVfce65EteG2GgUMr+2a10Q/Je7FDvQi65b/R2+hw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4db936c3-7bd1-430a-9b6b-4bb69f546de0", "AQAAAAIAAYagAAAAEAN8qLMTw5Bi702TDCRlq9JJIGKaSLEhU9ondGJqvAlTlv85dbtd1t4TLqn9HBDKwA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e8097be9-1abc-4d6a-81c6-f90e4ae59fc9", "AQAAAAIAAYagAAAAEFQI1M0+En1gnJZUD70u/yq+k18UVOk2YnDmGAJ5nALPH0xaLDMECq4wKNvmKtcaJw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "497c684b-06fe-47ab-b295-b2c7e6615be9", "AQAAAAIAAYagAAAAEC+nogR83MMaxN7rTEEwIrV9Oouo1pEFM5Mr3rwgG1N13b9ykxw8HbftrEiiJe5vAg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "045a6dff-3956-4095-a49a-b4397134594a", "AQAAAAIAAYagAAAAEKEeJQCPePSjBdvsMZ5Q8KjTruSET0yVkmF9gg62QjfDNjgsMNvVVsch3+g15MZcEg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2becbae8-e9c8-4d94-990a-09162edd75dc", "AQAAAAIAAYagAAAAEFu3clK/63Nv/0eqL3oajzorXp12vwazE5h3ayhV8Q3W4vlW9R5Gn0aafNX9XGapjw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "46de7948-c360-48cf-a527-b81ebec88fc1", "AQAAAAIAAYagAAAAEJMoXvrGqRs4XqBvS2eeipZXMZdyKUaU4bDWLiuGnsXmCrBFK3wSupOxk8CU9DTtEQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1a3c36c1-683e-464e-bc66-1ecc6dbfb121", "AQAAAAIAAYagAAAAEC5rQYPdmWdXQQZfilRenaPf9O8CcVWXn7ech+4tqB6jmx5atYyUHc6CZo/yktXnnA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3d7195b1-ab41-4f71-9770-3b1ac14a711a", "AQAAAAIAAYagAAAAENMwumiedQelIVHPVO9vpiyU9MaIkqYkqt2DichkwO8ZSaB+x9OLuVzzLjgd2c1RSg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d149b744-0ab2-43d0-944d-57a880b7f8e7", "AQAAAAIAAYagAAAAEBewo6S8TDM13MIBt3pGqSWAZgzYXgwV8gnypB0a0vLCVuHoHCUoObPUMWhOuVZQYw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "20241457-73a2-4af8-ad25-3282f989cbcc", "AQAAAAIAAYagAAAAEE7uzuUkmlTeMTPxw2YB0A38s/ONz3XBWQBLT+gI7SmCm8SOQql1c6gSL5H7Ipw1qQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "51c822af-49f4-40ae-b410-e11e4ecdc353", "AQAAAAIAAYagAAAAEJq9ZuIeCWwz8MTIFE8ib4p3O8TnuY9/RoK7w4PDVxzmCs+V/5w7/d0TpvXO42XIow==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c779d322-5cf8-458c-b973-eeee17497fb0", "AQAAAAIAAYagAAAAENrMA5uwzsOfP/fklYkIBr2b7UV/HtlIWxsTIbqvr/eajQxb1d3tLPhmgZaVLd0Lng==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cc2aeffc-6e70-460c-8393-e7d5506cc302", "AQAAAAIAAYagAAAAEA5+QeBFWUwfE6Y0RksLSccNmtlDLlS8dikHIm3qUU5fb+GA+TRet0w5cEENKtAKEw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "529aaf27-055e-4a1c-a283-0531f5b660bf", "AQAAAAIAAYagAAAAEFsTBF4ED4n8uYjxURjU2M222P/FU7gZf1Xz6TRlfUwAeKBABwYgzkGwbT3OTYeFqQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d8909912-da21-4e22-92e3-da11bcea36d0", "AQAAAAIAAYagAAAAENn5sebM9o+REBsq2+IPDBh1w3F+dFK08IkJUV/midc7XXYLSWd4yybYsA833wRY6w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "dc408893-8411-4be3-87e2-d825facb3114", "AQAAAAIAAYagAAAAEOrSj8PujvY69j8+DQFlUq9BcRNVNwSEPSj+2dF2koeAT6///vtvIg8+GhDFPRiulg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ad4e1f97-54a5-4718-841f-44e4f7ca97f0", "AQAAAAIAAYagAAAAEML8Hqg0ZIlNQhBXWJFJX/wJz25j3jeqb00y9B7EBbewMeKCehVy8HtZ+KRJY6tqZA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cce636ea-7afd-47be-aaf8-0e4d08529233", "AQAAAAIAAYagAAAAECdlRnACeZqOyljK3HyMal7heHgLUz/EV+26Bg6fywAQ5kHkqnLAWN0IzRGvjNIDFg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e0838b53-f8e5-4344-a8a1-dc7f3527e346", "AQAAAAIAAYagAAAAEEMjCOyMaSHGu4ax0V9h5k/yo9k6HGH5EpdqegXHeurCGCXHua5Z2aWtiQr88cCU+g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c3a7e0ec-d4c0-4a05-bd45-2914f762080b", "AQAAAAIAAYagAAAAEHCg2qoPwLR19kRweHFxZY1RC/ClX2TSa8qfnRrPoc/CrFqxd0OGf8dc/8hOf8APMg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3afbafb9-661a-48fb-a2e4-198477097a10", "AQAAAAIAAYagAAAAEEleW/QClfENA9VFwe3vVZWHuEs/U+0QZhufLgbtfu1oNULO25C+OygpUybSx106Fw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "939918db-5771-4910-985c-ae793c682bc5", "AQAAAAIAAYagAAAAEFIuuVxEpdltFcEZuo96BFSdDMbj/R15hC+j5z1TuV6QCjjqBenWNLWXur2ECYjc3Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f4b786c3-bdb4-44b0-bec6-cc573d3bf88d", "AQAAAAIAAYagAAAAEPaJKjoghxxQvHQtKYkGcWc+g3ccpVI0mXoWKAgp32kqcYsoYgzsomusBX83g/etcQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7ddc9bcc-726a-4353-acc1-19f86bb225bb", "AQAAAAIAAYagAAAAEGkpp82gyzo6TXf/fmI8gsbLzgYu4mX/tcEzIeNphyw/mvaao3D+M+a2q+El8DYydw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f29cd98d-fb71-458a-a55f-28e03a686614", "AQAAAAIAAYagAAAAEGguZeNIpg7URJ8G/dPdA2BwiQh9tJjlXRMXcSgskT9FSxmXvMg4CYpdzaU6/nY+Tg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "78abeb40-9f28-4945-921f-dd42fcc8c274", "AQAAAAIAAYagAAAAEFVxnrV36wVzp4KlI29YPbLg1/RtKF6lo+y9owN98og6ibxsEBcXkMlu+zmwtYx/hQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f134cb14-4bc4-4c5c-bd26-e986c6314203", "AQAAAAIAAYagAAAAEMROBfFNL85L/DMV0emo58ybQ/PplVtK2MFxC9JSQ53sFoTBv5yA2GPMKEAhNrCvlg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c753d101-4088-4e03-aa49-26f571060603", "AQAAAAIAAYagAAAAEOXZ0WO0dRqA7GDRPGhSKAr1uJCC0V/V/D6O+foOwq+K+NsUem05keLG+f9LmwWiog==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "23028a95-ecf4-42eb-a1a9-a0bfcc1fe819", "AQAAAAIAAYagAAAAEH5U6ioTdrRc6LniKYGBDazjCjUpK2OIxhq1WhSadjP4Em4GQIWhyDp923EUXyrEIw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "be47ce73-dd7f-467c-89c3-a15e914f1568", "AQAAAAIAAYagAAAAEAQmOv1sBlJ2vwpFWLXq5YrW61PGpXTCeEmO4Z57QQ1DB7ykMy/qvrmbIILgz5RBmg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "070fcc20-8dfd-49c4-85c1-ec1151e766c1", "AQAAAAIAAYagAAAAEI1KIXALJUaYEUY2xv3k6hpInbdK/GV2fpik3+1gIL6nx1AMU2TFKDru9wN8OGoPnA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4b29c1ef-04b9-4c04-9a53-dc3a88dee679", "AQAAAAIAAYagAAAAEHXxZ6qKk+HNheCNHt8VXdpdOI8b/ws8BeEUOTQosHCsSytI4xniS3VtH/wQ1g2wFA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0517a010-e212-4108-a7e0-736af91ad298", "AQAAAAIAAYagAAAAED6ola8OCflqN4SoUaRhgt0nfe9ZDt/0ryeb+4PU8GwmSXTcMhfWva/rjSwFu1krrA==" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2023, 6, 17, 20, 54, 8, 919, DateTimeKind.Local).AddTicks(1750));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartDate",
                value: new DateTime(2023, 6, 17, 20, 54, 8, 919, DateTimeKind.Local).AddTicks(1772));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                column: "StartDate",
                value: new DateTime(2023, 6, 17, 20, 54, 8, 919, DateTimeKind.Local).AddTicks(1775));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartDate",
                value: new DateTime(2023, 6, 17, 20, 54, 8, 919, DateTimeKind.Local).AddTicks(1779));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5,
                column: "StartDate",
                value: new DateTime(2023, 6, 17, 20, 54, 8, 919, DateTimeKind.Local).AddTicks(1782));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartDate",
                value: new DateTime(2023, 6, 17, 20, 54, 8, 919, DateTimeKind.Local).AddTicks(1888));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 7,
                column: "StartDate",
                value: new DateTime(2023, 6, 17, 20, 54, 8, 919, DateTimeKind.Local).AddTicks(1892));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 8,
                column: "StartDate",
                value: new DateTime(2023, 6, 17, 20, 54, 8, 919, DateTimeKind.Local).AddTicks(1895));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 9,
                column: "StartDate",
                value: new DateTime(2023, 6, 17, 20, 54, 8, 919, DateTimeKind.Local).AddTicks(1899));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 10,
                column: "StartDate",
                value: new DateTime(2023, 6, 17, 20, 54, 8, 919, DateTimeKind.Local).AddTicks(1903));

            migrationBuilder.UpdateData(
                table: "YogaClasses",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: true);

            migrationBuilder.UpdateData(
                table: "YogaClasses",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: true);

            migrationBuilder.UpdateData(
                table: "YogaClasses",
                keyColumn: "Id",
                keyValue: 3,
                column: "Status",
                value: true);

            migrationBuilder.UpdateData(
                table: "YogaClasses",
                keyColumn: "Id",
                keyValue: 4,
                column: "Status",
                value: true);

            migrationBuilder.UpdateData(
                table: "YogaClasses",
                keyColumn: "Id",
                keyValue: 5,
                column: "Status",
                value: true);

            migrationBuilder.UpdateData(
                table: "YogaClasses",
                keyColumn: "Id",
                keyValue: 6,
                column: "Status",
                value: true);

            migrationBuilder.UpdateData(
                table: "YogaClasses",
                keyColumn: "Id",
                keyValue: 7,
                column: "Status",
                value: true);

            migrationBuilder.UpdateData(
                table: "YogaClasses",
                keyColumn: "Id",
                keyValue: 8,
                column: "Status",
                value: true);

            migrationBuilder.UpdateData(
                table: "YogaClasses",
                keyColumn: "Id",
                keyValue: 9,
                column: "Status",
                value: true);

            migrationBuilder.UpdateData(
                table: "YogaClasses",
                keyColumn: "Id",
                keyValue: 10,
                column: "Status",
                value: true);
        }
    }
}
