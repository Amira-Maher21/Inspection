using Inspection.Domain.Enums.Accounting.Assets.Setup.AssetCustody;
using Inspection.Domain.Models.Accounting.AccountingSetup;
using Inspection.Domain.Models.Accounting.Assets.Setup.FixedAssets;
using Inspection.Domain.Models.Contracting.Setup.CostCodes;
using Inspection.Domain.Models.HRManagement.Employees;
using Inspection.Domain.Models.SystemConfigurations.Operations;
using NDS.Shared.Domain.Contracts.EntityCommonData;

namespace Inspection.Domain.Models.Accounting.Assets.Setup.AssetCustodies
{
    public class AssetCustodyLine : IAuditable
    {

        public long Id { get; private set; }


        public long AssetCustodyId { get; set; }
        public AssetCustody AssetCustody { get; set; } = null!;


        public long FixedAssetId { get; private set; }
        public FixedAsset FixedAsset { get; private set; } = null!;


        public AssetCustodyLineCustodyType CustodyType { get; private set; }


        public long? FromEmployeeId { get; private set; }
        public Employee FromEmployee { get; private set; } = null!;

        public long? ToEmployeeId { get; private set; }
        public Employee ToEmployee { get; private set; } = null!;


        public long? FromOperationId { get; private set; }
        public Operation FromOperation { get; private set; } = null!;
        public long? ToOperationId { get; private set; }
        public Operation ToOperation { get; private set; } = null!;


        public long? FromCostCenterId { get; private set; }
        public CostCenter? FromCostCenter { get; private set; }
        public long? ToCostCenterId { get; private set; }
        public CostCenter? ToCostCenter { get; private set; }


        public long? FromCostCodeId { get; private set; }
        public CostCode FromCostCode { get; private set; } = null!;
        public long? ToCostCodeId { get; private set; }
        public CostCode ToCostCode { get; private set; } = null!;

        public DateTime CustodyStartDate { get; private set; }
        public DateTime? CustodyEndDate { get; private set; }

        public string? HandoverDocumentUrl { get; private set; }

        public bool IsAcknowledged { get; private set; }
        public DateTime? AcknowledgedDate { get; private set; }

        public AssetCustodyLineDocumentStatus DocumentStatus { get; private set; }

        public string? Notes { get; private set; }

        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}