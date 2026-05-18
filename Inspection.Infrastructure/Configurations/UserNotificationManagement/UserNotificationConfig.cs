using Inspection.Domain.Models.UserNotificationManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.UserNotificationManagement
{
    public class UserNotificationConfig : IEntityTypeConfiguration<User_Notification>
    {
        public void Configure(EntityTypeBuilder<User_Notification> builder)
        {

            builder.ToTable("User_Notification", "Syst");

            builder.HasKey(e => e.ID).HasName("PK_User_Notifications_1");

            builder.Property(e => e.Date).HasColumnType("datetime");
            builder.Property(e => e.Descrp).HasMaxLength(3000);
            builder.Property(e => e.Email_Error).HasMaxLength(500);
            builder.Property(e => e.NotificationSubject).HasMaxLength(300);
            builder.Property(e => e.Push_Error).HasMaxLength(500);
            builder.Property(e => e.Screen_ID).HasMaxLength(100);
            builder.Property(e => e.Unread).HasDefaultValue(true);
            builder.Property(e => e.Values).HasMaxLength(2000);
        }
    }
}