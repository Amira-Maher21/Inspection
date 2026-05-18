namespace Inspection.Application.Contracts.Dto.Inventory.Transaction.ScrapReasons
{
    public class ScrapReasonUpdateDto
    {
        public long Id { get; set; }

        public long CompanyId { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }

        public long ChartOfAccountId { get; set; }


    }
}
