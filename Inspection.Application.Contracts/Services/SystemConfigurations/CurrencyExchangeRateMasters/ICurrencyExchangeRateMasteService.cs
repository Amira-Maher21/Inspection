using Inspection.Application.Contracts.Dto.SystemConfigurationDTOs.CurrencyExchangRateDtos;
using Inspection.Application.Contracts.Dtos.CurrencyExchange;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.SystemConfigurations.CurrencyExchangeRateMasters
{
    public interface ICurrencyExchangeRateMasteService
    {
        Task<ReturnBase<CurrencyExchangeRateMasterDto>> Create(CurrencyExchangeRateMasterCreateDto createDto);
        Task<ReturnBase<CurrencyExchangeRateMasterDto>> Update(CurrencyExchangeRateMasterUpdateDto updateDto);
        Task<ReturnBase<CurrencyExchangeRateMasterDto>> Delete(long id);
        Task<ReturnBase<CurrencyExchangeRateMasterDto>> GetById(long id);
        Task<ReturnBase<IEnumerable<CurrencyExchangeRateReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);


    }
}
