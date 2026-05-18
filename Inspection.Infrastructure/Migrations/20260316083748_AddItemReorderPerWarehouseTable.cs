using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddItemReorderPerWarehouseTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemReorderPerWarehouse",
                schema: "Inventory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<long>(type: "bigint", nullable: false),
                    DefaultWarehouseId = table.Column<long>(type: "bigint", nullable: true),
                    ReorderLevel = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    ReorderQuantity = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    SafetyStock = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemReorderPerWarehouse", x => x.Id);
                    table.CheckConstraint("CK_ItemReorderPerWareHouse_ReorderLevel_Positive", "[ReorderLevel] >= 0");
                    table.CheckConstraint("CK_ItemReorderPerWareHouse_ReorderQuantity_Positive", "[ReorderQuantity] >= 0");
                    table.CheckConstraint("CK_ItemReorderPerWareHouse_SafetyStock_Positive", "[SafetyStock] IS NULL OR [SafetyStock] >= 0");
                    table.ForeignKey(
                        name: "FK_ItemReorderPerWarehouse_Item_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "Inventory",
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemReorderPerWarehouse_Warehouse_DefaultWarehouseId",
                        column: x => x.DefaultWarehouseId,
                        principalSchema: "Inventory",
                        principalTable: "Warehouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemReorderPerWarehouse_DefaultWarehouseId",
                schema: "Inventory",
                table: "ItemReorderPerWarehouse",
                column: "DefaultWarehouseId");

            migrationBuilder.CreateIndex(
                name: "UQ_ItemReorderPerWareHouse_Item_Warehouse",
                schema: "Inventory",
                table: "ItemReorderPerWarehouse",
                columns: new[] { "ItemId", "DefaultWarehouseId" },
                unique: true,
                filter: "[DefaultWarehouseId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemReorderPerWarehouse",
                schema: "Inventory");
        }
    }
}
