using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixedAssetR : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Disabled",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.AddColumn<decimal>(
                name: "AccumulatedDepreciation",
                schema: "Accounting",
                table: "FixedAsset",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<long>(
                name: "ActivityId",
                schema: "Accounting",
                table: "FixedAsset",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "AssetGroupId",
                schema: "Accounting",
                table: "FixedAsset",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "AssetLocationId",
                schema: "Accounting",
                table: "FixedAsset",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AssetStatusEnum",
                schema: "Accounting",
                table: "FixedAsset",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "BOQLineId",
                schema: "Accounting",
                table: "FixedAsset",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BarcodeValue",
                schema: "Accounting",
                table: "FixedAsset",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                schema: "Accounting",
                table: "FixedAsset",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CompanyId",
                schema: "Accounting",
                table: "FixedAsset",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CostCenterId",
                schema: "Accounting",
                table: "FixedAsset",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CostCodeId",
                schema: "Accounting",
                table: "FixedAsset",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CostUnitId",
                schema: "Accounting",
                table: "FixedAsset",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CurrencyId",
                schema: "Accounting",
                table: "FixedAsset",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CurrentCustodyDeptId",
                schema: "Accounting",
                table: "FixedAsset",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CurrentCustodyEmployeeId",
                schema: "Accounting",
                table: "FixedAsset",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DepreciationStartDate",
                schema: "Accounting",
                table: "FixedAsset",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "EstimatedUnits",
                schema: "Accounting",
                table: "FixedAsset",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InsuranceEndDate",
                schema: "Accounting",
                table: "FixedAsset",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsurancePolicyNo",
                schema: "Accounting",
                table: "FixedAsset",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InsuranceStartDate",
                schema: "Accounting",
                table: "FixedAsset",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "InsuranceValue",
                schema: "Accounting",
                table: "FixedAsset",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCapitalized",
                schema: "Accounting",
                table: "FixedAsset",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsFullyDepreciated",
                schema: "Accounting",
                table: "FixedAsset",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModelNumber",
                schema: "Accounting",
                table: "FixedAsset",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "NetBookValue",
                schema: "Accounting",
                table: "FixedAsset",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                schema: "Accounting",
                table: "FixedAsset",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "OperationId",
                schema: "Accounting",
                table: "FixedAsset",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ProductionOrderId",
                schema: "Accounting",
                table: "FixedAsset",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SerialNumber",
                schema: "Accounting",
                table: "FixedAsset",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SubcontractBOQId",
                schema: "Accounting",
                table: "FixedAsset",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SupplierId",
                schema: "Accounting",
                table: "FixedAsset",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "WBSId",
                schema: "Accounting",
                table: "FixedAsset",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "WarrantyEndDate",
                schema: "Accounting",
                table: "FixedAsset",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "WarrantyStartDate",
                schema: "Accounting",
                table: "FixedAsset",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FixedAsset_ActivityId",
                schema: "Accounting",
                table: "FixedAsset",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_FixedAsset_AssetGroupId",
                schema: "Accounting",
                table: "FixedAsset",
                column: "AssetGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_FixedAsset_AssetLocationId",
                schema: "Accounting",
                table: "FixedAsset",
                column: "AssetLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_FixedAsset_BOQLineId",
                schema: "Accounting",
                table: "FixedAsset",
                column: "BOQLineId");

            migrationBuilder.CreateIndex(
                name: "IX_FixedAsset_CostCenterId",
                schema: "Accounting",
                table: "FixedAsset",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_FixedAsset_CostCodeId",
                schema: "Accounting",
                table: "FixedAsset",
                column: "CostCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_FixedAsset_CostUnitId",
                schema: "Accounting",
                table: "FixedAsset",
                column: "CostUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_FixedAsset_CurrencyId",
                schema: "Accounting",
                table: "FixedAsset",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_FixedAsset_CurrentCustodyDeptId",
                schema: "Accounting",
                table: "FixedAsset",
                column: "CurrentCustodyDeptId");

            migrationBuilder.CreateIndex(
                name: "IX_FixedAsset_CurrentCustodyEmployeeId",
                schema: "Accounting",
                table: "FixedAsset",
                column: "CurrentCustodyEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_FixedAsset_OperationId",
                schema: "Accounting",
                table: "FixedAsset",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_FixedAsset_ProductionOrderId",
                schema: "Accounting",
                table: "FixedAsset",
                column: "ProductionOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_FixedAsset_SubcontractBOQId",
                schema: "Accounting",
                table: "FixedAsset",
                column: "SubcontractBOQId");

            migrationBuilder.CreateIndex(
                name: "IX_FixedAsset_SupplierId",
                schema: "Accounting",
                table: "FixedAsset",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_FixedAsset_WBSId",
                schema: "Accounting",
                table: "FixedAsset",
                column: "WBSId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetComponent_FixedAssetId",
                schema: "Accounting",
                table: "AssetComponent",
                column: "FixedAssetId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetComponent_FixedAsset_FixedAssetId",
                schema: "Accounting",
                table: "AssetComponent",
                column: "FixedAssetId",
                principalSchema: "Accounting",
                principalTable: "FixedAsset",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FixedAsset_Activity_ActivityId",
                schema: "Accounting",
                table: "FixedAsset",
                column: "ActivityId",
                principalSchema: "Contracting",
                principalTable: "Activity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FixedAsset_AssetGroup_AssetGroupId",
                schema: "Accounting",
                table: "FixedAsset",
                column: "AssetGroupId",
                principalSchema: "Accounting",
                principalTable: "AssetGroup",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FixedAsset_AssetLocation_AssetLocationId",
                schema: "Accounting",
                table: "FixedAsset",
                column: "AssetLocationId",
                principalSchema: "Accounting",
                principalTable: "AssetLocation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FixedAsset_BOQLine_BOQLineId",
                schema: "Accounting",
                table: "FixedAsset",
                column: "BOQLineId",
                principalSchema: "Contracting",
                principalTable: "BOQLine",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FixedAsset_CostCenter_CostCenterId",
                schema: "Accounting",
                table: "FixedAsset",
                column: "CostCenterId",
                principalSchema: "Accounting",
                principalTable: "CostCenter",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FixedAsset_CostCode_CostCodeId",
                schema: "Accounting",
                table: "FixedAsset",
                column: "CostCodeId",
                principalSchema: "Contracting",
                principalTable: "CostCode",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FixedAsset_CostUnit_CostUnitId",
                schema: "Accounting",
                table: "FixedAsset",
                column: "CostUnitId",
                principalSchema: "Accounting",
                principalTable: "CostUnit",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FixedAsset_Currency_CurrencyId",
                schema: "Accounting",
                table: "FixedAsset",
                column: "CurrencyId",
                principalSchema: "Sec",
                principalTable: "Currency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FixedAsset_Department_CurrentCustodyDeptId",
                schema: "Accounting",
                table: "FixedAsset",
                column: "CurrentCustodyDeptId",
                principalSchema: "HR",
                principalTable: "Department",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FixedAsset_Employee_CurrentCustodyEmployeeId",
                schema: "Accounting",
                table: "FixedAsset",
                column: "CurrentCustodyEmployeeId",
                principalSchema: "HR",
                principalTable: "Employee",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FixedAsset_Operation_OperationId",
                schema: "Accounting",
                table: "FixedAsset",
                column: "OperationId",
                principalSchema: "Sec",
                principalTable: "Operation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FixedAsset_ProductionOrder_ProductionOrderId",
                schema: "Accounting",
                table: "FixedAsset",
                column: "ProductionOrderId",
                principalSchema: "Manufacturing",
                principalTable: "ProductionOrder",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FixedAsset_SubcontractBOQ_SubcontractBOQId",
                schema: "Accounting",
                table: "FixedAsset",
                column: "SubcontractBOQId",
                principalSchema: "Contracting",
                principalTable: "SubcontractBOQ",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FixedAsset_Supplier_SupplierId",
                schema: "Accounting",
                table: "FixedAsset",
                column: "SupplierId",
                principalSchema: "Accounting",
                principalTable: "Supplier",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FixedAsset_WBS_WBSId",
                schema: "Accounting",
                table: "FixedAsset",
                column: "WBSId",
                principalSchema: "Contracting",
                principalTable: "WBS",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetComponent_FixedAsset_FixedAssetId",
                schema: "Accounting",
                table: "AssetComponent");

            migrationBuilder.DropForeignKey(
                name: "FK_FixedAsset_Activity_ActivityId",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropForeignKey(
                name: "FK_FixedAsset_AssetGroup_AssetGroupId",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropForeignKey(
                name: "FK_FixedAsset_AssetLocation_AssetLocationId",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropForeignKey(
                name: "FK_FixedAsset_BOQLine_BOQLineId",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropForeignKey(
                name: "FK_FixedAsset_CostCenter_CostCenterId",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropForeignKey(
                name: "FK_FixedAsset_CostCode_CostCodeId",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropForeignKey(
                name: "FK_FixedAsset_CostUnit_CostUnitId",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropForeignKey(
                name: "FK_FixedAsset_Currency_CurrencyId",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropForeignKey(
                name: "FK_FixedAsset_Department_CurrentCustodyDeptId",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropForeignKey(
                name: "FK_FixedAsset_Employee_CurrentCustodyEmployeeId",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropForeignKey(
                name: "FK_FixedAsset_Operation_OperationId",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropForeignKey(
                name: "FK_FixedAsset_ProductionOrder_ProductionOrderId",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropForeignKey(
                name: "FK_FixedAsset_SubcontractBOQ_SubcontractBOQId",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropForeignKey(
                name: "FK_FixedAsset_Supplier_SupplierId",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropForeignKey(
                name: "FK_FixedAsset_WBS_WBSId",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropIndex(
                name: "IX_FixedAsset_ActivityId",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropIndex(
                name: "IX_FixedAsset_AssetGroupId",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropIndex(
                name: "IX_FixedAsset_AssetLocationId",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropIndex(
                name: "IX_FixedAsset_BOQLineId",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropIndex(
                name: "IX_FixedAsset_CostCenterId",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropIndex(
                name: "IX_FixedAsset_CostCodeId",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropIndex(
                name: "IX_FixedAsset_CostUnitId",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropIndex(
                name: "IX_FixedAsset_CurrencyId",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropIndex(
                name: "IX_FixedAsset_CurrentCustodyDeptId",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropIndex(
                name: "IX_FixedAsset_CurrentCustodyEmployeeId",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropIndex(
                name: "IX_FixedAsset_OperationId",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropIndex(
                name: "IX_FixedAsset_ProductionOrderId",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropIndex(
                name: "IX_FixedAsset_SubcontractBOQId",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropIndex(
                name: "IX_FixedAsset_SupplierId",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropIndex(
                name: "IX_FixedAsset_WBSId",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropIndex(
                name: "IX_AssetComponent_FixedAssetId",
                schema: "Accounting",
                table: "AssetComponent");

            migrationBuilder.DropColumn(
                name: "AccumulatedDepreciation",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropColumn(
                name: "ActivityId",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropColumn(
                name: "AssetGroupId",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropColumn(
                name: "AssetLocationId",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropColumn(
                name: "AssetStatusEnum",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropColumn(
                name: "BOQLineId",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropColumn(
                name: "BarcodeValue",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropColumn(
                name: "Brand",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropColumn(
                name: "CostCenterId",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropColumn(
                name: "CostCodeId",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropColumn(
                name: "CostUnitId",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropColumn(
                name: "CurrentCustodyDeptId",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropColumn(
                name: "CurrentCustodyEmployeeId",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropColumn(
                name: "DepreciationStartDate",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropColumn(
                name: "EstimatedUnits",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropColumn(
                name: "InsuranceEndDate",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropColumn(
                name: "InsurancePolicyNo",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropColumn(
                name: "InsuranceStartDate",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropColumn(
                name: "InsuranceValue",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropColumn(
                name: "IsCapitalized",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropColumn(
                name: "IsFullyDepreciated",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropColumn(
                name: "ModelNumber",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropColumn(
                name: "NetBookValue",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropColumn(
                name: "Notes",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropColumn(
                name: "OperationId",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropColumn(
                name: "ProductionOrderId",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropColumn(
                name: "SerialNumber",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropColumn(
                name: "SubcontractBOQId",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropColumn(
                name: "WBSId",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropColumn(
                name: "WarrantyEndDate",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.DropColumn(
                name: "WarrantyStartDate",
                schema: "Accounting",
                table: "FixedAsset");

            migrationBuilder.AddColumn<bool>(
                name: "Disabled",
                schema: "Accounting",
                table: "FixedAsset",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
