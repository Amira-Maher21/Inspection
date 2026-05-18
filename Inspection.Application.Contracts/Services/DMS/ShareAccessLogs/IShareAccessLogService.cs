using Inspection.Application.Contracts.Dto.DMSDTOs.ShareAccessLogs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.DMS.ShareAccessLogs
{
    public interface IShareAccessLogService
    {
        Task<ReturnBase<ShareAccessLogDto>> Create(ShareAccessLogCreateDto createDto);
        Task<ReturnBase<ShareAccessLogDto>> Update(ShareAccessLogUpdateDto updateDto);
        Task<ReturnBase<ShareAccessLogDto>> Delete(long id);
        Task<ReturnBase<ShareAccessLogDto>> GetById(long id);
        Task<ReturnBase<IEnumerable<ShareAccessLogDto>>> GetList(SqlQueryOptions? sqlQueryOptions = null);

        Task<ReturnBase<IEnumerable<ShareAccessLogReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}
