using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitAssetMaintenance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssetMaintenance",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenant_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    BranchId = table.Column<long>(type: "bigint", nullable: false),
                    MaintenanceCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaintenanceType = table.Column<int>(type: "int", nullable: false),
                    FrequencyTypeId = table.Column<int>(type: "int", nullable: true),
                    FrequencyValue = table.Column<float>(type: "real", nullable: true),
                    MaintenanceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlannedStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PlannedEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SupplierId = table.Column<long>(type: "bigint", nullable: true),
                    Technician = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    TotalEstimatedCost = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    TotalActualCost = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    InspectionRequired = table.Column<bool>(type: "bit", nullable: false),
                    InspectionResult = table.Column<int>(type: "int", nullable: true),
                    CertificateNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DocumentStatus = table.Column<int>(type: "int", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    SeriesId = table.Column<long>(type: "bigint", nullable: true),
                    RunningNumber = table.Column<int>(type: "int", nullable: false),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetMaintenance", x => x.Id);
                    table.CheckConstraint("CK_AssetMaintenance_Costs", "[TotalEstimatedCost] IS NULL OR [TotalEstimatedCost] >= 0 AND [TotalActualCost] IS NULL OR [TotalActualCost] >= 0");
                    table.CheckConstraint("CK_AssetMaintenance_DocumentStatus", "[DocumentStatus] IN (1,2)");
                    table.CheckConstraint("CK_AssetMaintenance_FrequencyValue", "[FrequencyValue] IS NULL OR [FrequencyValue] > 0");
                    table.CheckConstraint("CK_AssetMaintenance_MaintenanceType", "[MaintenanceType] IN (1,2,3,4,5)");
                    table.ForeignKey(
                        name: "FK_AssetMaintenance_Branch_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "Accounting",
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetMaintenance_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalSchema: "Stt",
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetMaintenance_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalSchema: "Accounting",
                        principalTable: "Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssetMaintenanceLine",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetMaintenanceId = table.Column<long>(type: "bigint", nullable: false),
                    AssetId = table.Column<long>(type: "bigint", nullable: false),
                    WorkDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    MaintenanceActionType = table.Column<int>(type: "int", nullable: false),
                    DowntimeHours = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    EstimatedCost = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    ActualCost = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    IsCapitalizable = table.Column<bool>(type: "bit", nullable: false),
                    WBSId = table.Column<long>(type: "bigint", nullable: true),
                    ActivityId = table.Column<long>(type: "bigint", nullable: true),
                    BOQItemId = table.Column<long>(type: "bigint", nullable: true),
                    SubcontractBOQId = table.Column<long>(type: "bigint", nullable: true),
                    ProductionOrderId = table.Column<long>(type: "bigint", nullable: true),
                    CostCodeId = table.Column<long>(type: "bigint", nullable: true),
                    OperationId = table.Column<long>(type: "bigint", nullable: true),
                    CostCenterId = table.Column<long>(type: "bigint", nullable: true),
                    In_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    In_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mod_User = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mod_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AssetMaintenanceId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetMaintenanceLine", x => x.Id);
                    table.CheckConstraint("CK_AssetMaintenanceLine_ActualCost", "[ActualCost] IS NULL OR [ActualCost] >= 0");
                    table.CheckConstraint("CK_AssetMaintenanceLine_DowntimeHours", "[DowntimeHours] IS NULL OR [DowntimeHours] >= 0");
                    table.CheckConstraint("CK_AssetMaintenanceLine_EstimatedCost", "[EstimatedCost] IS NULL OR [EstimatedCost] >= 0");
                    table.ForeignKey(
                        name: "FK_AssetMaintenanceLine_Activity_ActivityId",
                        column: x => x.ActivityId,
                        principalSchema: "Contracting",
                        principalTable: "Activity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetMaintenanceLine_AssetMaintenance_AssetMaintenanceId",
                        column: x => x.AssetMaintenanceId,
                        principalSchema: "Accounting",
                        principalTable: "AssetMaintenance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetMaintenanceLine_AssetMaintenance_AssetMaintenanceId1",
                        column: x => x.AssetMaintenanceId1,
                        principalSchema: "Accounting",
                        principalTable: "AssetMaintenance",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AssetMaintenanceLine_BOQ_BOQItemId",
                        column: x => x.BOQItemId,
                        principalSchema: "Contracting",
                        principalTable: "BOQ",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetMaintenanceLine_CostCenter_CostCenterId",
                        column: x => x.CostCenterId,
                        principalSchema: "Accounting",
                        principalTable: "CostCenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetMaintenanceLine_CostCode_CostCodeId",
                        column: x => x.CostCodeId,
                        principalSchema: "Contracting",
                        principalTable: "CostCode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetMaintenanceLine_FixedAsset_AssetId",
                        column: x => x.AssetId,
                        principalSchema: "Accounting",
                        principalTable: "FixedAsset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetMaintenanceLine_Operation_OperationId",
                        column: x => x.OperationId,
                        principalSchema: "Sec",
                        principalTable: "Operation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetMaintenanceLine_ProductionOrder_ProductionOrderId",
                        column: x => x.ProductionOrderId,
                        principalSchema: "Manufacturing",
                        principalTable: "ProductionOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetMaintenanceLine_SubcontractBOQ_SubcontractBOQId",
                        column: x => x.SubcontractBOQId,
                        principalSchema: "Contracting",
                        principalTable: "SubcontractBOQ",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetMaintenanceLine_WBS_WBSId",
                        column: x => x.WBSId,
                        principalSchema: "Contracting",
                        principalTable: "WBS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssetMaintenance_BranchId",
                schema: "Accounting",
                table: "AssetMaintenance",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetMaintenance_SeriesId",
                schema: "Accounting",
                table: "AssetMaintenance",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetMaintenance_SupplierId",
                schema: "Accounting",
                table: "AssetMaintenance",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetMaintenance_Tenant_ID_CompanyId_BranchId_MaintenanceCode",
                schema: "Accounting",
                table: "AssetMaintenance",
                columns: new[] { "Tenant_ID", "CompanyId", "BranchId", "MaintenanceCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssetMaintenanceLine_ActivityId",
                schema: "Accounting",
                table: "AssetMaintenanceLine",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetMaintenanceLine_AssetId",
                schema: "Accounting",
                table: "AssetMaintenanceLine",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetMaintenanceLine_AssetMaintenanceId",
                schema: "Accounting",
                table: "AssetMaintenanceLine",
                column: "AssetMaintenanceId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetMaintenanceLine_AssetMaintenanceId1",
                schema: "Accounting",
                table: "AssetMaintenanceLine",
                column: "AssetMaintenanceId1");

            migrationBuilder.CreateIndex(
                name: "IX_AssetMaintenanceLine_BOQItemId",
                schema: "Accounting",
                table: "AssetMaintenanceLine",
                column: "BOQItemId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetMaintenanceLine_CostCenterId",
                schema: "Accounting",
                table: "AssetMaintenanceLine",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetMaintenanceLine_CostCodeId",
                schema: "Accounting",
                table: "AssetMaintenanceLine",
                column: "CostCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetMaintenanceLine_OperationId",
                schema: "Accounting",
                table: "AssetMaintenanceLine",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetMaintenanceLine_ProductionOrderId",
                schema: "Accounting",
                table: "AssetMaintenanceLine",
                column: "ProductionOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetMaintenanceLine_SubcontractBOQId",
                schema: "Accounting",
                table: "AssetMaintenanceLine",
                column: "SubcontractBOQId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetMaintenanceLine_WBSId",
                schema: "Accounting",
                table: "AssetMaintenanceLine",
                column: "WBSId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssetMaintenanceLine",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "AssetMaintenance",
                schema: "Accounting");
        }
    }
}
