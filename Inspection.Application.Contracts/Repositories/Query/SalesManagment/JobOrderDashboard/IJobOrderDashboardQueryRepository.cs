using Inspection.Application.Contracts.Dto.Inspection.JobOrderDashboard;
using Inspection.Application.Contracts.Dto.SalesManagment.sales.JobOrderDashboard;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.SalesManagment.JobOrderDashboard
{
    public interface IJobOrderDashboardQueryRepository
    {

        Task<ReturnBase<JobOrderDashboardDto>> GetDashboardAsync(JobOrderDashboardFilterDto filter);


    }
}

