using Inspection.Domain.Models.Accounting.AccountingSetup.ModeOfPayments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Accounting.AccountingSetupConfig.ModeOfPayments
{
    public class ModeOfPaymentConfiguration : IEntityTypeConfiguration<ModeOfPayment>
    {
        public void Configure(EntityTypeBuilder<ModeOfPayment> builder)
        {

            builder.ToTable("ModeOfPayment", "Accounting");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd();


            builder.Property(x => x.Tenant_ID)
                   .IsRequired()
                   .HasMaxLength(50);




            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.Description)
                   .HasMaxLength(500);

            builder.Property(x => x.ChartOfAccountId)
                     .IsRequired();

            builder.HasOne(x => x.ChartOfAccount)
                   .WithMany()
                   .HasForeignKey(x => x.ChartOfAccountId)
                   .OnDelete(DeleteBehavior.Restrict);






            builder.HasOne(x => x.Currency)
                   .WithMany()
                   .HasForeignKey(x => x.CurrencyId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.FeesAccount)
                   .WithMany()
                   .HasForeignKey(x => x.FeesAccountId)
                   .OnDelete(DeleteBehavior.Restrict);



            builder.Property(x => x.PaymentType)
                   .IsRequired()
                   .HasConversion<int>();

            builder.Property(x => x.FeeType)
                   .HasConversion<int>();

            builder.Property(x => x.Direction)
                   .IsRequired()
                   .HasConversion<int>();


            builder.Property(x => x.FeeValue);
            builder.Property(x => x.HasFee);
            builder.Property(x => x.IncludeInPOS).HasDefaultValue(false);






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

            builder.HasIndex(x => new { x.Tenant_ID })
                   .IsUnique()
                   .HasDatabaseName("UX_ModeOfPayment_Code_Tenant");
        }
    }
}