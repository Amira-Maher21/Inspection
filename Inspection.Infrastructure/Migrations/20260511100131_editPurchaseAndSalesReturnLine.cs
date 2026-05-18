using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class editPurchaseAndSalesReturnLine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "ItemId",
                schema: "Sales",
                table: "SalesReturnLine",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "AssetId",
                schema: "Sales",
                table: "SalesReturnLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AssetTransactionType",
                schema: "Sales",
                table: "SalesReturnLine",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LineType",
                schema: "Sales",
                table: "SalesReturnLine",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                schema: "Accounting",
                table: "PurchaseReturnLine",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ItemId",
                schema: "Accounting",
                table: "PurchaseReturnLine",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "Accounting",
                table: "PurchaseReturnLine",
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
                table: "PurchaseReturnLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AssetTransactionType",
                schema: "Accounting",
                table: "PurchaseReturnLine",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LineType",
                schema: "Accounting",
                table: "PurchaseReturnLine",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnLine_AssetId",
                schema: "Sales",
                table: "SalesReturnLine",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnLine_AssetId",
                schema: "Accounting",
                table: "PurchaseReturnLine",
                column: "AssetId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseReturnLine_FixedAsset_AssetId",
                schema: "Accounting",
                table: "PurchaseReturnLine",
                column: "AssetId",
                principalSchema: "Accounting",
                principalTable: "FixedAsset",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesReturnLine_FixedAsset_AssetId",
                schema: "Sales",
                table: "SalesReturnLine",
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
                name: "FK_PurchaseReturnLine_FixedAsset_AssetId",
                schema: "Accounting",
                table: "PurchaseReturnLine");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesReturnLine_FixedAsset_AssetId",
                schema: "Sales",
                table: "SalesReturnLine");

            migrationBuilder.DropIndex(
                name: "IX_SalesReturnLine_AssetId",
                schema: "Sales",
                table: "SalesReturnLine");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseReturnLine_AssetId",
                schema: "Accounting",
                table: "PurchaseReturnLine");

            migrationBuilder.DropColumn(
                name: "AssetId",
                schema: "Sales",
                table: "SalesReturnLine");

            migrationBuilder.DropColumn(
                name: "AssetTransactionType",
                schema: "Sales",
                table: "SalesReturnLine");

            migrationBuilder.DropColumn(
                name: "LineType",
                schema: "Sales",
                table: "SalesReturnLine");

            migrationBuilder.DropColumn(
                name: "AssetId",
                schema: "Accounting",
                table: "PurchaseReturnLine");

            migrationBuilder.DropColumn(
                name: "AssetTransactionType",
                schema: "Accounting",
                table: "PurchaseReturnLine");

            migrationBuilder.DropColumn(
                name: "LineType",
                schema: "Accounting",
                table: "PurchaseReturnLine");

            migrationBuilder.AlterColumn<long>(
                name: "ItemId",
                schema: "Sales",
                table: "SalesReturnLine",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                schema: "Accounting",
                table: "PurchaseReturnLine",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<long>(
                name: "ItemId",
                schema: "Accounting",
                table: "PurchaseReturnLine",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "Accounting",
                table: "PurchaseReturnLine",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);
        }
    }
}
