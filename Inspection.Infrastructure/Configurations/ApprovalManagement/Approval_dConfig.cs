using Inspection.Domain.Models.ApprovalManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.ApprovalManagement
{
    public class Approval_dConfig : IEntityTypeConfiguration<Approval_d>
    {
        public void Configure(EntityTypeBuilder<Approval_d> builder)
        {
            builder.ToTable("Approval_d", "Sec");
            builder.HasKey(e => new { e.IDScrAproval, e.RecordID }).HasName("PK_Screen_Code_dApproval_List");

            builder.Property(e => e.Approval_title).HasMaxLength(20);
            builder.Property(e => e.From_Val).HasColumnType("decimal(18, 2)");
            builder.Property(e => e.To_Date).HasColumnType("datetime");
            builder.Property(e => e.To_Val).HasColumnType("decimal(18, 2)");
            builder.Property(e => e.User_CodeId).IsRequired();
            builder.Property(e => e.Tenant_ID).HasMaxLength(10);

            builder.HasOne(d => d.IDScrAprovalNavigation).WithMany(p => p.Approval_ds)
                .HasForeignKey(d => d.IDScrAproval)
                .HasConstraintName("FK_Screen_Code_dApproval_List_Screen_Code_dApproval");

            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(e => e.User_CodeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}