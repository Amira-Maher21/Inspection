using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class BaseCurrency4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_Currency_CurrencyId",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropIndex(
                name: "IX_Company_CurrencyId",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                schema: "Sec",
                table: "Company");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CurrencyId",
                schema: "Sec",
                table: "Company",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Company_CurrencyId",
                schema: "Sec",
                table: "Company",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Currency_CurrencyId",
                schema: "Sec",
                table: "Company",
                column: "CurrencyId",
                principalSchema: "Sec",
                principalTable: "Currency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
