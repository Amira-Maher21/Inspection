using Inspection.Application.Contracts.Dto.EquipmentManagement.CompanyEquipments;
 using Inspection.Domain.Models.EquipmentManagement.CompanyEquipments;
 using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Repositories.Query.EquipmentManagement.CompanyEquipments
{
 
    public interface ICompanyEquipmentQueryRepository : IQueryRepository<CompanyEquipment>
    {
        Task<CompanyEquipment?> GetByIdAsync(long id);
        Task<ReturnBase<IEnumerable<CompanyEquipmentDtoByInclude>>> GetListAsync(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<IEnumerable<CompanyEquipmentDtoByInclude>>> GetListIncludeNameAsync(SqlQueryOptions sqlQueryOptions);
        //Task<ReturnBase<IEnumerable<CompanyEquipmentDtoByInclude>>> GetLookUpCompanyEquipmentForNamesAsync(SqlQueryOptions queryOptions);

    }
}
