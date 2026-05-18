using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitCashReceipt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CashReceipt",
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
                    table.PrimaryKey("PK_CashReceipt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CashReceipt_Branch_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "Accounting",
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashReceipt_ChartOfAccount_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "Accounting",
                        principalTable: "ChartOfAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashReceipt_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalSchema: "Sec",
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashReceipt_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Accounting",
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashReceipt_FiscalYear_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalSchema: "Accounting",
                        principalTable: "FiscalYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashReceipt_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalSchema: "Stt",
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashReceipt_TaxType_TaxTypeId",
                        column: x => x.TaxTypeId,
                        principalSchema: "Accounting",
                        principalTable: "TaxType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesInvoice",
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
                    table.PrimaryKey("PK_SalesInvoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesInvoice_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalSchema: "Stt",
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CashReceiptAdjustment",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CashReceiptId = table.Column<long>(type: "bigint", nullable: false),
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
                    CashReceiptId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashReceiptAdjustment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CashReceiptAdjustment_CashReceipt_CashReceiptId",
                        column: x => x.CashReceiptId,
                        principalSchema: "Accounting",
                        principalTable: "CashReceipt",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CashReceiptAdjustment_CashReceipt_CashReceiptId1",
                        column: x => x.CashReceiptId1,
                        principalSchema: "Accounting",
                        principalTable: "CashReceipt",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CashReceiptAdjustment_ChartOfAccount_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "Accounting",
                        principalTable: "ChartOfAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashReceiptAdjustment_CostCenter_CostCenterId",
                        column: x => x.CostCenterId,
                        principalSchema: "Accounting",
                        principalTable: "CostCenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashReceiptAdjustment_CostUnit_CostUnitId",
                        column: x => x.CostUnitId,
                        principalSchema: "Accounting",
                        principalTable: "CostUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashReceiptAdjustment_Operation_OperationId",
                        column: x => x.OperationId,
                        principalSchema: "Sec",
                        principalTable: "Operation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CashReceiptLine",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CashReceiptId = table.Column<long>(type: "bigint", nullable: false),
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
                    CashReceiptId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashReceiptLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CashReceiptLine_Bank_BankId",
                        column: x => x.BankId,
                        principalSchema: "Accounting",
                        principalTable: "Bank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashReceiptLine_CashReceipt_CashReceiptId",
                        column: x => x.CashReceiptId,
                        principalSchema: "Accounting",
                        principalTable: "CashReceipt",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CashReceiptLine_CashReceipt_CashReceiptId1",
                        column: x => x.CashReceiptId1,
                        principalSchema: "Accounting",
                        principalTable: "CashReceipt",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CashReceiptLine_ChartOfAccount_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "Accounting",
                        principalTable: "ChartOfAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashReceiptLine_CostCenter_CostCenterId",
                        column: x => x.CostCenterId,
                        principalSchema: "Accounting",
                        principalTable: "CostCenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashReceiptLine_CostUnit_CostUnitId",
                        column: x => x.CostUnitId,
                        principalSchema: "Accounting",
                        principalTable: "CostUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashReceiptLine_ModeOfPayment_PaymentModeId",
                        column: x => x.PaymentModeId,
                        principalSchema: "Accounting",
                        principalTable: "ModeOfPayment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashReceiptLine_Operation_OperationId",
                        column: x => x.OperationId,
                        principalSchema: "Sec",
                        principalTable: "Operation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesInvoiceLine",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesInvoiceId = table.Column<long>(type: "bigint", nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesInvoiceLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesInvoiceLine_SalesInvoice_SalesInvoiceId",
                        column: x => x.SalesInvoiceId,
                        principalSchema: "Accounting",
                        principalTable: "SalesInvoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceAllocation",
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
                name: "IX_CashReceipt_AccountId",
                schema: "Accounting",
                table: "CashReceipt",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_CashReceipt_BranchId",
                schema: "Accounting",
                table: "CashReceipt",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_CashReceipt_CurrencyId",
                schema: "Accounting",
                table: "CashReceipt",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_CashReceipt_CustomerId",
                schema: "Accounting",
                table: "CashReceipt",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CashReceipt_FiscalYearId",
                schema: "Accounting",
                table: "CashReceipt",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_CashReceipt_SeriesId",
                schema: "Accounting",
                table: "CashReceipt",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_CashReceipt_TaxTypeId",
                schema: "Accounting",
                table: "CashReceipt",
                column: "TaxTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CashReceipt_Tenant_ID_CompanyId_ReceiptNumber",
                schema: "Accounting",
                table: "CashReceipt",
                columns: new[] { "Tenant_ID", "CompanyId", "ReceiptNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CashReceiptAdjustment_AccountId",
                schema: "Accounting",
                table: "CashReceiptAdjustment",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_CashReceiptAdjustment_CashReceiptId",
                schema: "Accounting",
                table: "CashReceiptAdjustment",
                column: "CashReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_CashReceiptAdjustment_CashReceiptId1",
                schema: "Accounting",
                table: "CashReceiptAdjustment",
                column: "CashReceiptId1");

            migrationBuilder.CreateIndex(
                name: "IX_CashReceiptAdjustment_CostCenterId",
                schema: "Accounting",
                table: "CashReceiptAdjustment",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_CashReceiptAdjustment_CostUnitId",
                schema: "Accounting",
                table: "CashReceiptAdjustment",
                column: "CostUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_CashReceiptAdjustment_OperationId",
                schema: "Accounting",
                table: "CashReceiptAdjustment",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_CashReceiptLine_AccountId",
                schema: "Accounting",
                table: "CashReceiptLine",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_CashReceiptLine_BankId",
                schema: "Accounting",
                table: "CashReceiptLine",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_CashReceiptLine_CashReceiptId",
                schema: "Accounting",
                table: "CashReceiptLine",
                column: "CashReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_CashReceiptLine_CashReceiptId1",
                schema: "Accounting",
                table: "CashReceiptLine",
                column: "CashReceiptId1");

            migrationBuilder.CreateIndex(
                name: "IX_CashReceiptLine_CostCenterId",
                schema: "Accounting",
                table: "CashReceiptLine",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_CashReceiptLine_CostUnitId",
                schema: "Accounting",
                table: "CashReceiptLine",
                column: "CostUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_CashReceiptLine_OperationId",
                schema: "Accounting",
                table: "CashReceiptLine",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_CashReceiptLine_PaymentModeId",
                schema: "Accounting",
                table: "CashReceiptLine",
                column: "PaymentModeId");

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

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoice_SeriesId",
                schema: "Accounting",
                table: "SalesInvoice",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceLine_SalesInvoiceId",
                schema: "Accounting",
                table: "SalesInvoiceLine",
                column: "SalesInvoiceId");




        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_ChartOfAccount_PurchaseAccountId",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_Company_ChartOfAccount_PurchaseReturnAccountId",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_Company_ChartOfAccount_RevenueAccountId",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_Company_ChartOfAccount_SalesReturnAccountId",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_Company_ChartOfAccount_WipAccountId",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_Company_Currency_ReportingCurrencyID",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_Company_Currency_ReportingCurrnecyID",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropTable(
                name: "CashReceiptAdjustment",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "CashReceiptLine",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "InvoiceAllocation",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "CashReceipt",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "SalesInvoiceLine",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "SalesInvoice",
                schema: "Accounting");

            migrationBuilder.DropIndex(
                name: "IX_Company_ReportingCurrencyID",
                schema: "Sec",
                table: "Company");
        }
    }
}
