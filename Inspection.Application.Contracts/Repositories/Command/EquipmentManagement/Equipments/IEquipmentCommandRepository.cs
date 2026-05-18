using Inspection.Domain.Models.EquipmentManagement.Equipments;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.EquipmentManagement.Equipments
{
    public interface IEquipmentCommandRepository : ICommandRepository<Equipment>
    {
        Task<ReturnBase> DeleteById(long id);

    }
}
