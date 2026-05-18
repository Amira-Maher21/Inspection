using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Currency : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_Country_CountryId",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "IsBaseCurrency",
                schema: "Sec",
                table: "Currency");

            migrationBuilder.DropColumn(
                name: "IsOfficialCurrency",
                schema: "Sec",
                table: "Currency");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                schema: "Sec",
                table: "Company",
                newName: "OfficialCurrencyId");

            migrationBuilder.RenameIndex(
                name: "IX_Company_CountryId",
                schema: "Sec",
                table: "Company",
                newName: "IX_Company_OfficialCurrencyId");

            migrationBuilder.AddColumn<bool>(
                name: "Disabled",
                schema: "Sec",
                table: "Currency",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "BaseCurrencyId",
                schema: "Sec",
                table: "Company",
                type: "bigint",
                nullable: true,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Company_BaseCurrencyId",
                schema: "Sec",
                table: "Company",
                column: "BaseCurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Currency_BaseCurrencyId",
                schema: "Sec",
                table: "Company",
                column: "BaseCurrencyId",
                principalSchema: "Sec",
                principalTable: "Currency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Currency_OfficialCurrencyId",
                schema: "Sec",
                table: "Company",
                column: "OfficialCurrencyId",
                principalSchema: "Sec",
                principalTable: "Currency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_Currency_BaseCurrencyId",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_Company_Currency_OfficialCurrencyId",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropIndex(
                name: "IX_Company_BaseCurrencyId",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "Disabled",
                schema: "Sec",
                table: "Currency");

            migrationBuilder.DropColumn(
                name: "BaseCurrencyId",
                schema: "Sec",
                table: "Company");

            migrationBuilder.RenameColumn(
                name: "OfficialCurrencyId",
                schema: "Sec",
                table: "Company",
                newName: "CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Company_OfficialCurrencyId",
                schema: "Sec",
                table: "Company",
                newName: "IX_Company_CountryId");

            migrationBuilder.AddColumn<bool>(
                name: "IsBaseCurrency",
                schema: "Sec",
                table: "Currency",
                type: "bit",
                nullable: true,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsOfficialCurrency",
                schema: "Sec",
                table: "Currency",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Country_CountryId",
                schema: "Sec",
                table: "Company",
                column: "CountryId",
                principalSchema: "Sec",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
