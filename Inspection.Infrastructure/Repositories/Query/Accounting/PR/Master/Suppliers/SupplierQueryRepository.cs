using Inspection.Application.Contracts.Dto.AccountingDtos.PR.MasterData.Suppliers;
using Inspection.Domain.Models.Accounting.PR.MasterData.Suppliers;
using Inspection.Infrastructure.QueryObjects.Accounting.PR.MasterData.Suppliers;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Accounting.PR.Master.Suppliers
{
    public class SupplierQueryRepository : QueryRepositoryBase<Supplier>, ISupplierQueryRepository
    {
        public SupplierQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {

        }
        public async Task<Supplier?> GetById(long id)
        {
            return await _dbSet
                .Include(s => s.SupplierContacts)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<ReturnBase<IEnumerable<SupplierReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var supplierQueryRepo = new SupplierQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await supplierQueryRepo.Query(sqlQueryOptions);
        }
        public async Task<Supplier?> GetByCode(string code)
        {
            return await _context.Set<Supplier>().Where(x => x.Code == code).FirstOrDefaultAsync();
        }


    }


}
