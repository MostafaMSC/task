using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Data.Migrations
{
    public partial class UpdateUsersTableByInhertinaceClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin",
                column: "ConcurrencyStamp",
                value: "f19b2cb0-2998-477d-8261-431ec732f72d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin2",
                column: "ConcurrencyStamp",
                value: "6e3be4f1-c700-48a2-bf5e-9d32dc4e3585");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "owner",
                column: "ConcurrencyStamp",
                value: "dd4d9a27-00e7-4340-8e2e-38804624824e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "View",
                column: "ConcurrencyStamp",
                value: "29440b44-66d6-4ee0-82fd-f3c578ea15ce");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e4fd0683-b6ae-4cfc-ae79-309996344de5", "ef9d0e5b-fc9c-44af-879a-3b770dff88ea" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin",
                column: "ConcurrencyStamp",
                value: "f1827d2e-61af-4181-a528-ef1bc0b898b2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin2",
                column: "ConcurrencyStamp",
                value: "1a608f23-b944-4ff8-876f-3254373baa0a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "owner",
                column: "ConcurrencyStamp",
                value: "d0346ff6-4da4-4d2f-8fa8-db6532a7f4db");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "View",
                column: "ConcurrencyStamp",
                value: "bfd6620d-281c-4e28-a753-7b1a2806fedd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c7f2cd16-5097-43f2-8bdc-e4f9e61ccbad", "13f03d7a-154e-4064-aaec-a517ddfc014b" });
        }
    }
}
