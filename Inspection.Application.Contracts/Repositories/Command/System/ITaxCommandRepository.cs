using Inspection.Domain.Models.System.Taxes;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.System
{
    public interface ITaxTypeCommandRepository : ICommandRepository<TaxType>
    {
        Task<ReturnBase> DeleteById(long id);

    }
}
