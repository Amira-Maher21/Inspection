using Inspection.Domain.Models.MenuManagement;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.MenuManagement.User_Groups
{

    public interface IUser_GroupCommandRepository : ICommandRepository<User_Group>
    {
        Task<ReturnBase> DeleteById(long id);

    }
}
