using Inspection.Domain.Enums.Accounting.Assets.Setup.AssetStatuss;
using Inspection.Domain.Enums.FixedAsset;

namespace Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.FixedAssetDTOs
{
    public class FixedAssetReturnSearchDto
    {
        public long Id { get; set; }

        public long? SeriesId { get; set; }
        public int RunningNumber { get; set; }

        public string Tenant_ID { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public long CompanyId { get; set; }

        public long AssetCategoryId { get; set; }
        public string AssetCategoryCode { get; set; } = null!;
        public string AssetCategoryName { get; set; } = null!;

        public long? AssetGroupId { get; set; }
        public string? AssetGroupName { get; set; }
        public string? AssetGroupCode { get; set; }

        public long? AssetLocationId { get; set; }
        public string? AssetLocationName { get; set; }
        public string? AssetLocationCode { get; set; }

        public AssetStatusEnum AssetStatusEnum { get; set; }

        public DateTime AcquisitionDate { get; set; }

        public DateTime? CapitalizationDate { get; set; }

        public decimal AcquisitionCost { get; set; }
        public decimal ResidualValue { get; set; }
        public int UsefulLifeMonths { get; set; }

        public DepreciationMethod DepreciationMethod { get; set; }
        public DateTime DepreciationStartDate { get; set; }

        public decimal? EstimatedUnits { get; set; }

        public long CurrencyId { get; set; }
        public string CurrencyName { get; set; } = null!;
        public string CurrencyCode { get; set; } = null!;

        public long? SupplierId { get; set; }
        public string? SupplierName { get; set; }
        public string? SupplierCode { get; set; }

        public string? SerialNumber { get; set; }
        public string? BarcodeValue { get; set; }
        public string? ModelNumber { get; set; }
        public string? Brand { get; set; }

        public DateTime? WarrantyStartDate { get; set; }
        public DateTime? WarrantyEndDate { get; set; }

        public string? InsurancePolicyNo { get; set; }
        public DateTime? InsuranceStartDate { get; set; }
        public DateTime? InsuranceEndDate { get; set; }

        public decimal? InsuranceValue { get; set; }

        public long? CurrentCustodyEmployeeId { get; set; }
        public string? CurrentCustodyEmployeeName { get; set; }
        public string? CurrentCustodyEmployeeCode { get; set; }

        public long? CurrentCustodyDeptId { get; set; }
        public string? CurrentCustodyDeptName { get; set; }

        public bool IsCapitalized { get; set; }
        public bool IsFullyDepreciated { get; set; }
        public decimal AccumulatedDepreciation { get; set; }
        public decimal NetBookValue { get; set; }

        public string? Notes { get; set; }

        public long? CostCenterId { get; set; }
        public string? CostCenterName { get; set; }
        public string? CostCenterCode { get; set; }

        public long? CostUnitId { get; set; }
        public string? CostUnitCode { get; set; }
        public string? CostUnitName { get; set; }

        public long? OperationId { get; set; }
        public string? OperationName { get; set; }
        public string? OperationCode { get; set; }

        public long? WBSId { get; set; }
        public string? WBSName { get; set; }
        public string? WBSCode { get; set; }

        public long? CostCodeId { get; set; }
        public string? CostCodeName { get; set; }
        public string? CostCodeValue { get; set; }

        public long? ActivityId { get; set; }
        public string? ActivityName { get; set; }
        public string? ActivityCode { get; set; }

        public long? BOQLineId { get; set; }
        public string? BOQLineName { get; set; }
        public string? BOQLineCode { get; set; }

        public long? SubcontractBOQId { get; set; }
        public string? SubcontractBOQCode { get; set; }

        public long? ProductionOrderId { get; set; }
        public string? ProductionOrderCode { get; set; }

        public bool Acquired { get; set; }
        public decimal TotalCost { get; set; }
        public decimal TotalDepreciation { get; set; }

        public long? MaintenanceSupplierId { get; set; }
        public string? MaintenanceSupplierName { get; set; }
        public string? MaintenanceSupplierCode { get; set; }

        public DateTime? NextServiceDate { get; set; }
        public DateTime? WarrantyDate { get; set; }
        public bool UnderMaintenance { get; set; }

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }

        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}
