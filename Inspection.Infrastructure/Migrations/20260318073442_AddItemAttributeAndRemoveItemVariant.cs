using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddItemAttributeAndRemoveItemVariant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GoodsReceiptLine_ItemVariant_ItemVariantId",
                schema: "Inventory",
                table: "GoodsReceiptLine");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryBalance_ItemVariant_ItemVariantId",
                schema: "Inventory",
                table: "InventoryBalance");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryCostLayer_ItemVariant_ItemVariantId",
                schema: "Inventory",
                table: "InventoryCostLayer");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryCostLayer_Item_ItemId",
                schema: "Inventory",
                table: "InventoryCostLayer");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryCostLayer_Warehouse_WarehouseId",
                schema: "Inventory",
                table: "InventoryCostLayer");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryLedger_ItemVariant_ItemVariantId",
                schema: "Inventory",
                table: "InventoryLedger");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryOpeningBalance_ItemVariant_ItemVariantId",
                schema: "Inventory",
                table: "InventoryOpeningBalance");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrderLine_ItemVariant_ItemVariantId",
                schema: "Sales",
                table: "SalesOrderLine");

            migrationBuilder.DropTable(
                name: "ItemVariant",
                schema: "Inventory");

            migrationBuilder.DropIndex(
                name: "IX_SalesOrderLine_ItemVariantId",
                schema: "Sales",
                table: "SalesOrderLine");

            migrationBuilder.DropIndex(
                name: "IX_InventoryOpeningBalance_ItemVariantId",
                schema: "Inventory",
                table: "InventoryOpeningBalance");

            migrationBuilder.DropIndex(
                name: "UQ_InventoryOpeningBalance",
                schema: "Inventory",
                table: "InventoryOpeningBalance");

            migrationBuilder.DropIndex(
                name: "IX_InventoryLedger_ItemVariantId",
                schema: "Inventory",
                table: "InventoryLedger");

            migrationBuilder.DropIndex(
                name: "IX_InventoryCostLayer_ItemVariantId",
                schema: "Inventory",
                table: "InventoryCostLayer");

            migrationBuilder.DropIndex(
                name: "UQ_InventoryCostLayer_Item",
                schema: "Inventory",
                table: "InventoryCostLayer");

            migrationBuilder.DropIndex(
                name: "UQ_InventoryCostLayer_Variant",
                schema: "Inventory",
                table: "InventoryCostLayer");

            migrationBuilder.DropIndex(
                name: "IX_InventoryBalance_ItemVariantId",
                schema: "Inventory",
                table: "InventoryBalance");

            migrationBuilder.DropIndex(
                name: "IX_InventoryBalance_Tenant_ID_ItemId_WarehouseId_WarehouseLocationId",
                schema: "Inventory",
                table: "InventoryBalance");

            migrationBuilder.DropIndex(
                name: "IX_InventoryBalance_Tenant_ID_ItemVariantId_WarehouseId_WarehouseLocationId",
                schema: "Inventory",
                table: "InventoryBalance");

            migrationBuilder.DropCheckConstraint(
                name: "CK_InvBalance_ItemOrVariant",
                schema: "Inventory",
                table: "InventoryBalance");

            migrationBuilder.DropCheckConstraint(
                name: "CK_InvBalance_Quantity",
                schema: "Inventory",
                table: "InventoryBalance");

            migrationBuilder.DropCheckConstraint(
                name: "CK_InvBalance_ReservedQuantity",
                schema: "Inventory",
                table: "InventoryBalance");

            migrationBuilder.DropIndex(
                name: "IX_GoodsReceiptLine_ItemVariantId",
                schema: "Inventory",
                table: "GoodsReceiptLine");

            migrationBuilder.DropIndex(
                name: "UQ_GoodsReceiptLine_NoDuplicate",
                schema: "Inventory",
                table: "GoodsReceiptLine");

            migrationBuilder.DropColumn(
                name: "ItemVariantId",
                schema: "Sales",
                table: "SalesOrderLine");

            migrationBuilder.DropColumn(
                name: "ItemVariantId",
                schema: "Inventory",
                table: "InventoryOpeningBalance");

            migrationBuilder.DropColumn(
                name: "ItemVariantId",
                schema: "Inventory",
                table: "InventoryLedger");

            migrationBuilder.DropColumn(
                name: "ItemVariantId",
                schema: "Inventory",
                table: "InventoryCostLayer");

            migrationBuilder.DropColumn(
                name: "ItemVariantId",
                schema: "Inventory",
                table: "InventoryBalance");

            migrationBuilder.DropColumn(
                name: "ItemVariantId",
                schema: "Inventory",
                table: "GoodsReceiptLine");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryBalance_ItemId",
                schema: "Inventory",
                table: "InventoryBalance",
                newName: "IX_InventoryBalance_Item");

            migrationBuilder.AddColumn<long>(
                name: "ItemId1",
                schema: "Inventory",
                table: "ItemReorderPerWarehouse",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Tenant_ID",
                schema: "Inventory",
                table: "InventoryCostLayer",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Tenant_ID",
                schema: "Inventory",
                table: "InventoryBalance",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "In_User",
                schema: "Inventory",
                table: "InventoryBalance",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "ItemAttribute",
                schema: "Inventory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenant_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AttributeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemAttribute", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemAttributeValue",
                schema: "Inventory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemAttributeId = table.Column<long>(type: "bigint", nullable: false),
                    AttributeValue = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ItemAttributeId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemAttributeValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemAttributeValue_ItemAttribute_ItemAttributeId",
                        column: x => x.ItemAttributeId,
                        principalSchema: "Inventory",
                        principalTable: "ItemAttribute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemAttributeValue_ItemAttribute_ItemAttributeId1",
                        column: x => x.ItemAttributeId1,
                        principalSchema: "Inventory",
                        principalTable: "ItemAttribute",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemReorderPerWarehouse_ItemId1",
                schema: "Inventory",
                table: "ItemReorderPerWarehouse",
                column: "ItemId1");

            migrationBuilder.CreateIndex(
                name: "UQ_InventoryOpeningBalance",
                schema: "Inventory",
                table: "InventoryOpeningBalance",
                columns: new[] { "CompanyId", "FiscalYearId", "WarehouseId", "ItemId", "WarehouseLocationId" },
                unique: true,
                filter: "[WarehouseLocationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryCostLayer_FIFO",
                schema: "Inventory",
                table: "InventoryCostLayer",
                columns: new[] { "Tenant_ID", "ItemId", "WarehouseId", "TransactionDate" });

            migrationBuilder.CreateIndex(
                name: "UQ_InventoryCostLayer_Transaction",
                schema: "Inventory",
                table: "InventoryCostLayer",
                columns: new[] { "Tenant_ID", "CompanyId", "ItemId", "WarehouseId", "SourceTransactionId" },
                unique: true);

            migrationBuilder.AddCheckConstraint(
                name: "CK_CostLayer_QtyIn",
                schema: "Inventory",
                table: "InventoryCostLayer",
                sql: "[QuantityIn] >= 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_CostLayer_QtyOut",
                schema: "Inventory",
                table: "InventoryCostLayer",
                sql: "[QuantityOut] >= 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_CostLayer_QtyOut_Less_Than_In",
                schema: "Inventory",
                table: "InventoryCostLayer",
                sql: "[QuantityOut] <= [QuantityIn]");

            migrationBuilder.AddCheckConstraint(
                name: "CK_CostLayer_Remaining",
                schema: "Inventory",
                table: "InventoryCostLayer",
                sql: "[RemainingQty] >= 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_CostLayer_Remaining_Valid",
                schema: "Inventory",
                table: "InventoryCostLayer",
                sql: "[RemainingQty] = [QuantityIn] - [QuantityOut]");

            migrationBuilder.CreateIndex(
                name: "UQ_InventoryBalance_Item_Warehouse_Location",
                schema: "Inventory",
                table: "InventoryBalance",
                columns: new[] { "Tenant_ID", "CompanyId", "ItemId", "WarehouseId", "WarehouseLocationId" },
                unique: true,
                filter: "[ItemId] IS NOT NULL AND [WarehouseLocationId] IS NOT NULL");

            migrationBuilder.AddCheckConstraint(
                name: "CK_InvBalance_Item_Required",
                schema: "Inventory",
                table: "InventoryBalance",
                sql: "[ItemId] IS NOT NULL");

            migrationBuilder.AddCheckConstraint(
                name: "CK_InvBalance_Quantity",
                schema: "Inventory",
                table: "InventoryBalance",
                sql: "[Quantity] >= 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_InvBalance_Reserved_Less_Than_Quantity",
                schema: "Inventory",
                table: "InventoryBalance",
                sql: "[ReservedQuantity] <= [Quantity]");

            migrationBuilder.AddCheckConstraint(
                name: "CK_InvBalance_ReservedQuantity",
                schema: "Inventory",
                table: "InventoryBalance",
                sql: "[ReservedQuantity] >= 0");

            migrationBuilder.CreateIndex(
                name: "UQ_GoodsReceiptLine_NoDuplicate",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                columns: new[] { "GoodsReceiptId", "ItemId", "WarehouseLocationId" },
                unique: true,
                filter: "[WarehouseLocationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ_ItemAttribute_Tenant_AttributeName",
                schema: "Inventory",
                table: "ItemAttribute",
                columns: new[] { "Tenant_ID", "AttributeName" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemAttributeValue_ItemAttributeId1",
                schema: "Inventory",
                table: "ItemAttributeValue",
                column: "ItemAttributeId1");

            migrationBuilder.CreateIndex(
                name: "UQ_ItemAttributeValue_AttributeId_Value",
                schema: "Inventory",
                table: "ItemAttributeValue",
                columns: new[] { "ItemAttributeId", "AttributeValue" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryCostLayer_Item_ItemId",
                schema: "Inventory",
                table: "InventoryCostLayer",
                column: "ItemId",
                principalSchema: "Inventory",
                principalTable: "Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryCostLayer_Warehouse_WarehouseId",
                schema: "Inventory",
                table: "InventoryCostLayer",
                column: "WarehouseId",
                principalSchema: "Inventory",
                principalTable: "Warehouse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemReorderPerWarehouse_Item_ItemId1",
                schema: "Inventory",
                table: "ItemReorderPerWarehouse",
                column: "ItemId1",
                principalSchema: "Inventory",
                principalTable: "Item",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryCostLayer_Item_ItemId",
                schema: "Inventory",
                table: "InventoryCostLayer");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryCostLayer_Warehouse_WarehouseId",
                schema: "Inventory",
                table: "InventoryCostLayer");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemReorderPerWarehouse_Item_ItemId1",
                schema: "Inventory",
                table: "ItemReorderPerWarehouse");

            migrationBuilder.DropTable(
                name: "ItemAttributeValue",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "ItemAttribute",
                schema: "Inventory");

            migrationBuilder.DropIndex(
                name: "IX_ItemReorderPerWarehouse_ItemId1",
                schema: "Inventory",
                table: "ItemReorderPerWarehouse");

            migrationBuilder.DropIndex(
                name: "UQ_InventoryOpeningBalance",
                schema: "Inventory",
                table: "InventoryOpeningBalance");

            migrationBuilder.DropIndex(
                name: "IX_InventoryCostLayer_FIFO",
                schema: "Inventory",
                table: "InventoryCostLayer");

            migrationBuilder.DropIndex(
                name: "UQ_InventoryCostLayer_Transaction",
                schema: "Inventory",
                table: "InventoryCostLayer");

            migrationBuilder.DropCheckConstraint(
                name: "CK_CostLayer_QtyIn",
                schema: "Inventory",
                table: "InventoryCostLayer");

            migrationBuilder.DropCheckConstraint(
                name: "CK_CostLayer_QtyOut",
                schema: "Inventory",
                table: "InventoryCostLayer");

            migrationBuilder.DropCheckConstraint(
                name: "CK_CostLayer_QtyOut_Less_Than_In",
                schema: "Inventory",
                table: "InventoryCostLayer");

            migrationBuilder.DropCheckConstraint(
                name: "CK_CostLayer_Remaining",
                schema: "Inventory",
                table: "InventoryCostLayer");

            migrationBuilder.DropCheckConstraint(
                name: "CK_CostLayer_Remaining_Valid",
                schema: "Inventory",
                table: "InventoryCostLayer");

            migrationBuilder.DropIndex(
                name: "UQ_InventoryBalance_Item_Warehouse_Location",
                schema: "Inventory",
                table: "InventoryBalance");

            migrationBuilder.DropCheckConstraint(
                name: "CK_InvBalance_Item_Required",
                schema: "Inventory",
                table: "InventoryBalance");

            migrationBuilder.DropCheckConstraint(
                name: "CK_InvBalance_Quantity",
                schema: "Inventory",
                table: "InventoryBalance");

            migrationBuilder.DropCheckConstraint(
                name: "CK_InvBalance_Reserved_Less_Than_Quantity",
                schema: "Inventory",
                table: "InventoryBalance");

            migrationBuilder.DropCheckConstraint(
                name: "CK_InvBalance_ReservedQuantity",
                schema: "Inventory",
                table: "InventoryBalance");

            migrationBuilder.DropIndex(
                name: "UQ_GoodsReceiptLine_NoDuplicate",
                schema: "Inventory",
                table: "GoodsReceiptLine");

            migrationBuilder.DropColumn(
                name: "ItemId1",
                schema: "Inventory",
                table: "ItemReorderPerWarehouse");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryBalance_Item",
                schema: "Inventory",
                table: "InventoryBalance",
                newName: "IX_InventoryBalance_ItemId");

            migrationBuilder.AddColumn<long>(
                name: "ItemVariantId",
                schema: "Sales",
                table: "SalesOrderLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ItemVariantId",
                schema: "Inventory",
                table: "InventoryOpeningBalance",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ItemVariantId",
                schema: "Inventory",
                table: "InventoryLedger",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Tenant_ID",
                schema: "Inventory",
                table: "InventoryCostLayer",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<long>(
                name: "ItemVariantId",
                schema: "Inventory",
                table: "InventoryCostLayer",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Tenant_ID",
                schema: "Inventory",
                table: "InventoryBalance",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "In_User",
                schema: "Inventory",
                table: "InventoryBalance",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<long>(
                name: "ItemVariantId",
                schema: "Inventory",
                table: "InventoryBalance",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ItemVariantId",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ItemVariant",
                schema: "Inventory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorId = table.Column<long>(type: "bigint", nullable: true),
                    ItemId = table.Column<long>(type: "bigint", nullable: false),
                    ModelId = table.Column<long>(type: "bigint", nullable: true),
                    SizeId = table.Column<long>(type: "bigint", nullable: true),
                    BarCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ItemId1 = table.Column<long>(type: "bigint", nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    SKU = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemVariant", x => x.Id);
                    table.CheckConstraint("CK_ItemVariant_AtLeastOneAttribute", "[ColorId] IS NOT NULL OR [SizeId] IS NOT NULL OR [ModelId] IS NOT NULL");
                    table.CheckConstraint("CK_ItemVariant_UnitPrice_Positive", "[UnitPrice] IS NULL OR [UnitPrice] >= 0");
                    table.ForeignKey(
                        name: "FK_ItemVariant_Color_ColorId",
                        column: x => x.ColorId,
                        principalSchema: "Inventory",
                        principalTable: "Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemVariant_Item_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "Inventory",
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemVariant_Item_ItemId1",
                        column: x => x.ItemId1,
                        principalSchema: "Inventory",
                        principalTable: "Item",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ItemVariant_Model_ModelId",
                        column: x => x.ModelId,
                        principalSchema: "Inventory",
                        principalTable: "Model",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemVariant_Size_SizeId",
                        column: x => x.SizeId,
                        principalSchema: "Inventory",
                        principalTable: "Size",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderLine_ItemVariantId",
                schema: "Sales",
                table: "SalesOrderLine",
                column: "ItemVariantId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryOpeningBalance_ItemVariantId",
                schema: "Inventory",
                table: "InventoryOpeningBalance",
                column: "ItemVariantId");

            migrationBuilder.CreateIndex(
                name: "UQ_InventoryOpeningBalance",
                schema: "Inventory",
                table: "InventoryOpeningBalance",
                columns: new[] { "CompanyId", "FiscalYearId", "WarehouseId", "ItemId", "ItemVariantId", "WarehouseLocationId" },
                unique: true,
                filter: "[ItemVariantId] IS NOT NULL AND [WarehouseLocationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryLedger_ItemVariantId",
                schema: "Inventory",
                table: "InventoryLedger",
                column: "ItemVariantId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryCostLayer_ItemVariantId",
                schema: "Inventory",
                table: "InventoryCostLayer",
                column: "ItemVariantId");

            migrationBuilder.CreateIndex(
                name: "UQ_InventoryCostLayer_Item",
                schema: "Inventory",
                table: "InventoryCostLayer",
                columns: new[] { "Tenant_ID", "ItemId", "WarehouseId" },
                unique: true,
                filter: "[ItemVariantId] IS NULL");

            migrationBuilder.CreateIndex(
                name: "UQ_InventoryCostLayer_Variant",
                schema: "Inventory",
                table: "InventoryCostLayer",
                columns: new[] { "CompanyId", "ItemVariantId", "WarehouseId" },
                unique: true,
                filter: "[ItemVariantId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryBalance_ItemVariantId",
                schema: "Inventory",
                table: "InventoryBalance",
                column: "ItemVariantId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryBalance_Tenant_ID_ItemId_WarehouseId_WarehouseLocationId",
                schema: "Inventory",
                table: "InventoryBalance",
                columns: new[] { "Tenant_ID", "ItemId", "WarehouseId", "WarehouseLocationId" },
                unique: true,
                filter: "[ItemId] IS NOT NULL AND [ItemVariantId] IS NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryBalance_Tenant_ID_ItemVariantId_WarehouseId_WarehouseLocationId",
                schema: "Inventory",
                table: "InventoryBalance",
                columns: new[] { "Tenant_ID", "ItemVariantId", "WarehouseId", "WarehouseLocationId" },
                unique: true,
                filter: "[ItemVariantId] IS NOT NULL");

            migrationBuilder.AddCheckConstraint(
                name: "CK_InvBalance_ItemOrVariant",
                schema: "Inventory",
                table: "InventoryBalance",
                sql: "(ItemId IS NOT NULL OR ItemVariantId IS NOT NULL)");

            migrationBuilder.AddCheckConstraint(
                name: "CK_InvBalance_Quantity",
                schema: "Inventory",
                table: "InventoryBalance",
                sql: "Quantity >= 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_InvBalance_ReservedQuantity",
                schema: "Inventory",
                table: "InventoryBalance",
                sql: "ReservedQuantity >= 0");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceiptLine_ItemVariantId",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                column: "ItemVariantId");

            migrationBuilder.CreateIndex(
                name: "UQ_GoodsReceiptLine_NoDuplicate",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                columns: new[] { "GoodsReceiptId", "ItemId", "ItemVariantId", "WarehouseLocationId" },
                unique: true,
                filter: "[ItemVariantId] IS NOT NULL AND [WarehouseLocationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ItemVariant_ColorId",
                schema: "Inventory",
                table: "ItemVariant",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemVariant_ItemId1",
                schema: "Inventory",
                table: "ItemVariant",
                column: "ItemId1");

            migrationBuilder.CreateIndex(
                name: "IX_ItemVariant_ModelId",
                schema: "Inventory",
                table: "ItemVariant",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemVariant_SizeId",
                schema: "Inventory",
                table: "ItemVariant",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "UQ_ItemVariant_BarCode",
                schema: "Inventory",
                table: "ItemVariant",
                column: "BarCode",
                unique: true,
                filter: "[BarCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ_ItemVariant_Item_Code",
                schema: "Inventory",
                table: "ItemVariant",
                columns: new[] { "ItemId", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_ItemVariant_Item_Combination",
                schema: "Inventory",
                table: "ItemVariant",
                columns: new[] { "ItemId", "ColorId", "SizeId", "ModelId" },
                unique: true,
                filter: "[ColorId] IS NOT NULL AND [SizeId] IS NOT NULL AND [ModelId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsReceiptLine_ItemVariant_ItemVariantId",
                schema: "Inventory",
                table: "GoodsReceiptLine",
                column: "ItemVariantId",
                principalSchema: "Inventory",
                principalTable: "ItemVariant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryBalance_ItemVariant_ItemVariantId",
                schema: "Inventory",
                table: "InventoryBalance",
                column: "ItemVariantId",
                principalSchema: "Inventory",
                principalTable: "ItemVariant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryCostLayer_ItemVariant_ItemVariantId",
                schema: "Inventory",
                table: "InventoryCostLayer",
                column: "ItemVariantId",
                principalSchema: "Inventory",
                principalTable: "ItemVariant",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryCostLayer_Item_ItemId",
                schema: "Inventory",
                table: "InventoryCostLayer",
                column: "ItemId",
                principalSchema: "Inventory",
                principalTable: "Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryCostLayer_Warehouse_WarehouseId",
                schema: "Inventory",
                table: "InventoryCostLayer",
                column: "WarehouseId",
                principalSchema: "Inventory",
                principalTable: "Warehouse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryLedger_ItemVariant_ItemVariantId",
                schema: "Inventory",
                table: "InventoryLedger",
                column: "ItemVariantId",
                principalSchema: "Inventory",
                principalTable: "ItemVariant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryOpeningBalance_ItemVariant_ItemVariantId",
                schema: "Inventory",
                table: "InventoryOpeningBalance",
                column: "ItemVariantId",
                principalSchema: "Inventory",
                principalTable: "ItemVariant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrderLine_ItemVariant_ItemVariantId",
                schema: "Sales",
                table: "SalesOrderLine",
                column: "ItemVariantId",
                principalSchema: "Inventory",
                principalTable: "ItemVariant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
