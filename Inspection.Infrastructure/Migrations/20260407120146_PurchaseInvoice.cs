using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PurchaseInvoice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ActivityId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "BOQItemId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Cost",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                type: "decimal(18,6)",
                precision: 18,
                scale: 6,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CostCenterId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CostCodeId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CostUnitId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountAmount",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                type: "decimal(18,6)",
                precision: 18,
                scale: 6,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DiscountType",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountValue",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                type: "decimal(18,6)",
                precision: 18,
                scale: 6,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "FreeItem",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsInclusive",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "ItemId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "OperationId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ProductionOrderId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Quantity",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                type: "decimal(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<long>(
                name: "SubcontractBOQId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TaxAmount",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                type: "decimal(18,6)",
                precision: 18,
                scale: 6,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TaxRate",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                type: "decimal(5,2)",
                precision: 5,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TaxTypeId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                type: "decimal(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<long>(
                name: "UnitOfMeasureId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<decimal>(
                name: "UnitPrice",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                type: "decimal(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<long>(
                name: "WBSId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "WarehouseId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "WarehouseLocationId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Mod_User",
                schema: "Accounting",
                table: "PurchaseInvoice",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "In_User",
                schema: "Accounting",
                table: "PurchaseInvoice",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<decimal>(
                name: "AdditionalDiscountAmount",
                schema: "Accounting",
                table: "PurchaseInvoice",
                type: "decimal(18,6)",
                precision: 18,
                scale: 6,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdditionalDiscountType",
                schema: "Accounting",
                table: "PurchaseInvoice",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "AdditionalDiscountValue",
                schema: "Accounting",
                table: "PurchaseInvoice",
                type: "decimal(18,6)",
                precision: 18,
                scale: 6,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApprovalStatus",
                schema: "Accounting",
                table: "PurchaseInvoice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "BranchId",
                schema: "Accounting",
                table: "PurchaseInvoice",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CurrencyId",
                schema: "Accounting",
                table: "PurchaseInvoice",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "InvoiceDate",
                schema: "Accounting",
                table: "PurchaseInvoice",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "InvoiceNo",
                schema: "Accounting",
                table: "PurchaseInvoice",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "NetAmount",
                schema: "Accounting",
                table: "PurchaseInvoice",
                type: "decimal(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                schema: "Accounting",
                table: "PurchaseInvoice",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PaymentDueDate",
                schema: "Accounting",
                table: "PurchaseInvoice",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "PaymentTermsId",
                schema: "Accounting",
                table: "PurchaseInvoice",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "Posting",
                schema: "Accounting",
                table: "PurchaseInvoice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "SalesOrderId",
                schema: "Accounting",
                table: "PurchaseInvoice",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SalesPersonId",
                schema: "Accounting",
                table: "PurchaseInvoice",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShipmentAddress",
                schema: "Accounting",
                table: "PurchaseInvoice",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ShipmentAmount",
                schema: "Accounting",
                table: "PurchaseInvoice",
                type: "decimal(18,6)",
                precision: 18,
                scale: 6,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShipmentMethod",
                schema: "Accounting",
                table: "PurchaseInvoice",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShipmentStatus",
                schema: "Accounting",
                table: "PurchaseInvoice",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                schema: "Accounting",
                table: "PurchaseInvoice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "SupplierId",
                schema: "Accounting",
                table: "PurchaseInvoice",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<decimal>(
                name: "TaxAmount",
                schema: "Accounting",
                table: "PurchaseInvoice",
                type: "decimal(18,6)",
                precision: 18,
                scale: 6,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                schema: "Accounting",
                table: "PurchaseInvoice",
                type: "decimal(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalDiscount",
                schema: "Accounting",
                table: "PurchaseInvoice",
                type: "decimal(18,6)",
                precision: 18,
                scale: 6,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "WarehouseId",
                schema: "Accounting",
                table: "PurchaseInvoice",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PurchaseInvoiceAdjustment",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PurchaseInvoiceId = table.Column<long>(type: "bigint", nullable: false),
                    ChartOfAccountId = table.Column<long>(type: "bigint", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CostCenterId = table.Column<long>(type: "bigint", nullable: false),
                    CostUnitId = table.Column<long>(type: "bigint", nullable: false),
                    OperationId = table.Column<long>(type: "bigint", nullable: false),
                    WBSId = table.Column<long>(type: "bigint", nullable: true),
                    CostCodeId = table.Column<long>(type: "bigint", nullable: true),
                    Activity = table.Column<bool>(type: "bit", nullable: true),
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
                    table.PrimaryKey("PK_PurchaseInvoiceAdjustment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseInvoiceAdjustment_ChartOfAccount_ChartOfAccountId",
                        column: x => x.ChartOfAccountId,
                        principalSchema: "Accounting",
                        principalTable: "ChartOfAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseInvoiceAdjustment_CostCenter_CostCenterId",
                        column: x => x.CostCenterId,
                        principalSchema: "Accounting",
                        principalTable: "CostCenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseInvoiceAdjustment_CostUnit_CostUnitId",
                        column: x => x.CostUnitId,
                        principalSchema: "Accounting",
                        principalTable: "CostUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseInvoiceAdjustment_Operation_OperationId",
                        column: x => x.OperationId,
                        principalSchema: "Sec",
                        principalTable: "Operation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseInvoiceAdjustment_PurchaseInvoice_PurchaseInvoiceId",
                        column: x => x.PurchaseInvoiceId,
                        principalSchema: "Accounting",
                        principalTable: "PurchaseInvoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceLine_CostCenterId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceLine_CostUnitId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                column: "CostUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceLine_ItemId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceLine_OperationId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceLine_TaxTypeId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                column: "TaxTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceLine_UnitOfMeasureId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                column: "UnitOfMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceLine_WarehouseId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceLine_WarehouseLocationId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                column: "WarehouseLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoice_BranchId",
                schema: "Accounting",
                table: "PurchaseInvoice",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoice_CurrencyId",
                schema: "Accounting",
                table: "PurchaseInvoice",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoice_PaymentTermsId",
                schema: "Accounting",
                table: "PurchaseInvoice",
                column: "PaymentTermsId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoice_SalesOrderId",
                schema: "Accounting",
                table: "PurchaseInvoice",
                column: "SalesOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoice_SalesPersonId",
                schema: "Accounting",
                table: "PurchaseInvoice",
                column: "SalesPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoice_SupplierId",
                schema: "Accounting",
                table: "PurchaseInvoice",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoice_Tenant_ID_CompanyId_InvoiceNo",
                schema: "Accounting",
                table: "PurchaseInvoice",
                columns: new[] { "Tenant_ID", "CompanyId", "InvoiceNo" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoice_WarehouseId",
                schema: "Accounting",
                table: "PurchaseInvoice",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceAdjustment_ChartOfAccountId",
                schema: "Accounting",
                table: "PurchaseInvoiceAdjustment",
                column: "ChartOfAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceAdjustment_CostCenterId",
                schema: "Accounting",
                table: "PurchaseInvoiceAdjustment",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceAdjustment_CostUnitId",
                schema: "Accounting",
                table: "PurchaseInvoiceAdjustment",
                column: "CostUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceAdjustment_OperationId",
                schema: "Accounting",
                table: "PurchaseInvoiceAdjustment",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceAdjustment_PurchaseInvoiceId",
                schema: "Accounting",
                table: "PurchaseInvoiceAdjustment",
                column: "PurchaseInvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseInvoice_Branch_BranchId",
                schema: "Accounting",
                table: "PurchaseInvoice",
                column: "BranchId",
                principalSchema: "Accounting",
                principalTable: "Branch",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseInvoice_Currency_CurrencyId",
                schema: "Accounting",
                table: "PurchaseInvoice",
                column: "CurrencyId",
                principalSchema: "Sec",
                principalTable: "Currency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseInvoice_PaymentTerm_PaymentTermsId",
                schema: "Accounting",
                table: "PurchaseInvoice",
                column: "PaymentTermsId",
                principalSchema: "Accounting",
                principalTable: "PaymentTerm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseInvoice_SalesOrder_SalesOrderId",
                schema: "Accounting",
                table: "PurchaseInvoice",
                column: "SalesOrderId",
                principalSchema: "Sales",
                principalTable: "SalesOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseInvoice_SalesPerson_SalesPersonId",
                schema: "Accounting",
                table: "PurchaseInvoice",
                column: "SalesPersonId",
                principalSchema: "Sales",
                principalTable: "SalesPerson",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseInvoice_Supplier_SupplierId",
                schema: "Accounting",
                table: "PurchaseInvoice",
                column: "SupplierId",
                principalSchema: "Accounting",
                principalTable: "Supplier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseInvoice_Warehouse_WarehouseId",
                schema: "Accounting",
                table: "PurchaseInvoice",
                column: "WarehouseId",
                principalSchema: "Inventory",
                principalTable: "Warehouse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseInvoiceLine_CostCenter_CostCenterId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                column: "CostCenterId",
                principalSchema: "Accounting",
                principalTable: "CostCenter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseInvoiceLine_CostUnit_CostUnitId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                column: "CostUnitId",
                principalSchema: "Accounting",
                principalTable: "CostUnit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseInvoiceLine_Item_ItemId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                column: "ItemId",
                principalSchema: "Inventory",
                principalTable: "Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseInvoiceLine_Operation_OperationId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                column: "OperationId",
                principalSchema: "Sec",
                principalTable: "Operation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseInvoiceLine_TaxType_TaxTypeId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                column: "TaxTypeId",
                principalSchema: "Accounting",
                principalTable: "TaxType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseInvoiceLine_UnitOfMeasure_UnitOfMeasureId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                column: "UnitOfMeasureId",
                principalSchema: "Inventory",
                principalTable: "UnitOfMeasure",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseInvoiceLine_WarehouseLocation_WarehouseLocationId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                column: "WarehouseLocationId",
                principalSchema: "Inventory",
                principalTable: "WarehouseLocation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseInvoiceLine_Warehouse_WarehouseId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
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
                name: "FK_PurchaseInvoice_Branch_BranchId",
                schema: "Accounting",
                table: "PurchaseInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseInvoice_Currency_CurrencyId",
                schema: "Accounting",
                table: "PurchaseInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseInvoice_PaymentTerm_PaymentTermsId",
                schema: "Accounting",
                table: "PurchaseInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseInvoice_SalesOrder_SalesOrderId",
                schema: "Accounting",
                table: "PurchaseInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseInvoice_SalesPerson_SalesPersonId",
                schema: "Accounting",
                table: "PurchaseInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseInvoice_Supplier_SupplierId",
                schema: "Accounting",
                table: "PurchaseInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseInvoice_Warehouse_WarehouseId",
                schema: "Accounting",
                table: "PurchaseInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseInvoiceLine_CostCenter_CostCenterId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseInvoiceLine_CostUnit_CostUnitId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseInvoiceLine_Item_ItemId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseInvoiceLine_Operation_OperationId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseInvoiceLine_TaxType_TaxTypeId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseInvoiceLine_UnitOfMeasure_UnitOfMeasureId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseInvoiceLine_WarehouseLocation_WarehouseLocationId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseInvoiceLine_Warehouse_WarehouseId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropTable(
                name: "PurchaseInvoiceAdjustment",
                schema: "Accounting");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseInvoiceLine_CostCenterId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseInvoiceLine_CostUnitId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseInvoiceLine_ItemId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseInvoiceLine_OperationId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseInvoiceLine_TaxTypeId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseInvoiceLine_UnitOfMeasureId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseInvoiceLine_WarehouseId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseInvoiceLine_WarehouseLocationId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseInvoice_BranchId",
                schema: "Accounting",
                table: "PurchaseInvoice");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseInvoice_CurrencyId",
                schema: "Accounting",
                table: "PurchaseInvoice");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseInvoice_PaymentTermsId",
                schema: "Accounting",
                table: "PurchaseInvoice");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseInvoice_SalesOrderId",
                schema: "Accounting",
                table: "PurchaseInvoice");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseInvoice_SalesPersonId",
                schema: "Accounting",
                table: "PurchaseInvoice");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseInvoice_SupplierId",
                schema: "Accounting",
                table: "PurchaseInvoice");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseInvoice_Tenant_ID_CompanyId_InvoiceNo",
                schema: "Accounting",
                table: "PurchaseInvoice");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseInvoice_WarehouseId",
                schema: "Accounting",
                table: "PurchaseInvoice");

            migrationBuilder.DropColumn(
                name: "ActivityId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropColumn(
                name: "BOQItemId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropColumn(
                name: "Cost",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropColumn(
                name: "CostCenterId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropColumn(
                name: "CostCodeId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropColumn(
                name: "CostUnitId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropColumn(
                name: "DiscountAmount",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropColumn(
                name: "DiscountType",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropColumn(
                name: "DiscountValue",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropColumn(
                name: "FreeItem",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropColumn(
                name: "IsInclusive",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropColumn(
                name: "ItemId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropColumn(
                name: "Notes",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropColumn(
                name: "OperationId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropColumn(
                name: "ProductionOrderId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropColumn(
                name: "Quantity",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropColumn(
                name: "SubcontractBOQId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropColumn(
                name: "TaxAmount",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropColumn(
                name: "TaxRate",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropColumn(
                name: "TaxTypeId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropColumn(
                name: "UnitOfMeasureId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropColumn(
                name: "WBSId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropColumn(
                name: "WarehouseLocationId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine");

            migrationBuilder.DropColumn(
                name: "AdditionalDiscountAmount",
                schema: "Accounting",
                table: "PurchaseInvoice");

            migrationBuilder.DropColumn(
                name: "AdditionalDiscountType",
                schema: "Accounting",
                table: "PurchaseInvoice");

            migrationBuilder.DropColumn(
                name: "AdditionalDiscountValue",
                schema: "Accounting",
                table: "PurchaseInvoice");

            migrationBuilder.DropColumn(
                name: "ApprovalStatus",
                schema: "Accounting",
                table: "PurchaseInvoice");

            migrationBuilder.DropColumn(
                name: "BranchId",
                schema: "Accounting",
                table: "PurchaseInvoice");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                schema: "Accounting",
                table: "PurchaseInvoice");

            migrationBuilder.DropColumn(
                name: "InvoiceDate",
                schema: "Accounting",
                table: "PurchaseInvoice");

            migrationBuilder.DropColumn(
                name: "InvoiceNo",
                schema: "Accounting",
                table: "PurchaseInvoice");

            migrationBuilder.DropColumn(
                name: "NetAmount",
                schema: "Accounting",
                table: "PurchaseInvoice");

            migrationBuilder.DropColumn(
                name: "Notes",
                schema: "Accounting",
                table: "PurchaseInvoice");

            migrationBuilder.DropColumn(
                name: "PaymentDueDate",
                schema: "Accounting",
                table: "PurchaseInvoice");

            migrationBuilder.DropColumn(
                name: "PaymentTermsId",
                schema: "Accounting",
                table: "PurchaseInvoice");

            migrationBuilder.DropColumn(
                name: "Posting",
                schema: "Accounting",
                table: "PurchaseInvoice");

            migrationBuilder.DropColumn(
                name: "SalesOrderId",
                schema: "Accounting",
                table: "PurchaseInvoice");

            migrationBuilder.DropColumn(
                name: "SalesPersonId",
                schema: "Accounting",
                table: "PurchaseInvoice");

            migrationBuilder.DropColumn(
                name: "ShipmentAddress",
                schema: "Accounting",
                table: "PurchaseInvoice");

            migrationBuilder.DropColumn(
                name: "ShipmentAmount",
                schema: "Accounting",
                table: "PurchaseInvoice");

            migrationBuilder.DropColumn(
                name: "ShipmentMethod",
                schema: "Accounting",
                table: "PurchaseInvoice");

            migrationBuilder.DropColumn(
                name: "ShipmentStatus",
                schema: "Accounting",
                table: "PurchaseInvoice");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "Accounting",
                table: "PurchaseInvoice");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                schema: "Accounting",
                table: "PurchaseInvoice");

            migrationBuilder.DropColumn(
                name: "TaxAmount",
                schema: "Accounting",
                table: "PurchaseInvoice");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                schema: "Accounting",
                table: "PurchaseInvoice");

            migrationBuilder.DropColumn(
                name: "TotalDiscount",
                schema: "Accounting",
                table: "PurchaseInvoice");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                schema: "Accounting",
                table: "PurchaseInvoice");

            migrationBuilder.AlterColumn<string>(
                name: "Mod_User",
                schema: "Accounting",
                table: "PurchaseInvoice",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "In_User",
                schema: "Accounting",
                table: "PurchaseInvoice",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
