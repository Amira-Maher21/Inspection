using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentCategorys;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Services.EquipmentManagement.EquipmentCategorys
{


    public interface IEquipmentCategoryService : IAccountServiceBase
    {

        Task<ReturnBase<UpdateEquipmentCategoryDto>> InsertEquipmentCategoryAsync(CreateEquipmentCategoryDto insertDto);
        Task<ReturnBase<UpdateEquipmentCategoryDto>> UpdateEquipmentCategoryAsync(UpdateEquipmentCategoryDto updateDto, long id);
        Task<ReturnBase<bool>> DeleteEquipmentCategoryAsync(long id);
        Task<ReturnBase<EquipmentCategoryDto>> GetEquipmentCategoryByIdAsync(long id);
        Task<ReturnBase<IEnumerable<EquipmentCategoryDtoByInclude>>> GetEquipmentCategoryListAsync(SqlQueryOptions sqlQueryOptions);
        Task<List<EquipmentCategoryDtoByInclude>> GetListAsync();
        Task<ReturnBase<IEnumerable<EquipmentCategoryDtoByInclude>>> GetEquipmentCategoryListByIncludeAsync(SqlQueryOptions sqlQueryOptions);

        Task<ReturnBase<IEnumerable<EquipmentCategoryDtoLookUpForNames>>> GetLookUpEquipmentCategoryForNamesAsync(SqlQueryOptions queryOptions);

    }
}
