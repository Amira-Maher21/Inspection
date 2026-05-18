using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.AssetCustodies;
using Inspection.Domain.Models.Accounting.Assets.Setup.AssetCustodies;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Accounting.Assets.Setup.AssetCustodies
{
    public interface IAssetCustodyQueryRepository : IQueryRepository<AssetCustody>
    {
        Task<ReturnBase<List<AssetCustody>>> GetAll();
        Task<AssetCustody?> GetById(long id);
        Task<ReturnBase<IEnumerable<AssetCustodyReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}