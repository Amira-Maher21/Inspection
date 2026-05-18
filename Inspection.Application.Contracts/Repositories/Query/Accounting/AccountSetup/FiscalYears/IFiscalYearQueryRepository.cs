using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.FiscalYearDTOs;
using Inspection.Domain.Models.Accounting.AccountingSetup.FiscalYears;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Accounting.AccountSetup.FiscalYears
{
    public interface IFiscalYearQueryRepository : IQueryRepository<FiscalYear>
    {
        Task<FiscalYear?> GetById(long id);
        Task<ReturnBase<IEnumerable<FiscalYearDto>>> Search(SqlQueryOptions sqlQueryOptions);
        Task<FiscalYear?> GetByCode(string code);
    }
}