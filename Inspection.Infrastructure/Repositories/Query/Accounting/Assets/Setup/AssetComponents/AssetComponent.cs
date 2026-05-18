using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.AssetComponents;
using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CashTransferDTOs;
using Inspection.Application.Contracts.Repositories.Query.Accounting.Assets.Setup.AssetCategories;
using Inspection.Application.Contracts.Repositories.Query.Accounting.Payments.CashTransfers;
using Inspection.Domain.Models.Accounting.Assets.Setup.AssetCategories;
using Inspection.Domain.Models.Accounting.Payment.CashTransfers;
using Inspection.Infrastructure.QueryObjects.Accounting.FixedAsset.Setup.AssetComponentQueries;
using Inspection.Infrastructure.QueryObjects.Accounting.Payments.CashTransfers;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Infrastructure.Repositories.Query.Accounting.Assets.Setup.AssetComponents
{
    public class AssetComponentQueryRepository : QueryRepositoryBase<AssetComponent>, Application.Contracts.Repositories.Query.Accounting.Assets.Setup.AssetCategories.IAssetComponentQueryRepository
    {
        public AssetComponentQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<ReturnBase<List<AssetComponent>>> GetAll()
        {
            var result = await _context.Set<AssetComponent>()
                .AsNoTracking()
                .ToListAsync();

            return ReturnBase<List<AssetComponent>>.Success(result);
        }

        public async Task<AssetComponent?> GetById(long id)
        {
            return await _context.Set<AssetComponent>()
            .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ReturnBase<IEnumerable<AssetComponentReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var assetComponentRepository = new AssetComponentQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await assetComponentRepository.Query(sqlQueryOptions);
        }
    }
}

