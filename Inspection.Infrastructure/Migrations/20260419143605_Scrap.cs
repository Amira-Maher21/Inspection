using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Scrap : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScrapReason",
                schema: "Inventory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenant_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ChartOfAccountId = table.Column<long>(type: "bigint", nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScrapReason", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScrapReason_ChartOfAccount_ChartOfAccountId",
                        column: x => x.ChartOfAccountId,
                        principalSchema: "Accounting",
                        principalTable: "ChartOfAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InventoryScrap",
                schema: "Inventory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenant_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    BranchId = table.Column<long>(type: "bigint", nullable: false),
                    InventoryScrapNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    WarehouseId = table.Column<long>(type: "bigint", nullable: false),
                    ScrapReasonId = table.Column<long>(type: "bigint", nullable: true),
                    InventoryScrapDate = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    table.PrimaryKey("PK_InventoryScrap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryScrap_Branch_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "Accounting",
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryScrap_ScrapReason_ScrapReasonId",
                        column: x => x.ScrapReasonId,
                        principalSchema: "Inventory",
                        principalTable: "ScrapReason",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryScrap_Warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalSchema: "Inventory",
                        principalTable: "Warehouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InventoryScrapLine",
                schema: "Inventory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventoryScrapId = table.Column<long>(type: "bigint", nullable: false),
                    ItemId = table.Column<long>(type: "bigint", nullable: false),
                    UnitOfMeasureId = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    WarehouseId = table.Column<long>(type: "bigint", nullable: false),
                    WarehouseLocationId = table.Column<long>(type: "bigint", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
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
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InventoryScrapId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryScrapLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryScrapLine_CostCenter_CostCenterId",
                        column: x => x.CostCenterId,
                        principalSchema: "Accounting",
                        principalTable: "CostCenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryScrapLine_CostUnit_CostUnitId",
                        column: x => x.CostUnitId,
                        principalSchema: "Accounting",
                        principalTable: "CostUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryScrapLine_InventoryScrap_InventoryScrapId",
                        column: x => x.InventoryScrapId,
                        principalSchema: "Inventory",
                        principalTable: "InventoryScrap",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryScrapLine_InventoryScrap_InventoryScrapId1",
                        column: x => x.InventoryScrapId1,
                        principalSchema: "Inventory",
                        principalTable: "InventoryScrap",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InventoryScrapLine_Item_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "Inventory",
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryScrapLine_Operation_OperationId",
                        column: x => x.OperationId,
                        principalSchema: "Sec",
                        principalTable: "Operation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryScrapLine_UnitOfMeasure_UnitOfMeasureId",
                        column: x => x.UnitOfMeasureId,
                        principalSchema: "Inventory",
                        principalTable: "UnitOfMeasure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryScrapLine_WarehouseLocation_WarehouseLocationId",
                        column: x => x.WarehouseLocationId,
                        principalSchema: "Inventory",
                        principalTable: "WarehouseLocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryScrapLine_Warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalSchema: "Inventory",
                        principalTable: "Warehouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryScrap_BranchId",
                schema: "Inventory",
                table: "InventoryScrap",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryScrap_ScrapReasonId",
                schema: "Inventory",
                table: "InventoryScrap",
                column: "ScrapReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryScrap_Tenant_ID_CompanyId_InventoryScrapNumber",
                schema: "Inventory",
                table: "InventoryScrap",
                columns: new[] { "Tenant_ID", "CompanyId", "InventoryScrapNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InventoryScrap_WarehouseId",
                schema: "Inventory",
                table: "InventoryScrap",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryScrapLine_CostCenterId",
                schema: "Inventory",
                table: "InventoryScrapLine",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryScrapLine_CostUnitId",
                schema: "Inventory",
                table: "InventoryScrapLine",
                column: "CostUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryScrapLine_InventoryScrapId",
                schema: "Inventory",
                table: "InventoryScrapLine",
                column: "InventoryScrapId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryScrapLine_InventoryScrapId1",
                schema: "Inventory",
                table: "InventoryScrapLine",
                column: "InventoryScrapId1");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryScrapLine_ItemId",
                schema: "Inventory",
                table: "InventoryScrapLine",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryScrapLine_OperationId",
                schema: "Inventory",
                table: "InventoryScrapLine",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryScrapLine_UnitOfMeasureId",
                schema: "Inventory",
                table: "InventoryScrapLine",
                column: "UnitOfMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryScrapLine_WarehouseId",
                schema: "Inventory",
                table: "InventoryScrapLine",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryScrapLine_WarehouseLocationId",
                schema: "Inventory",
                table: "InventoryScrapLine",
                column: "WarehouseLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_ScrapReason_ChartOfAccountId",
                schema: "Inventory",
                table: "ScrapReason",
                column: "ChartOfAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ScrapReason_Tenant_ID_CompanyId",
                schema: "Inventory",
                table: "ScrapReason",
                columns: new[] { "Tenant_ID", "CompanyId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryScrapLine",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "InventoryScrap",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "ScrapReason",
                schema: "Inventory");
        }
    }
}
