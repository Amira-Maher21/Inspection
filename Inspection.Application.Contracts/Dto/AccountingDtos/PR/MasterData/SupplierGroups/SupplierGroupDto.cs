namespace Inspection.Application.Contracts.Dto.AccountingDtos.PR.MasterData.SupplierGroups
{
    public class SupplierGroupDto
    {
        public long Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Tenant_ID { get; set; } = string.Empty;
        public long? DefaultAccountGroupId { get; set; }
        public long? PaymentTermsId { get; set; }

        public long? TaxCategoryId { get; set; }

        public string Notes { get; set; } = string.Empty;

        // Audit 
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}