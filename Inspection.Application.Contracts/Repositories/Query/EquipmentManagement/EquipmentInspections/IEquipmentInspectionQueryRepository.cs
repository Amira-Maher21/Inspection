using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentInspections;
using Inspection.Domain.Models.EquipmentManagement.EquipmentInspections;
using NDS.Shared.Application.RepositoryBase;


namespace Inspection.Application.Contracts.Repositories.Query.EquipmentManagement.EquipmentInspections
{
    public interface IEquipmentInspectionQueryRepository : IQueryRepository<EquipmentInspection>
    {
        Task<List<EquipmentInspectionWithNavigationPropertiesDto>> GetListWithDetailsAsync(long equipmentId);
        Task<EquipmentInspection?> GetById(long id);

    }
}
