using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class JournalEntryLineFK1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BOQItemId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine",
                newName: "BOQLineId");

            migrationBuilder.RenameColumn(
                name: "BOQItemId",
                schema: "Accounting",
                table: "JournalEntryLine",
                newName: "BOQLineId");

            migrationBuilder.RenameColumn(
                name: "BOQItemId",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                newName: "BOQLineId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntryTemplateLine_ActivityId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntryTemplateLine_BOQLineId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine",
                column: "BOQLineId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntryTemplateLine_CostCodeId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine",
                column: "CostCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntryTemplateLine_ProductionOrderId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine",
                column: "ProductionOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntryTemplateLine_SubcontractBOQId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine",
                column: "SubcontractBOQId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntryTemplateLine_WBSId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine",
                column: "WBSId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntryLine_ActivityId",
                schema: "Accounting",
                table: "JournalEntryLine",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntryLine_BOQLineId",
                schema: "Accounting",
                table: "JournalEntryLine",
                column: "BOQLineId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntryLine_CostCodeId",
                schema: "Accounting",
                table: "JournalEntryLine",
                column: "CostCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntryLine_ProductionOrderId",
                schema: "Accounting",
                table: "JournalEntryLine",
                column: "ProductionOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntryLine_SubcontractBOQId",
                schema: "Accounting",
                table: "JournalEntryLine",
                column: "SubcontractBOQId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntryLine_WBSId",
                schema: "Accounting",
                table: "JournalEntryLine",
                column: "WBSId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceiptLine_ActivityId",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceiptLine_BOQLineId",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                column: "BOQLineId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceiptLine_CostCodeId",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                column: "CostCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceiptLine_ProductionOrderId",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                column: "ProductionOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceiptLine_SubcontractBOQId",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                column: "SubcontractBOQId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceiptLine_WBSId",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                column: "WBSId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntryLine_Activity_ActivityId",
                schema: "Accounting",
                table: "JournalEntryLine",
                column: "ActivityId",
                principalSchema: "Contracting",
                principalTable: "Activity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntryLine_BOQLine_BOQLineId",
                schema: "Accounting",
                table: "JournalEntryLine",
                column: "BOQLineId",
                principalSchema: "Contracting",
                principalTable: "BOQLine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntryLine_CostCode_CostCodeId",
                schema: "Accounting",
                table: "JournalEntryLine",
                column: "CostCodeId",
                principalSchema: "Contracting",
                principalTable: "CostCode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntryLine_ProductionOrder_ProductionOrderId",
                schema: "Accounting",
                table: "JournalEntryLine",
                column: "ProductionOrderId",
                principalSchema: "Manufacturing",
                principalTable: "ProductionOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntryLine_SubcontractBOQ_SubcontractBOQId",
                schema: "Accounting",
                table: "JournalEntryLine",
                column: "SubcontractBOQId",
                principalSchema: "Contracting",
                principalTable: "SubcontractBOQ",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntryLine_WBS_WBSId",
                schema: "Accounting",
                table: "JournalEntryLine",
                column: "WBSId",
                principalSchema: "Contracting",
                principalTable: "WBS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntryTemplateLine_Activity_ActivityId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine",
                column: "ActivityId",
                principalSchema: "Contracting",
                principalTable: "Activity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntryTemplateLine_BOQLine_BOQLineId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine",
                column: "BOQLineId",
                principalSchema: "Contracting",
                principalTable: "BOQLine",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntryTemplateLine_CostCode_CostCodeId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine",
                column: "CostCodeId",
                principalSchema: "Contracting",
                principalTable: "CostCode",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntryTemplateLine_ProductionOrder_ProductionOrderId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine",
                column: "ProductionOrderId",
                principalSchema: "Manufacturing",
                principalTable: "ProductionOrder",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntryTemplateLine_SubcontractBOQ_SubcontractBOQId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine",
                column: "SubcontractBOQId",
                principalSchema: "Contracting",
                principalTable: "SubcontractBOQ",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntryTemplateLine_WBS_WBSId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine",
                column: "WBSId",
                principalSchema: "Contracting",
                principalTable: "WBS",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntryLine_Activity_ActivityId",
                schema: "Accounting",
                table: "JournalEntryLine");

            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntryLine_BOQLine_BOQLineId",
                schema: "Accounting",
                table: "JournalEntryLine");

            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntryLine_CostCode_CostCodeId",
                schema: "Accounting",
                table: "JournalEntryLine");

            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntryLine_ProductionOrder_ProductionOrderId",
                schema: "Accounting",
                table: "JournalEntryLine");

            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntryLine_SubcontractBOQ_SubcontractBOQId",
                schema: "Accounting",
                table: "JournalEntryLine");

            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntryLine_WBS_WBSId",
                schema: "Accounting",
                table: "JournalEntryLine");

            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntryTemplateLine_Activity_ActivityId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine");

            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntryTemplateLine_BOQLine_BOQLineId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine");

            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntryTemplateLine_CostCode_CostCodeId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine");

            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntryTemplateLine_ProductionOrder_ProductionOrderId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine");

            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntryTemplateLine_SubcontractBOQ_SubcontractBOQId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine");

            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntryTemplateLine_WBS_WBSId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine");

            migrationBuilder.DropIndex(
                name: "IX_JournalEntryTemplateLine_ActivityId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine");

            migrationBuilder.DropIndex(
                name: "IX_JournalEntryTemplateLine_BOQLineId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine");

            migrationBuilder.DropIndex(
                name: "IX_JournalEntryTemplateLine_CostCodeId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine");

            migrationBuilder.DropIndex(
                name: "IX_JournalEntryTemplateLine_ProductionOrderId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine");

            migrationBuilder.DropIndex(
                name: "IX_JournalEntryTemplateLine_SubcontractBOQId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine");

            migrationBuilder.DropIndex(
                name: "IX_JournalEntryTemplateLine_WBSId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine");

            migrationBuilder.DropIndex(
                name: "IX_JournalEntryLine_ActivityId",
                schema: "Accounting",
                table: "JournalEntryLine");

            migrationBuilder.DropIndex(
                name: "IX_JournalEntryLine_BOQLineId",
                schema: "Accounting",
                table: "JournalEntryLine");

            migrationBuilder.DropIndex(
                name: "IX_JournalEntryLine_CostCodeId",
                schema: "Accounting",
                table: "JournalEntryLine");

            migrationBuilder.DropIndex(
                name: "IX_JournalEntryLine_ProductionOrderId",
                schema: "Accounting",
                table: "JournalEntryLine");

            migrationBuilder.DropIndex(
                name: "IX_JournalEntryLine_SubcontractBOQId",
                schema: "Accounting",
                table: "JournalEntryLine");

            migrationBuilder.DropIndex(
                name: "IX_JournalEntryLine_WBSId",
                schema: "Accounting",
                table: "JournalEntryLine");

            migrationBuilder.DropIndex(
                name: "IX_GoodsReceiptLine_ActivityId",
                schema: "Inventory",
                table: "GoodsReceiptLine");

            migrationBuilder.DropIndex(
                name: "IX_GoodsReceiptLine_BOQLineId",
                schema: "Inventory",
                table: "GoodsReceiptLine");

            migrationBuilder.DropIndex(
                name: "IX_GoodsReceiptLine_CostCodeId",
                schema: "Inventory",
                table: "GoodsReceiptLine");

            migrationBuilder.DropIndex(
                name: "IX_GoodsReceiptLine_ProductionOrderId",
                schema: "Inventory",
                table: "GoodsReceiptLine");

            migrationBuilder.DropIndex(
                name: "IX_GoodsReceiptLine_SubcontractBOQId",
                schema: "Inventory",
                table: "GoodsReceiptLine");

            migrationBuilder.DropIndex(
                name: "IX_GoodsReceiptLine_WBSId",
                schema: "Inventory",
                table: "GoodsReceiptLine");

            migrationBuilder.RenameColumn(
                name: "BOQLineId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine",
                newName: "BOQItemId");

            migrationBuilder.RenameColumn(
                name: "BOQLineId",
                schema: "Accounting",
                table: "JournalEntryLine",
                newName: "BOQItemId");

            migrationBuilder.RenameColumn(
                name: "BOQLineId",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                newName: "BOQItemId");
        }
    }
}
