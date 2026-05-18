using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionCertificates;
using Inspection.Application.Contracts.Repositories.Query.InspectionManagement.InspectionCertificates;
using Inspection.Domain.Models.InspectionManagement.InspectionCertificates;
using Inspection.Infrastructure.QueryObjects.InspectionManagement.InspectionCertificates;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.InspectionManagement.InspectionCertificates
{
    public class InspectionCertificateQueryRepository : QueryRepositoryBase<InspectionCertificate>, IInspectionCertificateQueryRepository
    {
        public InspectionCertificateQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {

        }

        public async Task<ReturnBase<InspectionCertificate>> GetByIdAsync(object id)
        {
            try
            {
                var entity = await _context.Set<InspectionCertificate>().FindAsync(id);
                return ReturnBase<InspectionCertificate>.Success(entity);
            }
            catch (Exception ex)
            {
                return ReturnBase<InspectionCertificate>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<InspectionCertificate?> GetByIdAsync(long id)
        {
            var x = _dbSet
                           .Include(c => c.InspectionChecklists)
             .AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return await x;

        }
        //public async Task<InspectionCertificate?> GetByIdAsync2222(long id)
        //{
        //    var x = _dbSet

        //                   .Include(c => c.InspectionChecklists)
        //                   .ThenInclude(c => c.JobOrders)
        //                   .Include(c => c.InspectionChecklists).
        //                   ThenInclude(c => c.Equipments).ThenInclude(c => c.EquipmentsMoreInformations).ThenInclude(c => c.EquipmentsMoreInformationDetails)
        //     .AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        //    return await x;

        //}

        public async Task<IEnumerable<InspectionCertificateDtoByInclude?>> GetListByIncludeAsync(SqlQueryOptions sqlQueryOptions)
        {
            var InspectionCertificateQueryRepository = new InspectionCertificatesQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            var result = await InspectionCertificateQueryRepository.Query(sqlQueryOptions);
            return result.Result;
        }
    }
}
