using Inspection.Domain.Models.Accounting.PR.MasterData.Suppliers;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Accounting.PR.MasterData.Suppliers
{
    public interface ISupplierCommandRepository : ICommandRepository<Supplier>
    {
        // Hard Delete by Supplier Id
        Task<ReturnBase> DeleteById(long supplierId);

        // Delete related entities
        Task<ReturnBase> DeleteSupplierContactsBySupplierId(long supplierId);
        Task<ReturnBase> DeleteSupplierContactsByIds(List<long> ids);


    }
}
