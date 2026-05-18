using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitCashTransfer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CashTransfer",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenant_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    TransferNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BranchId = table.Column<long>(type: "bigint", nullable: false),
                    FiscalYearId = table.Column<long>(type: "bigint", nullable: false),
                    ChartOfAccountFromId = table.Column<long>(type: "bigint", nullable: false),
                    ChartOfAccountToId = table.Column<long>(type: "bigint", nullable: false),
                    ModeOfPaymentFromId = table.Column<long>(type: "bigint", nullable: false),
                    ModeOfPaymentToId = table.Column<long>(type: "bigint", nullable: false),
                    CurrencyId = table.Column<long>(type: "bigint", nullable: false),
                    TransferDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    IsInTransit = table.Column<bool>(type: "bit", nullable: false),
                    Posting = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ReferenceNumber = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ReferenceDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SeriesId = table.Column<long>(type: "bigint", nullable: true),
                    RunningNumber = table.Column<int>(type: "int", nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashTransfer", x => x.Id);
                    table.CheckConstraint("CK_CashTransfer_Amount", "[Amount] > 0");
                    table.CheckConstraint("CK_CashTransfer_DifferentAccounts", "[ChartOfAccountFromId] <> [ChartOfAccountToId]");
                    table.CheckConstraint("CK_CashTransfer_Posting", "[Posting] IN (1,2,3)");
                    table.ForeignKey(
                        name: "FK_CashTransfer_Branch_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "Accounting",
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashTransfer_ChartOfAccount_ChartOfAccountFromId",
                        column: x => x.ChartOfAccountFromId,
                        principalSchema: "Accounting",
                        principalTable: "ChartOfAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashTransfer_ChartOfAccount_ChartOfAccountToId",
                        column: x => x.ChartOfAccountToId,
                        principalSchema: "Accounting",
                        principalTable: "ChartOfAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashTransfer_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalSchema: "Sec",
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashTransfer_FiscalYear_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalSchema: "Accounting",
                        principalTable: "FiscalYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashTransfer_ModeOfPayment_ModeOfPaymentFromId",
                        column: x => x.ModeOfPaymentFromId,
                        principalSchema: "Accounting",
                        principalTable: "ModeOfPayment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashTransfer_ModeOfPayment_ModeOfPaymentToId",
                        column: x => x.ModeOfPaymentToId,
                        principalSchema: "Accounting",
                        principalTable: "ModeOfPayment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashTransfer_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalSchema: "Stt",
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CashTransferLine",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CashTransferId = table.Column<long>(type: "bigint", nullable: false),
                    ChartOfAccountId = table.Column<long>(type: "bigint", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashTransferLine", x => x.Id);
                    table.CheckConstraint("CK_CashTransferLine_Amount", "[Amount] > 0");
                    table.ForeignKey(
                        name: "FK_CashTransferLine_CashTransfer_CashTransferId",
                        column: x => x.CashTransferId,
                        principalSchema: "Accounting",
                        principalTable: "CashTransfer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CashTransferLine_ChartOfAccount_ChartOfAccountId",
                        column: x => x.ChartOfAccountId,
                        principalSchema: "Accounting",
                        principalTable: "ChartOfAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CashTransfer_BranchId",
                schema: "Accounting",
                table: "CashTransfer",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_CashTransfer_ChartOfAccountFromId",
                schema: "Accounting",
                table: "CashTransfer",
                column: "ChartOfAccountFromId");

            migrationBuilder.CreateIndex(
                name: "IX_CashTransfer_ChartOfAccountToId",
                schema: "Accounting",
                table: "CashTransfer",
                column: "ChartOfAccountToId");

            migrationBuilder.CreateIndex(
                name: "IX_CashTransfer_CurrencyId",
                schema: "Accounting",
                table: "CashTransfer",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_CashTransfer_FiscalYearId",
                schema: "Accounting",
                table: "CashTransfer",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_CashTransfer_ModeOfPaymentFromId",
                schema: "Accounting",
                table: "CashTransfer",
                column: "ModeOfPaymentFromId");

            migrationBuilder.CreateIndex(
                name: "IX_CashTransfer_ModeOfPaymentToId",
                schema: "Accounting",
                table: "CashTransfer",
                column: "ModeOfPaymentToId");

            migrationBuilder.CreateIndex(
                name: "IX_CashTransfer_SeriesId",
                schema: "Accounting",
                table: "CashTransfer",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_CashTransfer_Tenant_ID_CompanyId_BranchId_TransferNumber",
                schema: "Accounting",
                table: "CashTransfer",
                columns: new[] { "Tenant_ID", "CompanyId", "BranchId", "TransferNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CashTransferLine_CashTransferId",
                schema: "Accounting",
                table: "CashTransferLine",
                column: "CashTransferId");

            migrationBuilder.CreateIndex(
                name: "IX_CashTransferLine_ChartOfAccountId",
                schema: "Accounting",
                table: "CashTransferLine",
                column: "ChartOfAccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CashTransferLine",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "CashTransfer",
                schema: "Accounting");
        }
    }
}
