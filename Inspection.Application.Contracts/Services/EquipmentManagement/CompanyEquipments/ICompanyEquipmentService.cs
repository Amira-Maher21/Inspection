using Inspection.Application.Contracts.Dto.EquipmentManagement.CompanyEquipments;
 using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Services.EquipmentManagement.CompanyEquipments
{
  
    public interface ICompanyEquipmentService : IAccountServiceBase
    {

        Task<ReturnBase<UpdateCompanyEquipmentDto>> InsertCompanyEquipmentAsync(CreateCompanyEquipmentDto insertDto);
        Task<ReturnBase<UpdateCompanyEquipmentDto>> UpdateCompanyEquipmentAsync(UpdateCompanyEquipmentDto updateDto, long id);
        Task<ReturnBase<UpdateCompanyEquipmentDto>> DeleteCompanyEquipmentAsync(long id);
        Task<ReturnBase<CompanyEquipmentDto>> GetCompanyEquipmentByIdAsync(long id);
        Task<ReturnBase<IEnumerable<CompanyEquipmentDtoByInclude>>> GetCompanyEquipmentListAsync(SqlQueryOptions sqlQueryOptions);
        Task<List<CompanyEquipmentDtoByInclude>> GetListAsync();
        Task<ReturnBase<IEnumerable<CompanyEquipmentDtoByInclude>>> GetCompanyEquipmentListByIncludeAsync(SqlQueryOptions sqlQueryOptions);

        //Task<ReturnBase<IEnumerable<CompanyEquipmentDtoLookUpForNames>>> GetLookUpCompanyEquipmentForNamesAsync(SqlQueryOptions queryOptions);

    }
}

