
using Inspection.Domain.Enums;
using Inspection.Domain.Models.InspectionManagement.InspectionMethods;
using Inspection.Domain.Models.InspectionManagement.ServicesItems;
using Inspection.Domain.Models.Inventory.InventorySetup.Items;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inspection.Domain.Models.InspectionManagement.InspectionRequests
{
    public class InspectionRequestLines : IAuditable, IRootEntity
    {

        public long Id { get; set; }

        public long ItemId { get; set; }
        public Item Items { get; set; } = null!;
        public long InspectionRequestId { get; set; }
        public InspectionRequest InspectionRequests { get; set; } = null!;
        public long InspectionMethodId { get; set; }
        public InspectionMethod InspectionMethods { get; set; } = null!;
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public bool? IsSubcontractor { get; set; }
        public InspectionRequestLinesStatus Status { get; set; } = InspectionRequestLinesStatus.Planned;

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}