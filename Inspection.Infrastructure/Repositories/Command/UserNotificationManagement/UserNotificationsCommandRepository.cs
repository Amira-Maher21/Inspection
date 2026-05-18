using Inspection.Application.Contracts.Repositories.Command.UserNotificationManagement;
using Inspection.Domain.Models.UserNotificationManagement;
using Inspection.Infrastructure.DataContext;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.RepositoryBase.RepositoryHelpers;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Infrastructure.Repositories.Command.UserNotificationManagement
{
    internal class UserNotificationsCommandRepository : CommandRepositoryBase<User_Notification>, IUserNotificationsCommandRepository
    {
        public UserNotificationsCommandRepository(DbInspectionContext context,
                                        ITenantResolver tenantResolver,
                                        IExceptionManager exceptionManager) : base(context, tenantResolver, exceptionManager)
        {
            this._entityStructure = new EntityStructure
            {
                Key = ["ID"],
            };
        }
    }
}
