
  using Inspection.Application.Contracts.Dto.ServiceCatalog.ServiceTypes;
using Inspection.Application.Contracts.Services;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Services.ServiceCatalog.ServiceTypes
{
    public interface IServiceTypeService : IAccountServiceBase
    {
        Task<ReturnBase<UpdateServiceTypeDto>> InsertServiceTypeAsync(CreateServiceTypeDto insertDto);
        Task<ReturnBase<UpdateServiceTypeDto>> UpdateServiceTypeAsync(UpdateServiceTypeDto updateDto, long id);
        Task<ReturnBase<UpdateServiceTypeDto>> DeleteServiceTypeAsync(long id);
        Task<ReturnBase<ServiceTypeDto>> GetServiceTypeByIdAsync(long id);
        Task<ReturnBase<IEnumerable<ServiceTypeDtoByInclude>>> GetServiceTypeListAsync(SqlQueryOptions sqlQueryOptions);
        Task<List<ServiceTypeDtoByInclude>> GetListAsync();
        Task<ReturnBase<IEnumerable<ServiceTypeDtoByInclude>>> GetServiceTypeListByIncludeAsync(SqlQueryOptions sqlQueryOptions);

        Task<ReturnBase<IEnumerable<ServiceTypeDtoLookUpForNames>>> GetLookUpServiceTypeForNamesAsync(SqlQueryOptions queryOptions);

    }
}
