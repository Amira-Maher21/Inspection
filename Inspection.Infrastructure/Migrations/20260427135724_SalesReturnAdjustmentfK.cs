using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SalesReturnAdjustmentfK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BOQItemId",
                schema: "Sales",
                table: "SalesReturnAdjustment",
                newName: "BOQLineId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnAdjustment_ActivityId",
                schema: "Sales",
                table: "SalesReturnAdjustment",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnAdjustment_BOQLineId",
                schema: "Sales",
                table: "SalesReturnAdjustment",
                column: "BOQLineId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnAdjustment_CostCodeId",
                schema: "Sales",
                table: "SalesReturnAdjustment",
                column: "CostCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnAdjustment_ProductionOrderId",
                schema: "Sales",
                table: "SalesReturnAdjustment",
                column: "ProductionOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnAdjustment_SubcontractBOQId",
                schema: "Sales",
                table: "SalesReturnAdjustment",
                column: "SubcontractBOQId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnAdjustment_WBSId",
                schema: "Sales",
                table: "SalesReturnAdjustment",
                column: "WBSId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesReturnAdjustment_Activity_ActivityId",
                schema: "Sales",
                table: "SalesReturnAdjustment",
                column: "ActivityId",
                principalSchema: "Contracting",
                principalTable: "Activity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesReturnAdjustment_BOQLine_BOQLineId",
                schema: "Sales",
                table: "SalesReturnAdjustment",
                column: "BOQLineId",
                principalSchema: "Contracting",
                principalTable: "BOQLine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesReturnAdjustment_CostCode_CostCodeId",
                schema: "Sales",
                table: "SalesReturnAdjustment",
                column: "CostCodeId",
                principalSchema: "Contracting",
                principalTable: "CostCode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesReturnAdjustment_ProductionOrder_ProductionOrderId",
                schema: "Sales",
                table: "SalesReturnAdjustment",
                column: "ProductionOrderId",
                principalSchema: "Manufacturing",
                principalTable: "ProductionOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesReturnAdjustment_SubcontractBOQ_SubcontractBOQId",
                schema: "Sales",
                table: "SalesReturnAdjustment",
                column: "SubcontractBOQId",
                principalSchema: "Contracting",
                principalTable: "SubcontractBOQ",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesReturnAdjustment_WBS_WBSId",
                schema: "Sales",
                table: "SalesReturnAdjustment",
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
                name: "FK_SalesReturnAdjustment_Activity_ActivityId",
                schema: "Sales",
                table: "SalesReturnAdjustment");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesReturnAdjustment_BOQLine_BOQLineId",
                schema: "Sales",
                table: "SalesReturnAdjustment");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesReturnAdjustment_CostCode_CostCodeId",
                schema: "Sales",
                table: "SalesReturnAdjustment");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesReturnAdjustment_ProductionOrder_ProductionOrderId",
                schema: "Sales",
                table: "SalesReturnAdjustment");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesReturnAdjustment_SubcontractBOQ_SubcontractBOQId",
                schema: "Sales",
                table: "SalesReturnAdjustment");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesReturnAdjustment_WBS_WBSId",
                schema: "Sales",
                table: "SalesReturnAdjustment");

            migrationBuilder.DropIndex(
                name: "IX_SalesReturnAdjustment_ActivityId",
                schema: "Sales",
                table: "SalesReturnAdjustment");

            migrationBuilder.DropIndex(
                name: "IX_SalesReturnAdjustment_BOQLineId",
                schema: "Sales",
                table: "SalesReturnAdjustment");

            migrationBuilder.DropIndex(
                name: "IX_SalesReturnAdjustment_CostCodeId",
                schema: "Sales",
                table: "SalesReturnAdjustment");

            migrationBuilder.DropIndex(
                name: "IX_SalesReturnAdjustment_ProductionOrderId",
                schema: "Sales",
                table: "SalesReturnAdjustment");

            migrationBuilder.DropIndex(
                name: "IX_SalesReturnAdjustment_SubcontractBOQId",
                schema: "Sales",
                table: "SalesReturnAdjustment");

            migrationBuilder.DropIndex(
                name: "IX_SalesReturnAdjustment_WBSId",
                schema: "Sales",
                table: "SalesReturnAdjustment");

            migrationBuilder.RenameColumn(
                name: "BOQLineId",
                schema: "Sales",
                table: "SalesReturnAdjustment",
                newName: "BOQItemId");
        }
    }
}
