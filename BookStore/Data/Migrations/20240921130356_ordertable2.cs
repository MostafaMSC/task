using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Data.Migrations
{
    public partial class ordertable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderModuleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItem_OrdersTable_OrderModuleId",
                        column: x => x.OrderModuleId,
                        principalTable: "OrdersTable",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin",
                column: "ConcurrencyStamp",
                value: "0a54fab7-50f5-48fc-94ba-545d46545ad4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin2",
                column: "ConcurrencyStamp",
                value: "3833037f-f9cc-4cdd-b0bb-68001a97cec9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "owner",
                column: "ConcurrencyStamp",
                value: "a98f80bf-ddeb-40aa-95a9-e3e0a82217ab");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "View",
                column: "ConcurrencyStamp",
                value: "f3e8cffb-c50a-403b-ad03-fb20ca1077f9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d8381dea-319c-4f02-a9b3-512bf41fcc22", "2bd94e4a-34a6-40ca-b5af-95e63b4ac2ef" });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderModuleId",
                table: "OrderItem",
                column: "OrderModuleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin",
                column: "ConcurrencyStamp",
                value: "4cb9ec2f-376d-44a5-a6e8-1b86e4e142c1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin2",
                column: "ConcurrencyStamp",
                value: "c98e59d8-6495-47bf-9e2d-9745e98c423f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "owner",
                column: "ConcurrencyStamp",
                value: "a4a727ea-118e-4c06-b545-ad18d9c2961c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "View",
                column: "ConcurrencyStamp",
                value: "6c662845-c245-45f5-bde3-2beae8e92ea9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "51c08bf4-892c-4bcb-b58b-1408106bf2d8", "a3deff09-bcdb-47a5-808f-b42d995466c7" });
        }
    }
}
