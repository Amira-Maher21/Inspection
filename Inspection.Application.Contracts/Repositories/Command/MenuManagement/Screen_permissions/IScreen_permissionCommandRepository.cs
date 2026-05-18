using Inspection.Domain.Models.MenuManagement;
using NDS.Shared.Application.RepositoryBase;

namespace Inspection.Application.Contracts.Repositories.Command.MenuManagement.Screen_permissions
{

    public interface IScreen_permissionCommandRepository : ICommandRepository<Screen_permission>
    {
        //Task<ReturnBase> DeleteByIdAsync(string id);
    }
}

