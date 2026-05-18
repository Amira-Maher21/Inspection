using Inspection.Domain.Models.InspectionManagement.InspectionRequests;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Repositories.Command.InspectionManagement.InspectionRequestDetailSubcontractorF
{


    public interface IInspectionRequestDetailSubcontractorCommandRepository : ICommandRepository<InspectionRequestSubcontractorDetail>
    {
         

        Task<ReturnBase> DeleteByIdAsync(long id);
    }
}
