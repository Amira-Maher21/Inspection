using Inspection.Domain.Models.ServiceCatalog.ServiceTypes;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Repositories.Command.ServiceCatalog.ServiceTypes
{
    public interface IServiceTypeCommandRepository : ICommandRepository<ServiceType>
    {
        ////Task InsertAsync(ServiceType entity);
        ////Task UpdateAsync(ServiceType entity);
        ////Task DeleteAsync(ServiceType entity);
        //Task<ServiceType> GetByIdAsync(long id);
        // Task<ReturnBase<ServiceType?>> DeleteByIdAsync(long id);

        Task<ReturnBase> DeleteByIdAsync(long id);

    }

}
