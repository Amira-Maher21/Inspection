using Inspection.Domain.Models.InspectionManagement.InspectionRequests;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Application.SharedModels;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Inspection.Application.Contracts.Repositories.Command.InspectionManagement.InspectionRequests
{
    public interface IInspectionRequestCommandRepository : ICommandRepository<InspectionRequest>
    {
        Task<ReturnBase> DeleteByIdAsync(long id);
 
        //for list of item
        //Task<IEnumerable<InspectionRequestDetail>> InsertAsync(List<InspectionRequestDetail> inspectionRequestDetails);
        //Task<ReturnBase> InsertAsync(InspectionRequestDetail detail);
        //Task<ReturnBase> InsertAsync(InspectionRequestSubcontractorDetail sub);
        //Task<ReturnBase> UpdateAsync(InspectionRequestDetail detail);
        //Task<ReturnBase> UpdateAsync(InspectionRequestSubcontractorDetail sub);
    }
}
