 using Inspection.Domain.Models.TestTableMasters;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Services.TestTableMasters
{
    public interface ITestTableSubDetailsService : ICommandRepository<TestTableDetail>
    {
        Task<ReturnBase> DeleteByIdAsync(long id);

    }
}
