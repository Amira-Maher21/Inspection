using Inspection.Domain.Models.Accounting.PR.PurchaseInvoices;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Accounting.PR.PurchaseInvoices
{
    public interface IPurchaseInvoiceCommandRepository : ICommandRepository<PurchaseInvoice>
    {
        // Delete PurchaseInvoice by Id
        Task<ReturnBase> DeleteById(long id);

        // ===== Invoice Lines =====
        Task<ReturnBase> DeleteInvoiceLinesByPurchaseInvoiceId(long purchaseInvoiceId);
        Task<ReturnBase> DeleteInvoiceLinesByIds(List<long> ids);

        // ===== Invoice Adjustments =====
        Task<ReturnBase> DeleteAdjustmentsByPurchaseInvoiceId(long purchaseInvoiceId);
        Task<ReturnBase> DeleteAdjustmentsByIds(List<long> ids);
    }
}