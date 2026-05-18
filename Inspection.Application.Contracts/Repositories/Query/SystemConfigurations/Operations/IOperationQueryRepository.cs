using Inspection.Domain.Models.SystemConfigurations.Operations;
using NDS.Shared.Application.DataQuery;

namespace Inspection.Application.Contracts.Repositories.Query.SystemConfigurations.Operations
{
    public interface IOperationQueryRepository
    {
        Task<Operation?> GetById(long id);
        Task<IEnumerable<Operation>> GetList(SqlQueryOptions sqlQueryOptions = null);
        Task<bool> HasOpenTransactions(long operationId);
        Task<bool> HasAnyTransactions(long operationId);
    }
}
