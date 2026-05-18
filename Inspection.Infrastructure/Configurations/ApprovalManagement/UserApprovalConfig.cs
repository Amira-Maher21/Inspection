using Inspection.Domain.Models.ApprovalManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.ApprovalManagement
{
    public class UserApprovalConfig : IEntityTypeConfiguration<User_Approval>
    {
        public void Configure(EntityTypeBuilder<User_Approval> builder)
        {
            builder.ToTable("User_Approval", "Syst");
            builder.HasKey(e => e.id).HasName("PK_User_Approvals");

            builder.Property(e => e.ActionDate).HasColumnType("datetime");
            builder.Property(e => e.Date).HasColumnType("datetime");
            builder.Property(e => e.Delegate_Reasons).HasMaxLength(500);
            builder.Property(e => e.Descrp).HasMaxLength(1000);
            builder.Property(e => e.Hold_Reasons).HasMaxLength(500);
            builder.Property(e => e.In_User).HasMaxLength(4);
            builder.Property(e => e.Keys).HasMaxLength(2000);
            builder.Property(e => e.ReceivedDate).HasColumnType("datetime");
            builder.Property(e => e.Rejected_Reasons).HasMaxLength(500);
            builder.Property(e => e.RepFileName).HasMaxLength(500);
            builder.Property(e => e.Returned_Reasons).HasMaxLength(500);
            builder.Property(e => e.ScreenName).HasMaxLength(220);
            builder.Property(e => e.Screen_ID).HasMaxLength(100);
            builder.Property(e => e.Status).HasComment("0 Initialized 1 New 2 Approved 3 Rejected 4 Returned 5 Hold 6 Delegate 7 Completed 8 Sent");
            builder.Property(e => e.TableMasterName).HasMaxLength(220);
            builder.Property(e => e.Values).HasMaxLength(2000);
        }
    }
}