using Inspection.Domain.Models.Inspection.Techinal.Certificates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Inspection.Techinal.Certificates
{
    public class CertificateConfiguration : IEntityTypeConfiguration<Certificate>
    {
        public void Configure(EntityTypeBuilder<Certificate> builder)
        {
            builder.ToTable("Certificate", "Inspection");

            // Primary Key
            builder.HasKey(x => x.Id);

            // Indexes
            builder.HasIndex(x => new { x.Tenant_ID, x.CompanyId, x.CerficateNumber }).IsUnique();

            // Properties
            builder.Property(x => x.Tenant_ID).IsRequired().HasMaxLength(50);
            builder.Property(x => x.CompanyId).IsRequired();
            builder.Property(x => x.CerficateNumber).HasMaxLength(300);

            builder.Property(x => x.ChekclistId).IsRequired().HasMaxLength(50);
            builder.Property(x => x.IssuedByEmployeeId).IsRequired().HasMaxLength(50);

            builder.Property(x => x.CertificateType).IsRequired();
            builder.Property(x => x.IssueDate).IsRequired();
            builder.Property(x => x.Period).IsRequired();
            builder.Property(x => x.ExpiryDate).IsRequired();

            builder.Property(x => x.Remarks).HasMaxLength(500);

            // Audit
            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);
            builder.Property(x => x.In_Date).IsRequired();
            builder.Property(x => x.Mod_User).HasMaxLength(100);
            builder.Property(x => x.Mod_Date);

            // Relationships

            // Checklist (Required)
            builder.HasOne(x => x.Checklist)
                   .WithMany()
                   .HasForeignKey(x => x.ChekclistId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Employee (Required)
            builder.HasOne(x => x.Employee)
                   .WithMany()
                   .HasForeignKey(x => x.IssuedByEmployeeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Series)
                  .WithMany()
                  .HasForeignKey(x => x.SeriesId)
                  .OnDelete(DeleteBehavior.Restrict);
        }
    }
}