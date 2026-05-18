using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModeOfPaymentAndCompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModeOfPayment_Series_SeriesId",
                schema: "Accounting",
                table: "ModeOfPayment");

            migrationBuilder.DropIndex(
                name: "UX_ModeOfPayment_Code_Tenant",
                schema: "Accounting",
                table: "ModeOfPayment");

            migrationBuilder.DropColumn(
                name: "Code",
                schema: "Accounting",
                table: "ModeOfPayment");

            migrationBuilder.DropColumn(
                name: "ModeOfPaymentNumber",
                schema: "Accounting",
                table: "ModeOfPayment");

            migrationBuilder.DropColumn(
                name: "RunningNumber",
                schema: "Accounting",
                table: "ModeOfPayment");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "IsHolding",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "IsSubsidiary",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "LegalRegistrationNumber",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "Logo",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "SubEntity",
                schema: "Sec",
                table: "Company");

            migrationBuilder.RenameColumn(
                name: "SeriesId",
                schema: "Accounting",
                table: "ModeOfPayment",
                newName: "FeesAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_ModeOfPayment_SeriesId",
                schema: "Accounting",
                table: "ModeOfPayment",
                newName: "IX_ModeOfPayment_FeesAccountId");

            migrationBuilder.AddColumn<long>(
                name: "CurrencyId",
                schema: "Accounting",
                table: "ModeOfPayment",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Direction",
                schema: "Accounting",
                table: "ModeOfPayment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FeeType",
                schema: "Accounting",
                table: "ModeOfPayment",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "FeeValue",
                schema: "Accounting",
                table: "ModeOfPayment",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasFee",
                schema: "Accounting",
                table: "ModeOfPayment",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IncludeInPOS",
                schema: "Accounting",
                table: "ModeOfPayment",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PaymentType",
                schema: "Accounting",
                table: "ModeOfPayment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "IndustrySector",
                schema: "Sec",
                table: "Company",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ActiveActivity",
                schema: "Sec",
                table: "Company",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ActiveBOQItem",
                schema: "Sec",
                table: "Company",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ActiveCostCenter",
                schema: "Sec",
                table: "Company",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ActiveCostCode",
                schema: "Sec",
                table: "Company",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ActiveCostUnit",
                schema: "Sec",
                table: "Company",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ActiveOperation",
                schema: "Sec",
                table: "Company",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ActiveProductionOrder",
                schema: "Sec",
                table: "Company",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ActiveSubcontractBOQ",
                schema: "Sec",
                table: "Company",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ActiveWBS",
                schema: "Sec",
                table: "Company",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "AdjustmentAccountId",
                schema: "Sec",
                table: "Company",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CogsAccountId",
                schema: "Sec",
                table: "Company",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CompanyLogoPhotoid",
                schema: "Sec",
                table: "Company",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DefaultTaxType2Id",
                schema: "Sec",
                table: "Company",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DefaultTaxTypeId",
                schema: "Sec",
                table: "Company",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "GoodsReceivedNotInvoicedAccountId",
                schema: "Sec",
                table: "Company",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "InventoryAccountId",
                schema: "Sec",
                table: "Company",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PurchaseAccountId",
                schema: "Sec",
                table: "Company",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PurchaseReturnAccountId",
                schema: "Sec",
                table: "Company",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ReportingCurrnecyID",
                schema: "Sec",
                table: "Company",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "RevenueAccountId",
                schema: "Sec",
                table: "Company",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SalesReturnAccountId",
                schema: "Sec",
                table: "Company",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "WipAccountId",
                schema: "Sec",
                table: "Company",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ModeOfPayment_CurrencyId",
                schema: "Accounting",
                table: "ModeOfPayment",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "UX_ModeOfPayment_Code_Tenant",
                schema: "Accounting",
                table: "ModeOfPayment",
                column: "Tenant_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Company_AdjustmentAccountId",
                schema: "Sec",
                table: "Company",
                column: "AdjustmentAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_CogsAccountId",
                schema: "Sec",
                table: "Company",
                column: "CogsAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_DefaultTaxType2Id",
                schema: "Sec",
                table: "Company",
                column: "DefaultTaxType2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Company_DefaultTaxTypeId",
                schema: "Sec",
                table: "Company",
                column: "DefaultTaxTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_GoodsReceivedNotInvoicedAccountId",
                schema: "Sec",
                table: "Company",
                column: "GoodsReceivedNotInvoicedAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_InventoryAccountId",
                schema: "Sec",
                table: "Company",
                column: "InventoryAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_PurchaseAccountId",
                schema: "Sec",
                table: "Company",
                column: "PurchaseAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_PurchaseReturnAccountId",
                schema: "Sec",
                table: "Company",
                column: "PurchaseReturnAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_ReportingCurrnecyID",
                schema: "Sec",
                table: "Company",
                column: "ReportingCurrnecyID");

            migrationBuilder.CreateIndex(
                name: "IX_Company_RevenueAccountId",
                schema: "Sec",
                table: "Company",
                column: "RevenueAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_SalesReturnAccountId",
                schema: "Sec",
                table: "Company",
                column: "SalesReturnAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_WipAccountId",
                schema: "Sec",
                table: "Company",
                column: "WipAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_ChartOfAccount_AdjustmentAccountId",
                schema: "Sec",
                table: "Company",
                column: "AdjustmentAccountId",
                principalSchema: "Accounting",
                principalTable: "ChartOfAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Company_ChartOfAccount_CogsAccountId",
                schema: "Sec",
                table: "Company",
                column: "CogsAccountId",
                principalSchema: "Accounting",
                principalTable: "ChartOfAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Company_ChartOfAccount_DefaultTaxType2Id",
                schema: "Sec",
                table: "Company",
                column: "DefaultTaxType2Id",
                principalSchema: "Accounting",
                principalTable: "ChartOfAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Company_ChartOfAccount_DefaultTaxTypeId",
                schema: "Sec",
                table: "Company",
                column: "DefaultTaxTypeId",
                principalSchema: "Accounting",
                principalTable: "ChartOfAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Company_ChartOfAccount_GoodsReceivedNotInvoicedAccountId",
                schema: "Sec",
                table: "Company",
                column: "GoodsReceivedNotInvoicedAccountId",
                principalSchema: "Accounting",
                principalTable: "ChartOfAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Company_ChartOfAccount_InventoryAccountId",
                schema: "Sec",
                table: "Company",
                column: "InventoryAccountId",
                principalSchema: "Accounting",
                principalTable: "ChartOfAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Company_ChartOfAccount_PurchaseAccountId",
                schema: "Sec",
                table: "Company",
                column: "PurchaseAccountId",
                principalSchema: "Accounting",
                principalTable: "ChartOfAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Company_ChartOfAccount_PurchaseReturnAccountId",
                schema: "Sec",
                table: "Company",
                column: "PurchaseReturnAccountId",
                principalSchema: "Accounting",
                principalTable: "ChartOfAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Company_ChartOfAccount_RevenueAccountId",
                schema: "Sec",
                table: "Company",
                column: "RevenueAccountId",
                principalSchema: "Accounting",
                principalTable: "ChartOfAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Company_ChartOfAccount_SalesReturnAccountId",
                schema: "Sec",
                table: "Company",
                column: "SalesReturnAccountId",
                principalSchema: "Accounting",
                principalTable: "ChartOfAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Company_ChartOfAccount_WipAccountId",
                schema: "Sec",
                table: "Company",
                column: "WipAccountId",
                principalSchema: "Accounting",
                principalTable: "ChartOfAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Currency_ReportingCurrnecyID",
                schema: "Sec",
                table: "Company",
                column: "ReportingCurrnecyID",
                principalSchema: "Sec",
                principalTable: "Currency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ModeOfPayment_ChartOfAccount_FeesAccountId",
                schema: "Accounting",
                table: "ModeOfPayment",
                column: "FeesAccountId",
                principalSchema: "Accounting",
                principalTable: "ChartOfAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ModeOfPayment_Currency_CurrencyId",
                schema: "Accounting",
                table: "ModeOfPayment",
                column: "CurrencyId",
                principalSchema: "Sec",
                principalTable: "Currency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_ChartOfAccount_AdjustmentAccountId",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_Company_ChartOfAccount_CogsAccountId",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_Company_ChartOfAccount_DefaultTaxType2Id",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_Company_ChartOfAccount_DefaultTaxTypeId",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_Company_ChartOfAccount_GoodsReceivedNotInvoicedAccountId",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_Company_ChartOfAccount_InventoryAccountId",
                schema: "Sec",
                table: "Company");

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
                name: "FK_Company_Currency_ReportingCurrnecyID",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_ModeOfPayment_ChartOfAccount_FeesAccountId",
                schema: "Accounting",
                table: "ModeOfPayment");

            migrationBuilder.DropForeignKey(
                name: "FK_ModeOfPayment_Currency_CurrencyId",
                schema: "Accounting",
                table: "ModeOfPayment");

            migrationBuilder.DropIndex(
                name: "IX_ModeOfPayment_CurrencyId",
                schema: "Accounting",
                table: "ModeOfPayment");

            migrationBuilder.DropIndex(
                name: "UX_ModeOfPayment_Code_Tenant",
                schema: "Accounting",
                table: "ModeOfPayment");

            migrationBuilder.DropIndex(
                name: "IX_Company_AdjustmentAccountId",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropIndex(
                name: "IX_Company_CogsAccountId",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropIndex(
                name: "IX_Company_DefaultTaxType2Id",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropIndex(
                name: "IX_Company_DefaultTaxTypeId",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropIndex(
                name: "IX_Company_GoodsReceivedNotInvoicedAccountId",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropIndex(
                name: "IX_Company_InventoryAccountId",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropIndex(
                name: "IX_Company_PurchaseAccountId",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropIndex(
                name: "IX_Company_PurchaseReturnAccountId",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropIndex(
                name: "IX_Company_ReportingCurrnecyID",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropIndex(
                name: "IX_Company_RevenueAccountId",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropIndex(
                name: "IX_Company_SalesReturnAccountId",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropIndex(
                name: "IX_Company_WipAccountId",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                schema: "Accounting",
                table: "ModeOfPayment");

            migrationBuilder.DropColumn(
                name: "Direction",
                schema: "Accounting",
                table: "ModeOfPayment");

            migrationBuilder.DropColumn(
                name: "FeeType",
                schema: "Accounting",
                table: "ModeOfPayment");

            migrationBuilder.DropColumn(
                name: "FeeValue",
                schema: "Accounting",
                table: "ModeOfPayment");

            migrationBuilder.DropColumn(
                name: "HasFee",
                schema: "Accounting",
                table: "ModeOfPayment");

            migrationBuilder.DropColumn(
                name: "IncludeInPOS",
                schema: "Accounting",
                table: "ModeOfPayment");

            migrationBuilder.DropColumn(
                name: "PaymentType",
                schema: "Accounting",
                table: "ModeOfPayment");

            migrationBuilder.DropColumn(
                name: "ActiveActivity",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "ActiveBOQItem",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "ActiveCostCenter",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "ActiveCostCode",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "ActiveCostUnit",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "ActiveOperation",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "ActiveProductionOrder",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "ActiveSubcontractBOQ",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "ActiveWBS",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "AdjustmentAccountId",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "CogsAccountId",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "CompanyLogoPhotoid",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "DefaultTaxType2Id",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "DefaultTaxTypeId",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "GoodsReceivedNotInvoicedAccountId",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "InventoryAccountId",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "PurchaseAccountId",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "PurchaseReturnAccountId",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "ReportingCurrnecyID",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "RevenueAccountId",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "SalesReturnAccountId",
                schema: "Sec",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "WipAccountId",
                schema: "Sec",
                table: "Company");

            migrationBuilder.RenameColumn(
                name: "FeesAccountId",
                schema: "Accounting",
                table: "ModeOfPayment",
                newName: "SeriesId");

            migrationBuilder.RenameIndex(
                name: "IX_ModeOfPayment_FeesAccountId",
                schema: "Accounting",
                table: "ModeOfPayment",
                newName: "IX_ModeOfPayment_SeriesId");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                schema: "Accounting",
                table: "ModeOfPayment",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ModeOfPaymentNumber",
                schema: "Accounting",
                table: "ModeOfPayment",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RunningNumber",
                schema: "Accounting",
                table: "ModeOfPayment",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "IndustrySector",
                schema: "Sec",
                table: "Company",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "Sec",
                table: "Company",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHolding",
                schema: "Sec",
                table: "Company",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSubsidiary",
                schema: "Sec",
                table: "Company",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LegalRegistrationNumber",
                schema: "Sec",
                table: "Company",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Logo",
                schema: "Sec",
                table: "Company",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubEntity",
                schema: "Sec",
                table: "Company",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "UX_ModeOfPayment_Code_Tenant",
                schema: "Accounting",
                table: "ModeOfPayment",
                columns: new[] { "Code", "Tenant_ID" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ModeOfPayment_Series_SeriesId",
                schema: "Accounting",
                table: "ModeOfPayment",
                column: "SeriesId",
                principalSchema: "Stt",
                principalTable: "Series",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
