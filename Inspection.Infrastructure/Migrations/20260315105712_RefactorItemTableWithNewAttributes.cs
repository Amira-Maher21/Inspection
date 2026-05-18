using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RefactorItemTableWithNewAttributes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                schema: "Inventory",
                table: "Item");

            migrationBuilder.RenameColumn(
                name: "MinStockLevel",
                schema: "Inventory",
                table: "Item",
                newName: "SafetyStock");

            migrationBuilder.RenameColumn(
                name: "MaxStockLevel",
                schema: "Inventory",
                table: "Item",
                newName: "ReorderQuantity");

            migrationBuilder.AlterColumn<string>(
                name: "SKU",
                schema: "Inventory",
                table: "Item",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Calories",
                schema: "Inventory",
                table: "Item",
                type: "decimal(18,3)",
                precision: 18,
                scale: 3,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DefaultSupplierId",
                schema: "Inventory",
                table: "Item",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ETAItemCode",
                schema: "Inventory",
                table: "Item",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ETAItemType",
                schema: "Inventory",
                table: "Item",
                type: "int",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasVariant",
                schema: "Inventory",
                table: "Item",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IncludeInOnline",
                schema: "Inventory",
                table: "Item",
                type: "bit",
                nullable: true,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IncludeInPOS",
                schema: "Inventory",
                table: "Item",
                type: "bit",
                nullable: true,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "ItemPhotoId",
                schema: "Inventory",
                table: "Item",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "RelatedItemVariantId",
                schema: "Inventory",
                table: "Item",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Sale",
                schema: "Inventory",
                table: "Item",
                type: "bit",
                nullable: true,
                defaultValue: true);

            migrationBuilder.AddColumn<decimal>(
                name: "UnitCost",
                schema: "Inventory",
                table: "Item",
                type: "decimal(18,4)",
                precision: 18,
                scale: 4,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Item_BarCode",
                schema: "Inventory",
                table: "Item",
                column: "BarCode");

            migrationBuilder.CreateIndex(
                name: "IX_Item_DefaultSupplierId",
                schema: "Inventory",
                table: "Item",
                column: "DefaultSupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_ItemPhotoId",
                schema: "Inventory",
                table: "Item",
                column: "ItemPhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_RelatedItemVariantId",
                schema: "Inventory",
                table: "Item",
                column: "RelatedItemVariantId");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Item_Variant_Rules",
                schema: "Inventory",
                table: "Item",
                sql: "([HasVariant] = 1 AND [RelatedItemVariantId] IS NULL) OR ([HasVariant] = 0 AND [RelatedItemVariantId] IS NOT NULL) OR ([HasVariant] IS NULL)");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Document_ItemPhotoId",
                schema: "Inventory",
                table: "Item",
                column: "ItemPhotoId",
                principalSchema: "DMS",
                principalTable: "Document",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Item_RelatedItemVariantId",
                schema: "Inventory",
                table: "Item",
                column: "RelatedItemVariantId",
                principalSchema: "Inventory",
                principalTable: "Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Supplier_DefaultSupplierId",
                schema: "Inventory",
                table: "Item",
                column: "DefaultSupplierId",
                principalSchema: "Accounting",
                principalTable: "Supplier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_Document_ItemPhotoId",
                schema: "Inventory",
                table: "Item");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_Item_RelatedItemVariantId",
                schema: "Inventory",
                table: "Item");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_Supplier_DefaultSupplierId",
                schema: "Inventory",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_BarCode",
                schema: "Inventory",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_DefaultSupplierId",
                schema: "Inventory",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_ItemPhotoId",
                schema: "Inventory",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_RelatedItemVariantId",
                schema: "Inventory",
                table: "Item");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Item_Variant_Rules",
                schema: "Inventory",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Calories",
                schema: "Inventory",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "DefaultSupplierId",
                schema: "Inventory",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "ETAItemCode",
                schema: "Inventory",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "ETAItemType",
                schema: "Inventory",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "HasVariant",
                schema: "Inventory",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "IncludeInOnline",
                schema: "Inventory",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "IncludeInPOS",
                schema: "Inventory",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "ItemPhotoId",
                schema: "Inventory",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "RelatedItemVariantId",
                schema: "Inventory",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Sale",
                schema: "Inventory",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "UnitCost",
                schema: "Inventory",
                table: "Item");

            migrationBuilder.RenameColumn(
                name: "SafetyStock",
                schema: "Inventory",
                table: "Item",
                newName: "MinStockLevel");

            migrationBuilder.RenameColumn(
                name: "ReorderQuantity",
                schema: "Inventory",
                table: "Item",
                newName: "MaxStockLevel");

            migrationBuilder.AlterColumn<string>(
                name: "SKU",
                schema: "Inventory",
                table: "Item",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                schema: "Inventory",
                table: "Item",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }
    }
}
