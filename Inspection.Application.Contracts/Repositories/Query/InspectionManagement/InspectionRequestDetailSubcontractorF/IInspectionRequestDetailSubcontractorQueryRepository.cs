 using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionRequestSubcontractorDetailF;
using Inspection.Domain.Models.InspectionManagement.InspectionRequests;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Repositories.Query.InspectionManagement.InspectionRequestDetailSubcontractorF
{
   
    public interface IInspectionRequestDetailSubcontractorQueryRepository : IQueryRepository<InspectionRequestSubcontractorDetail>
    {
        Task<InspectionRequestSubcontractorDetail?> GetByIdAsync(long id);
        Task<ReturnBase<IEnumerable<InspectionRequestSubcontractorDetailDtoByInclude>>> GetListAsync(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<IEnumerable<InspectionRequestSubcontractorDetailDtoByInclude>>> GetListIncludeNameAsync(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<IEnumerable<InspectionRequestSubcontractorDetailDtoByInclude>>> GetLookUpInspectionRequestDetailSubcontractorForNamesAsync(SqlQueryOptions queryOptions);

    }
}
