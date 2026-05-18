using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionChecklistMoreInformationTemplates;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.InspectionManagement.InspectionChecklistMoreInformationTemplates
{

    public interface IInspectionChecklistMoreInformationTemplateService : IAccountServiceBase
    {
        Task<ReturnBase<InspectionChecklistMoreInformationTemplateDto>> GetAsync(long id);

        Task<ReturnBase<List<InspectionChecklistMoreInformationTemplateDtoByInclude>>> GetListByIncludeAsync(SqlQueryOptions sqlQueryOptions);

        Task<ReturnBase<List<InspectionChecklistMoreInformationTemplateDto>>> GetListAsync();
        Task<ReturnBase<UpdateInspectionChecklistMoreInformationTemplateDto>> CreateAsync(CreateInspectionChecklistMoreInformationTemplateDto input);

        Task<ReturnBase<UpdateInspectionChecklistMoreInformationTemplateDto>> UpdateAsync(long id, UpdateInspectionChecklistMoreInformationTemplateDto input);
        Task<ReturnBase<bool>> DeleteAsync(long id);
    }
}
