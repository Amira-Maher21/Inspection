using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class editAccountBalance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountBalance_Branch_BranchId",
                table: "AccountBalance");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountBalance_ChartOfAccount_ChartOfAccountId",
                table: "AccountBalance");

            migrationBuilder.DropIndex(
                name: "IX_AccountBalance_BranchId",
                table: "AccountBalance");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "AccountBalance");

            migrationBuilder.RenameTable(
                name: "AccountBalance",
                newName: "AccountBalance",
                newSchema: "Accounting");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalDebit",
                schema: "Accounting",
                table: "AccountBalance",
                type: "decimal(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalCredit",
                schema: "Accounting",
                table: "AccountBalance",
                type: "decimal(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Tenant_ID",
                schema: "Accounting",
                table: "AccountBalance",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "In_Date",
                schema: "Accounting",
                table: "AccountBalance",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "In_User",
                schema: "Accounting",
                table: "AccountBalance",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Mod_Date",
                schema: "Accounting",
                table: "AccountBalance",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mod_User",
                schema: "Accounting",
                table: "AccountBalance",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountBalance_Tenant_ID_CompanyId_ChartOfAccountId",
                schema: "Accounting",
                table: "AccountBalance",
                columns: new[] { "Tenant_ID", "CompanyId", "ChartOfAccountId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountBalance_ChartOfAccount_ChartOfAccountId",
                schema: "Accounting",
                table: "AccountBalance",
                column: "ChartOfAccountId",
                principalSchema: "Accounting",
                principalTable: "ChartOfAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountBalance_ChartOfAccount_ChartOfAccountId",
                schema: "Accounting",
                table: "AccountBalance");

            migrationBuilder.DropIndex(
                name: "IX_AccountBalance_Tenant_ID_CompanyId_ChartOfAccountId",
                schema: "Accounting",
                table: "AccountBalance");

            migrationBuilder.DropColumn(
                name: "In_Date",
                schema: "Accounting",
                table: "AccountBalance");

            migrationBuilder.DropColumn(
                name: "In_User",
                schema: "Accounting",
                table: "AccountBalance");

            migrationBuilder.DropColumn(
                name: "Mod_Date",
                schema: "Accounting",
                table: "AccountBalance");

            migrationBuilder.DropColumn(
                name: "Mod_User",
                schema: "Accounting",
                table: "AccountBalance");

            migrationBuilder.RenameTable(
                name: "AccountBalance",
                schema: "Accounting",
                newName: "AccountBalance");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalDebit",
                table: "AccountBalance",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)",
                oldPrecision: 18,
                oldScale: 6,
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalCredit",
                table: "AccountBalance",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)",
                oldPrecision: 18,
                oldScale: 6,
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "Tenant_ID",
                table: "AccountBalance",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<long>(
                name: "BranchId",
                table: "AccountBalance",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_AccountBalance_BranchId",
                table: "AccountBalance",
                column: "BranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountBalance_Branch_BranchId",
                table: "AccountBalance",
                column: "BranchId",
                principalSchema: "Accounting",
                principalTable: "Branch",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountBalance_ChartOfAccount_ChartOfAccountId",
                table: "AccountBalance",
                column: "ChartOfAccountId",
                principalSchema: "Accounting",
                principalTable: "ChartOfAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
