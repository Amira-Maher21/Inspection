using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class BaseCurrency : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_Currency_CurrencyId",
                schema: "Sec",
                table: "Company");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Company_Currency_CurrencyId",
            //    schema: "Sec",
            //    table: "Company",
            //    column: "CurrencyId",
            //    principalSchema: "Sec",
            //    principalTable: "Currency",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_Currency_CurrencyId",
                schema: "Sec",
                table: "Company");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Company_Currency_CurrencyId",
            //    schema: "Sec",
            //    table: "Company",
            //    column: "CurrencyId",
            //    principalSchema: "Sec",
            //    principalTable: "Currency",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);
        }
    }
}
