namespace Inspection.Application.Contracts.Dto.AccountingDtos.AR.MasterData.CustomerGroup
{
    public class CustomerGroupDto
    {
        public long Id { get; set; }
        public string GroupCode { get; set; } = string.Empty;
        public string GroupName { get; set; } = string.Empty;
        public decimal? CreditLimit { get; set; }
        public long? PaymentTermsId { get; set; }

        public long? DefaultAccountGroupId { get; set; }

        public long? TaxCategoryId { get; set; }

        //  tanent
        public string Tenant_ID { get; set; } = string.Empty;
        // Audit 
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}
