using Microsoft.EntityFrameworkCore.Migrations;

namespace HastaneBilgiSistemi.Data.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "29575a75-9f3c-4f94-bf76-60e5869d46da");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "598dff6d-7f55-41f6-a126-1fe111c96ecd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "a1dea849-31ec-4993-81fa-34ca6de6d18a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "3a290b35-b23f-4afd-97e6-b57974752405");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "37c2e4a6-169f-4ec7-818e-b26ed8fcee2a", "AQAAAAEAACcQAAAAEP+HyfTOMgW7TxeEp1sVWlUIlKIJAv4xXRyoYr6SSBYbLbofFWou48pBF34VNenoFg==", "5325321234", "a21427c7-59a1-48c0-863b-27b8367b10c8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "a6184a9d-e30a-4c26-b710-041b8cd6b86a", "AQAAAAEAACcQAAAAEAYrcdzwuc66XaX0w5mQ02Vtip0hOoyBjUIgjXWpkanZ/z60p0qI8rZCISRjm6PrzQ==", "5325321234", "b566ab31-5316-400a-a9e8-e32639e3461d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "8f78fe87-9871-41ef-9abd-1b8735a131ee", "AQAAAAEAACcQAAAAEAXGf8RC7uBdiphDjMUB/jkLBm92IIoKqwUqA0fPykJffRFPgnDFa2zqKhIYP72aqw==", "5325321234", "116e8b02-3638-425f-9960-cd31ac07a199" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "14068a09-4a0e-4b55-b797-d891338c88eb", "AQAAAAEAACcQAAAAEDTcaaqA4aouBWT29l9ykacJTJVpvf+5GWU4r6+ZTTXxJVav3BgAAoKwLaF4EIeEsA==", "5325321234", "a5e38416-4528-45ba-bb35-d27e5dd3623b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "662b6721-9581-4458-8187-2dcf2710620f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "178c696b-adb0-4847-958b-470cf33f2b79");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "eff986c9-bd1f-4b53-8592-935872f4ad38");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "b8b7f8f6-d559-4f94-85f7-a3ce3923f6ea");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "7ba61a2f-dd81-48bf-a184-ffbc3e1d6258", "AQAAAAEAACcQAAAAEPASut7584avIw5wcIAkBa79LFRtHNOPHrqLDgn5cS3ZpZU7O6k5AyyWhYY692TZHA==", "+905325321234", "c7b2f62a-41b4-47ff-9ac4-668d5ef72569" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "22497238-0e62-4ad0-9bac-a83c88373ce5", "AQAAAAEAACcQAAAAECudSbSrZWTmx8lKguysMhBKB2uX6bhyFSZn/Gn7D1cAktG5I2cmvZ+xMpvagLnsYA==", "+905325321234", "097c7d89-d05b-41b1-8d45-064d08ebf687" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "a7997f76-4de8-483e-a7ce-33a02f67f807", "AQAAAAEAACcQAAAAEA54ACDAHLwEHApgudi9QVXkRCkf9h+o22U276MWqi9dx2l4bkvnrR305nvJz4hwBg==", "+905325321234", "e92b13c0-1c42-4c61-be95-2dc04a227054" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "a114fe38-784e-4b79-af14-c414ce11c811", "AQAAAAEAACcQAAAAEDSgAura8IwJrqQSLnyeTelgceAOl8HH4sDX9VWC0LPi8gHL83vZgdBWoMMHO35suw==", "+905325321234", "252db328-e197-47ed-9e9b-bf2ac23084f6" });
        }
    }
}
