using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CashPaymentAdjustmentFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BOQItemId",
                schema: "Accounting",
                table: "CashPaymentAdjustment",
                newName: "BOQLineId");

            migrationBuilder.CreateIndex(
                name: "IX_CashPaymentAdjustment_ActivityId",
                schema: "Accounting",
                table: "CashPaymentAdjustment",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_CashPaymentAdjustment_BOQLineId",
                schema: "Accounting",
                table: "CashPaymentAdjustment",
                column: "BOQLineId");

            migrationBuilder.CreateIndex(
                name: "IX_CashPaymentAdjustment_CostCodeId",
                schema: "Accounting",
                table: "CashPaymentAdjustment",
                column: "CostCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_CashPaymentAdjustment_ProductionOrderId",
                schema: "Accounting",
                table: "CashPaymentAdjustment",
                column: "ProductionOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_CashPaymentAdjustment_SubcontractBOQId",
                schema: "Accounting",
                table: "CashPaymentAdjustment",
                column: "SubcontractBOQId");

            migrationBuilder.CreateIndex(
                name: "IX_CashPaymentAdjustment_WBSId",
                schema: "Accounting",
                table: "CashPaymentAdjustment",
                column: "WBSId");

            migrationBuilder.AddForeignKey(
                name: "FK_CashPaymentAdjustment_Activity_ActivityId",
                schema: "Accounting",
                table: "CashPaymentAdjustment",
                column: "ActivityId",
                principalSchema: "Contracting",
                principalTable: "Activity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CashPaymentAdjustment_BOQLine_BOQLineId",
                schema: "Accounting",
                table: "CashPaymentAdjustment",
                column: "BOQLineId",
                principalSchema: "Contracting",
                principalTable: "BOQLine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CashPaymentAdjustment_CostCode_CostCodeId",
                schema: "Accounting",
                table: "CashPaymentAdjustment",
                column: "CostCodeId",
                principalSchema: "Contracting",
                principalTable: "CostCode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CashPaymentAdjustment_ProductionOrder_ProductionOrderId",
                schema: "Accounting",
                table: "CashPaymentAdjustment",
                column: "ProductionOrderId",
                principalSchema: "Manufacturing",
                principalTable: "ProductionOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CashPaymentAdjustment_SubcontractBOQ_SubcontractBOQId",
                schema: "Accounting",
                table: "CashPaymentAdjustment",
                column: "SubcontractBOQId",
                principalSchema: "Contracting",
                principalTable: "SubcontractBOQ",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CashPaymentAdjustment_WBS_WBSId",
                schema: "Accounting",
                table: "CashPaymentAdjustment",
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
                name: "FK_CashPaymentAdjustment_Activity_ActivityId",
                schema: "Accounting",
                table: "CashPaymentAdjustment");

            migrationBuilder.DropForeignKey(
                name: "FK_CashPaymentAdjustment_BOQLine_BOQLineId",
                schema: "Accounting",
                table: "CashPaymentAdjustment");

            migrationBuilder.DropForeignKey(
                name: "FK_CashPaymentAdjustment_CostCode_CostCodeId",
                schema: "Accounting",
                table: "CashPaymentAdjustment");

            migrationBuilder.DropForeignKey(
                name: "FK_CashPaymentAdjustment_ProductionOrder_ProductionOrderId",
                schema: "Accounting",
                table: "CashPaymentAdjustment");

            migrationBuilder.DropForeignKey(
                name: "FK_CashPaymentAdjustment_SubcontractBOQ_SubcontractBOQId",
                schema: "Accounting",
                table: "CashPaymentAdjustment");

            migrationBuilder.DropForeignKey(
                name: "FK_CashPaymentAdjustment_WBS_WBSId",
                schema: "Accounting",
                table: "CashPaymentAdjustment");

            migrationBuilder.DropIndex(
                name: "IX_CashPaymentAdjustment_ActivityId",
                schema: "Accounting",
                table: "CashPaymentAdjustment");

            migrationBuilder.DropIndex(
                name: "IX_CashPaymentAdjustment_BOQLineId",
                schema: "Accounting",
                table: "CashPaymentAdjustment");

            migrationBuilder.DropIndex(
                name: "IX_CashPaymentAdjustment_CostCodeId",
                schema: "Accounting",
                table: "CashPaymentAdjustment");

            migrationBuilder.DropIndex(
                name: "IX_CashPaymentAdjustment_ProductionOrderId",
                schema: "Accounting",
                table: "CashPaymentAdjustment");

            migrationBuilder.DropIndex(
                name: "IX_CashPaymentAdjustment_SubcontractBOQId",
                schema: "Accounting",
                table: "CashPaymentAdjustment");

            migrationBuilder.DropIndex(
                name: "IX_CashPaymentAdjustment_WBSId",
                schema: "Accounting",
                table: "CashPaymentAdjustment");

            migrationBuilder.RenameColumn(
                name: "BOQLineId",
                schema: "Accounting",
                table: "CashPaymentAdjustment",
                newName: "BOQItemId");
        }
    }
}
