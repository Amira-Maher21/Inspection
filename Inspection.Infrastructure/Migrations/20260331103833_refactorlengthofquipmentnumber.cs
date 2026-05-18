using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class refactorlengthofquipmentnumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.AlterColumn<string>(
                name: "EquipmentNo",
                schema: "Inspection",
                table: "Equipment",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "In_Date",
                schema: "syst",
                table: "Language");

            migrationBuilder.DropColumn(
                name: "In_User",
                schema: "syst",
                table: "Language");

            migrationBuilder.DropColumn(
                name: "Mod_Date",
                schema: "syst",
                table: "Language");

            migrationBuilder.DropColumn(
                name: "Mod_User",
                schema: "syst",
                table: "Language");

            migrationBuilder.DropColumn(
                name: "Tenant_ID",
                schema: "syst",
                table: "Language");

            migrationBuilder.AlterColumn<string>(
                name: "EquipmentNo",
                schema: "Inspection",
                table: "Equipment",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
