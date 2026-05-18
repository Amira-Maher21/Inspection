using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EditPostingEngineTables : Migration
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

            migrationBuilder.DropColumn(
                name: "ArabicDescription",
                schema: "Inventory",
                table: "InventoryLedger");

            migrationBuilder.DropColumn(
                name: "IsPosted",
                schema: "Inventory",
                table: "InventoryLedger");



            migrationBuilder.RenameColumn(
                name: "SourceId",
                schema: "Inventory",
                table: "InventoryLedger",
                newName: "ReferenceDocumentId");

            migrationBuilder.RenameColumn(
                name: "SourceTransactionId",
                schema: "Inventory",
                table: "InventoryCostLayer",
                newName: "ReferenceDocumentId");

            migrationBuilder.AlterColumn<int>(
                name: "CostingMethod",
                schema: "Inventory",
                table: "InventoryLedger",
                type: "int",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<long>(
                name: "CompanyId",
                schema: "Inventory",
                table: "InventoryLedger",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "PostingDocumentTypeId",
                schema: "Inventory",
                table: "InventoryLedger",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "PostingDocumentTypeId",
                schema: "Inventory",
                table: "InventoryCostLayer",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<long>(
                name: "BranchId",
                schema: "Inventory",
                table: "GoodsReceipt",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "AccountBalance",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenant_ID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    BranchId = table.Column<long>(type: "bigint", nullable: false),
                    TotalDebit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalCredit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ChartOfAccountId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountBalance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountBalance_Branch_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "Accounting",
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountBalance_ChartOfAccount_ChartOfAccountId",
                        column: x => x.ChartOfAccountId,
                        principalSchema: "Accounting",
                        principalTable: "ChartOfAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_InventoryLedger_PostingDocumentTypeId",
                schema: "Inventory",
                table: "InventoryLedger",
                column: "PostingDocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryCostLayer_PostingDocumentTypeId",
                schema: "Inventory",
                table: "InventoryCostLayer",
                column: "PostingDocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountBalance_BranchId",
                table: "AccountBalance",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountBalance_ChartOfAccountId",
                table: "AccountBalance",
                column: "ChartOfAccountId");


            migrationBuilder.AddForeignKey(
                name: "FK_InventoryCostLayer_PostingDocumentType_PostingDocumentTypeId",
                schema: "Inventory",
                table: "InventoryCostLayer",
                column: "PostingDocumentTypeId",
                principalSchema: "Accounting",
                principalTable: "PostingDocumentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryLedger_PostingDocumentType_PostingDocumentTypeId",
                schema: "Inventory",
                table: "InventoryLedger",
                column: "PostingDocumentTypeId",
                principalSchema: "Accounting",
                principalTable: "PostingDocumentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryCostLayer_PostingDocumentType_PostingDocumentTypeId",
                schema: "Inventory",
                table: "InventoryCostLayer");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryLedger_PostingDocumentType_PostingDocumentTypeId",
                schema: "Inventory",
                table: "InventoryLedger");

            migrationBuilder.DropTable(
                name: "AccountBalance");

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

            migrationBuilder.DropCheckConstraint(
                name: "CK_Item_Inventory_Rules",
                schema: "Inventory",
                table: "Item");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Item_Service_No_Stock",
                schema: "Inventory",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_InventoryLedger_PostingDocumentTypeId",
                schema: "Inventory",
                table: "InventoryLedger");

            migrationBuilder.DropIndex(
                name: "IX_InventoryCostLayer_PostingDocumentTypeId",
                schema: "Inventory",
                table: "InventoryCostLayer");

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
                name: "ExchangeRate",
                schema: "Accounting",
                table: "JournalEntry");

            migrationBuilder.DropColumn(
                name: "Posting",
                schema: "Accounting",
                table: "JournalEntry");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                schema: "Inventory",
                table: "InventoryLedger");

            migrationBuilder.DropColumn(
                name: "PostingDocumentTypeId",
                schema: "Inventory",
                table: "InventoryLedger");

            migrationBuilder.DropColumn(
                name: "PostingDocumentTypeId",
                schema: "Inventory",
                table: "InventoryCostLayer");

            migrationBuilder.DropColumn(
                name: "ActivityId",
                schema: "Inventory",
                table: "GoodsReceiptLine");

            migrationBuilder.DropColumn(
                name: "BOQItemId",
                schema: "Inventory",
                table: "GoodsReceiptLine");

            migrationBuilder.DropColumn(
                name: "CostCodeId",
                schema: "Inventory",
                table: "GoodsReceiptLine");

            migrationBuilder.DropColumn(
                name: "OperationId",
                schema: "Inventory",
                table: "GoodsReceiptLine");

            migrationBuilder.DropColumn(
                name: "ProductionOrderId",
                schema: "Inventory",
                table: "GoodsReceiptLine");

            migrationBuilder.DropColumn(
                name: "SubcontractBOQId",
                schema: "Inventory",
                table: "GoodsReceiptLine");

            migrationBuilder.DropColumn(
                name: "WBSId",
                schema: "Inventory",
                table: "GoodsReceiptLine");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                schema: "Inventory",
                table: "GoodsReceipt");

            migrationBuilder.DropColumn(
                name: "DocumentCode",
                schema: "Inventory",
                table: "GoodsReceipt");

            migrationBuilder.DropColumn(
                name: "ExchangeRate",
                schema: "Inventory",
                table: "GoodsReceipt");

            migrationBuilder.DropColumn(
                name: "Posting",
                schema: "Inventory",
                table: "GoodsReceipt");

            migrationBuilder.DropColumn(
                name: "TotalCredit",
                schema: "Inventory",
                table: "GoodsReceipt");

            migrationBuilder.DropColumn(
                name: "TotalDebit",
                schema: "Inventory",
                table: "GoodsReceipt");

            migrationBuilder.RenameColumn(
                name: "SubcontractBOQId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine",
                newName: "OperaionId");

            migrationBuilder.RenameColumn(
                name: "ReferenceDocumentId",
                schema: "Inventory",
                table: "InventoryLedger",
                newName: "SourceId");

            migrationBuilder.RenameColumn(
                name: "ReferenceDocumentId",
                schema: "Inventory",
                table: "InventoryCostLayer",
                newName: "SourceTransactionId");

            migrationBuilder.AlterColumn<string>(
                name: "CostingMethod",
                schema: "Inventory",
                table: "InventoryLedger",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<string>(
                name: "ArabicDescription",
                schema: "Inventory",
                table: "InventoryLedger",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPosted",
                schema: "Inventory",
                table: "InventoryLedger",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<long>(
                name: "BranchId",
                schema: "Inventory",
                table: "GoodsReceipt",
                type: "bigint",
                nullable: true,
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
