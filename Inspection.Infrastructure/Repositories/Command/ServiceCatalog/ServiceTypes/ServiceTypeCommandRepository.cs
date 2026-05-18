using Inspection.Application.Contracts.Dto.ServiceCatalog.ServiceTypes;
using Inspection.Application.Contracts.Repositories.Command.ServiceCatalog.ServiceTypes;
 using Inspection.Domain.Models.ServiceCatalog.ServiceTypes;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.RepositoryBase.RepositoryHelpers;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Infrastructure.Repositories.Command.InspectionManagement
{

    public class ServiceTypeCommandRepository : CommandRepositoryBase<ServiceType>, IServiceTypeCommandRepository
    {
        public ServiceTypeCommandRepository(DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(context, tenantResolver, exceptionManager)
        {

            _entityStructure = new EntityStructure
            {
                Key = ["Id"]
            };
        }



        public async Task<ReturnBase> DeleteByIdAsync(long id)
        {
            var entity = await _dbSet.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (entity is null)
            {
                var error = new ReturnBaseError
                {
                    ErrorCode = "404",
                    ErrorMessage = "ServiceType Not Found"
                };
                var listOfErrors = new List<ReturnBaseError>() { error };
                return ReturnBase.Fail(listOfErrors);
            }
            _dbSet.Remove(entity);
            return ReturnBase.Success();
        }


        public async Task<ReturnBase<CreateServiceTypeDto>> InsertAsync(ServiceType input)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnBase<bool>> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnBase<ServiceTypeDto>> GetAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnBase<List<ServiceTypeDto>>> GetListAsync()
        {
            throw new NotImplementedException();
        }


        public Task<ReturnBase<ServiceTypeDto>> UpdateAsync(long id, UpdateServiceTypeDto input)
        {
            throw new NotImplementedException();
        }
    }
}
//ServiceTypeCommandRepository