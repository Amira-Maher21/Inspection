using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentInspections;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.EquipmentManagement.EquipmentInspections
{
    public interface IEquipmentInspectionService : IAccountServiceBase
    {
        Task<List<EquipmentInspectionDto>> GetListByEquipmentIdAsync(long equipmentId);
        Task<EquipmentInspectionDto> CreateAsync(CreateEquipmentInspectionDto input);
        Task<ReturnBase<EquipmentInspectionDto>> GetById(long id);


    }
}
