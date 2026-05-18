using Inspection.Application.Contracts.Dto.DMSDTOs.ShareAccessLogs;
using Inspection.Domain.Models.DMS.ShareAccessLogs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.DMS.ShareAccessLogs
{
    public interface IShareAccessLogQueryRepository
    {
        Task<ShareAccessLog?> GetById(long id);
        Task<IEnumerable<ShareAccessLog>> GetList(SqlQueryOptions sqlQueryOptions = null);
        Task<ReturnBase<IEnumerable<ShareAccessLogReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);

    }
}
