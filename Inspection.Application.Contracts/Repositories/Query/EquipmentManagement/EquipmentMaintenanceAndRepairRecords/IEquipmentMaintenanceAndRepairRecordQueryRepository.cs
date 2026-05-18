using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentMaintenanceAndRepairRecords;
using Inspection.Domain.Models.EquipmentManagement.EquipmentMaintenanceAndRepairRecords;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Repositories.Query.EquipmentManagement.EquipmentMaintenanceAndRepairRecords
{
 
    public interface IEquipmentMaintenanceAndRepairRecordQueryRepository : IQueryRepository<EquipmentMaintenanceAndRepairRecord>
    {
        Task<EquipmentMaintenanceAndRepairRecord?> GetByIdAsync(long id);
        Task<ReturnBase<IEnumerable<EquipmentMaintenanceAndRepairRecordDtoByInclude>>> GetListAsync(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<IEnumerable<EquipmentMaintenanceAndRepairRecordDtoByInclude>>> GetListIncludeNameAsync(SqlQueryOptions sqlQueryOptions);
        //Task<ReturnBase<IEnumerable<EquipmentMaintenanceAndRepairRecordDtoByInclude>>> GetLookUpEquipmentMaintenanceAndRepairRecordForNamesAsync(SqlQueryOptions queryOptions);

    }
}
