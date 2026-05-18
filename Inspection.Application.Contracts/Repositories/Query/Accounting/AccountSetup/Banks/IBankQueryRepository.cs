using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.BankDTOs;
using Inspection.Domain.Models.Accounting.AccountingSetup.Banks;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Accounting.AccountSetup.Banks
{
    public interface IBankQueryRepository : IQueryRepository<Bank>
    {
        Task<Bank?> GetById(long id);
        Task<ReturnBase<IEnumerable<BankDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }


}
