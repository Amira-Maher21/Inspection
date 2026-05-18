using Inspection.Application.Contracts.Dto.InspectionDto.Techinal.InspectionStandards;
using Inspection.Domain.Models.Inspection.Techinal.InspectionStandards;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Inspection.Techinal.InspectionStandards
{
    public interface IInspectionStandardService
    {
        Task<ReturnBase<InspectionStandardDto>> Create(InspectionStandardCreateDto createDto);
        Task<ReturnBase<InspectionStandardDto>> Update(InspectionStandardUpdateDto updateDto);
        Task<ReturnBase<InspectionStandardDto>> Delete(long id);
        Task<ReturnBase<InspectionStandardDto>> GetById(long id);
        //Task<ReturnBase<List<InspectionStandardDto>>> GetAll();
        Task<InspectionStandard> GetByCode(string code);
        Task<ReturnBase<IEnumerable<InspectionStandardReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}
