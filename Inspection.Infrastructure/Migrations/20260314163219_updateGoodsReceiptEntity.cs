using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateGoodsReceiptEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ledger_JournalEntry_JournalEntryId",
                schema: "Accounting",
                table: "Ledger");

            migrationBuilder.AlterColumn<long>(
                name: "JournalEntryId",
                schema: "Accounting",
                table: "Ledger",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Ledger_JournalEntry_JournalEntryId",
                schema: "Accounting",
                table: "Ledger",
                column: "JournalEntryId",
                principalSchema: "Accounting",
                principalTable: "JournalEntry",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ledger_JournalEntry_JournalEntryId",
                schema: "Accounting",
                table: "Ledger");

            migrationBuilder.AlterColumn<long>(
                name: "JournalEntryId",
                schema: "Accounting",
                table: "Ledger",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ledger_JournalEntry_JournalEntryId",
                schema: "Accounting",
                table: "Ledger",
                column: "JournalEntryId",
                principalSchema: "Accounting",
                principalTable: "JournalEntry",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
