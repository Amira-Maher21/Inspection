using Inspection.Application.Contracts.Dto.LocalizationDto;
using Inspection.Application.Contracts.Repositories.Query.LocalizationManagement;
using Inspection.Domain.Models.Localizations;
using Inspection.Infrastructure.QueryObjects.LocalizationManagement;
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

namespace Inspection.Infrastructure.Repositories.Query.LocalizationManagment
{
    internal class LocalizationQueryRepository : QueryRepositoryBase<Localization>, ILocalizationQueryRepository
    {
        public LocalizationQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }
        public async Task<ReturnBase<IEnumerable<GetLocalizationDto>>> GetLocalizationListAsync(SqlQueryOptions sqlQueryOptions)
        {
            var localizationQuery = new LocalizationQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await Query(localizationQuery, sqlQueryOptions);
        }
    }
}
