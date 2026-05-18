using Inspection.Application.Contracts.Repositories.Command.EquipmentManagement.Equipments;
using Inspection.Application.Contracts.Repositories.Command.EquipmentManagement.MaintenanceReports;
using Inspection.Domain.Models.EquipmentManagement.MaintenanceReports;
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

namespace Inspection.Infrastructure.Repositories.Command.EquipmentManagement.MaintenanceReports
{
    public class MaintenanceReportCommandRepository : CommandRepositoryBase<MaintenanceReport>, IMaintenanceReportCommandRepository
    {
        public MaintenanceReportCommandRepository(DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(context, tenantResolver, exceptionManager)
        {

            _entityStructure = new EntityStructure
            {
                Key = ["Id"]
            };
        }
    }
}
