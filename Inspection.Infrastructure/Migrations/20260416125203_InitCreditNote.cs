using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitCreditNote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CreditNote",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenant_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    CreditNoteNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BranchId = table.Column<long>(type: "bigint", nullable: false),
                    FiscalYearId = table.Column<long>(type: "bigint", nullable: false),
                    SalesInvoiceId = table.Column<long>(type: "bigint", nullable: true),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    ChartOfAccountId = table.Column<long>(type: "bigint", nullable: false),
                    CurrencyId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreditNoteDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdditionalDiscountType = table.Column<int>(type: "int", nullable: true),
                    AdditionalDiscountValue = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    AdditionalDiscountAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    TotalDiscount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Posting = table.Column<int>(type: "int", nullable: false),
                    SeriesId = table.Column<long>(type: "bigint", nullable: true),
                    RunningNumber = table.Column<int>(type: "int", nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditNote", x => x.Id);
                    table.CheckConstraint("CK_CreditNote_Posting", "[Posting] IN (1,2,3)");
                    table.CheckConstraint("CK_CreditNote_TotalAmount", "[TotalAmount] >= 0");
                    table.ForeignKey(
                        name: "FK_CreditNote_Branch_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "Accounting",
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CreditNote_ChartOfAccount_ChartOfAccountId",
                        column: x => x.ChartOfAccountId,
                        principalSchema: "Accounting",
                        principalTable: "ChartOfAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CreditNote_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalSchema: "Sec",
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CreditNote_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Accounting",
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CreditNote_FiscalYear_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalSchema: "Accounting",
                        principalTable: "FiscalYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CreditNote_SalesInvoice_SalesInvoiceId",
                        column: x => x.SalesInvoiceId,
                        principalSchema: "Accounting",
                        principalTable: "SalesInvoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CreditNote_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalSchema: "Stt",
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CreditNoteAdjustment",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreditNoteId = table.Column<long>(type: "bigint", nullable: false),
                    ChartOfAccountId = table.Column<long>(type: "bigint", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CostCenterId = table.Column<long>(type: "bigint", nullable: true),
                    CostUnitId = table.Column<long>(type: "bigint", nullable: true),
                    OperationId = table.Column<long>(type: "bigint", nullable: true),
                    WBSId = table.Column<long>(type: "bigint", nullable: true),
                    CostCodeId = table.Column<long>(type: "bigint", nullable: true),
                    ActivityId = table.Column<long>(type: "bigint", nullable: true),
                    BOQItemId = table.Column<long>(type: "bigint", nullable: true),
                    SubcontractBOQId = table.Column<long>(type: "bigint", nullable: true),
                    ProductionOrderId = table.Column<long>(type: "bigint", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreditNoteId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditNoteAdjustment", x => x.Id);
                    table.CheckConstraint("CK_CreditNoteAdjustment_Amount", "[Amount] <> 0");
                    table.ForeignKey(
                        name: "FK_CreditNoteAdjustment_ChartOfAccount_ChartOfAccountId",
                        column: x => x.ChartOfAccountId,
                        principalSchema: "Accounting",
                        principalTable: "ChartOfAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CreditNoteAdjustment_CostCenter_CostCenterId",
                        column: x => x.CostCenterId,
                        principalSchema: "Accounting",
                        principalTable: "CostCenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CreditNoteAdjustment_CostUnit_CostUnitId",
                        column: x => x.CostUnitId,
                        principalSchema: "Accounting",
                        principalTable: "CostUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CreditNoteAdjustment_CreditNote_CreditNoteId",
                        column: x => x.CreditNoteId,
                        principalSchema: "Accounting",
                        principalTable: "CreditNote",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CreditNoteAdjustment_CreditNote_CreditNoteId1",
                        column: x => x.CreditNoteId1,
                        principalSchema: "Accounting",
                        principalTable: "CreditNote",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CreditNoteAdjustment_Operation_OperationId",
                        column: x => x.OperationId,
                        principalSchema: "Sec",
                        principalTable: "Operation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CreditNoteLine",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreditNoteId = table.Column<long>(type: "bigint", nullable: false),
                    SalesInvoiceLineId = table.Column<long>(type: "bigint", nullable: true),
                    ItemId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UnitOfMeasureId = table.Column<long>(type: "bigint", nullable: true),
                    InvoicedQty = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    PreviousReturnedQty = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    ReturnedQty = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: true),
                    TaxTypeId = table.Column<long>(type: "bigint", nullable: true),
                    TaxRate = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    IsInclusive = table.Column<bool>(type: "bit", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    DiscountType = table.Column<int>(type: "int", nullable: true),
                    DiscountValue = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    NetAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    WarehouseId = table.Column<long>(type: "bigint", nullable: true),
                    WarehouseLocationId = table.Column<long>(type: "bigint", nullable: true),
                    FreeItem = table.Column<bool>(type: "bit", nullable: false),
                    CostCenterId = table.Column<long>(type: "bigint", nullable: true),
                    CostUnitId = table.Column<long>(type: "bigint", nullable: true),
                    OperationId = table.Column<long>(type: "bigint", nullable: true),
                    WBSId = table.Column<long>(type: "bigint", nullable: true),
                    CostCodeId = table.Column<long>(type: "bigint", nullable: true),
                    ActivityId = table.Column<long>(type: "bigint", nullable: true),
                    BOQItemId = table.Column<long>(type: "bigint", nullable: true),
                    SubcontractBOQId = table.Column<long>(type: "bigint", nullable: true),
                    ProductionOrderId = table.Column<long>(type: "bigint", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreditNoteId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditNoteLine", x => x.Id);
                    table.CheckConstraint("CK_CreditNoteLine_NetAmount", "[NetAmount] >= 0");
                    table.CheckConstraint("CK_CreditNoteLine_ReturnedQty", "[ReturnedQty] > 0");
                    table.CheckConstraint("CK_CreditNoteLine_UnitPrice", "[UnitPrice] >= 0");
                    table.ForeignKey(
                        name: "FK_CreditNoteLine_CostCenter_CostCenterId",
                        column: x => x.CostCenterId,
                        principalSchema: "Accounting",
                        principalTable: "CostCenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CreditNoteLine_CostUnit_CostUnitId",
                        column: x => x.CostUnitId,
                        principalSchema: "Accounting",
                        principalTable: "CostUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CreditNoteLine_CreditNote_CreditNoteId",
                        column: x => x.CreditNoteId,
                        principalSchema: "Accounting",
                        principalTable: "CreditNote",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CreditNoteLine_CreditNote_CreditNoteId1",
                        column: x => x.CreditNoteId1,
                        principalSchema: "Accounting",
                        principalTable: "CreditNote",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CreditNoteLine_Item_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "Inventory",
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CreditNoteLine_Operation_OperationId",
                        column: x => x.OperationId,
                        principalSchema: "Sec",
                        principalTable: "Operation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CreditNoteLine_TaxType_TaxTypeId",
                        column: x => x.TaxTypeId,
                        principalSchema: "Accounting",
                        principalTable: "TaxType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CreditNoteLine_UnitOfMeasure_UnitOfMeasureId",
                        column: x => x.UnitOfMeasureId,
                        principalSchema: "Inventory",
                        principalTable: "UnitOfMeasure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CreditNoteLine_WarehouseLocation_WarehouseLocationId",
                        column: x => x.WarehouseLocationId,
                        principalSchema: "Inventory",
                        principalTable: "WarehouseLocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CreditNoteLine_Warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalSchema: "Inventory",
                        principalTable: "Warehouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CreditNoteSalesInvoiceAllocation",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreditNoteId = table.Column<long>(type: "bigint", nullable: true),
                    SalesInvoiceId = table.Column<long>(type: "bigint", nullable: false),
                    SalesInvoiceLineId = table.Column<long>(type: "bigint", nullable: true),
                    CashReceiptId = table.Column<long>(type: "bigint", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CostCenterId = table.Column<long>(type: "bigint", nullable: true),
                    CostUnitId = table.Column<long>(type: "bigint", nullable: true),
                    OperationId = table.Column<long>(type: "bigint", nullable: true),
                    WBSId = table.Column<long>(type: "bigint", nullable: true),
                    BOQItemId = table.Column<long>(type: "bigint", nullable: true),
                    SubcontractBOQId = table.Column<long>(type: "bigint", nullable: true),
                    ProductionOrderId = table.Column<long>(type: "bigint", nullable: true),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreditNoteId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditNoteSalesInvoiceAllocation", x => x.Id);
                    table.CheckConstraint("CK_CreditNoteSalesInvoiceAllocation_Amount", "[Amount] > 0");
                    table.CheckConstraint("CK_CreditNoteSalesInvoiceAllocation_Source", "([CreditNoteId] IS NOT NULL AND [CashReceiptId] IS NULL) OR ([CreditNoteId] IS NULL AND [CashReceiptId] IS NOT NULL)");
                    table.ForeignKey(
                        name: "FK_CreditNoteSalesInvoiceAllocation_CashReceipt_CashReceiptId",
                        column: x => x.CashReceiptId,
                        principalSchema: "Accounting",
                        principalTable: "CashReceipt",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CreditNoteSalesInvoiceAllocation_CostCenter_CostCenterId",
                        column: x => x.CostCenterId,
                        principalSchema: "Accounting",
                        principalTable: "CostCenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CreditNoteSalesInvoiceAllocation_CostUnit_CostUnitId",
                        column: x => x.CostUnitId,
                        principalSchema: "Accounting",
                        principalTable: "CostUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CreditNoteSalesInvoiceAllocation_CreditNote_CreditNoteId",
                        column: x => x.CreditNoteId,
                        principalSchema: "Accounting",
                        principalTable: "CreditNote",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CreditNoteSalesInvoiceAllocation_CreditNote_CreditNoteId1",
                        column: x => x.CreditNoteId1,
                        principalSchema: "Accounting",
                        principalTable: "CreditNote",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CreditNoteSalesInvoiceAllocation_Operation_OperationId",
                        column: x => x.OperationId,
                        principalSchema: "Sec",
                        principalTable: "Operation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CreditNoteSalesInvoiceAllocation_SalesInvoiceLine_SalesInvoiceLineId",
                        column: x => x.SalesInvoiceLineId,
                        principalSchema: "Accounting",
                        principalTable: "SalesInvoiceLine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CreditNoteSalesInvoiceAllocation_SalesInvoice_SalesInvoiceId",
                        column: x => x.SalesInvoiceId,
                        principalSchema: "Accounting",
                        principalTable: "SalesInvoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CreditNote_BranchId",
                schema: "Accounting",
                table: "CreditNote",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditNote_ChartOfAccountId",
                schema: "Accounting",
                table: "CreditNote",
                column: "ChartOfAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditNote_CurrencyId",
                schema: "Accounting",
                table: "CreditNote",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditNote_CustomerId",
                schema: "Accounting",
                table: "CreditNote",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditNote_FiscalYearId",
                schema: "Accounting",
                table: "CreditNote",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditNote_SalesInvoiceId",
                schema: "Accounting",
                table: "CreditNote",
                column: "SalesInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditNote_SeriesId",
                schema: "Accounting",
                table: "CreditNote",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditNote_Tenant_ID_CompanyId_CreditNoteNumber",
                schema: "Accounting",
                table: "CreditNote",
                columns: new[] { "Tenant_ID", "CompanyId", "CreditNoteNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CreditNoteAdjustment_ChartOfAccountId",
                schema: "Accounting",
                table: "CreditNoteAdjustment",
                column: "ChartOfAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditNoteAdjustment_CostCenterId",
                schema: "Accounting",
                table: "CreditNoteAdjustment",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditNoteAdjustment_CostUnitId",
                schema: "Accounting",
                table: "CreditNoteAdjustment",
                column: "CostUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditNoteAdjustment_CreditNoteId",
                schema: "Accounting",
                table: "CreditNoteAdjustment",
                column: "CreditNoteId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditNoteAdjustment_CreditNoteId1",
                schema: "Accounting",
                table: "CreditNoteAdjustment",
                column: "CreditNoteId1");

            migrationBuilder.CreateIndex(
                name: "IX_CreditNoteAdjustment_OperationId",
                schema: "Accounting",
                table: "CreditNoteAdjustment",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditNoteLine_CostCenterId",
                schema: "Accounting",
                table: "CreditNoteLine",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditNoteLine_CostUnitId",
                schema: "Accounting",
                table: "CreditNoteLine",
                column: "CostUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditNoteLine_CreditNoteId",
                schema: "Accounting",
                table: "CreditNoteLine",
                column: "CreditNoteId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditNoteLine_CreditNoteId1",
                schema: "Accounting",
                table: "CreditNoteLine",
                column: "CreditNoteId1");

            migrationBuilder.CreateIndex(
                name: "IX_CreditNoteLine_ItemId",
                schema: "Accounting",
                table: "CreditNoteLine",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditNoteLine_OperationId",
                schema: "Accounting",
                table: "CreditNoteLine",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditNoteLine_TaxTypeId",
                schema: "Accounting",
                table: "CreditNoteLine",
                column: "TaxTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditNoteLine_UnitOfMeasureId",
                schema: "Accounting",
                table: "CreditNoteLine",
                column: "UnitOfMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditNoteLine_WarehouseId",
                schema: "Accounting",
                table: "CreditNoteLine",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditNoteLine_WarehouseLocationId",
                schema: "Accounting",
                table: "CreditNoteLine",
                column: "WarehouseLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditNoteSalesInvoiceAllocation_CashReceiptId",
                schema: "Accounting",
                table: "CreditNoteSalesInvoiceAllocation",
                column: "CashReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditNoteSalesInvoiceAllocation_CostCenterId",
                schema: "Accounting",
                table: "CreditNoteSalesInvoiceAllocation",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditNoteSalesInvoiceAllocation_CostUnitId",
                schema: "Accounting",
                table: "CreditNoteSalesInvoiceAllocation",
                column: "CostUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditNoteSalesInvoiceAllocation_CreditNoteId",
                schema: "Accounting",
                table: "CreditNoteSalesInvoiceAllocation",
                column: "CreditNoteId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditNoteSalesInvoiceAllocation_CreditNoteId1",
                schema: "Accounting",
                table: "CreditNoteSalesInvoiceAllocation",
                column: "CreditNoteId1");

            migrationBuilder.CreateIndex(
                name: "IX_CreditNoteSalesInvoiceAllocation_OperationId",
                schema: "Accounting",
                table: "CreditNoteSalesInvoiceAllocation",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditNoteSalesInvoiceAllocation_SalesInvoiceId",
                schema: "Accounting",
                table: "CreditNoteSalesInvoiceAllocation",
                column: "SalesInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditNoteSalesInvoiceAllocation_SalesInvoiceLineId",
                schema: "Accounting",
                table: "CreditNoteSalesInvoiceAllocation",
                column: "SalesInvoiceLineId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreditNoteAdjustment",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "CreditNoteLine",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "CreditNoteSalesInvoiceAllocation",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "CreditNote",
                schema: "Accounting");
        }
    }
}
