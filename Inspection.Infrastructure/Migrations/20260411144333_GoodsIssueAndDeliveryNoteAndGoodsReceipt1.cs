using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class GoodsIssueAndDeliveryNoteAndGoodsReceipt1 : Migration
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
                name: "IX_GoodsReceipt_Company_Tenant",
                schema: "Inventory",
                table: "GoodsReceipt");

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
                name: "UnitCost",
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

            migrationBuilder.RenameIndex(
                name: "UQ_GoodsReceiptLine_NoDuplicate",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                newName: "IX_GoodsReceiptLine_GoodsReceiptId_ItemId_WarehouseLocationId");

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

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalCost",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                type: "decimal(18,6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                type: "decimal(18,6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Mod_User",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "In_User",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<decimal>(
                name: "Cost",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                type: "decimal(18,6)",
                nullable: false,
                defaultValue: 0m);

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
                nullable: true);

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

            migrationBuilder.AlterColumn<long>(
                name: "WarehouseId",
                schema: "Inventory",
                table: "GoodsReceipt",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "Tenant_ID",
                schema: "Inventory",
                table: "GoodsReceipt",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "Posting",
                schema: "Inventory",
                table: "GoodsReceipt",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Mod_User",
                schema: "Inventory",
                table: "GoodsReceipt",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "In_User",
                schema: "Inventory",
                table: "GoodsReceipt",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DeliveryNote",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryNoteNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    BranchId = table.Column<long>(type: "bigint", nullable: false),
                    WarehouseId = table.Column<long>(type: "bigint", nullable: true),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    DeliveryNoteDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SalesOrderId = table.Column<long>(type: "bigint", nullable: true),
                    SalesInvoiceId = table.Column<long>(type: "bigint", nullable: true),
                    CurrencyId = table.Column<long>(type: "bigint", nullable: false),
                    PaymentTermsId = table.Column<long>(type: "bigint", nullable: false),
                    PaymentTermId = table.Column<long>(type: "bigint", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Posting = table.Column<int>(type: "int", nullable: false),
                    CustomerPurchaseOrder = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerPurchaseOrderDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AdditionalDiscountType = table.Column<int>(type: "int", nullable: true),
                    AdditionalDiscountValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AdditionalDiscountAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ShipmentAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ShipmentAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShipmentStatus = table.Column<int>(type: "int", nullable: false),
                    ShipmentMethod = table.Column<int>(type: "int", nullable: false),
                    DeliveryPersonName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeriesId = table.Column<long>(type: "bigint", nullable: true),
                    RunningNumber = table.Column<int>(type: "int", nullable: false),
                    ApprovalStatus = table.Column<int>(type: "int", nullable: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryNote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryNote_Branch_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "Accounting",
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeliveryNote_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalSchema: "Sec",
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeliveryNote_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Accounting",
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeliveryNote_PaymentTerm_PaymentTermId",
                        column: x => x.PaymentTermId,
                        principalSchema: "Accounting",
                        principalTable: "PaymentTerm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeliveryNote_SalesInvoice_SalesInvoiceId",
                        column: x => x.SalesInvoiceId,
                        principalSchema: "Accounting",
                        principalTable: "SalesInvoice",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DeliveryNote_SalesOrder_SalesOrderId",
                        column: x => x.SalesOrderId,
                        principalSchema: "Sales",
                        principalTable: "SalesOrder",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DeliveryNote_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalSchema: "Stt",
                        principalTable: "Series",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DeliveryNote_Warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalSchema: "Inventory",
                        principalTable: "Warehouse",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GoodsIssue",
                schema: "Inventory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GoodsIssueNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BranchId = table.Column<long>(type: "bigint", nullable: false),
                    WarehouseId = table.Column<long>(type: "bigint", nullable: true),
                    GoodsIssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Posting = table.Column<int>(type: "int", nullable: true),
                    ApprovalStatus = table.Column<int>(type: "int", nullable: false),
                    DocumentStatus = table.Column<int>(type: "int", nullable: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    SeriesId = table.Column<long>(type: "bigint", nullable: true),
                    RunningNumber = table.Column<int>(type: "int", nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsIssue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GoodsIssue_Branch_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "Accounting",
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GoodsIssue_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalSchema: "Stt",
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GoodsIssue_Warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalSchema: "Inventory",
                        principalTable: "Warehouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryNoteLine",
                schema: "Sales",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryNoteId = table.Column<long>(type: "bigint", nullable: false),
                    ItemId = table.Column<long>(type: "bigint", nullable: false),
                    UnitOfMeasureId = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: true),
                    TaxTypeId = table.Column<long>(type: "bigint", nullable: true),
                    TaxRate = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: true),
                    IsInclusive = table.Column<bool>(type: "bit", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: true),
                    DiscountType = table.Column<int>(type: "int", nullable: true),
                    DiscountValue = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: true),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: true),
                    WarehouseId = table.Column<long>(type: "bigint", nullable: true),
                    WarehouseLocationId = table.Column<long>(type: "bigint", nullable: true),
                    FreeItem = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CostCenterId = table.Column<long>(type: "bigint", nullable: true),
                    CostUnitId = table.Column<long>(type: "bigint", nullable: true),
                    OperationId = table.Column<long>(type: "bigint", nullable: true),
                    WBSId = table.Column<long>(type: "bigint", nullable: true),
                    CostCodeId = table.Column<long>(type: "bigint", nullable: true),
                    ActivityId = table.Column<long>(type: "bigint", nullable: true),
                    BOQItemId = table.Column<long>(type: "bigint", nullable: true),
                    SubcontractBOQId = table.Column<long>(type: "bigint", nullable: true),
                    ProductionOrderId = table.Column<long>(type: "bigint", nullable: true),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryNoteLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryNoteLine_CostCenter_CostCenterId",
                        column: x => x.CostCenterId,
                        principalSchema: "Accounting",
                        principalTable: "CostCenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryNoteLine_CostUnit_CostUnitId",
                        column: x => x.CostUnitId,
                        principalSchema: "Accounting",
                        principalTable: "CostUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryNoteLine_DeliveryNote_DeliveryNoteId",
                        column: x => x.DeliveryNoteId,
                        principalTable: "DeliveryNote",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeliveryNoteLine_Item_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "Inventory",
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryNoteLine_Operation_OperationId",
                        column: x => x.OperationId,
                        principalSchema: "Sec",
                        principalTable: "Operation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryNoteLine_TaxType_TaxTypeId",
                        column: x => x.TaxTypeId,
                        principalSchema: "Accounting",
                        principalTable: "TaxType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryNoteLine_UnitOfMeasure_UnitOfMeasureId",
                        column: x => x.UnitOfMeasureId,
                        principalSchema: "Inventory",
                        principalTable: "UnitOfMeasure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryNoteLine_WarehouseLocation_WarehouseLocationId",
                        column: x => x.WarehouseLocationId,
                        principalSchema: "Inventory",
                        principalTable: "WarehouseLocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryNoteLine_Warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalSchema: "Inventory",
                        principalTable: "Warehouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GoodsIssueLine",
                schema: "Inventory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GoodsIssueId = table.Column<long>(type: "bigint", nullable: false),
                    ItemId = table.Column<long>(type: "bigint", nullable: false),
                    UnitOfMeasureId = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: true),
                    WarehouseId = table.Column<long>(type: "bigint", nullable: true),
                    WarehouseLocationId = table.Column<long>(type: "bigint", nullable: true),
                    FreeItem = table.Column<bool>(type: "bit", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CostCenterId = table.Column<long>(type: "bigint", nullable: true),
                    CostUnitId = table.Column<long>(type: "bigint", nullable: true),
                    OperationId = table.Column<long>(type: "bigint", nullable: true),
                    WBSId = table.Column<long>(type: "bigint", nullable: true),
                    CostCodeId = table.Column<long>(type: "bigint", nullable: true),
                    ActivityId = table.Column<long>(type: "bigint", nullable: true),
                    BOQItemId = table.Column<long>(type: "bigint", nullable: true),
                    SubcontractBOQId = table.Column<long>(type: "bigint", nullable: true),
                    ProductionOrderId = table.Column<long>(type: "bigint", nullable: true),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsIssueLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GoodsIssueLine_CostCenter_CostCenterId",
                        column: x => x.CostCenterId,
                        principalSchema: "Accounting",
                        principalTable: "CostCenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GoodsIssueLine_CostUnit_CostUnitId",
                        column: x => x.CostUnitId,
                        principalSchema: "Accounting",
                        principalTable: "CostUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GoodsIssueLine_GoodsIssue_GoodsIssueId",
                        column: x => x.GoodsIssueId,
                        principalSchema: "Inventory",
                        principalTable: "GoodsIssue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GoodsIssueLine_Item_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "Inventory",
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GoodsIssueLine_Operation_OperationId",
                        column: x => x.OperationId,
                        principalSchema: "Sec",
                        principalTable: "Operation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GoodsIssueLine_UnitOfMeasure_UnitOfMeasureId",
                        column: x => x.UnitOfMeasureId,
                        principalSchema: "Inventory",
                        principalTable: "UnitOfMeasure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GoodsIssueLine_WarehouseLocation_WarehouseLocationId",
                        column: x => x.WarehouseLocationId,
                        principalSchema: "Inventory",
                        principalTable: "WarehouseLocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GoodsIssueLine_Warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalSchema: "Inventory",
                        principalTable: "Warehouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "IX_GoodsReceipt_Tenant_ID_CompanyId_GoodsReceiptNo",
                schema: "Inventory",
                table: "GoodsReceipt",
                columns: new[] { "Tenant_ID", "CompanyId", "GoodsReceiptNo" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryNote_BranchId",
                table: "DeliveryNote",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryNote_CurrencyId",
                table: "DeliveryNote",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryNote_CustomerId",
                table: "DeliveryNote",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryNote_PaymentTermId",
                table: "DeliveryNote",
                column: "PaymentTermId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryNote_SalesInvoiceId",
                table: "DeliveryNote",
                column: "SalesInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryNote_SalesOrderId",
                table: "DeliveryNote",
                column: "SalesOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryNote_SeriesId",
                table: "DeliveryNote",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryNote_WarehouseId",
                table: "DeliveryNote",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryNoteLine_CostCenterId",
                schema: "Sales",
                table: "DeliveryNoteLine",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryNoteLine_CostUnitId",
                schema: "Sales",
                table: "DeliveryNoteLine",
                column: "CostUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryNoteLine_DeliveryNoteId",
                schema: "Sales",
                table: "DeliveryNoteLine",
                column: "DeliveryNoteId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryNoteLine_ItemId",
                schema: "Sales",
                table: "DeliveryNoteLine",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryNoteLine_OperationId",
                schema: "Sales",
                table: "DeliveryNoteLine",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryNoteLine_TaxTypeId",
                schema: "Sales",
                table: "DeliveryNoteLine",
                column: "TaxTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryNoteLine_UnitOfMeasureId",
                schema: "Sales",
                table: "DeliveryNoteLine",
                column: "UnitOfMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryNoteLine_WarehouseId",
                schema: "Sales",
                table: "DeliveryNoteLine",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryNoteLine_WarehouseLocationId",
                schema: "Sales",
                table: "DeliveryNoteLine",
                column: "WarehouseLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsIssue_BranchId",
                schema: "Inventory",
                table: "GoodsIssue",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsIssue_SeriesId",
                schema: "Inventory",
                table: "GoodsIssue",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsIssue_Tenant_ID_CompanyId_GoodsIssueNo",
                schema: "Inventory",
                table: "GoodsIssue",
                columns: new[] { "Tenant_ID", "CompanyId", "GoodsIssueNo" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GoodsIssue_WarehouseId",
                schema: "Inventory",
                table: "GoodsIssue",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsIssueLine_CostCenterId",
                schema: "Inventory",
                table: "GoodsIssueLine",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsIssueLine_CostUnitId",
                schema: "Inventory",
                table: "GoodsIssueLine",
                column: "CostUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsIssueLine_ItemId",
                schema: "Inventory",
                table: "GoodsIssueLine",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsIssueLine_Main",
                schema: "Inventory",
                table: "GoodsIssueLine",
                columns: new[] { "GoodsIssueId", "ItemId", "WarehouseLocationId" });

            migrationBuilder.CreateIndex(
                name: "IX_GoodsIssueLine_OperationId",
                schema: "Inventory",
                table: "GoodsIssueLine",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsIssueLine_UnitOfMeasureId",
                schema: "Inventory",
                table: "GoodsIssueLine",
                column: "UnitOfMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsIssueLine_WarehouseId",
                schema: "Inventory",
                table: "GoodsIssueLine",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsIssueLine_WarehouseLocationId",
                schema: "Inventory",
                table: "GoodsIssueLine",
                column: "WarehouseLocationId");

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

            migrationBuilder.DropTable(
                name: "DeliveryNoteLine",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "GoodsIssueLine",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "DeliveryNote");

            migrationBuilder.DropTable(
                name: "GoodsIssue",
                schema: "Inventory");

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
                name: "IX_GoodsReceipt_Tenant_ID_CompanyId_GoodsReceiptNo",
                schema: "Inventory",
                table: "GoodsReceipt");

            migrationBuilder.DropColumn(
                name: "Cost",
                schema: "Inventory",
                table: "GoodsReceiptLine");

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

            migrationBuilder.RenameIndex(
                name: "IX_GoodsReceiptLine_UnitOfMeasureId",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                newName: "IX_GoodsReceiptLine_UomId");

            migrationBuilder.RenameIndex(
                name: "IX_GoodsReceiptLine_GoodsReceiptId_ItemId_WarehouseLocationId",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                newName: "UQ_GoodsReceiptLine_NoDuplicate");

            migrationBuilder.RenameColumn(
                name: "GoodsReceiptDate",
                schema: "Inventory",
                table: "GoodsReceipt",
                newName: "ReceiptDate");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalCost",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)");

            migrationBuilder.AlterColumn<string>(
                name: "Mod_User",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "In_User",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "UnitCost",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<long>(
                name: "WarehouseId",
                schema: "Inventory",
                table: "GoodsReceipt",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Tenant_ID",
                schema: "Inventory",
                table: "GoodsReceipt",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<int>(
                name: "Posting",
                schema: "Inventory",
                table: "GoodsReceipt",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Mod_User",
                schema: "Inventory",
                table: "GoodsReceipt",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "In_User",
                schema: "Inventory",
                table: "GoodsReceipt",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

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
                name: "IX_GoodsReceipt_Company_Tenant",
                schema: "Inventory",
                table: "GoodsReceipt",
                columns: new[] { "CompanyId", "Tenant_ID" });

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
