using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DebitNoteAdjustmentFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BOQItemId",
                schema: "Accounting",
                table: "DebitNoteAdjustment",
                newName: "BOQLineId");

            migrationBuilder.CreateIndex(
                name: "IX_DebitNoteAdjustment_ActivityId",
                schema: "Accounting",
                table: "DebitNoteAdjustment",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_DebitNoteAdjustment_BOQLineId",
                schema: "Accounting",
                table: "DebitNoteAdjustment",
                column: "BOQLineId");

            migrationBuilder.CreateIndex(
                name: "IX_DebitNoteAdjustment_CostCodeId",
                schema: "Accounting",
                table: "DebitNoteAdjustment",
                column: "CostCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_DebitNoteAdjustment_ProductionOrderId",
                schema: "Accounting",
                table: "DebitNoteAdjustment",
                column: "ProductionOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_DebitNoteAdjustment_SubcontractBOQId",
                schema: "Accounting",
                table: "DebitNoteAdjustment",
                column: "SubcontractBOQId");

            migrationBuilder.CreateIndex(
                name: "IX_DebitNoteAdjustment_WBSId",
                schema: "Accounting",
                table: "DebitNoteAdjustment",
                column: "WBSId");

            migrationBuilder.AddForeignKey(
                name: "FK_DebitNoteAdjustment_Activity_ActivityId",
                schema: "Accounting",
                table: "DebitNoteAdjustment",
                column: "ActivityId",
                principalSchema: "Contracting",
                principalTable: "Activity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DebitNoteAdjustment_BOQLine_BOQLineId",
                schema: "Accounting",
                table: "DebitNoteAdjustment",
                column: "BOQLineId",
                principalSchema: "Contracting",
                principalTable: "BOQLine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DebitNoteAdjustment_CostCode_CostCodeId",
                schema: "Accounting",
                table: "DebitNoteAdjustment",
                column: "CostCodeId",
                principalSchema: "Contracting",
                principalTable: "CostCode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DebitNoteAdjustment_ProductionOrder_ProductionOrderId",
                schema: "Accounting",
                table: "DebitNoteAdjustment",
                column: "ProductionOrderId",
                principalSchema: "Manufacturing",
                principalTable: "ProductionOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DebitNoteAdjustment_SubcontractBOQ_SubcontractBOQId",
                schema: "Accounting",
                table: "DebitNoteAdjustment",
                column: "SubcontractBOQId",
                principalSchema: "Contracting",
                principalTable: "SubcontractBOQ",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DebitNoteAdjustment_WBS_WBSId",
                schema: "Accounting",
                table: "DebitNoteAdjustment",
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
                name: "FK_DebitNoteAdjustment_Activity_ActivityId",
                schema: "Accounting",
                table: "DebitNoteAdjustment");

            migrationBuilder.DropForeignKey(
                name: "FK_DebitNoteAdjustment_BOQLine_BOQLineId",
                schema: "Accounting",
                table: "DebitNoteAdjustment");

            migrationBuilder.DropForeignKey(
                name: "FK_DebitNoteAdjustment_CostCode_CostCodeId",
                schema: "Accounting",
                table: "DebitNoteAdjustment");

            migrationBuilder.DropForeignKey(
                name: "FK_DebitNoteAdjustment_ProductionOrder_ProductionOrderId",
                schema: "Accounting",
                table: "DebitNoteAdjustment");

            migrationBuilder.DropForeignKey(
                name: "FK_DebitNoteAdjustment_SubcontractBOQ_SubcontractBOQId",
                schema: "Accounting",
                table: "DebitNoteAdjustment");

            migrationBuilder.DropForeignKey(
                name: "FK_DebitNoteAdjustment_WBS_WBSId",
                schema: "Accounting",
                table: "DebitNoteAdjustment");

            migrationBuilder.DropIndex(
                name: "IX_DebitNoteAdjustment_ActivityId",
                schema: "Accounting",
                table: "DebitNoteAdjustment");

            migrationBuilder.DropIndex(
                name: "IX_DebitNoteAdjustment_BOQLineId",
                schema: "Accounting",
                table: "DebitNoteAdjustment");

            migrationBuilder.DropIndex(
                name: "IX_DebitNoteAdjustment_CostCodeId",
                schema: "Accounting",
                table: "DebitNoteAdjustment");

            migrationBuilder.DropIndex(
                name: "IX_DebitNoteAdjustment_ProductionOrderId",
                schema: "Accounting",
                table: "DebitNoteAdjustment");

            migrationBuilder.DropIndex(
                name: "IX_DebitNoteAdjustment_SubcontractBOQId",
                schema: "Accounting",
                table: "DebitNoteAdjustment");

            migrationBuilder.DropIndex(
                name: "IX_DebitNoteAdjustment_WBSId",
                schema: "Accounting",
                table: "DebitNoteAdjustment");

            migrationBuilder.RenameColumn(
                name: "BOQLineId",
                schema: "Accounting",
                table: "DebitNoteAdjustment",
                newName: "BOQItemId");
        }
    }
}
