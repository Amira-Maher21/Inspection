using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Fix_ItemType_Enum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Item_Inventory_Rules",
                schema: "Inventory",
                table: "Item");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Item_Service_No_Stock",
                schema: "Inventory",
                table: "Item");

            migrationBuilder.AlterColumn<string>(
                name: "Program_ID",
                schema: "Syst",
                table: "Menu",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.AddCheckConstraint(
                name: "CK_Item_Inventory_Rules",
                schema: "Inventory",
                table: "Item",
                sql: "([ItemType] <> 1) OR ([IsStocked] = 1 AND [UnitOfMeasureId] IS NOT NULL)");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Item_Service_No_Stock",
                schema: "Inventory",
                table: "Item",
                sql: "([ItemType] <> 2) OR ([IsStocked] = 0 AND [IsSerialTracked] = 0 AND [IsBatchTracked] = 0 AND [IsExpiryTracked] = 0)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Item_Inventory_Rules",
                schema: "Inventory",
                table: "Item");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Item_Service_No_Stock",
                schema: "Inventory",
                table: "Item");

            migrationBuilder.AlterColumn<string>(
                name: "Program_ID",
                schema: "Syst",
                table: "Menu",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(6)",
                oldMaxLength: 6,
                oldNullable: true);

            migrationBuilder.AddCheckConstraint(
                name: "CK_Item_Inventory_Rules",
                schema: "Inventory",
                table: "Item",
                sql: "([ItemType] <> 'Inventory') OR ([IsStocked] = 1 AND [UnitOfMeasureId] IS NOT NULL)");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Item_Service_No_Stock",
                schema: "Inventory",
                table: "Item",
                sql: "([ItemType] <> 'Service') OR ([IsStocked] = 0 AND [IsSerialTracked] = 0 AND [IsBatchTracked] = 0 AND [IsExpiryTracked] = 0)");
        }
    }
}
