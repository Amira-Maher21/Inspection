using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addGoodReciptPostingHandler : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Posting",
                schema: "Accounting",
                table: "JournalEntry",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<decimal>(
                name: "ExchangeRate",
                schema: "Accounting",
                table: "JournalEntry",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<long>(
                name: "ActivityId",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "BOQItemId",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CostCodeId",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "OperationId",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ProductionOrderId",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SubcontractBOQId",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "WBSId",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "BranchId",
                schema: "Inventory",
                table: "GoodsReceipt",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CurrencyId",
                schema: "Inventory",
                table: "GoodsReceipt",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "DocumentCode",
                schema: "Inventory",
                table: "GoodsReceipt",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "ExchangeRate",
                schema: "Inventory",
                table: "GoodsReceipt",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Posting",
                schema: "Inventory",
                table: "GoodsReceipt",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalCredit",
                schema: "Inventory",
                table: "GoodsReceipt",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalDebit",
                schema: "Inventory",
                table: "GoodsReceipt",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExchangeRate",
                schema: "Accounting",
                table: "JournalEntry");

            migrationBuilder.DropColumn(
                name: "ActivityId",
                schema: "Inventory",
                table: "GoodsReceiptLine");

            migrationBuilder.DropColumn(
                name: "BOQItemId",
                schema: "Inventory",
                table: "GoodsReceiptLine");

            migrationBuilder.DropColumn(
                name: "CostCodeId",
                schema: "Inventory",
                table: "GoodsReceiptLine");

            migrationBuilder.DropColumn(
                name: "OperationId",
                schema: "Inventory",
                table: "GoodsReceiptLine");

            migrationBuilder.DropColumn(
                name: "ProductionOrderId",
                schema: "Inventory",
                table: "GoodsReceiptLine");

            migrationBuilder.DropColumn(
                name: "SubcontractBOQId",
                schema: "Inventory",
                table: "GoodsReceiptLine");

            migrationBuilder.DropColumn(
                name: "WBSId",
                schema: "Inventory",
                table: "GoodsReceiptLine");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                schema: "Inventory",
                table: "GoodsReceipt");

            migrationBuilder.DropColumn(
                name: "DocumentCode",
                schema: "Inventory",
                table: "GoodsReceipt");

            migrationBuilder.DropColumn(
                name: "ExchangeRate",
                schema: "Inventory",
                table: "GoodsReceipt");

            migrationBuilder.DropColumn(
                name: "Posting",
                schema: "Inventory",
                table: "GoodsReceipt");

            migrationBuilder.DropColumn(
                name: "TotalCredit",
                schema: "Inventory",
                table: "GoodsReceipt");

            migrationBuilder.DropColumn(
                name: "TotalDebit",
                schema: "Inventory",
                table: "GoodsReceipt");

            migrationBuilder.AlterColumn<bool>(
                name: "Posting",
                schema: "Accounting",
                table: "JournalEntry",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "BranchId",
                schema: "Inventory",
                table: "GoodsReceipt",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
