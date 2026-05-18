using Inspection.Domain.Models.MenuManagement;
using NDS.Shared.Application.DataQuery;

namespace Inspection.Application.Contracts.Repositories.Query.MenuManagement.Programs
{
    public interface IProgramQueryRepository
    {
        Task<IEnumerable<Program>> GetList(SqlQueryOptions sqlQueryOptions = null);

    }
}
