using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitInventoryAdjustment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InventoryAdjustment",
                schema: "Inventory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenant_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    InventoryAdjustmentNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BranchId = table.Column<long>(type: "bigint", nullable: false),
                    WareHouseId = table.Column<long>(type: "bigint", nullable: true),
                    InventoryAdjustmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Posting = table.Column<int>(type: "int", nullable: false),
                    ApprovalStatus = table.Column<int>(type: "int", nullable: false),
                    SeriesId = table.Column<long>(type: "bigint", nullable: true),
                    RunningNumber = table.Column<int>(type: "int", nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryAdjustment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryAdjustment_Branch_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "Accounting",
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryAdjustment_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalSchema: "Stt",
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryAdjustment_Warehouse_WareHouseId",
                        column: x => x.WareHouseId,
                        principalSchema: "Inventory",
                        principalTable: "Warehouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InventoryAdjustmentLine",
                schema: "Inventory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventoryAdjustmentId = table.Column<long>(type: "bigint", nullable: false),
                    SystemQty = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    CountedQty = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    DifferenceQty = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: true),
                    Adjustment = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ItemId = table.Column<long>(type: "bigint", nullable: false),
                    GoodsTransferInId = table.Column<long>(type: "bigint", nullable: false),
                    UnitOfMeasureId = table.Column<long>(type: "bigint", nullable: false),
                    WarehouseLocationId = table.Column<long>(type: "bigint", nullable: true),
                    CostCenterId = table.Column<long>(type: "bigint", nullable: true),
                    CostUnitId = table.Column<long>(type: "bigint", nullable: true),
                    OperationId = table.Column<long>(type: "bigint", nullable: true),
                    WBSId = table.Column<long>(type: "bigint", nullable: true),
                    CostCodeId = table.Column<long>(type: "bigint", nullable: true),
                    ActivityId = table.Column<long>(type: "bigint", nullable: true),
                    BOQItemId = table.Column<long>(type: "bigint", nullable: true),
                    SubcontractBOQId = table.Column<long>(type: "bigint", nullable: true),
                    ProductionOrderId = table.Column<long>(type: "bigint", nullable: true),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryAdjustmentLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryAdjustmentLine_CostCenter_CostCenterId",
                        column: x => x.CostCenterId,
                        principalSchema: "Accounting",
                        principalTable: "CostCenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryAdjustmentLine_CostUnit_CostUnitId",
                        column: x => x.CostUnitId,
                        principalSchema: "Accounting",
                        principalTable: "CostUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryAdjustmentLine_GoodsTransferIn_GoodsTransferInId",
                        column: x => x.GoodsTransferInId,
                        principalSchema: "Inventory",
                        principalTable: "GoodsTransferIn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryAdjustmentLine_InventoryAdjustment_InventoryAdjustmentId",
                        column: x => x.InventoryAdjustmentId,
                        principalSchema: "Inventory",
                        principalTable: "InventoryAdjustment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryAdjustmentLine_Item_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "Inventory",
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryAdjustmentLine_Operation_OperationId",
                        column: x => x.OperationId,
                        principalSchema: "Sec",
                        principalTable: "Operation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryAdjustmentLine_UnitOfMeasure_UnitOfMeasureId",
                        column: x => x.UnitOfMeasureId,
                        principalSchema: "Inventory",
                        principalTable: "UnitOfMeasure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryAdjustmentLine_WarehouseLocation_WarehouseLocationId",
                        column: x => x.WarehouseLocationId,
                        principalSchema: "Inventory",
                        principalTable: "WarehouseLocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryAdjustment_BranchId",
                schema: "Inventory",
                table: "InventoryAdjustment",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryAdjustment_SeriesId",
                schema: "Inventory",
                table: "InventoryAdjustment",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryAdjustment_Tenant_ID_CompanyId_InventoryAdjustmentNumber",
                schema: "Inventory",
                table: "InventoryAdjustment",
                columns: new[] { "Tenant_ID", "CompanyId", "InventoryAdjustmentNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InventoryAdjustment_WareHouseId",
                schema: "Inventory",
                table: "InventoryAdjustment",
                column: "WareHouseId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryAdjustmentLine_CostCenterId",
                schema: "Inventory",
                table: "InventoryAdjustmentLine",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryAdjustmentLine_CostUnitId",
                schema: "Inventory",
                table: "InventoryAdjustmentLine",
                column: "CostUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryAdjustmentLine_GoodsTransferInId",
                schema: "Inventory",
                table: "InventoryAdjustmentLine",
                column: "GoodsTransferInId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryAdjustmentLine_InventoryAdjustmentId",
                schema: "Inventory",
                table: "InventoryAdjustmentLine",
                column: "InventoryAdjustmentId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryAdjustmentLine_ItemId",
                schema: "Inventory",
                table: "InventoryAdjustmentLine",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryAdjustmentLine_OperationId",
                schema: "Inventory",
                table: "InventoryAdjustmentLine",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryAdjustmentLine_UnitOfMeasureId",
                schema: "Inventory",
                table: "InventoryAdjustmentLine",
                column: "UnitOfMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryAdjustmentLine_WarehouseLocationId",
                schema: "Inventory",
                table: "InventoryAdjustmentLine",
                column: "WarehouseLocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryAdjustmentLine",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "InventoryAdjustment",
                schema: "Inventory");
        }
    }
}
