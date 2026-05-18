using Inspection.Application.Contracts.Dto.MenuManagement.User_Codes;
using Inspection.Domain.Models.MenuManagement;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.MenuManagement.User_Codes
{
    public interface IUser_CodeQueryRepository
    {

        Task<User_Code?> GetById(long id);
        Task<User_Code?> GetByCode(string code);
        Task<ReturnBase<IEnumerable<User_CodeReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}