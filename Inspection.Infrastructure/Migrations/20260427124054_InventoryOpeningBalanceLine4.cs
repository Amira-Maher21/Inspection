using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InventoryOpeningBalanceLine4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BOQItemId",
                schema: "Inventory",
                table: "InventoryOpeningBalanceLine",
                newName: "BOQLineId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryOpeningBalanceLine_ActivityId",
                schema: "Inventory",
                table: "InventoryOpeningBalanceLine",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryOpeningBalanceLine_BOQLineId",
                schema: "Inventory",
                table: "InventoryOpeningBalanceLine",
                column: "BOQLineId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryOpeningBalanceLine_CostCodeId",
                schema: "Inventory",
                table: "InventoryOpeningBalanceLine",
                column: "CostCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryOpeningBalanceLine_ProductionOrderId",
                schema: "Inventory",
                table: "InventoryOpeningBalanceLine",
                column: "ProductionOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryOpeningBalanceLine_SubcontractBOQId",
                schema: "Inventory",
                table: "InventoryOpeningBalanceLine",
                column: "SubcontractBOQId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryOpeningBalanceLine_WBSId",
                schema: "Inventory",
                table: "InventoryOpeningBalanceLine",
                column: "WBSId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryOpeningBalanceLine_Activity_ActivityId",
                schema: "Inventory",
                table: "InventoryOpeningBalanceLine",
                column: "ActivityId",
                principalSchema: "Contracting",
                principalTable: "Activity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryOpeningBalanceLine_BOQLine_BOQLineId",
                schema: "Inventory",
                table: "InventoryOpeningBalanceLine",
                column: "BOQLineId",
                principalSchema: "Contracting",
                principalTable: "BOQLine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryOpeningBalanceLine_CostCode_CostCodeId",
                schema: "Inventory",
                table: "InventoryOpeningBalanceLine",
                column: "CostCodeId",
                principalSchema: "Contracting",
                principalTable: "CostCode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryOpeningBalanceLine_ProductionOrder_ProductionOrderId",
                schema: "Inventory",
                table: "InventoryOpeningBalanceLine",
                column: "ProductionOrderId",
                principalSchema: "Manufacturing",
                principalTable: "ProductionOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryOpeningBalanceLine_SubcontractBOQ_SubcontractBOQId",
                schema: "Inventory",
                table: "InventoryOpeningBalanceLine",
                column: "SubcontractBOQId",
                principalSchema: "Contracting",
                principalTable: "SubcontractBOQ",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryOpeningBalanceLine_WBS_WBSId",
                schema: "Inventory",
                table: "InventoryOpeningBalanceLine",
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
                name: "FK_InventoryOpeningBalanceLine_Activity_ActivityId",
                schema: "Inventory",
                table: "InventoryOpeningBalanceLine");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryOpeningBalanceLine_BOQLine_BOQLineId",
                schema: "Inventory",
                table: "InventoryOpeningBalanceLine");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryOpeningBalanceLine_CostCode_CostCodeId",
                schema: "Inventory",
                table: "InventoryOpeningBalanceLine");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryOpeningBalanceLine_ProductionOrder_ProductionOrderId",
                schema: "Inventory",
                table: "InventoryOpeningBalanceLine");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryOpeningBalanceLine_SubcontractBOQ_SubcontractBOQId",
                schema: "Inventory",
                table: "InventoryOpeningBalanceLine");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryOpeningBalanceLine_WBS_WBSId",
                schema: "Inventory",
                table: "InventoryOpeningBalanceLine");

            migrationBuilder.DropIndex(
                name: "IX_InventoryOpeningBalanceLine_ActivityId",
                schema: "Inventory",
                table: "InventoryOpeningBalanceLine");

            migrationBuilder.DropIndex(
                name: "IX_InventoryOpeningBalanceLine_BOQLineId",
                schema: "Inventory",
                table: "InventoryOpeningBalanceLine");

            migrationBuilder.DropIndex(
                name: "IX_InventoryOpeningBalanceLine_CostCodeId",
                schema: "Inventory",
                table: "InventoryOpeningBalanceLine");

            migrationBuilder.DropIndex(
                name: "IX_InventoryOpeningBalanceLine_ProductionOrderId",
                schema: "Inventory",
                table: "InventoryOpeningBalanceLine");

            migrationBuilder.DropIndex(
                name: "IX_InventoryOpeningBalanceLine_SubcontractBOQId",
                schema: "Inventory",
                table: "InventoryOpeningBalanceLine");

            migrationBuilder.DropIndex(
                name: "IX_InventoryOpeningBalanceLine_WBSId",
                schema: "Inventory",
                table: "InventoryOpeningBalanceLine");

            migrationBuilder.RenameColumn(
                name: "BOQLineId",
                schema: "Inventory",
                table: "InventoryOpeningBalanceLine",
                newName: "BOQItemId");
        }
    }
}
