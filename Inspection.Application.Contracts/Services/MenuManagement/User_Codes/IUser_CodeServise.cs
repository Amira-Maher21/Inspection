using Inspection.Application.Contracts.Dto.MenuManagement.User_Codes;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.MenuManagement.User_Codes
{
    public interface IUser_CodeServise
    {
        Task<ReturnBase<User_CodeDto>> Create(CreateUser_CodeDto dto);
        Task<ReturnBase<User_CodeDto>> Update(UpdateUser_CodeDto dto);
        Task<ReturnBase<User_CodeDto>> Delete(long userId);

        Task<ReturnBase<User_CodeDto>> GetById(long userId);
        Task<ReturnBase<User_CodeDto>> GetByCode(string code);
        Task<ReturnBase<IEnumerable<User_CodeReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}