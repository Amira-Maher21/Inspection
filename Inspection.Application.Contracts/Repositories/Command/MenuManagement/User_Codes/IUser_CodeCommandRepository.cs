using Inspection.Domain.Models.MenuManagement;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.MenuManagement.User_Codes
{
    public interface IUser_CodeCommandRepository : ICommandRepository<User_Code>
    {
        Task<ReturnBase> DeleteById(long id);

    }
}
