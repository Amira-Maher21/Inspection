using Inspection.Application.Contracts.Dto.Inventory.ItemGroupS;
using Inspection.Domain.Models.Accounting.PostingEngine;
using Inspection.Domain.Models.Inventory.ItemGroups;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Posting
{
    public interface IPostingAccountMappingQueryRepository : IQueryRepository<PostingAccountMapping>
    {
        Task<List<PostingAccountMapping>> GetByDocumentCode(string documentCode);

    }
}
