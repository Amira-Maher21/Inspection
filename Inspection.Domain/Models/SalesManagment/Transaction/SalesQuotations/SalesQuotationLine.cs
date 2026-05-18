using Inspection.Domain.Models.InspectionManagement.InspectionMethods;
using Inspection.Domain.Models.Inventory.InventorySetup.Items;
using NDS.Shared.Domain.Contracts.EntityCommonData;

namespace Inspection.Domain.Models.SalesManagment.Transaction.SalesQuotations
{
    public class SalesQuotationLine : IAuditable
    {
        public long Id { get; private set; }
        public long SalesQuotationId { get; set; }
        public SalesQuotation SalesQuotation { get; set; } = null!;

        public string? Description { get; private set; }

        public Item Item { get; private set; } = null!;
        public long ItemId { get; private set; }
        public int Quantity { get; private set; }

        public decimal UnitPrice { get; private set; }
        public decimal Total { get; private set; }

        public InspectionMethod? InspectionMethod { get; private set; }
        public long? InspectionMethodId { get; private set; }

        public string? Notes { get; private set; }

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }

    }
}