using Inspection.Application.Contracts.Dto.InspectionDto.Techinal.Checklists;
using Inspection.Application.Contracts.Dto.SharedDtos;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Inspection.Techinal.Checklists
{
    public interface IChecklistService
    {
        Task<ReturnBase<ChecklistDto>> Create(ChecklistCreateDto createDto);
        Task<ReturnBase<ChecklistDto>> Update(ChecklistUpdateDto updateDto);
        Task<ReturnBase<ChecklistDto>> Delete(long id);
        Task<ReturnBase<ChecklistDto>> GetById(long id);
        // Task<ReturnBase<ChecklistDto>> GetByCode(String Name);

        Task<ReturnBase<IEnumerable<ChecklistSearchReturnDto>>> Search(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<ImportResultDto>> ImportChecklist(ExcelImportRequestDto dto);
        Task<ReturnBase<FileResultDto>> DownloadTemplate();
    }
}
