using Inspection.Domain.Models.InspectionManagement.ServicesItems;
using Inspection.Domain.Models.MenuManagement;
using NDS.Shared.Application.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Repositories.Command.InspectionManagement.ServicesItemsF
{
    public interface IServiceItemCommandRepository : ICommandRepository<ServiceItem>
    {
    }
}
