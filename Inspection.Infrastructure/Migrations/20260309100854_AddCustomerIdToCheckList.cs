using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomerIdToCheckList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CustomerId",
                schema: "Inspection",
                table: "Checklist",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Checklist_CustomerId",
                schema: "Inspection",
                table: "Checklist",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Checklist_Customer_CustomerId",
                schema: "Inspection",
                table: "Checklist",
                column: "CustomerId",
                principalSchema: "Accounting",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checklist_Customer_CustomerId",
                schema: "Inspection",
                table: "Checklist");

            migrationBuilder.DropIndex(
                name: "IX_Checklist_CustomerId",
                schema: "Inspection",
                table: "Checklist");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                schema: "Inspection",
                table: "Checklist");
        }
    }
}
