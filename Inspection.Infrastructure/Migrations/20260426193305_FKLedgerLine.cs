using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FKLedgerLine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BOQItemId",
                schema: "Accounting",
                table: "LedgerLine",
                newName: "BOQLineId");

            migrationBuilder.CreateIndex(
                name: "IX_LedgerLine_ActivityId",
                schema: "Accounting",
                table: "LedgerLine",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_LedgerLine_BOQLineId",
                schema: "Accounting",
                table: "LedgerLine",
                column: "BOQLineId");

            migrationBuilder.CreateIndex(
                name: "IX_LedgerLine_CostCodeId",
                schema: "Accounting",
                table: "LedgerLine",
                column: "CostCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_LedgerLine_ProductionOrderId",
                schema: "Accounting",
                table: "LedgerLine",
                column: "ProductionOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_LedgerLine_SubcontractBOQId",
                schema: "Accounting",
                table: "LedgerLine",
                column: "SubcontractBOQId");

            migrationBuilder.CreateIndex(
                name: "IX_LedgerLine_WBSId",
                schema: "Accounting",
                table: "LedgerLine",
                column: "WBSId");

            migrationBuilder.AddForeignKey(
                name: "FK_LedgerLine_Activity_ActivityId",
                schema: "Accounting",
                table: "LedgerLine",
                column: "ActivityId",
                principalSchema: "Contracting",
                principalTable: "Activity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LedgerLine_BOQLine_BOQLineId",
                schema: "Accounting",
                table: "LedgerLine",
                column: "BOQLineId",
                principalSchema: "Contracting",
                principalTable: "BOQLine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LedgerLine_CostCode_CostCodeId",
                schema: "Accounting",
                table: "LedgerLine",
                column: "CostCodeId",
                principalSchema: "Contracting",
                principalTable: "CostCode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LedgerLine_ProductionOrder_ProductionOrderId",
                schema: "Accounting",
                table: "LedgerLine",
                column: "ProductionOrderId",
                principalSchema: "Manufacturing",
                principalTable: "ProductionOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LedgerLine_SubcontractBOQ_SubcontractBOQId",
                schema: "Accounting",
                table: "LedgerLine",
                column: "SubcontractBOQId",
                principalSchema: "Contracting",
                principalTable: "SubcontractBOQ",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LedgerLine_WBS_WBSId",
                schema: "Accounting",
                table: "LedgerLine",
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
                name: "FK_LedgerLine_Activity_ActivityId",
                schema: "Accounting",
                table: "LedgerLine");

            migrationBuilder.DropForeignKey(
                name: "FK_LedgerLine_BOQLine_BOQLineId",
                schema: "Accounting",
                table: "LedgerLine");

            migrationBuilder.DropForeignKey(
                name: "FK_LedgerLine_CostCode_CostCodeId",
                schema: "Accounting",
                table: "LedgerLine");

            migrationBuilder.DropForeignKey(
                name: "FK_LedgerLine_ProductionOrder_ProductionOrderId",
                schema: "Accounting",
                table: "LedgerLine");

            migrationBuilder.DropForeignKey(
                name: "FK_LedgerLine_SubcontractBOQ_SubcontractBOQId",
                schema: "Accounting",
                table: "LedgerLine");

            migrationBuilder.DropForeignKey(
                name: "FK_LedgerLine_WBS_WBSId",
                schema: "Accounting",
                table: "LedgerLine");

            migrationBuilder.DropIndex(
                name: "IX_LedgerLine_ActivityId",
                schema: "Accounting",
                table: "LedgerLine");

            migrationBuilder.DropIndex(
                name: "IX_LedgerLine_BOQLineId",
                schema: "Accounting",
                table: "LedgerLine");

            migrationBuilder.DropIndex(
                name: "IX_LedgerLine_CostCodeId",
                schema: "Accounting",
                table: "LedgerLine");

            migrationBuilder.DropIndex(
                name: "IX_LedgerLine_ProductionOrderId",
                schema: "Accounting",
                table: "LedgerLine");

            migrationBuilder.DropIndex(
                name: "IX_LedgerLine_SubcontractBOQId",
                schema: "Accounting",
                table: "LedgerLine");

            migrationBuilder.DropIndex(
                name: "IX_LedgerLine_WBSId",
                schema: "Accounting",
                table: "LedgerLine");

            migrationBuilder.RenameColumn(
                name: "BOQLineId",
                schema: "Accounting",
                table: "LedgerLine",
                newName: "BOQItemId");
        }
    }
}
