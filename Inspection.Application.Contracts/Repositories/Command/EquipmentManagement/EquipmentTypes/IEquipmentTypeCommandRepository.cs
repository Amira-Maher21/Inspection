using Inspection.Domain.Models.EquipmentManagement.EquipmentTypes;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Repositories.Command.EquipmentManagement.EquipmentTypes
{
    public interface IEquipmentTypeCommandRepository : ICommandRepository<EquipmentType>
    {
        Task<ReturnBase> DeleteByIdAsync(long id);
    }
}
