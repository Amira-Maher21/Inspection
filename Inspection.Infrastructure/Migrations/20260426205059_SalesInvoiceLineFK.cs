using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SalesInvoiceLineFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activity",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.RenameColumn(
                name: "CostCode",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                newName: "CostCodeId");

            migrationBuilder.RenameColumn(
                name: "BOQItemId",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                newName: "BOQLineId");

            migrationBuilder.AddColumn<long>(
                name: "ActivityId",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceLine_ActivityId",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceLine_BOQLineId",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                column: "BOQLineId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceLine_CostCodeId",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                column: "CostCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceLine_ProductionOrderId",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                column: "ProductionOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceLine_SubcontractBOQId",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                column: "SubcontractBOQId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceLine_WBSId",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                column: "WBSId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesInvoiceLine_Activity_ActivityId",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                column: "ActivityId",
                principalSchema: "Contracting",
                principalTable: "Activity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesInvoiceLine_BOQLine_BOQLineId",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                column: "BOQLineId",
                principalSchema: "Contracting",
                principalTable: "BOQLine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesInvoiceLine_CostCode_CostCodeId",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                column: "CostCodeId",
                principalSchema: "Contracting",
                principalTable: "CostCode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesInvoiceLine_ProductionOrder_ProductionOrderId",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                column: "ProductionOrderId",
                principalSchema: "Manufacturing",
                principalTable: "ProductionOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesInvoiceLine_SubcontractBOQ_SubcontractBOQId",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                column: "SubcontractBOQId",
                principalSchema: "Contracting",
                principalTable: "SubcontractBOQ",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesInvoiceLine_WBS_WBSId",
                schema: "Accounting",
                table: "SalesInvoiceLine",
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
                name: "FK_SalesInvoiceLine_Activity_ActivityId",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesInvoiceLine_BOQLine_BOQLineId",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesInvoiceLine_CostCode_CostCodeId",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesInvoiceLine_ProductionOrder_ProductionOrderId",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesInvoiceLine_SubcontractBOQ_SubcontractBOQId",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesInvoiceLine_WBS_WBSId",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropIndex(
                name: "IX_SalesInvoiceLine_ActivityId",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropIndex(
                name: "IX_SalesInvoiceLine_BOQLineId",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropIndex(
                name: "IX_SalesInvoiceLine_CostCodeId",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropIndex(
                name: "IX_SalesInvoiceLine_ProductionOrderId",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropIndex(
                name: "IX_SalesInvoiceLine_SubcontractBOQId",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropIndex(
                name: "IX_SalesInvoiceLine_WBSId",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropColumn(
                name: "ActivityId",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.RenameColumn(
                name: "CostCodeId",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                newName: "CostCode");

            migrationBuilder.RenameColumn(
                name: "BOQLineId",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                newName: "BOQItemId");

            migrationBuilder.AddColumn<bool>(
                name: "Activity",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                type: "bit",
                nullable: true);
        }
    }
}
