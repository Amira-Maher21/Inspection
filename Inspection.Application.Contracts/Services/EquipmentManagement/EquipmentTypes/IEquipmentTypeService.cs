using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentTypes;
using Inspection.Domain.Models.EquipmentManagement.EquipmentTypes;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;


namespace Inspection.Application.Contracts.Services.EquipmentManagement.EquipmentTypes
{

    public interface IEquipmentTypeService : IAccountServiceBase
    {

        Task<ReturnBase<UpdateEquipmentTypeDto>> InsertEquipmentTypeAsync(CreateEquipmentTypeDto insertDto);
        Task<ReturnBase<UpdateEquipmentTypeDto>> UpdateEquipmentTypeAsync(UpdateEquipmentTypeDto updateDto, long id);
        Task<ReturnBase<bool>> DeleteEquipmentTypeAsync(long id);
        Task<ReturnBase<EquipmentTypeDto>> GetEquipmentTypeByIdAsync(long id);
        Task<ReturnBase<IEnumerable<EquipmentTypeDtoByInclude>>> GetEquipmentTypeListAsync(SqlQueryOptions sqlQueryOptions);
        Task<List<EquipmentTypeDtoByInclude>> GetListAsync();
        Task<ReturnBase<IEnumerable<EquipmentTypeDtoByInclude>>> GetEquipmentTypeListByIncludeAsync(SqlQueryOptions sqlQueryOptions);
        Task<EquipmentType> GetByCode(string code);
        Task<ReturnBase<IEnumerable<EquipmentTypeDtoLookUpForNames>>> GetLookUpEquipmentTypeForNamesAsync(SqlQueryOptions queryOptions);

    }
}
