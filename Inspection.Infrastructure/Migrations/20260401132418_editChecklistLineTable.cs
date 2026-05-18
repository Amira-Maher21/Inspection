using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class editChecklistLineTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ChecklistTemplateLineId",
                schema: "Inspection",
                table: "ChecklistLine",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_ChecklistLine_ChecklistTemplateLineId",
                schema: "Inspection",
                table: "ChecklistLine",
                column: "ChecklistTemplateLineId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChecklistLine_ChecklistTemplateLine_ChecklistTemplateLineId",
                schema: "Inspection",
                table: "ChecklistLine",
                column: "ChecklistTemplateLineId",
                principalSchema: "Inspection",
                principalTable: "ChecklistTemplateLine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChecklistLine_ChecklistTemplateLine_ChecklistTemplateLineId",
                schema: "Inspection",
                table: "ChecklistLine");

            migrationBuilder.DropIndex(
                name: "IX_ChecklistLine_ChecklistTemplateLineId",
                schema: "Inspection",
                table: "ChecklistLine");

            migrationBuilder.DropColumn(
                name: "ChecklistTemplateLineId",
                schema: "Inspection",
                table: "ChecklistLine");
        }
    }
}
