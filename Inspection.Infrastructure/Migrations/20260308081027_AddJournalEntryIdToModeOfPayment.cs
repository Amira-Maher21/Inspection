using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddJournalEntryIdToModeOfPayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.CreateIndex(
                name: "IX_ModeOfPayment_JournalEntryId",
                schema: "Accounting",
                table: "ModeOfPayment",
                column: "JournalEntryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ModeOfPayment_JournalEntry_JournalEntryId",
                schema: "Accounting",
                table: "ModeOfPayment",
                column: "JournalEntryId",
                principalSchema: "Accounting",
                principalTable: "JournalEntry",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModeOfPayment_JournalEntry_JournalEntryId",
                schema: "Accounting",
                table: "ModeOfPayment");

            migrationBuilder.DropIndex(
                name: "IX_ModeOfPayment_JournalEntryId",
                schema: "Accounting",
                table: "ModeOfPayment");

            migrationBuilder.DropColumn(
                name: "JournalEntryId",
                schema: "Accounting",
                table: "ModeOfPayment");
        }
    }
}
