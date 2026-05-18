using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitAssetCostody : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssetCustody",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenant_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    DocumentNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DocumentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DocumentStatus = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetCustody", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssetCustodyLine",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetCustodyId = table.Column<long>(type: "bigint", maxLength: 50, nullable: false),
                    FixedAssetId = table.Column<long>(type: "bigint", nullable: false),
                    CustodyType = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    FromEmployeeId = table.Column<long>(type: "bigint", nullable: true),
                    ToEmployeeId = table.Column<long>(type: "bigint", nullable: true),
                    FromOperationId = table.Column<long>(type: "bigint", nullable: true),
                    ToOperationId = table.Column<long>(type: "bigint", nullable: true),
                    FromCostCenterId = table.Column<long>(type: "bigint", nullable: true),
                    ToCostCenterId = table.Column<long>(type: "bigint", nullable: true),
                    FromCostCodeId = table.Column<long>(type: "bigint", nullable: true),
                    ToCostCodeId = table.Column<long>(type: "bigint", nullable: true),
                    CustodyStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustodyEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HandoverDocumentUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsAcknowledged = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    AcknowledgedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DocumentStatus = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AssetCustodyId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetCustodyLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetCustodyLine_AssetCustody_AssetCustodyId",
                        column: x => x.AssetCustodyId,
                        principalSchema: "Accounting",
                        principalTable: "AssetCustody",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetCustodyLine_AssetCustody_AssetCustodyId1",
                        column: x => x.AssetCustodyId1,
                        principalSchema: "Accounting",
                        principalTable: "AssetCustody",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AssetCustodyLine_CostCenter_FromCostCenterId",
                        column: x => x.FromCostCenterId,
                        principalSchema: "Accounting",
                        principalTable: "CostCenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetCustodyLine_CostCenter_ToCostCenterId",
                        column: x => x.ToCostCenterId,
                        principalSchema: "Accounting",
                        principalTable: "CostCenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetCustodyLine_CostCode_FromCostCenterId",
                        column: x => x.FromCostCenterId,
                        principalSchema: "Contracting",
                        principalTable: "CostCode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetCustodyLine_CostCode_ToCostCodeId",
                        column: x => x.ToCostCodeId,
                        principalSchema: "Contracting",
                        principalTable: "CostCode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetCustodyLine_Employee_FromEmployeeId",
                        column: x => x.FromEmployeeId,
                        principalSchema: "HR",
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AssetCustodyLine_Employee_ToEmployeeId",
                        column: x => x.ToEmployeeId,
                        principalSchema: "HR",
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetCustodyLine_Operation_FromOperationId",
                        column: x => x.FromOperationId,
                        principalSchema: "Sec",
                        principalTable: "Operation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetCustodyLine_Operation_ToOperationId",
                        column: x => x.ToOperationId,
                        principalSchema: "Sec",
                        principalTable: "Operation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductionOrder_OperationId",
                schema: "Manufacturing",
                table: "ProductionOrder",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetCustody_Tenant_ID_CompanyId_DocumentNumber",
                schema: "Accounting",
                table: "AssetCustody",
                columns: new[] { "Tenant_ID", "CompanyId", "DocumentNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssetCustodyLine_AssetCustodyId",
                schema: "Accounting",
                table: "AssetCustodyLine",
                column: "AssetCustodyId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetCustodyLine_AssetCustodyId1",
                schema: "Accounting",
                table: "AssetCustodyLine",
                column: "AssetCustodyId1");

            migrationBuilder.CreateIndex(
                name: "IX_AssetCustodyLine_FromCostCenterId",
                schema: "Accounting",
                table: "AssetCustodyLine",
                column: "FromCostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetCustodyLine_FromEmployeeId",
                schema: "Accounting",
                table: "AssetCustodyLine",
                column: "FromEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetCustodyLine_FromOperationId",
                schema: "Accounting",
                table: "AssetCustodyLine",
                column: "FromOperationId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetCustodyLine_ToCostCenterId",
                schema: "Accounting",
                table: "AssetCustodyLine",
                column: "ToCostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetCustodyLine_ToCostCodeId",
                schema: "Accounting",
                table: "AssetCustodyLine",
                column: "ToCostCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetCustodyLine_ToEmployeeId",
                schema: "Accounting",
                table: "AssetCustodyLine",
                column: "ToEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetCustodyLine_ToOperationId",
                schema: "Accounting",
                table: "AssetCustodyLine",
                column: "ToOperationId");


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductionOrder_Operation_OperationId",
                schema: "Manufacturing",
                table: "ProductionOrder");

            migrationBuilder.DropTable(
                name: "AssetCustodyLine",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "AssetCustody",
                schema: "Accounting");

            migrationBuilder.DropIndex(
                name: "IX_ProductionOrder_OperationId",
                schema: "Manufacturing",
                table: "ProductionOrder");
        }
    }
}
