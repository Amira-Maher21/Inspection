using Inspection.Application.Contracts.Dto.AccountingDtos.AR.SalesInvoices;
using Inspection.Domain.Models.Accounting.AR.SalesInvoices;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Accounting.AR.SalesInvoices
{

    public interface ISalesInvoiceQueryRepository : IQueryRepository<SalesInvoice>
    {
        Task<SalesInvoice?> GetById(long id);
        Task<ReturnBase<IEnumerable<SalesInvoiceReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
        Task<SalesInvoice?> GetByCode(string code);
        Task<ReturnBase<List<SalesInvoiceLine>>> GetAll();


    }
}
