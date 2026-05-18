using Inspection.Domain.Models.Accounting.AccountBalance;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Accounting.AccountBalances
{

    public interface IAccountBalanceQueryRepository : IQueryRepository<AccountBalance>
    {
        Task<AccountBalance?> GetById(long id);
        //Task<ReturnBase<IEnumerable<AccountBalanceReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
        Task<AccountBalance?> GetByItemAsync(string tenantId, long companyId, long? chartOfAccountId);
    }
}