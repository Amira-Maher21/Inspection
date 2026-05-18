using Inspection.Domain.Models.DMS.ShareAccessLogs;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.DMS.ShareAccessLogs
{
    public interface IShareAccessLogCommandRepository : ICommandRepository<ShareAccessLog>
    {
        Task<ReturnBase> DeleteById(long id);
    }
}
