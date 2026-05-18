using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SalesInvoiceAuditable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "In_Date",
                schema: "Accounting",
                table: "SalesInvoiceSalesPerson",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "In_User",
                schema: "Accounting",
                table: "SalesInvoiceSalesPerson",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Mod_Date",
                schema: "Accounting",
                table: "SalesInvoiceSalesPerson",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mod_User",
                schema: "Accounting",
                table: "SalesInvoiceSalesPerson",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "In_Date",
                schema: "Accounting",
                table: "SalesInvoiceSalesAdjustment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "In_User",
                schema: "Accounting",
                table: "SalesInvoiceSalesAdjustment",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Mod_Date",
                schema: "Accounting",
                table: "SalesInvoiceSalesAdjustment",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mod_User",
                schema: "Accounting",
                table: "SalesInvoiceSalesAdjustment",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "In_Date",
                schema: "Accounting",
                table: "SalesInvoiceSalesPerson");

            migrationBuilder.DropColumn(
                name: "In_User",
                schema: "Accounting",
                table: "SalesInvoiceSalesPerson");

            migrationBuilder.DropColumn(
                name: "Mod_Date",
                schema: "Accounting",
                table: "SalesInvoiceSalesPerson");

            migrationBuilder.DropColumn(
                name: "Mod_User",
                schema: "Accounting",
                table: "SalesInvoiceSalesPerson");

            migrationBuilder.DropColumn(
                name: "In_Date",
                schema: "Accounting",
                table: "SalesInvoiceSalesAdjustment");

            migrationBuilder.DropColumn(
                name: "In_User",
                schema: "Accounting",
                table: "SalesInvoiceSalesAdjustment");

            migrationBuilder.DropColumn(
                name: "Mod_Date",
                schema: "Accounting",
                table: "SalesInvoiceSalesAdjustment");

            migrationBuilder.DropColumn(
                name: "Mod_User",
                schema: "Accounting",
                table: "SalesInvoiceSalesAdjustment");
        }
    }
}
