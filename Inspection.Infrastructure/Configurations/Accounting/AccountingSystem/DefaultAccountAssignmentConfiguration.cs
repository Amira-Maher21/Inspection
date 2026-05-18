using Inspection.Domain.Models.Accounting.AccountingSystem.DefaultAccountAssignment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Accounting.AccountingSystem
{
    public class DefaultAccountAssignmentConfiguration : IEntityTypeConfiguration<DefaultAccountAssignment>
    {
        [Obsolete]
        public void Configure(EntityTypeBuilder<DefaultAccountAssignment> builder)
        {

            builder.ToTable("DefaultAccountAssignment", "Accounting");

            builder.HasKey(x => x.Id);

            // DefaultAccountGroup (1 → Many)
            builder.HasOne(x => x.DefaultAccountGroup)
                   .WithMany()
                   .HasForeignKey(x => x.DefaultAccountGroupID)
                   .OnDelete(DeleteBehavior.Restrict);

            // DefaultAccountType (1 → Many)
            builder.HasOne(x => x.DefaultAccountType)
                   .WithMany()
                   .HasForeignKey(x => x.DefaultAccountTypeID)
                   .OnDelete(DeleteBehavior.Restrict);

            // ChartOfAccount (1 → Many)
            builder.HasOne(x => x.ChartOfAccount)
                   .WithMany()
                   .HasForeignKey(x => x.AccountID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.CurrencyID)
                   .IsRequired();


            //talent ID
            builder.Property(x => x.Tenant_ID)
                   .IsRequired()
                   .HasMaxLength(100);

            // Audit Fields (Mandatory)


            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);

            builder.Property(x => x.In_Date).IsRequired();

            builder.Property(x => x.Mod_User).HasMaxLength(100);

            builder.Property(x => x.Mod_Date);

            builder.HasIndex(x => new
            {
                x.Tenant_ID,
                x.DefaultAccountGroupID,
                x.DefaultAccountTypeID,
                x.CurrencyID
            })
           .IsUnique();

        }
    }
}