using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentsMoreInformationTemplateDetails;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.EquipmentManagement.EquipmentsMoreInformationTemplateDetails
{

    public interface IEquipmentsMoreInformationTemplateDetailService : IAccountServiceBase
    {

        Task<ReturnBase<UpdateEquipmentsMoreInformationTemplateDetailDto>> InsertEquipmentsMoreInformationTemplateDetailAsync(CreateEquipmentsMoreInformationTemplateDetailDto insertDto);
        Task<ReturnBase<UpdateEquipmentsMoreInformationTemplateDetailDto>> UpdateEquipmentsMoreInformationTemplateDetailAsync(UpdateEquipmentsMoreInformationTemplateDetailDto updateDto, long id);
        Task<ReturnBase<UpdateEquipmentsMoreInformationTemplateDetailDto>> DeleteEquipmentsMoreInformationTemplateDetailAsync(long id);
        Task<ReturnBase<EquipmentsMoreInformationTemplateDetailDto>> GetEquipmentsMoreInformationTemplateDetailByIdAsync(long id);
        Task<ReturnBase<List<EquipmentMoreInformationTemplateDetailsKeyValueDto>>> GetByEquipmentTypeIdAsync(long EquipmentTypeId);
        Task<ReturnBase<IEnumerable<EquipmentsMoreInformationTemplateDetailDtoByInclude>>> GetEquipmentsMoreInformationTemplateDetailListAsync(SqlQueryOptions sqlQueryOptions);
        Task<List<EquipmentsMoreInformationTemplateDetailDtoByInclude>> GetListAsync();
        Task<ReturnBase<IEnumerable<EquipmentsMoreInformationTemplateDetailDtoByInclude>>> GetEquipmentsMoreInformationTemplateDetailListByIncludeAsync(SqlQueryOptions sqlQueryOptions);

        //Task<ReturnBase<IEnumerable<EquipmentsMoreInformationTemplateDetailDtoLookUpForNames>>> GetLookUpEquipmentsMoreInformationTemplateDetailForNamesAsync(SqlQueryOptions queryOptions);

    }
}
