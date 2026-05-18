using Inspection.Domain.Enums.System.Taxs.DocumentDirections;

namespace Inspection.Application.Contracts.Dto.SystemDto.TaxTypeLine
{
    public class TaxTypeLineCreateDto
    {

        public long TaxTypeId { get; set; }

        public DocumentDirection DocumentDirection { get; set; }

        public long ChartOfAccountId { get; set; }

        public decimal? RecoverablePercentage { get; set; }


    }
}
