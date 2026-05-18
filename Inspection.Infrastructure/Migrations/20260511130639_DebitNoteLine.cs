using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DebitNoteLine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                schema: "Accounting",
                table: "DebitNoteLine",
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
                table: "DebitNoteLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AssetTransactionType",
                schema: "Accounting",
                table: "DebitNoteLine",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LineType",
                schema: "Accounting",
                table: "DebitNoteLine",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DebitNoteLine_AssetId",
                schema: "Accounting",
                table: "DebitNoteLine",
                column: "AssetId");

            migrationBuilder.AddForeignKey(
                name: "FK_DebitNoteLine_FixedAsset_AssetId",
                schema: "Accounting",
                table: "DebitNoteLine",
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
                name: "FK_DebitNoteLine_FixedAsset_AssetId",
                schema: "Accounting",
                table: "DebitNoteLine");

            migrationBuilder.DropIndex(
                name: "IX_DebitNoteLine_AssetId",
                schema: "Accounting",
                table: "DebitNoteLine");

            migrationBuilder.DropColumn(
                name: "AssetId",
                schema: "Accounting",
                table: "DebitNoteLine");

            migrationBuilder.DropColumn(
                name: "AssetTransactionType",
                schema: "Accounting",
                table: "DebitNoteLine");

            migrationBuilder.DropColumn(
                name: "LineType",
                schema: "Accounting",
                table: "DebitNoteLine");

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                schema: "Accounting",
                table: "DebitNoteLine",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);
        }
    }
}
