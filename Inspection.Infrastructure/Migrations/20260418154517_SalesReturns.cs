using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SalesReturns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PurchaseReturnId1",
                schema: "Accounting",
                table: "PurchaseReturnLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Mod_User",
                schema: "Accounting",
                table: "PurchaseReturn",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "In_User",
                schema: "Accounting",
                table: "PurchaseReturn",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            //migrationBuilder.AddColumn<int>(
            //    name: "RunningNumber",
            //    schema: "Inventory",
            //    table: "GoodsReceipt",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SalesReturn",
                schema: "Sales",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenant_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    BranchId = table.Column<long>(type: "bigint", nullable: false),
                    FiscalYearId = table.Column<long>(type: "bigint", nullable: false),
                    ReturnNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SalesInvoiceId = table.Column<long>(type: "bigint", nullable: true),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    ChartOfAccountId = table.Column<long>(type: "bigint", nullable: false),
                    WarehouseId = table.Column<long>(type: "bigint", nullable: false),
                    CurrencyId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnReason = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    NetAmount = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    Posting = table.Column<int>(type: "int", nullable: false),
                    ApprovalStatus = table.Column<int>(type: "int", nullable: false),
                    AdditionalDiscountType = table.Column<int>(type: "int", nullable: true),
                    AdditionalDiscountValue = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: true),
                    AdditionalDiscountAmount = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: true),
                    TotalDiscount = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: true),
                    SeriesId = table.Column<long>(type: "bigint", nullable: true),
                    RunningNumber = table.Column<int>(type: "int", nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesReturn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesReturn_Branch_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "Accounting",
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesReturn_ChartOfAccount_ChartOfAccountId",
                        column: x => x.ChartOfAccountId,
                        principalSchema: "Accounting",
                        principalTable: "ChartOfAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesReturn_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalSchema: "Sec",
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesReturn_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Accounting",
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesReturn_FiscalYear_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalSchema: "Accounting",
                        principalTable: "FiscalYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesReturn_SalesInvoice_SalesInvoiceId",
                        column: x => x.SalesInvoiceId,
                        principalSchema: "Accounting",
                        principalTable: "SalesInvoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesReturn_Warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalSchema: "Inventory",
                        principalTable: "Warehouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesReturnAdjustment",
                schema: "Sales",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesReturnId = table.Column<long>(type: "bigint", nullable: false),
                    ChartOfAccountId = table.Column<long>(type: "bigint", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
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
                    table.PrimaryKey("PK_SalesReturnAdjustment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesReturnAdjustment_ChartOfAccount_ChartOfAccountId",
                        column: x => x.ChartOfAccountId,
                        principalSchema: "Accounting",
                        principalTable: "ChartOfAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesReturnAdjustment_CostCenter_CostCenterId",
                        column: x => x.CostCenterId,
                        principalSchema: "Accounting",
                        principalTable: "CostCenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesReturnAdjustment_CostUnit_CostUnitId",
                        column: x => x.CostUnitId,
                        principalSchema: "Accounting",
                        principalTable: "CostUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesReturnAdjustment_Operation_OperationId",
                        column: x => x.OperationId,
                        principalSchema: "Sec",
                        principalTable: "Operation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesReturnAdjustment_SalesReturn_SalesReturnId",
                        column: x => x.SalesReturnId,
                        principalSchema: "Sales",
                        principalTable: "SalesReturn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesReturnLine",
                schema: "Sales",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesReturnId = table.Column<long>(type: "bigint", nullable: false),
                    SalesInvoiceLineId = table.Column<long>(type: "bigint", nullable: true),
                    ItemId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    UnitOfMeasureId = table.Column<long>(type: "bigint", nullable: false),
                    InvoicedQty = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    PreviousReturnedQty = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    ReturnedQty = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    TotalCost = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    NetAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    WarehouseId = table.Column<long>(type: "bigint", nullable: false),
                    WarehouseLocationId = table.Column<long>(type: "bigint", nullable: true),
                    BatchNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TaxTypeId = table.Column<long>(type: "bigint", nullable: false),
                    TaxRate = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    IsInclusive = table.Column<bool>(type: "bit", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    DiscountType = table.Column<int>(type: "int", nullable: true),
                    DiscountValue = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: true),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: true),
                    Condition = table.Column<int>(type: "int", nullable: false),
                    CostCenterId = table.Column<long>(type: "bigint", nullable: true),
                    CostUnitId = table.Column<long>(type: "bigint", nullable: true),
                    OperationId = table.Column<long>(type: "bigint", nullable: true),
                    WBSId = table.Column<long>(type: "bigint", nullable: true),
                    CostCodeId = table.Column<long>(type: "bigint", nullable: true),
                    ActivityId = table.Column<long>(type: "bigint", nullable: true),
                    BOQItemId = table.Column<long>(type: "bigint", nullable: true),
                    SubcontractBOQId = table.Column<long>(type: "bigint", nullable: true),
                    ProductionOrderId = table.Column<long>(type: "bigint", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SalesReturnId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesReturnLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesReturnLine_CostCenter_CostCenterId",
                        column: x => x.CostCenterId,
                        principalSchema: "Accounting",
                        principalTable: "CostCenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesReturnLine_CostUnit_CostUnitId",
                        column: x => x.CostUnitId,
                        principalSchema: "Accounting",
                        principalTable: "CostUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesReturnLine_Item_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "Inventory",
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesReturnLine_Operation_OperationId",
                        column: x => x.OperationId,
                        principalSchema: "Sec",
                        principalTable: "Operation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesReturnLine_SalesInvoiceLine_SalesInvoiceLineId",
                        column: x => x.SalesInvoiceLineId,
                        principalSchema: "Accounting",
                        principalTable: "SalesInvoiceLine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesReturnLine_SalesReturn_SalesReturnId",
                        column: x => x.SalesReturnId,
                        principalSchema: "Sales",
                        principalTable: "SalesReturn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesReturnLine_SalesReturn_SalesReturnId1",
                        column: x => x.SalesReturnId1,
                        principalSchema: "Sales",
                        principalTable: "SalesReturn",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SalesReturnLine_TaxType_TaxTypeId",
                        column: x => x.TaxTypeId,
                        principalSchema: "Accounting",
                        principalTable: "TaxType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesReturnLine_UnitOfMeasure_UnitOfMeasureId",
                        column: x => x.UnitOfMeasureId,
                        principalSchema: "Inventory",
                        principalTable: "UnitOfMeasure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesReturnLine_WarehouseLocation_WarehouseLocationId",
                        column: x => x.WarehouseLocationId,
                        principalSchema: "Inventory",
                        principalTable: "WarehouseLocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesReturnLine_Warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalSchema: "Inventory",
                        principalTable: "Warehouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnLine_PurchaseReturnId1",
                schema: "Accounting",
                table: "PurchaseReturnLine",
                column: "PurchaseReturnId1");

            //migrationBuilder.CreateIndex(
            //    name: "IX_GoodsReceipt_SeriesId",
            //    schema: "Inventory",
            //    table: "GoodsReceipt",
            //    column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturn_BranchId",
                schema: "Sales",
                table: "SalesReturn",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturn_ChartOfAccountId",
                schema: "Sales",
                table: "SalesReturn",
                column: "ChartOfAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturn_CurrencyId",
                schema: "Sales",
                table: "SalesReturn",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturn_CustomerId",
                schema: "Sales",
                table: "SalesReturn",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturn_FiscalYearId",
                schema: "Sales",
                table: "SalesReturn",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturn_SalesInvoiceId",
                schema: "Sales",
                table: "SalesReturn",
                column: "SalesInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturn_Tenant_ID_CompanyId_ReturnNumber",
                schema: "Sales",
                table: "SalesReturn",
                columns: new[] { "Tenant_ID", "CompanyId", "ReturnNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturn_WarehouseId",
                schema: "Sales",
                table: "SalesReturn",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnAdjustment_ChartOfAccountId",
                schema: "Sales",
                table: "SalesReturnAdjustment",
                column: "ChartOfAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnAdjustment_CostCenterId",
                schema: "Sales",
                table: "SalesReturnAdjustment",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnAdjustment_CostUnitId",
                schema: "Sales",
                table: "SalesReturnAdjustment",
                column: "CostUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnAdjustment_OperationId",
                schema: "Sales",
                table: "SalesReturnAdjustment",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnAdjustment_SalesReturnId",
                schema: "Sales",
                table: "SalesReturnAdjustment",
                column: "SalesReturnId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnLine_CostCenterId",
                schema: "Sales",
                table: "SalesReturnLine",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnLine_CostUnitId",
                schema: "Sales",
                table: "SalesReturnLine",
                column: "CostUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnLine_ItemId",
                schema: "Sales",
                table: "SalesReturnLine",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnLine_OperationId",
                schema: "Sales",
                table: "SalesReturnLine",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnLine_SalesInvoiceLineId",
                schema: "Sales",
                table: "SalesReturnLine",
                column: "SalesInvoiceLineId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnLine_SalesReturnId",
                schema: "Sales",
                table: "SalesReturnLine",
                column: "SalesReturnId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnLine_SalesReturnId1",
                schema: "Sales",
                table: "SalesReturnLine",
                column: "SalesReturnId1");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnLine_TaxTypeId",
                schema: "Sales",
                table: "SalesReturnLine",
                column: "TaxTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnLine_UnitOfMeasureId",
                schema: "Sales",
                table: "SalesReturnLine",
                column: "UnitOfMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnLine_WarehouseId",
                schema: "Sales",
                table: "SalesReturnLine",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnLine_WarehouseLocationId",
                schema: "Sales",
                table: "SalesReturnLine",
                column: "WarehouseLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseReturnLine_PurchaseReturn_PurchaseReturnId1",
                schema: "Accounting",
                table: "PurchaseReturnLine",
                column: "PurchaseReturnId1",
                principalSchema: "Accounting",
                principalTable: "PurchaseReturn",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseReturnLine_PurchaseReturn_PurchaseReturnId1",
                schema: "Accounting",
                table: "PurchaseReturnLine");

            migrationBuilder.DropTable(
                name: "SalesReturnAdjustment",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "SalesReturnLine",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "SalesReturn",
                schema: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseReturnLine_PurchaseReturnId1",
                schema: "Accounting",
                table: "PurchaseReturnLine");

            //migrationBuilder.DropIndex(
            //    name: "IX_GoodsReceipt_SeriesId",
            //    schema: "Inventory",
            //    table: "GoodsReceipt");

            migrationBuilder.DropColumn(
                name: "PurchaseReturnId1",
                schema: "Accounting",
                table: "PurchaseReturnLine");

            //migrationBuilder.DropColumn(
            //    name: "RunningNumber",
            //    schema: "Inventory",
            //    table: "GoodsReceipt");

            migrationBuilder.AlterColumn<string>(
                name: "Mod_User",
                schema: "Accounting",
                table: "PurchaseReturn",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "In_User",
                schema: "Accounting",
                table: "PurchaseReturn",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
