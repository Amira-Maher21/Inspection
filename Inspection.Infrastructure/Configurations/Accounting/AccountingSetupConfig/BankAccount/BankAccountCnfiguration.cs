using Inspection.Domain.Models.Accounting.AccountingSetup.BankAccounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Accounting.AccountingSetupConfig.BankAccounts
{

    public class BankAccountCnfiguration : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder.ToTable("BankAccount", "Accounting");


            //Property
            builder.HasKey(x => x.Id);
            builder.Property(x => x.BankAccountNumber)
                   .IsRequired()
                   .HasMaxLength(50);
            builder.Property(x => x.IBAN)
                    .HasMaxLength(50);
            builder.Property(x => x.AccountType)
                   .IsRequired()
                   .HasMaxLength(30);
            builder.Property(x => x.Address)
                   .HasMaxLength(500);
            builder.Property(x => x.ContactPerson)
                    .HasMaxLength(150);
            builder.Property(x => x.IsCompanyAccount);



            // Foreign Keys

            builder.HasOne(x => x.Bank)
                   .WithMany()
                   .HasForeignKey(x => x.BankId);

            builder.HasOne(x => x.Currency)
                   .WithMany()
                   .HasForeignKey(x => x.CurrencyId);


            builder.HasOne(x => x.ChartOfAccount)
                   .WithMany()
                   .HasForeignKey(x => x.ChartOfAccountId);





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

