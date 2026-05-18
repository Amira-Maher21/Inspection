using Inspection.Application.Contracts.Dto.AccountingDtos.PR.PurchaseInvoices;
using Inspection.Domain.Models.Accounting.PR.PurchaseInvoices;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Accounting.PR.PurchaseInvoices
{
    public interface IPurchaseInvoiceQueryRepository : IQueryRepository<PurchaseInvoice>
    {
        Task<PurchaseInvoice?> GetById(long id);
        Task<PurchaseInvoice?> GetByCode(string code);
        Task<ReturnBase<IEnumerable<PurchaseInvoiceReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}