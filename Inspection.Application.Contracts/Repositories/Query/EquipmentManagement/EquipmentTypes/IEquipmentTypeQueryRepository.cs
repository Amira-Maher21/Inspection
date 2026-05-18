using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentTypes;
using Inspection.Domain.Models.EquipmentManagement.EquipmentTypes;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.InspectionManagement.EquipmentTypes
{
    public interface IEquipmentTypeQueryRepository : IQueryRepository<EquipmentType>
    {
        Task<EquipmentType?> GetByIdAsync(long id);
        Task<EquipmentType?> GetByCode(string code);
        Task<ReturnBase<IEnumerable<EquipmentTypeDtoByInclude>>> GetListAsync(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<IEnumerable<EquipmentTypeDtoByInclude>>> GetListIncludeNameAsync(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<IEnumerable<EquipmentTypeDtoByInclude>>> GetLookUpEquipmentTypeForNamesAsync(SqlQueryOptions queryOptions);

    }
}
