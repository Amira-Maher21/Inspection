using Inspection.Application.Contracts.Repositories.Query.MenuManagement.SeriesF;
using Inspection.Domain.Models.MenuManagement;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.MenuManagement.SeriesF
{
    public class ScreenCodeQueryRepository : QueryRepositoryBase<Screen_Code>, IScreenCodeQueryRepository
    {
        public ScreenCodeQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
            _dapper = dapper;
        }
        private readonly DapperDbContext _dapper;
        public async Task<Screen_Code?> GetByMenu_IDAsync(string menuid)
        {

            return await _dbSet.FirstOrDefaultAsync(x => x.Menu_ID == menuid);
        }




        public async Task<string> GetMaxCodeAsync(
             string logicalTableName,
             string fieldName,
             string groupFieldName = null,
             string groupFieldValue = null,
             int paddingLength = 5)
        {
            var tenantId = _tenantResolver.GetTenantName();



            var tableNameSql = $"SELECT TabelMasterName FROM Syst.Screen_Code WHERE Screen_ID = '{logicalTableName}'";
            var tableNameResult = await _dapper.QueryScalar<string>(tableNameSql);

            var tableName = tableNameResult.Result;

            if (string.IsNullOrEmpty(tableName))
                throw new Exception($"Table '{logicalTableName}' not found in Syst.Screen_Code.");



            var sql = $"SELECT MAX(CAST([{fieldName}] AS INT)) FROM {tableName} WHERE Tenant_ID = '{tenantId}'";

            if (!string.IsNullOrEmpty(groupFieldName) && !string.IsNullOrEmpty(groupFieldValue))
            {
                sql += $" AND [{groupFieldName}] = '{groupFieldValue}'";
            }

            var maxResult = await _dapper.QueryScalar<int?>(sql);

            int maxValue = maxResult.Result ?? 0;

            int nextNumber = maxValue + 1;

            return nextNumber.ToString().PadLeft(paddingLength, '0');

        }
    }



}
