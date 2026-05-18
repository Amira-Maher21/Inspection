using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SubcontractBOQLineFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SubcontractBOQLine_CostCodeId",
                schema: "Contracting",
                table: "SubcontractBOQLine",
                column: "CostCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_SubcontractBOQLine_WBSId",
                schema: "Contracting",
                table: "SubcontractBOQLine",
                column: "WBSId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubcontractBOQLine_CostCode_CostCodeId",
                schema: "Contracting",
                table: "SubcontractBOQLine",
                column: "CostCodeId",
                principalSchema: "Contracting",
                principalTable: "CostCode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubcontractBOQLine_WBS_WBSId",
                schema: "Contracting",
                table: "SubcontractBOQLine",
                column: "WBSId",
                principalSchema: "Contracting",
                principalTable: "WBS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubcontractBOQLine_CostCode_CostCodeId",
                schema: "Contracting",
                table: "SubcontractBOQLine");

            migrationBuilder.DropForeignKey(
                name: "FK_SubcontractBOQLine_WBS_WBSId",
                schema: "Contracting",
                table: "SubcontractBOQLine");

            migrationBuilder.DropIndex(
                name: "IX_SubcontractBOQLine_CostCodeId",
                schema: "Contracting",
                table: "SubcontractBOQLine");

            migrationBuilder.DropIndex(
                name: "IX_SubcontractBOQLine_WBSId",
                schema: "Contracting",
                table: "SubcontractBOQLine");
        }
    }
}
