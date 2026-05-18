using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RefactorJournalEntryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntryTemplate_Currency_CurrencyId",
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

            migrationBuilder.AddColumn<long>(
                name: "JournalEntryTemplateId1",
                schema: "Accounting",
                table: "JournalEntryTemplateLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RunningNumber",
                schema: "Accounting",
                table: "JournalEntryTemplate",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntryTemplateLine_JournalEntryTemplateId1",
                schema: "Accounting",
                table: "JournalEntryTemplateLine",
                column: "JournalEntryTemplateId1");

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntryTemplate_Currency_CurrencyId",
                schema: "Accounting",
                table: "JournalEntryTemplate",
                column: "CurrencyId",
                principalSchema: "Sec",
                principalTable: "Currency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntryTemplateLine_CostCenter_CostCenterId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine",
                column: "CostCenterId",
                principalSchema: "Accounting",
                principalTable: "CostCenter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntryTemplateLine_CostUnit_CostUnitId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine",
                column: "CostUnitId",
                principalSchema: "Accounting",
                principalTable: "CostUnit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntryTemplateLine_JournalEntryTemplate_JournalEntryTemplateId1",
                schema: "Accounting",
                table: "JournalEntryTemplateLine",
                column: "JournalEntryTemplateId1",
                principalSchema: "Accounting",
                principalTable: "JournalEntryTemplate",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntryTemplateLine_Operation_OperationId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine",
                column: "OperationId",
                principalSchema: "Sec",
                principalTable: "Operation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntryTemplate_Currency_CurrencyId",
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
                name: "FK_JournalEntryTemplateLine_JournalEntryTemplate_JournalEntryTemplateId1",
                schema: "Accounting",
                table: "JournalEntryTemplateLine");

            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntryTemplateLine_Operation_OperationId",
                schema: "Accounting",
                table: "JournalEntryTemplateLine");

            migrationBuilder.DropIndex(
                name: "IX_JournalEntryTemplateLine_JournalEntryTemplateId1",
                schema: "Accounting",
                table: "JournalEntryTemplateLine");

            migrationBuilder.DropColumn(
                name: "JournalEntryTemplateId1",
                schema: "Accounting",
                table: "JournalEntryTemplateLine");

            migrationBuilder.AlterColumn<int>(
                name: "RunningNumber",
                schema: "Accounting",
                table: "JournalEntryTemplate",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntryTemplate_Currency_CurrencyId",
                schema: "Accounting",
                table: "JournalEntryTemplate",
                column: "CurrencyId",
                principalSchema: "Sec",
                principalTable: "Currency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
    }
}
