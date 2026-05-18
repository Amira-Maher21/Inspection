using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RefactorCurrencyIdInCompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_Currency_ReportingCurrencyID",
                schema: "Sec",
                table: "Company");

            migrationBuilder.RenameColumn(
                name: "ReportingCurrencyID",
                schema: "Sec",
                table: "Company",
                newName: "ReportingCurrencyId");

            migrationBuilder.RenameIndex(
                name: "IX_Company_ReportingCurrencyID",
                schema: "Sec",
                table: "Company",
                newName: "IX_Company_ReportingCurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Currency_ReportingCurrencyId",
                schema: "Sec",
                table: "Company",
                column: "ReportingCurrencyId",
                principalSchema: "Sec",
                principalTable: "Currency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_Currency_ReportingCurrencyId",
                schema: "Sec",
                table: "Company");

            migrationBuilder.RenameColumn(
                name: "ReportingCurrencyId",
                schema: "Sec",
                table: "Company",
                newName: "ReportingCurrencyID");

            migrationBuilder.RenameIndex(
                name: "IX_Company_ReportingCurrencyId",
                schema: "Sec",
                table: "Company",
                newName: "IX_Company_ReportingCurrencyID");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Currency_ReportingCurrencyID",
                schema: "Sec",
                table: "Company",
                column: "ReportingCurrencyID",
                principalSchema: "Sec",
                principalTable: "Currency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
