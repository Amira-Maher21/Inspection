using Inspection.Domain.Models.HRManagement.ApplicantCVs;
using Inspection.Domain.Models.HRManagement.Employees;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Repositories.Command.HRManagement.Employees
{
    public interface IEmployeeCommandRepository : ICommandRepository<Employee>
    {
        Task<ReturnBase> DeleteByIdAsync(long id);
    }
}
