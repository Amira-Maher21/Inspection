namespace Inspection.Application.Contracts.Dto.Inventory.System.InventoryCostLayers
{
    public class InventoryCostLayerCreateDto
    {

        public long ItemId { get; set; }

        public long CompanyId { get; set; }
        public long WarehouseId { get; set; }

        public decimal QuantityIn { get; set; }
        public decimal QuantityOut { get; set; }
        public decimal RemainingQty { get; set; }
        public decimal UnitCost { get; set; }
        public long ReferenceDocumentId { get; set; }
        public DateTime TransactionDate { get; set; }

    }
}