using Inspection.Application.Contracts.Dto.DMSDTOs.FolderPermissionDTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.DMS.FolderPermissions
{
    public interface IFolderPermissionService
    {
        Task<ReturnBase<FolderPermissionDto>> Create(FolderPermissionCreateDto createDto);
        Task<ReturnBase<FolderPermissionDto>> Update(FolderPermissionUpdateDto updateDto);
        Task<ReturnBase<FolderPermissionDto>> Delete(long id);
        Task<ReturnBase<FolderPermissionDto>> GetById(long id);
        Task<ReturnBase<IEnumerable<FolderPermissionReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}