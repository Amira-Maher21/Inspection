using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionRequests.Dashboard;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.InspectionManagement.InspectionRequests
{
    public interface IInspectionDashboardService
    {
        Task<ReturnBase<InspectionDashboardDto>>
            GetDashboardAsync(InspectionDashboardFilterDto filter);
    }
}
