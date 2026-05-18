using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DebitNoteLineFK1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GoodsReceiptLine_Activity_ActivityId",
                schema: "Inventory",
                table: "GoodsReceiptLine");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsReceiptLine_BOQLine_BOQLineId",
                schema: "Inventory",
                table: "GoodsReceiptLine");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsReceiptLine_CostCode_CostCodeId",
                schema: "Inventory",
                table: "GoodsReceiptLine");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsReceiptLine_ProductionOrder_ProductionOrderId",
                schema: "Inventory",
                table: "GoodsReceiptLine");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsReceiptLine_SubcontractBOQ_SubcontractBOQId",
                schema: "Inventory",
                table: "GoodsReceiptLine");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsReceiptLine_WBS_WBSId",
                schema: "Inventory",
                table: "GoodsReceiptLine");

            migrationBuilder.RenameColumn(
                name: "BOQItemId",
                schema: "Accounting",
                table: "DebitNoteLine",
                newName: "BOQLineId");

            migrationBuilder.CreateIndex(
                name: "IX_DebitNoteLine_ActivityId",
                schema: "Accounting",
                table: "DebitNoteLine",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_DebitNoteLine_BOQLineId",
                schema: "Accounting",
                table: "DebitNoteLine",
                column: "BOQLineId");

            migrationBuilder.CreateIndex(
                name: "IX_DebitNoteLine_CostCodeId",
                schema: "Accounting",
                table: "DebitNoteLine",
                column: "CostCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_DebitNoteLine_ProductionOrderId",
                schema: "Accounting",
                table: "DebitNoteLine",
                column: "ProductionOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_DebitNoteLine_SubcontractBOQId",
                schema: "Accounting",
                table: "DebitNoteLine",
                column: "SubcontractBOQId");

            migrationBuilder.CreateIndex(
                name: "IX_DebitNoteLine_WBSId",
                schema: "Accounting",
                table: "DebitNoteLine",
                column: "WBSId");

            migrationBuilder.AddForeignKey(
                name: "FK_DebitNoteLine_Activity_ActivityId",
                schema: "Accounting",
                table: "DebitNoteLine",
                column: "ActivityId",
                principalSchema: "Contracting",
                principalTable: "Activity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DebitNoteLine_BOQLine_BOQLineId",
                schema: "Accounting",
                table: "DebitNoteLine",
                column: "BOQLineId",
                principalSchema: "Contracting",
                principalTable: "BOQLine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DebitNoteLine_CostCode_CostCodeId",
                schema: "Accounting",
                table: "DebitNoteLine",
                column: "CostCodeId",
                principalSchema: "Contracting",
                principalTable: "CostCode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DebitNoteLine_ProductionOrder_ProductionOrderId",
                schema: "Accounting",
                table: "DebitNoteLine",
                column: "ProductionOrderId",
                principalSchema: "Manufacturing",
                principalTable: "ProductionOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DebitNoteLine_SubcontractBOQ_SubcontractBOQId",
                schema: "Accounting",
                table: "DebitNoteLine",
                column: "SubcontractBOQId",
                principalSchema: "Contracting",
                principalTable: "SubcontractBOQ",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DebitNoteLine_WBS_WBSId",
                schema: "Accounting",
                table: "DebitNoteLine",
                column: "WBSId",
                principalSchema: "Contracting",
                principalTable: "WBS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsReceiptLine_Activity_ActivityId",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                column: "ActivityId",
                principalSchema: "Contracting",
                principalTable: "Activity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsReceiptLine_BOQLine_BOQLineId",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                column: "BOQLineId",
                principalSchema: "Contracting",
                principalTable: "BOQLine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsReceiptLine_CostCode_CostCodeId",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                column: "CostCodeId",
                principalSchema: "Contracting",
                principalTable: "CostCode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsReceiptLine_ProductionOrder_ProductionOrderId",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                column: "ProductionOrderId",
                principalSchema: "Manufacturing",
                principalTable: "ProductionOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsReceiptLine_SubcontractBOQ_SubcontractBOQId",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                column: "SubcontractBOQId",
                principalSchema: "Contracting",
                principalTable: "SubcontractBOQ",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsReceiptLine_WBS_WBSId",
                schema: "Inventory",
                table: "GoodsReceiptLine",
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
                name: "FK_DebitNoteLine_Activity_ActivityId",
                schema: "Accounting",
                table: "DebitNoteLine");

            migrationBuilder.DropForeignKey(
                name: "FK_DebitNoteLine_BOQLine_BOQLineId",
                schema: "Accounting",
                table: "DebitNoteLine");

            migrationBuilder.DropForeignKey(
                name: "FK_DebitNoteLine_CostCode_CostCodeId",
                schema: "Accounting",
                table: "DebitNoteLine");

            migrationBuilder.DropForeignKey(
                name: "FK_DebitNoteLine_ProductionOrder_ProductionOrderId",
                schema: "Accounting",
                table: "DebitNoteLine");

            migrationBuilder.DropForeignKey(
                name: "FK_DebitNoteLine_SubcontractBOQ_SubcontractBOQId",
                schema: "Accounting",
                table: "DebitNoteLine");

            migrationBuilder.DropForeignKey(
                name: "FK_DebitNoteLine_WBS_WBSId",
                schema: "Accounting",
                table: "DebitNoteLine");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsReceiptLine_Activity_ActivityId",
                schema: "Inventory",
                table: "GoodsReceiptLine");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsReceiptLine_BOQLine_BOQLineId",
                schema: "Inventory",
                table: "GoodsReceiptLine");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsReceiptLine_CostCode_CostCodeId",
                schema: "Inventory",
                table: "GoodsReceiptLine");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsReceiptLine_ProductionOrder_ProductionOrderId",
                schema: "Inventory",
                table: "GoodsReceiptLine");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsReceiptLine_SubcontractBOQ_SubcontractBOQId",
                schema: "Inventory",
                table: "GoodsReceiptLine");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsReceiptLine_WBS_WBSId",
                schema: "Inventory",
                table: "GoodsReceiptLine");

            migrationBuilder.DropIndex(
                name: "IX_DebitNoteLine_ActivityId",
                schema: "Accounting",
                table: "DebitNoteLine");

            migrationBuilder.DropIndex(
                name: "IX_DebitNoteLine_BOQLineId",
                schema: "Accounting",
                table: "DebitNoteLine");

            migrationBuilder.DropIndex(
                name: "IX_DebitNoteLine_CostCodeId",
                schema: "Accounting",
                table: "DebitNoteLine");

            migrationBuilder.DropIndex(
                name: "IX_DebitNoteLine_ProductionOrderId",
                schema: "Accounting",
                table: "DebitNoteLine");

            migrationBuilder.DropIndex(
                name: "IX_DebitNoteLine_SubcontractBOQId",
                schema: "Accounting",
                table: "DebitNoteLine");

            migrationBuilder.DropIndex(
                name: "IX_DebitNoteLine_WBSId",
                schema: "Accounting",
                table: "DebitNoteLine");

            migrationBuilder.RenameColumn(
                name: "BOQLineId",
                schema: "Accounting",
                table: "DebitNoteLine",
                newName: "BOQItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsReceiptLine_Activity_ActivityId",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                column: "ActivityId",
                principalSchema: "Contracting",
                principalTable: "Activity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsReceiptLine_BOQLine_BOQLineId",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                column: "BOQLineId",
                principalSchema: "Contracting",
                principalTable: "BOQLine",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsReceiptLine_CostCode_CostCodeId",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                column: "CostCodeId",
                principalSchema: "Contracting",
                principalTable: "CostCode",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsReceiptLine_ProductionOrder_ProductionOrderId",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                column: "ProductionOrderId",
                principalSchema: "Manufacturing",
                principalTable: "ProductionOrder",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsReceiptLine_SubcontractBOQ_SubcontractBOQId",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                column: "SubcontractBOQId",
                principalSchema: "Contracting",
                principalTable: "SubcontractBOQ",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsReceiptLine_WBS_WBSId",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                column: "WBSId",
                principalSchema: "Contracting",
                principalTable: "WBS",
                principalColumn: "Id");
        }
    }
}
