using Inspection.Application.Contracts.Dto.Setting.ModuleSettings;
using Inspection.Domain.Models.Seeting.ModuleSettings;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Setting.ModuleSettings
{
    public interface IModuleSettingQueryRepository
    {
        Task<ModuleSetting?> GetById(long id);
        Task<ReturnBase<IEnumerable<ModuleSettingReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}
