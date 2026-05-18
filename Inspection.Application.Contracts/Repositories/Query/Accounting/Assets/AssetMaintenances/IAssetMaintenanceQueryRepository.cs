using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.AssetMaintenanceDTOs;
using Inspection.Domain.Models.Accounting.Assets.AssetMaintenances;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Accounting.Assets.AssetMaintenances
{
    public interface IAssetMaintenanceQueryRepository : IQueryRepository<AssetMaintenance>
    {
        Task<ReturnBase<List<AssetMaintenance>>> GetAll();
        Task<AssetMaintenance?> GetById(long id);
        Task<ReturnBase<IEnumerable<AssetMaintenanceReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}