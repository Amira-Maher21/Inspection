using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentSoftwares;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Services.EquipmentManagement.EquipmentSoftwares
{
 
 
 
    public interface IEquipmentSoftwareService : IAccountServiceBase
    {

        Task<ReturnBase<UpdateEquipmentSoftwareDto>> InsertEquipmentSoftwareAsync(CreateEquipmentSoftwareDto insertDto);
        Task<ReturnBase<UpdateEquipmentSoftwareDto>> UpdateEquipmentSoftwareAsync(UpdateEquipmentSoftwareDto updateDto, long id);
        Task<ReturnBase<UpdateEquipmentSoftwareDto>> DeleteEquipmentSoftwareAsync(long id);
        Task<ReturnBase<EquipmentSoftwareDto>> GetEquipmentSoftwareByIdAsync(long id);
        Task<ReturnBase<IEnumerable<EquipmentSoftwareDtoByInclude>>> GetEquipmentSoftwareListAsync(SqlQueryOptions sqlQueryOptions);
        Task<List<EquipmentSoftwareDtoByInclude>> GetListAsync();
        Task<ReturnBase<IEnumerable<EquipmentSoftwareDtoByInclude>>> GetEquipmentSoftwareListByIncludeAsync(SqlQueryOptions sqlQueryOptions);

        //Task<ReturnBase<IEnumerable<EquipmentSoftwareDtoLookUpForNames>>> GetLookUpEquipmentSoftwareForNamesAsync(SqlQueryOptions queryOptions);

    }
}

