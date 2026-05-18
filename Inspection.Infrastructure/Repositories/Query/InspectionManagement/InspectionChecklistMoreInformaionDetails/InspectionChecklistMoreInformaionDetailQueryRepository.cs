using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionChecklistMoreInformationDetails;
using Inspection.Application.Contracts.Repositories.Query.InspectionManagement.InspectionChecklistMoreInformationDetails;
using Inspection.Domain.Models.InspectionManagement.InspectionChecklistMoreInformationDetails;
using Inspection.Infrastructure.QueryObjects.InspectionManagement.InspectionChecklistMoreInformationDetails;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.InspectionManagement.InspectionChecklistMoreInformationDetails
{



    public class InspectionChecklistMoreInformationDetailQueryRepository : QueryRepositoryBase<InspectionChecklistMoreInformationDetail>, IInspectionChecklistMoreInformationDetailQR
    {
        public InspectionChecklistMoreInformationDetailQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }



        public async Task<InspectionChecklistMoreInformationDetail?> GetByIdAsync(long id)
        {
            return await _context.Set<InspectionChecklistMoreInformationDetail>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }


        public async Task<List<InspectionChecklistMoreInformationDetailsKeyValueDto>?> GetByEquipmentTypeIdAsync(long EquipmentTypeId)
        {
            return await _dbSet.Where(x => x.InspectionChecklistMoreInformations.EquipmentTypeId == EquipmentTypeId)
                .Select(x => new InspectionChecklistMoreInformationDetailsKeyValueDto
                {
                    //Id = x.Id,
                    KeyName = x.KeyName,
                    KeyValue = x.KeyValue,
                    //EquipmentTypeId = x.InspectionChecklistMoreInformation.EquipmentTypeId
                }).ToListAsync();

        }

        public async Task<ReturnBase<IEnumerable<InspectionChecklistMoreInformationDetailDtoByInclude>>> GetListAsync(SqlQueryOptions sqlQueryOptions)
        {
            var InspectionChecklistMoreInformationDetailQueryRepository = new InspectionChecklistMoreInformationDetailQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await InspectionChecklistMoreInformationDetailQueryRepository.Query(sqlQueryOptions);//Query(InspectionChecklistMoreInformationDetailDto, sqlQueryOptions);
        }

        public async Task<ReturnBase<IEnumerable<InspectionChecklistMoreInformationDetailDtoByInclude>>> GetListIncludeNameAsync(SqlQueryOptions sqlQueryOptions)
        {

            var InspectionChecklistMoreInformationDetailQuery = new InspectionChecklistMoreInformationDetailQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await Query(InspectionChecklistMoreInformationDetailQuery, sqlQueryOptions);

        }

        public async Task<ReturnBase<IEnumerable<InspectionChecklistMoreInformationDetailDtoByInclude>>> GetLookUpInspectionChecklistMoreInformationDetailForNamesAsync(SqlQueryOptions queryOptions)
        {
            var InspectionChecklistMoreInformationDetailQueryRepository = new InspectionChecklistMoreInformationDetailQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);

            return await InspectionChecklistMoreInformationDetailQueryRepository.Query(queryOptions);


        }

        //public async Task<ReturnBase<IEnumerable<InspectionChecklistMoreInformationDetailDto>>> GetListAsync(SqlQueryOptions sqlQueryOptions)
        //{
        //    //var InspectionChecklistMoreInformationDetailQueryRepository = new InspectionChecklistMoreInformationDetailQueryRepository(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
        //    //return await Query(InspectionChecklistMoreInformationDetailQueryRepository, sqlQueryOptions);
        //}
    }

}
