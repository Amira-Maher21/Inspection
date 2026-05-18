using Inspection.Domain.Models.Inventory.InventorySetup;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Inventory.InventorySetup
{
    public class WarehouseConfigration : IEntityTypeConfiguration<Warehouse>
    {
        [Obsolete]
        public void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            builder.ToTable("Warehouse", "Inventory");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Tenant_ID)
                   .IsRequired();

            builder.Property(x => x.CompanyId)
                   .IsRequired();

            builder.Property(x => x.BranchId)
                   .IsRequired();

            builder.Property(x => x.Code)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(150);



            builder.Property(x => x.Description)
                   .HasMaxLength(255);

            builder.Property(x => x.Address)
                   .HasMaxLength(255);

            builder.Property(x => x.ContactPhone)
                   .HasMaxLength(20);

            builder.Property(x => x.ResponsibleEmployeeId)
             .IsRequired(false);

            builder.Property(x => x.ContactEmail)
                   .HasMaxLength(254);

            builder.HasIndex(x => new { x.Code, x.Tenant_ID, x.CompanyId })
                   .IsUnique()
                   .HasDatabaseName("UQ_Warehouse_Code_Tenant_Company");

            builder.HasOne(x => x.Branch)
                   .WithMany()
                   .HasForeignKey(x => x.BranchId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ChartOfAccount)
                   .WithMany()
                   .HasForeignKey(x => x.InventoryAccountId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Country)
                   .WithMany()
                   .HasForeignKey(x => x.CountryId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.City)
                   .WithMany()
                   .HasForeignKey(x => x.CityId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Employee)
                   .WithMany()
                   .HasForeignKey(x => x.ResponsibleEmployeeId)
                   .OnDelete(DeleteBehavior.Restrict);


        }
    }
}