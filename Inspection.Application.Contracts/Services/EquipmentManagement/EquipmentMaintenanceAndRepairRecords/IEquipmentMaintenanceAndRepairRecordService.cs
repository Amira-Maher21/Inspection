using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentMaintenanceAndRepairRecords;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Services.EquipmentManagement.EquipmentMaintenanceAndRepairRecords
{
 
    public interface IEquipmentMaintenanceAndRepairRecordService : IAccountServiceBase
    {

        Task<ReturnBase<UpdateEquipmentMaintenanceAndRepairRecordDto>> InsertEquipmentMaintenanceAndRepairRecordAsync(CreateEquipmentMaintenanceAndRepairRecordDto insertDto);
        Task<ReturnBase<UpdateEquipmentMaintenanceAndRepairRecordDto>> UpdateEquipmentMaintenanceAndRepairRecordAsync(UpdateEquipmentMaintenanceAndRepairRecordDto updateDto, long id);
        Task<ReturnBase<UpdateEquipmentMaintenanceAndRepairRecordDto>> DeleteEquipmentMaintenanceAndRepairRecordAsync(long id);
        Task<ReturnBase<EquipmentMaintenanceAndRepairRecordDto>> GetEquipmentMaintenanceAndRepairRecordByIdAsync(long id);
        Task<ReturnBase<IEnumerable<EquipmentMaintenanceAndRepairRecordDtoByInclude>>> GetEquipmentMaintenanceAndRepairRecordListAsync(SqlQueryOptions sqlQueryOptions);
        Task<List<EquipmentMaintenanceAndRepairRecordDtoByInclude>> GetListAsync();
        Task<ReturnBase<IEnumerable<EquipmentMaintenanceAndRepairRecordDtoByInclude>>> GetEquipmentMaintenanceAndRepairRecordListByIncludeAsync(SqlQueryOptions sqlQueryOptions);

        //Task<ReturnBase<IEnumerable<EquipmentMaintenanceAndRepairRecordDtoLookUpForNames>>> GetLookUpEquipmentMaintenanceAndRepairRecordForNamesAsync(SqlQueryOptions queryOptions);

    }
}


