using NDS.Shared.Application.DataQuery;

namespace Inspection.Application.Contracts.Dto.UserNotificationManagement
{
    public class UserNotificationsIndexItemDto
    {
        public int ID { get; set; }
        public long? User_CodeId { get; set; }
        public string? Screen_ID { get; set; }
        public string? Values { get; set; }
        public string? NotificationSubject { get; set; }
        public string? Descrp { get; set; }
        public bool Unread { get; set; }
        public DateTime Date { get; set; }
        public string? Push_Error { get; set; }
        public string? Email_Error { get; set; }
    }

    public class UserNotificationsHelperDto
    {
        public SqlQueryOptions queryOptions { get; set; } = null!;
        public UserNotificationsIndexItemDto userNotificationsIndexItemDto { get; set; } = null!;
    }
}
