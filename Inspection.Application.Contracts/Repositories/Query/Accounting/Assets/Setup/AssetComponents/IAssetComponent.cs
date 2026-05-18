using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.AssetCategories;
using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.AssetComponents;
using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CashPaymentDTOs;
using Inspection.Domain.Models.Accounting.Assets.Setup.AssetCategories;
using Inspection.Domain.Models.Accounting.Payment.CashPayments;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Accounting.Assets.Setup.AssetCategories
{
    public interface IAssetComponentQueryRepository : IQueryRepository<AssetComponent>
    {
        Task<ReturnBase<List<AssetComponent>>> GetAll();
        Task<AssetComponent?> GetById(long id);
        Task<ReturnBase<IEnumerable<AssetComponentReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}