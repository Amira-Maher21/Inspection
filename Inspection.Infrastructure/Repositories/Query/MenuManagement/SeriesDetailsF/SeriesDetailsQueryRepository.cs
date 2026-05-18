using Inspection.Application.Contracts.Repositories.Query.MenuManagement.SeriesDetailsF;
using Inspection.Domain.Models.MenuManagement;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.MenuManagement.SeriesDetailsF
{
    public class SeriesDetailsQueryRepository : QueryRepositoryBase<SeriesDetails>, ISeriesDetailsQueryRepository
    {
        public SeriesDetailsQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) 
            : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<SeriesDetails?> GetBySeriesIdAndPeriodAsync(long seriesId, int year, int month)
        {
            return await _dbSet
                .FirstOrDefaultAsync(sd => sd.SeriesId == seriesId 
                    && sd.Year == year 
                    && sd.Month == month);
        }
    }
}