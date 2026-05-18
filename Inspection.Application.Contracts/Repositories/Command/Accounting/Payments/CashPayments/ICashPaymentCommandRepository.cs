using Inspection.Domain.Models.Accounting.Payment.CashPayments;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Accounting.Payments.CashPayments
{
    public interface ICashPaymentCommandRepository : ICommandRepository<CashPayment>
    {
        Task<ReturnBase> DeleteById(long id);

        Task<ReturnBase> DeleteCashPaymentLinesByCashPaymentIds(List<long> cashPaymentIds);

        Task<ReturnBase> DeletePurchaseInvoiceAllocationsByCashPaymentIds(List<long> cashPaymentIds);

        Task<ReturnBase> DeleteCashPaymentAdjustmentsByCashPaymentIds(List<long> cashPaymentIds);
    }
}