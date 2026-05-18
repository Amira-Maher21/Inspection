using Inspection.Application.Contracts.Repositories.Query.EquipmentManagement.EquipmentInspections;
using Inspection.Application.Contracts.Repositories.Query.EquipmentManagement.MaintenanceReports;
using Inspection.Domain.Models.EquipmentManagement.EquipmentInspections;
using Inspection.Domain.Models.EquipmentManagement.MaintenanceReports;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Infrastructure.Repositories.Query.EquipmentManagement.MaintenanceReports
{
    public class MaintenanceReportQueryRepository : QueryRepositoryBase<MaintenanceReport>, IMaintenanceReportQueryRepository
    {
        public MaintenanceReportQueryRepository(ISqlQueryBuilder sqlQueryBuilder, DapperDbContext dapperDbContext, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(sqlQueryBuilder, dapperDbContext, context, tenantResolver, exceptionManager)
        {
        }
    }
}
