using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentsMoreInformationTemplates;
using Inspection.Domain.Models.EquipmentManagement.EquipmentsMoreInfoTemplates;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.EquipmentManagement.EquipmentsMoreInformationTemplateTemplates
{


    public interface IEquipmentsMoreInformationTemplateQueryRepository : IQueryRepository<EquipmentsMoreInformationTemplate>
    {
        Task<EquipmentsMoreInformationTemplate?> GetByIdAsync(long id);


        Task<ReturnBase<IEnumerable<EquipmentsMoreInformationTemplateReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);

    }
}
