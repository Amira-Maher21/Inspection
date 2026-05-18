using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addCurrencyService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReportingOfficialCreditAmount",
                schema: "Accounting",
                table: "LedgerLine",
                newName: "ReportingCreditAmount");

            migrationBuilder.AddColumn<long>(
                name: "ReportingCurrencyID",
                schema: "Sec",
                table: "Company",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Company_ReportingCurrencyID",
                schema: "Sec",
                table: "Company",
                column: "ReportingCurrencyID");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Currency_ReportingCurrencyID",
                schema: "Sec",
                table: "Company",
                column: "ReportingCurrencyID",
                principalSchema: "Sec",
                principalTable: "Currency",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_Currency_ReportingCurrencyID",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropIndex(
                name: "IX_Company_ReportingCurrencyID",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "ReportingCurrencyID",
                schema: "Sec",
                table: "Company");

            migrationBuilder.RenameColumn(
                name: "ReportingCreditAmount",
                schema: "Accounting",
                table: "LedgerLine",
                newName: "ReportingOfficialCreditAmount");
        }
    }
}
