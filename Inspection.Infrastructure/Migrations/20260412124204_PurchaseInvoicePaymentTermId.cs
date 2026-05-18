using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PurchaseInvoicePaymentTermId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseInvoice_PaymentTerm_PaymentTermsId",
                schema: "Accounting",
                table: "PurchaseInvoice");

            migrationBuilder.RenameColumn(
                name: "PaymentTermsId",
                schema: "Accounting",
                table: "PurchaseInvoice",
                newName: "PaymentTermId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseInvoice_PaymentTermsId",
                schema: "Accounting",
                table: "PurchaseInvoice",
                newName: "IX_PurchaseInvoice_PaymentTermId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseInvoice_PaymentTerm_PaymentTermId",
                schema: "Accounting",
                table: "PurchaseInvoice",
                column: "PaymentTermId",
                principalSchema: "Accounting",
                principalTable: "PaymentTerm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseInvoice_PaymentTerm_PaymentTermId",
                schema: "Accounting",
                table: "PurchaseInvoice");

            migrationBuilder.RenameColumn(
                name: "PaymentTermId",
                schema: "Accounting",
                table: "PurchaseInvoice",
                newName: "PaymentTermsId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseInvoice_PaymentTermId",
                schema: "Accounting",
                table: "PurchaseInvoice",
                newName: "IX_PurchaseInvoice_PaymentTermsId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseInvoice_PaymentTerm_PaymentTermsId",
                schema: "Accounting",
                table: "PurchaseInvoice",
                column: "PaymentTermsId",
                principalSchema: "Accounting",
                principalTable: "PaymentTerm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
