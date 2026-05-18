using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DeliveryNotePaymentTermsId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryNote_Branch_BranchId",
                table: "DeliveryNote");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryNote_Currency_CurrencyId",
                table: "DeliveryNote");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryNote_Customer_CustomerId",
                table: "DeliveryNote");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryNote_PaymentTerm_PaymentTermId",
                table: "DeliveryNote");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryNote_SalesInvoice_SalesInvoiceId",
                table: "DeliveryNote");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryNote_SalesOrder_SalesOrderId",
                table: "DeliveryNote");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryNote_Series_SeriesId",
                table: "DeliveryNote");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryNote_Warehouse_WarehouseId",
                table: "DeliveryNote");

            migrationBuilder.DropColumn(
                name: "PaymentTermsId",
                table: "DeliveryNote");

            migrationBuilder.RenameTable(
                name: "DeliveryNote",
                newName: "DeliveryNote",
                newSchema: "Sales");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalDiscount",
                schema: "Sales",
                table: "DeliveryNote",
                type: "decimal(18,6)",
                precision: 18,
                scale: 6,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalAmount",
                schema: "Sales",
                table: "DeliveryNote",
                type: "decimal(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Tenant_ID",
                schema: "Sales",
                table: "DeliveryNote",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TaxAmount",
                schema: "Sales",
                table: "DeliveryNote",
                type: "decimal(18,6)",
                precision: 18,
                scale: 6,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ShipmentAmount",
                schema: "Sales",
                table: "DeliveryNote",
                type: "decimal(18,6)",
                precision: 18,
                scale: 6,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ShipmentAddress",
                schema: "Sales",
                table: "DeliveryNote",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                schema: "Sales",
                table: "DeliveryNote",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<decimal>(
                name: "NetAmount",
                schema: "Sales",
                table: "DeliveryNote",
                type: "decimal(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Mod_User",
                schema: "Sales",
                table: "DeliveryNote",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "In_User",
                schema: "Sales",
                table: "DeliveryNote",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryPersonName",
                schema: "Sales",
                table: "DeliveryNote",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryNoteNo",
                schema: "Sales",
                table: "DeliveryNote",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerPurchaseOrder",
                schema: "Sales",
                table: "DeliveryNote",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<decimal>(
                name: "AdditionalDiscountValue",
                schema: "Sales",
                table: "DeliveryNote",
                type: "decimal(18,6)",
                precision: 18,
                scale: 6,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "AdditionalDiscountAmount",
                schema: "Sales",
                table: "DeliveryNote",
                type: "decimal(18,6)",
                precision: 18,
                scale: 6,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryNote_Branch_BranchId",
                schema: "Sales",
                table: "DeliveryNote",
                column: "BranchId",
                principalSchema: "Accounting",
                principalTable: "Branch",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryNote_Currency_CurrencyId",
                schema: "Sales",
                table: "DeliveryNote",
                column: "CurrencyId",
                principalSchema: "Sec",
                principalTable: "Currency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryNote_Customer_CustomerId",
                schema: "Sales",
                table: "DeliveryNote",
                column: "CustomerId",
                principalSchema: "Accounting",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryNote_PaymentTerm_PaymentTermId",
                schema: "Sales",
                table: "DeliveryNote",
                column: "PaymentTermId",
                principalSchema: "Accounting",
                principalTable: "PaymentTerm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryNote_SalesInvoice_SalesInvoiceId",
                schema: "Sales",
                table: "DeliveryNote",
                column: "SalesInvoiceId",
                principalSchema: "Accounting",
                principalTable: "SalesInvoice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryNote_SalesOrder_SalesOrderId",
                schema: "Sales",
                table: "DeliveryNote",
                column: "SalesOrderId",
                principalSchema: "Sales",
                principalTable: "SalesOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryNote_Series_SeriesId",
                schema: "Sales",
                table: "DeliveryNote",
                column: "SeriesId",
                principalSchema: "Stt",
                principalTable: "Series",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryNote_Warehouse_WarehouseId",
                schema: "Sales",
                table: "DeliveryNote",
                column: "WarehouseId",
                principalSchema: "Inventory",
                principalTable: "Warehouse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryNote_Branch_BranchId",
                schema: "Sales",
                table: "DeliveryNote");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryNote_Currency_CurrencyId",
                schema: "Sales",
                table: "DeliveryNote");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryNote_Customer_CustomerId",
                schema: "Sales",
                table: "DeliveryNote");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryNote_PaymentTerm_PaymentTermId",
                schema: "Sales",
                table: "DeliveryNote");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryNote_SalesInvoice_SalesInvoiceId",
                schema: "Sales",
                table: "DeliveryNote");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryNote_SalesOrder_SalesOrderId",
                schema: "Sales",
                table: "DeliveryNote");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryNote_Series_SeriesId",
                schema: "Sales",
                table: "DeliveryNote");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryNote_Warehouse_WarehouseId",
                schema: "Sales",
                table: "DeliveryNote");

            migrationBuilder.RenameTable(
                name: "DeliveryNote",
                schema: "Sales",
                newName: "DeliveryNote");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalDiscount",
                table: "DeliveryNote",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)",
                oldPrecision: 18,
                oldScale: 6,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalAmount",
                table: "DeliveryNote",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)",
                oldPrecision: 18,
                oldScale: 6);

            migrationBuilder.AlterColumn<string>(
                name: "Tenant_ID",
                table: "DeliveryNote",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<decimal>(
                name: "TaxAmount",
                table: "DeliveryNote",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)",
                oldPrecision: 18,
                oldScale: 6,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ShipmentAmount",
                table: "DeliveryNote",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)",
                oldPrecision: 18,
                oldScale: 6,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ShipmentAddress",
                table: "DeliveryNote",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "DeliveryNote",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<decimal>(
                name: "NetAmount",
                table: "DeliveryNote",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)",
                oldPrecision: 18,
                oldScale: 6);

            migrationBuilder.AlterColumn<string>(
                name: "Mod_User",
                table: "DeliveryNote",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "In_User",
                table: "DeliveryNote",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryPersonName",
                table: "DeliveryNote",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryNoteNo",
                table: "DeliveryNote",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerPurchaseOrder",
                table: "DeliveryNote",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<decimal>(
                name: "AdditionalDiscountValue",
                table: "DeliveryNote",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)",
                oldPrecision: 18,
                oldScale: 6,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "AdditionalDiscountAmount",
                table: "DeliveryNote",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)",
                oldPrecision: 18,
                oldScale: 6,
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PaymentTermsId",
                table: "DeliveryNote",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryNote_Branch_BranchId",
                table: "DeliveryNote",
                column: "BranchId",
                principalSchema: "Accounting",
                principalTable: "Branch",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryNote_Currency_CurrencyId",
                table: "DeliveryNote",
                column: "CurrencyId",
                principalSchema: "Sec",
                principalTable: "Currency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryNote_Customer_CustomerId",
                table: "DeliveryNote",
                column: "CustomerId",
                principalSchema: "Accounting",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryNote_PaymentTerm_PaymentTermId",
                table: "DeliveryNote",
                column: "PaymentTermId",
                principalSchema: "Accounting",
                principalTable: "PaymentTerm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryNote_SalesInvoice_SalesInvoiceId",
                table: "DeliveryNote",
                column: "SalesInvoiceId",
                principalSchema: "Accounting",
                principalTable: "SalesInvoice",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryNote_SalesOrder_SalesOrderId",
                table: "DeliveryNote",
                column: "SalesOrderId",
                principalSchema: "Sales",
                principalTable: "SalesOrder",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryNote_Series_SeriesId",
                table: "DeliveryNote",
                column: "SeriesId",
                principalSchema: "Stt",
                principalTable: "Series",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryNote_Warehouse_WarehouseId",
                table: "DeliveryNote",
                column: "WarehouseId",
                principalSchema: "Inventory",
                principalTable: "Warehouse",
                principalColumn: "Id");
        }
    }
}
