using Inspection.Application.Contracts.Dto.EquipmentManagement.CompanyEquipments;
using Inspection.Application.Contracts.Repositories.Query.EquipmentManagement.CompanyEquipments;
using Inspection.Domain.Models.EquipmentManagement.CompanyEquipments;
using Inspection.Infrastructure.QueryObjects.EquipmentManagment.CompanyEquipments;
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

namespace Inspection.Infrastructure.Repositories.Query.EquipmentManagement.CompanyEquipments
{

    public class CompanyEquipmentQueryRepository : QueryRepositoryBase<CompanyEquipment>, ICompanyEquipmentQueryRepository
    {
        public CompanyEquipmentQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }



        public async Task<CompanyEquipment?> GetByIdAsync(long id)
        {
            return await _context.Set<CompanyEquipment>().Include(x=>x.EquipmentMaintenanceAndRepairRecords).Include(x=>x.EquipmentAccessories).Include(x=>x.EquipmentPreventiveMaintenances).Include(x=>x.EquipmentCalibrationHistorys).Include(x=>x.EquipmentSoftwares).Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ReturnBase<IEnumerable<CompanyEquipmentDtoByInclude>>> GetListAsync(SqlQueryOptions sqlQueryOptions)
        {
            var CompanyEquipmentQueryRepository = new CompanyEquipmentQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await CompanyEquipmentQueryRepository.Query(sqlQueryOptions);//Query(CompanyEquipmentDto, sqlQueryOptions);
        }

        public async Task<ReturnBase<IEnumerable<CompanyEquipmentDtoByInclude>>> GetListIncludeNameAsync(SqlQueryOptions sqlQueryOptions)
        {

            var CompanyEquipmentQuery = new CompanyEquipmentQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await Query(CompanyEquipmentQuery, sqlQueryOptions);

        }

        public async Task<ReturnBase<IEnumerable<CompanyEquipmentDtoByInclude>>> GetLookUpCompanyEquipmentForNamesAsync(SqlQueryOptions queryOptions)
        {
            var CompanyEquipmentQueryRepository = new CompanyEquipmentQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);

            return await CompanyEquipmentQueryRepository.Query(queryOptions);


        }

        //public async Task<ReturnBase<IEnumerable<CompanyEquipmentDto>>> GetListAsync(SqlQueryOptions sqlQueryOptions)
        //{
        //    //var CompanyEquipmentQueryRepository = new CompanyEquipmentQueryRepository(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
        //    //return await Query(CompanyEquipmentQueryRepository, sqlQueryOptions);
        //}
    }

}
