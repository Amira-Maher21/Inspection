using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.Cashing;
using Inspection.Domain.Models.Accounting.AccountingSetup.Cashing;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Accounting.AccountSetup.Cashing
{
    public interface ICashQueryRepository : IQueryRepository<Cash>
    {
        Task<ReturnBase<List<Cash>>> GetAll();
        Task<Cash?> GetById(long id);

        Task<ReturnBase<IEnumerable<CashReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);

    }
}
