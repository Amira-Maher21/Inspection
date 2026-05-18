using Inspection.Application.Contracts.Dto.SalesManagment.sales.JobOrderF;
using Inspection.Domain.Models.SalesManagment.Transaction.DTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.SalesManagment.sales
{
    public interface IJobOrderService : IAccountServiceBase
    {
        Task<ReturnBase<JobOrderDto>> GetAsync(long id);

        Task<ReturnBase<List<JobOrderDto>>> GetListAsync();
        Task<ReturnBase<List<JobOrderIncludeDto>>> GetListByIncludeAsync(SqlQueryOptions sqlQueryOptions);

        Task<ReturnBase<JobOrderDto>> CreateAsync(CreateJobOrderDto input);

        Task<ReturnBase<JobOrderDto>> UpdateAsync(UpdateJobOrderDto input);

        Task<ReturnBase<bool>> DeleteAsync(long id);
        Task<ReturnBase<IEnumerable<JobOrderDtoLookUpForNames>>> GetLookUpJobOrderForNamesAsync(SqlQueryOptions queryOptions);
        Task<ReturnBase<bool>> ChangeDocumentStatusAsync(ChangeJobOrderDocumentStatusDto newStatus);


    }
}
