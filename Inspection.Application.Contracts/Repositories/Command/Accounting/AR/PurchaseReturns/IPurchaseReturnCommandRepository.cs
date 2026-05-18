using Inspection.Domain.Models.Accounting.AR.PurchaseReturns;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Accounting.AR.PurchaseReturns
{
    public interface IPurchaseReturnCommandRepository : ICommandRepository<PurchaseReturn>
    {
        Task<ReturnBase> DeleteById(long id);

        Task<ReturnBase> DeletePurchaseReturnLinesByPurchaseReturnIds(List<long> PurchaseReturnIds);

        Task<ReturnBase> DeletePurchaseReturnAdjustmentsByPurchaseReturnIds(List<long> PurchaseReturnIds);
    }
}
