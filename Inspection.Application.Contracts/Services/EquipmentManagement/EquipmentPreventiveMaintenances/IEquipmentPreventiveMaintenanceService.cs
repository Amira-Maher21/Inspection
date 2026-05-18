using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentPreventiveMaintenances;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Services.EquipmentManagement.EquipmentPreventiveMaintenances
{
   

    public interface IEquipmentPreventiveMaintenanceService : IAccountServiceBase
    {

        Task<ReturnBase<UpdateEquipmentPreventiveMaintenanceDto>> InsertEquipmentPreventiveMaintenanceAsync(CreateEquipmentPreventiveMaintenanceDto insertDto);
        Task<ReturnBase<UpdateEquipmentPreventiveMaintenanceDto>> UpdateEquipmentPreventiveMaintenanceAsync(UpdateEquipmentPreventiveMaintenanceDto updateDto, long id);
        Task<ReturnBase<UpdateEquipmentPreventiveMaintenanceDto>> DeleteEquipmentPreventiveMaintenanceAsync(long id);
        Task<ReturnBase<EquipmentPreventiveMaintenanceDto>> GetEquipmentPreventiveMaintenanceByIdAsync(long id);
        Task<ReturnBase<IEnumerable<EquipmentPreventiveMaintenanceDtoByInclude>>> GetEquipmentPreventiveMaintenanceListAsync(SqlQueryOptions sqlQueryOptions);
        Task<List<EquipmentPreventiveMaintenanceDtoByInclude>> GetListAsync();
        Task<ReturnBase<IEnumerable<EquipmentPreventiveMaintenanceDtoByInclude>>> GetEquipmentPreventiveMaintenanceListByIncludeAsync(SqlQueryOptions sqlQueryOptions);

        //Task<ReturnBase<IEnumerable<EquipmentPreventiveMaintenanceDtoLookUpForNames>>> GetLookUpEquipmentPreventiveMaintenanceForNamesAsync(SqlQueryOptions queryOptions);

    }
}

