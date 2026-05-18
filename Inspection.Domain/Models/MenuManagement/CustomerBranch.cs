using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.Multitenant;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inspection.Domain.Models.MenuManagement
{
    [Table("CustomerBranch", Schema = "Inspection")]

    public class CustomerBranch : IRootEntity, ITenantEntity
    {
        [Key]
        public long Id { get; set; }
        public string NameAr { get; set; } = string.Empty;
        public string NameEn { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Tenant_ID { get; set; } = string.Empty;
    }
}