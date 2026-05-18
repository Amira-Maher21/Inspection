using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionChecklistMoreInformationTemplates;
using Inspection.Domain.Models.InspectionManagement.InspectionChecklistMoreInformationTemplates;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;

namespace Inspection.Application.Contracts.Repositories.Query.InspectionManagement.InspectionChecklistMoreInformationTemplates
{

    public interface IInspectionChecklistMoreInformationTemplateQueryRepository : IQueryRepository<InspectionChecklistMoreInformationTemplate>
    {
        Task<InspectionChecklistMoreInformationTemplate?> GetByIdAsync(long id);
        Task<IEnumerable<InspectionChecklistMoreInformationTemplateDtoByInclude?>> GetListByIncludeAsync(SqlQueryOptions sqlQueryOptions);

    }
}
