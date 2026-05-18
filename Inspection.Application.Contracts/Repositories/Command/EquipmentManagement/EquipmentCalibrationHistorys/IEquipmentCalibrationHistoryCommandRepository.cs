using Inspection.Domain.Models.EquipmentManagement.EquipmentCalibrationHistorys;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Repositories.Command.EquipmentManagement.EquipmentCalibrationHistorys
{
 

    public interface IEquipmentCalibrationHistoryCommandRepository  : ICommandRepository<EquipmentCalibrationHistory>
    {
        Task<ReturnBase> DeleteByIdAsync(long id);
    }
}

