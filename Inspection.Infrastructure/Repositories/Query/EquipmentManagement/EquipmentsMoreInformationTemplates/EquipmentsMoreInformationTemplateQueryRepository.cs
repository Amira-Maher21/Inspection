using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentsMoreInformationTemplates;
using Inspection.Application.Contracts.Repositories.Query.EquipmentManagement.EquipmentsMoreInformationTemplateTemplates;
using Inspection.Domain.Models.EquipmentManagement.EquipmentsMoreInfoTemplates;
using Inspection.Infrastructure.QueryObjects.EquipmentManagment.EquipmentsMoreInformationTemplateTemplates;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.EquipmentManagement.EquipmentsMoreInformationTemplateTemplates
{


    public class EquipmentsMoreInformationTemplateQueryRepository : QueryRepositoryBase<EquipmentsMoreInformationTemplate>, IEquipmentsMoreInformationTemplateQueryRepository
    {

        public EquipmentsMoreInformationTemplateQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {

        }

        public async Task<EquipmentsMoreInformationTemplate?> GetByIdAsync(long id)
        {
            return await _dbSet.Include(x => x.EquipmentsMoreInformationTemplateDetails).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ReturnBase<IEnumerable<EquipmentsMoreInformationTemplateReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var TaxQueryRepository = new EquipmentsMoreInformationTemplateQuery(
                    _queryBuilder,
                    _dapper,
                    _tenantResolver,
                    _exceptionManager
                );

                var queryResult = await TaxQueryRepository.Query(sqlQueryOptions);

                if (!queryResult.Succeeded)
                    return ReturnBase<IEnumerable<EquipmentsMoreInformationTemplateReturnSearchDto>>.Fail(queryResult.Errors);

                return ReturnBase<IEnumerable<EquipmentsMoreInformationTemplateReturnSearchDto>>.Success(queryResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<EquipmentsMoreInformationTemplateReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }


    }
}
