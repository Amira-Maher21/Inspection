using Inspection.Domain.Models.Accounting.ChartOfAccounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Accounting.ChartOfAccounts
{
    public class AccountTypeConfiguration : IEntityTypeConfiguration<AccountType>
    {
        public void Configure(EntityTypeBuilder<AccountType> builder)
        {
            builder.ToTable("AccountType", "Accounting");

            builder.HasKey(x => x.AccountTypeCode);

            builder.Property(x => x.AccountTypeCode).IsRequired().HasMaxLength(50);

            builder.Property(x => x.AccountTypeName).IsRequired().HasMaxLength(300);


            builder.Property(x => x.ParentAccountType).HasMaxLength(50);
        }
    }
}