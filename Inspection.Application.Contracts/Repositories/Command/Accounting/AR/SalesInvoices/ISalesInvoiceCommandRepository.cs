using Inspection.Domain.Models.Accounting.AR.SalesInvoices;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Accounting.AR.SalesInvoices
{
    public interface ISalesInvoiceCommandRepository : ICommandRepository<SalesInvoice>
    {
        Task<ReturnBase> DeleteById(long SalesInvoiceId);


        // ===== SalesInvoiceLines =====
        Task<ReturnBase> DeleteSalesInvoiceLinesBySalesInvoiceId(long SalesInvoiceId);
        Task<ReturnBase> DeleteSalesInvoiceLinesByIds(List<long> ids);

        // ===== SalesInvoiceSalesAdjustments =====  
        Task<ReturnBase> DeleteSalesInvoiceSalesAdjustmentsByAdjustmentId(long SalesInvoiceId);
        Task<ReturnBase> DeleteSalesInvoiceSalesAdjustmentsByIds(List<long> ids);


        // ===== SalesInvoiceSalesPersons =====
        Task<ReturnBase> DeleteSalesInvoiceSalesPersonsBySalesPersonId(long SalesInvoiceId);
        Task<ReturnBase> DeleteSalesInvoiceSalesPersonsByIds(List<long> ids);
    }
}
