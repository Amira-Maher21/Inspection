using Inspection.Domain.Models.InspectionManagement.InspectionRequests;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.InspectionManagement.InspectionRequests
{
    public class InspectionRequestLinesConfig : IEntityTypeConfiguration<InspectionRequestLines>
    {
        public void Configure(EntityTypeBuilder<InspectionRequestLines> builder)
        {
            builder.ToTable("InspectionRequestLines", "Inspection");

            builder.HasKey(x => x.Id);

            // ========================
            // Numeric Precision
            // ========================
            builder.Property(x => x.Quantity)
                   .HasPrecision(18, 4);

            builder.Property(x => x.Price)
                   .HasPrecision(18, 4);

            // ========================
            // Audit Fields
            // ========================
            builder.Property(x => x.In_User)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.Mod_User)
                   .HasMaxLength(100);

            // ========================
            // Enum Conversion
            // ========================
            builder.Property(x => x.Status)
                   .HasConversion<int>();

            // ========================
            // Relationships
            // ========================

            // Parent InspectionRequest (required)
            builder.HasOne(x => x.InspectionRequests)
                   .WithMany(x => x.InspectionRequestLines)
                   .HasForeignKey(x => x.InspectionRequestId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Item
            builder.HasOne(x => x.Items)
                   .WithMany()
                   .HasForeignKey(x => x.ItemId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Inspection Method
            builder.HasOne(x => x.InspectionMethods)
                   .WithMany()
                   .HasForeignKey(x => x.InspectionMethodId)
                   .OnDelete(DeleteBehavior.Restrict);

            // ========================
            // Helpful Indexes
            // ========================
            builder.HasIndex(x => x.InspectionRequestId);
            builder.HasIndex(x => x.ItemId);
        }
    }
}