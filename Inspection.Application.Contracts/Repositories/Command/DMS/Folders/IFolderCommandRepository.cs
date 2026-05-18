using Inspection.Domain.Models.DMS.Folders;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.DMS.Folders
{
    public interface IFolderCommandRepository : ICommandRepository<Folder>
    {
        Task<ReturnBase> DeleteById(long id);
        Task<bool> ExistsDuplicateNameAsync(string tenantId, long companyId, long? parentFolderId, string name, long? ignoreId);
    }
}