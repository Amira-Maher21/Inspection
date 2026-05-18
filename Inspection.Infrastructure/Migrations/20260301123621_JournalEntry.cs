using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class JournalEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JournalEntry",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    JournalNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FiscalYearId = table.Column<long>(type: "bigint", nullable: false),
                    JournalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PostingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BranchId = table.Column<long>(type: "bigint", nullable: false),
                    CurrencyId = table.Column<long>(type: "bigint", nullable: false),
                    JournalEntryTemplateId = table.Column<long>(type: "bigint", nullable: true),
                    IsReverseJournal = table.Column<bool>(type: "bit", nullable: true),
                    ReversalOfJournalEntryId = table.Column<long>(type: "bigint", nullable: true),
                    TotalDebit = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    TotalCredit = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    ReferenceNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ReferenceDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BillNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BillDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModeOfPaymentId = table.Column<long>(type: "bigint", nullable: true),
                    DocumentStatus = table.Column<int>(type: "int", nullable: true),
                    ApprovalStatus = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SeriesId = table.Column<long>(type: "bigint", nullable: true),
                    RunningNumber = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Tenant_ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalEntry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JournalEntry_Branch_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "Accounting",
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JournalEntry_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalSchema: "Sec",
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JournalEntry_FiscalYear_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalSchema: "Accounting",
                        principalTable: "FiscalYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JournalEntry_JournalEntryTemplate_JournalEntryTemplateId",
                        column: x => x.JournalEntryTemplateId,
                        principalSchema: "Accounting",
                        principalTable: "JournalEntryTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JournalEntry_ModeOfPayment_ModeOfPaymentId",
                        column: x => x.ModeOfPaymentId,
                        principalSchema: "Accounting",
                        principalTable: "ModeOfPayment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JournalEntry_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalSchema: "Stt",
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JournalEntryLine",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JournalEntryId = table.Column<long>(type: "bigint", nullable: false),
                    ChartOfAccountId = table.Column<long>(type: "bigint", nullable: false),
                    DebitAmount = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    CreditAmount = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    CostCenterId = table.Column<long>(type: "bigint", nullable: true),
                    OperationId = table.Column<long>(type: "bigint", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalEntryLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JournalEntryLine_ChartOfAccount_ChartOfAccountId",
                        column: x => x.ChartOfAccountId,
                        principalSchema: "Accounting",
                        principalTable: "ChartOfAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JournalEntryLine_CostCenter_CostCenterId",
                        column: x => x.CostCenterId,
                        principalSchema: "Accounting",
                        principalTable: "CostCenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JournalEntryLine_JournalEntry_JournalEntryId",
                        column: x => x.JournalEntryId,
                        principalSchema: "Accounting",
                        principalTable: "JournalEntry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JournalEntryLine_Operation_OperationId",
                        column: x => x.OperationId,
                        principalSchema: "Sec",
                        principalTable: "Operation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntry_BranchId",
                schema: "Accounting",
                table: "JournalEntry",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntry_CurrencyId",
                schema: "Accounting",
                table: "JournalEntry",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntry_FiscalYearId",
                schema: "Accounting",
                table: "JournalEntry",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntry_JournalEntryTemplateId",
                schema: "Accounting",
                table: "JournalEntry",
                column: "JournalEntryTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntry_ModeOfPaymentId",
                schema: "Accounting",
                table: "JournalEntry",
                column: "ModeOfPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntry_SeriesId",
                schema: "Accounting",
                table: "JournalEntry",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntryLine_ChartOfAccountId",
                schema: "Accounting",
                table: "JournalEntryLine",
                column: "ChartOfAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntryLine_CostCenterId",
                schema: "Accounting",
                table: "JournalEntryLine",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntryLine_JournalEntryId",
                schema: "Accounting",
                table: "JournalEntryLine",
                column: "JournalEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntryLine_OperationId",
                schema: "Accounting",
                table: "JournalEntryLine",
                column: "OperationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JournalEntryLine",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "JournalEntry",
                schema: "Accounting");
        }
    }
}
