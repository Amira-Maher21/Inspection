using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class GoodsReceiptLinefk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BOQItemId",
                schema: "Accounting",
                table: "CashReceiptLine",
                newName: "BOQLineId");

            migrationBuilder.CreateIndex(
                name: "IX_CashReceiptLine_ActivityId",
                schema: "Accounting",
                table: "CashReceiptLine",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_CashReceiptLine_BOQLineId",
                schema: "Accounting",
                table: "CashReceiptLine",
                column: "BOQLineId");

            migrationBuilder.CreateIndex(
                name: "IX_CashReceiptLine_CostCodeId",
                schema: "Accounting",
                table: "CashReceiptLine",
                column: "CostCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_CashReceiptLine_ProductionOrderId",
                schema: "Accounting",
                table: "CashReceiptLine",
                column: "ProductionOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_CashReceiptLine_SubcontractBOQId",
                schema: "Accounting",
                table: "CashReceiptLine",
                column: "SubcontractBOQId");

            migrationBuilder.CreateIndex(
                name: "IX_CashReceiptLine_WBSId",
                schema: "Accounting",
                table: "CashReceiptLine",
                column: "WBSId");

            migrationBuilder.AddForeignKey(
                name: "FK_CashReceiptLine_Activity_ActivityId",
                schema: "Accounting",
                table: "CashReceiptLine",
                column: "ActivityId",
                principalSchema: "Contracting",
                principalTable: "Activity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CashReceiptLine_BOQLine_BOQLineId",
                schema: "Accounting",
                table: "CashReceiptLine",
                column: "BOQLineId",
                principalSchema: "Contracting",
                principalTable: "BOQLine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CashReceiptLine_CostCode_CostCodeId",
                schema: "Accounting",
                table: "CashReceiptLine",
                column: "CostCodeId",
                principalSchema: "Contracting",
                principalTable: "CostCode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CashReceiptLine_ProductionOrder_ProductionOrderId",
                schema: "Accounting",
                table: "CashReceiptLine",
                column: "ProductionOrderId",
                principalSchema: "Manufacturing",
                principalTable: "ProductionOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CashReceiptLine_SubcontractBOQ_SubcontractBOQId",
                schema: "Accounting",
                table: "CashReceiptLine",
                column: "SubcontractBOQId",
                principalSchema: "Contracting",
                principalTable: "SubcontractBOQ",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CashReceiptLine_WBS_WBSId",
                schema: "Accounting",
                table: "CashReceiptLine",
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
                name: "FK_CashReceiptLine_Activity_ActivityId",
                schema: "Accounting",
                table: "CashReceiptLine");

            migrationBuilder.DropForeignKey(
                name: "FK_CashReceiptLine_BOQLine_BOQLineId",
                schema: "Accounting",
                table: "CashReceiptLine");

            migrationBuilder.DropForeignKey(
                name: "FK_CashReceiptLine_CostCode_CostCodeId",
                schema: "Accounting",
                table: "CashReceiptLine");

            migrationBuilder.DropForeignKey(
                name: "FK_CashReceiptLine_ProductionOrder_ProductionOrderId",
                schema: "Accounting",
                table: "CashReceiptLine");

            migrationBuilder.DropForeignKey(
                name: "FK_CashReceiptLine_SubcontractBOQ_SubcontractBOQId",
                schema: "Accounting",
                table: "CashReceiptLine");

            migrationBuilder.DropForeignKey(
                name: "FK_CashReceiptLine_WBS_WBSId",
                schema: "Accounting",
                table: "CashReceiptLine");

            migrationBuilder.DropIndex(
                name: "IX_CashReceiptLine_ActivityId",
                schema: "Accounting",
                table: "CashReceiptLine");

            migrationBuilder.DropIndex(
                name: "IX_CashReceiptLine_BOQLineId",
                schema: "Accounting",
                table: "CashReceiptLine");

            migrationBuilder.DropIndex(
                name: "IX_CashReceiptLine_CostCodeId",
                schema: "Accounting",
                table: "CashReceiptLine");

            migrationBuilder.DropIndex(
                name: "IX_CashReceiptLine_ProductionOrderId",
                schema: "Accounting",
                table: "CashReceiptLine");

            migrationBuilder.DropIndex(
                name: "IX_CashReceiptLine_SubcontractBOQId",
                schema: "Accounting",
                table: "CashReceiptLine");

            migrationBuilder.DropIndex(
                name: "IX_CashReceiptLine_WBSId",
                schema: "Accounting",
                table: "CashReceiptLine");

            migrationBuilder.RenameColumn(
                name: "BOQLineId",
                schema: "Accounting",
                table: "CashReceiptLine",
                newName: "BOQItemId");
        }
    }
}
