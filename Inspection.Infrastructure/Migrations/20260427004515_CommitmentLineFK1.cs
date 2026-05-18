using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CommitmentLineFK1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OperaionId",
                schema: "Contracting",
                table: "CommitmentLine",
                newName: "OperationId");

            migrationBuilder.RenameColumn(
                name: "BOQItemId",
                schema: "Contracting",
                table: "CommitmentLine",
                newName: "BOQLineId");

            migrationBuilder.CreateIndex(
                name: "IX_CommitmentLine_ActivityId",
                schema: "Contracting",
                table: "CommitmentLine",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_CommitmentLine_BOQLineId",
                schema: "Contracting",
                table: "CommitmentLine",
                column: "BOQLineId");

            migrationBuilder.CreateIndex(
                name: "IX_CommitmentLine_CostCodeId",
                schema: "Contracting",
                table: "CommitmentLine",
                column: "CostCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_CommitmentLine_OperationId",
                schema: "Contracting",
                table: "CommitmentLine",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_CommitmentLine_ProductionOrderId",
                schema: "Contracting",
                table: "CommitmentLine",
                column: "ProductionOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_CommitmentLine_SubcontractBOQId",
                schema: "Contracting",
                table: "CommitmentLine",
                column: "SubcontractBOQId");

            migrationBuilder.CreateIndex(
                name: "IX_CommitmentLine_WBSId",
                schema: "Contracting",
                table: "CommitmentLine",
                column: "WBSId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommitmentLine_Activity_ActivityId",
                schema: "Contracting",
                table: "CommitmentLine",
                column: "ActivityId",
                principalSchema: "Contracting",
                principalTable: "Activity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CommitmentLine_BOQLine_BOQLineId",
                schema: "Contracting",
                table: "CommitmentLine",
                column: "BOQLineId",
                principalSchema: "Contracting",
                principalTable: "BOQLine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CommitmentLine_CostCode_CostCodeId",
                schema: "Contracting",
                table: "CommitmentLine",
                column: "CostCodeId",
                principalSchema: "Contracting",
                principalTable: "CostCode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CommitmentLine_Operation_OperationId",
                schema: "Contracting",
                table: "CommitmentLine",
                column: "OperationId",
                principalSchema: "Sec",
                principalTable: "Operation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CommitmentLine_ProductionOrder_ProductionOrderId",
                schema: "Contracting",
                table: "CommitmentLine",
                column: "ProductionOrderId",
                principalSchema: "Manufacturing",
                principalTable: "ProductionOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CommitmentLine_SubcontractBOQ_SubcontractBOQId",
                schema: "Contracting",
                table: "CommitmentLine",
                column: "SubcontractBOQId",
                principalSchema: "Contracting",
                principalTable: "SubcontractBOQ",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CommitmentLine_WBS_WBSId",
                schema: "Contracting",
                table: "CommitmentLine",
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
                name: "FK_CommitmentLine_Activity_ActivityId",
                schema: "Contracting",
                table: "CommitmentLine");

            migrationBuilder.DropForeignKey(
                name: "FK_CommitmentLine_BOQLine_BOQLineId",
                schema: "Contracting",
                table: "CommitmentLine");

            migrationBuilder.DropForeignKey(
                name: "FK_CommitmentLine_CostCode_CostCodeId",
                schema: "Contracting",
                table: "CommitmentLine");

            migrationBuilder.DropForeignKey(
                name: "FK_CommitmentLine_Operation_OperationId",
                schema: "Contracting",
                table: "CommitmentLine");

            migrationBuilder.DropForeignKey(
                name: "FK_CommitmentLine_ProductionOrder_ProductionOrderId",
                schema: "Contracting",
                table: "CommitmentLine");

            migrationBuilder.DropForeignKey(
                name: "FK_CommitmentLine_SubcontractBOQ_SubcontractBOQId",
                schema: "Contracting",
                table: "CommitmentLine");

            migrationBuilder.DropForeignKey(
                name: "FK_CommitmentLine_WBS_WBSId",
                schema: "Contracting",
                table: "CommitmentLine");

            migrationBuilder.DropIndex(
                name: "IX_CommitmentLine_ActivityId",
                schema: "Contracting",
                table: "CommitmentLine");

            migrationBuilder.DropIndex(
                name: "IX_CommitmentLine_BOQLineId",
                schema: "Contracting",
                table: "CommitmentLine");

            migrationBuilder.DropIndex(
                name: "IX_CommitmentLine_CostCodeId",
                schema: "Contracting",
                table: "CommitmentLine");

            migrationBuilder.DropIndex(
                name: "IX_CommitmentLine_OperationId",
                schema: "Contracting",
                table: "CommitmentLine");

            migrationBuilder.DropIndex(
                name: "IX_CommitmentLine_ProductionOrderId",
                schema: "Contracting",
                table: "CommitmentLine");

            migrationBuilder.DropIndex(
                name: "IX_CommitmentLine_SubcontractBOQId",
                schema: "Contracting",
                table: "CommitmentLine");

            migrationBuilder.DropIndex(
                name: "IX_CommitmentLine_WBSId",
                schema: "Contracting",
                table: "CommitmentLine");

            migrationBuilder.RenameColumn(
                name: "OperationId",
                schema: "Contracting",
                table: "CommitmentLine",
                newName: "OperaionId");

            migrationBuilder.RenameColumn(
                name: "BOQLineId",
                schema: "Contracting",
                table: "CommitmentLine",
                newName: "BOQItemId");
        }
    }
}
