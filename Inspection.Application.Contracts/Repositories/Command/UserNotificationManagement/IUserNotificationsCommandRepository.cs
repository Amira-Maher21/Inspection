using Inspection.Domain.Models.UserNotificationManagement;
using NDS.Shared.Application.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Repositories.Command.UserNotificationManagement
{
    public interface IUserNotificationsCommandRepository : ICommandRepository<User_Notification>
    {
    }
}
