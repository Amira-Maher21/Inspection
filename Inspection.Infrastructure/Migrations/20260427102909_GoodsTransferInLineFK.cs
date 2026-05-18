using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class GoodsTransferInLineFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BOQItemId",
                schema: "Inventory",
                table: "GoodsTransferInLine",
                newName: "BOQLineId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsTransferInLine_ActivityId",
                schema: "Inventory",
                table: "GoodsTransferInLine",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsTransferInLine_BOQLineId",
                schema: "Inventory",
                table: "GoodsTransferInLine",
                column: "BOQLineId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsTransferInLine_CostCodeId",
                schema: "Inventory",
                table: "GoodsTransferInLine",
                column: "CostCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsTransferInLine_ProductionOrderId",
                schema: "Inventory",
                table: "GoodsTransferInLine",
                column: "ProductionOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsTransferInLine_SubcontractBOQId",
                schema: "Inventory",
                table: "GoodsTransferInLine",
                column: "SubcontractBOQId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsTransferInLine_WBSId",
                schema: "Inventory",
                table: "GoodsTransferInLine",
                column: "WBSId");

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsTransferInLine_Activity_ActivityId",
                schema: "Inventory",
                table: "GoodsTransferInLine",
                column: "ActivityId",
                principalSchema: "Contracting",
                principalTable: "Activity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsTransferInLine_BOQLine_BOQLineId",
                schema: "Inventory",
                table: "GoodsTransferInLine",
                column: "BOQLineId",
                principalSchema: "Contracting",
                principalTable: "BOQLine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsTransferInLine_CostCode_CostCodeId",
                schema: "Inventory",
                table: "GoodsTransferInLine",
                column: "CostCodeId",
                principalSchema: "Contracting",
                principalTable: "CostCode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsTransferInLine_ProductionOrder_ProductionOrderId",
                schema: "Inventory",
                table: "GoodsTransferInLine",
                column: "ProductionOrderId",
                principalSchema: "Manufacturing",
                principalTable: "ProductionOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsTransferInLine_SubcontractBOQ_SubcontractBOQId",
                schema: "Inventory",
                table: "GoodsTransferInLine",
                column: "SubcontractBOQId",
                principalSchema: "Contracting",
                principalTable: "SubcontractBOQ",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsTransferInLine_WBS_WBSId",
                schema: "Inventory",
                table: "GoodsTransferInLine",
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
                name: "FK_GoodsTransferInLine_Activity_ActivityId",
                schema: "Inventory",
                table: "GoodsTransferInLine");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsTransferInLine_BOQLine_BOQLineId",
                schema: "Inventory",
                table: "GoodsTransferInLine");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsTransferInLine_CostCode_CostCodeId",
                schema: "Inventory",
                table: "GoodsTransferInLine");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsTransferInLine_ProductionOrder_ProductionOrderId",
                schema: "Inventory",
                table: "GoodsTransferInLine");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsTransferInLine_SubcontractBOQ_SubcontractBOQId",
                schema: "Inventory",
                table: "GoodsTransferInLine");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsTransferInLine_WBS_WBSId",
                schema: "Inventory",
                table: "GoodsTransferInLine");

            migrationBuilder.DropIndex(
                name: "IX_GoodsTransferInLine_ActivityId",
                schema: "Inventory",
                table: "GoodsTransferInLine");

            migrationBuilder.DropIndex(
                name: "IX_GoodsTransferInLine_BOQLineId",
                schema: "Inventory",
                table: "GoodsTransferInLine");

            migrationBuilder.DropIndex(
                name: "IX_GoodsTransferInLine_CostCodeId",
                schema: "Inventory",
                table: "GoodsTransferInLine");

            migrationBuilder.DropIndex(
                name: "IX_GoodsTransferInLine_ProductionOrderId",
                schema: "Inventory",
                table: "GoodsTransferInLine");

            migrationBuilder.DropIndex(
                name: "IX_GoodsTransferInLine_SubcontractBOQId",
                schema: "Inventory",
                table: "GoodsTransferInLine");

            migrationBuilder.DropIndex(
                name: "IX_GoodsTransferInLine_WBSId",
                schema: "Inventory",
                table: "GoodsTransferInLine");

            migrationBuilder.RenameColumn(
                name: "BOQLineId",
                schema: "Inventory",
                table: "GoodsTransferInLine",
                newName: "BOQItemId");
        }
    }
}
