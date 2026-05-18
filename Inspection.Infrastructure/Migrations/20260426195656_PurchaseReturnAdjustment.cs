using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PurchaseReturnAdjustment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BOQItemId",
                schema: "Accounting",
                table: "PurchaseReturnAdjustment",
                newName: "BOQLineId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnAdjustment_ActivityId",
                schema: "Accounting",
                table: "PurchaseReturnAdjustment",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnAdjustment_BOQLineId",
                schema: "Accounting",
                table: "PurchaseReturnAdjustment",
                column: "BOQLineId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnAdjustment_CostCodeId",
                schema: "Accounting",
                table: "PurchaseReturnAdjustment",
                column: "CostCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnAdjustment_ProductionOrderId",
                schema: "Accounting",
                table: "PurchaseReturnAdjustment",
                column: "ProductionOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnAdjustment_SubcontractBOQId",
                schema: "Accounting",
                table: "PurchaseReturnAdjustment",
                column: "SubcontractBOQId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnAdjustment_WBSId",
                schema: "Accounting",
                table: "PurchaseReturnAdjustment",
                column: "WBSId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseReturnAdjustment_Activity_ActivityId",
                schema: "Accounting",
                table: "PurchaseReturnAdjustment",
                column: "ActivityId",
                principalSchema: "Contracting",
                principalTable: "Activity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseReturnAdjustment_BOQLine_BOQLineId",
                schema: "Accounting",
                table: "PurchaseReturnAdjustment",
                column: "BOQLineId",
                principalSchema: "Contracting",
                principalTable: "BOQLine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseReturnAdjustment_CostCode_CostCodeId",
                schema: "Accounting",
                table: "PurchaseReturnAdjustment",
                column: "CostCodeId",
                principalSchema: "Contracting",
                principalTable: "CostCode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseReturnAdjustment_ProductionOrder_ProductionOrderId",
                schema: "Accounting",
                table: "PurchaseReturnAdjustment",
                column: "ProductionOrderId",
                principalSchema: "Manufacturing",
                principalTable: "ProductionOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseReturnAdjustment_SubcontractBOQ_SubcontractBOQId",
                schema: "Accounting",
                table: "PurchaseReturnAdjustment",
                column: "SubcontractBOQId",
                principalSchema: "Contracting",
                principalTable: "SubcontractBOQ",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseReturnAdjustment_WBS_WBSId",
                schema: "Accounting",
                table: "PurchaseReturnAdjustment",
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
                name: "FK_PurchaseReturnAdjustment_Activity_ActivityId",
                schema: "Accounting",
                table: "PurchaseReturnAdjustment");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseReturnAdjustment_BOQLine_BOQLineId",
                schema: "Accounting",
                table: "PurchaseReturnAdjustment");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseReturnAdjustment_CostCode_CostCodeId",
                schema: "Accounting",
                table: "PurchaseReturnAdjustment");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseReturnAdjustment_ProductionOrder_ProductionOrderId",
                schema: "Accounting",
                table: "PurchaseReturnAdjustment");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseReturnAdjustment_SubcontractBOQ_SubcontractBOQId",
                schema: "Accounting",
                table: "PurchaseReturnAdjustment");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseReturnAdjustment_WBS_WBSId",
                schema: "Accounting",
                table: "PurchaseReturnAdjustment");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseReturnAdjustment_ActivityId",
                schema: "Accounting",
                table: "PurchaseReturnAdjustment");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseReturnAdjustment_BOQLineId",
                schema: "Accounting",
                table: "PurchaseReturnAdjustment");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseReturnAdjustment_CostCodeId",
                schema: "Accounting",
                table: "PurchaseReturnAdjustment");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseReturnAdjustment_ProductionOrderId",
                schema: "Accounting",
                table: "PurchaseReturnAdjustment");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseReturnAdjustment_SubcontractBOQId",
                schema: "Accounting",
                table: "PurchaseReturnAdjustment");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseReturnAdjustment_WBSId",
                schema: "Accounting",
                table: "PurchaseReturnAdjustment");

            migrationBuilder.RenameColumn(
                name: "BOQLineId",
                schema: "Accounting",
                table: "PurchaseReturnAdjustment",
                newName: "BOQItemId");
        }
    }
}
