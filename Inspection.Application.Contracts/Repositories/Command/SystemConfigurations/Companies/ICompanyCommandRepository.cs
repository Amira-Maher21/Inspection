using Inspection.Domain.Models.SystemConfigurations.Companies;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.SystemConfigurations.Companies
{
    public interface ICompanyCommandRepository : ICommandRepository<Company>
    {
        Task<ReturnBase> DeleteById(long id);
    }
}