using Inspection.Application.Contracts.Repositories.Query.Accounting.AccountSystem.PaymentTerms;
using Inspection.Domain.Models.Accounting.AccountingSystem.PaymentTerms;
using Inspection.Infrastructure.QueryObjects.Accounting.AccountSystem.PaymentTerms;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Accounting.AccountSystem.PaymetTerms
{
    public class PaymentTermQueryRepository : QueryRepositoryBase<PaymentTerm>, IPaymentTermQueryRepository
    {
        public PaymentTermQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<ReturnBase<List<PaymentTerm>>> GetAll()
        {
            var result = await _context.Set<PaymentTerm>().AsNoTracking().ToListAsync();
            return ReturnBase<List<PaymentTerm>>.Success(result);
        }

        public async Task<PaymentTerm?> GetById(long id)
        {
            return await _context.Set<PaymentTerm>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }


        public async Task<PaymentTerm?> GetByCode(string code)
        {
            return await _context.Set<PaymentTerm>().Where(x => x.Code == code).FirstOrDefaultAsync();
        }






        public async Task<ReturnBase<IEnumerable<PaymentTerm>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var PaymentTermRepository = new PaymentTermQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await PaymentTermRepository.Query(sqlQueryOptions);
        }


    }
}

