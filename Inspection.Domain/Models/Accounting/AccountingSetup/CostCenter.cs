using Inspection.Domain.Models.HRManagement.Departments;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;
using System.ComponentModel.DataAnnotations.Schema;


namespace Inspection.Domain.Models.Accounting.AccountingSetup
{
    [Table("CostCenter")]
    public class CostCenter : IRootEntity, ITenantEntity, IAuditable
    {

        public long Id { get; set; }
        public long? ParentCostCenterId { get; set; }

        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public bool IsMain { get; set; }
        public long? DepartmentId { get; set; }
        public Department Department { get; set; }

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }

    }
}