using Inspection.Domain.Models.ApprovalManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.ApprovalManagement
{
    public class ApprovalDelegationConfig : IEntityTypeConfiguration<Approval_Delegation>
    {
        public void Configure(EntityTypeBuilder<Approval_Delegation> builder)
        {
            builder.ToTable("Approval_Delegation", "Sec");
            builder.Property(e => e.To_Date).HasColumnType("datetime");

            builder.HasOne(d => d.IDScrAprovalNavigation).WithMany(p => p.Approval_Delegations)
                   .HasForeignKey(d => d.IDScrAproval)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_Approval_Delegation_Approval");
        }
    }
}