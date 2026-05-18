using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemovAccountIdInTax : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaxType_ChartOfAccount_ChartOfAccounttId",
                schema: "Accounting",
                table: "TaxType");

            migrationBuilder.DropIndex(
                name: "IX_TaxType_ChartOfAccounttId",
                schema: "Accounting",
                table: "TaxType");

            migrationBuilder.DropColumn(
                name: "ChartOfAccounttId",
                schema: "Accounting",
                table: "TaxType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ChartOfAccounttId",
                schema: "Accounting",
                table: "TaxType",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_TaxType_ChartOfAccounttId",
                schema: "Accounting",
                table: "TaxType",
                column: "ChartOfAccounttId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaxType_ChartOfAccount_ChartOfAccounttId",
                schema: "Accounting",
                table: "TaxType",
                column: "ChartOfAccounttId",
                principalSchema: "Accounting",
                principalTable: "ChartOfAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
