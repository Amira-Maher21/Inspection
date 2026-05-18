
 using Inspection.Application.Contracts.Dto.InspectionManagement.ServicesItemsF;
 using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Services.InspectionManagement.ServicesItemsF
{
    public interface IServiceItemService : IAccountServiceBase
    {
        Task<ReturnBase<ServiceItemDto>> GetAsync(long id);

        //Task<ReturnBase<Dictionary<string, string>>> GetSeriesAndNumber(string TableName, string SeriesTableColumn, string Screen_ID);
        Task<ReturnBase<List<ServiceItemIncludeDto>>> GetListByIncludeAsync(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<List<ServiceItemLookupDefualtDto>>> ServiceItemLookupDefualt(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<List<ServiceItemLookUpByIdForInspectionRequestDto>>> ServiceItemLookUpByIdData(SqlQueryOptions sqlQueryOptions);
 

        Task<ReturnBase<List<ServiceItemDto>>> GetListAsync();
        Task<ReturnBase<UpdateServiceItemDto>> CreateAsync(CreateServiceItemDto input);

        Task<ReturnBase<UpdateServiceItemDto>> UpdateAsync(long id, UpdateServiceItemDto input);
        Task<ReturnBase<bool>> DeleteAsync(long id);
    }
}
