using Inspection.Domain.Models.EquipmentManagement.EquipmentsMoreInformationTemplateDetails;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.EquipmentManagement.EquipmentsMoreInformationTemplateDetails
{


    public interface IEquipmentsMoreInformationTemplateDetailCommandRepository : ICommandRepository<EquipmentsMoreInformationTemplateDetail>
    {
        Task<ReturnBase> DeleteByIdAsync(long id);
    }
}
