using Inspection.Application.Contracts.Dto.InspectionManagement.CustomerLocations;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.InspectionManagement.CustomerLocations
{
    public interface ICustomerLocationService : IAccountServiceBase
    {

        Task<ReturnBase<UpdateCustomerLocationDto>> InsertCustomerLocationAsync(CreateCustomerLocationDto insertDto);
        Task<ReturnBase<UpdateCustomerLocationDto>> UpdateCustomerLocationAsync(UpdateCustomerLocationDto updateDto, long id);
        Task<ReturnBase<UpdateCustomerLocationDto>> DeleteCustomerLocationAsync(long id);
        Task<ReturnBase<CustomerLocationDto>> GetCustomerLocationByIdAsync(long id);
        //Task<ReturnBase<IEnumerable<CustomerLocationDto>>> GetCustomerLocationListAsync(SqlQueryOptions sqlQueryOptions);
        Task<List<CustomerLocationDto>> GetListAsync();
        Task<ReturnBase<IEnumerable<CustomerLocationDtoByInclude>>> GetCustomerLocationListByIncludeAsync(SqlQueryOptions sqlQueryOptions);

        Task<ReturnBase<IEnumerable<CustomerLocationDtoLookUpForNames>>> GetLookUpCustomerLocationForNamesAsync(SqlQueryOptions queryOptions);

    }
}
