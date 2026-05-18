using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitCashPayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceAllocation",
                schema: "Accounting");

            migrationBuilder.CreateTable(
                name: "CashPayment",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenant_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    ReceiptNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ManualNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BranchId = table.Column<long>(type: "bigint", nullable: false),
                    FiscalYearId = table.Column<long>(type: "bigint", nullable: false),
                    AccountId = table.Column<long>(type: "bigint", nullable: false),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    CurrencyId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ReceivedFrom = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ReceiptDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PostingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaxTypeId = table.Column<long>(type: "bigint", nullable: true),
                    TaxPercent = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Posting = table.Column<int>(type: "int", nullable: false),
                    ApprovalStatus = table.Column<int>(type: "int", nullable: false),
                    SeriesId = table.Column<long>(type: "bigint", nullable: true),
                    RunningNumber = table.Column<int>(type: "int", nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashPayment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CashPayment_Branch_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "Accounting",
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashPayment_ChartOfAccount_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "Accounting",
                        principalTable: "ChartOfAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashPayment_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalSchema: "Sec",
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashPayment_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Accounting",
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashPayment_FiscalYear_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalSchema: "Accounting",
                        principalTable: "FiscalYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashPayment_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalSchema: "Stt",
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashPayment_TaxType_TaxTypeId",
                        column: x => x.TaxTypeId,
                        principalSchema: "Accounting",
                        principalTable: "TaxType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseInvoice",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenant_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    SeriesId = table.Column<long>(type: "bigint", nullable: true),
                    RunningNumber = table.Column<int>(type: "int", nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseInvoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseInvoice_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalSchema: "Stt",
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesInvoiceAllocation",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesInvoiceId = table.Column<long>(type: "bigint", nullable: false),
                    SalesInvoiceLineId = table.Column<long>(type: "bigint", nullable: true),
                    CashReceiptId = table.Column<long>(type: "bigint", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
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
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CashReceiptId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesInvoiceAllocation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesInvoiceAllocation_CashReceipt_CashReceiptId",
                        column: x => x.CashReceiptId,
                        principalSchema: "Accounting",
                        principalTable: "CashReceipt",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesInvoiceAllocation_CashReceipt_CashReceiptId1",
                        column: x => x.CashReceiptId1,
                        principalSchema: "Accounting",
                        principalTable: "CashReceipt",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SalesInvoiceAllocation_CostCenter_CostCenterId",
                        column: x => x.CostCenterId,
                        principalSchema: "Accounting",
                        principalTable: "CostCenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesInvoiceAllocation_CostUnit_CostUnitId",
                        column: x => x.CostUnitId,
                        principalSchema: "Accounting",
                        principalTable: "CostUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesInvoiceAllocation_Operation_OperationId",
                        column: x => x.OperationId,
                        principalSchema: "Sec",
                        principalTable: "Operation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesInvoiceAllocation_SalesInvoiceLine_SalesInvoiceLineId",
                        column: x => x.SalesInvoiceLineId,
                        principalSchema: "Accounting",
                        principalTable: "SalesInvoiceLine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesInvoiceAllocation_SalesInvoice_SalesInvoiceId",
                        column: x => x.SalesInvoiceId,
                        principalSchema: "Accounting",
                        principalTable: "SalesInvoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CashPaymentAdjustment",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CashPaymentId = table.Column<long>(type: "bigint", nullable: false),
                    AccountId = table.Column<long>(type: "bigint", nullable: false),
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
                    CashPaymentId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashPaymentAdjustment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CashPaymentAdjustment_CashPayment_CashPaymentId",
                        column: x => x.CashPaymentId,
                        principalSchema: "Accounting",
                        principalTable: "CashPayment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CashPaymentAdjustment_CashPayment_CashPaymentId1",
                        column: x => x.CashPaymentId1,
                        principalSchema: "Accounting",
                        principalTable: "CashPayment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CashPaymentAdjustment_ChartOfAccount_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "Accounting",
                        principalTable: "ChartOfAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashPaymentAdjustment_CostCenter_CostCenterId",
                        column: x => x.CostCenterId,
                        principalSchema: "Accounting",
                        principalTable: "CostCenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashPaymentAdjustment_CostUnit_CostUnitId",
                        column: x => x.CostUnitId,
                        principalSchema: "Accounting",
                        principalTable: "CostUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashPaymentAdjustment_Operation_OperationId",
                        column: x => x.OperationId,
                        principalSchema: "Sec",
                        principalTable: "Operation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CashPaymentLine",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CashPaymentId = table.Column<long>(type: "bigint", nullable: false),
                    PaymentModeId = table.Column<long>(type: "bigint", nullable: false),
                    AccountId = table.Column<long>(type: "bigint", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    FeesAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    ReferenceNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ReferenceDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ChequeNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ChequeDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BankId = table.Column<long>(type: "bigint", nullable: true),
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
                    CashPaymentId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashPaymentLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CashPaymentLine_Bank_BankId",
                        column: x => x.BankId,
                        principalSchema: "Accounting",
                        principalTable: "Bank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashPaymentLine_CashPayment_CashPaymentId",
                        column: x => x.CashPaymentId,
                        principalSchema: "Accounting",
                        principalTable: "CashPayment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CashPaymentLine_CashPayment_CashPaymentId1",
                        column: x => x.CashPaymentId1,
                        principalSchema: "Accounting",
                        principalTable: "CashPayment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CashPaymentLine_ChartOfAccount_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "Accounting",
                        principalTable: "ChartOfAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashPaymentLine_CostCenter_CostCenterId",
                        column: x => x.CostCenterId,
                        principalSchema: "Accounting",
                        principalTable: "CostCenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashPaymentLine_CostUnit_CostUnitId",
                        column: x => x.CostUnitId,
                        principalSchema: "Accounting",
                        principalTable: "CostUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashPaymentLine_ModeOfPayment_PaymentModeId",
                        column: x => x.PaymentModeId,
                        principalSchema: "Accounting",
                        principalTable: "ModeOfPayment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashPaymentLine_Operation_OperationId",
                        column: x => x.OperationId,
                        principalSchema: "Sec",
                        principalTable: "Operation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseInvoiceLine",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseInvoiceId = table.Column<long>(type: "bigint", nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseInvoiceLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseInvoiceLine_PurchaseInvoice_PurchaseInvoiceId",
                        column: x => x.PurchaseInvoiceId,
                        principalSchema: "Accounting",
                        principalTable: "PurchaseInvoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseInvoiceAllocation",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseInvoiceId = table.Column<long>(type: "bigint", nullable: false),
                    PurchaseInvoiceLineId = table.Column<long>(type: "bigint", nullable: true),
                    CashPaymentId = table.Column<long>(type: "bigint", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
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
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CashPaymentId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseInvoiceAllocation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseInvoiceAllocation_CashPayment_CashPaymentId",
                        column: x => x.CashPaymentId,
                        principalSchema: "Accounting",
                        principalTable: "CashPayment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseInvoiceAllocation_CashPayment_CashPaymentId1",
                        column: x => x.CashPaymentId1,
                        principalSchema: "Accounting",
                        principalTable: "CashPayment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseInvoiceAllocation_CostCenter_CostCenterId",
                        column: x => x.CostCenterId,
                        principalSchema: "Accounting",
                        principalTable: "CostCenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseInvoiceAllocation_CostUnit_CostUnitId",
                        column: x => x.CostUnitId,
                        principalSchema: "Accounting",
                        principalTable: "CostUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseInvoiceAllocation_Operation_OperationId",
                        column: x => x.OperationId,
                        principalSchema: "Sec",
                        principalTable: "Operation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseInvoiceAllocation_PurchaseInvoiceLine_PurchaseInvoiceLineId",
                        column: x => x.PurchaseInvoiceLineId,
                        principalSchema: "Accounting",
                        principalTable: "PurchaseInvoiceLine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseInvoiceAllocation_PurchaseInvoice_PurchaseInvoiceId",
                        column: x => x.PurchaseInvoiceId,
                        principalSchema: "Accounting",
                        principalTable: "PurchaseInvoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CashPayment_AccountId",
                schema: "Accounting",
                table: "CashPayment",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_CashPayment_BranchId",
                schema: "Accounting",
                table: "CashPayment",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_CashPayment_CurrencyId",
                schema: "Accounting",
                table: "CashPayment",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_CashPayment_CustomerId",
                schema: "Accounting",
                table: "CashPayment",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CashPayment_FiscalYearId",
                schema: "Accounting",
                table: "CashPayment",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_CashPayment_SeriesId",
                schema: "Accounting",
                table: "CashPayment",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_CashPayment_TaxTypeId",
                schema: "Accounting",
                table: "CashPayment",
                column: "TaxTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CashPayment_Tenant_ID_CompanyId_ReceiptNumber",
                schema: "Accounting",
                table: "CashPayment",
                columns: new[] { "Tenant_ID", "CompanyId", "ReceiptNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CashPaymentAdjustment_AccountId",
                schema: "Accounting",
                table: "CashPaymentAdjustment",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_CashPaymentAdjustment_CashPaymentId",
                schema: "Accounting",
                table: "CashPaymentAdjustment",
                column: "CashPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_CashPaymentAdjustment_CashPaymentId1",
                schema: "Accounting",
                table: "CashPaymentAdjustment",
                column: "CashPaymentId1");

            migrationBuilder.CreateIndex(
                name: "IX_CashPaymentAdjustment_CostCenterId",
                schema: "Accounting",
                table: "CashPaymentAdjustment",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_CashPaymentAdjustment_CostUnitId",
                schema: "Accounting",
                table: "CashPaymentAdjustment",
                column: "CostUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_CashPaymentAdjustment_OperationId",
                schema: "Accounting",
                table: "CashPaymentAdjustment",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_CashPaymentLine_AccountId",
                schema: "Accounting",
                table: "CashPaymentLine",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_CashPaymentLine_BankId",
                schema: "Accounting",
                table: "CashPaymentLine",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_CashPaymentLine_CashPaymentId",
                schema: "Accounting",
                table: "CashPaymentLine",
                column: "CashPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_CashPaymentLine_CashPaymentId1",
                schema: "Accounting",
                table: "CashPaymentLine",
                column: "CashPaymentId1");

            migrationBuilder.CreateIndex(
                name: "IX_CashPaymentLine_CostCenterId",
                schema: "Accounting",
                table: "CashPaymentLine",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_CashPaymentLine_CostUnitId",
                schema: "Accounting",
                table: "CashPaymentLine",
                column: "CostUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_CashPaymentLine_OperationId",
                schema: "Accounting",
                table: "CashPaymentLine",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_CashPaymentLine_PaymentModeId",
                schema: "Accounting",
                table: "CashPaymentLine",
                column: "PaymentModeId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoice_SeriesId",
                schema: "Accounting",
                table: "PurchaseInvoice",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceAllocation_CashPaymentId",
                schema: "Accounting",
                table: "PurchaseInvoiceAllocation",
                column: "CashPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceAllocation_CashPaymentId1",
                schema: "Accounting",
                table: "PurchaseInvoiceAllocation",
                column: "CashPaymentId1");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceAllocation_CostCenterId",
                schema: "Accounting",
                table: "PurchaseInvoiceAllocation",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceAllocation_CostUnitId",
                schema: "Accounting",
                table: "PurchaseInvoiceAllocation",
                column: "CostUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceAllocation_OperationId",
                schema: "Accounting",
                table: "PurchaseInvoiceAllocation",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceAllocation_PurchaseInvoiceId",
                schema: "Accounting",
                table: "PurchaseInvoiceAllocation",
                column: "PurchaseInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceAllocation_PurchaseInvoiceLineId",
                schema: "Accounting",
                table: "PurchaseInvoiceAllocation",
                column: "PurchaseInvoiceLineId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceLine_PurchaseInvoiceId",
                schema: "Accounting",
                table: "PurchaseInvoiceLine",
                column: "PurchaseInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceAllocation_CashReceiptId",
                schema: "Accounting",
                table: "SalesInvoiceAllocation",
                column: "CashReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceAllocation_CashReceiptId1",
                schema: "Accounting",
                table: "SalesInvoiceAllocation",
                column: "CashReceiptId1");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceAllocation_CostCenterId",
                schema: "Accounting",
                table: "SalesInvoiceAllocation",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceAllocation_CostUnitId",
                schema: "Accounting",
                table: "SalesInvoiceAllocation",
                column: "CostUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceAllocation_OperationId",
                schema: "Accounting",
                table: "SalesInvoiceAllocation",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceAllocation_SalesInvoiceId",
                schema: "Accounting",
                table: "SalesInvoiceAllocation",
                column: "SalesInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceAllocation_SalesInvoiceLineId",
                schema: "Accounting",
                table: "SalesInvoiceAllocation",
                column: "SalesInvoiceLineId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CashPaymentAdjustment",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "CashPaymentLine",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "PurchaseInvoiceAllocation",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "SalesInvoiceAllocation",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "CashPayment",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "PurchaseInvoiceLine",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "PurchaseInvoice",
                schema: "Accounting");

            migrationBuilder.CreateTable(
                name: "InvoiceAllocation",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CashReceiptId = table.Column<long>(type: "bigint", nullable: false),
                    CostCenterId = table.Column<long>(type: "bigint", nullable: true),
                    CostUnitId = table.Column<long>(type: "bigint", nullable: true),
                    OperationId = table.Column<long>(type: "bigint", nullable: true),
                    SalesInvoiceId = table.Column<long>(type: "bigint", nullable: false),
                    SalesInvoiceLineId = table.Column<long>(type: "bigint", nullable: true),
                    ActivityId = table.Column<long>(type: "bigint", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    BOQItemId = table.Column<long>(type: "bigint", nullable: true),
                    CashReceiptId1 = table.Column<long>(type: "bigint", nullable: true),
                    CostCodeId = table.Column<long>(type: "bigint", nullable: true),
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
                    table.PrimaryKey("PK_InvoiceAllocation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceAllocation_CashReceipt_CashReceiptId",
                        column: x => x.CashReceiptId,
                        principalSchema: "Accounting",
                        principalTable: "CashReceipt",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceAllocation_CashReceipt_CashReceiptId1",
                        column: x => x.CashReceiptId1,
                        principalSchema: "Accounting",
                        principalTable: "CashReceipt",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InvoiceAllocation_CostCenter_CostCenterId",
                        column: x => x.CostCenterId,
                        principalSchema: "Accounting",
                        principalTable: "CostCenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoiceAllocation_CostUnit_CostUnitId",
                        column: x => x.CostUnitId,
                        principalSchema: "Accounting",
                        principalTable: "CostUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoiceAllocation_Operation_OperationId",
                        column: x => x.OperationId,
                        principalSchema: "Sec",
                        principalTable: "Operation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoiceAllocation_SalesInvoiceLine_SalesInvoiceLineId",
                        column: x => x.SalesInvoiceLineId,
                        principalSchema: "Accounting",
                        principalTable: "SalesInvoiceLine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoiceAllocation_SalesInvoice_SalesInvoiceId",
                        column: x => x.SalesInvoiceId,
                        principalSchema: "Accounting",
                        principalTable: "SalesInvoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceAllocation_CashReceiptId",
                schema: "Accounting",
                table: "InvoiceAllocation",
                column: "CashReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceAllocation_CashReceiptId1",
                schema: "Accounting",
                table: "InvoiceAllocation",
                column: "CashReceiptId1");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceAllocation_CostCenterId",
                schema: "Accounting",
                table: "InvoiceAllocation",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceAllocation_CostUnitId",
                schema: "Accounting",
                table: "InvoiceAllocation",
                column: "CostUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceAllocation_OperationId",
                schema: "Accounting",
                table: "InvoiceAllocation",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceAllocation_SalesInvoiceId",
                schema: "Accounting",
                table: "InvoiceAllocation",
                column: "SalesInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceAllocation_SalesInvoiceLineId",
                schema: "Accounting",
                table: "InvoiceAllocation",
                column: "SalesInvoiceLineId");
        }
    }
}
