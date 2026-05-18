using Inspection.Application.Contracts.Dto.AccountingDtos.PR.MasterData.SupplierGroups;
using Inspection.Domain.Models.Accounting.PR.MasterData.Suppliers;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Accounting.PR.Master.SupplierGroups
{
    public interface ISupplierGroupQueryRepository : IQueryRepository<SupplierGroup>
    {
        Task<ReturnBase<List<SupplierGroup>>> GetAll();
        Task<SupplierGroup?> GetById(long id);

        Task<ReturnBase<IEnumerable<SupplierGroupReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);

    }
}