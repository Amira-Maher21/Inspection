using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentsMoreInformationTemplates;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.EquipmentManagement.EquipmentsMoreInformationTemplateTemplates
{


    public interface IEquipmentsMoreInformationTemplateService : IAccountServiceBase
    {
        Task<ReturnBase<EquipmentsMoreInformationTemplateDto>> GetAsync(long id);

        //Task<ReturnBase<List<EquipmentsMoreInformationTemplateDtoByInclude>>> GetListByIncludeAsync(SqlQueryOptions sqlQueryOptions);

        Task<ReturnBase<List<EquipmentsMoreInformationTemplateDto>>> GetListAsync();
        Task<ReturnBase<UpdateEquipmentsMoreInformationTemplateDto>> CreateAsync(CreateEquipmentsMoreInformationTemplateDto input);

        Task<ReturnBase<UpdateEquipmentsMoreInformationTemplateDto>> UpdateAsync(long id, UpdateEquipmentsMoreInformationTemplateDto input);
        Task<ReturnBase<bool>> DeleteAsync(long id);


        Task<ReturnBase<IEnumerable<EquipmentsMoreInformationTemplateReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);

    }
}
