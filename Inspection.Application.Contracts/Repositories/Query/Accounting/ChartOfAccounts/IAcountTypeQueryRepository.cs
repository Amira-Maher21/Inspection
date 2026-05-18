using Inspection.Domain.Models.Accounting.ChartOfAccounts;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Accounting.ChartOfAccounts
{
    public interface IAcountTypeQueryRepository : IQueryRepository<AccountType>
    {
        Task<ReturnBase<List<AccountType>>> GetAll();
        Task<AccountType?> GetByCode(string code);
    }
}