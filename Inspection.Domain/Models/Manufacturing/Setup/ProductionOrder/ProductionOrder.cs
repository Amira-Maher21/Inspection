using Inspection.Domain.Enums.Accounting.payments.JournalEntrys;
using Inspection.Domain.Models.SystemConfigurations.Operations;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.Manufacturing.Setup.ProductionOrder
{
    public class ProductionOrder : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; set; }
        public long OperationId { get; set; }
        public Operation Operation { get; set; }

        public long OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public DocumentStatus DocumentStatus { get; set; }
        public decimal? ExpectedAmount { get; set; }

        public virtual ICollection<ProductionOrderLine> ProductionOrderLines { get; set; } = null!;

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}
