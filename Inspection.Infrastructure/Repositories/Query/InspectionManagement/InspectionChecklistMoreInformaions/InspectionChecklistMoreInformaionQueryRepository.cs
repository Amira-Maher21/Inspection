using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionChecklists;
using Inspection.Application.Contracts.Repositories.Query.InspectionManagement.InspectionChecklistMoreInformations;
using Inspection.Domain.Models.InspectionManagement.InspectionChecklistMoreInformations;
using Inspection.Infrastructure.QueryObjects.InspectionManagement.InspectionChecklistMoreInformations;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.InspectionManagement.InspectionChecklistMoreInformations
{

    public class InspectionChecklistMoreInformationQueryRepository : QueryRepositoryBase<InspectionChecklistMoreInformation>, IInspectionChecklistMoreInformationQR
    {

        public InspectionChecklistMoreInformationQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {

        }

        public async Task<InspectionChecklistMoreInformation?> GetByIdAsync(long id)
            => await _dbSet.Include(x => x.InspectionChecklistMoreInformationDetails).FirstOrDefaultAsync(x => x.Id == id);


        public async Task<IEnumerable<InspectionChecklistMoreInformationDtoByInclude?>> GetListByIncludeAsync(SqlQueryOptions sqlQueryOptions)
        {
            var InspectionChecklistMoreInformationQueryRepository = new InspectionChecklistMoreInformationQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            var result = await InspectionChecklistMoreInformationQueryRepository.Query(sqlQueryOptions);
            return result.Result;
        }


    }
}
