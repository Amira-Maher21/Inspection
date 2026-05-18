using Inspection.Application.Contracts.Dto.SystemConfigurationDTOs.DetailTableDtos;

namespace Inspection.Application.Contracts.Dto.SystemConfigurationDTOs.CurrencyExchangRateDtos
{
    public class CurrencyExchangeRateMasterCreateDto
    {



        public long CurrencyId { get; set; }
        public long CompanyId { get; set; }
        public DateTime EffectiveDate { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;




        public List<DetailTableCreateDto> Details { get; set; } = new List<DetailTableCreateDto>();



    }
}
