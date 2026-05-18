using Inspection.Application.Contracts.Dto.SampleDTOs.CurrencyExchangeRateDTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Sample.CurrencyExchangeRate
{
    public interface ISCurrencyExchangeRateService : IAccountServiceBase
    {
        Task<ReturnBase<SCurrencyExchangeRateItemDto?>> GetCurrencyExchangeRateById(long id);
        Task<ReturnBase<IEnumerable<SCurrencyExchangeRateListItemDto>>> GetCurrencyExchangeRateListAsync(SqlQueryOptions queryOptions);
        Task<ReturnBase<IEnumerable<SCurrencyExchangeRateLineListItemDto>>> GetCurrencyExchangeRatesLinesAsync(long id);
        Task<ReturnBase<long>> CreateCurrencyExchangeRateAsync(SCurrencyExchangeRateCreateDto createDto);
        Task<ReturnBase> UpdateCurrencyExchangeRateAsync(SCurrencyExchangeRateUpdateDto updateDto);
        Task<ReturnBase> AddCurrencyExchangeRateLineAsync(long id, SCurrencyExchangeRateAddLineDto addLineDto);
        Task<ReturnBase> UpdateCurrencyExchangeRateLineAsync(long id, SCurrencyExchangeRateUpdateLineDto updateLineDto);
        Task<ReturnBase> DeactivateCurrencyExchangeRateAsync(long id);
    }
}