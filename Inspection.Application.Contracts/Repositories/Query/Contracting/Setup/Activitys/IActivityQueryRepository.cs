using Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.Activitys;
using Inspection.Domain.Models.Contracting.Setup.Activitys;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Contracting.Setup.Activitys
{
    public interface IActivityQueryRepository
    {
        Task<Activity?> GetById(long id);
        Task<ReturnBase<IEnumerable<ActivityReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}
