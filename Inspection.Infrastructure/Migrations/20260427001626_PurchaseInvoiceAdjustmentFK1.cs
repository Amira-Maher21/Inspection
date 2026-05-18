using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PurchaseInvoiceAdjustmentFK1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "Activity",
                schema: "Accounting",
                table: "PurchaseInvoiceAdjustment");

            migrationBuilder.RenameColumn(
                name: "BOQItemId",
                schema: "Accounting",
                table: "PurchaseInvoiceAdjustment",
                newName: "BOQLineId");

            migrationBuilder.AddColumn<long>(
                name: "ActivityId",
                schema: "Accounting",
                table: "PurchaseInvoiceAdjustment",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceAdjustment_ActivityId",
                schema: "Accounting",
                table: "PurchaseInvoiceAdjustment",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceAdjustment_BOQLineId",
                schema: "Accounting",
                table: "PurchaseInvoiceAdjustment",
                column: "BOQLineId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceAdjustment_CostCodeId",
                schema: "Accounting",
                table: "PurchaseInvoiceAdjustment",
                column: "CostCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceAdjustment_ProductionOrderId",
                schema: "Accounting",
                table: "PurchaseInvoiceAdjustment",
                column: "ProductionOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceAdjustment_SubcontractBOQId",
                schema: "Accounting",
                table: "PurchaseInvoiceAdjustment",
                column: "SubcontractBOQId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceAdjustment_WBSId",
                schema: "Accounting",
                table: "PurchaseInvoiceAdjustment",
                column: "WBSId");

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntryTemplateLine_Activity_ActivityId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine",
                column: "ActivityId",
                principalSchema: "Contracting",
                principalTable: "Activity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntryTemplateLine_BOQLine_BOQLineId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine",
                column: "BOQLineId",
                principalSchema: "Contracting",
                principalTable: "BOQLine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntryTemplateLine_CostCode_CostCodeId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine",
                column: "CostCodeId",
                principalSchema: "Contracting",
                principalTable: "CostCode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntryTemplateLine_ProductionOrder_ProductionOrderId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine",
                column: "ProductionOrderId",
                principalSchema: "Manufacturing",
                principalTable: "ProductionOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntryTemplateLine_SubcontractBOQ_SubcontractBOQId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine",
                column: "SubcontractBOQId",
                principalSchema: "Contracting",
                principalTable: "SubcontractBOQ",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntryTemplateLine_WBS_WBSId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine",
                column: "WBSId",
                principalSchema: "Contracting",
                principalTable: "WBS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseInvoiceAdjustment_Activity_ActivityId",
                schema: "Accounting",
                table: "PurchaseInvoiceAdjustment",
                column: "ActivityId",
                principalSchema: "Contracting",
                principalTable: "Activity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseInvoiceAdjustment_BOQLine_BOQLineId",
                schema: "Accounting",
                table: "PurchaseInvoiceAdjustment",
                column: "BOQLineId",
                principalSchema: "Contracting",
                principalTable: "BOQLine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseInvoiceAdjustment_CostCode_CostCodeId",
                schema: "Accounting",
                table: "PurchaseInvoiceAdjustment",
                column: "CostCodeId",
                principalSchema: "Contracting",
                principalTable: "CostCode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseInvoiceAdjustment_ProductionOrder_ProductionOrderId",
                schema: "Accounting",
                table: "PurchaseInvoiceAdjustment",
                column: "ProductionOrderId",
                principalSchema: "Manufacturing",
                principalTable: "ProductionOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseInvoiceAdjustment_SubcontractBOQ_SubcontractBOQId",
                schema: "Accounting",
                table: "PurchaseInvoiceAdjustment",
                column: "SubcontractBOQId",
                principalSchema: "Contracting",
                principalTable: "SubcontractBOQ",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseInvoiceAdjustment_WBS_WBSId",
                schema: "Accounting",
                table: "PurchaseInvoiceAdjustment",
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

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseInvoiceAdjustment_Activity_ActivityId",
                schema: "Accounting",
                table: "PurchaseInvoiceAdjustment");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseInvoiceAdjustment_BOQLine_BOQLineId",
                schema: "Accounting",
                table: "PurchaseInvoiceAdjustment");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseInvoiceAdjustment_CostCode_CostCodeId",
                schema: "Accounting",
                table: "PurchaseInvoiceAdjustment");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseInvoiceAdjustment_ProductionOrder_ProductionOrderId",
                schema: "Accounting",
                table: "PurchaseInvoiceAdjustment");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseInvoiceAdjustment_SubcontractBOQ_SubcontractBOQId",
                schema: "Accounting",
                table: "PurchaseInvoiceAdjustment");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseInvoiceAdjustment_WBS_WBSId",
                schema: "Accounting",
                table: "PurchaseInvoiceAdjustment");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseInvoiceAdjustment_ActivityId",
                schema: "Accounting",
                table: "PurchaseInvoiceAdjustment");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseInvoiceAdjustment_BOQLineId",
                schema: "Accounting",
                table: "PurchaseInvoiceAdjustment");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseInvoiceAdjustment_CostCodeId",
                schema: "Accounting",
                table: "PurchaseInvoiceAdjustment");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseInvoiceAdjustment_ProductionOrderId",
                schema: "Accounting",
                table: "PurchaseInvoiceAdjustment");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseInvoiceAdjustment_SubcontractBOQId",
                schema: "Accounting",
                table: "PurchaseInvoiceAdjustment");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseInvoiceAdjustment_WBSId",
                schema: "Accounting",
                table: "PurchaseInvoiceAdjustment");

            migrationBuilder.DropColumn(
                name: "ActivityId",
                schema: "Accounting",
                table: "PurchaseInvoiceAdjustment");

            migrationBuilder.RenameColumn(
                name: "BOQLineId",
                schema: "Accounting",
                table: "PurchaseInvoiceAdjustment",
                newName: "BOQItemId");

            migrationBuilder.AddColumn<bool>(
                name: "Activity",
                schema: "Accounting",
                table: "PurchaseInvoiceAdjustment",
                type: "bit",
                nullable: true);

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
    }
}
