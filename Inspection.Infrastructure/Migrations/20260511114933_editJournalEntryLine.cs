using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class editJournalEntryLine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "Accounting",
                table: "JournalEntryLine",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "AssetId",
                schema: "Accounting",
                table: "JournalEntryLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AssetTransactionType",
                schema: "Accounting",
                table: "JournalEntryLine",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LineType",
                schema: "Accounting",
                table: "JournalEntryLine",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntryLine_AssetId",
                schema: "Accounting",
                table: "JournalEntryLine",
                column: "AssetId");

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntryLine_FixedAsset_AssetId",
                schema: "Accounting",
                table: "JournalEntryLine",
                column: "AssetId",
                principalSchema: "Accounting",
                principalTable: "FixedAsset",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntryLine_FixedAsset_AssetId",
                schema: "Accounting",
                table: "JournalEntryLine");

            migrationBuilder.DropIndex(
                name: "IX_JournalEntryLine_AssetId",
                schema: "Accounting",
                table: "JournalEntryLine");

            migrationBuilder.DropColumn(
                name: "AssetId",
                schema: "Accounting",
                table: "JournalEntryLine");

            migrationBuilder.DropColumn(
                name: "AssetTransactionType",
                schema: "Accounting",
                table: "JournalEntryLine");

            migrationBuilder.DropColumn(
                name: "LineType",
                schema: "Accounting",
                table: "JournalEntryLine");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "Accounting",
                table: "JournalEntryLine",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);
        }
    }
}
