using Inspection.Domain.Models.Accounting.AR.MasterData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Accounting.AR.MasterData
{
    public class CustomerContactConfig : IEntityTypeConfiguration<CustomerContact>
    {
        public void Configure(EntityTypeBuilder<CustomerContact> builder)
        {
            builder.ToTable("CustomerContact", "Accounting");

            // PK
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.ContactName)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(x => x.JobTitle)
                   .HasMaxLength(100);

            builder.Property(x => x.Phone)
                   .HasMaxLength(20);

            builder.Property(x => x.Mobile)
                   .HasMaxLength(20);

            builder.Property(x => x.Email)
                   .HasMaxLength(100);

            builder.Property(x => x.Fax)
                   .HasMaxLength(50);

            builder.Property(x => x.Notes)
                   .HasColumnType("nvarchar(max)");

            builder.Property(x => x.IsPrimary)
                   .IsRequired();

            // Index
            builder.HasIndex(x => x.CustomerId);

            // Relationships
            builder.HasOne(x => x.Customer)
                   .WithMany(x => x.CustomerContact)
                   .HasForeignKey(x => x.CustomerId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Department)
                   .WithMany()
                   .HasForeignKey(x => x.DepartmentId)
                   .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
