using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CashPaymentDTOs;
using Inspection.Domain.Models.Accounting.Payment.CashPayments;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Accounting.Payments.CashPayments
{
    public interface ICashPaymentQueryRepository : IQueryRepository<CashPayment>
    {
        Task<ReturnBase<List<CashPayment>>> GetAll();
        Task<CashPayment?> GetById(long id);
        Task<ReturnBase<IEnumerable<CashPaymentReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}