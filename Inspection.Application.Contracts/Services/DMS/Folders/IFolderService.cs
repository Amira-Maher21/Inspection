using Inspection.Application.Contracts.Dto.DMSDTOs.FolderDTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.DMS.Folders
{
    public interface IFolderService
    {
        Task<ReturnBase<FolderDto>> Create(FolderCreateDto createDto);
        Task<ReturnBase<FolderDto>> Update(FolderUpdateDto updateDto);
        Task<ReturnBase<FolderDto>> Delete(long id);
        Task<ReturnBase<FolderDto>> GetById(long id);
        Task<ReturnBase<IEnumerable<FolderReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}