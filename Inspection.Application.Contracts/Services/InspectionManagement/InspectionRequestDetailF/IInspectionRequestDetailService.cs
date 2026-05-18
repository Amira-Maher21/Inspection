using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionRequestDetailF;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Services.InspectionManagement.InspectionRequestDetailF
{

    public interface IInspectionRequestLinesService : IAccountServiceBase
    {

        Task<ReturnBase<UpdateInspectionRequestLinesDto>> InsertInspectionRequestLinesAsync(CreateInspectionRequestLinesDto insertDto);
        Task<ReturnBase<UpdateInspectionRequestLinesDto>> UpdateInspectionRequestLinesAsync(UpdateInspectionRequestLinesDto updateDto, long id);
        Task<ReturnBase<UpdateInspectionRequestLinesDto>> DeleteInspectionRequestLinesAsync(long id);
        Task<ReturnBase<InspectionRequestLinesDto>> GetInspectionRequestLinesByIdAsync(long id);
        Task<ReturnBase<IEnumerable<InspectionRequestLinesDtoByInclude>>> GetInspectionRequestLinesListAsync(SqlQueryOptions sqlQueryOptions);
        Task<List<InspectionRequestLinesDtoByInclude>> GetListAsync();
        Task<ReturnBase<IEnumerable<InspectionRequestLinesDtoByInclude>>> GetInspectionRequestLinesListByIncludeAsync(SqlQueryOptions sqlQueryOptions);

        //Task<ReturnBase<IEnumerable<InspectionRequestLinesDtoLookUpForNames>>> GetLookUpInspectionRequestLinesForNamesAsync(SqlQueryOptions queryOptions);

    }
}
