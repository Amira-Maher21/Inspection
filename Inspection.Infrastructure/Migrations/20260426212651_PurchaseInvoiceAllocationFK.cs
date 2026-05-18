using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PurchaseInvoiceAllocationFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BOQItemId",
                schema: "Accounting",
                table: "PurchaseInvoiceAllocation",
                newName: "BOQLineId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceAllocation_ActivityId",
                schema: "Accounting",
                table: "PurchaseInvoiceAllocation",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceAllocation_BOQLineId",
                schema: "Accounting",
                table: "PurchaseInvoiceAllocation",
                column: "BOQLineId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceAllocation_CostCodeId",
                schema: "Accounting",
                table: "PurchaseInvoiceAllocation",
                column: "CostCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceAllocation_ProductionOrderId",
                schema: "Accounting",
                table: "PurchaseInvoiceAllocation",
                column: "ProductionOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceAllocation_SubcontractBOQId",
                schema: "Accounting",
                table: "PurchaseInvoiceAllocation",
                column: "SubcontractBOQId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceAllocation_WBSId",
                schema: "Accounting",
                table: "PurchaseInvoiceAllocation",
                column: "WBSId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseInvoiceAllocation_Activity_ActivityId",
                schema: "Accounting",
                table: "PurchaseInvoiceAllocation",
                column: "ActivityId",
                principalSchema: "Contracting",
                principalTable: "Activity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseInvoiceAllocation_BOQLine_BOQLineId",
                schema: "Accounting",
                table: "PurchaseInvoiceAllocation",
                column: "BOQLineId",
                principalSchema: "Contracting",
                principalTable: "BOQLine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseInvoiceAllocation_CostCode_CostCodeId",
                schema: "Accounting",
                table: "PurchaseInvoiceAllocation",
                column: "CostCodeId",
                principalSchema: "Contracting",
                principalTable: "CostCode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseInvoiceAllocation_ProductionOrder_ProductionOrderId",
                schema: "Accounting",
                table: "PurchaseInvoiceAllocation",
                column: "ProductionOrderId",
                principalSchema: "Manufacturing",
                principalTable: "ProductionOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseInvoiceAllocation_SubcontractBOQ_SubcontractBOQId",
                schema: "Accounting",
                table: "PurchaseInvoiceAllocation",
                column: "SubcontractBOQId",
                principalSchema: "Contracting",
                principalTable: "SubcontractBOQ",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseInvoiceAllocation_WBS_WBSId",
                schema: "Accounting",
                table: "PurchaseInvoiceAllocation",
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
                name: "FK_PurchaseInvoiceAllocation_Activity_ActivityId",
                schema: "Accounting",
                table: "PurchaseInvoiceAllocation");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseInvoiceAllocation_BOQLine_BOQLineId",
                schema: "Accounting",
                table: "PurchaseInvoiceAllocation");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseInvoiceAllocation_CostCode_CostCodeId",
                schema: "Accounting",
                table: "PurchaseInvoiceAllocation");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseInvoiceAllocation_ProductionOrder_ProductionOrderId",
                schema: "Accounting",
                table: "PurchaseInvoiceAllocation");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseInvoiceAllocation_SubcontractBOQ_SubcontractBOQId",
                schema: "Accounting",
                table: "PurchaseInvoiceAllocation");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseInvoiceAllocation_WBS_WBSId",
                schema: "Accounting",
                table: "PurchaseInvoiceAllocation");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseInvoiceAllocation_ActivityId",
                schema: "Accounting",
                table: "PurchaseInvoiceAllocation");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseInvoiceAllocation_BOQLineId",
                schema: "Accounting",
                table: "PurchaseInvoiceAllocation");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseInvoiceAllocation_CostCodeId",
                schema: "Accounting",
                table: "PurchaseInvoiceAllocation");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseInvoiceAllocation_ProductionOrderId",
                schema: "Accounting",
                table: "PurchaseInvoiceAllocation");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseInvoiceAllocation_SubcontractBOQId",
                schema: "Accounting",
                table: "PurchaseInvoiceAllocation");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseInvoiceAllocation_WBSId",
                schema: "Accounting",
                table: "PurchaseInvoiceAllocation");

            migrationBuilder.RenameColumn(
                name: "BOQLineId",
                schema: "Accounting",
                table: "PurchaseInvoiceAllocation",
                newName: "BOQItemId");
        }
    }
}
