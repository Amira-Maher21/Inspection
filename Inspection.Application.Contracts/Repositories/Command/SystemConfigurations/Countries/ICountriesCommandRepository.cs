using Inspection.Domain.Models.SystemConfigurations.Countriess;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.SystemConfigurations.Countries
{
    public interface ICountriesCommandRepository : ICommandRepository<Country>
    {
        Task<ReturnBase> DeleteById(long id);


    }
}
