 using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionRequests;
using Inspection.Application.Contracts.Dto.InspectionManagement.CustomerProjects;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Services.InspectionManagement.CustomerProjects
{
    public interface ICustomerProjectService : IAccountServiceBase
    {

        Task<ReturnBase<UpdateCustomerProjectDto>> InsertCustomerProjectAsync(CreateCustomerProjectDto insertDto);
        Task<ReturnBase<UpdateCustomerProjectDto>> UpdateCustomerProjectAsync(UpdateCustomerProjectDto updateDto, long id);
        Task<ReturnBase<UpdateCustomerProjectDto>> DeleteCustomerProjectAsync(long id);
        Task<ReturnBase<CustomerProjectDto>> GetCustomerProjectByIdAsync(long id);
        //Task<ReturnBase<IEnumerable<CustomerProjectDtoByInclude>>> GetCustomerProjectListAsync(SqlQueryOptions sqlQueryOptions);
        Task<List<CustomerProjectDto>> GetListAsync();
        Task<ReturnBase<IEnumerable<CustomerProjectDtoByInclude>>> GetCustomerProjectListByIncludeAsync(SqlQueryOptions sqlQueryOptions);

        Task<ReturnBase<IEnumerable<CustomerProjectDtoLookUpForNames>>> GetLookUpCustomerProjectForNamesAsync(SqlQueryOptions queryOptions);

    }
}
