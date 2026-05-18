using Inspection.Application.Contracts.Dto.SystemConfigurationDTOs.CurrencyDTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.SystemConfigurations.Currencies
{
    public interface ICurrencyService
    {
        Task<ReturnBase<CurrencyDto>> Create(CurrencyCreateDto createDto);
        Task<ReturnBase<CurrencyDto>> Update(CurrencyUpdateDto updateDto);
        Task<ReturnBase<CurrencyDto>> Delete(long id);
        Task<ReturnBase<CurrencyDto>> GetById(long id);
        Task<ReturnBase<CurrencyDto>> GetByCode(string code);
        Task<ReturnBase<IEnumerable<CurrencyDto>>> Search(SqlQueryOptions sqlQueryOptions);

        Task<ReturnBase<CurrencyRatesResultDto>> GetRatesAsync(long companyId, long transactionCurrencyId, DateTime postingDate);
    }
}