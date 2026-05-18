using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SalesInvoiceAllocationFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BOQItemId",
                schema: "Accounting",
                table: "SalesInvoiceAllocation",
                newName: "BOQLineId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceAllocation_ActivityId",
                schema: "Accounting",
                table: "SalesInvoiceAllocation",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceAllocation_BOQLineId",
                schema: "Accounting",
                table: "SalesInvoiceAllocation",
                column: "BOQLineId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceAllocation_CostCodeId",
                schema: "Accounting",
                table: "SalesInvoiceAllocation",
                column: "CostCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceAllocation_ProductionOrderId",
                schema: "Accounting",
                table: "SalesInvoiceAllocation",
                column: "ProductionOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceAllocation_SubcontractBOQId",
                schema: "Accounting",
                table: "SalesInvoiceAllocation",
                column: "SubcontractBOQId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceAllocation_WBSId",
                schema: "Accounting",
                table: "SalesInvoiceAllocation",
                column: "WBSId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesInvoiceAllocation_Activity_ActivityId",
                schema: "Accounting",
                table: "SalesInvoiceAllocation",
                column: "ActivityId",
                principalSchema: "Contracting",
                principalTable: "Activity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesInvoiceAllocation_BOQLine_BOQLineId",
                schema: "Accounting",
                table: "SalesInvoiceAllocation",
                column: "BOQLineId",
                principalSchema: "Contracting",
                principalTable: "BOQLine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesInvoiceAllocation_CostCode_CostCodeId",
                schema: "Accounting",
                table: "SalesInvoiceAllocation",
                column: "CostCodeId",
                principalSchema: "Contracting",
                principalTable: "CostCode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesInvoiceAllocation_ProductionOrder_ProductionOrderId",
                schema: "Accounting",
                table: "SalesInvoiceAllocation",
                column: "ProductionOrderId",
                principalSchema: "Manufacturing",
                principalTable: "ProductionOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesInvoiceAllocation_SubcontractBOQ_SubcontractBOQId",
                schema: "Accounting",
                table: "SalesInvoiceAllocation",
                column: "SubcontractBOQId",
                principalSchema: "Contracting",
                principalTable: "SubcontractBOQ",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesInvoiceAllocation_WBS_WBSId",
                schema: "Accounting",
                table: "SalesInvoiceAllocation",
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
                name: "FK_SalesInvoiceAllocation_Activity_ActivityId",
                schema: "Accounting",
                table: "SalesInvoiceAllocation");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesInvoiceAllocation_BOQLine_BOQLineId",
                schema: "Accounting",
                table: "SalesInvoiceAllocation");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesInvoiceAllocation_CostCode_CostCodeId",
                schema: "Accounting",
                table: "SalesInvoiceAllocation");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesInvoiceAllocation_ProductionOrder_ProductionOrderId",
                schema: "Accounting",
                table: "SalesInvoiceAllocation");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesInvoiceAllocation_SubcontractBOQ_SubcontractBOQId",
                schema: "Accounting",
                table: "SalesInvoiceAllocation");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesInvoiceAllocation_WBS_WBSId",
                schema: "Accounting",
                table: "SalesInvoiceAllocation");

            migrationBuilder.DropIndex(
                name: "IX_SalesInvoiceAllocation_ActivityId",
                schema: "Accounting",
                table: "SalesInvoiceAllocation");

            migrationBuilder.DropIndex(
                name: "IX_SalesInvoiceAllocation_BOQLineId",
                schema: "Accounting",
                table: "SalesInvoiceAllocation");

            migrationBuilder.DropIndex(
                name: "IX_SalesInvoiceAllocation_CostCodeId",
                schema: "Accounting",
                table: "SalesInvoiceAllocation");

            migrationBuilder.DropIndex(
                name: "IX_SalesInvoiceAllocation_ProductionOrderId",
                schema: "Accounting",
                table: "SalesInvoiceAllocation");

            migrationBuilder.DropIndex(
                name: "IX_SalesInvoiceAllocation_SubcontractBOQId",
                schema: "Accounting",
                table: "SalesInvoiceAllocation");

            migrationBuilder.DropIndex(
                name: "IX_SalesInvoiceAllocation_WBSId",
                schema: "Accounting",
                table: "SalesInvoiceAllocation");

            migrationBuilder.RenameColumn(
                name: "BOQLineId",
                schema: "Accounting",
                table: "SalesInvoiceAllocation",
                newName: "BOQItemId");
        }
    }
}
