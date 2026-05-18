using Inspection.Domain.Models.SystemConfigurations.DetailTables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class DetailTableConfig : IEntityTypeConfiguration<DetailTable>
{
    public void Configure(EntityTypeBuilder<DetailTable> builder)
    {
        builder.ToTable("DetailTable", "Sec");
        builder.HasKey(x => x.Id);

        builder.HasIndex(x => new { x.CurrencyExchangRateId, x.CurrencyId }).IsUnique();

        builder.HasOne(d => d.CurrencyExchangRate)
               .WithMany(m => m.Details)
               .HasForeignKey(d => d.CurrencyExchangRateId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Currencys)
               .WithMany()
               .HasForeignKey(x => x.CurrencyId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.Rate)
               .IsRequired()
               .HasPrecision(18, 6);
    }
}