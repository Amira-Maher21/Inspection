using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class editCommitment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Contracting");

            migrationBuilder.RenameTable(
                name: "CommitmentLine",
                newName: "CommitmentLine",
                newSchema: "Contracting");

            migrationBuilder.RenameTable(
                name: "Commitment",
                newName: "Commitment",
                newSchema: "Contracting");

            migrationBuilder.AlterColumn<string>(
                name: "Mod_User",
                schema: "Contracting",
                table: "CommitmentLine",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "In_User",
                schema: "Contracting",
                table: "CommitmentLine",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<decimal>(
                name: "CommittedRate",
                schema: "Contracting",
                table: "CommitmentLine",
                type: "decimal(18,4)",
                precision: 18,
                scale: 4,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "CommittedQty",
                schema: "Contracting",
                table: "CommitmentLine",
                type: "decimal(18,4)",
                precision: 18,
                scale: 4,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Tenant_ID",
                schema: "Contracting",
                table: "Commitment",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Mod_User",
                schema: "Contracting",
                table: "Commitment",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "In_User",
                schema: "Contracting",
                table: "Commitment",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DocumentNo",
                schema: "Contracting",
                table: "Commitment",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyId",
                schema: "Contracting",
                table: "Commitment",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Commitment_Tenant_ID_CompanyId_DocumentNo",
                schema: "Contracting",
                table: "Commitment",
                columns: new[] { "Tenant_ID", "CompanyId", "DocumentNo" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Commitment_Tenant_ID_CompanyId_DocumentNo",
                schema: "Contracting",
                table: "Commitment");

            migrationBuilder.RenameTable(
                name: "CommitmentLine",
                schema: "Contracting",
                newName: "CommitmentLine");

            migrationBuilder.RenameTable(
                name: "Commitment",
                schema: "Contracting",
                newName: "Commitment");

            migrationBuilder.AlterColumn<string>(
                name: "Mod_User",
                table: "CommitmentLine",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "In_User",
                table: "CommitmentLine",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<decimal>(
                name: "CommittedRate",
                table: "CommitmentLine",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldPrecision: 18,
                oldScale: 4);

            migrationBuilder.AlterColumn<decimal>(
                name: "CommittedQty",
                table: "CommitmentLine",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldPrecision: 18,
                oldScale: 4);

            migrationBuilder.AlterColumn<string>(
                name: "Tenant_ID",
                table: "Commitment",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Mod_User",
                table: "Commitment",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "In_User",
                table: "Commitment",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "DocumentNo",
                table: "Commitment",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "CompanyId",
                table: "Commitment",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
