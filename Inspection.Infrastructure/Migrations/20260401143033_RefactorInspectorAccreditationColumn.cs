using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RefactorInspectorAccreditationColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InspectorAccreditation_AccreditationBody_AccreditationBodyId",
                schema: "Inspection",
                table: "InspectorAccreditation");

            migrationBuilder.DropForeignKey(
                name: "FK_InspectorAccreditation_Inspector_InspectorId",
                schema: "Inspection",
                table: "InspectorAccreditation");

            migrationBuilder.DropIndex(
                name: "IX_InspectorAccreditation_InspectorId",
                schema: "Inspection",
                table: "InspectorAccreditation");

            migrationBuilder.DropColumn(
                name: "InspectorId",
                schema: "Inspection",
                table: "InspectorAccreditation");

            migrationBuilder.AddForeignKey(
                name: "FK_InspectorAccreditation_AccreditationBody_AccreditationBodyId",
                schema: "Inspection",
                table: "InspectorAccreditation",
                column: "AccreditationBodyId",
                principalSchema: "Inspection",
                principalTable: "AccreditationBody",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InspectorAccreditation_AccreditationBody_AccreditationBodyId",
                schema: "Inspection",
                table: "InspectorAccreditation");

            migrationBuilder.AddColumn<long>(
                name: "InspectorId",
                schema: "Inspection",
                table: "InspectorAccreditation",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_InspectorAccreditation_InspectorId",
                schema: "Inspection",
                table: "InspectorAccreditation",
                column: "InspectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_InspectorAccreditation_AccreditationBody_AccreditationBodyId",
                schema: "Inspection",
                table: "InspectorAccreditation",
                column: "AccreditationBodyId",
                principalSchema: "Inspection",
                principalTable: "AccreditationBody",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InspectorAccreditation_Inspector_InspectorId",
                schema: "Inspection",
                table: "InspectorAccreditation",
                column: "InspectorId",
                principalSchema: "Inspection",
                principalTable: "Inspector",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
