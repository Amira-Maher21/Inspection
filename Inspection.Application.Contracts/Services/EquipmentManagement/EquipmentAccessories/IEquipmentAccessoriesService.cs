using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentAccessories;
 using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Services.EquipmentManagement.EquipmentAccessories
{
   public interface IEquipmentAccessoriesService : IAccountServiceBase
    {

        Task<ReturnBase<UpdateEquipmentAccessoryDto>> InsertEquipmentAccessoryAsync(CreateEquipmentAccessoryDto insertDto);
        Task<ReturnBase<UpdateEquipmentAccessoryDto>> UpdateEquipmentAccessoryAsync(UpdateEquipmentAccessoryDto updateDto, long id);
        Task<ReturnBase<UpdateEquipmentAccessoryDto>> DeleteEquipmentAccessoryAsync(long id);
        Task<ReturnBase<EquipmentAccessoryDto>> GetEquipmentAccessoryByIdAsync(long id);
        Task<ReturnBase<IEnumerable<EquipmentAccessoryDtoByInclude>>> GetEquipmentAccessoryListAsync(SqlQueryOptions sqlQueryOptions);
        Task<List<EquipmentAccessoryDtoByInclude>> GetListAsync();
        Task<ReturnBase<IEnumerable<EquipmentAccessoryDtoByInclude>>> GetEquipmentAccessoryListByIncludeAsync(SqlQueryOptions sqlQueryOptions);

        //Task<ReturnBase<IEnumerable<EquipmentAccessoryDtoLookUpForNames>>> GetLookUpEquipmentAccessoryForNamesAsync(SqlQueryOptions queryOptions);

    }
}

