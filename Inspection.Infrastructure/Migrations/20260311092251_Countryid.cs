using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Countryid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CountryId",
                schema: "Sec",
                table: "Company",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Company_CountryId",
                schema: "Sec",
                table: "Company",
                column: "CountryId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_Country_CountryId",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropIndex(
                name: "IX_Company_CountryId",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "CountryId",
                schema: "Sec",
                table: "Company");
        }
    }
}
