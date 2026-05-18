using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SalesPersonId2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "SalesPersonId",
                schema: "Accounting",
                table: "SalesInvoice",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoice_SalesPersonId",
                schema: "Accounting",
                table: "SalesInvoice",
                column: "SalesPersonId");

            migrationBuilder.AddForeignKey(
     name: "FK_SalesInvoice_SalesPerson_SalesPersonId",
     schema: "Accounting",       // schema الجدول اللي فيه العمود
     table: "SalesInvoice",      // جدول SalesInvoice
     column: "SalesPersonId",    // العمود في SalesInvoice
     principalTable: "SalesPerson", // جدول المرجع
     principalSchema: "Sales",      // schema جدول المرجع
     principalColumn: "Id",         // العمود المرجعي
     onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                 name: "FK_SalesInvoice_SalesPerson_SalesPersonId",
                 schema: "Accounting",
                 table: "SalesInvoice");

            migrationBuilder.DropIndex(
                name: "IX_SalesInvoice_SalesPersonId",
                schema: "Accounting",
                table: "SalesInvoice");

            migrationBuilder.DropColumn(
                name: "SalesPersonId",
                schema: "Accounting",
                table: "SalesInvoice");
        }
    }
}
