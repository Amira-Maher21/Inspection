using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class JournalEntry2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModeOfPayment_JournalEntry_JournalEntryId1",
                schema: "Accounting",
                table: "ModeOfPayment");

            migrationBuilder.DropIndex(
                name: "IX_ModeOfPayment_JournalEntryId1",
                schema: "Accounting",
                table: "ModeOfPayment");

            migrationBuilder.DropColumn(
             name: "JournalEntryId1",
             schema: "Accounting",
             table: "ModeOfPayment");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "JournalEntryId",
                schema: "Accounting",
                table: "ModeOfPayment",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "JournalEntryId1",
                schema: "Accounting",
                table: "ModeOfPayment",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_ModeOfPayment_JournalEntryId1",
                schema: "Accounting",
                table: "ModeOfPayment",
                column: "JournalEntryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ModeOfPayment_JournalEntry_JournalEntryId1",
                schema: "Accounting",
                table: "ModeOfPayment",
                column: "JournalEntryId1",
                principalSchema: "Accounting",
                principalTable: "JournalEntry",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
