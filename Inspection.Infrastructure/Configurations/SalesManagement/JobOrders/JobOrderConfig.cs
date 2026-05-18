using Inspection.Domain.Models.Inspection.Techinal.JobOrder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.SalesManagement.JobOrders
{

    public class JobOrderConfig : IEntityTypeConfiguration<JobOrder>
    {
        public void Configure(EntityTypeBuilder<JobOrder> builder)
        {
            builder.ToTable("JobOrder", "Inspection");
            builder.HasKey(x => x.Id);

            builder.HasIndex(e => new { e.JobOrderNumber })
                   .HasDatabaseName("UX_JobOrder_JobOrderNumber")
                   .IsUnique();

            builder.Property(x => x.Tenant_ID)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.CompanyId)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.JobOrderNumber)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.JobOrderDate)
                   .IsRequired();

            builder.Property(x => x.PlannedStartDate)
                   .IsRequired();

            builder.Property(x => x.PlannedEndDate)
                   .IsRequired();

            builder.Property(x => x.DocumentStatus)
                   .IsRequired();

            builder.Property(x => x.ApprovalStatus)
                   .IsRequired();

            builder.Property(x => x.In_User)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.In_Date)
                   .IsRequired();

            // =============================
            // Optional Fields
            // =============================
            builder.Property(x => x.Mod_User)
                   .HasMaxLength(100);

            builder.Property(x => x.SiteContactName)
                   .HasMaxLength(300);

            builder.Property(x => x.SiteContactMobile)
                   .HasMaxLength(300);

            builder.Property(x => x.SiteContactEmail)
                   .HasMaxLength(300);

            builder.Property(x => x.Location)
                   .HasMaxLength(500);

            builder.Property(x => x.Remarks)
                   .HasMaxLength(500);

            builder.Property(x => x.DocumentStatusCancelledDescription)
                   .HasMaxLength(500);

            // =============================
            // Relationships
            // =============================

            // Customer
            builder.HasOne(x => x.Customer)
                   .WithMany()
                   .HasForeignKey(x => x.CustomerId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Inspection Request
            builder.HasOne(x => x.InspectionRequest)
                   .WithMany()
                   .HasForeignKey(x => x.InspectionRequestId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Sales Quotation
            builder.HasOne(x => x.SalesQuotation)
                   .WithMany()
                   .HasForeignKey(x => x.QuotationId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Series
            builder.HasOne(x => x.Series)
                   .WithMany()
                   .HasForeignKey(x => x.SeriesId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Sales Order
            builder.HasOne(x => x.SalesOrder)
                   .WithMany()
                   .HasForeignKey(x => x.SalesOrderId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Job Order Lines
            builder.HasMany(x => x.JobOrderLines)
                   .WithOne()
                   .HasForeignKey("JobOrderId")
                   .OnDelete(DeleteBehavior.Cascade);


        }
    }
}