using Inspection.Domain.Models.SalesManagment.Setup.SalesPersons;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.SalesManagment.Setup.SalesPersons
{
    public interface ISalesPersonCommandRepository : ICommandRepository<SalesPerson>
    {
        Task<ReturnBase> DeleteById(long id);
    }
}
