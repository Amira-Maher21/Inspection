using Inspection.Application.Contracts.Dto.EquipmentManagement.Equipments;
using Inspection.Application.Contracts.Dto.EquipmentManagement.Equipments.EquipmentNew;
using Inspection.Domain.Models.EquipmentManagement.Equipments;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.EquipmentManagement.Equipments
{
    public interface IEquipmentQueryRepository : IQueryRepository<Equipment>
    {
        Task<Equipment?> GetByIdAsync(long id);

        Task<ReturnBase<IEnumerable<EquipmentReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
        //Task<EquipmentFullDto?> GetEquipmentByIdAsync(long id);
        Task<object?> GetEquipmentByIdAsync(long id);

        Task<ReturnBase<EquipmentWithChecklistTemplateDto>> GetChecklistTemplateByEquipmentAsync(long equipmentId, string TanentId, long CompanyId);
    }
}
