using Inspection.Domain.Models.Inspection.Techinal.JobOrder;
using NDS.Shared.Application.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Repositories.Command.SalesManagment.sales
{
    public interface IJobOrderCommandRepository : ICommandRepository<JobOrder>
    {
    }
}
