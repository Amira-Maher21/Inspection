using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class editPurchaseInvoiceLine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ItemId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "AssetId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AssetTransactionType",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LineType",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceLine_AssetId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                column: "AssetId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseInvoiceLine_FixedAsset_AssetId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
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
                name: "FK_PurchaseInvoiceLine_FixedAsset_AssetId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseInvoiceLine_AssetId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropColumn(
                name: "AssetId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropColumn(
                name: "AssetTransactionType",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropColumn(
                name: "LineType",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<long>(
                name: "ItemId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);
        }
    }
}
