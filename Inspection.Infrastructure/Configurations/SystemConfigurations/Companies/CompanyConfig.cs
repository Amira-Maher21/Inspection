using Inspection.Domain.Models.SystemConfigurations.Companies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.SystemConfigurations.Companies
{
    public class CompanyConfig : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Company", "Sec");
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => new { x.Tenant_ID, x.Code }).IsUnique();

            // Required Fields
            builder.Property(x => x.Tenant_ID).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Code).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Address).IsRequired().HasMaxLength(500);
            builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(50);
            builder.Property(x => x.CountryId).IsRequired();

            // Email Validation
            builder.Property(x => x.Email)
                   .IsRequired(false)
                   .HasMaxLength(200)
                   .HasAnnotation("RegularExpression", @"^[^@\s]+@[^@\s]+\.[^@\s]+$");

            // Optional Fields
            builder.Property(x => x.Website).HasMaxLength(300)
                   .HasAnnotation("RegularExpression", @"^https?://.*");



            builder.Property(x => x.TaxIdNumber).IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.CommercialRegisterNumber).IsRequired()
                   .HasMaxLength(100);

            // Foreign Keys

            builder.HasOne(c => c.BaseCurrency)
                       .WithMany()
                       .HasForeignKey(c => c.BaseCurrencyId)
                       .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.OfficialCurrency)
                   .WithMany()
                   .HasForeignKey(c => c.OfficialCurrencyId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.City)
                   .WithMany()
                   .HasForeignKey(x => x.CityId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Country)
                   .WithMany()
                   .HasForeignKey(x => x.CountryId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ReportingCurrency)
                     .WithMany()
                     .HasForeignKey(x => x.ReportingCurrencyId)
                     .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(x => x.DefaultTaxType)
                  .WithMany()
                  .HasForeignKey(x => x.DefaultTaxTypeId)
                  .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(x => x.DefaultTaxType2)
                  .WithMany()
                  .HasForeignKey(x => x.DefaultTaxType2Id)
                  .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(x => x.InventoryAccount)
                  .WithMany()
                  .HasForeignKey(x => x.InventoryAccountId)
                  .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(x => x.CogsAccount)
                  .WithMany()
                  .HasForeignKey(x => x.CogsAccountId)
                  .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(x => x.AdjustmentAccount)
                  .WithMany()
                  .HasForeignKey(x => x.AdjustmentAccountId)
                  .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(x => x.RevenueAccount)
                  .WithMany()
                  .HasForeignKey(x => x.RevenueAccountId)
                  .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(x => x.PurchaseAccount)
                  .WithMany()
                  .HasForeignKey(x => x.PurchaseAccountId)
                  .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(x => x.PurchaseReturnAccount)
                  .WithMany()
                  .HasForeignKey(x => x.PurchaseReturnAccountId)
                  .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(x => x.SalesReturnAccount)
                  .WithMany()
                  .HasForeignKey(x => x.SalesReturnAccountId)
                  .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(x => x.GoodsReceivedNotInvoicedAccount)
                  .WithMany()
                  .HasForeignKey(x => x.GoodsReceivedNotInvoicedAccountId)
                  .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(x => x.WipAccount)
                  .WithMany()
                  .HasForeignKey(x => x.WipAccountId)
                  .OnDelete(DeleteBehavior.Restrict);



            //builder.Property(x => x.CompanyLogoPhotoid).IsRequired(false);

            //builder.Property(x => x.IndustrySector).HasMaxLength(200);
            //builder.Property(x => x.BuildingNumber).HasMaxLength(50);
            //builder.Property(x => x.Street).HasMaxLength(200);
            //builder.Property(x => x.Zone).HasMaxLength(100);

            //boll
            builder.Property(x => x.ActiveCostCenter)
                     .IsRequired()
                     .HasDefaultValue(false);

            builder.Property(x => x.ActiveCostUnit)
                   .IsRequired()
                   .HasDefaultValue(false);

            builder.Property(x => x.ActiveOperation)
                   .IsRequired()
                   .HasDefaultValue(false);

            builder.Property(x => x.ActiveWBS)
                   .IsRequired()
                   .HasDefaultValue(false);

            builder.Property(x => x.ActiveCostCode)
                   .IsRequired()
                   .HasDefaultValue(false);

            builder.Property(x => x.ActiveActivity)
                   .IsRequired()
                   .HasDefaultValue(false);

            builder.Property(x => x.ActiveBOQItem)
                   .IsRequired()
                   .HasDefaultValue(false);

            builder.Property(x => x.ActiveSubcontractBOQ)
                   .IsRequired()
                   .HasDefaultValue(false);

            builder.Property(x => x.ActiveProductionOrder)
                   .IsRequired()
                   .HasDefaultValue(false);

            // Audit Fields

            builder.Property(x => x.In_User).IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.In_Date).IsRequired();

            builder.Property(x => x.Mod_User)
                   .HasMaxLength(100);

            builder.Property(x => x.Mod_Date);
        }
    }
}