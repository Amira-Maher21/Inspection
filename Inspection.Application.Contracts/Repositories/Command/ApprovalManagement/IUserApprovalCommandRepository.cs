using Inspection.Domain.Models.ApprovalManagement;
using NDS.Shared.Application.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Repositories.Command.ApprovalManagement
{
    public interface IUserApprovalCommandRepository : ICommandRepository<User_Approval>
    {
    }
}
