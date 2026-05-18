using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.AssetLocations;
using Inspection.Domain.Models.Accounting.Assets.Setup.AssetLocations;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Accounting.Assets.Setup.AssetLocations
{
    public interface IAssetLocationQueryRepository : IQueryRepository<AssetLocation>
    {
        Task<AssetLocation?> GetById(long id);
        Task<ReturnBase<List<AssetLocation>>> GetAll();
        Task<ReturnBase<IEnumerable<AssetLocationReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
        Task<AssetLocation?> GetByCode(string code);
    }
}