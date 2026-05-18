 using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionRequestSubcontractorDetailF;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Services.InspectionManagement.InspectionRequestDetailSubcontractorF
{

    public interface IInspectionRequestDetailSubcontractorService : IAccountServiceBase
    {

        Task<ReturnBase<UpdateInspectionRequestSubcontractorDetailDto>> InsertInspectionRequestDetailSubcontractorAsync(CreateInspectionRequestSubcontractorDetailDto insertDto);
        Task<ReturnBase<UpdateInspectionRequestSubcontractorDetailDto>> UpdateInspectionRequestDetailSubcontractorAsync(UpdateInspectionRequestSubcontractorDetailDto updateDto, long id);
        Task<ReturnBase<UpdateInspectionRequestSubcontractorDetailDto>> DeleteInspectionRequestDetailSubcontractorAsync(long id);
        Task<ReturnBase<InspectionRequestSubcontractorDetailDto>> GetInspectionRequestDetailSubcontractorByIdAsync(long id);
        Task<ReturnBase<IEnumerable<InspectionRequestSubcontractorDetailDtoByInclude>>> GetInspectionRequestDetailSubcontractorListAsync(SqlQueryOptions sqlQueryOptions);
        Task<List<InspectionRequestSubcontractorDetailDtoByInclude>> GetListAsync();
        Task<ReturnBase<IEnumerable<InspectionRequestSubcontractorDetailDtoByInclude>>> GetInspectionRequestDetailSubcontractorListByIncludeAsync(SqlQueryOptions sqlQueryOptions);

        //Task<ReturnBase<IEnumerable<InspectionRequestDetailSubcontractorDtoLookUpForNames>>> GetLookUpInspectionRequestDetailSubcontractorForNamesAsync(SqlQueryOptions queryOptions);

    }
}
