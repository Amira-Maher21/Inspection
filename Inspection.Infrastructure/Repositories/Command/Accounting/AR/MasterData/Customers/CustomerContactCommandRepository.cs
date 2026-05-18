using Inspection.Application.Contracts.Repositories.Command.Accounting.AR.MasterData;
using Inspection.Domain.Models.Accounting.AR.MasterData;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.RepositoryBase.RepositoryHelpers;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Infrastructure.Repositories.Command.Accounting.AR.MasterData.Customers
{
    public class CustomerContactCommandRepository : CommandRepositoryBase<CustomerContact>, ICustomerContactCommandRepository
    {
        public CustomerContactCommandRepository(DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(context, tenantResolver, exceptionManager)
        {

            _entityStructure = new EntityStructure
            {
                Key = ["Id"]
            };
        }


        public async Task<ReturnBase<IEnumerable<CustomerContact>>> GetListByCustomerId(long customerId)
        {
            var contacts = await _dbSet.Where(c => c.CustomerId == customerId).ToListAsync();
            return ReturnBase<IEnumerable<CustomerContact>>.Success(contacts);
        }
    }
}
