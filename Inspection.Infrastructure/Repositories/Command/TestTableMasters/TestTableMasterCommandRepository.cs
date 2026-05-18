using Inspection.Application.Contracts.Repositories.Command.TestTableMasters;
using Inspection.Domain.Models.TestTableMaster;
using Inspection.Domain.Models.TestTableMasters;
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

namespace Inspection.Infrastructure.Repositories.Command.TestTableMasters 
{
  
    public class TestTableMasterCommandRepository : CommandRepositoryBase<TestTableMaster>, ITestTableMasterCommandRepository
    {
        public TestTableMasterCommandRepository(DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(context, tenantResolver, exceptionManager)
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
                    ErrorMessage = "Inspection Request Not Found"
                };
                var listOfErrors = new List<ReturnBaseError>() { error };
                return ReturnBase.Fail(listOfErrors);
            }
            _dbSet.Remove(entity);
            return ReturnBase.Success();
        }

        public Task<ReturnBase> InsertAsync(TestTableMaster detail)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnBase> InsertAsync(TestTableSubDetail sub)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnBase> UpdateAsync(TestTableDetail detail)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnBase> UpdateAsync(TestTableSubDetail sub)
        {
            throw new NotImplementedException();
        }
    }

}
