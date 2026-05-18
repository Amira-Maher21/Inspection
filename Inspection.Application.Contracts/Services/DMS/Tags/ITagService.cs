using Inspection.Application.Contracts.Dto.DMSDTOs.TagDTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.DMS.Tags
{
    public interface ITagService
    {
        Task<ReturnBase<TagDto>> Create(TagCreateDto createDto);
        Task<ReturnBase<TagDto>> Update(TagUpdateDto updateDto);
        Task<ReturnBase<TagDto>> Delete(long id);
        Task<ReturnBase<TagDto>> GetById(long id);
        Task<ReturnBase<IEnumerable<TagReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}
