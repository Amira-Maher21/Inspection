using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SalesReturn22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryScrap_Warehouse_WarehouseId",
                schema: "Inventory",
                table: "InventoryScrap");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryScrapLine_Warehouse_WarehouseId",
                schema: "Inventory",
                table: "InventoryScrapLine");

            migrationBuilder.DropIndex(
                name: "IX_InventoryScrapLine_WarehouseId",
                schema: "Inventory",
                table: "InventoryScrapLine");

            migrationBuilder.DropIndex(
                name: "IX_InventoryScrap_WarehouseId",
                schema: "Inventory",
                table: "InventoryScrap");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                schema: "Inventory",
                table: "InventoryScrapLine");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                schema: "Inventory",
                table: "InventoryScrap");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "WarehouseId",
                schema: "Inventory",
                table: "InventoryScrapLine",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "WarehouseId",
                schema: "Inventory",
                table: "InventoryScrap",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_InventoryScrapLine_WarehouseId",
                schema: "Inventory",
                table: "InventoryScrapLine",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryScrap_WarehouseId",
                schema: "Inventory",
                table: "InventoryScrap",
                column: "WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryScrap_Warehouse_WarehouseId",
                schema: "Inventory",
                table: "InventoryScrap",
                column: "WarehouseId",
                principalSchema: "Inventory",
                principalTable: "Warehouse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryScrapLine_Warehouse_WarehouseId",
                schema: "Inventory",
                table: "InventoryScrapLine",
                column: "WarehouseId",
                principalSchema: "Inventory",
                principalTable: "Warehouse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
