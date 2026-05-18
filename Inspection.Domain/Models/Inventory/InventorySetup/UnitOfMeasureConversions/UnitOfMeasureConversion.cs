using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.Inventory.InventorySetup.UnitOfMeasureConversions
{
    public class UnitOfMeasureConversion : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; private set; }
        public long FromUoMId { get; private set; }
        public UnitOfMeasure FromUnitOfMeasure { get; private set; } = null!;
        public long ToUoMId { get; private set; }
        public UnitOfMeasure ToUnitOfMeasure { get; private set; } = null!;
        public decimal ConversionFactor { get; private set; }

        public string Tenant_ID { get; set; } = string.Empty;
        // Audit 
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }


    }
}
