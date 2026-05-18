using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RefactorInventoryOpeningBalanceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryOpeningBalance_Item_ItemId",
                schema: "Inventory",
                table: "InventoryOpeningBalance");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryOpeningBalance_UnitOfMeasure_UnitOfMeasureId",
                schema: "Inventory",
                table: "InventoryOpeningBalance");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryOpeningBalance_WarehouseLocation_WarehouseLocationId",
                schema: "Inventory",
                table: "InventoryOpeningBalance");

            migrationBuilder.DropIndex(
                name: "IX_InventoryOpeningBalance_ItemId",
                schema: "Inventory",
                table: "InventoryOpeningBalance");

            migrationBuilder.DropIndex(
                name: "IX_InventoryOpeningBalance_WarehouseLocationId",
                schema: "Inventory",
                table: "InventoryOpeningBalance");

            migrationBuilder.DropIndex(
                name: "UQ_InventoryOpeningBalance",
                schema: "Inventory",
                table: "InventoryOpeningBalance");

            migrationBuilder.DropColumn(
                name: "IsPosted",
                schema: "Inventory",
                table: "InventoryOpeningBalance");

            migrationBuilder.DropColumn(
                name: "ItemId",
                schema: "Inventory",
                table: "InventoryOpeningBalance");

            migrationBuilder.DropColumn(
                name: "OpeningQuantity",
                schema: "Inventory",
                table: "InventoryOpeningBalance");

            migrationBuilder.DropColumn(
                name: "OpeningUnitCost",
                schema: "Inventory",
                table: "InventoryOpeningBalance");

            migrationBuilder.DropColumn(
                name: "WarehouseLocationId",
                schema: "Inventory",
                table: "InventoryOpeningBalance");

            migrationBuilder.RenameColumn(
                name: "UnitOfMeasureId",
                schema: "Inventory",
                table: "InventoryOpeningBalance",
                newName: "CurrencyId");

            migrationBuilder.RenameColumn(
                name: "TotalOpeningCost",
                schema: "Inventory",
                table: "InventoryOpeningBalance",
                newName: "TotalValue");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryOpeningBalance_UnitOfMeasureId",
                schema: "Inventory",
                table: "InventoryOpeningBalance",
                newName: "IX_InventoryOpeningBalance_CurrencyId");

            migrationBuilder.AddColumn<int>(
                name: "Posting",
                schema: "Inventory",
                table: "InventoryOpeningBalance",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "YearEndCarryForward",
                schema: "Inventory",
                table: "InventoryOpeningBalance",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "InventoryOpeningBalanceLine",
                schema: "Inventory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventoryOpeningBalanceId = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    UnitCost = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    TotalCost = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SerialNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ItemId = table.Column<long>(type: "bigint", nullable: false),
                    WarehouseLocationId = table.Column<long>(type: "bigint", nullable: true),
                    BatchId = table.Column<long>(type: "bigint", nullable: true),
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
                    table.PrimaryKey("PK_InventoryOpeningBalanceLine", x => x.Id);
                    table.CheckConstraint("CK_InventoryOpeningBalanceLine_SerialQty", "[SerialNumber] IS NULL OR [Quantity] = 1");
                    table.ForeignKey(
                        name: "FK_InventoryOpeningBalanceLine_Batch_BatchId",
                        column: x => x.BatchId,
                        principalSchema: "Inventory",
                        principalTable: "Batch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryOpeningBalanceLine_CostCenter_CostCenterId",
                        column: x => x.CostCenterId,
                        principalSchema: "Accounting",
                        principalTable: "CostCenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryOpeningBalanceLine_CostUnit_CostUnitId",
                        column: x => x.CostUnitId,
                        principalSchema: "Accounting",
                        principalTable: "CostUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryOpeningBalanceLine_InventoryOpeningBalance_InventoryOpeningBalanceId",
                        column: x => x.InventoryOpeningBalanceId,
                        principalSchema: "Inventory",
                        principalTable: "InventoryOpeningBalance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryOpeningBalanceLine_Item_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "Inventory",
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryOpeningBalanceLine_Operation_OperationId",
                        column: x => x.OperationId,
                        principalSchema: "Sec",
                        principalTable: "Operation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryOpeningBalanceLine_WarehouseLocation_WarehouseLocationId",
                        column: x => x.WarehouseLocationId,
                        principalSchema: "Inventory",
                        principalTable: "WarehouseLocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryOpeningBalance_Tenant_ID_CompanyId_WarehouseId_FiscalYearId",
                schema: "Inventory",
                table: "InventoryOpeningBalance",
                columns: new[] { "Tenant_ID", "CompanyId", "WarehouseId", "FiscalYearId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InventoryOpeningBalanceLine_BatchId",
                schema: "Inventory",
                table: "InventoryOpeningBalanceLine",
                column: "BatchId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryOpeningBalanceLine_CostCenterId",
                schema: "Inventory",
                table: "InventoryOpeningBalanceLine",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryOpeningBalanceLine_CostUnitId",
                schema: "Inventory",
                table: "InventoryOpeningBalanceLine",
                column: "CostUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryOpeningBalanceLine_InventoryOpeningBalanceId",
                schema: "Inventory",
                table: "InventoryOpeningBalanceLine",
                column: "InventoryOpeningBalanceId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryOpeningBalanceLine_InventoryOpeningBalanceId_ItemId_WarehouseLocationId",
                schema: "Inventory",
                table: "InventoryOpeningBalanceLine",
                columns: new[] { "InventoryOpeningBalanceId", "ItemId", "WarehouseLocationId" },
                unique: true,
                filter: "[WarehouseLocationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryOpeningBalanceLine_ItemId",
                schema: "Inventory",
                table: "InventoryOpeningBalanceLine",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryOpeningBalanceLine_OperationId",
                schema: "Inventory",
                table: "InventoryOpeningBalanceLine",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryOpeningBalanceLine_WarehouseLocationId",
                schema: "Inventory",
                table: "InventoryOpeningBalanceLine",
                column: "WarehouseLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryOpeningBalance_Currency_CurrencyId",
                schema: "Inventory",
                table: "InventoryOpeningBalance",
                column: "CurrencyId",
                principalSchema: "Sec",
                principalTable: "Currency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryOpeningBalance_Currency_CurrencyId",
                schema: "Inventory",
                table: "InventoryOpeningBalance");

            migrationBuilder.DropTable(
                name: "InventoryOpeningBalanceLine",
                schema: "Inventory");

            migrationBuilder.DropIndex(
                name: "IX_InventoryOpeningBalance_Tenant_ID_CompanyId_WarehouseId_FiscalYearId",
                schema: "Inventory",
                table: "InventoryOpeningBalance");

            migrationBuilder.DropColumn(
                name: "Posting",
                schema: "Inventory",
                table: "InventoryOpeningBalance");

            migrationBuilder.DropColumn(
                name: "YearEndCarryForward",
                schema: "Inventory",
                table: "InventoryOpeningBalance");

            migrationBuilder.RenameColumn(
                name: "TotalValue",
                schema: "Inventory",
                table: "InventoryOpeningBalance",
                newName: "TotalOpeningCost");

            migrationBuilder.RenameColumn(
                name: "CurrencyId",
                schema: "Inventory",
                table: "InventoryOpeningBalance",
                newName: "UnitOfMeasureId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryOpeningBalance_CurrencyId",
                schema: "Inventory",
                table: "InventoryOpeningBalance",
                newName: "IX_InventoryOpeningBalance_UnitOfMeasureId");

            migrationBuilder.AddColumn<bool>(
                name: "IsPosted",
                schema: "Inventory",
                table: "InventoryOpeningBalance",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "ItemId",
                schema: "Inventory",
                table: "InventoryOpeningBalance",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<decimal>(
                name: "OpeningQuantity",
                schema: "Inventory",
                table: "InventoryOpeningBalance",
                type: "decimal(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "OpeningUnitCost",
                schema: "Inventory",
                table: "InventoryOpeningBalance",
                type: "decimal(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<long>(
                name: "WarehouseLocationId",
                schema: "Inventory",
                table: "InventoryOpeningBalance",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InventoryOpeningBalance_ItemId",
                schema: "Inventory",
                table: "InventoryOpeningBalance",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryOpeningBalance_WarehouseLocationId",
                schema: "Inventory",
                table: "InventoryOpeningBalance",
                column: "WarehouseLocationId");

            migrationBuilder.CreateIndex(
                name: "UQ_InventoryOpeningBalance",
                schema: "Inventory",
                table: "InventoryOpeningBalance",
                columns: new[] { "CompanyId", "FiscalYearId", "WarehouseId", "ItemId", "WarehouseLocationId" },
                unique: true,
                filter: "[WarehouseLocationId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryOpeningBalance_Item_ItemId",
                schema: "Inventory",
                table: "InventoryOpeningBalance",
                column: "ItemId",
                principalSchema: "Inventory",
                principalTable: "Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryOpeningBalance_UnitOfMeasure_UnitOfMeasureId",
                schema: "Inventory",
                table: "InventoryOpeningBalance",
                column: "UnitOfMeasureId",
                principalSchema: "Inventory",
                principalTable: "UnitOfMeasure",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryOpeningBalance_WarehouseLocation_WarehouseLocationId",
                schema: "Inventory",
                table: "InventoryOpeningBalance",
                column: "WarehouseLocationId",
                principalSchema: "Inventory",
                principalTable: "WarehouseLocation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
