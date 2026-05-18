using Inspection.Application.Contracts.Dto.SalesManagment.sales.Transactions.SalesQuotationDTOs;
using Inspection.Domain.Models.SalesManagment.Transaction.SalesQuotations;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.SalesManagment.Transactions.SalesQuotations
{
    public interface ISalesQuotationQueryRepository : IQueryRepository<SalesQuotation>
    {
        Task<ReturnBase<List<SalesQuotation>>> GetAll();
        Task<SalesQuotation?> GetById(long id);
        Task<ReturnBase<IEnumerable<SalesQuotationReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
        Task<SalesQuotation?> GetByInspectionRequestId(long inspectionRequestId);
    }
}