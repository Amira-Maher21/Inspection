using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Documentid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "DocumentId",
                schema: "DMS",
                table: "DocumentShare",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_DocumentShare_DocumentId",
                schema: "DMS",
                table: "DocumentShare",
                column: "DocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentShare_Document_DocumentId",
                schema: "DMS",
                table: "DocumentShare",
                column: "DocumentId",
                principalSchema: "DMS",
                principalTable: "Document",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentShare_Document_DocumentId",
                schema: "DMS",
                table: "DocumentShare");

            migrationBuilder.DropIndex(
                name: "IX_DocumentShare_DocumentId",
                schema: "DMS",
                table: "DocumentShare");

            migrationBuilder.DropColumn(
                name: "DocumentId",
                schema: "DMS",
                table: "DocumentShare");
        }
    }
}
