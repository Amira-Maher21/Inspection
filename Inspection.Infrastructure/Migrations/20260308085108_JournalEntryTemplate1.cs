using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class JournalEntryTemplate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "CurrencyId",
                schema: "Accounting",
                table: "JournalEntryTemplate",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntryTemplate_BranchId",
                schema: "Accounting",
                table: "JournalEntryTemplate",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntryTemplate_CurrencyId",
                schema: "Accounting",
                table: "JournalEntryTemplate",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntryTemplate_Branch_BranchId",
                schema: "Accounting",
                table: "JournalEntryTemplate",
                column: "BranchId",
                principalSchema: "Accounting",
                principalTable: "Branch",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntryTemplate_Currency_CurrencyId",
                schema: "Accounting",
                table: "JournalEntryTemplate",
                column: "CurrencyId",
                principalSchema: "Sec",
                principalTable: "Currency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntryTemplate_Branch_BranchId",
                schema: "Accounting",
                table: "JournalEntryTemplate");

            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntryTemplate_Currency_CurrencyId",
                schema: "Accounting",
                table: "JournalEntryTemplate");

            migrationBuilder.DropIndex(
                name: "IX_JournalEntryTemplate_BranchId",
                schema: "Accounting",
                table: "JournalEntryTemplate");

            migrationBuilder.DropIndex(
                name: "IX_JournalEntryTemplate_CurrencyId",
                schema: "Accounting",
                table: "JournalEntryTemplate");

            migrationBuilder.AlterColumn<int>(
                name: "CurrencyId",
                schema: "Accounting",
                table: "JournalEntryTemplate",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
