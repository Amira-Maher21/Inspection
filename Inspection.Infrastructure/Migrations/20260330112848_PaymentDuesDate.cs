using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PaymentDuesDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                 name: "PaymentDuesDate",
                 schema: "Accounting",
                 table: "SalesInvoice",
                 nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
             name: "PaymentDuesDate",
             schema: "Accounting",
             table: "SalesInvoice");
        }
    }
}
