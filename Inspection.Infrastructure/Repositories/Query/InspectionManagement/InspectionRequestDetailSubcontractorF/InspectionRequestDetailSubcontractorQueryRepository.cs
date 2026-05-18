 using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionRequestSubcontractorDetailF;
using Inspection.Application.Contracts.Repositories.Query.InspectionManagement.InspectionRequestDetailSubcontractorF;
using Inspection.Domain.Models.InspectionManagement.InspectionRequests;
using Inspection.Infrastructure.QueryObjects.InspectionManagement.InspectionRequestDetailSubcontractorF;
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

namespace Inspection.Infrastructure.Repositories.Query.InspectionManagement.InspectionRequestDetailSubcontractorF
{
     
    public class InspectionRequestDetailSubcontractorQueryRepository : QueryRepositoryBase<InspectionRequestSubcontractorDetail>, IInspectionRequestDetailSubcontractorQueryRepository
{
        public InspectionRequestDetailSubcontractorQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }



        public async Task<InspectionRequestSubcontractorDetail?> GetByIdAsync(long id)
        {
            return await _context.Set<InspectionRequestSubcontractorDetail>().Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<ReturnBase<IEnumerable<InspectionRequestSubcontractorDetailDtoByInclude>>> GetListAsync(SqlQueryOptions sqlQueryOptions)
        {
            var InspectionRequestDetailSubcontractorQueryRepository = new InspectionRequestDetailSubcontractorQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await InspectionRequestDetailSubcontractorQueryRepository.Query(sqlQueryOptions);//Query(InspectionRequestDetailSubcontractorDto, sqlQueryOptions);
        }

        public async Task<ReturnBase<IEnumerable<InspectionRequestSubcontractorDetailDtoByInclude>>> GetListIncludeNameAsync(SqlQueryOptions sqlQueryOptions)
        {

            var InspectionRequestDetailSubcontractorQuery = new InspectionRequestDetailSubcontractorQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await Query(InspectionRequestDetailSubcontractorQuery, sqlQueryOptions);

        }

        public async Task<ReturnBase<IEnumerable<InspectionRequestSubcontractorDetailDtoByInclude>>> GetLookUpInspectionRequestDetailSubcontractorForNamesAsync(SqlQueryOptions queryOptions)
        {
            var InspectionRequestDetailSubcontractorQueryRepository = new InspectionRequestDetailSubcontractorQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);

            return await InspectionRequestDetailSubcontractorQueryRepository.Query(queryOptions);


        }

        //public async Task<ReturnBase<IEnumerable<InspectionRequestDetailSubcontractorDto>>> GetListAsync(SqlQueryOptions sqlQueryOptions)
        //{
        //    //var InspectionRequestDetailSubcontractorQueryRepository = new InspectionRequestDetailSubcontractorQueryRepository(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
        //    //return await Query(InspectionRequestDetailSubcontractorQueryRepository, sqlQueryOptions);
        //}
    }

}
