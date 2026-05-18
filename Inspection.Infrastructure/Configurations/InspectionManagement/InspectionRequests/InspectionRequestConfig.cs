using Inspection.Domain.Models.InspectionManagement.InspectionRequests;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.InspectionManagement.InspectionRequests
{
    public class InspectionRequestConfig : IEntityTypeConfiguration<InspectionRequest>
    {
        public void Configure(EntityTypeBuilder<InspectionRequest> builder)
        {
            builder.ToTable("InspectionRequest", "Inspection");

            builder.HasKey(x => x.Id);

            // ========================
            // Basic Properties
            // ========================
            builder.Property(x => x.RequestNumber)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.Tenant_ID)
                   .HasMaxLength(50);

            builder.Property(x => x.Remarks)
                   .HasMaxLength(500);

            builder.Property(x => x.In_User)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.Mod_User)
                   .HasMaxLength(100);

            // ========================
            // Enums
            // ========================
            builder.Property(x => x.DocumentStatus)
                   .HasConversion<int>();

            builder.Property(x => x.ApprovalStatus)
                   .HasConversion<int>();

            // ========================
            // Indexes
            // ========================
            builder.HasIndex(e => new { e.RequestNumber, e.Tenant_ID })
                   .HasDatabaseName("UX_InspectionRequest_RequestNumber_Tenant")
                   .IsUnique();

            // ========================
            // Relationships
            // ========================

            builder.HasOne(x => x.Customers)
                   .WithMany()
                   .HasForeignKey(x => x.CustomerId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.CustomerLocations)
                   .WithMany()
                   .HasForeignKey(x => x.LocationId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.CustomerContact)
                   .WithMany()
                   .HasForeignKey(x => x.ContactPersonId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.CustomerProjects)
                   .WithMany()
                   .HasForeignKey(x => x.CustomerProjectId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.InspectionType)
                   .WithMany()
                   .HasForeignKey(x => x.InspectionTypeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Series)
                   .WithMany()
                   .HasForeignKey(x => x.SeriesId)
                   .OnDelete(DeleteBehavior.Restrict);

            // ========================
            // Child Collection
            // ========================
            builder.HasMany(x => x.InspectionRequestLines)
                   .WithOne()
                   .HasForeignKey("InspectionRequestId")
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}