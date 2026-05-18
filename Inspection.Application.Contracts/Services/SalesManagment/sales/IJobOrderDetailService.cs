using Inspection.Application.Contracts.Dto.SalesManagment.sales.JobOrderDetails;
using Inspection.Application.Contracts.Dto.SalesManagment.sales.JobOrderF;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.SalesManagment.sales
{

    public interface IJobOrderDetailService : IAccountServiceBase
    {

        Task<ReturnBase<UpdateJobOrderLinesDto>> InsertJobOrderDetailAsync(CreateJobOrderLinesDto insertDto);
        Task<ReturnBase<UpdateJobOrderLinesDto>> UpdateJobOrderDetailAsync(UpdateJobOrderLinesDto updateDto, long id);
        Task<ReturnBase<UpdateJobOrderLinesDto>> DeleteJobOrderDetailAsync(long id);
        Task<ReturnBase<JobOrderLinesDto>> GetJobOrderDetailByIdAsync(long id);
        //Task<ReturnBase<IEnumerable<JobOrderDetailDtoByInclude>>> GetJobOrderDetailListAsync(SqlQueryOptions sqlQueryOptions);
        //Task<List<JobOrderDetailDtoByInclude>> GetListAsync();
        //Task<ReturnBase<IEnumerable<JobOrderDetailDtoByInclude>>> GetJobOrderDetailListByIncludeAsync(SqlQueryOptions sqlQueryOptions);

        //Task<ReturnBase<IEnumerable<JobOrderDetailDtoLookUpForNames>>> GetLookUpJobOrderDetailForNamesAsync(SqlQueryOptions queryOptions);
        Task<ReturnBase<IEnumerable<JobOrderLinegGetListDto>>>
                GetJobOrderDetailsListAsync();
    }
}