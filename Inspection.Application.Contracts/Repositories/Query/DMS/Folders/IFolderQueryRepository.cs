using Inspection.Application.Contracts.Dto.DMSDTOs.FolderDTOs;
using Inspection.Domain.Models.DMS.Folders;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.DMS.Folders
{
    public interface IFolderQueryRepository : IQueryRepository<Folder>
    {
        IQueryable<Folder> GetAll();
        Task<Folder?> GetById(long id);
        Task<ReturnBase<IEnumerable<FolderReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions, string tenantId, long companyId);
    }
}