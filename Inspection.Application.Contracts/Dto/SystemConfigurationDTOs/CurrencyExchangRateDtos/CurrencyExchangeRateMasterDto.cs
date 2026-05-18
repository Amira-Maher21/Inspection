using Inspection.Application.Contracts.Dto.SystemConfigurationDTOs.DetailTableDtos;

namespace Inspection.Application.Contracts.Dtos.CurrencyExchange
{
    public class CurrencyExchangeRateMasterDto
    {
        public string Tenant_ID { get; set; } = string.Empty;

        public long Id { get; set; }
        public long CurrencyId { get; set; }
        //public string? CurrencyCode { get; set; }
        //public string? CurrencyName { get; set; }
        public long CompanyId { get; set; }

        public DateTime EffectiveDate { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }


        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
        public List<DetailTableDto> Details { get; set; } = new List<DetailTableDto>();



    }
}
