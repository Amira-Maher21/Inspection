using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class GoodsIssueAndDeliveryNote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GoodsReceipt_Operation_OperationId",
                schema: "Inventory",
                table: "GoodsReceipt");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsReceipt_Supplier_SupplierId",
                schema: "Inventory",
                table: "GoodsReceipt");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsReceiptLine_UnitOfMeasure_UomId",
                schema: "Inventory",
                table: "GoodsReceiptLine");

            migrationBuilder.DropIndex(
                name: "IX_GoodsReceipt_OperationId",
                schema: "Inventory",
                table: "GoodsReceipt");

            migrationBuilder.DropIndex(
                name: "IX_GoodsReceipt_SupplierId",
                schema: "Inventory",
                table: "GoodsReceipt");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "Inventory",
                table: "GoodsReceiptLine");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                schema: "Inventory",
                table: "GoodsReceipt");

            migrationBuilder.DropColumn(
                name: "Description",
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
                name: "OperationId",
                schema: "Inventory",
                table: "GoodsReceipt");

            migrationBuilder.DropColumn(
                name: "PostingDate",
                schema: "Inventory",
                table: "GoodsReceipt");

            migrationBuilder.DropColumn(
                name: "PurshseOrderNumber",
                schema: "Inventory",
                table: "GoodsReceipt");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "Inventory",
                table: "GoodsReceipt");

            migrationBuilder.DropColumn(
                name: "SupplierId",
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

            migrationBuilder.RenameColumn(
                name: "UomId",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                newName: "UnitOfMeasureId");

            migrationBuilder.RenameColumn(
                name: "UnitCost",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                newName: "Cost");

            migrationBuilder.RenameIndex(
                name: "IX_GoodsReceiptLine_UomId",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                newName: "IX_GoodsReceiptLine_UnitOfMeasureId");

            migrationBuilder.RenameColumn(
                name: "ReceiptDate",
                schema: "Inventory",
                table: "GoodsReceipt",
                newName: "GoodsReceiptDate");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                schema: "Accounting",
                table: "PurchaseInvoiceAdjustment",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<long>(
                name: "CostCenterId",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CostUnitId",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "FreeItem",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "WarehouseId",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GoodsReceiptNo",
                schema: "Inventory",
                table: "GoodsReceipt",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                schema: "Inventory",
                table: "GoodsReceipt",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceiptLine_CostCenterId",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceiptLine_CostUnitId",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                column: "CostUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceiptLine_OperationId",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceiptLine_WarehouseId",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "UQ_GoodsReceipt_No",
                schema: "Inventory",
                table: "GoodsReceipt",
                column: "GoodsReceiptNo",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsReceiptLine_CostCenter_CostCenterId",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                column: "CostCenterId",
                principalSchema: "Accounting",
                principalTable: "CostCenter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsReceiptLine_CostUnit_CostUnitId",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                column: "CostUnitId",
                principalSchema: "Accounting",
                principalTable: "CostUnit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsReceiptLine_Operation_OperationId",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                column: "OperationId",
                principalSchema: "Sec",
                principalTable: "Operation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsReceiptLine_UnitOfMeasure_UnitOfMeasureId",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                column: "UnitOfMeasureId",
                principalSchema: "Inventory",
                principalTable: "UnitOfMeasure",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsReceiptLine_Warehouse_WarehouseId",
                schema: "Inventory",
                table: "GoodsReceiptLine",
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
                name: "FK_GoodsReceiptLine_CostCenter_CostCenterId",
                schema: "Inventory",
                table: "GoodsReceiptLine");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsReceiptLine_CostUnit_CostUnitId",
                schema: "Inventory",
                table: "GoodsReceiptLine");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsReceiptLine_Operation_OperationId",
                schema: "Inventory",
                table: "GoodsReceiptLine");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsReceiptLine_UnitOfMeasure_UnitOfMeasureId",
                schema: "Inventory",
                table: "GoodsReceiptLine");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsReceiptLine_Warehouse_WarehouseId",
                schema: "Inventory",
                table: "GoodsReceiptLine");

            migrationBuilder.DropIndex(
                name: "IX_GoodsReceiptLine_CostCenterId",
                schema: "Inventory",
                table: "GoodsReceiptLine");

            migrationBuilder.DropIndex(
                name: "IX_GoodsReceiptLine_CostUnitId",
                schema: "Inventory",
                table: "GoodsReceiptLine");

            migrationBuilder.DropIndex(
                name: "IX_GoodsReceiptLine_OperationId",
                schema: "Inventory",
                table: "GoodsReceiptLine");

            migrationBuilder.DropIndex(
                name: "IX_GoodsReceiptLine_WarehouseId",
                schema: "Inventory",
                table: "GoodsReceiptLine");

            migrationBuilder.DropIndex(
                name: "UQ_GoodsReceipt_No",
                schema: "Inventory",
                table: "GoodsReceipt");

            migrationBuilder.DropColumn(
                name: "CostCenterId",
                schema: "Inventory",
                table: "GoodsReceiptLine");

            migrationBuilder.DropColumn(
                name: "CostUnitId",
                schema: "Inventory",
                table: "GoodsReceiptLine");

            migrationBuilder.DropColumn(
                name: "FreeItem",
                schema: "Inventory",
                table: "GoodsReceiptLine");

            migrationBuilder.DropColumn(
                name: "Notes",
                schema: "Inventory",
                table: "GoodsReceiptLine");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                schema: "Inventory",
                table: "GoodsReceiptLine");

            migrationBuilder.DropColumn(
                name: "GoodsReceiptNo",
                schema: "Inventory",
                table: "GoodsReceipt");

            migrationBuilder.DropColumn(
                name: "Notes",
                schema: "Inventory",
                table: "GoodsReceipt");

            migrationBuilder.RenameColumn(
                name: "UnitOfMeasureId",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                newName: "UomId");

            migrationBuilder.RenameColumn(
                name: "Cost",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                newName: "UnitCost");

            migrationBuilder.RenameIndex(
                name: "IX_GoodsReceiptLine_UnitOfMeasureId",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                newName: "IX_GoodsReceiptLine_UomId");

            migrationBuilder.RenameColumn(
                name: "GoodsReceiptDate",
                schema: "Inventory",
                table: "GoodsReceipt",
                newName: "ReceiptDate");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "Accounting",
                table: "PurchaseInvoiceAdjustment",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CurrencyId",
                schema: "Inventory",
                table: "GoodsReceipt",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "Inventory",
                table: "GoodsReceipt",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

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

            migrationBuilder.AddColumn<long>(
                name: "OperationId",
                schema: "Inventory",
                table: "GoodsReceipt",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostingDate",
                schema: "Inventory",
                table: "GoodsReceipt",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PurshseOrderNumber",
                schema: "Inventory",
                table: "GoodsReceipt",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                schema: "Inventory",
                table: "GoodsReceipt",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "SupplierId",
                schema: "Inventory",
                table: "GoodsReceipt",
                type: "bigint",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceipt_OperationId",
                schema: "Inventory",
                table: "GoodsReceipt",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceipt_SupplierId",
                schema: "Inventory",
                table: "GoodsReceipt",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsReceipt_Operation_OperationId",
                schema: "Inventory",
                table: "GoodsReceipt",
                column: "OperationId",
                principalSchema: "Sec",
                principalTable: "Operation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsReceipt_Supplier_SupplierId",
                schema: "Inventory",
                table: "GoodsReceipt",
                column: "SupplierId",
                principalSchema: "Accounting",
                principalTable: "Supplier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsReceiptLine_UnitOfMeasure_UomId",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                column: "UomId",
                principalSchema: "Inventory",
                principalTable: "UnitOfMeasure",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
