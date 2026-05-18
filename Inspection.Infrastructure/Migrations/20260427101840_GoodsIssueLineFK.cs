using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class GoodsIssueLineFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BOQItemId",
                schema: "Inventory",
                table: "GoodsIssueLine",
                newName: "BOQLineId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsIssueLine_ActivityId",
                schema: "Inventory",
                table: "GoodsIssueLine",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsIssueLine_BOQLineId",
                schema: "Inventory",
                table: "GoodsIssueLine",
                column: "BOQLineId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsIssueLine_CostCodeId",
                schema: "Inventory",
                table: "GoodsIssueLine",
                column: "CostCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsIssueLine_ProductionOrderId",
                schema: "Inventory",
                table: "GoodsIssueLine",
                column: "ProductionOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsIssueLine_SubcontractBOQId",
                schema: "Inventory",
                table: "GoodsIssueLine",
                column: "SubcontractBOQId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsIssueLine_WBSId",
                schema: "Inventory",
                table: "GoodsIssueLine",
                column: "WBSId");

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsIssueLine_Activity_ActivityId",
                schema: "Inventory",
                table: "GoodsIssueLine",
                column: "ActivityId",
                principalSchema: "Contracting",
                principalTable: "Activity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsIssueLine_BOQLine_BOQLineId",
                schema: "Inventory",
                table: "GoodsIssueLine",
                column: "BOQLineId",
                principalSchema: "Contracting",
                principalTable: "BOQLine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsIssueLine_CostCode_CostCodeId",
                schema: "Inventory",
                table: "GoodsIssueLine",
                column: "CostCodeId",
                principalSchema: "Contracting",
                principalTable: "CostCode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsIssueLine_ProductionOrder_ProductionOrderId",
                schema: "Inventory",
                table: "GoodsIssueLine",
                column: "ProductionOrderId",
                principalSchema: "Manufacturing",
                principalTable: "ProductionOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsIssueLine_SubcontractBOQ_SubcontractBOQId",
                schema: "Inventory",
                table: "GoodsIssueLine",
                column: "SubcontractBOQId",
                principalSchema: "Contracting",
                principalTable: "SubcontractBOQ",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsIssueLine_WBS_WBSId",
                schema: "Inventory",
                table: "GoodsIssueLine",
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
                name: "FK_GoodsIssueLine_Activity_ActivityId",
                schema: "Inventory",
                table: "GoodsIssueLine");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsIssueLine_BOQLine_BOQLineId",
                schema: "Inventory",
                table: "GoodsIssueLine");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsIssueLine_CostCode_CostCodeId",
                schema: "Inventory",
                table: "GoodsIssueLine");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsIssueLine_ProductionOrder_ProductionOrderId",
                schema: "Inventory",
                table: "GoodsIssueLine");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsIssueLine_SubcontractBOQ_SubcontractBOQId",
                schema: "Inventory",
                table: "GoodsIssueLine");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsIssueLine_WBS_WBSId",
                schema: "Inventory",
                table: "GoodsIssueLine");

            migrationBuilder.DropIndex(
                name: "IX_GoodsIssueLine_ActivityId",
                schema: "Inventory",
                table: "GoodsIssueLine");

            migrationBuilder.DropIndex(
                name: "IX_GoodsIssueLine_BOQLineId",
                schema: "Inventory",
                table: "GoodsIssueLine");

            migrationBuilder.DropIndex(
                name: "IX_GoodsIssueLine_CostCodeId",
                schema: "Inventory",
                table: "GoodsIssueLine");

            migrationBuilder.DropIndex(
                name: "IX_GoodsIssueLine_ProductionOrderId",
                schema: "Inventory",
                table: "GoodsIssueLine");

            migrationBuilder.DropIndex(
                name: "IX_GoodsIssueLine_SubcontractBOQId",
                schema: "Inventory",
                table: "GoodsIssueLine");

            migrationBuilder.DropIndex(
                name: "IX_GoodsIssueLine_WBSId",
                schema: "Inventory",
                table: "GoodsIssueLine");

            migrationBuilder.RenameColumn(
                name: "BOQLineId",
                schema: "Inventory",
                table: "GoodsIssueLine",
                newName: "BOQItemId");
        }
    }
}
