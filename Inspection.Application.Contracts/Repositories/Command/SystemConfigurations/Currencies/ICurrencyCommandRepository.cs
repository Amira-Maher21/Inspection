using Inspection.Domain.Models.SystemConfigurations.Currencies;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.SystemConfigurations.Currencies
{
    public interface ICurrencyCommandRepository : ICommandRepository<Currency>
    {
        Task<ReturnBase> DeleteById(long id);
    }
}