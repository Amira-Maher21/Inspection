using Inspection.Application.Contracts.Dto.SystemDto.TaxTypeLine;

namespace Inspection.Application.Contracts.Dto.SystemDto.Taxs
{
    public class TaxReturnSearchDto
    {

        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public decimal Percentage { get; set; }
        public string Description { get; set; }


        public bool IsActive { get; set; }
        public bool IsRecoverable { get; set; }
        public bool IsInclusive { get; set; }


        public bool IsExempt { get; set; }
        public string? EtaCodeEgypt { get; set; }
        public bool IsSystem { get; set; }


        public long taxCategoryId { get; set; }
        public string TaxCategoryCode { get; set; }
        public string TaxCategoryName { get; set; }

        public long TaxAccountId { get; set; }
        public string TaxAccountCode { get; set; }
        public string TaxAccountName { get; set; }




        public List<TaxTypeLineDto> TaxTypeLine { get; set; } = new List<TaxTypeLineDto>();


    }
}
