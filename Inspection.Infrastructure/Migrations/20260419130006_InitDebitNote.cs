using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitDebitNote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreditNoteSalesInvoiceAllocation",
                schema: "Accounting");

            migrationBuilder.CreateTable(
                name: "DebitNote",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenant_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    DebitNoteNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BranchId = table.Column<long>(type: "bigint", nullable: false),
                    FiscalYearId = table.Column<long>(type: "bigint", nullable: false),
                    SalesInvoiceId = table.Column<long>(type: "bigint", nullable: true),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    ChartOfAccountId = table.Column<long>(type: "bigint", nullable: false),
                    CurrencyId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DebitNoteDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    AdditionalDiscountType = table.Column<int>(type: "int", nullable: true),
                    AdditionalDiscountValue = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    AdditionalDiscountAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    TotalDiscount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
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
                    table.PrimaryKey("PK_DebitNote", x => x.Id);
                    table.CheckConstraint("CK_DebitNote_Posting", "[Posting] IN (1,2,3)");
                    table.CheckConstraint("CK_DebitNote_TotalAmount", "[TotalAmount] >= 0");
                    table.ForeignKey(
                        name: "FK_DebitNote_Branch_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "Accounting",
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DebitNote_ChartOfAccount_ChartOfAccountId",
                        column: x => x.ChartOfAccountId,
                        principalSchema: "Accounting",
                        principalTable: "ChartOfAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DebitNote_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalSchema: "Sec",
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DebitNote_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Accounting",
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DebitNote_FiscalYear_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalSchema: "Accounting",
                        principalTable: "FiscalYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DebitNote_SalesInvoice_SalesInvoiceId",
                        column: x => x.SalesInvoiceId,
                        principalSchema: "Accounting",
                        principalTable: "SalesInvoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DebitNote_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalSchema: "Stt",
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DebitNoteAdjustment",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DebitNoteId = table.Column<long>(type: "bigint", nullable: false),
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
                    DebitNoteId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DebitNoteAdjustment", x => x.Id);
                    table.CheckConstraint("CK_DebitNoteAdjustment_Amount", "[Amount] <> 0");
                    table.ForeignKey(
                        name: "FK_DebitNoteAdjustment_ChartOfAccount_ChartOfAccountId",
                        column: x => x.ChartOfAccountId,
                        principalSchema: "Accounting",
                        principalTable: "ChartOfAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DebitNoteAdjustment_CostCenter_CostCenterId",
                        column: x => x.CostCenterId,
                        principalSchema: "Accounting",
                        principalTable: "CostCenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DebitNoteAdjustment_CostUnit_CostUnitId",
                        column: x => x.CostUnitId,
                        principalSchema: "Accounting",
                        principalTable: "CostUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DebitNoteAdjustment_DebitNote_DebitNoteId",
                        column: x => x.DebitNoteId,
                        principalSchema: "Accounting",
                        principalTable: "DebitNote",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DebitNoteAdjustment_DebitNote_DebitNoteId1",
                        column: x => x.DebitNoteId1,
                        principalSchema: "Accounting",
                        principalTable: "DebitNote",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DebitNoteAdjustment_Operation_OperationId",
                        column: x => x.OperationId,
                        principalSchema: "Sec",
                        principalTable: "Operation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DebitNoteLine",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DebitNoteId = table.Column<long>(type: "bigint", nullable: false),
                    SalesInvoiceLineId = table.Column<long>(type: "bigint", nullable: true),
                    ItemId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UnitOfMeasureId = table.Column<long>(type: "bigint", nullable: true),
                    InvoicedQty = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    PreviousAdditionalQty = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    AdditionalQty = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: true),
                    TaxTypeId = table.Column<long>(type: "bigint", nullable: true),
                    TaxRate = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    IsInclusive = table.Column<bool>(type: "bit", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    NetAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DiscountType = table.Column<int>(type: "int", nullable: true),
                    DiscountValue = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
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
                    DebitNoteId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DebitNoteLine", x => x.Id);
                    table.CheckConstraint("CK_DebitNoteLine_AdditionalQty", "[AdditionalQty] > 0");
                    table.CheckConstraint("CK_DebitNoteLine_NetAmount", "[NetAmount] >= 0");
                    table.CheckConstraint("CK_DebitNoteLine_UnitPrice", "[UnitPrice] >= 0");
                    table.ForeignKey(
                        name: "FK_DebitNoteLine_CostCenter_CostCenterId",
                        column: x => x.CostCenterId,
                        principalSchema: "Accounting",
                        principalTable: "CostCenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DebitNoteLine_CostUnit_CostUnitId",
                        column: x => x.CostUnitId,
                        principalSchema: "Accounting",
                        principalTable: "CostUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DebitNoteLine_DebitNote_DebitNoteId",
                        column: x => x.DebitNoteId,
                        principalSchema: "Accounting",
                        principalTable: "DebitNote",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DebitNoteLine_DebitNote_DebitNoteId1",
                        column: x => x.DebitNoteId1,
                        principalSchema: "Accounting",
                        principalTable: "DebitNote",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DebitNoteLine_Item_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "Inventory",
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DebitNoteLine_Operation_OperationId",
                        column: x => x.OperationId,
                        principalSchema: "Sec",
                        principalTable: "Operation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DebitNoteLine_SalesInvoiceLine_SalesInvoiceLineId",
                        column: x => x.SalesInvoiceLineId,
                        principalSchema: "Accounting",
                        principalTable: "SalesInvoiceLine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DebitNoteLine_TaxType_TaxTypeId",
                        column: x => x.TaxTypeId,
                        principalSchema: "Accounting",
                        principalTable: "TaxType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DebitNoteLine_UnitOfMeasure_UnitOfMeasureId",
                        column: x => x.UnitOfMeasureId,
                        principalSchema: "Inventory",
                        principalTable: "UnitOfMeasure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DebitNoteLine_WarehouseLocation_WarehouseLocationId",
                        column: x => x.WarehouseLocationId,
                        principalSchema: "Inventory",
                        principalTable: "WarehouseLocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DebitNoteLine_Warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalSchema: "Inventory",
                        principalTable: "Warehouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CreditNoteLine_SalesInvoiceLineId",
                schema: "Accounting",
                table: "CreditNoteLine",
                column: "SalesInvoiceLineId");

            migrationBuilder.CreateIndex(
                name: "IX_DebitNote_BranchId",
                schema: "Accounting",
                table: "DebitNote",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_DebitNote_ChartOfAccountId",
                schema: "Accounting",
                table: "DebitNote",
                column: "ChartOfAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_DebitNote_CurrencyId",
                schema: "Accounting",
                table: "DebitNote",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_DebitNote_CustomerId",
                schema: "Accounting",
                table: "DebitNote",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_DebitNote_FiscalYearId",
                schema: "Accounting",
                table: "DebitNote",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_DebitNote_SalesInvoiceId",
                schema: "Accounting",
                table: "DebitNote",
                column: "SalesInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_DebitNote_SeriesId",
                schema: "Accounting",
                table: "DebitNote",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_DebitNote_Tenant_ID_CompanyId_DebitNoteNumber",
                schema: "Accounting",
                table: "DebitNote",
                columns: new[] { "Tenant_ID", "CompanyId", "DebitNoteNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DebitNoteAdjustment_ChartOfAccountId",
                schema: "Accounting",
                table: "DebitNoteAdjustment",
                column: "ChartOfAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_DebitNoteAdjustment_CostCenterId",
                schema: "Accounting",
                table: "DebitNoteAdjustment",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_DebitNoteAdjustment_CostUnitId",
                schema: "Accounting",
                table: "DebitNoteAdjustment",
                column: "CostUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_DebitNoteAdjustment_DebitNoteId",
                schema: "Accounting",
                table: "DebitNoteAdjustment",
                column: "DebitNoteId");

            migrationBuilder.CreateIndex(
                name: "IX_DebitNoteAdjustment_DebitNoteId1",
                schema: "Accounting",
                table: "DebitNoteAdjustment",
                column: "DebitNoteId1");

            migrationBuilder.CreateIndex(
                name: "IX_DebitNoteAdjustment_OperationId",
                schema: "Accounting",
                table: "DebitNoteAdjustment",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_DebitNoteLine_CostCenterId",
                schema: "Accounting",
                table: "DebitNoteLine",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_DebitNoteLine_CostUnitId",
                schema: "Accounting",
                table: "DebitNoteLine",
                column: "CostUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_DebitNoteLine_DebitNoteId",
                schema: "Accounting",
                table: "DebitNoteLine",
                column: "DebitNoteId");

            migrationBuilder.CreateIndex(
                name: "IX_DebitNoteLine_DebitNoteId1",
                schema: "Accounting",
                table: "DebitNoteLine",
                column: "DebitNoteId1");

            migrationBuilder.CreateIndex(
                name: "IX_DebitNoteLine_ItemId",
                schema: "Accounting",
                table: "DebitNoteLine",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_DebitNoteLine_OperationId",
                schema: "Accounting",
                table: "DebitNoteLine",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_DebitNoteLine_SalesInvoiceLineId",
                schema: "Accounting",
                table: "DebitNoteLine",
                column: "SalesInvoiceLineId");

            migrationBuilder.CreateIndex(
                name: "IX_DebitNoteLine_TaxTypeId",
                schema: "Accounting",
                table: "DebitNoteLine",
                column: "TaxTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DebitNoteLine_UnitOfMeasureId",
                schema: "Accounting",
                table: "DebitNoteLine",
                column: "UnitOfMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_DebitNoteLine_WarehouseId",
                schema: "Accounting",
                table: "DebitNoteLine",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_DebitNoteLine_WarehouseLocationId",
                schema: "Accounting",
                table: "DebitNoteLine",
                column: "WarehouseLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_CreditNoteLine_SalesInvoiceLine_SalesInvoiceLineId",
                schema: "Accounting",
                table: "CreditNoteLine",
                column: "SalesInvoiceLineId",
                principalSchema: "Accounting",
                principalTable: "SalesInvoiceLine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreditNoteLine_SalesInvoiceLine_SalesInvoiceLineId",
                schema: "Accounting",
                table: "CreditNoteLine");

            migrationBuilder.DropTable(
                name: "DebitNoteAdjustment",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "DebitNoteLine",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "DebitNote",
                schema: "Accounting");

            migrationBuilder.DropIndex(
                name: "IX_CreditNoteLine_SalesInvoiceLineId",
                schema: "Accounting",
                table: "CreditNoteLine");

            migrationBuilder.CreateTable(
                name: "CreditNoteSalesInvoiceAllocation",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CashReceiptId = table.Column<long>(type: "bigint", nullable: true),
                    CostCenterId = table.Column<long>(type: "bigint", nullable: true),
                    CostUnitId = table.Column<long>(type: "bigint", nullable: true),
                    CreditNoteId = table.Column<long>(type: "bigint", nullable: true),
                    OperationId = table.Column<long>(type: "bigint", nullable: true),
                    SalesInvoiceId = table.Column<long>(type: "bigint", nullable: false),
                    SalesInvoiceLineId = table.Column<long>(type: "bigint", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    BOQItemId = table.Column<long>(type: "bigint", nullable: true),
                    CreditNoteId1 = table.Column<long>(type: "bigint", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ProductionOrderId = table.Column<long>(type: "bigint", nullable: true),
                    SubcontractBOQId = table.Column<long>(type: "bigint", nullable: true),
                    WBSId = table.Column<long>(type: "bigint", nullable: true)
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
    }
}
