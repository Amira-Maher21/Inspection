using Inspection.Application.Contracts.Dto.SystemDto.TaxTypeLine;

namespace Inspection.Application.Contracts.Dto.SystemDto.Taxs
{
    public class TaxCreateDto
    {
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
        public List<TaxTypeLineCreateDto> TaxTypeLine { get; set; } = new List<TaxTypeLineCreateDto>();



    }
}
