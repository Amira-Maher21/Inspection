using Inspection.Domain.Models.Accounting.Payment.DebitNotes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Accounting.Payment.DebitNotes
{
    public class DebitNoteAdjustmentConfiguration : IEntityTypeConfiguration<DebitNoteAdjustment>
    {
        [Obsolete]
        public void Configure(EntityTypeBuilder<DebitNoteAdjustment> builder)
        {
            builder.ToTable("DebitNoteAdjustment", "Accounting");

            // Primary Key
            builder.HasKey(x => x.Id);

            // Indexes
            builder.HasIndex(x => x.DebitNoteId);

            // Properties
            builder.Property(x => x.Amount).IsRequired().HasPrecision(18, 2);
            builder.Property(x => x.Description).HasMaxLength(500);

            // Audit
            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);
            builder.Property(x => x.In_Date).IsRequired();
            builder.Property(x => x.Mod_User).HasMaxLength(100);
            builder.Property(x => x.Mod_Date);

            // Required FKs
            builder.Property(x => x.DebitNoteId).IsRequired();
            builder.Property(x => x.ChartOfAccountId).IsRequired();

            // Optional FKs

            builder.Property(x => x.CostCenterId).IsRequired(false);
            builder.Property(x => x.CostUnitId).IsRequired(false);
            builder.Property(x => x.OperationId).IsRequired(false);
            builder.Property(x => x.WBSId).IsRequired(false);
            builder.Property(x => x.CostCodeId).IsRequired(false);
            builder.Property(x => x.ActivityId).IsRequired(false);
            builder.Property(x => x.BOQLineId).IsRequired(false);
            builder.Property(x => x.SubcontractBOQId).IsRequired(false);
            builder.Property(x => x.ProductionOrderId).IsRequired(false);

            // Relationships
            builder.HasOne(x => x.WBS)
                .WithMany()
                .HasForeignKey(x => x.WBSId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Activity)
                   .WithMany()
                   .HasForeignKey(x => x.ActivityId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.CostCode)
                   .WithMany()
                   .HasForeignKey(x => x.CostCodeId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.SubcontractBOQ)
                   .WithMany()
                   .HasForeignKey(x => x.SubcontractBOQId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.ProductionOrder)
                   .WithMany()
                   .HasForeignKey(x => x.ProductionOrderId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.BOQLine)
                   .WithMany()
                   .HasForeignKey(x => x.BOQLineId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Parent DebitNote
            builder.HasOne(x => x.DebitNote)
                   .WithMany()
                   .HasForeignKey(x => x.DebitNoteId);

            // Chart Of Account
            builder.HasOne(x => x.ChartOfAccount)
                   .WithMany()
                   .HasForeignKey(x => x.ChartOfAccountId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Cost Center
            builder.HasOne(x => x.CostCenter)
                   .WithMany()
                   .HasForeignKey(x => x.CostCenterId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Cost Unit
            builder.HasOne(x => x.CostUnit)
                   .WithMany()
                   .HasForeignKey(x => x.CostUnitId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Operation
            builder.HasOne(x => x.Operation)
                   .WithMany()
                   .HasForeignKey(x => x.OperationId)
                   .OnDelete(DeleteBehavior.Restrict);

            // CHECK CONSTRAINTS

            // Amount != 0
            builder.HasCheckConstraint(
                "CK_DebitNoteAdjustment_Amount",
                "[Amount] <> 0"
            );
        }
    }
}