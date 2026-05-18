using AutoMapper;
using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionRequests.Dashboard;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Services.InspectionManagement.InspectionRequests;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.InspectionManagement.InspectionRequests
{
    public class InspectionDashboardService
        : AccountsServiceBase, IInspectionDashboardService
    {
        public InspectionDashboardService(
            IAccountUnitOfWork accountUoW,
            IAccountsQueriesManager queriesManager,
            IMapper mapper,
            IExceptionManager exceptionManager)
            : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
        }

        public async Task<ReturnBase<InspectionDashboardDto>>
            GetDashboardAsync(InspectionDashboardFilterDto filter)
        {
            try
            {
                return await _queriesManager
                    .InspectionDashboard
                    .GetDashboardAsync(filter);
            }
            catch (Exception ex)
            {
                return ReturnBase<InspectionDashboardDto>
                    .Fail(ex, _exceptionManager);
            }
        }
    }
}
