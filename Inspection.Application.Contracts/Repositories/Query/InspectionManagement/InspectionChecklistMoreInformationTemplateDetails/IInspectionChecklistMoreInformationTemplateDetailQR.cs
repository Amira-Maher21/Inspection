using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionChecklistMoreInformationTemplateDetails;
using Inspection.Domain.Models.InspectionManagement.InspectionChecklistMoreInformationTemplateDetails;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.InspectionManagement.InspectionChecklistMoreInformationTemplateDetails
{



    public interface IInspectionChecklistMoreInformationTemplateDetailQR : IQueryRepository<InspectionChecklistMoreInformationTemplateDetail>
    {
        Task<InspectionChecklistMoreInformationTemplateDetail?> GetByIdAsync(long id);
        Task<List<InspectionChecklistMoreInformationTemplateDetailKeyValueDto>?> GetByEquipmentTypeIdAsync(long EquipmentTypeId);
        Task<ReturnBase<IEnumerable<InspectionChecklistMoreInformationTemplateDetailDtoByInclude>>> GetListAsync(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<IEnumerable<InspectionChecklistMoreInformationTemplateDetailDtoByInclude>>> GetListIncludeNameAsync(SqlQueryOptions sqlQueryOptions);

    }
}
