using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DocumentShare5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShareTypeEnum",
                schema: "DMS",
                table: "DocumentShare",
                newName: "ShareType");

            migrationBuilder.AddColumn<long>(
                name: "CompanyId",
                schema: "DMS",
                table: "ShareAccessLog",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "In_Date",
                schema: "DMS",
                table: "ShareAccessLog",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "In_User",
                schema: "DMS",
                table: "ShareAccessLog",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Mod_Date",
                schema: "DMS",
                table: "ShareAccessLog",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mod_User",
                schema: "DMS",
                table: "ShareAccessLog",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tenant_ID",
                schema: "DMS",
                table: "ShareAccessLog",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyId",
                schema: "DMS",
                table: "ShareAccessLog");

            migrationBuilder.DropColumn(
                name: "In_Date",
                schema: "DMS",
                table: "ShareAccessLog");

            migrationBuilder.DropColumn(
                name: "In_User",
                schema: "DMS",
                table: "ShareAccessLog");

            migrationBuilder.DropColumn(
                name: "Mod_Date",
                schema: "DMS",
                table: "ShareAccessLog");

            migrationBuilder.DropColumn(
                name: "Mod_User",
                schema: "DMS",
                table: "ShareAccessLog");

            migrationBuilder.DropColumn(
                name: "Tenant_ID",
                schema: "DMS",
                table: "ShareAccessLog");

            migrationBuilder.RenameColumn(
                name: "ShareType",
                schema: "DMS",
                table: "DocumentShare",
                newName: "ShareTypeEnum");
        }
    }
}
