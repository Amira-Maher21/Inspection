using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionChecklistMoreInformationTemplates;
using Inspection.Application.Contracts.Repositories.Query.InspectionManagement.InspectionChecklistMoreInformationTemplates;
using Inspection.Domain.Models.InspectionManagement.InspectionChecklistMoreInformationTemplates;
using Inspection.Infrastructure.QueryObjects.InspectionManagement.InspectionChecklistMoreInformationTemplates;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.EquipmentManagement.InspectionChecklistMoreInformationTemplateTemplates
{


    public class InspectionChecklistMoreInformationTemplateQueryRepository : QueryRepositoryBase<InspectionChecklistMoreInformationTemplate>, IInspectionChecklistMoreInformationTemplateQueryRepository
    {

        public InspectionChecklistMoreInformationTemplateQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {

        }

        public async Task<InspectionChecklistMoreInformationTemplate?> GetByIdAsync(long id)
        {
            return await _dbSet.Include(x => x.InspectionChecklistMoreInformationTemplateDetails).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<InspectionChecklistMoreInformationTemplateDtoByInclude?>> GetListByIncludeAsync(SqlQueryOptions sqlQueryOptions)
        {
            var InspectionChecklistMoreInformationTemplateQueryRepository = new InspectionChecklistMoreInformationTemplateQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            var result = await InspectionChecklistMoreInformationTemplateQueryRepository.Query(sqlQueryOptions);
            return result.Result;
        }


    }
}
