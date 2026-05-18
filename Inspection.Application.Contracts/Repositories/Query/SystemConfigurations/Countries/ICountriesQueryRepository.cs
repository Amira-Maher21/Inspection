using Inspection.Application.Contracts.Dto.SystemConfigurationDTOs.CountrisDto;
using Inspection.Domain.Models.SystemConfigurations.Countriess;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.SystemConfigurations.Countries
{
    public interface ICountriesQueryRepository : IQueryRepository<Country>
    {
        Task<Country?> GetById(long id);
        Task<Country?> GetByCode(string code);
        Task<bool> ExistsAsync(long id);

        Task<ReturnBase<IEnumerable<CountryDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }

}
