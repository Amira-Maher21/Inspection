using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreditNoteAdjustmentFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BOQItemId",
                schema: "Accounting",
                table: "CreditNoteAdjustment",
                newName: "BOQLineId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditNoteAdjustment_ActivityId",
                schema: "Accounting",
                table: "CreditNoteAdjustment",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditNoteAdjustment_BOQLineId",
                schema: "Accounting",
                table: "CreditNoteAdjustment",
                column: "BOQLineId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditNoteAdjustment_CostCodeId",
                schema: "Accounting",
                table: "CreditNoteAdjustment",
                column: "CostCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditNoteAdjustment_ProductionOrderId",
                schema: "Accounting",
                table: "CreditNoteAdjustment",
                column: "ProductionOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditNoteAdjustment_SubcontractBOQId",
                schema: "Accounting",
                table: "CreditNoteAdjustment",
                column: "SubcontractBOQId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditNoteAdjustment_WBSId",
                schema: "Accounting",
                table: "CreditNoteAdjustment",
                column: "WBSId");

            migrationBuilder.AddForeignKey(
                name: "FK_CreditNoteAdjustment_Activity_ActivityId",
                schema: "Accounting",
                table: "CreditNoteAdjustment",
                column: "ActivityId",
                principalSchema: "Contracting",
                principalTable: "Activity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CreditNoteAdjustment_BOQLine_BOQLineId",
                schema: "Accounting",
                table: "CreditNoteAdjustment",
                column: "BOQLineId",
                principalSchema: "Contracting",
                principalTable: "BOQLine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CreditNoteAdjustment_CostCode_CostCodeId",
                schema: "Accounting",
                table: "CreditNoteAdjustment",
                column: "CostCodeId",
                principalSchema: "Contracting",
                principalTable: "CostCode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CreditNoteAdjustment_ProductionOrder_ProductionOrderId",
                schema: "Accounting",
                table: "CreditNoteAdjustment",
                column: "ProductionOrderId",
                principalSchema: "Manufacturing",
                principalTable: "ProductionOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CreditNoteAdjustment_SubcontractBOQ_SubcontractBOQId",
                schema: "Accounting",
                table: "CreditNoteAdjustment",
                column: "SubcontractBOQId",
                principalSchema: "Contracting",
                principalTable: "SubcontractBOQ",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CreditNoteAdjustment_WBS_WBSId",
                schema: "Accounting",
                table: "CreditNoteAdjustment",
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
                name: "FK_CreditNoteAdjustment_Activity_ActivityId",
                schema: "Accounting",
                table: "CreditNoteAdjustment");

            migrationBuilder.DropForeignKey(
                name: "FK_CreditNoteAdjustment_BOQLine_BOQLineId",
                schema: "Accounting",
                table: "CreditNoteAdjustment");

            migrationBuilder.DropForeignKey(
                name: "FK_CreditNoteAdjustment_CostCode_CostCodeId",
                schema: "Accounting",
                table: "CreditNoteAdjustment");

            migrationBuilder.DropForeignKey(
                name: "FK_CreditNoteAdjustment_ProductionOrder_ProductionOrderId",
                schema: "Accounting",
                table: "CreditNoteAdjustment");

            migrationBuilder.DropForeignKey(
                name: "FK_CreditNoteAdjustment_SubcontractBOQ_SubcontractBOQId",
                schema: "Accounting",
                table: "CreditNoteAdjustment");

            migrationBuilder.DropForeignKey(
                name: "FK_CreditNoteAdjustment_WBS_WBSId",
                schema: "Accounting",
                table: "CreditNoteAdjustment");

            migrationBuilder.DropIndex(
                name: "IX_CreditNoteAdjustment_ActivityId",
                schema: "Accounting",
                table: "CreditNoteAdjustment");

            migrationBuilder.DropIndex(
                name: "IX_CreditNoteAdjustment_BOQLineId",
                schema: "Accounting",
                table: "CreditNoteAdjustment");

            migrationBuilder.DropIndex(
                name: "IX_CreditNoteAdjustment_CostCodeId",
                schema: "Accounting",
                table: "CreditNoteAdjustment");

            migrationBuilder.DropIndex(
                name: "IX_CreditNoteAdjustment_ProductionOrderId",
                schema: "Accounting",
                table: "CreditNoteAdjustment");

            migrationBuilder.DropIndex(
                name: "IX_CreditNoteAdjustment_SubcontractBOQId",
                schema: "Accounting",
                table: "CreditNoteAdjustment");

            migrationBuilder.DropIndex(
                name: "IX_CreditNoteAdjustment_WBSId",
                schema: "Accounting",
                table: "CreditNoteAdjustment");

            migrationBuilder.RenameColumn(
                name: "BOQLineId",
                schema: "Accounting",
                table: "CreditNoteAdjustment",
                newName: "BOQItemId");
        }
    }
}
