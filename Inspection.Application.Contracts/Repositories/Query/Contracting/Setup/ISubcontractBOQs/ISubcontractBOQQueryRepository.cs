using Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.SubcontractBOQDTOs;
using Inspection.Domain.Models.Contracting.Setup.SubcontractBOQs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Contracting.Setup.ISubcontractBOQs
{
    public interface ISubcontractBOQQueryRepository : IQueryRepository<SubcontractBOQ>
    {
        Task<ReturnBase<List<SubcontractBOQ>>> GetAll();
        Task<SubcontractBOQ?> GetById(long id);
        Task<ReturnBase<IEnumerable<SubcontractBOQReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}