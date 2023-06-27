using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YogaManagement.Database.Migrations
{
    /// <inheritdoc />
    public partial class RemoveRoom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Room",
                table: "TimeSlots");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "30f1ecae-1f19-41f7-98e5-d33d66f7e9a5", "AQAAAAIAAYagAAAAEJr2GXH6pCmLeIGSiWWfLJGJ9koinIuxwL0Zf+V22M/xiW/grb5tQdUQdOiVVDHXqg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b316b056-549d-48e6-9b68-179bd57dda87", "AQAAAAIAAYagAAAAEFF4q2S3vmdf7BWqDnCmFzWjSSgp8rrNojEVtr1WfMxlZBY2jdH1j88pHENAmpEuvQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c85fea7e-e721-4f2d-bf08-9f6315fd2e36", "AQAAAAIAAYagAAAAENOTLo3Npo6pkSqeeDf38rzpNOxUtFy+r5Fmx2MSiUPKD3snOxNH348QkBmmx8ysYw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "10e23886-fac6-43de-a29b-9d3f670290f5", "AQAAAAIAAYagAAAAEJ+72S9VNSVAGK5Z87ZQoMuo4rIbR30n69oH1XXGAm/3ELPPD6ZGtmHyhA6ywvPRCg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fa6e69db-0f33-4a0b-8d3e-ae32bbc0034c", "AQAAAAIAAYagAAAAEEkh2ezz50G2sFJLw+nfIffJcvgbbI6GYBrR7WidreFrhB0IGfR3JhkLhlJsKQuAXQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9030217d-d8e3-48fe-943f-d1cb362b962c", "AQAAAAIAAYagAAAAEA3Pe5J1bKAB9HgRNgHE1IWDqb+My+hdsqM91WNjCw6fzg8K8e8NTn8krzvX82kaCQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5e016784-9801-42a8-96e9-bf6a4607a6e1", "AQAAAAIAAYagAAAAEKKUhMRBklW2Vwx1G2i+fH9DOD/hyZC0gcGY3kF934AkNMMUFX5/NDKfFpytf18ZVg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d9427ec6-8dc3-4512-b9c9-787aae11488f", "AQAAAAIAAYagAAAAECCeaEmJKX2QSqa3X3kDn9WjgjDfiii3pwX/3q78+hhit/d12/p6lrR2brzTaQ6OCg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d850f763-c00f-4c62-956f-58a66e8be818", "AQAAAAIAAYagAAAAECixnGPd+MBQi89tX5IwUhXUzofOw8xix3xoPi3Fjt0n930mmQptSJIECPAamzpqDg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e80553c1-1ef1-42e9-acb9-184707b39ad1", "AQAAAAIAAYagAAAAEKB32OZdevlbfgwsQswnVI9H5zlJTHDwiCIoH8dsOysPWG514qGd/JKz+bMOhZisbA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5e1ce877-3aed-4db8-b4df-5b33aad4e2a3", "AQAAAAIAAYagAAAAEPRoPbVTjlj75ZA+q39XM/OLtJJgzuh4WyJsm+eSt57lEypC2wTKO6uVlZUxYC52QA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e99116e1-a17f-4acd-a23b-06999c3cae9b", "AQAAAAIAAYagAAAAEOsVE+BQmJONYmkYfDqkERbwYM2bIAvERsUIWZHXOpSGxKxR+NDrCjHiOOYFOmEYSw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f11c4b9d-48d3-474a-b3f2-1e85c5e3f656", "AQAAAAIAAYagAAAAEBbRlynx9yCYv01n3c5nUMVc7m1+Abwbc8fnYnZqDT5itE8IAiX3jy9BexsIXZTCjQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f83e981b-6340-45e3-9660-bb844c64f712", "AQAAAAIAAYagAAAAEKln5+Gpb4A6lzK9x6tIlxK+ufmStCjqr2KPcq4CfnpJZ6KOUTieeZKLz8fddnCP/w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ca0ec4da-ad9d-448c-9e0d-60fe90d273c0", "AQAAAAIAAYagAAAAENfODYr+tu3OreC7lTqUvZCDvG29k9Asg3W3AjQXE54Wm9G0MjyKSBYN84nnbxfitQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f0eaf560-ccea-4f3d-8c92-fb1c81b7e16e", "AQAAAAIAAYagAAAAEKOY9ugmOSgqjNe3ROd4ShlJOdhk9xDjgCYdOWCs1sztnNhAiDauNH+ihlt51UFE+A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "56e9de8f-3dfc-4680-8621-e44508bd0774", "AQAAAAIAAYagAAAAENheyl/NaPhSlUwqrmYTe01jxReQLLaGMQaCLZVSnghrt63lJOLnZ3Ncu+qvoz9m5w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a18ef5eb-1413-460f-9edf-9c4ca06c0a8e", "AQAAAAIAAYagAAAAEFpW4c0zDRaduT7EvkOcbSovP9yAVyT4BxYUm2pByLvS8IktcLeku/4ArKodi0fwYA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8c7eb55e-e8ae-48b3-acf2-48c09ac14e54", "AQAAAAIAAYagAAAAEOIUpW7GAF6Yt4LiuGIoRge15jMUCfjh46iBofaPTYXsHrDucJOn2+u9zIDSMnBIYw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "377d285d-382f-46c4-addd-85d217e2e657", "AQAAAAIAAYagAAAAEMnu2ijsXcUsc/i1h9qu31LCPa8mHaba9S6MTetm1nXK9MnnHPxIsUxYH0TWw6ukIg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a0dc41da-1c1c-4d27-bb08-74b3a4e2a6ca", "AQAAAAIAAYagAAAAEAaTP2TH15vrOr22ghD8m1w7Pe/orlo++oi838hEd/QxCeGAp+gnbcM8M05fEVYmPA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b10cdf6b-b346-4c0c-a3b7-9f23a0030fff", "AQAAAAIAAYagAAAAEPnXz+6Sb8U9Zlmy1tVq9YG3cOBZsQsFp+0KznKnKvVrWOzbYQkLfzJFjIVBpxq64w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "dd02f695-1c80-4ea4-a1c0-4c33c9b3106f", "AQAAAAIAAYagAAAAED6Cqw7+VRsec143nVa51fBTdYMFI3VnarcBayc50i+zutLpFV0O0Eo6LL037t0Cyg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c8e4a597-bc99-4f98-a245-dcaa517b5d10", "AQAAAAIAAYagAAAAEAAQJQrj3QFlvjV37z5Nk8wMHTQAwu3RdtMQsy+C9FKNeseKdedS8Rtd2V+pDC2NOQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c7425da7-de4b-499e-ac49-d28ed3cc8816", "AQAAAAIAAYagAAAAEHzTeG7/LMmlbFNHlXopv0gamLMcpGAtHFnfP1sQfSsA0JjdqFxNpEQ0miHR3ut+Cg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ee1305c1-c3a0-412f-b308-f8f0e74dc9a7", "AQAAAAIAAYagAAAAEGXGzH2EKUe92Janhbbw+CXyhlm8jHzZHMZmiTJSRJYGsOggH/X0LohDHbSZPvrZkQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2fa63521-89ba-4c43-ab12-5308df96cf87", "AQAAAAIAAYagAAAAEIF1P3n7lBmCTWtFY+BA9/C9NF9u2Fplu3w/Tcm9+MC9baHwAPdFRaWfPNI/5rzM4g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e37cb80e-ec85-4d80-a6e4-b1c15e3adeb8", "AQAAAAIAAYagAAAAEOQ0G2N05/o5yLo2K0ST/gLClGp0zC7WexWtECsESeLnhLlHAKZdzvFuHwD6zaRXUQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9409c9af-0137-40ea-91f0-7aa3b1ac94b9", "AQAAAAIAAYagAAAAEARVHevhYPKnA+ESj57xGdY9XlGG+VdxXVVj8TOVCz1W8Ogq8tscSs3mLc3qXRerWg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "319401ed-a0dc-42eb-a53d-2a9d5547f48f", "AQAAAAIAAYagAAAAEMLvLqjE6pdofBpY8EnCL/CHypMZ5Qn9Dog3J9pK1HOhAbr87MjERezE/IGawRDbaA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b386da29-3be8-44d2-b4fa-e51f81277dd8", "AQAAAAIAAYagAAAAEKg5V+l53cU8xtqYEcARXwYUqu+9p8eoodmmeYymM4NPn69D3tqvMT8BWxJp+Pwjfg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e2a2c4a3-70e9-44f5-b7f8-31a6bb086e77", "AQAAAAIAAYagAAAAEMBZqJ606EAXnKMI29VjO+wvOf75rwnNmsPmKaZqrp5kg6snG3lKcPqkROCYU8T3yw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "85aec94a-8d1e-41dc-8eb7-481e749bed7c", "AQAAAAIAAYagAAAAENvAul2kIbXmZW7gOfNu6gWciAK/8Hqm++PhULMj9R5OS/GqmBKOWMgbX/ykTANWtg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "eb00d3ec-d2fd-47ef-bd01-390e1f55afeb", "AQAAAAIAAYagAAAAEJyCzLOFcIGwTtPooPJF+YlfBFQJ4tiNLn9px67ozJmVXNPJl3ziHSsd46rgEroAEA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8fd6cbdf-2f16-4e0c-adb3-43c86f38ff4f", "AQAAAAIAAYagAAAAEMx2NY68qI5VjAhWl0j469VwNI9GJ19PpGu487LPFYgrvRzFASLgEc65rEJZ2fhEag==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a52076dd-594b-45cf-b96a-a08f520c8737", "AQAAAAIAAYagAAAAEBjgzQQyfXYK+8b8pHLJW5/6pj1y6rq1JlqIyBSnc7dBoiDe95wPEpi810F0WekVVw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1b0820ce-a64a-4b0e-ba32-76750c8391cb", "AQAAAAIAAYagAAAAEBp+Vc8br43z9bQUVVHwOnaxMcyz3gr5woMb15D2g/NZRryljwLqP1QLnJwKLN2szw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8c46e0d5-8a8a-437c-8a8e-9267654b45bc", "AQAAAAIAAYagAAAAELNGNvTFc6XRkt5cm+1YtJdhe3mmrA81/FuvszZ9mc7/KiVEZcFl6evz17ukjzdSEw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "06df0d54-46fe-47ef-a546-d2e4824b0461", "AQAAAAIAAYagAAAAEFqGiNMWk+z14rUUXD21ySLlMBWtrMY4Vbs8iT9+7i9FzcQoPycvMQ7dSPcmP3tbdw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b5f5e841-c00a-4849-b066-74a3e1bd0c9b", "AQAAAAIAAYagAAAAEEl+6//l8tmJfRLt5jTStWiobBKqChn4nys3F8SwIlu37Pc2oQkOvXxFlliZbCOlHA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7d89ffda-e053-4b9e-b205-ee7de29e13fa", "AQAAAAIAAYagAAAAEExbc0j5clY6wcRyt4lo6P/L3sidOE74z4p4SK9RHKV/LjL2fjm6gxun5RYqSaACxA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7fb78a05-641d-47f1-b9eb-9ded3a3a7d50", "AQAAAAIAAYagAAAAEGzpkINzVicqdbQh1xzeETBMSemQWspWBFf1BwKgbPxUoCSdAf6jt95DQyThueqhoA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "220f0250-5260-499e-965b-78876ae0557f", "AQAAAAIAAYagAAAAEOw1tYcsl892FYe55LzbfUfTU7r8L7II4jqsRykrVeDmY3gG3KXZpYfKctHJvWx50Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c68be88f-b3bc-451f-95ac-1634079093e0", "AQAAAAIAAYagAAAAED6MczD8vAvU/WpefjGuf+gt48cJMDlpWUFwACLfcAmN+kfDOHmFH1x0k7VdurrYnQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4e82fb6b-582b-4cd4-ad2b-26eac4e58ebb", "AQAAAAIAAYagAAAAEPMJSJqnpValBmASUJxlB98my9hzxtzelFf4KmMEGP1SNiirQIIrof5LwG1nZQPPQQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d0f25c87-365c-4a8f-bc00-4b49fcad5f58", "AQAAAAIAAYagAAAAEJIfkrnn+NkhvOvyn1k4O4B8hLiCKVZz1vk0hYrtye5/aR9htnfDIrsAQozENr4r8w==" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2023, 6, 27, 16, 35, 56, 48, DateTimeKind.Local).AddTicks(8189));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartDate",
                value: new DateTime(2023, 6, 27, 16, 35, 56, 48, DateTimeKind.Local).AddTicks(8216));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                column: "StartDate",
                value: new DateTime(2023, 6, 27, 16, 35, 56, 48, DateTimeKind.Local).AddTicks(8220));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartDate",
                value: new DateTime(2023, 6, 27, 16, 35, 56, 48, DateTimeKind.Local).AddTicks(8223));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5,
                column: "StartDate",
                value: new DateTime(2023, 6, 27, 16, 35, 56, 48, DateTimeKind.Local).AddTicks(8226));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartDate",
                value: new DateTime(2023, 6, 27, 16, 35, 56, 48, DateTimeKind.Local).AddTicks(8230));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 7,
                column: "StartDate",
                value: new DateTime(2023, 6, 27, 16, 35, 56, 48, DateTimeKind.Local).AddTicks(8233));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 8,
                column: "StartDate",
                value: new DateTime(2023, 6, 27, 16, 35, 56, 48, DateTimeKind.Local).AddTicks(8236));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 9,
                column: "StartDate",
                value: new DateTime(2023, 6, 27, 16, 35, 56, 48, DateTimeKind.Local).AddTicks(8240));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 10,
                column: "StartDate",
                value: new DateTime(2023, 6, 27, 16, 35, 56, 48, DateTimeKind.Local).AddTicks(8278));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Room",
                table: "TimeSlots",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "88794026-afac-41de-90fd-4e2b18a540e5", "AQAAAAIAAYagAAAAEDrXUzS2ZS7G/+wZXK4o2cSFyaOUjdrADbXRyHnXhXYIy2opMCpqbY0p7Gq1CO6ViQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a8964c5c-4898-4045-8545-bfaf18aaf4c9", "AQAAAAIAAYagAAAAEBTMZ+DOv2Snkq/M45xqOu+s7BRDEY7hak2sBcD1RIpEV4M7NuIFnRGKjr7ZOasDdA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e407acd9-a93e-4bd5-aaa0-6edb93928bdf", "AQAAAAIAAYagAAAAELLX1C8fVrAQbol6x7uBF2FD/NOmCHass43r/+tYO2pere4nDtLBiQMFQV1pQBFs5Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "14ebc341-f695-4223-b14e-4ea84705bf63", "AQAAAAIAAYagAAAAEEdQPCiRV216q4eoDu4GcL1nZs/cReyRCOHbWZUpRFo6OLq7L06BWc65/x1AyVy6Fw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "86fa5527-82b4-4fc3-b9d5-205f469b36c2", "AQAAAAIAAYagAAAAEDu2Ot0qPvDna/RGGWaFudwMklYEZ/NqSAs6JmYlDwCipAOZQhTZu7VzUjBj7bznJw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0f6e4419-edaf-4aa8-a3b2-b715bb7adbd1", "AQAAAAIAAYagAAAAELSWWwaycrVBCJxnXMLmiTY7Pui4Mor8PHf+BNEtyAHZIE09+9kiedJS9BtFv/vozQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "507f3b73-97b4-46ed-af84-dc51e110a45a", "AQAAAAIAAYagAAAAEPlPhHp5PVSKN0cei5Nq4N50R1htULHfALvYjaid0YMgCgHqd8JW6TnXbWLTQGpTpw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d377c20a-7fde-4b4b-bc4c-ef38721c1e1b", "AQAAAAIAAYagAAAAEA3Zuh2d+9B22fcSYdWkdzO0ljCkRa24odEUqmXF0kXrIRH5rV+oL2vz1VaSt0bqcw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "935a738f-4e06-4707-919f-56869871a429", "AQAAAAIAAYagAAAAEMssRqDENBxv2+PKzkxNXxezvASQky6NFxZ2nW5FL5M1734Jl1JD4P73Ks2pPErIMw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "694d8fe3-c2bb-480f-a203-5bb5a3508624", "AQAAAAIAAYagAAAAEBaHVLDdOaGVjM9hyyoXrZtPmvv23sZYfxYyZFCITa7u8xcRsZt7z+KT6nVLJaCoMQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4e6bd894-7577-48cc-82ce-b0f5a140f6e5", "AQAAAAIAAYagAAAAEMyIWQBkjtuieDTPqfWab00pJJWODe0+n6p0XJhrLk5BJ61LRxsJqyR+DSRTINVN3g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "82a35be5-0e34-474d-baec-6cbf4725f08e", "AQAAAAIAAYagAAAAEDAXARGcO8/IPLMtlmABQn/JyPCBmXhCHYI2NZ/vGQ6BSIfA8jht0ZWVPEyda0mx7g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bab4b0fb-4e75-42d5-9c68-db1b0d32f78a", "AQAAAAIAAYagAAAAEERXT+V/aTr4slEmsxAL4S6IVRksMUb1jLarb/UTNZvb/+geIAEPrpuSczTSGTarTw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "241d3659-e5a1-451b-8e1d-9f1f91787c01", "AQAAAAIAAYagAAAAEGL6LA+ZI2UWO97WTMAeOHfVVPST5pZCWpbEI0A1BD2isBaPyfTy4b4uhJcaVIVSkg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "36be0f4e-7467-467c-a30f-53e750ec6862", "AQAAAAIAAYagAAAAEJvxiDm397shBqnn6m+/A6GYqm/epIiQpVStGOLbYKnvZYRhAxzUiF+kNyQb0do2xA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c463c75f-cbd8-4651-89c9-ff6582801280", "AQAAAAIAAYagAAAAEC4RgEFqZLEAJv274Bc73Su2dbzcn6jzFpHC8ABOENxgKEceaNplI/It1cy4TaOU0Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "27d1168b-3eb1-4a4e-bb25-1655cf944b0c", "AQAAAAIAAYagAAAAEHknNOSqF3OpZM639IRdXlaAMT0jfOG2druLVvxWP55r91kOZ6z56ZNmzszBxftTTw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8d69007d-afe0-4d83-8411-502ec52a4f6f", "AQAAAAIAAYagAAAAEPWLAB9cq+ZduL9oIu1C7mACl0L/04qbt2xt/9zoxTtQAbbAge3dyzmClPEuB4XFpg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1281066c-82dd-4cf3-9b8f-0d28a8ff935a", "AQAAAAIAAYagAAAAEHZf/ux4BFGpnawSfTofmOb9Fkm2rYRsbXoYCkWjajO4QORm8Tegaq3q0qw5YhoKcQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9d55b2d5-c4ca-4eda-8b6f-c55ea9ced939", "AQAAAAIAAYagAAAAEFM4If5vxhIB/HECTWxwHAaIDdfFcJLc9DgGtIO9JV/uzr3CXY8wxf6Ot0XNQPmlZA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f60c84f3-7b3c-43c1-9be0-a4a4ad387370", "AQAAAAIAAYagAAAAEAcnEhQB/kRhZKbSnRVpwqOlrVhLvvNNKZf95V4qSs7D4cSWJCaRRiyuXdDa/ORAuA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "479b8fef-41af-44d7-8d52-659be02b3228", "AQAAAAIAAYagAAAAELBkUxzlsV1Mn96JFsoortt7/Tgq1xtqgP1IsANOqbhaHCZHjJPA9Gnzde3jz2x2UA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c82e8068-cb38-4d6e-a1f9-c8de8114d99c", "AQAAAAIAAYagAAAAENzwIlm3L/wnzApmi04TS5/vC7f01VitF6FxIhg9LZARDBJUp2hGZIVslwndJgsQEQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "dc71dd8c-e71c-468c-a602-c0dd9312af4d", "AQAAAAIAAYagAAAAEM1lCTwlzrP0huCo43vKY0Ip0iLxpk6qJLyghjXWabeBDgfIIp03vzViBj4nWDHEqw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b61d0dff-78c9-4ac7-a0e6-599ba17123f4", "AQAAAAIAAYagAAAAELUj73LtEplSkoUXoGXn/YJJlDzLVFdYPt2oFpn6UXu3kTh8/0FF5bRl0fekwDgJAQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6d464f1a-b06b-4155-947e-a0ee4e57f8fa", "AQAAAAIAAYagAAAAEJIEwvuhTESaAr4Bvc+NuxRsu1gZeVLeXcSmHHkdYEoWZoyU3k4KhcsczUxZiZbNeA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ac90ba31-aba2-4784-be11-fc00a5e22248", "AQAAAAIAAYagAAAAEN9S8GgVo0ALcPLGD8wXnF/0CY2o5YAqD0S0PSdCtkXgLVgX5XokoNSHBDdp+6lZCQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6196af0d-22be-4e1b-a456-0d433760746b", "AQAAAAIAAYagAAAAEPMeSL3t9bfw/AvjgWKB9ygdLoy0gG4vEsEw85yDBVVzzc3vccddDlpt6F0sutSoqA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6c18f0ad-3db9-46f6-bbec-843a3ca54bc5", "AQAAAAIAAYagAAAAEKRp6bd7RBswxfLmdYx3EUj2tqPJCVbdEQbeblwgqiZpRiooAnmNCLZnbXn7Yv9Fng==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "84e1b928-2f60-4767-8da6-d6d6112ab044", "AQAAAAIAAYagAAAAEO7EAaUV2P06XhKaH2A+zWLXnyMUU5/2Z60/QMm6V7kjmNs8svYQbTjTLYhR3Qg9Lg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8d0db305-3e04-475e-b002-8077d30f8039", "AQAAAAIAAYagAAAAEDvJocu/g3B+Polch19WYVbAJehF9TczMDnOeixr2IewIqZ8VsqwvwwiJpmV7j5lnw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6c5466c4-1ff8-426c-851c-14719fe819a9", "AQAAAAIAAYagAAAAEM6KuurkNzBw7iakSD30uI8yNlnfz449kkGD45xArpdfUBK96ZccjivuG8XAsiSyaQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "86704686-202b-4470-9917-d72a08657ea1", "AQAAAAIAAYagAAAAEJCuvF6FS0o0C25y5ctdc3Qvyvn1EDs8Gcdo0g8lDWpglBPZl0WgqAi7O7eeuoUWFA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "da4f8ae3-5a48-4a64-9521-4d4b68863d65", "AQAAAAIAAYagAAAAEESyzYal4SvkffQMbuKDQOoGCExKAJ0n4i3cQk+P/4jhtfH5VoYL2QfY8ADBex+6MQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "063ffee8-2097-4e3b-a3e0-ee67fe2599ff", "AQAAAAIAAYagAAAAEGbqIpDy/YgQfE8XPrdeaPCBrdll5Zy6p9583VlLNil70lYMDEQYx8HDvaMIp9WC4Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b79024c9-0312-4e51-8b63-94e558c7aae7", "AQAAAAIAAYagAAAAEPQhfum9PkZ4m0ocSWV2e6oVEDzKGi0nQ9BB++sJmwS0mYbkeI/T2yMopzcirZbTMA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "de9266f1-d904-438e-9efd-29ce1bc87930", "AQAAAAIAAYagAAAAEMO9rsSANnS0n3MwGevKtzsnLFb8wLQC40HPVbmrbj2o2/zYLe8tyHEpIRvz+8jn1g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4963e7e1-af33-4ce8-8bc9-c3160835ea5c", "AQAAAAIAAYagAAAAEObwLM0oVPB0u8yteJib83WIE4NVJ0i+iq9xVMzEPsB2C6cgblHfTSJxaGYC3HQabQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f33469aa-ada8-4068-ba7e-963bf9629547", "AQAAAAIAAYagAAAAEFNHtWzWpek/g/Kzk99PEKfQxp0XUA4MsMKE5lAswCg1bNVVvlAodk9nhWIbkaAfPQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5087ca15-03ce-4805-9e9d-26ad2e148e9a", "AQAAAAIAAYagAAAAEM+qfb8VUmpHlj5Li/PtVD6xm4QMgW9RI0Pnq+xX7UQC24J6178cS8tHLrCApD4i7g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a0b00c41-4028-487c-a52d-7529b4e29b17", "AQAAAAIAAYagAAAAEMbvqd0+II62fvTohnTHuppHUnPNLlYEiaOhMpvGTmOpCX+gisqfJ/bGwxcNUI4YvA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a367f39f-5986-4796-9bca-f41f40881520", "AQAAAAIAAYagAAAAEBC6YDdKCmN7QzQ5v5ajEHQWlfhqv3A8Tw38qfOFuV6V2+FL0X/rDJkYgN9TFaUJPA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ae5b3de8-bb2b-4d9c-a5dd-6bbe9707ada7", "AQAAAAIAAYagAAAAEJsxHuGJ4Wt5/AjhoMl7GmvY/YJnPPEgTnocgYzeNvA+AwQugNirK9O5zVld2noM2w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "666ac693-6c35-4896-83af-aaf11a79cff7", "AQAAAAIAAYagAAAAEDR36/62h3Gx3YZ0zLxKM/4TXZQ7pfXnhW5tCX18HLpeE/8fvHptjzApjxOSf+wxaw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "703275a4-000f-4005-ab3d-52df2a866e36", "AQAAAAIAAYagAAAAEF5C/s/A035EavcYZt8b5c7El03CMPkR1zFTcZ2fhRVM0qKia+L37Al7/a/i3GPRiQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "54764013-50f6-4359-b3c0-ee53278dbfab", "AQAAAAIAAYagAAAAEF2bkMghfCEHtyIacOLy9d3GqXxvbOOabng8D/rNvf6eZ2ZXOdWTXpnLZeHcm7vXwA==" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2023, 6, 26, 23, 1, 1, 47, DateTimeKind.Local).AddTicks(4191));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartDate",
                value: new DateTime(2023, 6, 26, 23, 1, 1, 47, DateTimeKind.Local).AddTicks(4212));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                column: "StartDate",
                value: new DateTime(2023, 6, 26, 23, 1, 1, 47, DateTimeKind.Local).AddTicks(4215));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4,
                column: "StartDate",
                value: new DateTime(2023, 6, 26, 23, 1, 1, 47, DateTimeKind.Local).AddTicks(4219));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5,
                column: "StartDate",
                value: new DateTime(2023, 6, 26, 23, 1, 1, 47, DateTimeKind.Local).AddTicks(4223));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartDate",
                value: new DateTime(2023, 6, 26, 23, 1, 1, 47, DateTimeKind.Local).AddTicks(4227));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 7,
                column: "StartDate",
                value: new DateTime(2023, 6, 26, 23, 1, 1, 47, DateTimeKind.Local).AddTicks(4388));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 8,
                column: "StartDate",
                value: new DateTime(2023, 6, 26, 23, 1, 1, 47, DateTimeKind.Local).AddTicks(4393));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 9,
                column: "StartDate",
                value: new DateTime(2023, 6, 26, 23, 1, 1, 47, DateTimeKind.Local).AddTicks(4396));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 10,
                column: "StartDate",
                value: new DateTime(2023, 6, 26, 23, 1, 1, 47, DateTimeKind.Local).AddTicks(4400));

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 11,
                column: "Room",
                value: 101);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 12,
                column: "Room",
                value: 101);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 13,
                column: "Room",
                value: 101);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 14,
                column: "Room",
                value: 101);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 15,
                column: "Room",
                value: 101);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 16,
                column: "Room",
                value: 101);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 17,
                column: "Room",
                value: 101);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 21,
                column: "Room",
                value: 202);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 22,
                column: "Room",
                value: 202);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 23,
                column: "Room",
                value: 202);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 24,
                column: "Room",
                value: 202);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 25,
                column: "Room",
                value: 202);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 26,
                column: "Room",
                value: 202);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 27,
                column: "Room",
                value: 202);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 31,
                column: "Room",
                value: 303);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 32,
                column: "Room",
                value: 303);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 33,
                column: "Room",
                value: 303);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 34,
                column: "Room",
                value: 303);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 35,
                column: "Room",
                value: 303);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 36,
                column: "Room",
                value: 303);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 37,
                column: "Room",
                value: 303);
        }
    }
}
