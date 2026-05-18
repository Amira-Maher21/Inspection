using Inspection.Application.Contracts.Repositories.Command.EquipmentManagement.EquipmentCategorys;
using Inspection.Domain.Models.EquipmentManagement.EquipmentCategorys;
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

namespace Inspection.Infrastructure.Repositories.Command.EquipmentManagement.EquipmentCategorys
{
 
 

    public class EquipmentCategoryCommandRepository : CommandRepositoryBase<EquipmentCategory>, IEquipmentCategoryCommandRepository
    {
        public EquipmentCategoryCommandRepository(DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(context, tenantResolver, exceptionManager)
        {

            _entityStructure = new EntityStructure
            {
                Key = ["Id"]
            };
        }

        public Task<ReturnBase> DeleteByIdAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}

