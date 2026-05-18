using Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.CostCodes;
using Inspection.Domain.Models.Contracting.Setup.CostCodes;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Contracting.Setup.CostCodes
{
    public interface ICostCodeQueryRepository
    {
        Task<CostCode?> GetById(long id);
        Task<ReturnBase<IEnumerable<CostCodeReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}
