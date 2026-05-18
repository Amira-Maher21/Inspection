using Inspection.Domain.Models.InspectionManagement.InspectionReports;
using NDS.Shared.Application.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Repositories.Command.InspectionManagement.InspectionReports
{
    public interface IInspectionReportCommandRepository : ICommandRepository<InspectionReport>
    {
        //Task InsertAsync(InspectionReport entity);
        //Task UpdateAsync(InspectionReport entity);
        //Task DeleteAsync(InspectionReport entity);
        //Task DeleteByIdAsync(Guid id);
    }

}
