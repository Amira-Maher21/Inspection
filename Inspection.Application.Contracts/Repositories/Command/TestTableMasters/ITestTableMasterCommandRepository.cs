using Inspection.Domain.Models.TestTableMaster;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Repositories.Command.TestTableMasters
{
    public interface ITestTableMasterCommandRepository : ICommandRepository<TestTableMaster>
    {
        Task<ReturnBase> DeleteByIdAsync(long id);

    }
}
