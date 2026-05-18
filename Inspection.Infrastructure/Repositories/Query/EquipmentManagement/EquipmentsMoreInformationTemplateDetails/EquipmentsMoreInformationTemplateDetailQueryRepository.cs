using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentsMoreInformationTemplateDetails;
using Inspection.Application.Contracts.Repositories.Query.EquipmentManagement.EquipmentsMoreInformationTemplateDetails;
using Inspection.Domain.Models.EquipmentManagement.EquipmentsMoreInformationTemplateDetails;
using Inspection.Infrastructure.QueryObjects.EquipmentManagment.EquipmentsMoreInformationTemplateDetails;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.EquipmentManagement.EquipmentsMoreInformationTemplateDetails
{




    public class EquipmentsMoreInformationTemplateDetailQueryRepository : QueryRepositoryBase<EquipmentsMoreInformationTemplateDetail>, IEquipmentsMoreInformationTemplateDetailQueryRepository
    {
        public EquipmentsMoreInformationTemplateDetailQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }



        public async Task<EquipmentsMoreInformationTemplateDetail?> GetByIdAsync(long id)
        {
            return await _context.Set<EquipmentsMoreInformationTemplateDetail>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }


        public async Task<List<EquipmentMoreInformationTemplateDetailsKeyValueDto>?> GetByEquipmentTypeIdAsync(long EquipmentTypeId)
        {
            return await _dbSet.Where(x => x.EquipmentsMoreInformationTemplates.EquipmentTypeId == EquipmentTypeId)
                .Select(x => new EquipmentMoreInformationTemplateDetailsKeyValueDto
                {
                    //Id = x.Id,
                    KeyName = x.KeyName,
                    KeyValue = x.KeyValue,
                    //EquipmentTypeId = x.EquipmentsMoreInformations.EquipmentTypeId
                }).ToListAsync();

        }

        public async Task<ReturnBase<IEnumerable<EquipmentsMoreInformationTemplateDetailDtoByInclude>>> GetListAsync(SqlQueryOptions sqlQueryOptions)
        {
            var EquipmentsMoreInformationTemplateDetailQueryRepository = new EquipmentsMoreInformationTemplateDetailQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await EquipmentsMoreInformationTemplateDetailQueryRepository.Query(sqlQueryOptions);//Query(EquipmentsMoreInformationTemplateDetailDto, sqlQueryOptions);
        }

        public async Task<ReturnBase<IEnumerable<EquipmentsMoreInformationTemplateDetailDtoByInclude>>> GetListIncludeNameAsync(SqlQueryOptions sqlQueryOptions)
        {

            var EquipmentsMoreInformationTemplateDetailQuery = new EquipmentsMoreInformationTemplateDetailQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await Query(EquipmentsMoreInformationTemplateDetailQuery, sqlQueryOptions);

        }

        public async Task<ReturnBase<IEnumerable<EquipmentsMoreInformationTemplateDetailDtoByInclude>>> GetLookUpEquipmentsMoreInformationTemplateDetailForNamesAsync(SqlQueryOptions queryOptions)
        {
            var EquipmentsMoreInformationTemplateDetailQueryRepository = new EquipmentsMoreInformationTemplateDetailQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);

            return await EquipmentsMoreInformationTemplateDetailQueryRepository.Query(queryOptions);


        }

        //public async Task<ReturnBase<IEnumerable<EquipmentsMoreInformationTemplateDetailDto>>> GetListAsync(SqlQueryOptions sqlQueryOptions)
        //{
        //    //var EquipmentsMoreInformationTemplateDetailQueryRepository = new EquipmentsMoreInformationTemplateDetailQueryRepository(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
        //    //return await Query(EquipmentsMoreInformationTemplateDetailQueryRepository, sqlQueryOptions);
        //}
    }

}
