using Inspection.Application.Contracts.Dto.MenuManagement.Screen_permissions;
using Inspection.Domain.Models.MenuManagement;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.MenuManagement.Screen_permissions
{

    public interface IScreen_permissionQueryRepository : IQueryRepository<Screen_permission>
    {
        Task<Screen_permission?> GetByIdAsync(string id);
        Task<ReturnBase<IEnumerable<Screen_permissionDtoByInclude>>> GetListAsync(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<IEnumerable<Screen_permissionDtoByInclude>>> GetLookUpScreen_permissionForNamesAsync(SqlQueryOptions queryOptions);
        Task<ReturnBase<IEnumerable<Screen_permissionReturnSearchDto>>> GetListIncldeNameAsync(SqlQueryOptions sqlQueryOptions);

    }
}

