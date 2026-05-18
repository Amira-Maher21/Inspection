using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EditInventoryLedger : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryLedger_PostingDocumentType_PostingDocumentTypeId",
                schema: "Inventory",
                table: "InventoryLedger");

            migrationBuilder.AddColumn<int>(
                name: "Direction",
                schema: "Accounting",
                table: "PostingAccountMapping",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsInventory",
                schema: "Accounting",
                table: "PostingAccountMapping",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "CurrencyId",
                schema: "Inventory",
                table: "InventoryLedger",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "DocumentNumber",
                schema: "Inventory",
                table: "InventoryLedger",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsCancelled",
                schema: "Inventory",
                table: "InventoryLedger",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Inventory",
                table: "InventoryLedger",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsReversed",
                schema: "Inventory",
                table: "InventoryLedger",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "ReferenceDocumentLineId",
                schema: "Inventory",
                table: "InventoryLedger",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReversedFromId",
                schema: "Inventory",
                table: "InventoryLedger",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TransactionValue",
                schema: "Inventory",
                table: "InventoryLedger",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_InventoryLedger_CurrencyId",
                schema: "Inventory",
                table: "InventoryLedger",
                column: "CurrencyId");

            migrationBuilder.AddCheckConstraint(
                name: "CK_InventoryLedger_QuantityRule",
                schema: "Inventory",
                table: "InventoryLedger",
                sql: "NOT (QuantityIn > 0 AND QuantityOut > 0)");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryLedger_Currency_CurrencyId",
                schema: "Inventory",
                table: "InventoryLedger",
                column: "CurrencyId",
                principalSchema: "Sec",
                principalTable: "Currency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryLedger_PostingDocumentType_PostingDocumentTypeId",
                schema: "Inventory",
                table: "InventoryLedger",
                column: "PostingDocumentTypeId",
                principalSchema: "Accounting",
                principalTable: "PostingDocumentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryLedger_Currency_CurrencyId",
                schema: "Inventory",
                table: "InventoryLedger");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryLedger_PostingDocumentType_PostingDocumentTypeId",
                schema: "Inventory",
                table: "InventoryLedger");

            migrationBuilder.DropIndex(
                name: "IX_InventoryLedger_CurrencyId",
                schema: "Inventory",
                table: "InventoryLedger");

            migrationBuilder.DropCheckConstraint(
                name: "CK_InventoryLedger_QuantityRule",
                schema: "Inventory",
                table: "InventoryLedger");

            migrationBuilder.DropColumn(
                name: "Direction",
                schema: "Accounting",
                table: "PostingAccountMapping");

            migrationBuilder.DropColumn(
                name: "IsInventory",
                schema: "Accounting",
                table: "PostingAccountMapping");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                schema: "Inventory",
                table: "InventoryLedger");

            migrationBuilder.DropColumn(
                name: "DocumentNumber",
                schema: "Inventory",
                table: "InventoryLedger");

            migrationBuilder.DropColumn(
                name: "IsCancelled",
                schema: "Inventory",
                table: "InventoryLedger");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Inventory",
                table: "InventoryLedger");

            migrationBuilder.DropColumn(
                name: "IsReversed",
                schema: "Inventory",
                table: "InventoryLedger");

            migrationBuilder.DropColumn(
                name: "ReferenceDocumentLineId",
                schema: "Inventory",
                table: "InventoryLedger");

            migrationBuilder.DropColumn(
                name: "ReversedFromId",
                schema: "Inventory",
                table: "InventoryLedger");

            migrationBuilder.DropColumn(
                name: "TransactionValue",
                schema: "Inventory",
                table: "InventoryLedger");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryLedger_PostingDocumentType_PostingDocumentTypeId",
                schema: "Inventory",
                table: "InventoryLedger",
                column: "PostingDocumentTypeId",
                principalSchema: "Accounting",
                principalTable: "PostingDocumentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
