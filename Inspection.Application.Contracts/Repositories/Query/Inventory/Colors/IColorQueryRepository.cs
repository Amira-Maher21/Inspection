using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.Colors;
using Inspection.Domain.Models.Inventory.InventorySetup.Colors;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Inventory.Colors
{
    public interface IColorQueryRepository : IQueryRepository<Color>
    {
        Task<Color?> GetById(long id);
        Task<Color?> GetByCode(string code);

        Task<ReturnBase<IEnumerable<ColorDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}


