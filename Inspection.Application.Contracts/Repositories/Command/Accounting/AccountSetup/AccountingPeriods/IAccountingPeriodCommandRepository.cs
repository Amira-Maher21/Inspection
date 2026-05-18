using Inspection.Domain.Models.Accounting.AccountingSetup.AccountingPeriods;
using Inspection.Domain.Models.Accounting.PR.MasterData.Suppliers;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Accounting.AccountSetup.AccountingPeriods
{
    public interface IAccountingPeriodCommandRepository : ICommandRepository<AccountingPeriod>
    {
        Task<ReturnBase> DeleteById(long id);
    }
}
 