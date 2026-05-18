using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class makemodeofpaymentandjurnerytempleteandjurnerytempleteline : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.CreateTable(
                name: "JournalEntryTemplate",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<long>(type: "bigint", nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BranchId = table.Column<long>(type: "bigint", nullable: true),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    TotalDebit = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    TotalCredit = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    ReferenceNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ReferenceDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BillNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BillDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentModeCodeId = table.Column<long>(type: "bigint", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Tenant_ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SeriesId = table.Column<long>(type: "bigint", nullable: true),
                    RunningNumber = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalEntryTemplate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JournalEntryTemplate_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalSchema: "Stt",
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JournalEntryTemplateLine",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JournalEntryId = table.Column<long>(type: "bigint", nullable: false),
                    AccountId = table.Column<long>(type: "bigint", nullable: false),
                    DebitAmount = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    CreditAmount = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    CostCenterId = table.Column<long>(type: "bigint", nullable: true),
                    CostUnitId = table.Column<long>(type: "bigint", nullable: true),
                    OperaionId = table.Column<long>(type: "bigint", nullable: true),
                    WBSId = table.Column<long>(type: "bigint", nullable: true),
                    ItemWorkId = table.Column<long>(type: "bigint", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalEntryTemplateLine", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModeOfPayment",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Tenant_ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SeriesId = table.Column<long>(type: "bigint", nullable: true),
                    ChecklistTemplateNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RunningNumber = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModeOfPayment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModeOfPayment_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalSchema: "Stt",
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntryTemplate_SeriesId",
                schema: "Accounting",
                table: "JournalEntryTemplate",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntryTemplateLine_AccountId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntryTemplateLine_JournalEntryId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine",
                column: "JournalEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_ModeOfPayment_SeriesId",
                schema: "Accounting",
                table: "ModeOfPayment",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "UX_ModeOfPayment_Code_Tenant",
                schema: "Accounting",
                table: "ModeOfPayment",
                columns: new[] { "Code", "Tenant_ID" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JournalEntryTemplate",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "JournalEntryTemplateLine",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "ModeOfPayment",
                schema: "Accounting");

            migrationBuilder.AlterColumn<string>(
                name: "Program_ID",
                schema: "Syst",
                table: "Menu",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(6)",
                oldMaxLength: 6,
                oldNullable: true);
        }
    }
}
