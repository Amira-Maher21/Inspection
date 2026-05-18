using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Language : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountTypeNameEnglish",
                schema: "Accounting",
                table: "AccountType");

            migrationBuilder.AddColumn<string>(
                name: "Tenant_ID",
                schema: "Accounting",
                table: "AccountType",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tenant_ID",
                schema: "Accounting",
                table: "AccountType");

            migrationBuilder.AddColumn<string>(
                name: "AccountTypeNameEnglish",
                schema: "Accounting",
                table: "AccountType",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "");
        }
    }
}
