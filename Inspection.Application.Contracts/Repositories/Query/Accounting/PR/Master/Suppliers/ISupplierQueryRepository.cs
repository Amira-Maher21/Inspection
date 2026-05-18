using Inspection.Application.Contracts.Dto.AccountingDtos.PR.MasterData.Suppliers;
using Inspection.Domain.Models.Accounting.PR.MasterData.Suppliers;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Infrastructure.Repositories.Query.Accounting.PR.Master.Suppliers
{
    public interface ISupplierQueryRepository : IQueryRepository<Supplier>
    {
        Task<Supplier?> GetById(long id);
        Task<ReturnBase<IEnumerable<SupplierReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);

        Task<Supplier?> GetByCode(string code);

    }
}
