using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Update2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsInclusive2",
                schema: "Sales",
                table: "SalesReturnLine",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TaxAmount2",
                schema: "Sales",
                table: "SalesReturnLine",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TaxRate2",
                schema: "Sales",
                table: "SalesReturnLine",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TaxType2Id",
                schema: "Sales",
                table: "SalesReturnLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TaxTypeId2",
                schema: "Sales",
                table: "SalesReturnLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsInclusive2",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TaxAmount2",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TaxRate2",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TaxType2Id",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TaxTypeId2",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsInclusive2",
                schema: "Accounting",
                table: "PurchaseReturnLine",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TaxAmount2",
                schema: "Accounting",
                table: "PurchaseReturnLine",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TaxRate2",
                schema: "Accounting",
                table: "PurchaseReturnLine",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TaxType2Id",
                schema: "Accounting",
                table: "PurchaseReturnLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TaxTypeId2",
                schema: "Accounting",
                table: "PurchaseReturnLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsInclusive2",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TaxAmount2",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TaxRate2",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TaxType2Id",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TaxTypeId2",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsInclusive2",
                schema: "Accounting",
                table: "DebitNoteLine",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TaxAmount2",
                schema: "Accounting",
                table: "DebitNoteLine",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TaxRate2",
                schema: "Accounting",
                table: "DebitNoteLine",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TaxTypeId2",
                schema: "Accounting",
                table: "DebitNoteLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsInclusive2",
                schema: "Accounting",
                table: "CreditNoteLine",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TaxAmount2",
                schema: "Accounting",
                table: "CreditNoteLine",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TaxRate2",
                schema: "Accounting",
                table: "CreditNoteLine",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TaxType2Id",
                schema: "Accounting",
                table: "CreditNoteLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TaxTypeId2",
                schema: "Accounting",
                table: "CreditNoteLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnLine_TaxType2Id",
                schema: "Sales",
                table: "SalesReturnLine",
                column: "TaxType2Id");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceLine_TaxType2Id",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                column: "TaxType2Id");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnLine_TaxType2Id",
                schema: "Accounting",
                table: "PurchaseReturnLine",
                column: "TaxType2Id");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceLine_TaxType2Id",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                column: "TaxType2Id");

            migrationBuilder.CreateIndex(
                name: "IX_CreditNoteLine_TaxType2Id",
                schema: "Accounting",
                table: "CreditNoteLine",
                column: "TaxType2Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CreditNoteLine_TaxType_TaxType2Id",
                schema: "Accounting",
                table: "CreditNoteLine",
                column: "TaxType2Id",
                principalSchema: "Accounting",
                principalTable: "TaxType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseInvoiceLine_TaxType_TaxType2Id",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                column: "TaxType2Id",
                principalSchema: "Accounting",
                principalTable: "TaxType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseReturnLine_TaxType_TaxType2Id",
                schema: "Accounting",
                table: "PurchaseReturnLine",
                column: "TaxType2Id",
                principalSchema: "Accounting",
                principalTable: "TaxType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesInvoiceLine_TaxType_TaxType2Id",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                column: "TaxType2Id",
                principalSchema: "Accounting",
                principalTable: "TaxType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesReturnLine_TaxType_TaxType2Id",
                schema: "Sales",
                table: "SalesReturnLine",
                column: "TaxType2Id",
                principalSchema: "Accounting",
                principalTable: "TaxType",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreditNoteLine_TaxType_TaxType2Id",
                schema: "Accounting",
                table: "CreditNoteLine");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseInvoiceLine_TaxType_TaxType2Id",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseReturnLine_TaxType_TaxType2Id",
                schema: "Accounting",
                table: "PurchaseReturnLine");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesInvoiceLine_TaxType_TaxType2Id",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesReturnLine_TaxType_TaxType2Id",
                schema: "Sales",
                table: "SalesReturnLine");

            migrationBuilder.DropIndex(
                name: "IX_SalesReturnLine_TaxType2Id",
                schema: "Sales",
                table: "SalesReturnLine");

            migrationBuilder.DropIndex(
                name: "IX_SalesInvoiceLine_TaxType2Id",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseReturnLine_TaxType2Id",
                schema: "Accounting",
                table: "PurchaseReturnLine");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseInvoiceLine_TaxType2Id",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropIndex(
                name: "IX_CreditNoteLine_TaxType2Id",
                schema: "Accounting",
                table: "CreditNoteLine");

            migrationBuilder.DropColumn(
                name: "IsInclusive2",
                schema: "Sales",
                table: "SalesReturnLine");

            migrationBuilder.DropColumn(
                name: "TaxAmount2",
                schema: "Sales",
                table: "SalesReturnLine");

            migrationBuilder.DropColumn(
                name: "TaxRate2",
                schema: "Sales",
                table: "SalesReturnLine");

            migrationBuilder.DropColumn(
                name: "TaxType2Id",
                schema: "Sales",
                table: "SalesReturnLine");

            migrationBuilder.DropColumn(
                name: "TaxTypeId2",
                schema: "Sales",
                table: "SalesReturnLine");

            migrationBuilder.DropColumn(
                name: "IsInclusive2",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropColumn(
                name: "TaxAmount2",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropColumn(
                name: "TaxRate2",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropColumn(
                name: "TaxType2Id",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropColumn(
                name: "TaxTypeId2",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropColumn(
                name: "IsInclusive2",
                schema: "Accounting",
                table: "PurchaseReturnLine");

            migrationBuilder.DropColumn(
                name: "TaxAmount2",
                schema: "Accounting",
                table: "PurchaseReturnLine");

            migrationBuilder.DropColumn(
                name: "TaxRate2",
                schema: "Accounting",
                table: "PurchaseReturnLine");

            migrationBuilder.DropColumn(
                name: "TaxType2Id",
                schema: "Accounting",
                table: "PurchaseReturnLine");

            migrationBuilder.DropColumn(
                name: "TaxTypeId2",
                schema: "Accounting",
                table: "PurchaseReturnLine");

            migrationBuilder.DropColumn(
                name: "IsInclusive2",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropColumn(
                name: "TaxAmount2",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropColumn(
                name: "TaxRate2",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropColumn(
                name: "TaxType2Id",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropColumn(
                name: "TaxTypeId2",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropColumn(
                name: "IsInclusive2",
                schema: "Accounting",
                table: "DebitNoteLine");

            migrationBuilder.DropColumn(
                name: "TaxAmount2",
                schema: "Accounting",
                table: "DebitNoteLine");

            migrationBuilder.DropColumn(
                name: "TaxRate2",
                schema: "Accounting",
                table: "DebitNoteLine");

            migrationBuilder.DropColumn(
                name: "TaxTypeId2",
                schema: "Accounting",
                table: "DebitNoteLine");

            migrationBuilder.DropColumn(
                name: "IsInclusive2",
                schema: "Accounting",
                table: "CreditNoteLine");

            migrationBuilder.DropColumn(
                name: "TaxAmount2",
                schema: "Accounting",
                table: "CreditNoteLine");

            migrationBuilder.DropColumn(
                name: "TaxRate2",
                schema: "Accounting",
                table: "CreditNoteLine");

            migrationBuilder.DropColumn(
                name: "TaxType2Id",
                schema: "Accounting",
                table: "CreditNoteLine");

            migrationBuilder.DropColumn(
                name: "TaxTypeId2",
                schema: "Accounting",
                table: "CreditNoteLine");
        }
    }
}
