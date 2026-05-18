using Inspection.Domain.Models.EquipmentManagement.EquipmentInspections;
using Inspection.Domain.Models.EquipmentManagement.Equipments;
using NDS.Shared.Application.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Repositories.Command.EquipmentManagement.EquipmentInspections
{
    public interface IEquipmentInspectionCommandRepository : ICommandRepository<EquipmentInspection>
    {
    }
}
