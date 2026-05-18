using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class editCommitmentEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VendorId",
                schema: "Contracting",
                table: "Commitment",
                newName: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Commitment_SupplierId",
                schema: "Contracting",
                table: "Commitment",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Commitment_Supplier_SupplierId",
                schema: "Contracting",
                table: "Commitment",
                column: "SupplierId",
                principalSchema: "Accounting",
                principalTable: "Supplier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commitment_Supplier_SupplierId",
                schema: "Contracting",
                table: "Commitment");

            migrationBuilder.DropIndex(
                name: "IX_Commitment_SupplierId",
                schema: "Contracting",
                table: "Commitment");

            migrationBuilder.RenameColumn(
                name: "SupplierId",
                schema: "Contracting",
                table: "Commitment",
                newName: "VendorId");
        }
    }
}
