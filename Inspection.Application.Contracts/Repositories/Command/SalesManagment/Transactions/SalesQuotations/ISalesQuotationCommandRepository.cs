using Inspection.Domain.Models.SalesManagment.Transaction.SalesQuotations;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.SalesManagment.Transactions.SalesQuotations
{
    public interface ISalesQuotationCommandRepository : ICommandRepository<SalesQuotation>
    {
        Task<ReturnBase> DeleteById(long id);
        Task<ReturnBase> DeleteSalesQuotationLinesByIds(List<long> ids);
    }
}