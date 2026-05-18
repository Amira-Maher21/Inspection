using Inspection.Domain.Models.Accounting.Payment.CashReceipts;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Accounting.Payments.CashReceipts
{
    public interface ICashReceiptCommandRepository : ICommandRepository<CashReceipt>
    {
        Task<ReturnBase> DeleteById(long id);

        //Task<ReturnBase> DeleteCashReceiptLinesByCashReceiptId(long cashReceiptId);
        Task<ReturnBase> DeleteCashReceiptLineByCashReceiptIds(List<long> cashReceiptIds);

        //Task<ReturnBase> DeleteSalesInvoiceAllocationsByCashReceiptId(long cashReceiptId);
        Task<ReturnBase> DeleteSalesInvoiceAllocationsByCashReceiptIds(List<long> cashReceiptIds);

        //Task<ReturnBase> DeleteCashReceiptAdjustmentsByCashReceiptId(long cashReceiptId);
        Task<ReturnBase> DeleteCashReceiptAdjustmentsCashReceiptIds(List<long> cashReceiptIds);
    }
}