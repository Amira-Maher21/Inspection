using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionChecklistMoreInformationDetails;
using Inspection.Domain.Models.InspectionManagement.InspectionChecklistMoreInformationDetails;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.InspectionManagement.InspectionChecklistMoreInformationDetails
{



    public interface IInspectionChecklistMoreInformationDetailQR : IQueryRepository<InspectionChecklistMoreInformationDetail>
    {
        Task<InspectionChecklistMoreInformationDetail?> GetByIdAsync(long id);
        Task<List<InspectionChecklistMoreInformationDetailsKeyValueDto>?> GetByEquipmentTypeIdAsync(long EquipmentTypeId);
        Task<ReturnBase<IEnumerable<InspectionChecklistMoreInformationDetailDtoByInclude>>> GetListAsync(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<IEnumerable<InspectionChecklistMoreInformationDetailDtoByInclude>>> GetListIncludeNameAsync(SqlQueryOptions sqlQueryOptions);

    }
}
