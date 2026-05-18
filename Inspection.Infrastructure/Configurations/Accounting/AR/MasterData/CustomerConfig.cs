using Inspection.Domain.Enums.Accounting;
using Inspection.Domain.Models.Accounting.AR.MasterData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Accounting.AR.MasterData
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer", "Accounting");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Code)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.HasOne(x => x.Series)
                             .WithMany()
                             .HasForeignKey(x => x.SeriesId)
                             .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.CustomerType)
               .HasMaxLength(20)
               .HasDefaultValue(CustomerTypeEnum.Company)
               .IsRequired();

            builder.Property(x => x.NationalId).HasMaxLength(20);
            builder.Property(x => x.TaxRegistrationNo).HasMaxLength(50);
            builder.Property(x => x.CommercialRegistryNo).HasMaxLength(50);

            builder.Property(x => x.Address)
                   .IsRequired()
                   .HasMaxLength(300);



            builder.Property(x => x.Phone)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.Property(x => x.Mobile).HasMaxLength(20);
            builder.Property(x => x.Email).HasMaxLength(100);
            builder.Property(x => x.Website).HasMaxLength(100);

            builder.Property(x => x.CreditLimit)
                   .HasColumnType("decimal(18,2)");

            builder.Property(x => x.Disable).IsRequired();

            builder.Property(x => x.Notes)
                   .HasColumnType("nvarchar(max)");

            // Unique Constraint
            builder.HasIndex(x => new { x.Code, x.Tenant_ID })
                   .IsUnique();

            // Relationships
            builder.HasOne(x => x.Country)
                   .WithMany()
                   .HasForeignKey(x => x.CountryId);

            builder.HasOne(x => x.City)
                   .WithMany()
                   .HasForeignKey(x => x.CityId);

            builder.HasOne(x => x.Currency)
                   .WithMany()
                   .HasForeignKey(x => x.CurrencyId);

            builder.HasOne(x => x.paymentTerm)
                   .WithMany()
                   .HasForeignKey(x => x.PaymentTermId);


            builder.HasMany(x => x.CustomerContact)
                   .WithOne(x => x.Customer)
                   .HasForeignKey(x => x.CustomerId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.CustomerLocation)
                   .WithOne(x => x.Customers)
                   .HasForeignKey(x => x.CustomerId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.CustomerProject)
                   .WithOne(x => x.Customers)
                   .HasForeignKey(x => x.CustomerId)
                   .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
