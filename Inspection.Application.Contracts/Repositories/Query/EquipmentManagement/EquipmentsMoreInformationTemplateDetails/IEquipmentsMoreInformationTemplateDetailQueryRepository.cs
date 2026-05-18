using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentsMoreInformationTemplateDetails;
using Inspection.Domain.Models.EquipmentManagement.EquipmentsMoreInformationTemplateDetails;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.EquipmentManagement.EquipmentsMoreInformationTemplateDetails
{



    public interface IEquipmentsMoreInformationTemplateDetailQueryRepository : IQueryRepository<EquipmentsMoreInformationTemplateDetail>
    {
        Task<EquipmentsMoreInformationTemplateDetail?> GetByIdAsync(long id);
        Task<List<EquipmentMoreInformationTemplateDetailsKeyValueDto>?> GetByEquipmentTypeIdAsync(long EquipmentTypeId);
        Task<ReturnBase<IEnumerable<EquipmentsMoreInformationTemplateDetailDtoByInclude>>> GetListAsync(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<IEnumerable<EquipmentsMoreInformationTemplateDetailDtoByInclude>>> GetListIncludeNameAsync(SqlQueryOptions sqlQueryOptions);
        //Task<ReturnBase<IEnumerable<EquipmentsMoreInformationTemplateDetailDtoByInclude>>> GetLookUpEquipmentsMoreInformationTemplateDetailForNamesAsync(SqlQueryOptions queryOptions);

    }
}
