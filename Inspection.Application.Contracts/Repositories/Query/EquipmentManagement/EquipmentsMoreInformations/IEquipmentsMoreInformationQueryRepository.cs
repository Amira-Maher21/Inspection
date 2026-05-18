using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentsMoreInformations;
using Inspection.Application.Contracts.Dto.MenuManagement.BranchF;
using Inspection.Domain.Models.EquipmentManagement.EquipmentsMoreInfo;
using Inspection.Domain.Models.MenuManagement;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Repositories.Query.EquipmentManagement.EquipmentsMoreInformations
{
    public interface IEquipmentsMoreInformationQueryRepository : IQueryRepository<EquipmentsMoreInformation>
    {
        Task<EquipmentsMoreInformation?> GetByIdAsync(long id);
         Task<IEnumerable<EquipmentsMoreInformationIncludeDto?>> GetListByIncludeAsync(SqlQueryOptions sqlQueryOptions);

    }
}
