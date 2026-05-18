namespace Inspection.Application.Contracts.Dto.Inventory.Transaction.InventoryOpeningBalanceDTOs.InventoryOpeningBalanceLineDTOs
{
    public interface IInventoryLineHasSerialAndQty
    {
        string? SerialNumber { get; }
        decimal Quantity { get; }
    }
}