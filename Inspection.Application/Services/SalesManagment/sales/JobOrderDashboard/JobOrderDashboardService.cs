using AutoMapper;
using Inspection.Application.Contracts.Dto.Inspection.JobOrderDashboard;
using Inspection.Application.Contracts.Dto.SalesManagment.sales.JobOrderDashboard;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Query.SalesManagment.JobOrderDashboard;
using Inspection.Application.Contracts.Services.SalesManagment.sales.JobOrderDashboard;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.SalesManagment.sales.JobOrderDashboard
{
    public class JobOrderDashboardService : AccountsServiceBase, IJobOrderDashboardService
    {
        private readonly IJobOrderDashboardQueryRepository _queryRepository;

        public JobOrderDashboardService(
            IAccountUnitOfWork accountUoW,
            IAccountsQueriesManager queriesManager,
            IMapper mapper,
            IExceptionManager exceptionManager)

            : base(accountUoW, queriesManager, mapper, exceptionManager)
        {

        }


        public async Task<ReturnBase<JobOrderDashboardDto>> GetDashboardAsync(JobOrderDashboardFilterDto filter)
        {
            try
            {
                return await _queriesManager.IJobOrderDashboardQueryRepository
                    .GetDashboardAsync(filter);
            }
            catch (Exception ex)
            {
                return ReturnBase<JobOrderDashboardDto>.Fail(ex, _exceptionManager);
            }
        }




    }
}
