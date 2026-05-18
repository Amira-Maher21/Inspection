using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixedAsset11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Acquired",
                schema: "Accounting",
                table: "FixedAsset",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "MaintenanceSupplierId",
                schema: "Accounting",
                table: "FixedAsset",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NextServiceDate",
                schema: "Accounting",
                table: "FixedAsset",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalCost",
                schema: "Accounting",
                table: "FixedAsset",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalDepreciation",
                schema: "Accounting",
                table: "FixedAsset",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "UnderMaintenance",
                schema: "Accounting",
                table: "FixedAsset",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "WarrantyDate",
                schema: "Accounting",
                table: "FixedAsset",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FixedAsset_MaintenanceSupplierId",
                schema: "Accounting",
                table: "FixedAsset",
                column: "MaintenanceSupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_FixedAsset_Supplier_MaintenanceSupplierId",
                schema: "Accounting",
                table: "FixedAsset",
                column: "MaintenanceSupplierId",
                principalSchema: "Accounting",
                principalTable: "Supplier",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FixedAsset_Supplier_MaintenanceSupplierId",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropIndex(
                name: "IX_FixedAsset_MaintenanceSupplierId",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropColumn(
                name: "Acquired",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropColumn(
                name: "MaintenanceSupplierId",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropColumn(
                name: "NextServiceDate",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropColumn(
                name: "TotalCost",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropColumn(
                name: "TotalDepreciation",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropColumn(
                name: "UnderMaintenance",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropColumn(
                name: "WarrantyDate",
                schema: "Accounting",
                table: "FixedAsset");
        }
    }
}
