using Inspection.Domain.Models.Accounting.AccountingSetup;
using Inspection.Domain.Models.Accounting.AccountingSetup.CostUnits;
using Inspection.Domain.Models.Accounting.AR.MasterData;
using Inspection.Domain.Models.SystemConfigurations.Companies;
using Inspection.Domain.Models.SystemConfigurations.OperationTypes;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inspection.Domain.Models.SystemConfigurations.Operations
{
    [Table("Operation")]
    public class Operation : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public DateTime AwardDate { get; set; }
        public string Location { get; set; }
        public bool IsActive { get; set; }
        public bool IsClosed { get; set; }
        public DateTime? PlannedStartDate { get; set; }
        public DateTime? PlannedEndDate { get; set; }
        public DateTime? ClosedDate { get; set; }




        public long OperationTypeId { get; set; }
        public OperationType operationType { get; set; }
        public long CostUnitId { get; set; }
        public CostUnit costUnit { get; set; }
        public long CostCenterId { get; set; }
        public CostCenter costCenter { get; set; }
        public long CustomerId { get; set; }
        public Customer customer { get; set; }
        public long CompanyId { get; set; }
        public Company company { get; set; }



        public string Tenant_ID { get; set; } = string.Empty;
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }



    }
}
