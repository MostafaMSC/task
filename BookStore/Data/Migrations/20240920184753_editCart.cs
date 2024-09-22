using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Data.Migrations
{
    public partial class editCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin",
                column: "ConcurrencyStamp",
                value: "11445ee2-106e-4a0f-8248-f96e5d21a7da");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin2",
                column: "ConcurrencyStamp",
                value: "e52cc4ff-fcc4-4c15-9cd6-1ec0ddfb1fd5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "owner",
                column: "ConcurrencyStamp",
                value: "6238f00c-d3be-4eb5-bda2-bd1c906245b6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "View",
                column: "ConcurrencyStamp",
                value: "a4400d45-4b2f-41ba-85e3-413dea58050b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3ab5afa2-c709-44f8-82c6-9c2b20a58c7b", "42e84801-5359-44b9-a063-f6c3dff61f94" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin",
                column: "ConcurrencyStamp",
                value: "43468248-eb5b-48b9-b680-1e91519ab74e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin2",
                column: "ConcurrencyStamp",
                value: "eadf471b-adf9-48e3-8bce-ad98ae7851b0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "owner",
                column: "ConcurrencyStamp",
                value: "9fdf8c1d-8403-4cec-b320-2105e64b5c95");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "View",
                column: "ConcurrencyStamp",
                value: "5d2bc45e-dc55-462e-a1d2-95b46cbb6589");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "01eb0fc4-9423-4f7e-80ff-e8119a41b986", "88475cd6-82ca-4b14-af34-cf314c008124" });
        }
    }
}
