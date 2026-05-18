
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class BOQLineFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_BOQLine_CostCodeId",
                schema: "Contracting",
                table: "BOQLine",
                column: "CostCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_BOQLine_WBSId",
                schema: "Contracting",
                table: "BOQLine",
                column: "WBSId");

            migrationBuilder.AddForeignKey(
                name: "FK_BOQLine_CostCode_CostCodeId",
                schema: "Contracting",
                table: "BOQLine",
                column: "CostCodeId",
                principalSchema: "Contracting",
                principalTable: "CostCode",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BOQLine_WBS_WBSId",
                schema: "Contracting",
                table: "BOQLine",
                column: "WBSId",
                principalSchema: "Contracting",
                principalTable: "WBS",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BOQLine_CostCode_CostCodeId",
                schema: "Contracting",
                table: "BOQLine");

            migrationBuilder.DropForeignKey(
                name: "FK_BOQLine_WBS_WBSId",
                schema: "Contracting",
                table: "BOQLine");

            migrationBuilder.DropIndex(
                name: "IX_BOQLine_CostCodeId",
                schema: "Contracting",
                table: "BOQLine");

            migrationBuilder.DropIndex(
                name: "IX_BOQLine_WBSId",
                schema: "Contracting",
                table: "BOQLine");
        }
    }
}
