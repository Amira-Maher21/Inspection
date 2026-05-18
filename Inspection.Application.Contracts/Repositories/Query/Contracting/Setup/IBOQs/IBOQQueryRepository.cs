using Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.BOQDTOs;
using Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.BOQDTOs.BOQLineDTOs;
using Inspection.Domain.Models.Contracting.Setup.BOQs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Contracting.Setup.IBOQs
{
    public interface IBOQQueryRepository : IQueryRepository<BOQ>
    {
        Task<ReturnBase<List<BOQ>>> GetAll();
        Task<BOQ?> GetById(long id);
        Task<ReturnBase<IEnumerable<BOQReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<IEnumerable<BOQLineDto>>> SearchBOQLines(SqlQueryOptions sqlQueryOptions);
    }
}