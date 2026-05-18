using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.CostCenterDTOs;
using Inspection.Domain.Models.Accounting.AccountingSetup;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Accounting.AccountSetup
{
    public interface ICostCenterQueryRepository : IQueryRepository<CostCenter>
    {
        Task<CostCenter?> GetById(long id);
        Task<CostCenter?> GetByCode(string code);
        Task<ReturnBase<IEnumerable<CostCenterReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);

    }
}
