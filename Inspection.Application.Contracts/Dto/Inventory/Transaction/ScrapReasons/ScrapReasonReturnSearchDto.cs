namespace Inspection.Application.Contracts.Dto.Inventory.Transaction.ScrapReasons
{
    public class ScrapReasonReturnSearchDto
    {
        public long Id { get; set; }

        public string Tenant_ID { get; set; }
        public long CompanyId { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }

        public long ChartOfAccountId { get; set; }
        public string ChartOfAccountName { get; set; }
        public string ChartOfAccountCode { get; set; }

        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}
