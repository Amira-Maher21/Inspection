namespace Inspection.Infrastructure.Configurations.System.TaxTypes
{
    //public class TaxTypeConfiguration : IEntityTypeConfiguration<TaxType>
    //{
    //    public void Configure(EntityTypeBuilder<TaxType> builder)
    //    {
    //        builder.ToTable("TaxType", "Accounting");

    //        builder.HasKey(x => x.Id);

    //        builder.Property(x => x.TaxTypeCode)
    //               .IsRequired()
    //               .HasMaxLength(20);

    //        builder.Property(x => x.TaxTypeName)
    //               .IsRequired()
    //               .HasMaxLength(200);

    //        builder.Property(x => x.CompanyId);


    //        builder.Property(x => x.TaxCategoryId)
    //               .IsRequired();



    //        builder.Property(x => x.Percentage)
    //               .HasColumnType("decimal(18,6)");

    //        builder.Property(x => x.IsInclusive);
    //        builder.Property(x => x.IsRecoverable)
    //               .IsRequired();

    //        builder.Property(x => x.IsExempt)
    //               .IsRequired();

    //        builder.Property(x => x.TaxTypeValue)
    //               .HasConversion<int>()
    //               .IsRequired();

    //        builder.Property(x => x.EtaCodeEgypt)
    //               .HasMaxLength(200);

    //        builder.Property(x => x.ChartOfAccountId)
    //               .IsRequired();

    //        builder.Property(x => x.Description)
    //               .HasMaxLength(500);

    //        builder.Property(x => x.IsActive)
    //               .IsRequired();

    //        builder.Property(x => x.IsSystem)
    //               .IsRequired();

    //        builder.Property(x => x.Tenant_ID)
    //               .IsRequired();

    //        builder.Property(x => x.In_User)
    //               .IsRequired()
    //               .HasMaxLength(100);

    //        builder.Property(x => x.In_Date)
    //               .IsRequired();

    //        builder.Property(x => x.Mod_User)
    //               .HasMaxLength(100);

    //        builder.Property(x => x.Mod_Date);

    //        builder.HasIndex(x => new { x.Tenant_ID, x.CompanyId, x.TaxTypeCode, x.TaxTypeValue })
    //               .IsUnique()
    //               .HasDatabaseName("UX_TaxTypes_Tenant_Code");

    //        builder.HasOne(x => x.ChartOfAccount)
    //               .WithMany()
    //               .HasForeignKey(x => x.ChartOfAccountId)
    //               .OnDelete(DeleteBehavior.Restrict)
    //               .HasConstraintName("FK_TaxTypes_Account");

    //        builder.HasOne(x => x.TaxCategory)
    //               .WithMany()
    //               .HasForeignKey(x => x.TaxCategoryId)
    //               .OnDelete(DeleteBehavior.Restrict)
    //               .HasConstraintName("FK_TaxTypes_TaxCategory");
    //    }
    //}
}