using Inspection.Domain.Models.EquipmentManagement.CompanyEquipments;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Repositories.Command.EquipmentManagement.CompanyEquipments
{
  
    public interface ICompanyEquipmentCommandRepository : ICommandRepository<CompanyEquipment>
    {
        Task<ReturnBase> DeleteByIdAsync(long id);
    }
}
