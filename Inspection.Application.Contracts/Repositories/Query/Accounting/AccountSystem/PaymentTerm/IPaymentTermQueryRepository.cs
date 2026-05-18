using Inspection.Domain.Models.Accounting.AccountingSystem.PaymentTerms;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
namespace Inspection.Application.Contracts.Repositories.Query.Accounting.AccountSystem.PaymentTerms
{
    public interface IPaymentTermQueryRepository : IQueryRepository<PaymentTerm>
    {
        Task<ReturnBase<List<PaymentTerm>>> GetAll();
        Task<PaymentTerm?> GetById(long id);
        Task<PaymentTerm?> GetByCode(string code);

        Task<ReturnBase<IEnumerable<PaymentTerm>>> Search(SqlQueryOptions sqlQueryOptions);

    }
}