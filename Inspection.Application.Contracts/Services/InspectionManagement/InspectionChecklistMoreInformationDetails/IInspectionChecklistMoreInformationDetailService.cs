using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionChecklistMoreInformationDetails;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.InspectionManagement.InspectionChecklistMoreInformationDetails
{



    public interface IInspectionChecklistMoreInformationDetailService : IAccountServiceBase
    {

        Task<ReturnBase<UpdateInspectionChecklistMoreInformationDetailDto>> InsertInspectionChecklistMoreInformationDetailAsync(CreateInspectionChecklistMoreInformationDetailDto insertDto);
        Task<ReturnBase<UpdateInspectionChecklistMoreInformationDetailDto>> UpdateInspectionChecklistMoreInformationDetailAsync(UpdateInspectionChecklistMoreInformationDetailDto updateDto, long id);
        Task<ReturnBase<UpdateInspectionChecklistMoreInformationDetailDto>> DeleteInspectionChecklistMoreInformationDetailAsync(long id);
        Task<ReturnBase<InspectionChecklistMoreInformationDetailDto>> GetInspectionChecklistMoreInformationDetailByIdAsync(long id);
        Task<ReturnBase<List<InspectionChecklistMoreInformationDetailsKeyValueDto>>> GetByEquipmentTypeIdAsync(long EquipmentTypeId);
        Task<ReturnBase<IEnumerable<InspectionChecklistMoreInformationDetailDtoByInclude>>> GetInspectionChecklistMoreInformationDetailListAsync(SqlQueryOptions sqlQueryOptions);
        Task<List<InspectionChecklistMoreInformationDetailDtoByInclude>> GetListAsync();
        Task<ReturnBase<IEnumerable<InspectionChecklistMoreInformationDetailDtoByInclude>>> GetInspectionChecklistMoreInformationDetailListByIncludeAsync(SqlQueryOptions sqlQueryOptions);


    }
}
