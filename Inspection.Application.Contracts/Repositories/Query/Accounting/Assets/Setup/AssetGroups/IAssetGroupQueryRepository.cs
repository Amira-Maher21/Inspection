

using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.AssetCategories;
using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.AssetGroupDTOs;
using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CashTransferDTOs;
using Inspection.Domain.Models.Accounting.Assets.Setup.AssetCategories;
using Inspection.Domain.Models.Accounting.Assets.Setup.AssetGroups;
using Inspection.Domain.Models.Accounting.Payment.CashTransfers;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Accounting.Assets.Setup.AssetGroups
{
    public interface IAssetGroupQueryRepository:IQueryRepository<AssetGroup>
    {
        Task<ReturnBase<List<AssetGroup>>> GetAll();
        Task<AssetGroup?> GetById(long id);
        Task<ReturnBase<IEnumerable<AssetGroupReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);

    }
}
