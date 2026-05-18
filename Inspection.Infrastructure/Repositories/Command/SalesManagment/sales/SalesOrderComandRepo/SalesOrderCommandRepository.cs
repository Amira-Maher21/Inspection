using Inspection.Application.Contracts.Repositories.Command.SalesManagment.sales.SalesOrderCommandRepository;
using Inspection.Domain.Models.SalesManagment.Transaction.SalesOrders;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.RepositoryBase.RepositoryHelpers;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Command.SalesManagment.sales
{
    public class SalesOrderCommandRepository : CommandRepositoryBase<SalesOrder>, ISalesOrderCommandRepository
    {
        public SalesOrderCommandRepository(DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(context, tenantResolver, exceptionManager)
        {

            _entityStructure = new EntityStructure
            {
                Key = ["Id"]
            };
        }

    }
}
