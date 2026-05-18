using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPurchaseReturn7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PurchaseReturn",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenant_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    BranchId = table.Column<long>(type: "bigint", nullable: false),
                    FiscalYearId = table.Column<long>(type: "bigint", nullable: false),
                    ReturnNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PurchaseInvoiceId = table.Column<long>(type: "bigint", nullable: true),
                    SupplierId = table.Column<long>(type: "bigint", nullable: false),
                    ChartOfAccountId = table.Column<long>(type: "bigint", nullable: false),
                    WarehouseId = table.Column<long>(type: "bigint", nullable: false),
                    CurrencyId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnReason = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    NetAmount = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    AdditionalDiscountType = table.Column<int>(type: "int", nullable: true),
                    AdditionalDiscountValue = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: true),
                    AdditionalDiscountAmount = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: true),
                    TotalDiscount = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: true),
                    Posting = table.Column<int>(type: "int", nullable: false),
                    ApprovalStatus = table.Column<int>(type: "int", nullable: false),
                    SeriesId = table.Column<long>(type: "bigint", nullable: true),
                    RunningNumber = table.Column<int>(type: "int", nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseReturn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseReturn_Branch_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "Accounting",
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseReturn_ChartOfAccount_ChartOfAccountId",
                        column: x => x.ChartOfAccountId,
                        principalSchema: "Accounting",
                        principalTable: "ChartOfAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseReturn_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalSchema: "Sec",
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseReturn_FiscalYear_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalSchema: "Accounting",
                        principalTable: "FiscalYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseReturn_PurchaseInvoice_PurchaseInvoiceId",
                        column: x => x.PurchaseInvoiceId,
                        principalSchema: "Accounting",
                        principalTable: "PurchaseInvoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseReturn_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalSchema: "Stt",
                        principalTable: "Series",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseReturn_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalSchema: "Accounting",
                        principalTable: "Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseReturn_Warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalSchema: "Inventory",
                        principalTable: "Warehouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseReturnAdjustment",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseReturnId = table.Column<long>(type: "bigint", nullable: false),
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
                    table.PrimaryKey("PK_PurchaseReturnAdjustment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseReturnAdjustment_ChartOfAccount_ChartOfAccountId",
                        column: x => x.ChartOfAccountId,
                        principalSchema: "Accounting",
                        principalTable: "ChartOfAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseReturnAdjustment_CostCenter_CostCenterId",
                        column: x => x.CostCenterId,
                        principalSchema: "Accounting",
                        principalTable: "CostCenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseReturnAdjustment_CostUnit_CostUnitId",
                        column: x => x.CostUnitId,
                        principalSchema: "Accounting",
                        principalTable: "CostUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseReturnAdjustment_Operation_OperationId",
                        column: x => x.OperationId,
                        principalSchema: "Sec",
                        principalTable: "Operation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseReturnAdjustment_PurchaseReturn_PurchaseReturnId",
                        column: x => x.PurchaseReturnId,
                        principalSchema: "Accounting",
                        principalTable: "PurchaseReturn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseReturnLine",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseReturnId = table.Column<long>(type: "bigint", nullable: false),
                    PurchaseInvoiceLineId = table.Column<long>(type: "bigint", nullable: true),
                    ItemId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UnitOfMeasureId = table.Column<long>(type: "bigint", nullable: false),
                    InvoicedQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PreviousReturnedQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReturnedQty = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    TotalCost = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    NetAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    WarehouseId = table.Column<long>(type: "bigint", nullable: true),
                    WarehouseLocationId = table.Column<long>(type: "bigint", nullable: true),
                    BatchNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SerialNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Condition = table.Column<int>(type: "int", nullable: false),
                    CostCenterId = table.Column<long>(type: "bigint", nullable: true),
                    CostUnitId = table.Column<long>(type: "bigint", nullable: true),
                    TaxTypeId = table.Column<long>(type: "bigint", nullable: true),
                    TaxRate = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    IsInclusive = table.Column<bool>(type: "bit", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: true),
                    DiscountType = table.Column<int>(type: "int", nullable: true),
                    DiscountValue = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: true),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: true),
                    WBSId = table.Column<long>(type: "bigint", nullable: true),
                    CostCodeId = table.Column<long>(type: "bigint", nullable: true),
                    ActivityId = table.Column<long>(type: "bigint", nullable: true),
                    BOQItemId = table.Column<long>(type: "bigint", nullable: true),
                    SubcontractBOQId = table.Column<long>(type: "bigint", nullable: true),
                    ProductionOrderId = table.Column<long>(type: "bigint", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    In_User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseReturnLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseReturnLine_CostCenter_CostCenterId",
                        column: x => x.CostCenterId,
                        principalSchema: "Accounting",
                        principalTable: "CostCenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseReturnLine_CostUnit_CostUnitId",
                        column: x => x.CostUnitId,
                        principalSchema: "Accounting",
                        principalTable: "CostUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseReturnLine_Item_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "Inventory",
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseReturnLine_PurchaseInvoiceLine_PurchaseInvoiceLineId",
                        column: x => x.PurchaseInvoiceLineId,
                        principalSchema: "Accounting",
                        principalTable: "PurchaseInvoiceLine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseReturnLine_PurchaseReturn_PurchaseReturnId",
                        column: x => x.PurchaseReturnId,
                        principalSchema: "Accounting",
                        principalTable: "PurchaseReturn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseReturnLine_TaxType_TaxTypeId",
                        column: x => x.TaxTypeId,
                        principalSchema: "Accounting",
                        principalTable: "TaxType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseReturnLine_UnitOfMeasure_UnitOfMeasureId",
                        column: x => x.UnitOfMeasureId,
                        principalSchema: "Inventory",
                        principalTable: "UnitOfMeasure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseReturnLine_WarehouseLocation_WarehouseLocationId",
                        column: x => x.WarehouseLocationId,
                        principalSchema: "Inventory",
                        principalTable: "WarehouseLocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseReturnLine_Warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalSchema: "Inventory",
                        principalTable: "Warehouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturn_BranchId",
                schema: "Accounting",
                table: "PurchaseReturn",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturn_ChartOfAccountId",
                schema: "Accounting",
                table: "PurchaseReturn",
                column: "ChartOfAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturn_CurrencyId",
                schema: "Accounting",
                table: "PurchaseReturn",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturn_FiscalYearId",
                schema: "Accounting",
                table: "PurchaseReturn",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturn_PurchaseInvoiceId",
                schema: "Accounting",
                table: "PurchaseReturn",
                column: "PurchaseInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturn_SeriesId",
                schema: "Accounting",
                table: "PurchaseReturn",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturn_SupplierId",
                schema: "Accounting",
                table: "PurchaseReturn",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturn_Tenant_ID_CompanyId_ReturnNumber",
                schema: "Accounting",
                table: "PurchaseReturn",
                columns: new[] { "Tenant_ID", "CompanyId", "ReturnNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturn_WarehouseId",
                schema: "Accounting",
                table: "PurchaseReturn",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnAdjustment_ChartOfAccountId",
                schema: "Accounting",
                table: "PurchaseReturnAdjustment",
                column: "ChartOfAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnAdjustment_CostCenterId",
                schema: "Accounting",
                table: "PurchaseReturnAdjustment",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnAdjustment_CostUnitId",
                schema: "Accounting",
                table: "PurchaseReturnAdjustment",
                column: "CostUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnAdjustment_OperationId",
                schema: "Accounting",
                table: "PurchaseReturnAdjustment",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnAdjustment_PurchaseReturnId",
                schema: "Accounting",
                table: "PurchaseReturnAdjustment",
                column: "PurchaseReturnId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnLine_CostCenterId",
                schema: "Accounting",
                table: "PurchaseReturnLine",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnLine_CostUnitId",
                schema: "Accounting",
                table: "PurchaseReturnLine",
                column: "CostUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnLine_ItemId",
                schema: "Accounting",
                table: "PurchaseReturnLine",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnLine_PurchaseInvoiceLineId",
                schema: "Accounting",
                table: "PurchaseReturnLine",
                column: "PurchaseInvoiceLineId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnLine_PurchaseReturnId",
                schema: "Accounting",
                table: "PurchaseReturnLine",
                column: "PurchaseReturnId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnLine_TaxTypeId",
                schema: "Accounting",
                table: "PurchaseReturnLine",
                column: "TaxTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnLine_UnitOfMeasureId",
                schema: "Accounting",
                table: "PurchaseReturnLine",
                column: "UnitOfMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnLine_WarehouseId",
                schema: "Accounting",
                table: "PurchaseReturnLine",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnLine_WarehouseLocationId",
                schema: "Accounting",
                table: "PurchaseReturnLine",
                column: "WarehouseLocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseReturnAdjustment",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "PurchaseReturnLine",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "PurchaseReturn",
                schema: "Accounting");
        }
    }
}
