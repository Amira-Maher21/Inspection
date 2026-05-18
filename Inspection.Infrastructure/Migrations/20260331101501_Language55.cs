using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Language55 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "In_Date",
                schema: "syst",
                table: "Language",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "In_User",
                schema: "syst",
                table: "Language",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Mod_Date",
                schema: "syst",
                table: "Language",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mod_User",
                schema: "syst",
                table: "Language",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tenant_ID",
                schema: "syst",
                table: "Language",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "In_Date",
                schema: "syst",
                table: "Language");

            migrationBuilder.DropColumn(
                name: "In_User",
                schema: "syst",
                table: "Language");

            migrationBuilder.DropColumn(
                name: "Mod_Date",
                schema: "syst",
                table: "Language");

            migrationBuilder.DropColumn(
                name: "Mod_User",
                schema: "syst",
                table: "Language");

            migrationBuilder.DropColumn(
                name: "Tenant_ID",
                schema: "syst",
                table: "Language");
        }
    }
}
