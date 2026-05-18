using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CashPaymentLinefK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BOQItemId",
                schema: "Sales",
                table: "SalesReturnLine",
                newName: "BOQLineId");

            migrationBuilder.RenameColumn(
                name: "BOQItemId",
                schema: "Inventory",
                table: "GoodsTransferOutLine",
                newName: "BOQLineId");

            migrationBuilder.RenameColumn(
                name: "BOQItemId",
                schema: "Accounting",
                table: "CashPaymentLine",
                newName: "BOQLineId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnLine_ActivityId",
                schema: "Sales",
                table: "SalesReturnLine",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnLine_BOQLineId",
                schema: "Sales",
                table: "SalesReturnLine",
                column: "BOQLineId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnLine_CostCodeId",
                schema: "Sales",
                table: "SalesReturnLine",
                column: "CostCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnLine_ProductionOrderId",
                schema: "Sales",
                table: "SalesReturnLine",
                column: "ProductionOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnLine_SubcontractBOQId",
                schema: "Sales",
                table: "SalesReturnLine",
                column: "SubcontractBOQId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnLine_WBSId",
                schema: "Sales",
                table: "SalesReturnLine",
                column: "WBSId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsTransferOutLine_ActivityId",
                schema: "Inventory",
                table: "GoodsTransferOutLine",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsTransferOutLine_BOQLineId",
                schema: "Inventory",
                table: "GoodsTransferOutLine",
                column: "BOQLineId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsTransferOutLine_CostCodeId",
                schema: "Inventory",
                table: "GoodsTransferOutLine",
                column: "CostCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsTransferOutLine_ProductionOrderId",
                schema: "Inventory",
                table: "GoodsTransferOutLine",
                column: "ProductionOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsTransferOutLine_SubcontractBOQId",
                schema: "Inventory",
                table: "GoodsTransferOutLine",
                column: "SubcontractBOQId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsTransferOutLine_WBSId",
                schema: "Inventory",
                table: "GoodsTransferOutLine",
                column: "WBSId");

            migrationBuilder.CreateIndex(
                name: "IX_CashPaymentLine_ActivityId",
                schema: "Accounting",
                table: "CashPaymentLine",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_CashPaymentLine_BOQLineId",
                schema: "Accounting",
                table: "CashPaymentLine",
                column: "BOQLineId");

            migrationBuilder.CreateIndex(
                name: "IX_CashPaymentLine_CostCodeId",
                schema: "Accounting",
                table: "CashPaymentLine",
                column: "CostCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_CashPaymentLine_ProductionOrderId",
                schema: "Accounting",
                table: "CashPaymentLine",
                column: "ProductionOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_CashPaymentLine_SubcontractBOQId",
                schema: "Accounting",
                table: "CashPaymentLine",
                column: "SubcontractBOQId");

            migrationBuilder.CreateIndex(
                name: "IX_CashPaymentLine_WBSId",
                schema: "Accounting",
                table: "CashPaymentLine",
                column: "WBSId");

            migrationBuilder.AddForeignKey(
                name: "FK_CashPaymentLine_Activity_ActivityId",
                schema: "Accounting",
                table: "CashPaymentLine",
                column: "ActivityId",
                principalSchema: "Contracting",
                principalTable: "Activity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CashPaymentLine_BOQLine_BOQLineId",
                schema: "Accounting",
                table: "CashPaymentLine",
                column: "BOQLineId",
                principalSchema: "Contracting",
                principalTable: "BOQLine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CashPaymentLine_CostCode_CostCodeId",
                schema: "Accounting",
                table: "CashPaymentLine",
                column: "CostCodeId",
                principalSchema: "Contracting",
                principalTable: "CostCode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CashPaymentLine_ProductionOrder_ProductionOrderId",
                schema: "Accounting",
                table: "CashPaymentLine",
                column: "ProductionOrderId",
                principalSchema: "Manufacturing",
                principalTable: "ProductionOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CashPaymentLine_SubcontractBOQ_SubcontractBOQId",
                schema: "Accounting",
                table: "CashPaymentLine",
                column: "SubcontractBOQId",
                principalSchema: "Contracting",
                principalTable: "SubcontractBOQ",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CashPaymentLine_WBS_WBSId",
                schema: "Accounting",
                table: "CashPaymentLine",
                column: "WBSId",
                principalSchema: "Contracting",
                principalTable: "WBS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsTransferOutLine_Activity_ActivityId",
                schema: "Inventory",
                table: "GoodsTransferOutLine",
                column: "ActivityId",
                principalSchema: "Contracting",
                principalTable: "Activity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsTransferOutLine_BOQLine_BOQLineId",
                schema: "Inventory",
                table: "GoodsTransferOutLine",
                column: "BOQLineId",
                principalSchema: "Contracting",
                principalTable: "BOQLine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsTransferOutLine_CostCode_CostCodeId",
                schema: "Inventory",
                table: "GoodsTransferOutLine",
                column: "CostCodeId",
                principalSchema: "Contracting",
                principalTable: "CostCode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsTransferOutLine_ProductionOrder_ProductionOrderId",
                schema: "Inventory",
                table: "GoodsTransferOutLine",
                column: "ProductionOrderId",
                principalSchema: "Manufacturing",
                principalTable: "ProductionOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsTransferOutLine_SubcontractBOQ_SubcontractBOQId",
                schema: "Inventory",
                table: "GoodsTransferOutLine",
                column: "SubcontractBOQId",
                principalSchema: "Contracting",
                principalTable: "SubcontractBOQ",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsTransferOutLine_WBS_WBSId",
                schema: "Inventory",
                table: "GoodsTransferOutLine",
                column: "WBSId",
                principalSchema: "Contracting",
                principalTable: "WBS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesReturnLine_Activity_ActivityId",
                schema: "Sales",
                table: "SalesReturnLine",
                column: "ActivityId",
                principalSchema: "Contracting",
                principalTable: "Activity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesReturnLine_BOQLine_BOQLineId",
                schema: "Sales",
                table: "SalesReturnLine",
                column: "BOQLineId",
                principalSchema: "Contracting",
                principalTable: "BOQLine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesReturnLine_CostCode_CostCodeId",
                schema: "Sales",
                table: "SalesReturnLine",
                column: "CostCodeId",
                principalSchema: "Contracting",
                principalTable: "CostCode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesReturnLine_ProductionOrder_ProductionOrderId",
                schema: "Sales",
                table: "SalesReturnLine",
                column: "ProductionOrderId",
                principalSchema: "Manufacturing",
                principalTable: "ProductionOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesReturnLine_SubcontractBOQ_SubcontractBOQId",
                schema: "Sales",
                table: "SalesReturnLine",
                column: "SubcontractBOQId",
                principalSchema: "Contracting",
                principalTable: "SubcontractBOQ",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesReturnLine_WBS_WBSId",
                schema: "Sales",
                table: "SalesReturnLine",
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
                name: "FK_CashPaymentLine_Activity_ActivityId",
                schema: "Accounting",
                table: "CashPaymentLine");

            migrationBuilder.DropForeignKey(
                name: "FK_CashPaymentLine_BOQLine_BOQLineId",
                schema: "Accounting",
                table: "CashPaymentLine");

            migrationBuilder.DropForeignKey(
                name: "FK_CashPaymentLine_CostCode_CostCodeId",
                schema: "Accounting",
                table: "CashPaymentLine");

            migrationBuilder.DropForeignKey(
                name: "FK_CashPaymentLine_ProductionOrder_ProductionOrderId",
                schema: "Accounting",
                table: "CashPaymentLine");

            migrationBuilder.DropForeignKey(
                name: "FK_CashPaymentLine_SubcontractBOQ_SubcontractBOQId",
                schema: "Accounting",
                table: "CashPaymentLine");

            migrationBuilder.DropForeignKey(
                name: "FK_CashPaymentLine_WBS_WBSId",
                schema: "Accounting",
                table: "CashPaymentLine");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsTransferOutLine_Activity_ActivityId",
                schema: "Inventory",
                table: "GoodsTransferOutLine");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsTransferOutLine_BOQLine_BOQLineId",
                schema: "Inventory",
                table: "GoodsTransferOutLine");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsTransferOutLine_CostCode_CostCodeId",
                schema: "Inventory",
                table: "GoodsTransferOutLine");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsTransferOutLine_ProductionOrder_ProductionOrderId",
                schema: "Inventory",
                table: "GoodsTransferOutLine");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsTransferOutLine_SubcontractBOQ_SubcontractBOQId",
                schema: "Inventory",
                table: "GoodsTransferOutLine");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsTransferOutLine_WBS_WBSId",
                schema: "Inventory",
                table: "GoodsTransferOutLine");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesReturnLine_Activity_ActivityId",
                schema: "Sales",
                table: "SalesReturnLine");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesReturnLine_BOQLine_BOQLineId",
                schema: "Sales",
                table: "SalesReturnLine");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesReturnLine_CostCode_CostCodeId",
                schema: "Sales",
                table: "SalesReturnLine");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesReturnLine_ProductionOrder_ProductionOrderId",
                schema: "Sales",
                table: "SalesReturnLine");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesReturnLine_SubcontractBOQ_SubcontractBOQId",
                schema: "Sales",
                table: "SalesReturnLine");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesReturnLine_WBS_WBSId",
                schema: "Sales",
                table: "SalesReturnLine");

            migrationBuilder.DropIndex(
                name: "IX_SalesReturnLine_ActivityId",
                schema: "Sales",
                table: "SalesReturnLine");

            migrationBuilder.DropIndex(
                name: "IX_SalesReturnLine_BOQLineId",
                schema: "Sales",
                table: "SalesReturnLine");

            migrationBuilder.DropIndex(
                name: "IX_SalesReturnLine_CostCodeId",
                schema: "Sales",
                table: "SalesReturnLine");

            migrationBuilder.DropIndex(
                name: "IX_SalesReturnLine_ProductionOrderId",
                schema: "Sales",
                table: "SalesReturnLine");

            migrationBuilder.DropIndex(
                name: "IX_SalesReturnLine_SubcontractBOQId",
                schema: "Sales",
                table: "SalesReturnLine");

            migrationBuilder.DropIndex(
                name: "IX_SalesReturnLine_WBSId",
                schema: "Sales",
                table: "SalesReturnLine");

            migrationBuilder.DropIndex(
                name: "IX_GoodsTransferOutLine_ActivityId",
                schema: "Inventory",
                table: "GoodsTransferOutLine");

            migrationBuilder.DropIndex(
                name: "IX_GoodsTransferOutLine_BOQLineId",
                schema: "Inventory",
                table: "GoodsTransferOutLine");

            migrationBuilder.DropIndex(
                name: "IX_GoodsTransferOutLine_CostCodeId",
                schema: "Inventory",
                table: "GoodsTransferOutLine");

            migrationBuilder.DropIndex(
                name: "IX_GoodsTransferOutLine_ProductionOrderId",
                schema: "Inventory",
                table: "GoodsTransferOutLine");

            migrationBuilder.DropIndex(
                name: "IX_GoodsTransferOutLine_SubcontractBOQId",
                schema: "Inventory",
                table: "GoodsTransferOutLine");

            migrationBuilder.DropIndex(
                name: "IX_GoodsTransferOutLine_WBSId",
                schema: "Inventory",
                table: "GoodsTransferOutLine");

            migrationBuilder.DropIndex(
                name: "IX_CashPaymentLine_ActivityId",
                schema: "Accounting",
                table: "CashPaymentLine");

            migrationBuilder.DropIndex(
                name: "IX_CashPaymentLine_BOQLineId",
                schema: "Accounting",
                table: "CashPaymentLine");

            migrationBuilder.DropIndex(
                name: "IX_CashPaymentLine_CostCodeId",
                schema: "Accounting",
                table: "CashPaymentLine");

            migrationBuilder.DropIndex(
                name: "IX_CashPaymentLine_ProductionOrderId",
                schema: "Accounting",
                table: "CashPaymentLine");

            migrationBuilder.DropIndex(
                name: "IX_CashPaymentLine_SubcontractBOQId",
                schema: "Accounting",
                table: "CashPaymentLine");

            migrationBuilder.DropIndex(
                name: "IX_CashPaymentLine_WBSId",
                schema: "Accounting",
                table: "CashPaymentLine");

            migrationBuilder.RenameColumn(
                name: "BOQLineId",
                schema: "Sales",
                table: "SalesReturnLine",
                newName: "BOQItemId");

            migrationBuilder.RenameColumn(
                name: "BOQLineId",
                schema: "Inventory",
                table: "GoodsTransferOutLine",
                newName: "BOQItemId");

            migrationBuilder.RenameColumn(
                name: "BOQLineId",
                schema: "Accounting",
                table: "CashPaymentLine",
                newName: "BOQItemId");
        }
    }
}
