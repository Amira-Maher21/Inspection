using Inspection.Application.Contracts.Dto.Inspection.JobOrderDashboard;
using Inspection.Application.Contracts.Dto.SalesManagment.sales.JobOrderDashboard;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.SalesManagment.sales.JobOrderDashboard
{
    public interface IJobOrderDashboardService : IAccountServiceBase
    {
        Task<ReturnBase<JobOrderDashboardDto>> GetDashboardAsync(JobOrderDashboardFilterDto filter);
    }
}