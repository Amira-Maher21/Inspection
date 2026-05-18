using Inspection.Application.Contracts.Dto.MenuManagement.User_Groups;
using Inspection.Domain.Models.MenuManagement;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.MenuManagement.User_Groups
{

    public interface IUser_GroupQueryRepository : IQueryRepository<User_Group>
    {

        Task<User_Group?> GetById(long id);
        Task<IEnumerable<User_Group>> GetList(SqlQueryOptions sqlQueryOptions = null);
        Task<ReturnBase<IEnumerable<User_GroupReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }

}
