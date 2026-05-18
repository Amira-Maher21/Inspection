using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addLedgerEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Item_Inventory_Rules",
                schema: "Inventory",
                table: "Item");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Item_Service_No_Stock",
                schema: "Inventory",
                table: "Item");

            migrationBuilder.RenameColumn(
                name: "OperaionId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine",
                newName: "SubcontractBOQId");

            //migrationBuilder.AddColumn<long>(
            //    name: "ChartOfAccountId",
            //    schema: "Accounting",
            //    table: "ModeOfPayment",
            //    type: "bigint",
            //    nullable: false,
            //    defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ActivityId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "BOQItemId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CostCodeId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ProductionOrderId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CurrencyId",
                schema: "Accounting",
                table: "JournalEntryTemplate",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<long>(
                name: "ActivityId",
                schema: "Accounting",
                table: "JournalEntryLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "BOQItemId",
                schema: "Accounting",
                table: "JournalEntryLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CostCodeId",
                schema: "Accounting",
                table: "JournalEntryLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ProductionOrderId",
                schema: "Accounting",
                table: "JournalEntryLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SubcontractBOQId",
                schema: "Accounting",
                table: "JournalEntryLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "WBSId",
                schema: "Accounting",
                table: "JournalEntryLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DocumentCode",
                schema: "Accounting",
                table: "JournalEntry",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Posting",
                schema: "Accounting",
                table: "JournalEntry",
                type: "bit",
                nullable: false,
                defaultValue: false);

            //migrationBuilder.CreateTable(
            //    name: "PostingDocumentType",
            //    schema: "Accounting",
            //    columns: table => new
            //    {
            //        Id = table.Column<long>(type: "bigint", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        DocumentCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        DocumentName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_PostingDocumentType", x => x.Id);
            //    });

            migrationBuilder.CreateTable(
                name: "Ledger",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenant_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    DocumentCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostingDocumentTypeId = table.Column<long>(type: "bigint", nullable: false),
                    ReferenceDocumentId = table.Column<long>(type: "bigint", nullable: false),
                    DocumentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PostingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JournalEntryId = table.Column<long>(type: "bigint", nullable: false),
                    TotalDebit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalCredit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrencyId = table.Column<long>(type: "bigint", nullable: false),
                    BranchId = table.Column<long>(type: "bigint", nullable: false),
                    PostedById = table.Column<long>(type: "bigint", nullable: false),
                    PostedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsReferenceDocumentCanceled = table.Column<bool>(type: "bit", nullable: false),
                    ReverseLedgerId = table.Column<long>(type: "bigint", nullable: true),
                    In_User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ledger", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ledger_Branch_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "Accounting",
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ledger_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalSchema: "Sec",
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ledger_JournalEntry_JournalEntryId",
                        column: x => x.JournalEntryId,
                        principalSchema: "Accounting",
                        principalTable: "JournalEntry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ledger_Ledger_ReverseLedgerId",
                        column: x => x.ReverseLedgerId,
                        principalSchema: "Accounting",
                        principalTable: "Ledger",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ledger_PostingDocumentType_PostingDocumentTypeId",
                        column: x => x.PostingDocumentTypeId,
                        principalSchema: "Accounting",
                        principalTable: "PostingDocumentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            //migrationBuilder.CreateTable(
            //    name: "PostingAccountMapping",
            //    schema: "Accounting",
            //    columns: table => new
            //    {
            //        Id = table.Column<long>(type: "bigint", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        PostingKey = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        AccountSource = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        PostingDocumentTypeId = table.Column<long>(type: "bigint", nullable: false),
            //        ChartOfAccountId = table.Column<long>(type: "bigint", nullable: true),
            //        Side = table.Column<int>(type: "int", nullable: false),
            //        Priority = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_PostingAccountMapping", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_PostingAccountMapping_ChartOfAccount_ChartOfAccountId",
            //            column: x => x.ChartOfAccountId,
            //            principalSchema: "Accounting",
            //            principalTable: "ChartOfAccount",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_PostingAccountMapping_PostingDocumentType_PostingDocumentTypeId",
            //            column: x => x.PostingDocumentTypeId,
            //            principalSchema: "Accounting",
            //            principalTable: "PostingDocumentType",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            migrationBuilder.CreateTable(
                name: "LedgerLine",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LedgerId = table.Column<long>(type: "bigint", nullable: false),
                    ChartOfAccountId = table.Column<long>(type: "bigint", nullable: true),
                    DebitAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreditAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CostCenterId = table.Column<long>(type: "bigint", nullable: true),
                    CostUnitId = table.Column<long>(type: "bigint", nullable: true),
                    OperationId = table.Column<long>(type: "bigint", nullable: true),
                    WBSId = table.Column<long>(type: "bigint", nullable: true),
                    CostCodeId = table.Column<long>(type: "bigint", nullable: true),
                    ActivityId = table.Column<long>(type: "bigint", nullable: true),
                    BOQItemId = table.Column<long>(type: "bigint", nullable: true),
                    SubcontractBOQId = table.Column<long>(type: "bigint", nullable: true),
                    ProductionOrderId = table.Column<long>(type: "bigint", nullable: true),
                    In_User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LedgerLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LedgerLine_ChartOfAccount_ChartOfAccountId",
                        column: x => x.ChartOfAccountId,
                        principalSchema: "Accounting",
                        principalTable: "ChartOfAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LedgerLine_CostCenter_CostCenterId",
                        column: x => x.CostCenterId,
                        principalSchema: "Accounting",
                        principalTable: "CostCenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LedgerLine_CostUnit_CostUnitId",
                        column: x => x.CostUnitId,
                        principalSchema: "Accounting",
                        principalTable: "CostUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LedgerLine_Ledger_LedgerId",
                        column: x => x.LedgerId,
                        principalSchema: "Accounting",
                        principalTable: "Ledger",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LedgerLine_Operation_OperationId",
                        column: x => x.OperationId,
                        principalSchema: "Sec",
                        principalTable: "Operation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            //migrationBuilder.CreateIndex(
            //    name: "IX_ModeOfPayment_ChartOfAccountId",
            //    schema: "Accounting",
            //    table: "ModeOfPayment",
            //    column: "ChartOfAccountId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_JournalEntryTemplate_BranchId",
            //    schema: "Accounting",
            //    table: "JournalEntryTemplate",
            //    column: "BranchId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_JournalEntryTemplate_CurrencyId",
            //    schema: "Accounting",
            //    table: "JournalEntryTemplate",
            //    column: "CurrencyId");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Item_Inventory_Rules",
                schema: "Inventory",
                table: "Item",
                sql: "([ItemType] <> 1) OR ([IsStocked] = 1 AND [UnitOfMeasureId] IS NOT NULL)");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Item_Service_No_Stock",
                schema: "Inventory",
                table: "Item",
                sql: "([ItemType] <> 2) OR ([IsStocked] = 0 AND [IsSerialTracked] = 0 AND [IsBatchTracked] = 0 AND [IsExpiryTracked] = 0)");

            migrationBuilder.CreateIndex(
                name: "IX_Ledger_BranchId",
                schema: "Accounting",
                table: "Ledger",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Ledger_CompanyId_BranchId",
                schema: "Accounting",
                table: "Ledger",
                columns: new[] { "CompanyId", "BranchId" });

            migrationBuilder.CreateIndex(
                name: "IX_Ledger_CurrencyId",
                schema: "Accounting",
                table: "Ledger",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Ledger_JournalEntryId",
                schema: "Accounting",
                table: "Ledger",
                column: "JournalEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_Ledger_PostingDate",
                schema: "Accounting",
                table: "Ledger",
                column: "PostingDate");

            migrationBuilder.CreateIndex(
                name: "IX_Ledger_PostingDocumentTypeId",
                schema: "Accounting",
                table: "Ledger",
                column: "PostingDocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ledger_ReverseLedgerId",
                schema: "Accounting",
                table: "Ledger",
                column: "ReverseLedgerId");

            migrationBuilder.CreateIndex(
                name: "IX_Ledger_Tenant_ID",
                schema: "Accounting",
                table: "Ledger",
                column: "Tenant_ID");

            migrationBuilder.CreateIndex(
                name: "IX_LedgerLine_ChartOfAccountId",
                schema: "Accounting",
                table: "LedgerLine",
                column: "ChartOfAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_LedgerLine_CostCenterId",
                schema: "Accounting",
                table: "LedgerLine",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_LedgerLine_CostUnitId",
                schema: "Accounting",
                table: "LedgerLine",
                column: "CostUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_LedgerLine_LedgerId",
                schema: "Accounting",
                table: "LedgerLine",
                column: "LedgerId");

            migrationBuilder.CreateIndex(
                name: "IX_LedgerLine_OperationId",
                schema: "Accounting",
                table: "LedgerLine",
                column: "OperationId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_PostingAccountMapping_ChartOfAccountId",
            //    schema: "Accounting",
            //    table: "PostingAccountMapping",
            //    column: "ChartOfAccountId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_PostingAccountMapping_PostingDocumentTypeId",
            //    schema: "Accounting",
            //    table: "PostingAccountMapping",
            //    column: "PostingDocumentTypeId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_JournalEntryTemplate_Branch_BranchId",
            //    schema: "Accounting",
            //    table: "JournalEntryTemplate",
            //    column: "BranchId",
            //    principalSchema: "Accounting",
            //    principalTable: "Branch",
            //    principalColumn: "Id");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_JournalEntryTemplate_Currency_CurrencyId",
            //    schema: "Accounting",
            //    table: "JournalEntryTemplate",
            //    column: "CurrencyId",
            //    principalSchema: "Sec",
            //    principalTable: "Currency",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ModeOfPayment_ChartOfAccount_ChartOfAccountId",
            //    schema: "Accounting",
            //    table: "ModeOfPayment",
            //    column: "ChartOfAccountId",
            //    principalSchema: "Accounting",
            //    principalTable: "ChartOfAccount",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntryTemplate_Branch_BranchId",
                schema: "Accounting",
                table: "JournalEntryTemplate");

            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntryTemplate_Currency_CurrencyId",
                schema: "Accounting",
                table: "JournalEntryTemplate");

            migrationBuilder.DropForeignKey(
                name: "FK_ModeOfPayment_ChartOfAccount_ChartOfAccountId",
                schema: "Accounting",
                table: "ModeOfPayment");

            migrationBuilder.DropTable(
                name: "LedgerLine",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "PostingAccountMapping",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "Ledger",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "PostingDocumentType",
                schema: "Accounting");

            migrationBuilder.DropIndex(
                name: "IX_ModeOfPayment_ChartOfAccountId",
                schema: "Accounting",
                table: "ModeOfPayment");

            migrationBuilder.DropIndex(
                name: "IX_JournalEntryTemplate_BranchId",
                schema: "Accounting",
                table: "JournalEntryTemplate");

            migrationBuilder.DropIndex(
                name: "IX_JournalEntryTemplate_CurrencyId",
                schema: "Accounting",
                table: "JournalEntryTemplate");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Item_Inventory_Rules",
                schema: "Inventory",
                table: "Item");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Item_Service_No_Stock",
                schema: "Inventory",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "ChartOfAccountId",
                schema: "Accounting",
                table: "ModeOfPayment");

            migrationBuilder.DropColumn(
                name: "ActivityId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine");

            migrationBuilder.DropColumn(
                name: "BOQItemId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine");

            migrationBuilder.DropColumn(
                name: "CostCodeId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine");

            migrationBuilder.DropColumn(
                name: "ProductionOrderId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine");

            migrationBuilder.DropColumn(
                name: "ActivityId",
                schema: "Accounting",
                table: "JournalEntryLine");

            migrationBuilder.DropColumn(
                name: "BOQItemId",
                schema: "Accounting",
                table: "JournalEntryLine");

            migrationBuilder.DropColumn(
                name: "CostCodeId",
                schema: "Accounting",
                table: "JournalEntryLine");

            migrationBuilder.DropColumn(
                name: "ProductionOrderId",
                schema: "Accounting",
                table: "JournalEntryLine");

            migrationBuilder.DropColumn(
                name: "SubcontractBOQId",
                schema: "Accounting",
                table: "JournalEntryLine");

            migrationBuilder.DropColumn(
                name: "WBSId",
                schema: "Accounting",
                table: "JournalEntryLine");

            migrationBuilder.DropColumn(
                name: "DocumentCode",
                schema: "Accounting",
                table: "JournalEntry");

            migrationBuilder.DropColumn(
                name: "Posting",
                schema: "Accounting",
                table: "JournalEntry");

            migrationBuilder.RenameColumn(
                name: "SubcontractBOQId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine",
                newName: "OperaionId");

            migrationBuilder.AlterColumn<int>(
                name: "CurrencyId",
                schema: "Accounting",
                table: "JournalEntryTemplate",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Item_Inventory_Rules",
                schema: "Inventory",
                table: "Item",
                sql: "([ItemType] <> 'Inventory') OR ([IsStocked] = 1 AND [UnitOfMeasureId] IS NOT NULL)");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Item_Service_No_Stock",
                schema: "Inventory",
                table: "Item",
                sql: "([ItemType] <> 'Service') OR ([IsStocked] = 0 AND [IsSerialTracked] = 0 AND [IsBatchTracked] = 0 AND [IsExpiryTracked] = 0)");
        }
    }
}
