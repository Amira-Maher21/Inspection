using Inspection.Application.Contracts.Dto.SalesManagment.sales.SalesQuotationF.SalesQuotationDashboard;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.SalesManagment.SalesQuotationDashboard
{
    public interface ISalesQuotationDashboardQueryRepository
    {
        Task<ReturnBase<SalesQuotationDashboardDto>>
            GetDashboardAsync(SalesQuotationDashboardFilterDto filter);
    }
}
