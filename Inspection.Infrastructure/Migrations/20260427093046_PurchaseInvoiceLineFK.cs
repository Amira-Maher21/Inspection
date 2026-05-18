using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PurchaseInvoiceLineFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                schema: "Contracting",
                table: "WBS");

            //migrationBuilder.DropColumn(
            //    name: "Code",
            //    schema: "Accounting",
            //    table: "AssetCategory");

            migrationBuilder.RenameColumn(
                name: "BOQItemId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                newName: "BOQLineId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceLine_ActivityId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceLine_BOQLineId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                column: "BOQLineId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceLine_CostCodeId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                column: "CostCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceLine_ProductionOrderId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                column: "ProductionOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceLine_SubcontractBOQId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                column: "SubcontractBOQId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceLine_WBSId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                column: "WBSId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseInvoiceLine_Activity_ActivityId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                column: "ActivityId",
                principalSchema: "Contracting",
                principalTable: "Activity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseInvoiceLine_BOQLine_BOQLineId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                column: "BOQLineId",
                principalSchema: "Contracting",
                principalTable: "BOQLine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseInvoiceLine_CostCode_CostCodeId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                column: "CostCodeId",
                principalSchema: "Contracting",
                principalTable: "CostCode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseInvoiceLine_ProductionOrder_ProductionOrderId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                column: "ProductionOrderId",
                principalSchema: "Manufacturing",
                principalTable: "ProductionOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseInvoiceLine_SubcontractBOQ_SubcontractBOQId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                column: "SubcontractBOQId",
                principalSchema: "Contracting",
                principalTable: "SubcontractBOQ",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseInvoiceLine_WBS_WBSId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
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
                name: "FK_PurchaseInvoiceLine_Activity_ActivityId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseInvoiceLine_BOQLine_BOQLineId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseInvoiceLine_CostCode_CostCodeId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseInvoiceLine_ProductionOrder_ProductionOrderId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseInvoiceLine_SubcontractBOQ_SubcontractBOQId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseInvoiceLine_WBS_WBSId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseInvoiceLine_ActivityId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseInvoiceLine_BOQLineId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseInvoiceLine_CostCodeId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseInvoiceLine_ProductionOrderId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseInvoiceLine_SubcontractBOQId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseInvoiceLine_WBSId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.RenameColumn(
                name: "BOQLineId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                newName: "BOQItemId");

            migrationBuilder.AddColumn<byte>(
                name: "Status",
                schema: "Contracting",
                table: "WBS",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            //migrationBuilder.AddColumn<string>(
            //    name: "Code",
            //    schema: "Accounting",
            //    table: "AssetCategory",
            //    type: "nvarchar(50)",
            //    maxLength: 50,
            //    nullable: false,
            //    defaultValue: "");
        }
    }
}
