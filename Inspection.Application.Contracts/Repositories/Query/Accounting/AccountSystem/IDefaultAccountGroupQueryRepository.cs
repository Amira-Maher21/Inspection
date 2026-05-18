using Inspection.Domain.Models.Accounting.AccountingSystem;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Accounting.AccountSystem
{
    public interface IDefaultAccountGroupQueryRepository : IQueryRepository<DefaultAccountGroup>
    {
        Task<ReturnBase<List<DefaultAccountGroup>>> GetAll();
        Task<DefaultAccountGroup?> GetById(long id);

        Task<ReturnBase<IEnumerable<DefaultAccountGroup>>> Search(SqlQueryOptions sqlQueryOptions);

    }
}