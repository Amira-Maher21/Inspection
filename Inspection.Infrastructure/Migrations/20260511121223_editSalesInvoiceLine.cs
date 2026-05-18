using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class editSalesInvoiceLine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                schema: "Accounting",
                table: "SalesInvoiceLine",
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
                table: "SalesInvoiceLine",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "AssetId",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AssetTransactionType",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LineType",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceLine_AssetId",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                column: "AssetId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesInvoiceLine_FixedAsset_AssetId",
                schema: "Accounting",
                table: "SalesInvoiceLine",
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
                name: "FK_SalesInvoiceLine_FixedAsset_AssetId",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropIndex(
                name: "IX_SalesInvoiceLine_AssetId",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropColumn(
                name: "AssetId",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropColumn(
                name: "AssetTransactionType",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropColumn(
                name: "LineType",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<long>(
                name: "ItemId",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);
        }
    }
}
