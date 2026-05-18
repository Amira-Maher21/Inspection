using Inspection.Application.Contracts.Dto.AccountingDtos.AR.PurchaseReturns;
using Inspection.Domain.Models.Accounting.AR.PurchaseReturns;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Accounting.AR.PurchaseReturns
{
    public interface IPurchaseReturnQueryRepository : IQueryRepository<PurchaseReturn>
    {
        Task<ReturnBase<List<PurchaseReturn>>> GetAll();
        Task<PurchaseReturn?> GetById(long id);
        Task<ReturnBase<IEnumerable<PurchaseReturnReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}
