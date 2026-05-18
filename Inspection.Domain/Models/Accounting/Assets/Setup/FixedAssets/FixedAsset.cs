using Inspection.Domain.Enums.Accounting.Assets.Setup.AssetStatuss;
using Inspection.Domain.Enums.FixedAsset;
using Inspection.Domain.Models.Accounting.AccountingSetup;
using Inspection.Domain.Models.Accounting.AccountingSetup.CostUnits;
using Inspection.Domain.Models.Accounting.Assets.Setup.AssetCategories;
using Inspection.Domain.Models.Accounting.Assets.Setup.AssetGroups;
using Inspection.Domain.Models.Accounting.Assets.Setup.AssetLocations;
using Inspection.Domain.Models.Accounting.PR.MasterData.Suppliers;
using Inspection.Domain.Models.Contracting.Setup.Activitys;
using Inspection.Domain.Models.Contracting.Setup.BOQs;
using Inspection.Domain.Models.Contracting.Setup.CostCodes;
using Inspection.Domain.Models.Contracting.Setup.SubcontractBOQs;
using Inspection.Domain.Models.Contracting.Setup.WBSs;
using Inspection.Domain.Models.HRManagement.Departments;
using Inspection.Domain.Models.HRManagement.Employees;
using Inspection.Domain.Models.Manufacturing.Setup.ProductionOrder;
using Inspection.Domain.Models.MenuManagement;
using Inspection.Domain.Models.SystemConfigurations.Currencies;
using Inspection.Domain.Models.SystemConfigurations.Operations;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.Accounting.Assets.Setup.FixedAssets
{
    public class FixedAsset : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; private set; }

        public Series? Series { get; set; }
        public long? SeriesId { get; set; }
        public int RunningNumber { get; set; }

        public string Tenant_ID { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Name { get; private set; } = string.Empty;

        public long CompanyId { get; private set; }

        public long AssetCategoryId { get; private set; }
        public AssetCategory AssetCategory { get; private set; } = null!;

        public long? AssetGroupId { get; private set; }
        public AssetGroup? AssetGroup { get; private set; }
        public long? AssetLocationId { get; private set; }
        public AssetLocation? AssetLocation { get; private set; }

        public AssetStatusEnum AssetStatusEnum { get; private set; }

        public DateTime AcquisitionDate { get; private set; }

        public DateTime? CapitalizationDate { get; private set; }

        public decimal AcquisitionCost { get; private set; }
        public decimal ResidualValue { get; private set; }
        public int UsefulLifeMonths { get; private set; }

        public DepreciationMethod DepreciationMethod { get; private set; }
        public DateTime DepreciationStartDate { get; private set; }

        public decimal? EstimatedUnits { get; private set; }

        public long CurrencyId { get; private set; }
        public Currency Currency { get; private set; } = null!;

        public long? SupplierId { get; private set; }
        public Supplier? Supplier { get; private set; }


        public string? SerialNumber { get; private set; }
        public string? BarcodeValue { get; private set; }
        public string? ModelNumber { get; private set; }
        public string? Brand { get; private set; }

        public DateTime? WarrantyStartDate { get; private set; }
        public DateTime? WarrantyEndDate { get; private set; }

        public string? InsurancePolicyNo { get; private set; }
        public DateTime? InsuranceStartDate { get; private set; }
        public DateTime? InsuranceEndDate { get; private set; }

        public decimal? InsuranceValue { get; private set; }

        public long? CurrentCustodyEmployeeId { get; private set; }
        public Employee? CurrentCustodyEmployee { get; private set; }

        public long? CurrentCustodyDeptId { get; private set; }
        public Department? CurrentCustodyDept { get; private set; }

        public bool IsCapitalized { get; private set; }
        public bool IsFullyDepreciated { get; private set; }
        public decimal AccumulatedDepreciation { get; private set; }
        public decimal NetBookValue { get; private set; }

        public string? Notes { get; private set; }

        public long? CostCenterId { get; private set; }
        public CostCenter? CostCenter { get; private set; }

        public long? CostUnitId { get; private set; }
        public CostUnit? CostUnit { get; private set; }

        public long? OperationId { get; private set; }
        public Operation? Operation { get; private set; }

        public long? WBSId { get; private set; }
        public WBS? WBS { get; private set; }

        public long? CostCodeId { get; private set; }
        public CostCode? CostCode { get; private set; }

        public long? ActivityId { get; private set; }
        public Activity? Activity { get; private set; }

        public long? BOQLineId { get; private set; }
        public BOQLine? BOQLine { get; private set; }

        public long? SubcontractBOQId { get; private set; }
        public SubcontractBOQ? SubcontractBOQ { get; private set; }

        public long? ProductionOrderId { get; private set; }
        public ProductionOrder? ProductionOrder { get; private set; }



        public bool Acquired { get; private set; }
        public decimal TotalCost { get; private set; }
        public decimal TotalDepreciation { get; private set; }
        public long? MaintenanceSupplierId { get; private set; }
        public Supplier? MaintenanceSupplier { get; private set; }
        public DateTime? NextServiceDate { get; private set; }
        public DateTime? WarrantyDate { get; private set; }
        public bool UnderMaintenance { get; private set; }

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}