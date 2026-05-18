using Inspection.Domain.Models.Accounting.AccountingSetup.FiscalYears;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Accounting.AccountSetup.FiscalYears
{
    public interface IFiscalYearCommandRepository : ICommandRepository<FiscalYear>
    {
        Task<ReturnBase> DeleteById(long id);
    }
}