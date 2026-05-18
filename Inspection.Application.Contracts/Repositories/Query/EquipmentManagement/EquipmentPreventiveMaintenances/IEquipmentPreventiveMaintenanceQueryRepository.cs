using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentPreventiveMaintenances;
using Inspection.Domain.Models.EquipmentManagement.EquipmentPreventiveMaintenances;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Repositories.Query.EquipmentManagement.EquipmentPreventiveMaintenances
{
 

    public interface IEquipmentPreventiveMaintenanceQueryRepository : IQueryRepository<EquipmentPreventiveMaintenance>
    {
        Task<EquipmentPreventiveMaintenance?> GetByIdAsync(long id);
        Task<ReturnBase<IEnumerable<EquipmentPreventiveMaintenanceDtoByInclude>>> GetListAsync(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<IEnumerable<EquipmentPreventiveMaintenanceDtoByInclude>>> GetListIncludeNameAsync(SqlQueryOptions sqlQueryOptions);
        //Task<ReturnBase<IEnumerable<EquipmentPreventiveMaintenanceDtoByInclude>>> GetLookUpEquipmentPreventiveMaintenanceForNamesAsync(SqlQueryOptions queryOptions);

    }
}
