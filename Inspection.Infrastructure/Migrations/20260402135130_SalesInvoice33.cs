using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SalesInvoice33 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CustomersPurchaseOrderDate",
                schema: "Accounting",
                table: "SalesInvoice",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoice_BranchId",
                schema: "Accounting",
                table: "SalesInvoice",
                column: "BranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesInvoice_Branch_BranchId",
                schema: "Accounting",
                table: "SalesInvoice",
                column: "BranchId",
                principalSchema: "Accounting",
                principalTable: "Branch",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesInvoice_Branch_BranchId",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.DropIndex(
                name: "IX_SalesInvoice_BranchId",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.AlterColumn<string>(
                name: "CustomersPurchaseOrderDate",
                schema: "Accounting",
                table: "SalesInvoice",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
