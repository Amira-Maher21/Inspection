using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RefactorBOQ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_BOQ_RevisionNumber",
                schema: "Contracting",
                table: "BOQ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddCheckConstraint(
                name: "CK_BOQ_RevisionNumber",
                schema: "Contracting",
                table: "BOQ",
                sql: "[RevisionNumber] > 0");
        }
    }
}
