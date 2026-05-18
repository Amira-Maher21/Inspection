using Inspection.Domain.Models.Accounting.Payment.JournalEntryLines;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Accounting.Payment.JournalEntryLines
{
    public class JournalEntryLineConfiguration : IEntityTypeConfiguration<JournalEntryLine>
    {
        public void Configure(EntityTypeBuilder<JournalEntryLine> builder)
        {
            builder.ToTable("JournalEntryLine", "Accounting");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id);

            builder.Property(x => x.JournalEntryId)
                   .IsRequired();

            builder.Property(x => x.ChartOfAccountId)
                   .IsRequired();

            builder.Property(x => x.DebitAmount)
                   .HasPrecision(18, 6)
                   .IsRequired();

            builder.Property(x => x.CreditAmount)
                   .HasPrecision(18, 6)
                   .IsRequired();

            builder.Property(x => x.CostCenterId)
                   .IsRequired(false);

            builder.Property(x => x.OperationId)
                   .IsRequired(false);

            builder.Property(x => x.Description)
                   .HasMaxLength(500)
                   .IsRequired();

            builder.Property(x => x.In_User)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.In_Date)
                   .IsRequired();

            builder.Property(x => x.Mod_User)
                   .HasMaxLength(100)
                   .IsRequired(false);

            builder.Property(x => x.Mod_Date)
                   .IsRequired(false);

            builder.HasOne(x => x.JournalEntry)
                   .WithMany(j => j.JournalEntryLines)
                   .HasForeignKey(x => x.JournalEntryId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.ChartOfAccount)
                   .WithMany()
                   .HasForeignKey(x => x.ChartOfAccountId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.CostCenter)
                   .WithMany()
                   .HasForeignKey(x => x.CostCenterId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Operation)
                   .WithMany()
                   .HasForeignKey(x => x.OperationId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Customer)
                   .WithMany()
                   .HasForeignKey(x => x.CustomerId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Supplier)
                     .WithMany()
                     .HasForeignKey(x => x.SupplierId)
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

            builder.HasOne(x => x.FixedAsset)
                   .WithMany()
                   .HasForeignKey(x => x.AssetId)
                   .OnDelete(DeleteBehavior.Restrict);


            // Enums
            builder.Property(x => x.LineType)
                   .HasConversion<int>();

            builder.Property(x => x.AssetTransactionType)
                   .HasConversion<int>();

            // Indexes
            builder.HasIndex(x => x.JournalEntryId);
            builder.HasIndex(x => x.ChartOfAccountId);
            builder.HasIndex(x => x.CostCenterId);
            builder.HasIndex(x => x.OperationId);

        }
    }
}