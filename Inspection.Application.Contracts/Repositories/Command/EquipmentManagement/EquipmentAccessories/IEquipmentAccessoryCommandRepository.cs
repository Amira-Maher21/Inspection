using Inspection.Domain.Models.EquipmentManagement.EquipmentAccessories;
 using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Repositories.Command.EquipmentManagement.EquipmentAccessories
{
   
    public interface IEquipmentAccessoryCommandRepository : ICommandRepository<EquipmentAccessory>
    {
        Task<ReturnBase> DeleteByIdAsync(long id);
    }
}
