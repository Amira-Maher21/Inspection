using Inspection.Application.Contracts.Dto.SalesManagment.sales.SalesQuotationF.SalesQuotationDashboard;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.SalesManagment.sales.SalesQuotationDashboard
{
    public interface ISalesQuotationDashboardService
    {
        Task<ReturnBase<SalesQuotationDashboardDto>>
            GetDashboardAsync(SalesQuotationDashboardFilterDto filter);
    }
}
