using Inspection.Domain.Enums.System.Taxs.DocumentDirections;

namespace Inspection.Application.Contracts.Dto.SystemDto.TaxTypeLine
{
    public class TaxTypeLineDto
    {
        public long Id { get; set; }

        public long TaxTypeId { get; set; }

        public DocumentDirection DocumentDirection { get; set; }

        public long ChartOfAccountId { get; set; }

        public decimal? RecoverablePercentage { get; set; }

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}
