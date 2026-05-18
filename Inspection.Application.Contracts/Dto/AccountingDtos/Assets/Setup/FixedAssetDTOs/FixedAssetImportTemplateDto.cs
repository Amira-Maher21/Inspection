using Inspection.Domain.Enums.Accounting.Assets.Setup.AssetStatuss;
using Inspection.Domain.Enums.FixedAsset;

namespace Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.FixedAssetDTOs
{
    public class FixedAssetImportTemplateDto
    {
        //public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        // ===== Lookups instead of FK =====
        public string AssetCategoryCode { get; set; } = string.Empty;
        public string AssetGroupCode { get; set; } = string.Empty;
        public string AssetLocationCode { get; set; } = string.Empty;

        public string CurrencyCode { get; set; } = string.Empty;
        public string SupplierCode { get; set; } = string.Empty;

        public string EmployeeCode { get; set; } = string.Empty;
        public string DepartmentCode { get; set; } = string.Empty;

        public string CostCenterCode { get; set; } = string.Empty;
        public string CostUnitCode { get; set; } = string.Empty;

        public string OperationCode { get; set; } = string.Empty;
        public string WBSCode { get; set; } = string.Empty;
        public string CostCodeCode { get; set; } = string.Empty;
        public string ActivityCode { get; set; } = string.Empty;

        public string BOQLineCode { get; set; } = string.Empty;
        public string SubcontractBOQCode { get; set; } = string.Empty;
        public string ProductionOrderCode { get; set; } = string.Empty;

        // ===== Main Data =====

        public DateTime AcquisitionDate { get; set; }
        public DateTime? CapitalizationDate { get; set; }

        public decimal AcquisitionCost { get; set; }
        public decimal ResidualValue { get; set; }
        public int UsefulLifeMonths { get; set; }

        public DepreciationMethod DepreciationMethod { get; set; }




        public AssetStatusEnum AssetStatusEnum { get; set; }

        public decimal? EstimatedUnits { get; set; }

        // Identification
        public string SerialNumber { get; set; }
        public string BarcodeValue { get; set; }
        public string ModelNumber { get; set; }
        public string Brand { get; set; }

        // Warranty
        public DateTime? WarrantyStartDate { get; set; }
        public DateTime? WarrantyEndDate { get; set; }

        // Insurance
        public string? InsurancePolicyNo { get; set; }
        public DateTime? InsuranceStartDate { get; set; }
        public DateTime? InsuranceEndDate { get; set; }
        public decimal? InsuranceValue { get; set; }
        public long CompanyId { get; set; }
        public DateTime DepreciationStartDate { get; set; }
        // Financial status
        public bool IsCapitalized { get; set; }
        public bool IsFullyDepreciated { get; set; }
        public decimal AccumulatedDepreciation { get; set; }
        public decimal NetBookValue { get; set; }

        public string Notes { get; set; }

        public bool Acquired { get; set; }
        public decimal TotalCost { get; set; }
        public decimal TotalDepreciation { get; set; }
        public long? MaintenanceSupplierCode { get; set; }
        public DateTime? NextServiceDate { get; set; }
        public DateTime? WarrantyDate { get; set; }
        public bool UnderMaintenance { get; set; }
    }
}