using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CostingMethodEnumAndTaxAcuuont : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TaxAccountId",
                schema: "Accounting",
                table: "TaxType",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "CostingMethodEnum",
                schema: "Sec",
                table: "Company",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaxType_TaxAccountId",
                schema: "Accounting",
                table: "TaxType",
                column: "TaxAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaxType_ChartOfAccount_TaxAccountId",
                schema: "Accounting",
                table: "TaxType",
                column: "TaxAccountId",
                principalSchema: "Accounting",
                principalTable: "ChartOfAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaxType_ChartOfAccount_TaxAccountId",
                schema: "Accounting",
                table: "TaxType");

            migrationBuilder.DropIndex(
                name: "IX_TaxType_TaxAccountId",
                schema: "Accounting",
                table: "TaxType");

            migrationBuilder.DropColumn(
                name: "TaxAccountId",
                schema: "Accounting",
                table: "TaxType");

            migrationBuilder.DropColumn(
                name: "CostingMethodEnum",
                schema: "Sec",
                table: "Company");
        }
    }
}
