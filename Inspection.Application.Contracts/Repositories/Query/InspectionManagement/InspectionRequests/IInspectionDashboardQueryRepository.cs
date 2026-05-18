using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionRequests.Dashboard;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.InspectionManagement.InspectionRequests
{
    public interface IInspectionDashboardQueryRepository
    {
        Task<ReturnBase<InspectionDashboardDto>>
            GetDashboardAsync(InspectionDashboardFilterDto filter);
    }

}
