using Inspection.Application.Contracts.Dto.AccountingDtos.AR.MasterData.CustomerGroup;
using Inspection.Domain.Models.Accounting.AR.MasterData;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Accounting.AR.MasterData
{
    public interface ICustomerGroupQueryRepository : IQueryRepository<CustomerGroup>
    {
        Task<ReturnBase<List<CustomerGroup>>> GetAll();
        Task<CustomerGroup?> GetById(long id);

        Task<ReturnBase<IEnumerable<CustomerGroupReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);

    }
}