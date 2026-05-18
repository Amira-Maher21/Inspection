using Inspection.Domain.Models.Inspection.Techinal.Inspectors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Inspection.Techinal
{
    public class InspectorConfiguration : IEntityTypeConfiguration<Inspector>
    {
        public void Configure(EntityTypeBuilder<Inspector> builder)
        {
            builder.ToTable("Inspector", "Inspection");

            // Primary Key
            builder.HasKey(x => x.Id);

            // Indexes
            builder.HasIndex(x => new { x.Tenant_ID, x.CompanyId, x.Code }).IsUnique();

            // Properties
            builder.Property(x => x.Tenant_ID).IsRequired().HasMaxLength(100);
            builder.Property(x => x.CompanyId).IsRequired();
            builder.Property(x => x.EmployeeId).IsRequired(false);
            builder.Property(x => x.User_CodeId).IsRequired();
            builder.Property(x => x.InspectorCategoryId).IsRequired();
            builder.Property(x => x.Code).IsRequired().HasMaxLength(50);
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Email).HasMaxLength(100);
            builder.Property(x => x.Phone).HasMaxLength(20);
            builder.Property(x => x.HireDate).HasColumnType("date");
            builder.Property(x => x.Disabled).IsRequired().HasDefaultValue(false);
            builder.Property(x => x.QualificationNotes).HasColumnType("nvarchar(max)");
            builder.Property(x => x.Remarks).HasColumnType("nvarchar(max)");

            // Audit
            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);
            builder.Property(x => x.In_Date).IsRequired();
            builder.Property(x => x.Mod_User).HasMaxLength(100);
            builder.Property(x => x.Mod_Date);

            // Relationships

            // Employee (Optional)
            builder.HasOne(x => x.Employee)
                   .WithMany()
                   .HasForeignKey(x => x.EmployeeId)
                   .OnDelete(DeleteBehavior.Restrict);

            // InspectorCategory (Optional)
            builder.HasOne(x => x.InspectorCategory)
                   .WithMany()
                   .HasForeignKey(x => x.InspectorCategoryId)
                   .OnDelete(DeleteBehavior.Restrict);

            // User_Code (Optional)
            builder.HasOne(x => x.User)
                   .WithMany()
                   .HasForeignKey(x => x.User_CodeId)
                   .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(x => x.Series)
                  .WithMany()
                  .HasForeignKey(x => x.SeriesId)
                  .OnDelete(DeleteBehavior.Restrict);
        }
    }
}