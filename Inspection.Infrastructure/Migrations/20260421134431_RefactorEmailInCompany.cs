using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RefactorEmailInCompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_Currency_ReportingCurrencyID",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_Company_Currency_ReportingCurrnecyID",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropIndex(
                name: "IX_Company_ReportingCurrnecyID",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "ReportingCurrnecyID",
                schema: "Sec",
                table: "Company");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "Sec",
                table: "Company",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_Currency_ReportingCurrencyID",
                schema: "Sec",
                table: "Company");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "Sec",
                table: "Company",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ReportingCurrnecyID",
                schema: "Sec",
                table: "Company",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Company_ReportingCurrnecyID",
                schema: "Sec",
                table: "Company",
                column: "ReportingCurrnecyID");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Currency_ReportingCurrencyID",
                schema: "Sec",
                table: "Company",
                column: "ReportingCurrencyID",
                principalSchema: "Sec",
                principalTable: "Currency",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Currency_ReportingCurrnecyID",
                schema: "Sec",
                table: "Company",
                column: "ReportingCurrnecyID",
                principalSchema: "Sec",
                principalTable: "Currency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
