using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.Multitenant;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inspection.Domain.Models.MenuManagement
{
    [Table("Area", Schema = "Inspection")]

    public class Area : IRootEntity, ITenantEntity
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Tenant_ID { get; set; } = string.Empty;
    }
}