using Inspection.Application.Contracts.Repositories.Command.SalesManagment.sales;
using Inspection.Domain.Models.Inspection.Techinal.JobOrder;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.RepositoryBase.RepositoryHelpers;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Infrastructure.Repositories.Command.SalesManagment.sales
{
    public class JobOrderCommandRepository : CommandRepositoryBase<JobOrder>, IJobOrderCommandRepository
    {
        public JobOrderCommandRepository(DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(context, tenantResolver, exceptionManager)
        {
            _entityStructure = new EntityStructure
            {
                Key = ["Id"]
            };
        }

    }
}
