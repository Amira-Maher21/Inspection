using Inspection.Application.Contracts.Dto.InspectionManagement.CustomerLocations;
using Inspection.Domain.Models.InspectionManagement.CustomerLocations;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.InspectionManagement.CustomerLocations
{
    public interface ICustomerLocationQueryRepository : IQueryRepository<CustomerLocation>
    {
        Task<CustomerLocation?> GetByIdAsync(long id);
        //Task<ReturnBase<IEnumerable<LocationDto>>> GetListAsync(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<IEnumerable<CustomerLocationDtoByInclude>>> GetListIncludeNameAsync(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<IEnumerable<CustomerLocationDtoByInclude>>> GetLookUpCustomerLocationForNamesAsync(SqlQueryOptions queryOptions);
    }
}
