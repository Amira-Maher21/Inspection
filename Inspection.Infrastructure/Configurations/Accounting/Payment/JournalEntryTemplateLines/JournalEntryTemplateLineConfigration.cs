using Inspection.Domain.Models.Accounting.Payment.JournalEntryTemplates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Accounting.Payment.JournalEntryTemplateLines
{

    public class JournalEntryTemplateLineConfigration
       : IEntityTypeConfiguration<JournalEntryTemplateLine>
    {
        public void Configure(EntityTypeBuilder<JournalEntryTemplateLine> builder)
        {

            builder.ToTable("JournalEntryTemplateLine", "Accounting");

            builder.HasKey(x => x.Id);


            builder.Property(x => x.JournalEntryTemplateId)
                   .IsRequired();

            builder.Property(x => x.AccountId)
                   .IsRequired();


            builder.Property(x => x.DebitAmount)
                   .HasPrecision(18, 6)
                   .IsRequired();

            builder.Property(x => x.CreditAmount)
                   .HasPrecision(18, 6)
                   .IsRequired();

            builder.Property(x => x.CostCenterId)
                   .IsRequired(false);

            builder.Property(x => x.CostUnitId)
                   .IsRequired(false);

            builder.Property(x => x.OperationId)
                   .IsRequired(false);

            builder.Property(x => x.WBSId)
                   .IsRequired(false);

            builder.Property(x => x.ItemWorkId)
                   .IsRequired(false);


            builder.Property(x => x.Description)
                   .HasMaxLength(500)
                   .IsRequired(false);


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

            builder.HasIndex(x => x.JournalEntryTemplateId)
                   .HasDatabaseName("IX_JournalEntryTemplateLine_JournalEntryTemplateId");

            builder.HasIndex(x => x.AccountId)
                   .HasDatabaseName("IX_JournalEntryTemplateLine_AccountId");

            // Parent
            builder.HasOne(x => x.JournalEntryTemplate)
                   .WithMany()
                   .HasForeignKey(x => x.JournalEntryTemplateId);

            builder.HasOne(x => x.Customer)
                .WithMany()
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.CostCenter)
                .WithMany()
                .HasForeignKey(x => x.CostCenterId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.CostUnit)
                .WithMany()
                .HasForeignKey(x => x.CostUnitId)
                .OnDelete(DeleteBehavior.Restrict);

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



            builder.HasOne(x => x.Supplier)
                .WithMany()
                .HasForeignKey(x => x.SupplierId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
