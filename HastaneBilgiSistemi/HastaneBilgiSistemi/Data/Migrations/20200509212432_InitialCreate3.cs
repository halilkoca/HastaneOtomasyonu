using Microsoft.EntityFrameworkCore.Migrations;

namespace HastaneBilgiSistemi.Data.Migrations
{
    public partial class InitialCreate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Polyclinic_PolyclinicId",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "PolicylinicId",
                table: "Reservation");

            migrationBuilder.AlterColumn<int>(
                name: "PolyclinicId",
                table: "Reservation",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "07551023-cdfc-40b2-98b3-d3cda1250829");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "5992814b-3867-44b5-9f0c-34790c1c2a8b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "47f37478-e5d9-405c-bd82-88331080b470");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "753f8c2b-411f-47f2-b4a9-c5976f418f66");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c6cfacc1-ea7b-41cd-8621-122911645043", "AQAAAAEAACcQAAAAEJcugf4xToJ1MKhSTjgBRII0siWJx3Z0bmRxzqTVh1MRfLzMdDTpgFnLfhwX5mY15w==", "c8717e69-a0d0-49c0-bcf0-8c3e79d2278d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5e6ee46f-56cf-404b-be55-85cea8d4beac", "AQAAAAEAACcQAAAAEKYUax3eGL5Yc+rQkg9FpbS3BxyztNzWQLk4ThJXQCbhxIaLeEAMf58Kjekq0gne7w==", "5e7385ea-7495-4719-8bd5-6e98585481fa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d405dcec-b5ef-43dd-877a-07821b98f423", "AQAAAAEAACcQAAAAEEDohhaIMkRWu9f/01f9h2a6CmqSvsh+z9K/N/6UNJuYIP1uesHPtNN9hHehjQqmog==", "4e2f0c73-34d9-4174-97ba-a8bcf2d7d8e0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9dca12d6-078b-4eb1-8765-453bf4c6dc76", "AQAAAAEAACcQAAAAEBk7tdfMD4ghnqM6iYBrmIYehml8NKFWGa8723/RDmHJJzZs4f/EFXcx9WRjTmmarA==", "b161bf1d-9494-4bf1-a2a6-b850871439c7" });

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Polyclinic_PolyclinicId",
                table: "Reservation",
                column: "PolyclinicId",
                principalTable: "Polyclinic",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Polyclinic_PolyclinicId",
                table: "Reservation");

            migrationBuilder.AlterColumn<int>(
                name: "PolyclinicId",
                table: "Reservation",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "PolicylinicId",
                table: "Reservation",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "37c2e4a6-169f-4ec7-818e-b26ed8fcee2a", "AQAAAAEAACcQAAAAEP+HyfTOMgW7TxeEp1sVWlUIlKIJAv4xXRyoYr6SSBYbLbofFWou48pBF34VNenoFg==", "a21427c7-59a1-48c0-863b-27b8367b10c8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a6184a9d-e30a-4c26-b710-041b8cd6b86a", "AQAAAAEAACcQAAAAEAYrcdzwuc66XaX0w5mQ02Vtip0hOoyBjUIgjXWpkanZ/z60p0qI8rZCISRjm6PrzQ==", "b566ab31-5316-400a-a9e8-e32639e3461d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8f78fe87-9871-41ef-9abd-1b8735a131ee", "AQAAAAEAACcQAAAAEAXGf8RC7uBdiphDjMUB/jkLBm92IIoKqwUqA0fPykJffRFPgnDFa2zqKhIYP72aqw==", "116e8b02-3638-425f-9960-cd31ac07a199" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "14068a09-4a0e-4b55-b797-d891338c88eb", "AQAAAAEAACcQAAAAEDTcaaqA4aouBWT29l9ykacJTJVpvf+5GWU4r6+ZTTXxJVav3BgAAoKwLaF4EIeEsA==", "a5e38416-4528-45ba-bb35-d27e5dd3623b" });

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Polyclinic_PolyclinicId",
                table: "Reservation",
                column: "PolyclinicId",
                principalTable: "Polyclinic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
