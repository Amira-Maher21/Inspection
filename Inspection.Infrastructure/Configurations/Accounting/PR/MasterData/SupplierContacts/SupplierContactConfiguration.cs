using Inspection.Domain.Models.Accounting.PR.MasterData.SupplierContacts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Accounting.PR.MasterData.SupplierContacts
{
    public class SupplierContactConfiguration : IEntityTypeConfiguration<SupplierContact>
    {
        public void Configure(EntityTypeBuilder<SupplierContact> builder)
        {
            builder.ToTable("SupplierContact", "Accounting");

            // Primary Key
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
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
            builder.Property(x => x.Department)
                   .HasMaxLength(100);
            builder.Property(x => x.IsPrimary)
                   .IsRequired();
            builder.Property(x => x.Notes);





            // Foreign Key
            builder.HasOne(x => x.Supplier)
                    .WithMany(x => x.SupplierContacts)
                    .HasForeignKey(x => x.SupplierId)
                    .OnDelete(DeleteBehavior.Cascade);





            // Audit columns (if any)
            builder.Property(x => x.In_User)
                   .IsRequired()
                   .HasMaxLength(100);



            builder.Property(x => x.Mod_User)
                   .HasMaxLength(100);

            builder.Property(x => x.Mod_Date);
        }
    }
}
