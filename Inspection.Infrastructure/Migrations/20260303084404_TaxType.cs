using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TaxType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TaxType_Tenant_ID_Code",
                schema: "Accounting",
                table: "TaxType");

            migrationBuilder.AlterColumn<decimal>(
                name: "Percentage",
                schema: "Accounting",
                table: "TaxType",
                type: "decimal(18,6)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.AddColumn<long>(
                name: "CompanyId",
                schema: "Accounting",
                table: "TaxType",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "EtaCodeEgypt",
                schema: "Accounting",
                table: "TaxType",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsExempt",
                schema: "Accounting",
                table: "TaxType",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSystem",
                schema: "Accounting",
                table: "TaxType",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TaxTypeValue",
                schema: "Accounting",
                table: "TaxType",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TaxTypeLine",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaxTypeId = table.Column<long>(type: "bigint", nullable: false),
                    DocumentDirection = table.Column<int>(type: "int", nullable: false),
                    ChartOfAccountId = table.Column<long>(type: "bigint", nullable: false),
                    RecoverablePercentage = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxTypeLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxTypeLine_ChartOfAccount_ChartOfAccountId",
                        column: x => x.ChartOfAccountId,
                        principalSchema: "Accounting",
                        principalTable: "ChartOfAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaxTypeLine_TaxType_TaxTypeId",
                        column: x => x.TaxTypeId,
                        principalSchema: "Accounting",
                        principalTable: "TaxType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaxType_Tenant_ID_CompanyId_Code_TaxTypeValue",
                schema: "Accounting",
                table: "TaxType",
                columns: new[] { "Tenant_ID", "CompanyId", "Code", "TaxTypeValue" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaxTypeLine_ChartOfAccountId",
                schema: "Accounting",
                table: "TaxTypeLine",
                column: "ChartOfAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxTypeLine_TaxTypeId_DocumentDirection",
                schema: "Accounting",
                table: "TaxTypeLine",
                columns: new[] { "TaxTypeId", "DocumentDirection" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaxTypeLine",
                schema: "Accounting");

            migrationBuilder.DropIndex(
                name: "IX_TaxType_Tenant_ID_CompanyId_Code_TaxTypeValue",
                schema: "Accounting",
                table: "TaxType");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                schema: "Accounting",
                table: "TaxType");

            migrationBuilder.DropColumn(
                name: "EtaCodeEgypt",
                schema: "Accounting",
                table: "TaxType");

            migrationBuilder.DropColumn(
                name: "IsExempt",
                schema: "Accounting",
                table: "TaxType");

            migrationBuilder.DropColumn(
                name: "IsSystem",
                schema: "Accounting",
                table: "TaxType");

            migrationBuilder.DropColumn(
                name: "TaxTypeValue",
                schema: "Accounting",
                table: "TaxType");

            migrationBuilder.AlterColumn<decimal>(
                name: "Percentage",
                schema: "Accounting",
                table: "TaxType",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.CreateIndex(
                name: "IX_TaxType_Tenant_ID_Code",
                schema: "Accounting",
                table: "TaxType",
                columns: new[] { "Tenant_ID", "Code" },
                unique: true);
        }
    }
}
