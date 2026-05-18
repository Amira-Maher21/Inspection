using Inspection.Domain.Models.Inspection.Techinal.JobOrder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.SalesManagement.JobOrders
{

    public class JobOrderLinesConfig : IEntityTypeConfiguration<JobOrderLine>
    {
        public void Configure(EntityTypeBuilder<JobOrderLine> builder)
        {
            builder.ToTable("JobOrderLine", "Inspection");

            // =============================
            // Primary Key
            // =============================
            builder.HasKey(x => x.Id);

            // =============================
            // Required Properties
            // =============================

            builder.Property(x => x.JobOrderId)
                   .IsRequired();

            builder.Property(x => x.ItemId)
                   .IsRequired();

            builder.Property(x => x.InspectionMethodId)
                   .IsRequired();

            builder.Property(x => x.InspectorId)
                   .IsRequired();

            builder.Property(x => x.ScheduledFromTime)
                   .IsRequired();

            builder.Property(x => x.ScheduledToTime)
                   .IsRequired();

            builder.Property(x => x.PlannedQuantity)
                   .HasPrecision(18, 2);

            builder.Property(x => x.CompletedQuantity)
                   .HasPrecision(18, 2);

            builder.Property(x => x.In_User)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.In_Date)
                   .IsRequired();

            // =============================
            // Optional Properties
            // =============================

            builder.Property(x => x.Mod_User)
                   .HasMaxLength(100);

            builder.Property(x => x.Remarks)
                   .HasMaxLength(500);

            // =============================
            // Relationships
            // =============================

            // JobOrder (Many -> One)
            builder.HasOne(x => x.JobOrders)
                   .WithMany(x => x.JobOrderLines)
                   .HasForeignKey(x => x.JobOrderId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Item
            builder.HasOne(x => x.Item)
                   .WithMany()
                   .HasForeignKey(x => x.ItemId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Inspection Method
            builder.HasOne(x => x.InspectionMethods)
                   .WithMany()
                   .HasForeignKey(x => x.InspectionMethodId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Inspector
            builder.HasOne(x => x.Inspectors)
                   .WithMany()
                   .HasForeignKey(x => x.InspectorId)
                   .OnDelete(DeleteBehavior.Restrict);



        }
    }
}