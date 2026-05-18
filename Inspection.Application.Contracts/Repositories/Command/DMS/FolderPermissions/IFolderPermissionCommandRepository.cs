using Inspection.Domain.Models.DMS.FolderPermissions;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.DMS.FolderPermissions
{
    public interface IFolderPermissionCommandRepository : ICommandRepository<FolderPermission>
    {
        Task<ReturnBase> DeleteById(long id);
    }
}