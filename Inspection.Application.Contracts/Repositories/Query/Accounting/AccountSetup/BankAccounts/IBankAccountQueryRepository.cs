using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.BankAccountDTOs;
using Inspection.Domain.Models.Accounting.AccountingSetup.BankAccounts;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Accounting.AccountSetup.BankAccounts
{

    public interface IBankAccountQueryRepository : IQueryRepository<BankAccount>
    {
        Task<BankAccount?> GetById(long id);
        Task<ReturnBase<IEnumerable<BankAccountReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }

}
