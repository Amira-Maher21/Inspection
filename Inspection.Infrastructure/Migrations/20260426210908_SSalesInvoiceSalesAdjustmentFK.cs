using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SSalesInvoiceSalesAdjustmentFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activity",
                schema: "Accounting",
                table: "SalesInvoiceSalesAdjustment");

            migrationBuilder.RenameColumn(
                name: "CostCode",
                schema: "Accounting",
                table: "SalesInvoiceSalesAdjustment",
                newName: "CostCodeId");

            migrationBuilder.RenameColumn(
                name: "BOQItemId",
                schema: "Accounting",
                table: "SalesInvoiceSalesAdjustment",
                newName: "BOQLineId");

            migrationBuilder.AddColumn<long>(
                name: "ActivityId",
                schema: "Accounting",
                table: "SalesInvoiceSalesAdjustment",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceSalesAdjustment_ActivityId",
                schema: "Accounting",
                table: "SalesInvoiceSalesAdjustment",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceSalesAdjustment_BOQLineId",
                schema: "Accounting",
                table: "SalesInvoiceSalesAdjustment",
                column: "BOQLineId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceSalesAdjustment_CostCodeId",
                schema: "Accounting",
                table: "SalesInvoiceSalesAdjustment",
                column: "CostCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceSalesAdjustment_ProductionOrderId",
                schema: "Accounting",
                table: "SalesInvoiceSalesAdjustment",
                column: "ProductionOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceSalesAdjustment_SubcontractBOQId",
                schema: "Accounting",
                table: "SalesInvoiceSalesAdjustment",
                column: "SubcontractBOQId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceSalesAdjustment_WBSId",
                schema: "Accounting",
                table: "SalesInvoiceSalesAdjustment",
                column: "WBSId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesInvoiceSalesAdjustment_Activity_ActivityId",
                schema: "Accounting",
                table: "SalesInvoiceSalesAdjustment",
                column: "ActivityId",
                principalSchema: "Contracting",
                principalTable: "Activity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesInvoiceSalesAdjustment_BOQLine_BOQLineId",
                schema: "Accounting",
                table: "SalesInvoiceSalesAdjustment",
                column: "BOQLineId",
                principalSchema: "Contracting",
                principalTable: "BOQLine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesInvoiceSalesAdjustment_CostCode_CostCodeId",
                schema: "Accounting",
                table: "SalesInvoiceSalesAdjustment",
                column: "CostCodeId",
                principalSchema: "Contracting",
                principalTable: "CostCode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesInvoiceSalesAdjustment_ProductionOrder_ProductionOrderId",
                schema: "Accounting",
                table: "SalesInvoiceSalesAdjustment",
                column: "ProductionOrderId",
                principalSchema: "Manufacturing",
                principalTable: "ProductionOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesInvoiceSalesAdjustment_SubcontractBOQ_SubcontractBOQId",
                schema: "Accounting",
                table: "SalesInvoiceSalesAdjustment",
                column: "SubcontractBOQId",
                principalSchema: "Contracting",
                principalTable: "SubcontractBOQ",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesInvoiceSalesAdjustment_WBS_WBSId",
                schema: "Accounting",
                table: "SalesInvoiceSalesAdjustment",
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
                name: "FK_SalesInvoiceSalesAdjustment_Activity_ActivityId",
                schema: "Accounting",
                table: "SalesInvoiceSalesAdjustment");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesInvoiceSalesAdjustment_BOQLine_BOQLineId",
                schema: "Accounting",
                table: "SalesInvoiceSalesAdjustment");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesInvoiceSalesAdjustment_CostCode_CostCodeId",
                schema: "Accounting",
                table: "SalesInvoiceSalesAdjustment");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesInvoiceSalesAdjustment_ProductionOrder_ProductionOrderId",
                schema: "Accounting",
                table: "SalesInvoiceSalesAdjustment");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesInvoiceSalesAdjustment_SubcontractBOQ_SubcontractBOQId",
                schema: "Accounting",
                table: "SalesInvoiceSalesAdjustment");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesInvoiceSalesAdjustment_WBS_WBSId",
                schema: "Accounting",
                table: "SalesInvoiceSalesAdjustment");

            migrationBuilder.DropIndex(
                name: "IX_SalesInvoiceSalesAdjustment_ActivityId",
                schema: "Accounting",
                table: "SalesInvoiceSalesAdjustment");

            migrationBuilder.DropIndex(
                name: "IX_SalesInvoiceSalesAdjustment_BOQLineId",
                schema: "Accounting",
                table: "SalesInvoiceSalesAdjustment");

            migrationBuilder.DropIndex(
                name: "IX_SalesInvoiceSalesAdjustment_CostCodeId",
                schema: "Accounting",
                table: "SalesInvoiceSalesAdjustment");

            migrationBuilder.DropIndex(
                name: "IX_SalesInvoiceSalesAdjustment_ProductionOrderId",
                schema: "Accounting",
                table: "SalesInvoiceSalesAdjustment");

            migrationBuilder.DropIndex(
                name: "IX_SalesInvoiceSalesAdjustment_SubcontractBOQId",
                schema: "Accounting",
                table: "SalesInvoiceSalesAdjustment");

            migrationBuilder.DropIndex(
                name: "IX_SalesInvoiceSalesAdjustment_WBSId",
                schema: "Accounting",
                table: "SalesInvoiceSalesAdjustment");

            migrationBuilder.DropColumn(
                name: "ActivityId",
                schema: "Accounting",
                table: "SalesInvoiceSalesAdjustment");

            migrationBuilder.RenameColumn(
                name: "CostCodeId",
                schema: "Accounting",
                table: "SalesInvoiceSalesAdjustment",
                newName: "CostCode");

            migrationBuilder.RenameColumn(
                name: "BOQLineId",
                schema: "Accounting",
                table: "SalesInvoiceSalesAdjustment",
                newName: "BOQItemId");

            migrationBuilder.AddColumn<bool>(
                name: "Activity",
                schema: "Accounting",
                table: "SalesInvoiceSalesAdjustment",
                type: "bit",
                nullable: true);
        }
    }
}
