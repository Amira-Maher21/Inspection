using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class editCompanyTypeInCommitment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "CompanyId",
                schema: "Contracting",
                table: "Commitment",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntry_ReversalOfJournalEntryId",
                schema: "Accounting",
                table: "JournalEntry",
                column: "ReversalOfJournalEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntry_Tenant_ID_CompanyId_JournalNo",
                schema: "Accounting",
                table: "JournalEntry",
                columns: new[] { "Tenant_ID", "CompanyId", "JournalNo" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntry_JournalEntry_ReversalOfJournalEntryId",
                schema: "Accounting",
                table: "JournalEntry",
                column: "ReversalOfJournalEntryId",
                principalSchema: "Accounting",
                principalTable: "JournalEntry",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntry_JournalEntry_ReversalOfJournalEntryId",
                schema: "Accounting",
                table: "JournalEntry");

            migrationBuilder.DropIndex(
                name: "IX_JournalEntry_ReversalOfJournalEntryId",
                schema: "Accounting",
                table: "JournalEntry");

            migrationBuilder.DropIndex(
                name: "IX_JournalEntry_Tenant_ID_CompanyId_JournalNo",
                schema: "Accounting",
                table: "JournalEntry");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyId",
                schema: "Contracting",
                table: "Commitment",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
