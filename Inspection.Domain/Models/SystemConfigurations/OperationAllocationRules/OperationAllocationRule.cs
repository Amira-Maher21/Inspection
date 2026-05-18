using Inspection.Domain.Models.SystemConfigurations.Operations;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inspection.Domain.Models.SystemConfigurations.OperationAllocationRule
{
    [Table("OperationAllocationRule")]
    public class OperationAllocationRule : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; set; }
        public long OperationId { get; set; }
        public Operation Operation { get; set; }

        public bool BOQ { get; set; }
        public bool WBS { get; set; }
        public bool WorkItem { get; set; }
        public bool CostCenter { get; set; }
        public bool CostUnit { get; set; }




        public string Tenant_ID { get; set; } = string.Empty;
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }

    }
}
