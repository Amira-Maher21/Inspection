using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EditItemValidations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Item_Service_No_Stock",
                schema: "Inventory",
                table: "Item");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Item_Variant_Rules",
                schema: "Inventory",
                table: "Item");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Item_Service_No_Stock",
                schema: "Inventory",
                table: "Item",
                sql: "([ItemType] <> 2) OR ([IsStocked] = 0 AND [IsSerialTracked] = 0 AND [IsBatchTracked] = 0)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Item_Service_No_Stock",
                schema: "Inventory",
                table: "Item");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Item_Service_No_Stock",
                schema: "Inventory",
                table: "Item",
                sql: "([ItemType] <> 2) OR ([IsStocked] = 0 AND [IsSerialTracked] = 0 AND [IsBatchTracked] = 0 AND [IsExpiryTracked] = 0)");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Item_Variant_Rules",
                schema: "Inventory",
                table: "Item",
                sql: "([HasVariant] = 1 AND [RelatedItemVariantId] IS NULL) OR ([HasVariant] = 0 AND [RelatedItemVariantId] IS NOT NULL) OR ([HasVariant] IS NULL)");
        }
    }
}
