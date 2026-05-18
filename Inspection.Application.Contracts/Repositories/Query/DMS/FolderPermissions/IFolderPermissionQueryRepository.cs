using Inspection.Application.Contracts.Dto.DMSDTOs.FolderPermissionDTOs;
using Inspection.Domain.Models.DMS.FolderPermissions;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.DMS.FolderPermissions
{
    public interface IFolderPermissionQueryRepository : IQueryRepository<FolderPermission>
    {
        IQueryable<FolderPermission> GetAll();
        Task<FolderPermission?> GetById(long id);
        Task<ReturnBase<IEnumerable<FolderPermissionReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions, string tenantId, long companyId);
    }
}