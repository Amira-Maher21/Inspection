using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentsMoreInformations;
using Inspection.Application.Contracts.Dto.MenuManagement.BranchF;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Services.EquipmentManagement.EquipmentsMoreInformations
{
    public interface IEquipmentsMoreInformationService : IAccountServiceBase
    {
        Task<ReturnBase<EquipmentsMoreInformationDto>> GetAsync(long id);

        Task<ReturnBase<List<EquipmentsMoreInformationIncludeDto>>> GetListByIncludeAsync(SqlQueryOptions sqlQueryOptions);
       
        Task<ReturnBase<List<EquipmentsMoreInformationDto>>> GetListAsync();
        Task<ReturnBase<UpdateEquipmentsMoreInformationDto>> CreateAsync(CreateEquipmentsMoreInformationDto input);

        Task<ReturnBase<UpdateEquipmentsMoreInformationDto>> UpdateAsync(long id, UpdateEquipmentsMoreInformationDto input);
        Task<ReturnBase<bool>> DeleteAsync(long id);
    }
}
