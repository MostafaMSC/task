using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Data.Migrations
{
    public partial class editCartnew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShippingCartModuleId",
                table: "CartItems",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin",
                column: "ConcurrencyStamp",
                value: "d446be4d-c42d-4d78-846d-fa59db3c4139");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin2",
                column: "ConcurrencyStamp",
                value: "df8e4d24-51dd-4e72-934b-ae6add0ce557");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "owner",
                column: "ConcurrencyStamp",
                value: "45e44df0-5242-410f-9d4b-b3b75a5e3ed0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "View",
                column: "ConcurrencyStamp",
                value: "519d9921-c2f1-487d-8f26-1e3af0011400");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "cb30763c-b29b-42ef-98b0-e42fcffb858c", "688d1bbe-9f8c-42bb-82af-8d42cbdbdf48" });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ShippingCartModuleId",
                table: "CartItems",
                column: "ShippingCartModuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_ShippingCarts_ShippingCartModuleId",
                table: "CartItems",
                column: "ShippingCartModuleId",
                principalTable: "ShippingCarts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_ShippingCarts_ShippingCartModuleId",
                table: "CartItems");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_ShippingCartModuleId",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "ShippingCartModuleId",
                table: "CartItems");

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
    }
}
