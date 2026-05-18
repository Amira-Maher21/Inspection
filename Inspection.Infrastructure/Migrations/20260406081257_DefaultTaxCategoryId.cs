using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DefaultTaxCategoryId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemGroup_TaxCategory_TaxCategoryId",
                schema: "Inventory",
                table: "ItemGroup");

            migrationBuilder.DropIndex(
                name: "IX_ItemGroup_TaxCategoryId",
                schema: "Inventory",
                table: "ItemGroup");

            migrationBuilder.DropColumn(
                name: "TaxCategoryId",
                schema: "Inventory",
                table: "ItemGroup");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TaxCategoryId",
                schema: "Inventory",
                table: "ItemGroup",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_ItemGroup_TaxCategoryId",
                schema: "Inventory",
                table: "ItemGroup",
                column: "TaxCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemGroup_TaxCategory_TaxCategoryId",
                schema: "Inventory",
                table: "ItemGroup",
                column: "TaxCategoryId",
                principalSchema: "Accounting",
                principalTable: "TaxCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
