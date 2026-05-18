using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Edtequipment12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_EquipmentType_EquipmentTypeId",
                schema: "Inspection",
                table: "Equipment");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_EquipmentType_EquipmentTypeId",
                schema: "Inspection",
                table: "Equipment",
                column: "EquipmentTypeId",
                principalSchema: "Inspection",
                principalTable: "EquipmentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_EquipmentType_EquipmentTypeId",
                schema: "Inspection",
                table: "Equipment");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_EquipmentType_EquipmentTypeId",
                schema: "Inspection",
                table: "Equipment",
                column: "EquipmentTypeId",
                principalSchema: "Inspection",
                principalTable: "EquipmentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
