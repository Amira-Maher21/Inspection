using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreditNoteLineFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BOQItemId",
                schema: "Accounting",
                table: "CreditNoteLine",
                newName: "BOQLineId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditNoteLine_ActivityId",
                schema: "Accounting",
                table: "CreditNoteLine",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditNoteLine_BOQLineId",
                schema: "Accounting",
                table: "CreditNoteLine",
                column: "BOQLineId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditNoteLine_CostCodeId",
                schema: "Accounting",
                table: "CreditNoteLine",
                column: "CostCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditNoteLine_ProductionOrderId",
                schema: "Accounting",
                table: "CreditNoteLine",
                column: "ProductionOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditNoteLine_SubcontractBOQId",
                schema: "Accounting",
                table: "CreditNoteLine",
                column: "SubcontractBOQId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditNoteLine_WBSId",
                schema: "Accounting",
                table: "CreditNoteLine",
                column: "WBSId");

            migrationBuilder.AddForeignKey(
                name: "FK_CreditNoteLine_Activity_ActivityId",
                schema: "Accounting",
                table: "CreditNoteLine",
                column: "ActivityId",
                principalSchema: "Contracting",
                principalTable: "Activity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CreditNoteLine_BOQLine_BOQLineId",
                schema: "Accounting",
                table: "CreditNoteLine",
                column: "BOQLineId",
                principalSchema: "Contracting",
                principalTable: "BOQLine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CreditNoteLine_CostCode_CostCodeId",
                schema: "Accounting",
                table: "CreditNoteLine",
                column: "CostCodeId",
                principalSchema: "Contracting",
                principalTable: "CostCode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CreditNoteLine_ProductionOrder_ProductionOrderId",
                schema: "Accounting",
                table: "CreditNoteLine",
                column: "ProductionOrderId",
                principalSchema: "Manufacturing",
                principalTable: "ProductionOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CreditNoteLine_SubcontractBOQ_SubcontractBOQId",
                schema: "Accounting",
                table: "CreditNoteLine",
                column: "SubcontractBOQId",
                principalSchema: "Contracting",
                principalTable: "SubcontractBOQ",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CreditNoteLine_WBS_WBSId",
                schema: "Accounting",
                table: "CreditNoteLine",
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
                name: "FK_CreditNoteLine_Activity_ActivityId",
                schema: "Accounting",
                table: "CreditNoteLine");

            migrationBuilder.DropForeignKey(
                name: "FK_CreditNoteLine_BOQLine_BOQLineId",
                schema: "Accounting",
                table: "CreditNoteLine");

            migrationBuilder.DropForeignKey(
                name: "FK_CreditNoteLine_CostCode_CostCodeId",
                schema: "Accounting",
                table: "CreditNoteLine");

            migrationBuilder.DropForeignKey(
                name: "FK_CreditNoteLine_ProductionOrder_ProductionOrderId",
                schema: "Accounting",
                table: "CreditNoteLine");

            migrationBuilder.DropForeignKey(
                name: "FK_CreditNoteLine_SubcontractBOQ_SubcontractBOQId",
                schema: "Accounting",
                table: "CreditNoteLine");

            migrationBuilder.DropForeignKey(
                name: "FK_CreditNoteLine_WBS_WBSId",
                schema: "Accounting",
                table: "CreditNoteLine");

            migrationBuilder.DropIndex(
                name: "IX_CreditNoteLine_ActivityId",
                schema: "Accounting",
                table: "CreditNoteLine");

            migrationBuilder.DropIndex(
                name: "IX_CreditNoteLine_BOQLineId",
                schema: "Accounting",
                table: "CreditNoteLine");

            migrationBuilder.DropIndex(
                name: "IX_CreditNoteLine_CostCodeId",
                schema: "Accounting",
                table: "CreditNoteLine");

            migrationBuilder.DropIndex(
                name: "IX_CreditNoteLine_ProductionOrderId",
                schema: "Accounting",
                table: "CreditNoteLine");

            migrationBuilder.DropIndex(
                name: "IX_CreditNoteLine_SubcontractBOQId",
                schema: "Accounting",
                table: "CreditNoteLine");

            migrationBuilder.DropIndex(
                name: "IX_CreditNoteLine_WBSId",
                schema: "Accounting",
                table: "CreditNoteLine");

            migrationBuilder.RenameColumn(
                name: "BOQLineId",
                schema: "Accounting",
                table: "CreditNoteLine",
                newName: "BOQItemId");
        }
    }
}
