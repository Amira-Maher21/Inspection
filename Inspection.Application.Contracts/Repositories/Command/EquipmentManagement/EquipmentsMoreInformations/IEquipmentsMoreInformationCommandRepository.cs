using Inspection.Domain.Models.EquipmentManagement.Equipments;
using Inspection.Domain.Models.EquipmentManagement.EquipmentsMoreInfo;
using NDS.Shared.Application.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Repositories.Command.EquipmentManagement.EquipmentsMoreInformations
{
    public interface IEquipmentsMoreInformationCommandRepository : ICommandRepository<EquipmentsMoreInformation>
    {
    }
}
