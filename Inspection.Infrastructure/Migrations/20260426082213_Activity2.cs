using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Activity2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activity_Series_SeriesId",
                schema: "Contracting",
                table: "Activity");

            migrationBuilder.DropIndex(
                name: "IX_Activity_SeriesId",
                schema: "Contracting",
                table: "Activity");

            migrationBuilder.DropColumn(
                name: "RunningNumber",
                schema: "Contracting",
                table: "Activity");

            migrationBuilder.DropColumn(
                name: "SeriesId",
                schema: "Contracting",
                table: "Activity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RunningNumber",
                schema: "Contracting",
                table: "Activity",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "SeriesId",
                schema: "Contracting",
                table: "Activity",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Activity_SeriesId",
                schema: "Contracting",
                table: "Activity",
                column: "SeriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activity_Series_SeriesId",
                schema: "Contracting",
                table: "Activity",
                column: "SeriesId",
                principalSchema: "Stt",
                principalTable: "Series",
                principalColumn: "Id");
        }
    }
}
