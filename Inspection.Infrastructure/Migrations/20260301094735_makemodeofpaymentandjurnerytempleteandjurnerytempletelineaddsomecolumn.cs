using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class makemodeofpaymentandjurnerytempleteandjurnerytempletelineaddsomecolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "JournalEntryId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine",
                newName: "JournalEntryTemplateId");

            migrationBuilder.RenameIndex(
                name: "IX_JournalEntryTemplateLine_JournalEntryId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine",
                newName: "IX_JournalEntryTemplateLine_JournalEntryTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntryTemplateLine_JournalEntryTemplate_JournalEntryTemplateId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine",
                column: "JournalEntryTemplateId",
                principalSchema: "Accounting",
                principalTable: "JournalEntryTemplate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntryTemplateLine_JournalEntryTemplate_JournalEntryTemplateId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine");

            migrationBuilder.RenameColumn(
                name: "JournalEntryTemplateId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine",
                newName: "JournalEntryId");

            migrationBuilder.RenameIndex(
                name: "IX_JournalEntryTemplateLine_JournalEntryTemplateId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine",
                newName: "IX_JournalEntryTemplateLine_JournalEntryId");
        }
    }
}
