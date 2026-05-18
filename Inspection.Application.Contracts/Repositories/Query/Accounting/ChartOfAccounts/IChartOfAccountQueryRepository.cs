using Inspection.Application.Contracts.Dto.AccountingDtos.ChartOfAccounts.ChartOfAccountDTOs;
using Inspection.Domain.Models.Accounting.ChartOfAccounts;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Accounting.ChartOfAccounts
{
    public interface IChartOfAccountQueryRepository : IQueryRepository<ChartOfAccount>
    {
        Task<ReturnBase<List<ChartOfAccount>>> GetAll();
        Task<ChartOfAccount?> GetById(long id);
        Task<ChartOfAccount?> GetByCode(string code);
        Task<ReturnBase<IEnumerable<ChartOfAccountReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<IEnumerable<ChartOfAccountSelectQueryDto>>> Select(SqlQueryOptions sqlQueryOptions);
    }
}