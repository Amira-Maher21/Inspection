using Inspection.Domain.Models.EquipmentManagement.EquipmentPreventiveMaintenances;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Repositories.Command.EquipmentManagement.EquipmentPreventiveMaintenances
{
 
    public interface IEquipmentPreventiveMaintenanceCommandRepository : ICommandRepository<EquipmentPreventiveMaintenance>
    {
        Task<ReturnBase> DeleteByIdAsync(long id);
    }
}
