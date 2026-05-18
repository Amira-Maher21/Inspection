using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class urchaseReturnLineFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BOQItemId",
                schema: "Accounting",
                table: "PurchaseReturnLine",
                newName: "BOQLineId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnLine_ActivityId",
                schema: "Accounting",
                table: "PurchaseReturnLine",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnLine_BOQLineId",
                schema: "Accounting",
                table: "PurchaseReturnLine",
                column: "BOQLineId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnLine_CostCodeId",
                schema: "Accounting",
                table: "PurchaseReturnLine",
                column: "CostCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnLine_ProductionOrderId",
                schema: "Accounting",
                table: "PurchaseReturnLine",
                column: "ProductionOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnLine_SubcontractBOQId",
                schema: "Accounting",
                table: "PurchaseReturnLine",
                column: "SubcontractBOQId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnLine_WBSId",
                schema: "Accounting",
                table: "PurchaseReturnLine",
                column: "WBSId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseReturnLine_Activity_ActivityId",
                schema: "Accounting",
                table: "PurchaseReturnLine",
                column: "ActivityId",
                principalSchema: "Contracting",
                principalTable: "Activity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseReturnLine_BOQLine_BOQLineId",
                schema: "Accounting",
                table: "PurchaseReturnLine",
                column: "BOQLineId",
                principalSchema: "Contracting",
                principalTable: "BOQLine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseReturnLine_CostCode_CostCodeId",
                schema: "Accounting",
                table: "PurchaseReturnLine",
                column: "CostCodeId",
                principalSchema: "Contracting",
                principalTable: "CostCode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseReturnLine_ProductionOrder_ProductionOrderId",
                schema: "Accounting",
                table: "PurchaseReturnLine",
                column: "ProductionOrderId",
                principalSchema: "Manufacturing",
                principalTable: "ProductionOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseReturnLine_SubcontractBOQ_SubcontractBOQId",
                schema: "Accounting",
                table: "PurchaseReturnLine",
                column: "SubcontractBOQId",
                principalSchema: "Contracting",
                principalTable: "SubcontractBOQ",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseReturnLine_WBS_WBSId",
                schema: "Accounting",
                table: "PurchaseReturnLine",
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
                name: "FK_PurchaseReturnLine_Activity_ActivityId",
                schema: "Accounting",
                table: "PurchaseReturnLine");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseReturnLine_BOQLine_BOQLineId",
                schema: "Accounting",
                table: "PurchaseReturnLine");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseReturnLine_CostCode_CostCodeId",
                schema: "Accounting",
                table: "PurchaseReturnLine");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseReturnLine_ProductionOrder_ProductionOrderId",
                schema: "Accounting",
                table: "PurchaseReturnLine");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseReturnLine_SubcontractBOQ_SubcontractBOQId",
                schema: "Accounting",
                table: "PurchaseReturnLine");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseReturnLine_WBS_WBSId",
                schema: "Accounting",
                table: "PurchaseReturnLine");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseReturnLine_ActivityId",
                schema: "Accounting",
                table: "PurchaseReturnLine");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseReturnLine_BOQLineId",
                schema: "Accounting",
                table: "PurchaseReturnLine");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseReturnLine_CostCodeId",
                schema: "Accounting",
                table: "PurchaseReturnLine");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseReturnLine_ProductionOrderId",
                schema: "Accounting",
                table: "PurchaseReturnLine");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseReturnLine_SubcontractBOQId",
                schema: "Accounting",
                table: "PurchaseReturnLine");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseReturnLine_WBSId",
                schema: "Accounting",
                table: "PurchaseReturnLine");

            migrationBuilder.RenameColumn(
                name: "BOQLineId",
                schema: "Accounting",
                table: "PurchaseReturnLine",
                newName: "BOQItemId");
        }
    }
}
