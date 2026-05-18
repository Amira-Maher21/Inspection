using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class BaseCurrency2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "BaseCurrencyId",
                schema: "Sec",
                table: "Company",
                type: "bigint",
                nullable: false,
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_Currency_BaseCurrencyId",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropIndex(
                name: "IX_Company_BaseCurrencyId",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "BaseCurrencyId",
                schema: "Sec",
                table: "Company");
        }
    }
}
