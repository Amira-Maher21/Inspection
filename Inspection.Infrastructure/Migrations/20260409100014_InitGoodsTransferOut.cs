using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitGoodsTransferOut : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.CreateTable(
                name: "GoodsTransferOut",
                schema: "Inventory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenant_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    GoodsTransferOutNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BranchId = table.Column<long>(type: "bigint", nullable: false),
                    WareHouseFromId = table.Column<long>(type: "bigint", nullable: false),
                    WareHouseId = table.Column<long>(type: "bigint", nullable: true),
                    GoodsTransferOutDate = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    table.PrimaryKey("PK_GoodsTransferOut", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GoodsTransferOut_Branch_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "Accounting",
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GoodsTransferOut_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalSchema: "Stt",
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GoodsTransferOut_Warehouse_WareHouseFromId",
                        column: x => x.WareHouseFromId,
                        principalSchema: "Inventory",
                        principalTable: "Warehouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GoodsTransferOut_Warehouse_WareHouseId",
                        column: x => x.WareHouseId,
                        principalSchema: "Inventory",
                        principalTable: "Warehouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GoodsTransferOutLine",
                schema: "Inventory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GoodsTransferOutId = table.Column<long>(type: "bigint", nullable: false),
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
                    table.PrimaryKey("PK_GoodsTransferOutLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GoodsTransferOutLine_CostCenter_CostCenterId",
                        column: x => x.CostCenterId,
                        principalSchema: "Accounting",
                        principalTable: "CostCenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GoodsTransferOutLine_CostUnit_CostUnitId",
                        column: x => x.CostUnitId,
                        principalSchema: "Accounting",
                        principalTable: "CostUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GoodsTransferOutLine_GoodsTransferOut_GoodsTransferOutId",
                        column: x => x.GoodsTransferOutId,
                        principalSchema: "Inventory",
                        principalTable: "GoodsTransferOut",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GoodsTransferOutLine_Item_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "Inventory",
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GoodsTransferOutLine_Operation_OperationId",
                        column: x => x.OperationId,
                        principalSchema: "Sec",
                        principalTable: "Operation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GoodsTransferOutLine_UnitOfMeasure_UnitOfMeasureId",
                        column: x => x.UnitOfMeasureId,
                        principalSchema: "Inventory",
                        principalTable: "UnitOfMeasure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GoodsTransferOutLine_WarehouseLocation_WarehouseLocationId",
                        column: x => x.WarehouseLocationId,
                        principalSchema: "Inventory",
                        principalTable: "WarehouseLocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GoodsTransferOutLine_Warehouse_WareHouseId",
                        column: x => x.WareHouseId,
                        principalSchema: "Inventory",
                        principalTable: "Warehouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GoodsTransferOut_BranchId",
                schema: "Inventory",
                table: "GoodsTransferOut",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsTransferOut_SeriesId",
                schema: "Inventory",
                table: "GoodsTransferOut",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsTransferOut_Tenant_ID_CompanyId_GoodsTransferOutNumber",
                schema: "Inventory",
                table: "GoodsTransferOut",
                columns: new[] { "Tenant_ID", "CompanyId", "GoodsTransferOutNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GoodsTransferOut_WareHouseFromId",
                schema: "Inventory",
                table: "GoodsTransferOut",
                column: "WareHouseFromId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsTransferOut_WareHouseId",
                schema: "Inventory",
                table: "GoodsTransferOut",
                column: "WareHouseId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsTransferOutLine_CostCenterId",
                schema: "Inventory",
                table: "GoodsTransferOutLine",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsTransferOutLine_CostUnitId",
                schema: "Inventory",
                table: "GoodsTransferOutLine",
                column: "CostUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsTransferOutLine_GoodsTransferOutId",
                schema: "Inventory",
                table: "GoodsTransferOutLine",
                column: "GoodsTransferOutId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsTransferOutLine_ItemId",
                schema: "Inventory",
                table: "GoodsTransferOutLine",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsTransferOutLine_OperationId",
                schema: "Inventory",
                table: "GoodsTransferOutLine",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsTransferOutLine_UnitOfMeasureId",
                schema: "Inventory",
                table: "GoodsTransferOutLine",
                column: "UnitOfMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsTransferOutLine_WareHouseId",
                schema: "Inventory",
                table: "GoodsTransferOutLine",
                column: "WareHouseId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsTransferOutLine_WarehouseLocationId",
                schema: "Inventory",
                table: "GoodsTransferOutLine",
                column: "WarehouseLocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GoodsTransferOutLine",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "GoodsTransferOut",
                schema: "Inventory");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "Accounting",
                table: "PurchaseInvoiceAdjustment",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }
    }
}
