using Inspection.Domain.Models.EquipmentManagement.EquipmentMaintenanceAndRepairRecords;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Repositories.Command.EquipmentManagement.EquipmentMaintenanceAndRepairRecords
{
 

    public interface IEquipmentMaintenanceAndRepairRecordCommandRepository : ICommandRepository<EquipmentMaintenanceAndRepairRecord>
    {
        Task<ReturnBase> DeleteByIdAsync(long id);
    }
}
