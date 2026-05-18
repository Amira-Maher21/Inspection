using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addProductionOrderEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Manufacturing");

            migrationBuilder.CreateTable(
                name: "ProductionOrder",
                schema: "Manufacturing",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenant_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompanyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OperationId = table.Column<long>(type: "bigint", nullable: false),
                    OrderNumber = table.Column<long>(type: "bigint", maxLength: 50, nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DocumentStatus = table.Column<int>(type: "int", nullable: false),
                    ExpectedAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionOrder", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductionOrderLine",
                schema: "Manufacturing",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductionOrderId = table.Column<long>(type: "bigint", nullable: false),
                    ItemId = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    UnitRate = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    WBSId = table.Column<long>(type: "bigint", nullable: false),
                    CostCodeId = table.Column<long>(type: "bigint", nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionOrderLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductionOrderLine_Item_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "Inventory",
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductionOrderLine_ProductionOrder_ProductionOrderId",
                        column: x => x.ProductionOrderId,
                        principalSchema: "Manufacturing",
                        principalTable: "ProductionOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductionOrder_Tenant_ID_CompanyId_OrderNumber",
                schema: "Manufacturing",
                table: "ProductionOrder",
                columns: new[] { "Tenant_ID", "CompanyId", "OrderNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductionOrderLine_ItemId",
                schema: "Manufacturing",
                table: "ProductionOrderLine",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionOrderLine_ProductionOrderId",
                schema: "Manufacturing",
                table: "ProductionOrderLine",
                column: "ProductionOrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductionOrderLine",
                schema: "Manufacturing");

            migrationBuilder.DropTable(
                name: "ProductionOrder",
                schema: "Manufacturing");
        }
    }
}
