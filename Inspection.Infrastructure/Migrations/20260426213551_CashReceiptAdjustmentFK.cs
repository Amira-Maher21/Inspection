using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CashReceiptAdjustmentFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BOQItemId",
                schema: "Accounting",
                table: "CashReceiptAdjustment",
                newName: "BOQLineId");

            migrationBuilder.CreateIndex(
                name: "IX_CashReceiptAdjustment_ActivityId",
                schema: "Accounting",
                table: "CashReceiptAdjustment",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_CashReceiptAdjustment_BOQLineId",
                schema: "Accounting",
                table: "CashReceiptAdjustment",
                column: "BOQLineId");

            migrationBuilder.CreateIndex(
                name: "IX_CashReceiptAdjustment_CostCodeId",
                schema: "Accounting",
                table: "CashReceiptAdjustment",
                column: "CostCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_CashReceiptAdjustment_ProductionOrderId",
                schema: "Accounting",
                table: "CashReceiptAdjustment",
                column: "ProductionOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_CashReceiptAdjustment_SubcontractBOQId",
                schema: "Accounting",
                table: "CashReceiptAdjustment",
                column: "SubcontractBOQId");

            migrationBuilder.CreateIndex(
                name: "IX_CashReceiptAdjustment_WBSId",
                schema: "Accounting",
                table: "CashReceiptAdjustment",
                column: "WBSId");

            migrationBuilder.AddForeignKey(
                name: "FK_CashReceiptAdjustment_Activity_ActivityId",
                schema: "Accounting",
                table: "CashReceiptAdjustment",
                column: "ActivityId",
                principalSchema: "Contracting",
                principalTable: "Activity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CashReceiptAdjustment_BOQLine_BOQLineId",
                schema: "Accounting",
                table: "CashReceiptAdjustment",
                column: "BOQLineId",
                principalSchema: "Contracting",
                principalTable: "BOQLine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CashReceiptAdjustment_CostCode_CostCodeId",
                schema: "Accounting",
                table: "CashReceiptAdjustment",
                column: "CostCodeId",
                principalSchema: "Contracting",
                principalTable: "CostCode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CashReceiptAdjustment_ProductionOrder_ProductionOrderId",
                schema: "Accounting",
                table: "CashReceiptAdjustment",
                column: "ProductionOrderId",
                principalSchema: "Manufacturing",
                principalTable: "ProductionOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CashReceiptAdjustment_SubcontractBOQ_SubcontractBOQId",
                schema: "Accounting",
                table: "CashReceiptAdjustment",
                column: "SubcontractBOQId",
                principalSchema: "Contracting",
                principalTable: "SubcontractBOQ",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CashReceiptAdjustment_WBS_WBSId",
                schema: "Accounting",
                table: "CashReceiptAdjustment",
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
                name: "FK_CashReceiptAdjustment_Activity_ActivityId",
                schema: "Accounting",
                table: "CashReceiptAdjustment");

            migrationBuilder.DropForeignKey(
                name: "FK_CashReceiptAdjustment_BOQLine_BOQLineId",
                schema: "Accounting",
                table: "CashReceiptAdjustment");

            migrationBuilder.DropForeignKey(
                name: "FK_CashReceiptAdjustment_CostCode_CostCodeId",
                schema: "Accounting",
                table: "CashReceiptAdjustment");

            migrationBuilder.DropForeignKey(
                name: "FK_CashReceiptAdjustment_ProductionOrder_ProductionOrderId",
                schema: "Accounting",
                table: "CashReceiptAdjustment");

            migrationBuilder.DropForeignKey(
                name: "FK_CashReceiptAdjustment_SubcontractBOQ_SubcontractBOQId",
                schema: "Accounting",
                table: "CashReceiptAdjustment");

            migrationBuilder.DropForeignKey(
                name: "FK_CashReceiptAdjustment_WBS_WBSId",
                schema: "Accounting",
                table: "CashReceiptAdjustment");

            migrationBuilder.DropIndex(
                name: "IX_CashReceiptAdjustment_ActivityId",
                schema: "Accounting",
                table: "CashReceiptAdjustment");

            migrationBuilder.DropIndex(
                name: "IX_CashReceiptAdjustment_BOQLineId",
                schema: "Accounting",
                table: "CashReceiptAdjustment");

            migrationBuilder.DropIndex(
                name: "IX_CashReceiptAdjustment_CostCodeId",
                schema: "Accounting",
                table: "CashReceiptAdjustment");

            migrationBuilder.DropIndex(
                name: "IX_CashReceiptAdjustment_ProductionOrderId",
                schema: "Accounting",
                table: "CashReceiptAdjustment");

            migrationBuilder.DropIndex(
                name: "IX_CashReceiptAdjustment_SubcontractBOQId",
                schema: "Accounting",
                table: "CashReceiptAdjustment");

            migrationBuilder.DropIndex(
                name: "IX_CashReceiptAdjustment_WBSId",
                schema: "Accounting",
                table: "CashReceiptAdjustment");

            migrationBuilder.RenameColumn(
                name: "BOQLineId",
                schema: "Accounting",
                table: "CashReceiptAdjustment",
                newName: "BOQItemId");
        }
    }
}
