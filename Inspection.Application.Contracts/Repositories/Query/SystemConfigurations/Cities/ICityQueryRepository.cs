using Inspection.Application.Contracts.Dto.SystemConfigurationDTOs.CityDTOs;
using Inspection.Domain.Models.SystemConfigurations.Cities;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.SystemConfigurations.Cities
{
    public interface ICityQueryRepository : IQueryRepository<City>
    {
        Task<City?> GetById(long id);
        Task<City?> GetByCode(string code);
        Task<bool> ExistsAsync(long id);
        Task<ReturnBase<IEnumerable<CitySearchReturnDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}