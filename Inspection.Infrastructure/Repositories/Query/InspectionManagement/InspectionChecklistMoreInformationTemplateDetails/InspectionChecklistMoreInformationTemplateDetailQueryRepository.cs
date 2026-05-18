using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionChecklistMoreInformationTemplateDetails;
using Inspection.Application.Contracts.Repositories.Query.InspectionManagement.InspectionChecklistMoreInformationTemplateDetails;
using Inspection.Domain.Models.InspectionManagement.InspectionChecklistMoreInformationTemplateDetails;
using Inspection.Infrastructure.QueryObjects.EquipmentManagment.InspectionChecklistMoreInformationTemplateDetails;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.EquipmentManagement.InspectionChecklistMoreInformationTemplateDetails
{




    public class InspectionChecklistMoreInformationTemplateDetailQueryRepository : QueryRepositoryBase<InspectionChecklistMoreInformationTemplateDetail>, IInspectionChecklistMoreInformationTemplateDetailQR
    {
        public InspectionChecklistMoreInformationTemplateDetailQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }



        public async Task<InspectionChecklistMoreInformationTemplateDetail?> GetByIdAsync(long id)
        {
            return await _context.Set<InspectionChecklistMoreInformationTemplateDetail>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }


        public async Task<List<InspectionChecklistMoreInformationTemplateDetailKeyValueDto>?> GetByEquipmentTypeIdAsync(long EquipmentTypeId)
        {
            return await _dbSet.Where(x => x.InspectionChecklistMoreInformationTemplates.EquipmentTypeId == EquipmentTypeId)
                .Select(x => new InspectionChecklistMoreInformationTemplateDetailKeyValueDto
                {
                    //Id = x.Id,
                    KeyName = x.KeyName,
                    KeyValue = x.KeyValue,
                    //EquipmentTypeId = x.EquipmentsMoreInformations.EquipmentTypeId
                }).ToListAsync();

        }

        //public async Task<ReturnBase<IEnumerable<InspectionChecklistMoreInformationTemplateDetailDtoByInclude>>> GetListAsync(SqlQueryOptions sqlQueryOptions)
        //{
        //    var InspectionChecklistMoreInformationTemplateDetailQueryRepository = new InspectionChecklistMoreInformationTemplateDetailQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
        //    return await InspectionChecklistMoreInformationTemplateDetailQueryRepository.Query(sqlQueryOptions);//Query(InspectionChecklistMoreInformationTemplateDetailDto, sqlQueryOptions);
        //}

        //public Task<ReturnBase<IEnumerable<InspectionChecklistMoreInformationTemplateDetailDtoByInclude>>> GetListIncludeNameAsync(SqlQueryOptions sqlQueryOptions)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<ReturnBase<IEnumerable<InspectionChecklistMoreInformationTemplateDetailDtoByInclude>>> GetListAsync(SqlQueryOptions sqlQueryOptions)
        {
            var InspectionChecklistMoreInformationTemplateDetailQueryRepository = new InspectionChecklistMoreInformationTemplateDetailQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await InspectionChecklistMoreInformationTemplateDetailQueryRepository.Query(sqlQueryOptions);//Query(InspectionChecklistMoreInformationTemplateDetailDto, sqlQueryOptions);
        }

        public async Task<ReturnBase<IEnumerable<InspectionChecklistMoreInformationTemplateDetailDtoByInclude>>> GetListIncludeNameAsync(SqlQueryOptions sqlQueryOptions)
        {

            var InspectionChecklistMoreInformationTemplateDetailQuery = new InspectionChecklistMoreInformationTemplateDetailQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await Query(InspectionChecklistMoreInformationTemplateDetailQuery, sqlQueryOptions);

        }

        //public async Task<ReturnBase<IEnumerable<InspectionChecklistMoreInformationTemplateDetailDtoByInclude>>> GetLookUpInspectionChecklistMoreInformationTemplateDetailForNamesAsync(SqlQueryOptions queryOptions)
        //{
        //    var InspectionChecklistMoreInformationTemplateDetailQueryRepository = new InspectionChecklistMoreInformationTemplateDetailQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);

        //    return await InspectionChecklistMoreInformationTemplateDetailQueryRepository.Query(queryOptions);


        //}


    }

}
