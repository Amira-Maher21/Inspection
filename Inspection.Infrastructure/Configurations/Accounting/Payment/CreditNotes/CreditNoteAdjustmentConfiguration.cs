using Inspection.Domain.Models.Accounting.Payment.CreditNotes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Accounting.Payment.CreditNotes
{
    public class CreditNoteAdjustmentConfiguration : IEntityTypeConfiguration<CreditNoteAdjustment>
    {
        [Obsolete]
        public void Configure(EntityTypeBuilder<CreditNoteAdjustment> builder)
        {
            builder.ToTable("CreditNoteAdjustment", "Accounting");

            // Primary Key
            builder.HasKey(x => x.Id);

            // Indexes
            builder.HasIndex(x => x.CreditNoteId);

            // Properties
            builder.Property(x => x.Amount).IsRequired().HasPrecision(18, 2);
            builder.Property(x => x.Description).HasMaxLength(500);

            // Audit
            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);
            builder.Property(x => x.In_Date).IsRequired();
            builder.Property(x => x.Mod_User).HasMaxLength(100);
            builder.Property(x => x.Mod_Date);

            // Required FKs
            builder.Property(x => x.CreditNoteId).IsRequired();
            builder.Property(x => x.ChartOfAccountId).IsRequired();

            // Relationships

            // Parent CreditNote
            builder.HasOne(x => x.CreditNote)
                   .WithMany()
                   .HasForeignKey(x => x.CreditNoteId);

            // Chart Of Account
            builder.HasOne(x => x.ChartOfAccount)
                   .WithMany()
                   .HasForeignKey(x => x.ChartOfAccountId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Cost Center (Optional)
            builder.HasOne(x => x.CostCenter)
                   .WithMany()
                   .HasForeignKey(x => x.CostCenterId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Cost Unit (Optional)
            builder.HasOne(x => x.CostUnit)
                   .WithMany()
                   .HasForeignKey(x => x.CostUnitId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Operation (Optional)
            builder.HasOne(x => x.Operation)
                   .WithMany()
                   .HasForeignKey(x => x.OperationId)
                   .OnDelete(DeleteBehavior.Restrict);


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




            // CHECK CONSTRAINTS 

            // Amount != 0
            builder.HasCheckConstraint(
                "CK_CreditNoteAdjustment_Amount",
                "[Amount] <> 0"
            );
        }
    }
}