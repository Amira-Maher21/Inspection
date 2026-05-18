using Inspection.Application.Contracts.Dto.SystemConfigurationDTOs.CurrencyExchangRateDtos;
using Inspection.Domain.Models.SystemConfigurations.CurrencyExchangRates;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.SystemConfigurations.CurrencyExchangeRates
{
    public interface ICurrencyExchangeRateQueryRepository : IQueryRepository<CurrencyExchangRate>
    {
        Task<CurrencyExchangRate?> GetById(long id);
        Task<ReturnBase<IEnumerable<CurrencyExchangeRateReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}
