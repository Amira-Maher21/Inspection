using Inspection.Domain.Models.MenuManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.MenuManagement
{
    public class ProgramConfig : IEntityTypeConfiguration<Program>
    {
        public void Configure(EntityTypeBuilder<Program> builder)
        {
            builder.ToTable("Program", "Syst");
            builder.HasKey(e => e.Program_ID).HasName("PK_Programs");
            builder.Property(e => e.Program_ID).HasMaxLength(5);
            builder.Property(e => e.Icon).HasMaxLength(200);
            builder.Property(e => e.ProgramName).HasMaxLength(25);
            builder.Property(e => e.WebRoute).HasMaxLength(500);
        }
    }
}