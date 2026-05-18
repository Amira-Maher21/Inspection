using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RefactorSalesQuotation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesQuotation_Currency_CurrencyId",
                schema: "Sales",
                table: "SalesQuotation");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesQuotation_Customer_CustomerId",
                schema: "Sales",
                table: "SalesQuotation");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesQuotation_InspectionRequest_InspectionRequestId",
                schema: "Sales",
                table: "SalesQuotation");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesQuotation_SalesPerson_SalespersonId",
                schema: "Sales",
                table: "SalesQuotation");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesQuotation_Series_SeriesId",
                schema: "Sales",
                table: "SalesQuotation");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesQuotation_TaxType_TaxTypeId",
                schema: "Sales",
                table: "SalesQuotation");

            migrationBuilder.DropTable(
                name: "SalesQuotationLines",
                schema: "Sales");

            migrationBuilder.DropIndex(
                name: "UX_SalesQuotation_QuotationNumber_Tenant",
                schema: "Sales",
                table: "SalesQuotation");

            migrationBuilder.AlterColumn<string>(
                name: "VersionNumber",
                schema: "Sales",
                table: "SalesQuotation",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "TermsAndConditions",
                schema: "Sales",
                table: "SalesQuotation",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Tenant_ID",
                schema: "Sales",
                table: "SalesQuotation",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "QuotationNumber",
                schema: "Sales",
                table: "SalesQuotation",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "PONumber",
                schema: "Sales",
                table: "SalesQuotation",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Mod_User",
                schema: "Sales",
                table: "SalesQuotation",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "In_User",
                schema: "Sales",
                table: "SalesQuotation",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerNote",
                schema: "Sales",
                table: "SalesQuotation",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyId",
                schema: "Sales",
                table: "SalesQuotation",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "SalesQuotationLine",
                schema: "Sales",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesQuotationId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ItemId = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    InspectionMethodId = table.Column<long>(type: "bigint", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SalesQuotationId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesQuotationLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesQuotationLine_InspectionMethod_InspectionMethodId",
                        column: x => x.InspectionMethodId,
                        principalSchema: "Inspection",
                        principalTable: "InspectionMethod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesQuotationLine_Item_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "Inventory",
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesQuotationLine_SalesQuotation_SalesQuotationId",
                        column: x => x.SalesQuotationId,
                        principalSchema: "Sales",
                        principalTable: "SalesQuotation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesQuotationLine_SalesQuotation_SalesQuotationId1",
                        column: x => x.SalesQuotationId1,
                        principalSchema: "Sales",
                        principalTable: "SalesQuotation",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalesQuotation_Tenant_ID_CompanyId_QuotationNumber",
                schema: "Sales",
                table: "SalesQuotation",
                columns: new[] { "Tenant_ID", "CompanyId", "QuotationNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesQuotationLine_InspectionMethodId",
                schema: "Sales",
                table: "SalesQuotationLine",
                column: "InspectionMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesQuotationLine_ItemId",
                schema: "Sales",
                table: "SalesQuotationLine",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesQuotationLine_SalesQuotationId",
                schema: "Sales",
                table: "SalesQuotationLine",
                column: "SalesQuotationId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesQuotationLine_SalesQuotationId1",
                schema: "Sales",
                table: "SalesQuotationLine",
                column: "SalesQuotationId1");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesQuotation_Currency_CurrencyId",
                schema: "Sales",
                table: "SalesQuotation",
                column: "CurrencyId",
                principalSchema: "Sec",
                principalTable: "Currency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesQuotation_Customer_CustomerId",
                schema: "Sales",
                table: "SalesQuotation",
                column: "CustomerId",
                principalSchema: "Accounting",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesQuotation_InspectionRequest_InspectionRequestId",
                schema: "Sales",
                table: "SalesQuotation",
                column: "InspectionRequestId",
                principalSchema: "Inspection",
                principalTable: "InspectionRequest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesQuotation_SalesPerson_SalespersonId",
                schema: "Sales",
                table: "SalesQuotation",
                column: "SalespersonId",
                principalSchema: "Sales",
                principalTable: "SalesPerson",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesQuotation_Series_SeriesId",
                schema: "Sales",
                table: "SalesQuotation",
                column: "SeriesId",
                principalSchema: "Stt",
                principalTable: "Series",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesQuotation_TaxType_TaxTypeId",
                schema: "Sales",
                table: "SalesQuotation",
                column: "TaxTypeId",
                principalSchema: "Accounting",
                principalTable: "TaxType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesQuotation_Currency_CurrencyId",
                schema: "Sales",
                table: "SalesQuotation");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesQuotation_Customer_CustomerId",
                schema: "Sales",
                table: "SalesQuotation");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesQuotation_InspectionRequest_InspectionRequestId",
                schema: "Sales",
                table: "SalesQuotation");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesQuotation_SalesPerson_SalespersonId",
                schema: "Sales",
                table: "SalesQuotation");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesQuotation_Series_SeriesId",
                schema: "Sales",
                table: "SalesQuotation");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesQuotation_TaxType_TaxTypeId",
                schema: "Sales",
                table: "SalesQuotation");

            migrationBuilder.DropTable(
                name: "SalesQuotationLine",
                schema: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_SalesQuotation_Tenant_ID_CompanyId_QuotationNumber",
                schema: "Sales",
                table: "SalesQuotation");

            migrationBuilder.AlterColumn<string>(
                name: "VersionNumber",
                schema: "Sales",
                table: "SalesQuotation",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "TermsAndConditions",
                schema: "Sales",
                table: "SalesQuotation",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000);

            migrationBuilder.AlterColumn<string>(
                name: "Tenant_ID",
                schema: "Sales",
                table: "SalesQuotation",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "QuotationNumber",
                schema: "Sales",
                table: "SalesQuotation",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "PONumber",
                schema: "Sales",
                table: "SalesQuotation",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Mod_User",
                schema: "Sales",
                table: "SalesQuotation",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "In_User",
                schema: "Sales",
                table: "SalesQuotation",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerNote",
                schema: "Sales",
                table: "SalesQuotation",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<string>(
                name: "CompanyId",
                schema: "Sales",
                table: "SalesQuotation",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateTable(
                name: "SalesQuotationLines",
                schema: "Sales",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InspectionMethodId = table.Column<long>(type: "bigint", nullable: true),
                    ItemId = table.Column<long>(type: "bigint", nullable: false),
                    SalesQuotationId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesQuotationLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesQuotationLines_InspectionMethod_InspectionMethodId",
                        column: x => x.InspectionMethodId,
                        principalSchema: "Inspection",
                        principalTable: "InspectionMethod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesQuotationLines_Item_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "Inventory",
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesQuotationLines_SalesQuotation_SalesQuotationId",
                        column: x => x.SalesQuotationId,
                        principalSchema: "Sales",
                        principalTable: "SalesQuotation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "UX_SalesQuotation_QuotationNumber_Tenant",
                schema: "Sales",
                table: "SalesQuotation",
                columns: new[] { "QuotationNumber", "Tenant_ID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesQuotationLines_InspectionMethodId",
                schema: "Sales",
                table: "SalesQuotationLines",
                column: "InspectionMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesQuotationLines_ItemId",
                schema: "Sales",
                table: "SalesQuotationLines",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesQuotationLines_SalesQuotationId",
                schema: "Sales",
                table: "SalesQuotationLines",
                column: "SalesQuotationId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesQuotation_Currency_CurrencyId",
                schema: "Sales",
                table: "SalesQuotation",
                column: "CurrencyId",
                principalSchema: "Sec",
                principalTable: "Currency",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesQuotation_Customer_CustomerId",
                schema: "Sales",
                table: "SalesQuotation",
                column: "CustomerId",
                principalSchema: "Accounting",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesQuotation_InspectionRequest_InspectionRequestId",
                schema: "Sales",
                table: "SalesQuotation",
                column: "InspectionRequestId",
                principalSchema: "Inspection",
                principalTable: "InspectionRequest",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesQuotation_SalesPerson_SalespersonId",
                schema: "Sales",
                table: "SalesQuotation",
                column: "SalespersonId",
                principalSchema: "Sales",
                principalTable: "SalesPerson",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesQuotation_Series_SeriesId",
                schema: "Sales",
                table: "SalesQuotation",
                column: "SeriesId",
                principalSchema: "Stt",
                principalTable: "Series",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesQuotation_TaxType_TaxTypeId",
                schema: "Sales",
                table: "SalesQuotation",
                column: "TaxTypeId",
                principalSchema: "Accounting",
                principalTable: "TaxType",
                principalColumn: "Id");
        }
    }
}
