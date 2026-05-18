using Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.WBSs;
using Inspection.Domain.Models.Contracting.Setup.WBSs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Contracting.Setup.WBSs
{
    public interface IWBSQueryRepository
    {
        Task<WBS?> GetById(long id);
        Task<ReturnBase<IEnumerable<WBSReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}
