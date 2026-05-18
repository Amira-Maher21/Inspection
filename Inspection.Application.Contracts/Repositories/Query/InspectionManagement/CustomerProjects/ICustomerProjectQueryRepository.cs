using Inspection.Application.Contracts.Dto.InspectionManagement.CustomerProjects;
using Inspection.Domain.Models.InspectionManagement.CustomerProjects;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.InspectionManagement.CustomerProjects
{
    public interface ICustomerProjectQueryRepository : IQueryRepository<CustomerProject>
    {
        Task<CustomerProject?> GetByIdAsync(long id);
        Task<ReturnBase<IEnumerable<CustomerProjectDtoByInclude>>> GetListAsync(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<IEnumerable<CustomerProjectDtoByInclude>>> GetLookUpCustomerProjectForNamesAsync(SqlQueryOptions queryOptions);
        Task<ReturnBase<IEnumerable<CustomerProjectDtoByInclude>>> GetListIncldeNameAsync(SqlQueryOptions sqlQueryOptions);

    }
}
