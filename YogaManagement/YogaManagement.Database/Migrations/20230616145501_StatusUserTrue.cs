using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YogaManagement.Database.Migrations
{
    /// <inheritdoc />
    public partial class StatusUserTrue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "63b067fe-5a79-4f33-844f-ac4681d37c13", "AQAAAAIAAYagAAAAEGUI2oKYfoXY1buknYzqPEDWNfdwTioxFswRiMJm5AbEJosQnjUBzxK32jM+AVN2KQ==", true });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "ce80386a-a518-4fdb-ad79-9f88e3fa66dd", "AQAAAAIAAYagAAAAEGHQzsyXtGZy0+6z/6eKdrao2KhE5tr8U3Amy1FllntNRWNek7Qejc54Q5Sjedmifw==", true });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "82dae3d0-0b24-4dd6-b266-82937deea64c", "AQAAAAIAAYagAAAAEEWdexA5ySh8iEbZWJ1+70VpRD03fmtaZTr45XuUx6FS1J8F/KRVomUmfqnRqSNfkg==", true });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "2f116fcf-ba2d-4c6f-8406-4174413b5010", "AQAAAAIAAYagAAAAEGAZhWkYNoqY+ESGntDUn1T62LjbPK/4RsUYX9rL4/H5y29zJFOvvf8shGfC7KPKdQ==", true });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "4b1822c8-c669-40ce-9195-99c6939e444b", "AQAAAAIAAYagAAAAEJOU6CuPcnpMwh8n2sjxiVrFq/Nf30KForlmfKMX70EOyOr7YDRzZ71EAEimzEEjPQ==", true });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "aa2f5da6-eaa0-4727-a2bd-ce8d1cf6b72d", "AQAAAAIAAYagAAAAEE09dOfo+vOkJL5aNReRDrOmKPfvnqOCi5XuNK13U9dx70WGbbn5ieJJGMFGncTQnQ==", true });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "dc4c8cb2-b04c-4019-b368-c6cf506b01b9", "AQAAAAIAAYagAAAAEJ/rpcZYZPEpj6A1Uwa445A8yQBcsobWg+xOYYq9pK5duhpMxW7J0J6WhF4ewWTsaQ==", true });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "94639199-b5b9-4169-9583-87ff6bb87d88", "AQAAAAIAAYagAAAAEJ1Ijvn1L9+rp4eXJCrgbM8nkgRn+kTXVjN1kBqa4dVh1E6w5+a/FrzerAK0OTSKyg==", true });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "f9dde32b-99ee-46ea-b6ee-b3fd7cbf5ae0", "AQAAAAIAAYagAAAAEI1ZDNbLfbNMu8xpbXjRnFN4M45m2xb8AOlrYXKV0iTL0daFRdJkCgARDePvUGcmAg==", true });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "260db6e4-4df1-49d1-bf30-9862bc2c8871", "AQAAAAIAAYagAAAAEFWe/fFfglE46WN3uotSL1Vh+kansGHo+7K29U6s8fN7ElsxGD0TsPVyA9rh3YlXxg==", true });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "dd7b73e2-fd5a-49cf-8958-e2aba49cc2ae", "AQAAAAIAAYagAAAAEEttcwDuvLNV7XZepxjedckLPsSMUadgJghKbOdiiN+VtQc3NWJGk6zP3eebozphwQ==", true });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "6c55e55b-6199-49dd-890c-36f37a3e1406", "AQAAAAIAAYagAAAAELykSS0T/wP57yMpHhkeIMBWVhJt7zngyJqL6Ygt5nN7nOBxGIUxasu7O6swG3g6gw==", true });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "669e2250-d24b-4687-8bda-8ad655917e9e", "AQAAAAIAAYagAAAAEFrnZaiJ5QN4XNrJSYnfNvM32m7JeASvfGBrowd2+s1gL6tA8ehJVMVtGuFYv+ezTg==", true });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "82c749c8-59d6-4026-8f7a-00a4798580dc", "AQAAAAIAAYagAAAAEDyYk6MZYo5cs5Zv8sdH0w/d5gu/8JipswAOl8TrIyF+SnaC6G7tqyonBanUZWCXhw==", true });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "023dae61-9639-426b-955b-266169fffb69", "AQAAAAIAAYagAAAAEH5aDihXgecK+DGMOPCmwRLGmllSE1qkVoO7/96wqGx02bo8o/yJgG5QVRP0xPOW6A==", true });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "4e450da4-c6cd-496f-bc53-365cb8c2597a", "AQAAAAIAAYagAAAAEPv+9ibRLMMMCD4ccj6fst9P6n/UiSfiSALtpQmXgl3AHEBVqpvDvgcPOfxRzXPxPw==", true });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "23e65303-3759-4bfd-b623-de4e7a1366d1", "AQAAAAIAAYagAAAAENynWepouZxP16WYzvhDAUEYARqjDu+pnMH7ONSE/Uq17gvjMxqVC/XA3aCm0n06Vg==", true });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "cc489d77-2ebc-4f1f-b9f0-b327a0e624d3", "AQAAAAIAAYagAAAAEOm16eeHUJEFDclkfFQ8XYI1eDOmlue+Ln1ZH5jGWF1vxK/QH8bjvWpWmoSMBL9Q3w==", true });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "4a1d67d7-c36e-49a6-b02b-b5156a63e7ba", "AQAAAAIAAYagAAAAEN8zukWsMBZWc4txwiRgyGtkjeYM7OS5WT/TVO95X/51ILSZi11ss3mxOgZ/5m04mA==", true });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "f2dd0742-49cf-4090-94c3-7936f81ee52d", "AQAAAAIAAYagAAAAEIPoCJcQ2XYdeBjUIBSmnEMFK7cEbTzjq3OOisrwcu+5QlxysqIWIsFIr4sls9zg/Q==", true });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "130b5dbe-da0e-4784-99e8-f84e70d97013", "AQAAAAIAAYagAAAAEBAZ0ALHJwgt/iwxSL4YdnUO4iVQEmBh/qsGDEShgKcuyI9r/usmEwJ2diqVvdICdA==", true });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "5a863cf2-bd80-4aa0-bde5-063f9d2c3882", "AQAAAAIAAYagAAAAEF16g3uZncVZG2/d0joDYLzfZe+IcHvLGz26W08c/RwwA1u9S/EQQsClTL6ducKtCw==", true });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "958b49cf-2c84-4ad4-9ef0-2945a0493585", "AQAAAAIAAYagAAAAEP39XDKUNlYLxxUHdgbMs91Nh5JAPEP2t+l8XpfO9KY+caJPfWqLS1UPY4pF6k8V7A==", true });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "3f5995f2-695e-4cca-b3ab-31461a28cf2b", "AQAAAAIAAYagAAAAEGjoB4ATzLbi8Timgxot/UIkvwBsXJIYlSN465NjwD7USPDZ6F5oC0GuQgCpzRTI1Q==", true });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "631fb071-2af5-403d-af3b-2df5310ab57b", "AQAAAAIAAYagAAAAEC+MP/xfVTSUFTLdlyRJEtwEJpuamOZn9y2Vf4m8/E7hy5adFAeakK96Iv/jFYJ7BQ==", true });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "d563b773-0ad8-4e77-9830-f0c48d8bd56c", "AQAAAAIAAYagAAAAEN5oFiTfcmDHnjxohCAIH1Ba8/SsAierwzo3rm/0Sk0IikQrZ6vlVP9hpX5bFdZv5w==", true });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "96e8b069-6bea-4eea-a043-8000d0985d11", "AQAAAAIAAYagAAAAEOx2Zk7nDUcBvCJwnnSDiKX4JHfR97jhik1ZeVI9lkT+HVto4qIgN3oDqtlPCTI7dg==", true });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "ec0e00c7-02a6-42e7-afbd-7e5420d04abc", "AQAAAAIAAYagAAAAEIlESKedreO6D6bfTp79LDhoZJYyLF+ji3JK7ARovHkhVL/kR4WWf1J6Hip4INnuRg==", true });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "61598f7a-c6b5-4b8c-a4fa-844036508519", "AQAAAAIAAYagAAAAEFTczUsju/jcSVdbPkcgvchDU6r+M7sxcL0hsdKaVB5PGhS0eTmY2YrOMk3vwusraQ==", true });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "2f2408d6-1792-4081-a623-89dc81ee8ea7", "AQAAAAIAAYagAAAAEDjmbjd/SMwZxa8Mp9hcU5mAFy/pHWg3ZI6qndlCpVWA4CLt6Uvc6tGGp6ibdA+25A==", true });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "03e12be1-7837-40fe-9ba6-4d2f848eb380", "AQAAAAIAAYagAAAAEOp22LKQuvgAOqHJalJGCID9D0e5BmYGa6oBZiQJqDkMxv9mQx8TIw7P7h5oNv0b0g==", true });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "7320a8be-0e3e-4fff-9239-95e273cb7608", "AQAAAAIAAYagAAAAEPjZtuyyHvSXGYIPYs5Lz7Mr3+FSQtG1VGRe6HcTeZuReFucsr173Few5BI5zTPDpA==", true });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "d7146bdf-752b-4b56-8419-3aaad931d156", "AQAAAAIAAYagAAAAEIY0BfEVYfLANVPNhX/kVDrekYSqYbmRps73AlMud5I/3aHlpm4abGigRkRiZE6XKQ==", true });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "d3d252a2-1b1b-4cdc-84d1-ca669c91da98", "AQAAAAIAAYagAAAAEE/5sfZerLuc7jWnJE4RkaAKuHFurU6Hs1g57agGoLnKrXCRRzyC/zC61BtiWBsz8A==", true });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "0e7eeca1-2b17-4057-a5cf-687dcd336093", "AQAAAAIAAYagAAAAEICZqvd0qlDu5qPHDCwQGqxvfFijyriTHpI6MLAPYqGOflKiN1mZJirE8Xd/iqDQjg==", true });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "bed93659-29af-4976-a513-cff94f02bb85", "AQAAAAIAAYagAAAAEAXT6300qUUvRUWrHGbmfx6iaweqjtazEoYJgBcM3IzuX0VQYxOM6fyrNSF7cwFLsg==", true });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "884c64c8-844e-4cdc-b141-d58257ded138", "AQAAAAIAAYagAAAAEDWIFhOrcVmgmKadMeXpYnu2ySB3fzkxo9MuNrPvHBXqX0PbyoKsLF88KBuDQ/Um6g==", true });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "0b39b6bb-1ac9-4f60-9376-fa48b83469a2", "AQAAAAIAAYagAAAAEBfaYhpMhs4Gno9xxMyULSOtHvdG8upxvfxMl33cT2l32D2OfXvH17AuvmisdRHQ/A==", true });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "f4d55b5d-26df-4c53-8e21-3649b2532104", "AQAAAAIAAYagAAAAEHvALaNhbSx4JLyzhQZSf/YjhgZffSUUIIFPSISC7quB9AV5nc8jLtREPYtUqps5OA==", true });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "d65bd14f-33a7-4ae3-8ed1-2a3aea1fb813", "AQAAAAIAAYagAAAAEMn0WEj+AQPjNYXa9FCAoTecvK9g7Uykw194wKBqmBJQUwf+v7QXmr7PHlvclZRt+g==", true });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "ed2ced81-c05a-4b81-9561-f6d4d9c31c68", "AQAAAAIAAYagAAAAEOB8T57vamW2feQV7Ndl/ScTCBqThq45026n2hOHKmRq9QKUGe4LmP1AaVHkkEFduA==", true });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "3e44d4b7-87c4-45a5-88fa-a85eac44f6cd", "AQAAAAIAAYagAAAAEMVaCy03tvJz6C5/maWGuulfydJbNMZnsD3f75T66hIfQSN3/0uNmtuGRVjPlpv+wg==", true });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "ddef52cd-d095-4fb6-b794-cc2c3ee1143b", "AQAAAAIAAYagAAAAECgjx8vyPt1ytdXaeFVH1S/Qlkb9toxH3vQJELuLqI1EkevfUfJoZoVe/mvX4GE1fA==", true });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "a329be4c-9863-495b-8779-37428fbabbf6", "AQAAAAIAAYagAAAAEO//bx3hoWdTZRre2ttf96oO0NVsOTnkeYD42zRGqeaN9rgWPSFTkF/PUnK5zXaIKg==", true });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "d8a9438e-e4b1-4d9c-8685-465016d79362", "AQAAAAIAAYagAAAAEFbPTmovCB6OtfIJXL7wL9UGIQJj9hwfCXB+CiSNbVLRL81CzMzcXH/WTWoJZc/Sgg==", true });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "0763cd95-0f36-41ba-9e54-8676c35339aa", "AQAAAAIAAYagAAAAEISqktXw9sXNSwy89Q61wGOFy7iiqVyHCQUezBZK4KWV2pkqwIgUI9V+uzVa6uvVKg==", true });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2023, 6, 16, 21, 55, 1, 166, DateTimeKind.Local).AddTicks(6804));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartDate",
                value: new DateTime(2023, 6, 16, 21, 55, 1, 166, DateTimeKind.Local).AddTicks(6824));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                column: "StartDate",
                value: new DateTime(2023, 6, 16, 21, 55, 1, 166, DateTimeKind.Local).AddTicks(6828));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartDate",
                value: new DateTime(2023, 6, 16, 21, 55, 1, 166, DateTimeKind.Local).AddTicks(6831));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5,
                column: "StartDate",
                value: new DateTime(2023, 6, 16, 21, 55, 1, 166, DateTimeKind.Local).AddTicks(6834));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartDate",
                value: new DateTime(2023, 6, 16, 21, 55, 1, 166, DateTimeKind.Local).AddTicks(6838));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 7,
                column: "StartDate",
                value: new DateTime(2023, 6, 16, 21, 55, 1, 166, DateTimeKind.Local).AddTicks(6841));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 8,
                column: "StartDate",
                value: new DateTime(2023, 6, 16, 21, 55, 1, 166, DateTimeKind.Local).AddTicks(6844));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 9,
                column: "StartDate",
                value: new DateTime(2023, 6, 16, 21, 55, 1, 166, DateTimeKind.Local).AddTicks(6848));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 10,
                column: "StartDate",
                value: new DateTime(2023, 6, 16, 21, 55, 1, 166, DateTimeKind.Local).AddTicks(6852));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "e3326fbd-bc1b-464c-9969-2f678e9886bf", "AQAAAAIAAYagAAAAEE7fwwmQ4QDAGxp1nTx5hEyfeOT44eux3t5R5m/TGHjXocofxw0eDP6wLhXytiAHNg==", false });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "387aff09-d7cb-4a9d-84c3-e0c45d21f870", "AQAAAAIAAYagAAAAEJnJG+aukmln4P41F8HO7HvO/pYUJw6yw5I3ueDPncR9OdF30+1UB5wr3a6oKnuQ0Q==", false });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "1faad31e-8a6d-48b9-8835-b986b06ac9f0", "AQAAAAIAAYagAAAAEIVe0vVgZ/XorCdOpNM3Z6qBSt+i/TJFZPZ+RppEnW2jN+2JtlOtJrjy+JiMXSpLeg==", false });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "3c4859e2-f1e6-462e-8eaf-77ffc85a81e2", "AQAAAAIAAYagAAAAEB8o9OkluwpaQUaX/mrSnlahJ/e1Pc/mZ8uFeWe7xDdUVb1TIGBSkygyAOyWiQZgXQ==", false });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "f70539a8-a2f4-421e-a270-77248579182b", "AQAAAAIAAYagAAAAEHFjotLHlon1tK0UFhSo2kcayMV1FLAPJ3vsEL7xXyNiDC567fjcG2nnG59m0cu5MQ==", false });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "1d7fe282-da22-472a-83cf-4346256b2edb", "AQAAAAIAAYagAAAAEO7ObrvOWxXCu2EIbcUaR3oYEB2h92HFcv4cHZlkZB8MiRq+aprGilLAblCJmFBZ7A==", false });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "764b24b3-e289-4e41-b796-a24d1ac359ea", "AQAAAAIAAYagAAAAEPTxzG0LGb2F2nQCsFbEdwLeiaDvpwYtTOGTd1mZEW98RJoziLs9mkR96KC3lVrC0w==", false });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "e55d603c-c40b-47e5-a3af-6aa9c4813d17", "AQAAAAIAAYagAAAAEOG734asZ3DHaPVfEZDCLCzRHOKODWpmLLHeUIg04qfC5paTmDVBpccP2PgoNZo6iQ==", false });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "10e3549f-cd8e-4568-8996-b441c40de1e2", "AQAAAAIAAYagAAAAEElEOLZPVa0DhSRQ9b0x547qjcAUApCQJG6bCXLsWV0UBH1TW8zauIU3DOjVZcD4eA==", false });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "66fcb9cd-4b59-4352-92f2-f74a328fdefe", "AQAAAAIAAYagAAAAEOAu6xWNibBchDwHeRPpXOkaUO85VjBl98i1WvLok4BUfZNjODLXyRyOw48OL7mlmQ==", false });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "11606e8b-8085-49e0-a967-4f48aa68d9c1", "AQAAAAIAAYagAAAAEMzuW9QWst81w9TOWpJsVMM+MVAanUgo1aLCYb3jMm4auz4dlt2ZJr4yBl9RPGUQAg==", false });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "cf79daeb-d307-4445-92d7-7da80b170ad9", "AQAAAAIAAYagAAAAEEVX6d22FPLSWZXnLe82hvnQzChmzlWgoJE4rf2oAP3IMK7ie3e1/J1w19Ss5X+lkA==", false });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "8dc2de6c-b084-49ee-95b5-c4669fa1a1fb", "AQAAAAIAAYagAAAAEHco6+D9C+sNJj7C0dQ8Qm4UZSHK1S7MKj/5SPABmCxyodGfZwBbsUCSsnpGBRfv0Q==", false });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "b9f080d7-8ebb-480f-9b77-9b060ff89f88", "AQAAAAIAAYagAAAAEAxj1yoXf5b7lnamEhoeYYUXtyz4BlxxxsFISQ0qmphjsT1BDDEblIYKMIphShKkJw==", false });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "b9ffac78-2717-43fa-bc08-1a8ecf638fe7", "AQAAAAIAAYagAAAAEBymr7t+DAPubT9Fp+SQ2A62AiagsA+wnaDh2IvKCtgPkPOAXu6pR6LvTj27K87IVQ==", false });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "f3fc0515-f56f-401c-8921-0543b4efeaed", "AQAAAAIAAYagAAAAEOcpopOqu2hVr4KsSkMPCHaUa763puUOXjxadsXtWepCYbPf96nKsK518D2kPTTaOg==", false });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "4754db0c-0772-433d-95a6-ccb2de1d0131", "AQAAAAIAAYagAAAAEHAm/L/8DHvfmOBNoyotvt5+ukPGKahuzTi6mhQPLD/92h92bdO0vSdvUo0YfF5qCg==", false });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "7f83bda3-c150-481b-9d99-b0c9e788663f", "AQAAAAIAAYagAAAAEB81rah7ultKKzU+bVd7jDRo71AY7kYsNcVkxF/LCKX2/Ye9XSHwwUcHS0qww+lErA==", false });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "4fdede92-2197-4510-a5e5-d104473c3350", "AQAAAAIAAYagAAAAEBiflrlSH3UX963muRb6EdUy47dRYKo67u2WrDj8Ofuw45lUmGKmtwviyF2GLiFmyQ==", false });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "9d1e51ec-0897-49a8-af86-6769923ac91e", "AQAAAAIAAYagAAAAEMdjcVcFkoJnHbG92CwRWW8gTCG4tdBl8cOGHjeya6AVz2+/kpHI//QEXdcgRlMqog==", false });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "7425d9b6-1272-4571-8543-bdc3078b6a0d", "AQAAAAIAAYagAAAAEMawTRWf9UWeuztnnxdvXvZTh80vgZ0ygOZD9TLNG2cFrh127IsOUmpt0h3uWGoWpA==", false });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "04e5f49b-c7c3-4f0d-bbeb-c03f82e7e6a6", "AQAAAAIAAYagAAAAEOZNG0YoMK6M8/CC4Wc8pIn+QhFcenk4dNesc20Zdz+e0crj0pVrtQP9cMC3f81ZVg==", false });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "50b24b74-420a-4bb2-a47f-d88869f00072", "AQAAAAIAAYagAAAAEF6L22mAMcZgPD2i5uFzR7bf5DoLirMt1pDjgbeCRvvIv7NltSJM5DnNWmDMrtEVXg==", false });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "7d2f30ae-99e2-4ab3-bfb8-f19797c4de85", "AQAAAAIAAYagAAAAELWv3s7w0zfl+shTyYKwV5XKOZE9JRIf/ho+KPC9Imz9j7hR/SNwzKggGVfi9z9ATg==", false });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "b064004d-d366-4d8c-a9b6-9dc2e5b74940", "AQAAAAIAAYagAAAAELzZZ37qVVGzsCsH2pcPjsNezhVu0kRg20WWm4ZUqJQMFWCtNoo5HrLicDMR6p8qEg==", false });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "253b578f-9c6e-4b62-8b7c-27bfdcfe7660", "AQAAAAIAAYagAAAAEKyOfYzfoNdhob6RjByZVK7IhE8PqyyJfJhrDb/UnP9/UZ3l1SUUdYvahNZHoNbfeQ==", false });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "d8150e3f-8b39-4b3f-b865-e87aaf764caa", "AQAAAAIAAYagAAAAENbHkxL3QbiBZ7i9YeqkYOTuPINjeEV9lwt89jXr11WmgrWTqRlwaEJeGl8j9FRonw==", false });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "c623031c-2c1c-4b6b-985d-bce801a25780", "AQAAAAIAAYagAAAAEEPxN3vxHCl0XiMN182hPqly4lwedc1OXQD7sueil2O1QHpSaoXls2dpvqg4XpFfjg==", false });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "77cb1bf5-585a-444d-bd21-419a99208321", "AQAAAAIAAYagAAAAEFYvjbhXDvaUZhCkAU2VHiLKzm96+hvSHVuM/DhpkVPJ1/eoRDkYOu1R6/62lYy0xA==", false });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "8efd5b52-d3d3-49dd-910f-d0d9beba1d39", "AQAAAAIAAYagAAAAEAnF5dHbeninZ2p44OZd27He7Ne+vhgbG5WsZk1UifnGWXWO584az2YL+SXq+45SVw==", false });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "ec4254d2-792a-4f8b-8137-1c3b222c9f8e", "AQAAAAIAAYagAAAAEEpIiAleEAj7iWhmih6ETXUx2JzHfqSHWaX1BtIuEroXY5MFzH9ETiKTy1Tj7d/eGg==", false });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "341d12f8-9917-474c-90fc-759f069861ab", "AQAAAAIAAYagAAAAEHXaNtfEZIDhQ2rH1JiQ5Nkzb2M1CBXOdD0m6I/02B8E340q8YjNbJH6AuHQvi0UAg==", false });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "e5b5e7b3-b65c-4a5e-a565-bda6e706be23", "AQAAAAIAAYagAAAAEOnHRKHD4L+eOoYHk0KlvpvMcQw30y6uMhBEojTopXzyJ/+znX35H+Pf0IbM8mTxKg==", false });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "24fc858c-4c26-49ef-9bdc-d0343697efc8", "AQAAAAIAAYagAAAAEG6euWIO5q5jutHXBg5dq+0BLBbhmyWcNBisePOjRZt8QggacutoeFefgb6ARu1A2g==", false });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "9fe5e2a4-82e5-4a5b-ba66-3450597f377a", "AQAAAAIAAYagAAAAEM4NLugbKY5ciCi0/w7m9qPcch2GyCvdBCjzCtknlwK3qr0tkao+is/HP7VCgIOtoA==", false });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "80b90325-d48f-474a-8909-72603150dced", "AQAAAAIAAYagAAAAEL0Ganh4xVVPug1wGTvBQF7zLBG+AgZm381bDzfj+NuZrSF7ODJQbhGGtQZAqoOYYQ==", false });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "d73efe0e-1d8c-48c3-a281-16412a796062", "AQAAAAIAAYagAAAAECuHRMDzjvltmEIHtyZx4IiZIIEXgpJ9tBBTMxqHSeA0Wi2CYmxN+gNHi4wq0BMI1Q==", false });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "d4be2121-9c0e-40bc-92e5-3227398da332", "AQAAAAIAAYagAAAAEI16NMvFKPG4IXI99fHG5U89Y+g5RUal8ILqT7y60UAYAsEmkdbtPBrPWVMIy06KNg==", false });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "4f2dcb70-4051-4caa-b9bb-7fe12928c3ee", "AQAAAAIAAYagAAAAENl9PJJWr0i8cdt6uUfuqz+7h3nSj+qu9ExYkWd8ywFrhEw4on+REg7CFlcYm1vZuA==", false });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "0b009e44-01e2-45e5-ac6f-d89539c5a3eb", "AQAAAAIAAYagAAAAEChVaXWfzbRLQrqTCHYbsGmVBimGXZFaupVK4NWwvqA3EqnybnxE3FgUwDAODV4sGA==", false });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "479dafaf-9dbb-4614-b5c8-aca8d1efacc8", "AQAAAAIAAYagAAAAEGp2RvaHwF0ks5QOoWz3NcnrFw2oZ5xnHV4IVo63P2W57gA1i857q9lWfr7Q60DaXw==", false });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "eff0a403-6718-4a21-88cf-10a33c8c8116", "AQAAAAIAAYagAAAAEFvCYa1P6N6c2y9tNl8Lpxc5vw7QFqB84nwwc0L9b5ibC2vXEF4GH3YFua2yFbcJDQ==", false });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "c8c7b032-5eb7-4208-964b-78a3032a4ba2", "AQAAAAIAAYagAAAAEJaFMrQyglqRO/U79zFcAG3tzQAT/Z/F9j1DXf03EBl5jxsPpU5qFvxlF5mpNdL3YA==", false });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "db57ae90-c9e5-44fc-94eb-41542d6e79fe", "AQAAAAIAAYagAAAAENIgQiK6kta+npln7qr3xS6yUPk6hRmm8/Q+e4BcNxhB9qSFp1jl4jedEX/ImCROWA==", false });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "65350705-87ff-4e4e-afeb-a88e2088009f", "AQAAAAIAAYagAAAAEKg8BQrkesnm74Hbn+fuEmw8mpvfXgpqZvV1i1qDz9XmEmtq62ejI+aL9HSe+V//2A==", false });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "3075136b-6e22-47b2-9fb2-27ce31806319", "AQAAAAIAAYagAAAAEFSxWMos4C5NcnjRSzAkysajrzu4+fjersR83T7/KnRVFXK106/Qbvmw3v5Wz8LK9g==", false });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2023, 6, 9, 13, 23, 26, 832, DateTimeKind.Local).AddTicks(5773));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartDate",
                value: new DateTime(2023, 6, 9, 13, 23, 26, 832, DateTimeKind.Local).AddTicks(5807));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                column: "StartDate",
                value: new DateTime(2023, 6, 9, 13, 23, 26, 832, DateTimeKind.Local).AddTicks(5814));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartDate",
                value: new DateTime(2023, 6, 9, 13, 23, 26, 832, DateTimeKind.Local).AddTicks(5820));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5,
                column: "StartDate",
                value: new DateTime(2023, 6, 9, 13, 23, 26, 832, DateTimeKind.Local).AddTicks(5827));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartDate",
                value: new DateTime(2023, 6, 9, 13, 23, 26, 832, DateTimeKind.Local).AddTicks(5835));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 7,
                column: "StartDate",
                value: new DateTime(2023, 6, 9, 13, 23, 26, 832, DateTimeKind.Local).AddTicks(5841));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 8,
                column: "StartDate",
                value: new DateTime(2023, 6, 9, 13, 23, 26, 832, DateTimeKind.Local).AddTicks(5848));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 9,
                column: "StartDate",
                value: new DateTime(2023, 6, 9, 13, 23, 26, 832, DateTimeKind.Local).AddTicks(5854));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 10,
                column: "StartDate",
                value: new DateTime(2023, 6, 9, 13, 23, 26, 832, DateTimeKind.Local).AddTicks(5862));
        }
    }
}
