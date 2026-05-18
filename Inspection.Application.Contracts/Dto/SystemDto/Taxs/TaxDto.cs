using Inspection.Application.Contracts.Dto.SystemDto.TaxTypeLine;

namespace Inspection.Application.Contracts.Dto.SystemDto.Taxs
{
    public class TaxDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal Percentage { get; set; }
        public string Description { get; set; }


        public bool IsActive { get; set; }
        public bool IsRecoverable { get; set; }
        public bool IsInclusive { get; set; }


        public long taxCategoryId { get; set; }
        public long TaxAccountId { get; set; }
        public bool IsExempt { get; set; }
        public string? EtaCodeEgypt { get; set; }
        public bool IsSystem { get; set; }


        public List<TaxTypeLineDto> TaxTypeLine { get; set; } = new List<TaxTypeLineDto>();


        public string Tenant_ID { get; set; } = string.Empty;
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }

    }
}
