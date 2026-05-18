using Inspection.Application.Contracts.Dto.InspectionDto.Techinal.InspectorDTOs;
using Inspection.Application.Contracts.Dto.SharedDtos;
using Inspection.Domain.Models.Inspection.Techinal.Inspectors;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Inspection.Techinal.Inspectors
{
    public interface IInspectorService
    {
        Task<ReturnBase<InspectorDto>> Create(InspectorCreateDto createDto);
        Task<ReturnBase<InspectorDto>> Update(InspectorUpdateDto updateDto);
        Task<ReturnBase<InspectorDto>> Delete(long id);
        Task<ReturnBase<InspectorDto>> GetById(long id);
        Task<Inspector> GetByCode(string code);
        Task<ReturnBase<IEnumerable<InspectorReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<ImportResultDto>> ImportInspectors(ExcelImportRequestDto dto);
        Task<ReturnBase<FileResultDto>> DownloadTemplate();

        Task<ReturnBase<IEnumerable<InspectorGetListDto>>> GetListAsync();

    }
}
