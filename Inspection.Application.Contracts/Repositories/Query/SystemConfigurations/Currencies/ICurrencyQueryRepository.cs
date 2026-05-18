using Inspection.Application.Contracts.Dto.SystemConfigurationDTOs.CurrencyDTOs;
using Inspection.Domain.Models.SystemConfigurations.Currencies;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.SystemConfigurations.Currencies
{
    public interface ICurrencyQueryRepository : IQueryRepository<Currency>
    {
        Task<Currency?> GetById(long id);
        Task<Currency?> GetByCode(string code);

        Task<ReturnBase<IEnumerable<CurrencyDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}