using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EditPostingTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntry_ModeOfPayment_ModeOfPaymentId",
                schema: "Accounting",
                table: "JournalEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntryTemplate_Branch_BranchId",
                schema: "Accounting",
                table: "JournalEntryTemplate");

            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntryTemplate_ModeOfPayment_ModeOfPaymentId",
                schema: "Accounting",
                table: "JournalEntryTemplate");

            migrationBuilder.DropIndex(
                name: "IX_JournalEntryTemplate_BranchId",
                schema: "Accounting",
                table: "JournalEntryTemplate");

            migrationBuilder.DropIndex(
                name: "IX_JournalEntryTemplate_ModeOfPaymentId",
                schema: "Accounting",
                table: "JournalEntryTemplate");

            migrationBuilder.DropIndex(
                name: "IX_JournalEntry_ModeOfPaymentId",
                schema: "Accounting",
                table: "JournalEntry");

            migrationBuilder.DropColumn(
                name: "BillDate",
                schema: "Accounting",
                table: "JournalEntryTemplate");

            migrationBuilder.DropColumn(
                name: "BillNo",
                schema: "Accounting",
                table: "JournalEntryTemplate");

            migrationBuilder.DropColumn(
                name: "BranchId",
                schema: "Accounting",
                table: "JournalEntryTemplate");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                schema: "Accounting",
                table: "JournalEntryTemplate");

            migrationBuilder.DropColumn(
                name: "DueDate",
                schema: "Accounting",
                table: "JournalEntryTemplate");

            migrationBuilder.DropColumn(
                name: "ModeOfPaymentId",
                schema: "Accounting",
                table: "JournalEntryTemplate");

            migrationBuilder.DropColumn(
                name: "ReferenceDate",
                schema: "Accounting",
                table: "JournalEntryTemplate");

            migrationBuilder.DropColumn(
                name: "ReferenceNumber",
                schema: "Accounting",
                table: "JournalEntryTemplate");

            migrationBuilder.DropColumn(
                name: "BillDate",
                schema: "Accounting",
                table: "JournalEntry");

            migrationBuilder.DropColumn(
                name: "BillNo",
                schema: "Accounting",
                table: "JournalEntry");

            migrationBuilder.DropColumn(
                name: "DueDate",
                schema: "Accounting",
                table: "JournalEntry");

            migrationBuilder.DropColumn(
                name: "ModeOfPaymentId",
                schema: "Accounting",
                table: "JournalEntry");

            migrationBuilder.AddColumn<string>(
                name: "Screen_CodeId",
                schema: "Accounting",
                table: "PostingDocumentType",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "BaseCreditAmount",
                schema: "Accounting",
                table: "LedgerLine",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "BaseDebitAmount",
                schema: "Accounting",
                table: "LedgerLine",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<long>(
                name: "CustomerId",
                schema: "Accounting",
                table: "LedgerLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "OfficialCreditAmount",
                schema: "Accounting",
                table: "LedgerLine",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "OfficialDebitAmount",
                schema: "Accounting",
                table: "LedgerLine",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ReportingDebitAmount",
                schema: "Accounting",
                table: "LedgerLine",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ReportingOfficialCreditAmount",
                schema: "Accounting",
                table: "LedgerLine",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<long>(
                name: "SupplierId",
                schema: "Accounting",
                table: "LedgerLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ExchangeRate",
                schema: "Accounting",
                table: "Ledger",
                type: "decimal(18,6)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ExchangeRateOfficialCurrency",
                schema: "Accounting",
                table: "Ledger",
                type: "decimal(18,6)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ExchangeRateReportingCurrency",
                schema: "Accounting",
                table: "Ledger",
                type: "decimal(18,6)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<long>(
                name: "OfficialCurrencyId",
                schema: "Accounting",
                table: "Ledger",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ReportingCurrencyId",
                schema: "Accounting",
                table: "Ledger",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CustomerId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SupplierId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CustomerId",
                schema: "Accounting",
                table: "JournalEntryLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SupplierId",
                schema: "Accounting",
                table: "JournalEntryLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PostingDocumentType_Screen_CodeId",
                schema: "Accounting",
                table: "PostingDocumentType",
                column: "Screen_CodeId");

            migrationBuilder.CreateIndex(
                name: "IX_LedgerLine_CustomerId",
                schema: "Accounting",
                table: "LedgerLine",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_LedgerLine_SupplierId",
                schema: "Accounting",
                table: "LedgerLine",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Ledger_OfficialCurrencyId",
                schema: "Accounting",
                table: "Ledger",
                column: "OfficialCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Ledger_ReportingCurrencyId",
                schema: "Accounting",
                table: "Ledger",
                column: "ReportingCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntryTemplateLine_CustomerId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntryTemplateLine_SupplierId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntryLine_CustomerId",
                schema: "Accounting",
                table: "JournalEntryLine",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntryLine_SupplierId",
                schema: "Accounting",
                table: "JournalEntryLine",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntryLine_Customer_CustomerId",
                schema: "Accounting",
                table: "JournalEntryLine",
                column: "CustomerId",
                principalSchema: "Accounting",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntryLine_Supplier_SupplierId",
                schema: "Accounting",
                table: "JournalEntryLine",
                column: "SupplierId",
                principalSchema: "Accounting",
                principalTable: "Supplier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntryTemplateLine_Customer_CustomerId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine",
                column: "CustomerId",
                principalSchema: "Accounting",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntryTemplateLine_Supplier_SupplierId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine",
                column: "SupplierId",
                principalSchema: "Accounting",
                principalTable: "Supplier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ledger_Currency_OfficialCurrencyId",
                schema: "Accounting",
                table: "Ledger",
                column: "OfficialCurrencyId",
                principalSchema: "Sec",
                principalTable: "Currency",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ledger_Currency_ReportingCurrencyId",
                schema: "Accounting",
                table: "Ledger",
                column: "ReportingCurrencyId",
                principalSchema: "Sec",
                principalTable: "Currency",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LedgerLine_Customer_CustomerId",
                schema: "Accounting",
                table: "LedgerLine",
                column: "CustomerId",
                principalSchema: "Accounting",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LedgerLine_Supplier_SupplierId",
                schema: "Accounting",
                table: "LedgerLine",
                column: "SupplierId",
                principalSchema: "Accounting",
                principalTable: "Supplier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostingDocumentType_Screen_Code_Screen_CodeId",
                schema: "Accounting",
                table: "PostingDocumentType",
                column: "Screen_CodeId",
                principalSchema: "Syst",
                principalTable: "Screen_Code",
                principalColumn: "Screen_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntryLine_Customer_CustomerId",
                schema: "Accounting",
                table: "JournalEntryLine");

            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntryLine_Supplier_SupplierId",
                schema: "Accounting",
                table: "JournalEntryLine");

            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntryTemplateLine_Customer_CustomerId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine");

            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntryTemplateLine_Supplier_SupplierId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine");

            migrationBuilder.DropForeignKey(
                name: "FK_Ledger_Currency_OfficialCurrencyId",
                schema: "Accounting",
                table: "Ledger");

            migrationBuilder.DropForeignKey(
                name: "FK_Ledger_Currency_ReportingCurrencyId",
                schema: "Accounting",
                table: "Ledger");

            migrationBuilder.DropForeignKey(
                name: "FK_LedgerLine_Customer_CustomerId",
                schema: "Accounting",
                table: "LedgerLine");

            migrationBuilder.DropForeignKey(
                name: "FK_LedgerLine_Supplier_SupplierId",
                schema: "Accounting",
                table: "LedgerLine");

            migrationBuilder.DropForeignKey(
                name: "FK_PostingDocumentType_Screen_Code_Screen_CodeId",
                schema: "Accounting",
                table: "PostingDocumentType");

            migrationBuilder.DropIndex(
                name: "IX_PostingDocumentType_Screen_CodeId",
                schema: "Accounting",
                table: "PostingDocumentType");

            migrationBuilder.DropIndex(
                name: "IX_LedgerLine_CustomerId",
                schema: "Accounting",
                table: "LedgerLine");

            migrationBuilder.DropIndex(
                name: "IX_LedgerLine_SupplierId",
                schema: "Accounting",
                table: "LedgerLine");

            migrationBuilder.DropIndex(
                name: "IX_Ledger_OfficialCurrencyId",
                schema: "Accounting",
                table: "Ledger");

            migrationBuilder.DropIndex(
                name: "IX_Ledger_ReportingCurrencyId",
                schema: "Accounting",
                table: "Ledger");

            migrationBuilder.DropIndex(
                name: "IX_JournalEntryTemplateLine_CustomerId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine");

            migrationBuilder.DropIndex(
                name: "IX_JournalEntryTemplateLine_SupplierId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine");

            migrationBuilder.DropIndex(
                name: "IX_JournalEntryLine_CustomerId",
                schema: "Accounting",
                table: "JournalEntryLine");

            migrationBuilder.DropIndex(
                name: "IX_JournalEntryLine_SupplierId",
                schema: "Accounting",
                table: "JournalEntryLine");

            migrationBuilder.DropColumn(
                name: "Screen_CodeId",
                schema: "Accounting",
                table: "PostingDocumentType");

            migrationBuilder.DropColumn(
                name: "BaseCreditAmount",
                schema: "Accounting",
                table: "LedgerLine");

            migrationBuilder.DropColumn(
                name: "BaseDebitAmount",
                schema: "Accounting",
                table: "LedgerLine");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                schema: "Accounting",
                table: "LedgerLine");

            migrationBuilder.DropColumn(
                name: "OfficialCreditAmount",
                schema: "Accounting",
                table: "LedgerLine");

            migrationBuilder.DropColumn(
                name: "OfficialDebitAmount",
                schema: "Accounting",
                table: "LedgerLine");

            migrationBuilder.DropColumn(
                name: "ReportingDebitAmount",
                schema: "Accounting",
                table: "LedgerLine");

            migrationBuilder.DropColumn(
                name: "ReportingOfficialCreditAmount",
                schema: "Accounting",
                table: "LedgerLine");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                schema: "Accounting",
                table: "LedgerLine");

            migrationBuilder.DropColumn(
                name: "ExchangeRate",
                schema: "Accounting",
                table: "Ledger");

            migrationBuilder.DropColumn(
                name: "ExchangeRateOfficialCurrency",
                schema: "Accounting",
                table: "Ledger");

            migrationBuilder.DropColumn(
                name: "ExchangeRateReportingCurrency",
                schema: "Accounting",
                table: "Ledger");

            migrationBuilder.DropColumn(
                name: "OfficialCurrencyId",
                schema: "Accounting",
                table: "Ledger");

            migrationBuilder.DropColumn(
                name: "ReportingCurrencyId",
                schema: "Accounting",
                table: "Ledger");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                schema: "Accounting",
                table: "JournalEntryLine");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                schema: "Accounting",
                table: "JournalEntryLine");

            migrationBuilder.AddColumn<DateTime>(
                name: "BillDate",
                schema: "Accounting",
                table: "JournalEntryTemplate",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillNo",
                schema: "Accounting",
                table: "JournalEntryTemplate",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "BranchId",
                schema: "Accounting",
                table: "JournalEntryTemplate",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CompanyId",
                schema: "Accounting",
                table: "JournalEntryTemplate",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                schema: "Accounting",
                table: "JournalEntryTemplate",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ModeOfPaymentId",
                schema: "Accounting",
                table: "JournalEntryTemplate",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReferenceDate",
                schema: "Accounting",
                table: "JournalEntryTemplate",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReferenceNumber",
                schema: "Accounting",
                table: "JournalEntryTemplate",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BillDate",
                schema: "Accounting",
                table: "JournalEntry",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillNo",
                schema: "Accounting",
                table: "JournalEntry",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                schema: "Accounting",
                table: "JournalEntry",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ModeOfPaymentId",
                schema: "Accounting",
                table: "JournalEntry",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntryTemplate_BranchId",
                schema: "Accounting",
                table: "JournalEntryTemplate",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntryTemplate_ModeOfPaymentId",
                schema: "Accounting",
                table: "JournalEntryTemplate",
                column: "ModeOfPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntry_ModeOfPaymentId",
                schema: "Accounting",
                table: "JournalEntry",
                column: "ModeOfPaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntry_ModeOfPayment_ModeOfPaymentId",
                schema: "Accounting",
                table: "JournalEntry",
                column: "ModeOfPaymentId",
                principalSchema: "Accounting",
                principalTable: "ModeOfPayment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntryTemplate_Branch_BranchId",
                schema: "Accounting",
                table: "JournalEntryTemplate",
                column: "BranchId",
                principalSchema: "Accounting",
                principalTable: "Branch",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntryTemplate_ModeOfPayment_ModeOfPaymentId",
                schema: "Accounting",
                table: "JournalEntryTemplate",
                column: "ModeOfPaymentId",
                principalSchema: "Accounting",
                principalTable: "ModeOfPayment",
                principalColumn: "Id");
        }
    }
}
