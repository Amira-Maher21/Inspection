using Inspection.Domain.Models.InspectionManagement.InspectionReports;
using NDS.Shared.Application.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Repositories.Query.InspectionManagement.InspectionReports
{
    public interface IInspectionReportQueryRepository : IQueryRepository<InspectionReport>
    {
        //Task<InspectionReport?> GetByIdAsync(Guid id);
        //Task<List<InspectionReport>> GetListAsync();
    }
}
