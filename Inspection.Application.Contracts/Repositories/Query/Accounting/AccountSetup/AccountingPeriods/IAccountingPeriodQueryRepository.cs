using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.AccountingPeriodDTOs;
using Inspection.Domain.Models.Accounting.AccountingSetup.AccountingPeriods;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Accounting.AccountSetup.AccountingPeriods
{
    public interface IAccountingPeriodQueryRepository : IQueryRepository<AccountingPeriod>
    {
        IQueryable<AccountingPeriod> GetAll();

        Task<AccountingPeriod?> GetById(long id);
        Task<ReturnBase<IEnumerable<AccountingPeriodReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}