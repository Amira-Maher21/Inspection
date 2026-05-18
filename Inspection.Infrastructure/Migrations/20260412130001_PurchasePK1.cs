using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PurchasePK1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
             migrationBuilder.DropPrimaryKey(
                name: "PK_PurchaseInvoiceAdjustment",
                schema: "Accounting",
                table: "PurchaseInvoiceAdjustment");

             migrationBuilder.DropColumn(
                name: "Id",
                schema: "Accounting",
                table: "PurchaseInvoiceAdjustment");

             migrationBuilder.AddColumn<long>(
                name: "Id",
                schema: "Accounting",
                table: "PurchaseInvoiceAdjustment",
                type: "bigint",
                nullable: false)
                .Annotation("SqlServer:Identity", "1, 1");

             migrationBuilder.AddPrimaryKey(
                name: "PK_PurchaseInvoiceAdjustment",
                schema: "Accounting",
                table: "PurchaseInvoiceAdjustment",
                column: "Id");
        }

         protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchaseInvoiceAdjustment",
                schema: "Accounting",
                table: "PurchaseInvoiceAdjustment");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "Accounting",
                table: "PurchaseInvoiceAdjustment");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                schema: "Accounting",
                table: "PurchaseInvoiceAdjustment",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchaseInvoiceAdjustment",
                schema: "Accounting",
                table: "PurchaseInvoiceAdjustment",
                column: "Id");
        }
    }
}
