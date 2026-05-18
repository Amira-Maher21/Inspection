using Inspection.Application.Contracts.Dto.MenuManagement.User_Groups;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.MenuManagement.User_Groups
{


    public interface IUser_GroupService : IAccountServiceBase
    {

        Task<ReturnBase<User_GroupDto>> Create(CreateUser_GroupDto createDto);
        Task<ReturnBase<User_GroupDto>> Update(UpdateUser_GroupDto updateDto);
        Task<ReturnBase<User_GroupDto>> Delete(long id);
        Task<ReturnBase<User_GroupDto>> GetById(long id);
        Task<ReturnBase<IEnumerable<User_GroupReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);

    }
}
