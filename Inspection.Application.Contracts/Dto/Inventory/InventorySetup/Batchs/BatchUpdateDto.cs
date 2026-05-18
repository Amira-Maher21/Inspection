namespace Inspection.Application.Contracts.Dto.Inventory.InventorySetup.Batchs
{
    public class BatchUpdateDto
    {
        public long Id { get; set; }
        public long CompanyId { get; set; }

        public string BatchNumber { get; set; }

        public long ItemId { get; set; }

        public DateTime? ManufactureDate { get; set; }
        public DateTime? ExpiryDate { get; set; }



    }
}
