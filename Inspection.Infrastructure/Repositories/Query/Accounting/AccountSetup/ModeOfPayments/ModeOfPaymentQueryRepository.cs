using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.ModeOfPayments;
using Inspection.Application.Contracts.Repositories.Query.Accounting.AccountSetup.ModeOfPayments;
using Inspection.Domain.Models.Accounting.AccountingSetup.ModeOfPayments;
using Inspection.Infrastructure.QueryObjects.Accounting.AccountingSetup.ModeOfPayments;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Accounting.AccountSetup.ModeOfPayments
{
    public class ModeOfPaymentQueryRepository
        : QueryRepositoryBase<ModeOfPayment>, IModeOfPaymentQueryRepository
    {
        public ModeOfPaymentQueryRepository(
            ISqlQueryBuilder queryBuilder,
            DapperDbContext dapper,
            DbContext context,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager)
            : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<ModeOfPayment?> GetById(long id)
        {
            return await _context.Set<ModeOfPayment>()
                                 .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ReturnBase<IEnumerable<ModeOfPaymentSearchReturnDto>>> Search(
            SqlQueryOptions sqlQueryOptions)
        {
            var modeOfPaymentRepository = new ModeOfPaymentQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await modeOfPaymentRepository.Query(sqlQueryOptions);
        }





    }
}