using Inspection.Application.Contracts.Dto.AccountingDtos.AR.MasterData;
using Inspection.Application.Contracts.Dto.AccountingDtos.AR.MasterData.CustomerContacts;
using Inspection.Application.Contracts.Dto.InspectionManagement.CustomerLocations;
using Inspection.Application.Contracts.Dto.InspectionManagement.CustomerProjects;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Accounting.AR.MasterData
{
    public interface ICustomerServiceMaster
    {

        Task<ReturnBase<CustomerDto>> Create(CustomerCreateDto createDto);
        Task<ReturnBase<CustomerDto>> Update(CustomerUpdateDto updateDto);
        Task<ReturnBase<CustomerDto>> Delete(long id);
        Task<ReturnBase<CustomerDto>> GetById(long id);
        Task<ReturnBase<IEnumerable<CustomerReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);



        //Add List
        Task<ReturnBase<IEnumerable<CustomerLocationDto>>> AddLocations(List<CreateCustomerLocationDto> locations);
        Task<ReturnBase<IEnumerable<CustomerProjectDto>>> AddProjects(List<CreateCustomerProjectDto> projects);
        Task<ReturnBase<IEnumerable<CustomerContactDto>>> AddContacts(List<CustomerContactCreateDto> contacts);


    }
}
