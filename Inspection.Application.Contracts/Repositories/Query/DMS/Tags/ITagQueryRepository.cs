using Inspection.Application.Contracts.Dto.DMSDTOs.TagDTOs;
using Inspection.Domain.Models.DMS.Tags;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.DMS.Tags
{
    public interface ITagQueryRepository : IQueryRepository<Tag>
    {
        Task<Tag?> GetById(long id);
        Task<ReturnBase<IEnumerable<TagReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions, string tenantId, long companyId);
    }
}