using Inspection.Domain.Enums.Accounting.Assets.Setup.AssetStatuss;
using Inspection.Domain.Enums.FixedAsset;

namespace Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.FixedAssetDTOs
{
    public class FixedAssetUpdateDto
    {
        public long Id { get; set; }


        public string Name { get; set; } = string.Empty;

        public long CompanyId { get; set; }

        public long AssetCategoryId { get; set; }

        public long? AssetGroupId { get; set; }

        public long? AssetLocationId { get; set; }

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

        public long? SupplierId { get; set; }


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
        public long? CurrentCustodyDeptId { get; set; }

        public bool IsCapitalized { get; set; }
        public bool IsFullyDepreciated { get; set; }
        public decimal AccumulatedDepreciation { get; set; }
        public decimal NetBookValue { get; set; }

        public string? Notes { get; set; }

        public long? CostCenterId { get; set; }
        public long? CostUnitId { get; set; }
        public long? OperationId { get; set; }
        public long? WBSId { get; set; }
        public long? CostCodeId { get; set; }
        public long? ActivityId { get; set; }
        public long? BOQLineId { get; set; }
        public long? SubcontractBOQId { get; set; }
        public long? ProductionOrderId { get; set; }


        public bool Acquired { get; set; }
        public decimal TotalCost { get; set; }
        public decimal TotalDepreciation { get; set; }
        public long? MaintenanceSupplierId { get; set; }
        public DateTime? NextServiceDate { get; set; }
        public DateTime? WarrantyDate { get; set; }
        public bool UnderMaintenance { get; set; }

    }
}