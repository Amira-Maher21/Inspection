using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SalesInvoiceAndList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Cost",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                type: "decimal(18,6)",
                precision: 18,
                scale: 6,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                type: "decimal(5,2)",
                precision: 5,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ItemId",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Quantity",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                type: "decimal(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TaxRate",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                type: "decimal(5,2)",
                precision: 5,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                type: "decimal(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<long>(
                name: "UnitOfMeasureId",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<decimal>(
                name: "UnitPrice",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                type: "decimal(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<long>(
                name: "WarehouseLocationId",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Mod_User",
                schema: "Accounting",
                table: "SalesInvoice",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "In_User",
                schema: "Accounting",
                table: "SalesInvoice",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "ApprovalStatus",
                schema: "Accounting",
                table: "SalesInvoice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "BranchId",
                schema: "Accounting",
                table: "SalesInvoice",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CurrencyId",
                schema: "Accounting",
                table: "SalesInvoice",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CustomerId",
                schema: "Accounting",
                table: "SalesInvoice",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "DocumentStatus",
                schema: "Accounting",
                table: "SalesInvoice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "GoodsReceiptId",
                schema: "Accounting",
                table: "SalesInvoice",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InvoiceDate",
                schema: "Accounting",
                table: "SalesInvoice",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "InvoiceNo",
                schema: "Accounting",
                table: "SalesInvoice",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsPosted",
                schema: "Accounting",
                table: "SalesInvoice",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                schema: "Accounting",
                table: "SalesInvoice",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PaymentTermsId",
                schema: "Accounting",
                table: "SalesInvoice",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostingDate",
                schema: "Accounting",
                table: "SalesInvoice",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "SalesOrderId",
                schema: "Accounting",
                table: "SalesInvoice",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TaxAmount",
                schema: "Accounting",
                table: "SalesInvoice",
                type: "decimal(18,6)",
                precision: 18,
                scale: 6,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                schema: "Accounting",
                table: "SalesInvoice",
                type: "decimal(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceLine_ItemId",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceLine_UnitOfMeasureId",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                column: "UnitOfMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceLine_WarehouseLocationId",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                column: "WarehouseLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoice_CurrencyId",
                schema: "Accounting",
                table: "SalesInvoice",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoice_CustomerId",
                schema: "Accounting",
                table: "SalesInvoice",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoice_GoodsReceiptId",
                schema: "Accounting",
                table: "SalesInvoice",
                column: "GoodsReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoice_InvoiceDate",
                schema: "Accounting",
                table: "SalesInvoice",
                column: "InvoiceDate");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoice_PaymentTermsId",
                schema: "Accounting",
                table: "SalesInvoice",
                column: "PaymentTermsId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoice_SalesOrderId",
                schema: "Accounting",
                table: "SalesInvoice",
                column: "SalesOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesInvoice_Currency_CurrencyId",
                schema: "Accounting",
                table: "SalesInvoice",
                column: "CurrencyId",
                principalSchema: "Sec",
                principalTable: "Currency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesInvoice_Customer_CustomerId",
                schema: "Accounting",
                table: "SalesInvoice",
                column: "CustomerId",
                principalSchema: "Accounting",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesInvoice_GoodsReceipt_GoodsReceiptId",
                schema: "Accounting",
                table: "SalesInvoice",
                column: "GoodsReceiptId",
                principalSchema: "Inventory",
                principalTable: "GoodsReceipt",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesInvoice_PaymentTerm_PaymentTermsId",
                schema: "Accounting",
                table: "SalesInvoice",
                column: "PaymentTermsId",
                principalSchema: "Accounting",
                principalTable: "PaymentTerm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesInvoice_SalesOrder_SalesOrderId",
                schema: "Accounting",
                table: "SalesInvoice",
                column: "SalesOrderId",
                principalSchema: "Sales",
                principalTable: "SalesOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesInvoiceLine_Item_ItemId",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                column: "ItemId",
                principalSchema: "Inventory",
                principalTable: "Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesInvoiceLine_UnitOfMeasure_UnitOfMeasureId",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                column: "UnitOfMeasureId",
                principalSchema: "Inventory",
                principalTable: "UnitOfMeasure",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesInvoiceLine_WarehouseLocation_WarehouseLocationId",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                column: "WarehouseLocationId",
                principalSchema: "Inventory",
                principalTable: "WarehouseLocation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesInvoice_Currency_CurrencyId",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesInvoice_Customer_CustomerId",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesInvoice_GoodsReceipt_GoodsReceiptId",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesInvoice_PaymentTerm_PaymentTermsId",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesInvoice_SalesOrder_SalesOrderId",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesInvoiceLine_Item_ItemId",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesInvoiceLine_UnitOfMeasure_UnitOfMeasureId",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesInvoiceLine_WarehouseLocation_WarehouseLocationId",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropIndex(
                name: "IX_SalesInvoiceLine_ItemId",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropIndex(
                name: "IX_SalesInvoiceLine_UnitOfMeasureId",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropIndex(
                name: "IX_SalesInvoiceLine_WarehouseLocationId",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropIndex(
                name: "IX_SalesInvoice_CurrencyId",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.DropIndex(
                name: "IX_SalesInvoice_CustomerId",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.DropIndex(
                name: "IX_SalesInvoice_GoodsReceiptId",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.DropIndex(
                name: "IX_SalesInvoice_InvoiceDate",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.DropIndex(
                name: "IX_SalesInvoice_PaymentTermsId",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.DropIndex(
                name: "IX_SalesInvoice_SalesOrderId",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.DropColumn(
                name: "Cost",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropColumn(
                name: "Discount",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropColumn(
                name: "ItemId",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropColumn(
                name: "Notes",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropColumn(
                name: "Quantity",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropColumn(
                name: "TaxRate",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropColumn(
                name: "UnitOfMeasureId",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropColumn(
                name: "WarehouseLocationId",
                schema: "Accounting",
                table: "SalesInvoiceLine");

            migrationBuilder.DropColumn(
                name: "ApprovalStatus",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.DropColumn(
                name: "BranchId",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.DropColumn(
                name: "DocumentStatus",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.DropColumn(
                name: "GoodsReceiptId",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.DropColumn(
                name: "InvoiceDate",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.DropColumn(
                name: "InvoiceNo",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.DropColumn(
                name: "IsPosted",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.DropColumn(
                name: "Notes",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.DropColumn(
                name: "PaymentTermsId",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.DropColumn(
                name: "PostingDate",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.DropColumn(
                name: "SalesOrderId",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.DropColumn(
                name: "TaxAmount",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.AlterColumn<string>(
                name: "Mod_User",
                schema: "Accounting",
                table: "SalesInvoice",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "In_User",
                schema: "Accounting",
                table: "SalesInvoice",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
