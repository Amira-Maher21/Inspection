using Inspection.Application.Contracts.Dto.SystemConfigurationDTOs.DetailTableDtos;
using Inspection.Domain.Models.SystemConfigurations.Currencies;

namespace Inspection.Application.Contracts.Dto.SystemConfigurationDTOs.CurrencyExchangRateDtos
{
    public class CurrencyExchangeRateReturnSearchDto
    {
        public string Tenant_ID { get; set; } = string.Empty;
        public long Id { get; set; }
        public long CurrencyId { get; set; }
        public long CompanyId { get; set; }


        public Currency Currency { get; set; } = null!;
        public string CurrencyCode { get; set; } = null!;
        public string CurrencyName { get; set; } = null!;



        public DateTime EffectiveDate { get; set; }
        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
        public List<DetailTableDto> Details { get; set; } = new List<DetailTableDto>();
    }
}
