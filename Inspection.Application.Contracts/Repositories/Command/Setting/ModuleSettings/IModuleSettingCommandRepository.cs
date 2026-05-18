using Inspection.Domain.Models.Seeting.ModuleSettings;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Setting.ModuleSettings
{
    public interface IModuleSettingCommandRepository : ICommandRepository<ModuleSetting>
    {
        Task<ReturnBase> DeleteById(long id);

    }
}
