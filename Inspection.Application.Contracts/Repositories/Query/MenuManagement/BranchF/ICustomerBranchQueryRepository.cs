using Inspection.Application.Contracts.Dto.MenuManagement.BranchF;
using Inspection.Domain.Models.MenuManagement;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;

namespace Inspection.Application.Contracts.Repositories.Query.MenuManagement.BranchF
{
    public interface ICustomerBranchQueryRepository : IQueryRepository<CustomerBranch>
    {
        Task<CustomerBranch?> GetByIdAsync(long id);
        Task<IEnumerable<CustomerBranchIncludeDto?>> GetListByIncludeAsync(SqlQueryOptions sqlQueryOptions);

    }
}
