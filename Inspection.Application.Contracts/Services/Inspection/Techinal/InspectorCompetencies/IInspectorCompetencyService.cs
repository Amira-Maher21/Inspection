using Inspection.Application.Contracts.Dto.InspectionDto.Techinal.InspectorCompetencyDTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Inspection.Techinal.InspectorCompetencies
{
    public interface IInspectorCompetencyService
    {
        Task<ReturnBase<InspectorCompetencyDto>> Create(InspectorCompetencyCreateDto createDto);
        Task<ReturnBase<InspectorCompetencyDto>> Update(InspectorCompetencyUpdateDto updateDto);
        Task<ReturnBase<InspectorCompetencyDto>> Delete(long id);
        Task<ReturnBase<InspectorCompetencyDto>> GetById(long id);
        Task<ReturnBase<IEnumerable<InspectorCompetencyReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}