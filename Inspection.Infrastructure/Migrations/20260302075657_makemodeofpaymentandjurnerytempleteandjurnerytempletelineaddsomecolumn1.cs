using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class makemodeofpaymentandjurnerytempleteandjurnerytempletelineaddsomecolumn1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenantId",
                schema: "Accounting",
                table: "JournalEntryTemplate");

            migrationBuilder.RenameColumn(
                name: "PaymentModeCodeId",
                schema: "Accounting",
                table: "JournalEntryTemplate",
                newName: "ModeOfPaymentId");

            migrationBuilder.AddColumn<long>(
                name: "OperationId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JournalEntryTemplateNumber",
                schema: "Accounting",
                table: "JournalEntryTemplate",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntryTemplateLine_CostCenterId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntryTemplateLine_CostUnitId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine",
                column: "CostUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntryTemplateLine_OperationId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntryTemplate_ModeOfPaymentId",
                schema: "Accounting",
                table: "JournalEntryTemplate",
                column: "ModeOfPaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntryTemplate_ModeOfPayment_ModeOfPaymentId",
                schema: "Accounting",
                table: "JournalEntryTemplate",
                column: "ModeOfPaymentId",
                principalSchema: "Accounting",
                principalTable: "ModeOfPayment",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntryTemplateLine_CostCenter_CostCenterId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine",
                column: "CostCenterId",
                principalSchema: "Accounting",
                principalTable: "CostCenter",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntryTemplateLine_CostUnit_CostUnitId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine",
                column: "CostUnitId",
                principalSchema: "Accounting",
                principalTable: "CostUnit",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntryTemplateLine_Operation_OperationId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine",
                column: "OperationId",
                principalSchema: "Sec",
                principalTable: "Operation",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntryTemplate_ModeOfPayment_ModeOfPaymentId",
                schema: "Accounting",
                table: "JournalEntryTemplate");

            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntryTemplateLine_CostCenter_CostCenterId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine");

            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntryTemplateLine_CostUnit_CostUnitId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine");

            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntryTemplateLine_Operation_OperationId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine");

            migrationBuilder.DropIndex(
                name: "IX_JournalEntryTemplateLine_CostCenterId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine");

            migrationBuilder.DropIndex(
                name: "IX_JournalEntryTemplateLine_CostUnitId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine");

            migrationBuilder.DropIndex(
                name: "IX_JournalEntryTemplateLine_OperationId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine");

            migrationBuilder.DropIndex(
                name: "IX_JournalEntryTemplate_ModeOfPaymentId",
                schema: "Accounting",
                table: "JournalEntryTemplate");

            migrationBuilder.DropColumn(
                name: "OperationId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine");

            migrationBuilder.DropColumn(
                name: "JournalEntryTemplateNumber",
                schema: "Accounting",
                table: "JournalEntryTemplate");

            migrationBuilder.RenameColumn(
                name: "ModeOfPaymentId",
                schema: "Accounting",
                table: "JournalEntryTemplate",
                newName: "PaymentModeCodeId");

            migrationBuilder.AddColumn<long>(
                name: "TenantId",
                schema: "Accounting",
                table: "JournalEntryTemplate",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
