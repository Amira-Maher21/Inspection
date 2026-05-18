using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionRequestDetailF;
using Inspection.Domain.Models.InspectionManagement.InspectionRequests;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Repositories.Query.InspectionManagement.InspectionRequestDetailF
{
   
    public interface IInspectionRequestLinesQueryRepository : IQueryRepository<InspectionRequestLines>
    {
        Task<InspectionRequestLines?> GetByIdAsync(long id);
        Task<ReturnBase<IEnumerable<InspectionRequestLinesDtoByInclude>>> GetListAsync(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<IEnumerable<InspectionRequestLinesDtoByInclude>>> GetListIncludeNameAsync(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<IEnumerable<InspectionRequestLinesDtoByInclude>>> GetLookUpInspectionRequestLinesForNamesAsync(SqlQueryOptions queryOptions);

    }
}
