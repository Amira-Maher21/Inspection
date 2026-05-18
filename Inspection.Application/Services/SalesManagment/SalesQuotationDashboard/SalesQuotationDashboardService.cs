using AutoMapper;
using Inspection.Application.Contracts.Dto.SalesManagment.sales.SalesQuotationF.SalesQuotationDashboard;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Services.SalesManagment.sales.SalesQuotationDashboard;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.SalesManagment.SalesQuotationDashboard
{
    public class SalesQuotationDashboardService
        : AccountsServiceBase, ISalesQuotationDashboardService
    {
        public SalesQuotationDashboardService(
            IAccountUnitOfWork accountUoW,
            IAccountsQueriesManager queriesManager,
            IMapper mapper,
            IExceptionManager exceptionManager)
            : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
        }

        public async Task<ReturnBase<SalesQuotationDashboardDto>>
            GetDashboardAsync(SalesQuotationDashboardFilterDto filter)
        {
            try
            {
                return await _queriesManager
                    .ISalesQuotationDashboardQueryRepository
                    .GetDashboardAsync(filter);
            }
            catch (Exception ex)
            {
                return ReturnBase<SalesQuotationDashboardDto>
                    .Fail(ex, _exceptionManager);
            }
        }
    }
}
