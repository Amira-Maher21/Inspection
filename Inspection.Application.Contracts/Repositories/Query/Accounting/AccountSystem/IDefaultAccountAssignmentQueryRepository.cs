using Inspection.Domain.Models.Accounting.AccountingSystem.DefaultAccountAssignment;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Accounting.AccountSystem
{
    public interface IDefaultAccountAssignmentQueryRepository : IQueryRepository<DefaultAccountAssignment>
    {
        Task<ReturnBase<List<DefaultAccountAssignment>>> GetAll();
        Task<DefaultAccountAssignment?> GetById(long id);

        Task<ReturnBase<IEnumerable<DefaultAccountAssignmentReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);

    }
}