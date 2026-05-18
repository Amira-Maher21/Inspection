using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class editAssetCategoryRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "CompanyId",
                schema: "Accounting",
                table: "AssetLocation",
                type: "bigint",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<long>(
                name: "CompanyId",
                schema: "Accounting",
                table: "AssetCategory",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_AssetCategory_AssetDisposalAccountId",
                schema: "Accounting",
                table: "AssetCategory",
                column: "AssetDisposalAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetCategory_GainOnDisposalAccountId",
                schema: "Accounting",
                table: "AssetCategory",
                column: "GainOnDisposalAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetCategory_ImpairmentLossAccountId",
                schema: "Accounting",
                table: "AssetCategory",
                column: "ImpairmentLossAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetCategory_LossOnDisposalAccountId",
                schema: "Accounting",
                table: "AssetCategory",
                column: "LossOnDisposalAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetCategory_RevaluationSurplusAccountId",
                schema: "Accounting",
                table: "AssetCategory",
                column: "RevaluationSurplusAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetCategory_ChartOfAccount_AccumulatedDepreciationAccountId",
                schema: "Accounting",
                table: "AssetCategory",
                column: "AccumulatedDepreciationAccountId",
                principalSchema: "Accounting",
                principalTable: "ChartOfAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetCategory_ChartOfAccount_AssetAccountId",
                schema: "Accounting",
                table: "AssetCategory",
                column: "AssetAccountId",
                principalSchema: "Accounting",
                principalTable: "ChartOfAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetCategory_ChartOfAccount_AssetDisposalAccountId",
                schema: "Accounting",
                table: "AssetCategory",
                column: "AssetDisposalAccountId",
                principalSchema: "Accounting",
                principalTable: "ChartOfAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetCategory_ChartOfAccount_DepreciationExpenseAccountId",
                schema: "Accounting",
                table: "AssetCategory",
                column: "DepreciationExpenseAccountId",
                principalSchema: "Accounting",
                principalTable: "ChartOfAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetCategory_ChartOfAccount_GainOnDisposalAccountId",
                schema: "Accounting",
                table: "AssetCategory",
                column: "GainOnDisposalAccountId",
                principalSchema: "Accounting",
                principalTable: "ChartOfAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetCategory_ChartOfAccount_ImpairmentLossAccountId",
                schema: "Accounting",
                table: "AssetCategory",
                column: "ImpairmentLossAccountId",
                principalSchema: "Accounting",
                principalTable: "ChartOfAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetCategory_ChartOfAccount_LossOnDisposalAccountId",
                schema: "Accounting",
                table: "AssetCategory",
                column: "LossOnDisposalAccountId",
                principalSchema: "Accounting",
                principalTable: "ChartOfAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetCategory_ChartOfAccount_RevaluationSurplusAccountId",
                schema: "Accounting",
                table: "AssetCategory",
                column: "RevaluationSurplusAccountId",
                principalSchema: "Accounting",
                principalTable: "ChartOfAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetCategory_ChartOfAccount_AccumulatedDepreciationAccountId",
                schema: "Accounting",
                table: "AssetCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetCategory_ChartOfAccount_AssetAccountId",
                schema: "Accounting",
                table: "AssetCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetCategory_ChartOfAccount_AssetDisposalAccountId",
                schema: "Accounting",
                table: "AssetCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetCategory_ChartOfAccount_DepreciationExpenseAccountId",
                schema: "Accounting",
                table: "AssetCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetCategory_ChartOfAccount_GainOnDisposalAccountId",
                schema: "Accounting",
                table: "AssetCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetCategory_ChartOfAccount_ImpairmentLossAccountId",
                schema: "Accounting",
                table: "AssetCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetCategory_ChartOfAccount_LossOnDisposalAccountId",
                schema: "Accounting",
                table: "AssetCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetCategory_ChartOfAccount_RevaluationSurplusAccountId",
                schema: "Accounting",
                table: "AssetCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_CashReceiptLine_Activity_ActivityId",
                schema: "Accounting",
                table: "CashReceiptLine");

            migrationBuilder.DropForeignKey(
                name: "FK_CashReceiptLine_BOQLine_BOQLineId",
                schema: "Accounting",
                table: "CashReceiptLine");

            migrationBuilder.DropForeignKey(
                name: "FK_CashReceiptLine_CostCode_CostCodeId",
                schema: "Accounting",
                table: "CashReceiptLine");

            migrationBuilder.DropForeignKey(
                name: "FK_CashReceiptLine_ProductionOrder_ProductionOrderId",
                schema: "Accounting",
                table: "CashReceiptLine");

            migrationBuilder.DropForeignKey(
                name: "FK_CashReceiptLine_SubcontractBOQ_SubcontractBOQId",
                schema: "Accounting",
                table: "CashReceiptLine");

            migrationBuilder.DropForeignKey(
                name: "FK_CashReceiptLine_WBS_WBSId",
                schema: "Accounting",
                table: "CashReceiptLine");

            migrationBuilder.DropIndex(
                name: "IX_CashReceiptLine_ActivityId",
                schema: "Accounting",
                table: "CashReceiptLine");

            migrationBuilder.DropIndex(
                name: "IX_CashReceiptLine_BOQLineId",
                schema: "Accounting",
                table: "CashReceiptLine");

            migrationBuilder.DropIndex(
                name: "IX_CashReceiptLine_CostCodeId",
                schema: "Accounting",
                table: "CashReceiptLine");

            migrationBuilder.DropIndex(
                name: "IX_CashReceiptLine_ProductionOrderId",
                schema: "Accounting",
                table: "CashReceiptLine");

            migrationBuilder.DropIndex(
                name: "IX_CashReceiptLine_SubcontractBOQId",
                schema: "Accounting",
                table: "CashReceiptLine");

            migrationBuilder.DropIndex(
                name: "IX_CashReceiptLine_WBSId",
                schema: "Accounting",
                table: "CashReceiptLine");

            migrationBuilder.DropIndex(
                name: "IX_AssetCategory_AssetDisposalAccountId",
                schema: "Accounting",
                table: "AssetCategory");

            migrationBuilder.DropIndex(
                name: "IX_AssetCategory_GainOnDisposalAccountId",
                schema: "Accounting",
                table: "AssetCategory");

            migrationBuilder.DropIndex(
                name: "IX_AssetCategory_ImpairmentLossAccountId",
                schema: "Accounting",
                table: "AssetCategory");

            migrationBuilder.DropIndex(
                name: "IX_AssetCategory_LossOnDisposalAccountId",
                schema: "Accounting",
                table: "AssetCategory");

            migrationBuilder.DropIndex(
                name: "IX_AssetCategory_RevaluationSurplusAccountId",
                schema: "Accounting",
                table: "AssetCategory");

            migrationBuilder.RenameColumn(
                name: "BOQLineId",
                schema: "Accounting",
                table: "CashReceiptLine",
                newName: "BOQItemId");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyId",
                schema: "Accounting",
                table: "AssetLocation",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "CompanyId",
                schema: "Accounting",
                table: "AssetCategory",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
