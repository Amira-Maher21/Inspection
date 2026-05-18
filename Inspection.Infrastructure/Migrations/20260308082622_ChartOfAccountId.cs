using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChartOfAccountId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModeOfPayment_JournalEntry_JournalEntryId",
                schema: "Accounting",
                table: "ModeOfPayment");

            migrationBuilder.RenameColumn(
                name: "JournalEntryId",
                schema: "Accounting",
                table: "ModeOfPayment",
                newName: "ChartOfAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_ModeOfPayment_JournalEntryId",
                schema: "Accounting",
                table: "ModeOfPayment",
                newName: "IX_ModeOfPayment_ChartOfAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_ModeOfPayment_ChartOfAccount_ChartOfAccountId",
                schema: "Accounting",
                table: "ModeOfPayment",
                column: "ChartOfAccountId",
                principalSchema: "Accounting",
                principalTable: "ChartOfAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModeOfPayment_ChartOfAccount_ChartOfAccountId",
                schema: "Accounting",
                table: "ModeOfPayment");

            migrationBuilder.RenameColumn(
                name: "ChartOfAccountId",
                schema: "Accounting",
                table: "ModeOfPayment",
                newName: "JournalEntryId");

            migrationBuilder.RenameIndex(
                name: "IX_ModeOfPayment_ChartOfAccountId",
                schema: "Accounting",
                table: "ModeOfPayment",
                newName: "IX_ModeOfPayment_JournalEntryId");

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
    }
}
