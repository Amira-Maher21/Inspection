 using Inspection.Application.Contracts.Dto.MenuManagement;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Infrastructure.QueryObjects.MenuManagement.SeriesF
{
    internal class SeriesQuery : QueryObjectBase<string>
    {


        public SeriesQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager, string? fiscalYear = null) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<string>>> Query(SqlQueryOptions queryOptions)
        {

            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<string>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<string>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }

        public async Task<ReturnBase<IEnumerable<string>>> Querygeneral( string TableName, string SeriesTableColumn, string? series)
        {
            try
            {
                string querystring = "";

                if (series == null || series == "")
                {
                     querystring = $"SELECT TOP (1) {SeriesTableColumn} FROM {TableName} ORDER BY {SeriesTableColumn} DESC;";

                }
                else
                {
                     querystring = $"SELECT TOP (1) {SeriesTableColumn} FROM {TableName} WHERE series = '{series}' ORDER BY {SeriesTableColumn} DESC;";

                }
                
                var result = await this._dapper.QueryList<string>(querystring!, null);

                return result;
               
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<string>>.Fail(ex, _exceptionManager);
            }
        }
    }
}
