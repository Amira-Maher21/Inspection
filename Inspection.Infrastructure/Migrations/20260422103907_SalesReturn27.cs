using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SalesReturn27 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryScrap_ScrapReason_ScrapReasonId",
                schema: "Inventory",
                table: "InventoryScrap");

            migrationBuilder.DropIndex(
                name: "IX_InventoryScrap_ScrapReasonId",
                schema: "Inventory",
                table: "InventoryScrap");

            migrationBuilder.DropColumn(
                name: "ScrapReasonId",
                schema: "Inventory",
                table: "InventoryScrap");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ScrapReasonId",
                schema: "Inventory",
                table: "InventoryScrap",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InventoryScrap_ScrapReasonId",
                schema: "Inventory",
                table: "InventoryScrap",
                column: "ScrapReasonId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryScrap_ScrapReason_ScrapReasonId",
                schema: "Inventory",
                table: "InventoryScrap",
                column: "ScrapReasonId",
                principalSchema: "Inventory",
                principalTable: "ScrapReason",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
