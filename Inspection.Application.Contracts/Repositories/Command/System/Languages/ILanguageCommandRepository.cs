using Inspection.Domain.Models.System.Languages;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.System.Languages
{

    public interface ILanguageCommandRepository : ICommandRepository<Language>
    {
        Task<ReturnBase> DeleteById(string LocaleCode);

    }
}
