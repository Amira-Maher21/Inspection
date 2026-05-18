using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InventoryScrapLineFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BOQItemId",
                schema: "Inventory",
                table: "InventoryScrapLine",
                newName: "BOQLineId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryScrapLine_ActivityId",
                schema: "Inventory",
                table: "InventoryScrapLine",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryScrapLine_BOQLineId",
                schema: "Inventory",
                table: "InventoryScrapLine",
                column: "BOQLineId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryScrapLine_CostCodeId",
                schema: "Inventory",
                table: "InventoryScrapLine",
                column: "CostCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryScrapLine_ProductionOrderId",
                schema: "Inventory",
                table: "InventoryScrapLine",
                column: "ProductionOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryScrapLine_SubcontractBOQId",
                schema: "Inventory",
                table: "InventoryScrapLine",
                column: "SubcontractBOQId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryScrapLine_WBSId",
                schema: "Inventory",
                table: "InventoryScrapLine",
                column: "WBSId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryScrapLine_Activity_ActivityId",
                schema: "Inventory",
                table: "InventoryScrapLine",
                column: "ActivityId",
                principalSchema: "Contracting",
                principalTable: "Activity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryScrapLine_BOQLine_BOQLineId",
                schema: "Inventory",
                table: "InventoryScrapLine",
                column: "BOQLineId",
                principalSchema: "Contracting",
                principalTable: "BOQLine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryScrapLine_CostCode_CostCodeId",
                schema: "Inventory",
                table: "InventoryScrapLine",
                column: "CostCodeId",
                principalSchema: "Contracting",
                principalTable: "CostCode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryScrapLine_ProductionOrder_ProductionOrderId",
                schema: "Inventory",
                table: "InventoryScrapLine",
                column: "ProductionOrderId",
                principalSchema: "Manufacturing",
                principalTable: "ProductionOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryScrapLine_SubcontractBOQ_SubcontractBOQId",
                schema: "Inventory",
                table: "InventoryScrapLine",
                column: "SubcontractBOQId",
                principalSchema: "Contracting",
                principalTable: "SubcontractBOQ",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryScrapLine_WBS_WBSId",
                schema: "Inventory",
                table: "InventoryScrapLine",
                column: "WBSId",
                principalSchema: "Contracting",
                principalTable: "WBS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryScrapLine_Activity_ActivityId",
                schema: "Inventory",
                table: "InventoryScrapLine");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryScrapLine_BOQLine_BOQLineId",
                schema: "Inventory",
                table: "InventoryScrapLine");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryScrapLine_CostCode_CostCodeId",
                schema: "Inventory",
                table: "InventoryScrapLine");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryScrapLine_ProductionOrder_ProductionOrderId",
                schema: "Inventory",
                table: "InventoryScrapLine");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryScrapLine_SubcontractBOQ_SubcontractBOQId",
                schema: "Inventory",
                table: "InventoryScrapLine");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryScrapLine_WBS_WBSId",
                schema: "Inventory",
                table: "InventoryScrapLine");

            migrationBuilder.DropIndex(
                name: "IX_InventoryScrapLine_ActivityId",
                schema: "Inventory",
                table: "InventoryScrapLine");

            migrationBuilder.DropIndex(
                name: "IX_InventoryScrapLine_BOQLineId",
                schema: "Inventory",
                table: "InventoryScrapLine");

            migrationBuilder.DropIndex(
                name: "IX_InventoryScrapLine_CostCodeId",
                schema: "Inventory",
                table: "InventoryScrapLine");

            migrationBuilder.DropIndex(
                name: "IX_InventoryScrapLine_ProductionOrderId",
                schema: "Inventory",
                table: "InventoryScrapLine");

            migrationBuilder.DropIndex(
                name: "IX_InventoryScrapLine_SubcontractBOQId",
                schema: "Inventory",
                table: "InventoryScrapLine");

            migrationBuilder.DropIndex(
                name: "IX_InventoryScrapLine_WBSId",
                schema: "Inventory",
                table: "InventoryScrapLine");

            migrationBuilder.RenameColumn(
                name: "BOQLineId",
                schema: "Inventory",
                table: "InventoryScrapLine",
                newName: "BOQItemId");
        }
    }
}
