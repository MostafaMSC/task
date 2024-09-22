using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Data.Migrations
{
    public partial class ShippingCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShippingCarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShippingCarts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShippingCartId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_BooksTable_BookId",
                        column: x => x.BookId,
                        principalTable: "BooksTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_ShippingCarts_ShippingCartId",
                        column: x => x.ShippingCartId,
                        principalTable: "ShippingCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_BookId",
                table: "CartItems",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ShippingCartId",
                table: "CartItems",
                column: "ShippingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingCarts_UserId",
                table: "ShippingCarts",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "ShippingCarts");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin",
                column: "ConcurrencyStamp",
                value: "87a5bae0-7a7b-4820-863c-a9bea3339c69");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin2",
                column: "ConcurrencyStamp",
                value: "f9bdfbc9-f64c-4c5f-97c0-7f322de4c5a7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "owner",
                column: "ConcurrencyStamp",
                value: "55239331-30dc-423e-9da1-3fc509e0e392");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "View",
                column: "ConcurrencyStamp",
                value: "0ca1391d-980c-4c1d-afcc-47edfa16997e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6ca1e62c-7594-4631-aac5-5fef4a8194be", "12412238-f7cf-4c47-aca9-dd9a8090e7c4" });
        }
    }
}
