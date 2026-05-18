using Inspection.Application.Contracts.Repositories.Query.EquipmentManagement.MaintenanceReports;
using Inspection.Application.Contracts.Repositories.Query.EquipmentManagement.MaintenanceSchedules;
using Inspection.Domain.Models.EquipmentManagement.MaintenanceReports;
using Inspection.Domain.Models.EquipmentManagement.MaintenanceSchedules;
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

namespace Inspection.Infrastructure.Repositories.Query.EquipmentManagement.MaintenanceSchedules
{
    public class MaintenanceScheduleQueryRepository : QueryRepositoryBase<MaintenanceSchedule>, IMaintenanceScheduleQueryRepository
    {
        public MaintenanceScheduleQueryRepository(ISqlQueryBuilder sqlQueryBuilder, DapperDbContext dapperDbContext, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(sqlQueryBuilder, dapperDbContext, context, tenantResolver, exceptionManager)
        {
        }
    }
}
