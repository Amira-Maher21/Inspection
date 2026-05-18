using Inspection.Application.Contracts.Dto.InspectionDto.Techinal.AccreditationBodyDTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Inspection.Techinal.AccreditationBodies
{
    public interface IAccreditationBodyService
    {
        Task<ReturnBase<AccreditationBodyDto>> Create(AccreditationBodyCreateDto createDto);
        Task<ReturnBase<AccreditationBodyDto>> Update(AccreditationBodyUpdateDto updateDto);
        Task<ReturnBase<AccreditationBodyDto>> Delete(long id);
        Task<ReturnBase<AccreditationBodyDto>> GetById(long id);
        Task<ReturnBase<IEnumerable<AccreditationBodyReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}