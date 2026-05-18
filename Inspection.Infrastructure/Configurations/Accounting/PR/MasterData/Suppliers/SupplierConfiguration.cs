using Inspection.Domain.Enums.Accounting.AR.MasterData;
using Inspection.Domain.Models.Accounting.PR.MasterData.Suppliers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Accounting.PR.MasterData.Suppliers
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("Supplier", "Accounting");


            //Property
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Code)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.HasOne(x => x.Series)
                            .WithMany()
                            .HasForeignKey(x => x.SeriesId)
                            .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(200);


            builder.Property(x => x.SupplierTypeEnum)
              .HasMaxLength(20)
              .HasDefaultValue(SupplierTypeEnum.Company)
              .IsRequired();

            builder.Property(x => x.NationId)
                   .HasMaxLength(20);
            builder.Property(x => x.TaxRegistration)
                    .HasMaxLength(50);
            builder.Property(x => x.CommercialRegistry)
                    .HasMaxLength(50);
            builder.Property(x => x.Address)
                   .IsRequired()
                   .HasMaxLength(300);
            builder.Property(x => x.Phone)
                   .IsRequired()
                   .HasMaxLength(20);
            builder.Property(x => x.Mobile)
                    .HasMaxLength(20);
            builder.Property(x => x.Email)
                    .HasMaxLength(100);
            builder.Property(x => x.Website)
                    .HasMaxLength(100);
            builder.Property(x => x.PaymentTermsId);
            builder.Property(x => x.CreditLimit)
                   .HasColumnType("decimal(18,2)");
            builder.Property(x => x.Dsiable);
            builder.Property(x => x.Notes)
                   .HasColumnType("nvarchar(max)");


            // Foreign Keys

            builder.HasOne(x => x.Country)
                   .WithMany()
                   .HasForeignKey(x => x.CountryId);
            builder.HasOne(x => x.City)
                   .WithMany()
                   .HasForeignKey(x => x.CityId);
            builder.HasOne(x => x.Currency)
                   .WithMany()
                   .HasForeignKey(x => x.CurrencyId);
            builder.HasOne(x => x.TaxCategory)
                   .WithMany()
                   .HasForeignKey(x => x.TaxCategoryId);
            //builder.HasOne(x => x.SupplierGroup)
            //       .WithMany()
            //       .HasForeignKey(x => x.SupplierGroupId);



            //IsUnique
            builder.HasIndex(x => new { x.Tenant_ID, x.Code }).IsUnique();




            builder.Property(x => x.Tenant_ID)
                      .IsRequired()
                      .HasMaxLength(100);
            builder.Property(x => x.In_User)
                       .IsRequired()
                       .HasMaxLength(100);

            builder.Property(x => x.Mod_User)
                      .HasMaxLength(100);
            builder.Property(x => x.Mod_Date);
        }
    }
}
