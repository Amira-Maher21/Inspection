using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentsMoreInformationDetails;
using Inspection.Application.Contracts.Repositories.Query.EquipmentManagement.EquipmentsMoreInformationDetails;
using Inspection.Domain.Models.EquipmentManagement.EquipmentsMoreInformationDetails;
using Inspection.Infrastructure.QueryObjects.EquipmentManagment.EquipmentsMoreInformationDetails;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.EquipmentManagement.EquipmentsMoreInformationDetails
{



    public class EquipmentsMoreInformationDetailQueryRepository : QueryRepositoryBase<EquipmentsMoreInformationDetail>, IEquipmentsMoreInformationDetailQueryRepository
    {
        public EquipmentsMoreInformationDetailQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }



        public async Task<EquipmentsMoreInformationDetail?> GetByIdAsync(long id)
        {
            return await _context.Set<EquipmentsMoreInformationDetail>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }


        public async Task<List<EquipmentMoreInformationDetailsKeyValueDto>?> GetByEquipmentTypeIdAsync(long EquipmentTypeId)
        {
            return await _dbSet.Where(x => x.EquipmentsMoreInformations.EquipmentTypeId == EquipmentTypeId)
                .Select(x => new EquipmentMoreInformationDetailsKeyValueDto
                {
                    //Id = x.Id,
                    KeyName = x.KeyName,
                    KeyValue = x.KeyValue,
                    //EquipmentTypeId = x.EquipmentsMoreInformations.EquipmentTypeId
                }).ToListAsync();

        }

        public async Task<ReturnBase<IEnumerable<EquipmentsMoreInformationDetailDtoByInclude>>> GetListAsync(SqlQueryOptions sqlQueryOptions)
        {
            var EquipmentsMoreInformationDetailQueryRepository = new EquipmentsMoreInformationDetailQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await EquipmentsMoreInformationDetailQueryRepository.Query(sqlQueryOptions);//Query(EquipmentsMoreInformationDetailDto, sqlQueryOptions);
        }

        public async Task<ReturnBase<IEnumerable<EquipmentsMoreInformationDetailDtoByInclude>>> GetListIncludeNameAsync(SqlQueryOptions sqlQueryOptions)
        {

            var EquipmentsMoreInformationDetailQuery = new EquipmentsMoreInformationDetailQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await Query(EquipmentsMoreInformationDetailQuery, sqlQueryOptions);

        }

        public async Task<ReturnBase<IEnumerable<EquipmentsMoreInformationDetailDtoByInclude>>> GetLookUpEquipmentsMoreInformationDetailForNamesAsync(SqlQueryOptions queryOptions)
        {
            var EquipmentsMoreInformationDetailQueryRepository = new EquipmentsMoreInformationDetailQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);

            return await EquipmentsMoreInformationDetailQueryRepository.Query(queryOptions);


        }

        //public async Task<ReturnBase<IEnumerable<EquipmentsMoreInformationDetailDto>>> GetListAsync(SqlQueryOptions sqlQueryOptions)
        //{
        //    //var EquipmentsMoreInformationDetailQueryRepository = new EquipmentsMoreInformationDetailQueryRepository(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
        //    //return await Query(EquipmentsMoreInformationDetailQueryRepository, sqlQueryOptions);
        //}
    }

}
