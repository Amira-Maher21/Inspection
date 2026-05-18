using Inspection.Application.Contracts.Repositories.Command.InspectionManagement.InspectionReports;
using Inspection.Domain.Models.InspectionManagement.InspectionReports;
using Inspection.Infrastructure.DataContext;
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

namespace Inspection.Infrastructure.Repositories.Command.InspectionManagement.InspectionReports
{
    public class InspectionReportCommandRepository : CommandRepositoryBase<InspectionReport>, IInspectionReportCommandRepository
    {
        public InspectionReportCommandRepository(DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(context, tenantResolver, exceptionManager)
        {

            _entityStructure = new EntityStructure
            {
                Key = ["Id"]
            };
        }

    }
}