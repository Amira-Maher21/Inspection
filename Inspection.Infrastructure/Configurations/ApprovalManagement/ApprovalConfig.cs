using Inspection.Domain.Models.ApprovalManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.ApprovalManagement
{
    public class ApprovalConfig : IEntityTypeConfiguration<Approval>
    {
        public void Configure(EntityTypeBuilder<Approval> builder)
        {
            builder.ToTable("Approval", "Sec");
            builder.HasKey(e => e.Id).HasName("PK_Screen_Code_dApproval");

            builder.Property(e => e.ScreenId).HasMaxLength(100);
            builder.Property(e => e.Tenant_ID).HasMaxLength(10);
            builder.Property(e => e.WorkFlowTitle).HasMaxLength(300);

            builder.HasOne(x => x.Screen)
                   .WithMany()
                   .HasForeignKey(x => x.ScreenId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}