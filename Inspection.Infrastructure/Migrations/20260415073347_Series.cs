using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Series : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RunningNumber",
                schema: "Inventory",
                table: "GoodsReceipt",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "SeriesId",
                schema: "Inventory",
                table: "GoodsReceipt",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceipt_SeriesId",
                schema: "Inventory",
                table: "GoodsReceipt",
                column: "SeriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsReceipt_Series_SeriesId",
                schema: "Inventory",
                table: "GoodsReceipt",
                column: "SeriesId",
                principalSchema: "Stt",
                principalTable: "Series",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GoodsReceipt_Series_SeriesId",
                schema: "Inventory",
                table: "GoodsReceipt");

            migrationBuilder.DropIndex(
                name: "IX_GoodsReceipt_SeriesId",
                schema: "Inventory",
                table: "GoodsReceipt");

            migrationBuilder.DropColumn(
                name: "RunningNumber",
                schema: "Inventory",
                table: "GoodsReceipt");

            migrationBuilder.DropColumn(
                name: "SeriesId",
                schema: "Inventory",
                table: "GoodsReceipt");
        }
    }
}
