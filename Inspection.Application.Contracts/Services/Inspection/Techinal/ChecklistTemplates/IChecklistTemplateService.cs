using Inspection.Application.Contracts.Dto.InspectionDto.Techinal.ChecklistTemplates;
using Inspection.Application.Contracts.Dto.SharedDtos;
using Inspection.Domain.Models.Inspection.Techinal.ChecklistTemplates;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Inspection.Techinal.ChecklistTemplates
{
    public interface IChecklistTemplateService
    {
        Task<ReturnBase<ChecklistTemplateDto>> Create(ChecklistTemplateCreateDto createDto);
        Task<ReturnBase<ChecklistTemplateDto>> Update(ChecklistTemplateUpdateDto updateDto);
        Task<ReturnBase<ChecklistTemplateDto>> Delete(long id);
        Task<ReturnBase<ChecklistTemplateDto>> GetById(long id);
        Task<ChecklistTemplate> GetByCode(string code);
        Task<ReturnBase<IEnumerable<ChecklistTemplateSearchReturnDto>>> Search(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<ImportResultDto>> ImportChecklistTemplate(ExcelImportRequestDto dto);
        Task<ReturnBase<FileResultDto>> DownloadTemplate();
    }
}
