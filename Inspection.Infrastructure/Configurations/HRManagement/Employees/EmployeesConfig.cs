using Inspection.Domain.Models.HRManagement.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.HRManagement.Employees
{

    public class EmployeesConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee", "HR");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FullName).IsRequired().HasMaxLength(250);
            builder.Property(x => x.EmployeeCode).IsRequired().HasMaxLength(50);
            builder.Property(x => x.PhotoUrl).HasMaxLength(500);
            builder.Property(x => x.NationalId).HasMaxLength(50);
            builder.Property(x => x.Qualifications).HasMaxLength(1000);
            builder.Property(x => x.HireDate).IsRequired();
            builder.Property(x => x.Tenant_ID).HasMaxLength(100);

            builder.HasOne(x => x.CV)
                   .WithMany()
                   .HasForeignKey(x => x.CVId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(x => x.JobTitle)
                   .WithMany()
                   .HasForeignKey(x => x.JobTitleId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Department)
                   .WithMany()
                   .HasForeignKey(x => x.DepartmentId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}