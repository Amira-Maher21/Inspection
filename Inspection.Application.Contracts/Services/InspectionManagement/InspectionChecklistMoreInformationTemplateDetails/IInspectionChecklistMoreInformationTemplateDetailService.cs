using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionChecklistMoreInformationTemplateDetails;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.InspectionManagement.InspectionChecklistMoreInformationTemplateDetails
{


    public interface IInspectionChecklistMoreInformationTemplateDetailService : IAccountServiceBase
    {

        Task<ReturnBase<UpdateInspectionChecklistMoreInformationTemplateDetailDto>> InsertInspectionChecklistMoreInformationTemplateDetailAsync(CreateInspectionChecklistMoreInformationTemplateDetailDto insertDto);
        Task<ReturnBase<UpdateInspectionChecklistMoreInformationTemplateDetailDto>> UpdateInspectionChecklistMoreInformationTemplateDetailAsync(UpdateInspectionChecklistMoreInformationTemplateDetailDto updateDto, long id);
        Task<ReturnBase<UpdateInspectionChecklistMoreInformationTemplateDetailDto>> DeleteInspectionChecklistMoreInformationTemplateDetailAsync(long id);
        Task<ReturnBase<InspectionChecklistMoreInformationTemplateDetailDto>> GetInspectionChecklistMoreInformationTemplateDetailByIdAsync(long id);
        Task<ReturnBase<List<InspectionChecklistMoreInformationTemplateDetailKeyValueDto>>> GetByEquipmentTypeIdAsync(long EquipmentTypeId);
        Task<ReturnBase<IEnumerable<InspectionChecklistMoreInformationTemplateDetailDtoByInclude>>> GetInspectionChecklistMoreInformationTemplateDetailListAsync(SqlQueryOptions sqlQueryOptions);
        Task<List<InspectionChecklistMoreInformationTemplateDetailDtoByInclude>> GetListAsync();
        Task<ReturnBase<IEnumerable<InspectionChecklistMoreInformationTemplateDetailDtoByInclude>>> GetInspectionChecklistMoreInformationTemplateDetailListByIncludeAsync(SqlQueryOptions sqlQueryOptions);


    }
}

