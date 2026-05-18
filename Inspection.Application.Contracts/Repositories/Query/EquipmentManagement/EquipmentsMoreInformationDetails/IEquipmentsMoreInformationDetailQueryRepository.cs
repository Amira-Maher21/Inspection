using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentsMoreInformationDetails;
using Inspection.Domain.Models.EquipmentManagement.EquipmentsMoreInformationDetails;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.EquipmentManagement.EquipmentsMoreInformationDetails
{


    public interface IEquipmentsMoreInformationDetailQueryRepository : IQueryRepository<EquipmentsMoreInformationDetail>
    {
        Task<EquipmentsMoreInformationDetail?> GetByIdAsync(long id);
        Task<List<EquipmentMoreInformationDetailsKeyValueDto>?> GetByEquipmentTypeIdAsync(long EquipmentTypeId);
        Task<ReturnBase<IEnumerable<EquipmentsMoreInformationDetailDtoByInclude>>> GetListAsync(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<IEnumerable<EquipmentsMoreInformationDetailDtoByInclude>>> GetListIncludeNameAsync(SqlQueryOptions sqlQueryOptions);

    }
}
