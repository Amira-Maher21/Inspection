using Inspection.Domain.Models.DMS.DocumentShares;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.DMS.DocumentShares
{
    public class DocumentShareConfiguration : IEntityTypeConfiguration<DocumentShare>
    {
        public void Configure(EntityTypeBuilder<DocumentShare> builder)
        {
            builder.ToTable("DocumentShare", "DMS");

            // PK
            builder.HasKey(x => x.Id);


            builder.Property(x => x.CompanyId).IsRequired();



            // Required
            builder.Property(x => x.DocumentId).IsRequired();
            builder.Property(x => x.SharedById).IsRequired();

            builder.Property(x => x.ShareType)
                  .IsRequired()
                  .HasConversion<int>();

            builder.Property(x => x.ShareToken)
                  .HasMaxLength(100);

            builder.Property(x => x.Email)
                   .HasMaxLength(254);

            builder.Property(x => x.PasswordHash)
                   .HasMaxLength(255);


            builder.Property(x => x.ExpiresAt)
                   .IsRequired(false);


            builder.Property(x => x.LastAccessedAt)
                    .IsRequired(false);

            builder.Property(x => x.RevokedAt)
                    .IsRequired(false);

            builder.Property(x => x.CanView).HasDefaultValue(true);
            builder.Property(x => x.CanDownload).HasDefaultValue(false);
            builder.Property(x => x.CanEdit).HasDefaultValue(false);
            builder.Property(x => x.RequirePassword).HasDefaultValue(false);
            builder.Property(x => x.AccessCount).HasDefaultValue(false);
            builder.Property(x => x.IsActive).HasDefaultValue(true);

            // Unique Token
            builder.HasIndex(x => x.ShareToken)
                   .IsUnique()
                   .HasFilter("[ShareToken] IS NOT NULL");


            builder.HasOne(x => x.Document)
                   .WithMany()
                   .HasForeignKey(x => x.DocumentId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.SharedBy)
                   .WithMany()
                   .HasForeignKey(x => x.SharedById)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.SharedWith)
                   .WithMany()
                   .HasForeignKey(x => x.SharedWithId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.RevokedBy)
                   .WithMany()
                   .HasForeignKey(x => x.RevokedById)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}