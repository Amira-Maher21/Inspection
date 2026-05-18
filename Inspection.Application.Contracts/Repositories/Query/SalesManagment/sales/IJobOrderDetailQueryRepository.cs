using Inspection.Application.Contracts.Dto.SalesManagment.sales.JobOrderF;
using Inspection.Domain.Models.Inspection.Techinal.JobOrder;
using NDS.Shared.Application.RepositoryBase;

namespace Inspection.Application.Contracts.Repositories.Query.SalesManagment.sales
{

    public interface IJobOrderDetailQueryRepository : IQueryRepository<JobOrderLine>
    {
        Task<JobOrderLine?> GetByIdAsync(long id);
        //Task<IEnumerable<JobOrderDetailIncludeDto?>> GetListByIncludeAsync(SqlQueryOptions sqlQueryOptions);
        //Task<ReturnBase<IEnumerable<JobOrderDetailIncludeDto>>> GetLookUpJobOrderDetailForNamesAsync(SqlQueryOptions queryOptions);
        Task<IEnumerable<JobOrderLinegGetListDto>> GetListAsync();

    }
}

