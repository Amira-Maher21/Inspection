using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModeOfPayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ChecklistTemplateNumber",
                schema: "Accounting",
                table: "ModeOfPayment",
                newName: "ModeOfPaymentNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModeOfPaymentNumber",
                schema: "Accounting",
                table: "ModeOfPayment",
                newName: "ChecklistTemplateNumber");
        }
    }
}
