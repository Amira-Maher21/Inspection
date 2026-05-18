using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Services
{
    public class NewNotificationHub : Hub
    {
        public static IHubContext HubContext => GlobalHost.ConnectionManager.GetHubContext<NewNotificationHub>();
    }
}
