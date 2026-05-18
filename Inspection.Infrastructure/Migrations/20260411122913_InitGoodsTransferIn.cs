using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitGoodsTransferIn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GoodsTransferIn",
                schema: "Inventory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenant_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    GoodsTransferInNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BranchId = table.Column<long>(type: "bigint", nullable: false),
                    GoodsTransferOutId = table.Column<long>(type: "bigint", nullable: false),
                    WareHouseId = table.Column<long>(type: "bigint", nullable: true),
                    GoodsTransferInDate = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    table.PrimaryKey("PK_GoodsTransferIn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GoodsTransferIn_Branch_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "Accounting",
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GoodsTransferIn_GoodsTransferOut_GoodsTransferOutId",
                        column: x => x.GoodsTransferOutId,
                        principalSchema: "Inventory",
                        principalTable: "GoodsTransferOut",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GoodsTransferIn_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalSchema: "Stt",
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GoodsTransferIn_Warehouse_WareHouseId",
                        column: x => x.WareHouseId,
                        principalSchema: "Inventory",
                        principalTable: "Warehouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GoodsTransferInLine",
                schema: "Inventory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GoodsTransferInId = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: true),
                    FreeItem = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ItemId = table.Column<long>(type: "bigint", nullable: false),
                    UnitOfMeasureId = table.Column<long>(type: "bigint", nullable: false),
                    WareHouseId = table.Column<long>(type: "bigint", nullable: true),
                    CostCenterId = table.Column<long>(type: "bigint", nullable: true),
                    CostUnitId = table.Column<long>(type: "bigint", nullable: true),
                    OperationId = table.Column<long>(type: "bigint", nullable: true),
                    WarehouseLocationId = table.Column<long>(type: "bigint", nullable: true),
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
                    table.PrimaryKey("PK_GoodsTransferInLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GoodsTransferInLine_CostCenter_CostCenterId",
                        column: x => x.CostCenterId,
                        principalSchema: "Accounting",
                        principalTable: "CostCenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GoodsTransferInLine_CostUnit_CostUnitId",
                        column: x => x.CostUnitId,
                        principalSchema: "Accounting",
                        principalTable: "CostUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GoodsTransferInLine_GoodsTransferIn_GoodsTransferInId",
                        column: x => x.GoodsTransferInId,
                        principalSchema: "Inventory",
                        principalTable: "GoodsTransferIn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GoodsTransferInLine_Item_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "Inventory",
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GoodsTransferInLine_Operation_OperationId",
                        column: x => x.OperationId,
                        principalSchema: "Sec",
                        principalTable: "Operation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GoodsTransferInLine_UnitOfMeasure_UnitOfMeasureId",
                        column: x => x.UnitOfMeasureId,
                        principalSchema: "Inventory",
                        principalTable: "UnitOfMeasure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GoodsTransferInLine_WarehouseLocation_WarehouseLocationId",
                        column: x => x.WarehouseLocationId,
                        principalSchema: "Inventory",
                        principalTable: "WarehouseLocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GoodsTransferInLine_Warehouse_WareHouseId",
                        column: x => x.WareHouseId,
                        principalSchema: "Inventory",
                        principalTable: "Warehouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GoodsTransferIn_BranchId",
                schema: "Inventory",
                table: "GoodsTransferIn",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsTransferIn_GoodsTransferOutId",
                schema: "Inventory",
                table: "GoodsTransferIn",
                column: "GoodsTransferOutId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsTransferIn_SeriesId",
                schema: "Inventory",
                table: "GoodsTransferIn",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsTransferIn_Tenant_ID_CompanyId_GoodsTransferInNumber",
                schema: "Inventory",
                table: "GoodsTransferIn",
                columns: new[] { "Tenant_ID", "CompanyId", "GoodsTransferInNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GoodsTransferIn_WareHouseId",
                schema: "Inventory",
                table: "GoodsTransferIn",
                column: "WareHouseId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsTransferInLine_CostCenterId",
                schema: "Inventory",
                table: "GoodsTransferInLine",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsTransferInLine_CostUnitId",
                schema: "Inventory",
                table: "GoodsTransferInLine",
                column: "CostUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsTransferInLine_GoodsTransferInId",
                schema: "Inventory",
                table: "GoodsTransferInLine",
                column: "GoodsTransferInId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsTransferInLine_ItemId",
                schema: "Inventory",
                table: "GoodsTransferInLine",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsTransferInLine_OperationId",
                schema: "Inventory",
                table: "GoodsTransferInLine",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsTransferInLine_UnitOfMeasureId",
                schema: "Inventory",
                table: "GoodsTransferInLine",
                column: "UnitOfMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsTransferInLine_WareHouseId",
                schema: "Inventory",
                table: "GoodsTransferInLine",
                column: "WareHouseId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsTransferInLine_WarehouseLocationId",
                schema: "Inventory",
                table: "GoodsTransferInLine",
                column: "WarehouseLocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GoodsTransferInLine",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "GoodsTransferIn",
                schema: "Inventory");
        }
    }
}
