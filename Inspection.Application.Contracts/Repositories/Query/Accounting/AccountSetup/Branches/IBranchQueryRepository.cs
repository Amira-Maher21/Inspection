using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.Branches;
using Inspection.Domain.Models.Accounting.AccountingSetup.Branches;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Accounting.AccountSetup.Branches
{
    public interface IBranchQueryRepository : IQueryRepository<Branch>
    {
        Task<ReturnBase<List<Branch>>> GetAll();
        Task<Branch?> GetById(long id);

        Task<ReturnBase<IEnumerable<BranchReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
        Task<Branch?> GetByCode(string code);


    }
}