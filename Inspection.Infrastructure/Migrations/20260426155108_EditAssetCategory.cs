using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EditAssetCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AssetCategory_Tenant_ID_Code",
                schema: "Accounting",
                table: "AssetCategory");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "Accounting",
                table: "AssetCategory",
                newName: "CategoryName");

            migrationBuilder.RenameColumn(
                name: "Code",
                schema: "Accounting",
                table: "AssetCategory",
                newName: "CategoryCode");

            migrationBuilder.AlterColumn<string>(
                name: "Tenant_ID",
                schema: "Accounting",
                table: "AssetCategory",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<int>(
                name: "DefaultUsefulLifeMonths",
                schema: "Accounting",
                table: "AssetCategory",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "DefaultDepreciationMethod",
                schema: "Accounting",
                table: "AssetCategory",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<long>(
                name: "AccumulatedDepreciationAccountId",
                schema: "Accounting",
                table: "AssetCategory",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "AssetAccountId",
                schema: "Accounting",
                table: "AssetCategory",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "AssetDisposalAccountId",
                schema: "Accounting",
                table: "AssetCategory",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                schema: "Accounting",
                table: "AssetCategory",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "DefaultResidualValuePct",
                schema: "Accounting",
                table: "AssetCategory",
                type: "decimal(18,4)",
                precision: 18,
                scale: 4,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DepreciationExpenseAccountId",
                schema: "Accounting",
                table: "AssetCategory",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "GainOnDisposalAccountId",
                schema: "Accounting",
                table: "AssetCategory",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ImpairmentLossAccountId",
                schema: "Accounting",
                table: "AssetCategory",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LossOnDisposalAccountId",
                schema: "Accounting",
                table: "AssetCategory",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                schema: "Accounting",
                table: "AssetCategory",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "RevaluationSurplusAccountId",
                schema: "Accounting",
                table: "AssetCategory",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssetCategory_AccumulatedDepreciationAccountId",
                schema: "Accounting",
                table: "AssetCategory",
                column: "AccumulatedDepreciationAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetCategory_AssetAccountId",
                schema: "Accounting",
                table: "AssetCategory",
                column: "AssetAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetCategory_DepreciationExpenseAccountId",
                schema: "Accounting",
                table: "AssetCategory",
                column: "DepreciationExpenseAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetCategory_Tenant_ID_CompanyId_CategoryCode",
                schema: "Accounting",
                table: "AssetCategory",
                columns: new[] { "Tenant_ID", "CompanyId", "CategoryCode" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AssetCategory_AccumulatedDepreciationAccountId",
                schema: "Accounting",
                table: "AssetCategory");

            migrationBuilder.DropIndex(
                name: "IX_AssetCategory_AssetAccountId",
                schema: "Accounting",
                table: "AssetCategory");

            migrationBuilder.DropIndex(
                name: "IX_AssetCategory_DepreciationExpenseAccountId",
                schema: "Accounting",
                table: "AssetCategory");

            migrationBuilder.DropIndex(
                name: "IX_AssetCategory_Tenant_ID_CompanyId_CategoryCode",
                schema: "Accounting",
                table: "AssetCategory");

            migrationBuilder.DropColumn(
                name: "AccumulatedDepreciationAccountId",
                schema: "Accounting",
                table: "AssetCategory");

            migrationBuilder.DropColumn(
                name: "AssetAccountId",
                schema: "Accounting",
                table: "AssetCategory");

            migrationBuilder.DropColumn(
                name: "AssetDisposalAccountId",
                schema: "Accounting",
                table: "AssetCategory");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                schema: "Accounting",
                table: "AssetCategory");

            migrationBuilder.DropColumn(
                name: "DefaultResidualValuePct",
                schema: "Accounting",
                table: "AssetCategory");

            migrationBuilder.DropColumn(
                name: "DepreciationExpenseAccountId",
                schema: "Accounting",
                table: "AssetCategory");

            migrationBuilder.DropColumn(
                name: "GainOnDisposalAccountId",
                schema: "Accounting",
                table: "AssetCategory");

            migrationBuilder.DropColumn(
                name: "ImpairmentLossAccountId",
                schema: "Accounting",
                table: "AssetCategory");

            migrationBuilder.DropColumn(
                name: "LossOnDisposalAccountId",
                schema: "Accounting",
                table: "AssetCategory");

            migrationBuilder.DropColumn(
                name: "Notes",
                schema: "Accounting",
                table: "AssetCategory");

            migrationBuilder.DropColumn(
                name: "RevaluationSurplusAccountId",
                schema: "Accounting",
                table: "AssetCategory");

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                schema: "Accounting",
                table: "AssetCategory",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CategoryCode",
                schema: "Accounting",
                table: "AssetCategory",
                newName: "Code");

            migrationBuilder.AlterColumn<string>(
                name: "Tenant_ID",
                schema: "Accounting",
                table: "AssetCategory",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<long>(
                name: "DefaultUsefulLifeMonths",
                schema: "Accounting",
                table: "AssetCategory",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "DefaultDepreciationMethod",
                schema: "Accounting",
                table: "AssetCategory",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_AssetCategory_Tenant_ID_Code",
                schema: "Accounting",
                table: "AssetCategory",
                columns: new[] { "Tenant_ID", "Code" },
                unique: true);
        }
    }
}
