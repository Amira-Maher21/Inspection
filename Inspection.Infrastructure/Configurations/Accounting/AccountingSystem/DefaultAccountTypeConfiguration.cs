using Inspection.Domain.Models.Accounting.AccountingSystem;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class DefaultAccountTypeConfiguration
    : IEntityTypeConfiguration<DefaultAccountType>
{
    public void Configure(EntityTypeBuilder<DefaultAccountType> builder)
    {
        builder.ToTable("DefaultAccountType", "Accounting");

        builder.HasKey(x => x.Id);


        builder.Property(x => x.Id)
               .ValueGeneratedOnAdd();

        builder.Property(x => x.Code)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(x => x.VATOUTPUT)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(x => x.Name)
               .IsRequired()
               .HasMaxLength(300);

        builder.Property(x => x.EntityType)
        .IsRequired()
        .HasConversion<int>();


        builder.Property(x => x.ProgramId)
               .IsRequired();

        builder.HasOne(x => x.Program)
               .WithMany()
               .HasForeignKey(x => x.ProgramId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => x.Code).IsUnique();
    }
}
