using Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.Divisions;
using Inspection.Domain.Models.Contracting.Setup.Divisions;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Contracting.Setup.Divisions
{

    public interface IDivisionQueryRepository
    {
        Task<Division?> GetById(long id);
        Task<ReturnBase<IEnumerable<DivisionReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}
