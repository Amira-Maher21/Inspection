using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PurchaseReturnAdjustment4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BOQItemId",
                schema: "Inventory",
                table: "InventoryAdjustmentLine",
                newName: "BOQLineId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryAdjustmentLine_ActivityId",
                schema: "Inventory",
                table: "InventoryAdjustmentLine",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryAdjustmentLine_BOQLineId",
                schema: "Inventory",
                table: "InventoryAdjustmentLine",
                column: "BOQLineId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryAdjustmentLine_CostCodeId",
                schema: "Inventory",
                table: "InventoryAdjustmentLine",
                column: "CostCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryAdjustmentLine_ProductionOrderId",
                schema: "Inventory",
                table: "InventoryAdjustmentLine",
                column: "ProductionOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryAdjustmentLine_SubcontractBOQId",
                schema: "Inventory",
                table: "InventoryAdjustmentLine",
                column: "SubcontractBOQId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryAdjustmentLine_WBSId",
                schema: "Inventory",
                table: "InventoryAdjustmentLine",
                column: "WBSId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryAdjustmentLine_Activity_ActivityId",
                schema: "Inventory",
                table: "InventoryAdjustmentLine",
                column: "ActivityId",
                principalSchema: "Contracting",
                principalTable: "Activity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryAdjustmentLine_BOQLine_BOQLineId",
                schema: "Inventory",
                table: "InventoryAdjustmentLine",
                column: "BOQLineId",
                principalSchema: "Contracting",
                principalTable: "BOQLine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryAdjustmentLine_CostCode_CostCodeId",
                schema: "Inventory",
                table: "InventoryAdjustmentLine",
                column: "CostCodeId",
                principalSchema: "Contracting",
                principalTable: "CostCode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryAdjustmentLine_ProductionOrder_ProductionOrderId",
                schema: "Inventory",
                table: "InventoryAdjustmentLine",
                column: "ProductionOrderId",
                principalSchema: "Manufacturing",
                principalTable: "ProductionOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryAdjustmentLine_SubcontractBOQ_SubcontractBOQId",
                schema: "Inventory",
                table: "InventoryAdjustmentLine",
                column: "SubcontractBOQId",
                principalSchema: "Contracting",
                principalTable: "SubcontractBOQ",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryAdjustmentLine_WBS_WBSId",
                schema: "Inventory",
                table: "InventoryAdjustmentLine",
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
                name: "FK_InventoryAdjustmentLine_Activity_ActivityId",
                schema: "Inventory",
                table: "InventoryAdjustmentLine");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryAdjustmentLine_BOQLine_BOQLineId",
                schema: "Inventory",
                table: "InventoryAdjustmentLine");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryAdjustmentLine_CostCode_CostCodeId",
                schema: "Inventory",
                table: "InventoryAdjustmentLine");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryAdjustmentLine_ProductionOrder_ProductionOrderId",
                schema: "Inventory",
                table: "InventoryAdjustmentLine");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryAdjustmentLine_SubcontractBOQ_SubcontractBOQId",
                schema: "Inventory",
                table: "InventoryAdjustmentLine");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryAdjustmentLine_WBS_WBSId",
                schema: "Inventory",
                table: "InventoryAdjustmentLine");

            migrationBuilder.DropIndex(
                name: "IX_InventoryAdjustmentLine_ActivityId",
                schema: "Inventory",
                table: "InventoryAdjustmentLine");

            migrationBuilder.DropIndex(
                name: "IX_InventoryAdjustmentLine_BOQLineId",
                schema: "Inventory",
                table: "InventoryAdjustmentLine");

            migrationBuilder.DropIndex(
                name: "IX_InventoryAdjustmentLine_CostCodeId",
                schema: "Inventory",
                table: "InventoryAdjustmentLine");

            migrationBuilder.DropIndex(
                name: "IX_InventoryAdjustmentLine_ProductionOrderId",
                schema: "Inventory",
                table: "InventoryAdjustmentLine");

            migrationBuilder.DropIndex(
                name: "IX_InventoryAdjustmentLine_SubcontractBOQId",
                schema: "Inventory",
                table: "InventoryAdjustmentLine");

            migrationBuilder.DropIndex(
                name: "IX_InventoryAdjustmentLine_WBSId",
                schema: "Inventory",
                table: "InventoryAdjustmentLine");

            migrationBuilder.RenameColumn(
                name: "BOQLineId",
                schema: "Inventory",
                table: "InventoryAdjustmentLine",
                newName: "BOQItemId");
        }
    }
}
