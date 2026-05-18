using Inspection.Application.Contracts.Dto.SampleDTOs.CurrencyExchangeRateDTOs;
using Inspection.Domain.Models.Sample.CurrencyExchangeRate;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Sample.CurrencyExchangeRate
{
    public interface ISCurrencyExchangeRateQueryRepository : IQueryRepository<SCurrencyExchangeRateHeader>

    {
        Task<ReturnBase<SCurrencyExchangeRateItemDto?>> GetByIdAsync(long id);

        Task<ReturnBase<IEnumerable<SCurrencyExchangeRateListItemDto>>> GetListAsync(SqlQueryOptions queryOptions);

        Task<ReturnBase<IEnumerable<SCurrencyExchangeRateLineListItemDto>>> GetLinesAsync(long id);

        Task<ReturnBase<decimal>> GetLatestRateAsync(long baseCurrencyId, long targetCurrencyId, DateTime postingDate);
    }
}