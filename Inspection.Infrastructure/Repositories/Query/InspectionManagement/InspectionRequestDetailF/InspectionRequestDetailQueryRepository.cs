using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionRequestDetailF;
using Inspection.Application.Contracts.Repositories.Query.InspectionManagement.InspectionRequestDetailF;
using Inspection.Domain.Models.InspectionManagement.InspectionRequests;
using Inspection.Infrastructure.QueryObjects.InspectionManagement.InspectionRequestDetailF;
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

namespace Inspection.Infrastructure.Repositories.Query.InspectionManagement.InspectionRequestDetailF
{
     
    public class InspectionRequestLinesQueryRepository : QueryRepositoryBase<InspectionRequestLines>, IInspectionRequestLinesQueryRepository
{
        public InspectionRequestLinesQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }



        public async Task<InspectionRequestLines?> GetByIdAsync(long id)
        {
            return await _context.Set<InspectionRequestLines>().Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<ReturnBase<IEnumerable<InspectionRequestLinesDtoByInclude>>> GetListAsync(SqlQueryOptions sqlQueryOptions)
        {
            var InspectionRequestDetailQueryRepository = new InspectionRequestDetailQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await InspectionRequestDetailQueryRepository.Query(sqlQueryOptions);//Query(InspectionRequestDetailDto, sqlQueryOptions);
        }

        public async Task<ReturnBase<IEnumerable<InspectionRequestLinesDtoByInclude>>> GetListIncludeNameAsync(SqlQueryOptions sqlQueryOptions)
        {

            var InspectionRequestDetailQuery = new InspectionRequestDetailQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await Query(InspectionRequestDetailQuery, sqlQueryOptions);

        }

        public async Task<ReturnBase<IEnumerable<InspectionRequestLinesDtoByInclude>>> GetLookUpInspectionRequestLinesForNamesAsync(SqlQueryOptions queryOptions)
        {
            var InspectionRequestDetailQueryRepository = new InspectionRequestDetailQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);

            return await InspectionRequestDetailQueryRepository.Query(queryOptions);


        }

        //public async Task<ReturnBase<IEnumerable<InspectionRequestDetailDto>>> GetListAsync(SqlQueryOptions sqlQueryOptions)
        //{
        //    //var InspectionRequestDetailQueryRepository = new InspectionRequestDetailQueryRepository(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
        //    //return await Query(InspectionRequestDetailQueryRepository, sqlQueryOptions);
        //}
    }

}
