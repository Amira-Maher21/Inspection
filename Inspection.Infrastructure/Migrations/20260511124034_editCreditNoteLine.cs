using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class editCreditNoteLine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                schema: "Accounting",
                table: "CreditNoteLine",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ItemId",
                schema: "Accounting",
                table: "CreditNoteLine",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "Accounting",
                table: "CreditNoteLine",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "AssetId",
                schema: "Accounting",
                table: "CreditNoteLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AssetTransactionType",
                schema: "Accounting",
                table: "CreditNoteLine",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LineType",
                schema: "Accounting",
                table: "CreditNoteLine",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CreditNoteLine_AssetId",
                schema: "Accounting",
                table: "CreditNoteLine",
                column: "AssetId");

            migrationBuilder.AddForeignKey(
                name: "FK_CreditNoteLine_FixedAsset_AssetId",
                schema: "Accounting",
                table: "CreditNoteLine",
                column: "AssetId",
                principalSchema: "Accounting",
                principalTable: "FixedAsset",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreditNoteLine_FixedAsset_AssetId",
                schema: "Accounting",
                table: "CreditNoteLine");

            migrationBuilder.DropIndex(
                name: "IX_CreditNoteLine_AssetId",
                schema: "Accounting",
                table: "CreditNoteLine");

            migrationBuilder.DropColumn(
                name: "AssetId",
                schema: "Accounting",
                table: "CreditNoteLine");

            migrationBuilder.DropColumn(
                name: "AssetTransactionType",
                schema: "Accounting",
                table: "CreditNoteLine");

            migrationBuilder.DropColumn(
                name: "LineType",
                schema: "Accounting",
                table: "CreditNoteLine");

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                schema: "Accounting",
                table: "CreditNoteLine",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<long>(
                name: "ItemId",
                schema: "Accounting",
                table: "CreditNoteLine",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "Accounting",
                table: "CreditNoteLine",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);
        }
    }
}
