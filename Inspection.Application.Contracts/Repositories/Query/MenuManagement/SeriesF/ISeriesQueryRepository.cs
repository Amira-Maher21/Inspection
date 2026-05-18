using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentInspections;
using Inspection.Domain.Models.EquipmentManagement.EquipmentInspections;
using Inspection.Domain.Models.EquipmentManagement.Equipments;
using Inspection.Domain.Models.MenuManagement;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Repositories.Query.MenuManagement.SeriesF
{
    public interface ISeriesQueryRepository : IQueryRepository<Series>
    {
        
        Task<Series?> GetByIdAsync(long id);

        Task<Series?> GetByScreen_IDAsync(string Screen_ID);
 
        Task<Dictionary<string,string>?> GetSeriesTableNumberAsync(string TableName,string SeriesTableColumn ,string Screen_ID, string FinalSeriesCode);
       

    }
}
