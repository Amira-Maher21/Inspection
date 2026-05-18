using Inspection.Application.Contracts.Dto.Setting.ModuleSettings;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Setting.ModuleSettings
{
    public interface IModuleSettingServise
    {
        Task<ReturnBase<ModuleSettingDto>> Create(ModuleSettingCreateDto dto);
        Task<ReturnBase<ModuleSettingDto>> Update(ModuleSettingUpdateDto dto);
        Task<ReturnBase<ModuleSettingDto>> Delete(long id);

        Task<ReturnBase<ModuleSettingDto>> GetById(long id);

        Task<ReturnBase<IEnumerable<ModuleSettingReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}
