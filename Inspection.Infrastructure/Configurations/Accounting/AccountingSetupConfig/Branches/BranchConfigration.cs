using Inspection.Domain.Models.Accounting.AccountingSetup.Branches;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Accounting.AccountingSetupConfig.Branches
{
    public class BranchConfigration : IEntityTypeConfiguration<Branch>
    {
        [Obsolete]
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.ToTable("Branch", "Accounting");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Tenant_ID)
                   .IsRequired();

            builder.Property(x => x.CompanyId)
                   .IsRequired();

            builder.Property(x => x.Code)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(x => x.Description)
                   .HasMaxLength(255);

            builder.Property(x => x.Address)
                   .HasMaxLength(255);

            builder.Property(x => x.Phone)
                   .HasMaxLength(20);

            builder.Property(x => x.Email)
                   .HasMaxLength(254);



            builder.HasIndex(x => new { x.CompanyId, x.Tenant_ID, x.Code })
                   .IsUnique()
                   .HasDatabaseName("UQ_Branch_Company_Tenant_Code");

            builder.HasOne(x => x.Company)
                   .WithMany()
                   .HasForeignKey(x => x.CompanyId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Country)
                   .WithMany()
                   .HasForeignKey(x => x.CountryId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.City)
                   .WithMany()
                   .HasForeignKey(x => x.CityId)
                   .OnDelete(DeleteBehavior.Restrict);


        }
    }
}