using Inspection.Domain.Models.Seeting.ModuleSettings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.Setting.ModuleSettings
{
    public class ModuleSettingConfiguration : IEntityTypeConfiguration<ModuleSetting>
    {
        public void Configure(EntityTypeBuilder<ModuleSetting> builder)
        {
            builder.ToTable("ModuleSetting");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                  .ValueGeneratedOnAdd();

            // FK to Program
            builder.HasOne(x => x.Program)
                   .WithMany()
                   .HasForeignKey(x => x.ProgramId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Properties
            builder.Property(x => x.SettingKey)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(x => x.SettingValue)
                   .HasMaxLength(255)
                   .IsRequired();

            builder.Property(x => x.ValueType)
                   .HasMaxLength(20)
                   .IsRequired();

            builder.Property(x => x.Description)
                   .HasMaxLength(255)
                   .IsRequired(false);

            builder.Property(x => x.Tenant_ID)
                   .HasMaxLength(50)
                   .IsRequired();

            // Audit fields
            builder.Property(x => x.In_User)
                   .HasMaxLength(50)
                   .IsRequired();
            builder.Property(x => x.Mod_User)
                   .HasMaxLength(50)
                   .IsRequired(false);

            // Unique Constraint
            builder.HasIndex(x => new { x.Tenant_ID, x.CompanyId, x.ProgramId, x.SettingKey })
                   .IsUnique()
                   .HasDatabaseName("UQ_ModuleSetting_Company_Module_Key");

            //// Check Constraint for ValueType
            //builder.HasCheckConstraint("CK_ModuleSetting_ValueType",
            //    "[ValueType] IN ('Boolean', 'Int', 'Decimal', 'String')");
        }
    }
}
