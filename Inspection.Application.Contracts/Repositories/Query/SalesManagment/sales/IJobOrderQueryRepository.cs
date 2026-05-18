using Inspection.Application.Contracts.Dto.SalesManagment.sales.JobOrderF;
using Inspection.Domain.Models.Inspection.Techinal.JobOrder;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.SalesManagment.sales
{
    public interface IJobOrderQueryRepository : IQueryRepository<JobOrder>
    {
        Task<JobOrder?> GetByIdAsync(long id);
        Task<IEnumerable<JobOrderIncludeDto?>> GetListByIncludeAsync(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<IEnumerable<JobOrderIncludeDto>>> GetLookUpJobOrderForNamesAsync(SqlQueryOptions queryOptions);

    }
}
