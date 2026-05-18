using Inspection.Application.Contracts.Dto.EquipmentManagement.Equipments;
using Inspection.Application.Contracts.Dto.EquipmentManagement.Equipments.EquipmentNew;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.EquipmentManagement.Equipments
{
    public interface IEquipmentService : IAccountServiceBase
    {


        Task<ReturnBase<EquipmentWithChecklistTemplateDto>> GetChecklistTampleteAsync(long id);

        Task<ReturnBase<EquipmentDto>> GetById(long id);
        Task<ReturnBase<EquipmentDto>> Create(CreateEquipmentDto dto);
        Task<ReturnBase<EquipmentDto>> Update(UpdateEquipmentDto dto);
        Task<ReturnBase<EquipmentDto>> Delete(long id);

        //Task<ReturnBase<EquipmentFullDto>> GetEquipmentByIdAsync(long id);
        Task<ReturnBase<object>> GetEquipmentByIdAsync(long id);
        Task<ReturnBase<IEnumerable<EquipmentReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);

        #region
        //Task<ReturnBase<List<EquipmentDto>>> GetExpiringSoonEquipmentsAsync();

        //Task<ReturnBase<bool>> UpdateCalibrationStatusAsync(Guid equipmentId);
        //Task<ReturnBase<List<EquipmentDto>>> GetCalibrationDueSoonAsync();
        //Task<ReturnBase<EquipmentDto>> GetByCustomerIdAsync(long CustomerId);
        #endregion

    }
}