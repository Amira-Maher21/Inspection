using Inspection.Application.Contracts.Dto.MenuManagement;
using Inspection.Application.Contracts.Repositories.Query.MenuManagement;
using Inspection.Application.Contracts.Repositories.Query.MenuManagement.SeriesF;
using Inspection.Domain.Enums;
using Inspection.Domain.Models.MenuManagement;
using Inspection.Infrastructure.QueryObjects.MenuManagement;
using Inspection.Infrastructure.QueryObjects.MenuManagement.SeriesF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.Exceptions;
using NDS.Shared.Infrastructure.Multitenant;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Infrastructure.Repositories.Query.MenuManagement.SeriesF
{
    public class SeriesQueryRepository : QueryRepositoryBase<Series>, ISeriesQueryRepository
    {

        public SeriesQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {

        }

        public async Task<Series?> GetByIdAsync(long id) => await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<Series?> GetByScreen_IDAsync(string Screen_ID) => await _dbSet.FirstOrDefaultAsync(x => x.ScreenCode_Id == Screen_ID);
        private string PadNumber(int paddingLength, int number)
        {
            // Convert the number to string and pad with zeros on the left
            string result = number.ToString().PadLeft(paddingLength, '0');

            // If the padded result is shorter than or equal to the number itself, return the number as-is
            if (result.Length <= number.ToString().Length)
                return number.ToString();

            return result;
        }

        public async Task<Dictionary<string, string>?> GetSeriesTableNumberAsync(string TableName, string SeriesTableColumn, string Screen_ID, string FinalSeriesCode)
        {
            var Series = await GetByScreen_IDAsync(Screen_ID);
            if (Series is null)
                throw new NotImplementedException();
            var SeriesQueryobj = new SeriesQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            string? seriesCode = null;
            if (Series.ResetPolicy != ResetPolicyEnum.Never)
                seriesCode = FinalSeriesCode;
            var res = await SeriesQueryobj.Querygeneral(TableName, SeriesTableColumn, seriesCode);

            if (!res.Succeeded)
                throw new NotImplementedException();
            int seriesNumber = 0;
            string? firstResult = res.Result.FirstOrDefault();

            // Parse if not null or empty
            if (!string.IsNullOrEmpty(firstResult))
            {
                int.TryParse(firstResult, out seriesNumber);

            }
            string finalseriesNumber = PadNumber(Series.PaddingLength, seriesNumber + 1);
            var resDictionary = new Dictionary<string, string>();
            resDictionary.Add("SeriesCode", FinalSeriesCode);
            resDictionary.Add("SeriesNumber", finalseriesNumber);
            //resDictionary.Add("Separator", (Series.Separator).ToString());
            resDictionary.Add("FinelSeriesCodeAndSeriesNumber", FinalSeriesCode + finalseriesNumber);


            return resDictionary;

        }




    }
}
