using Inspection.Domain.Models.DMS.DocumentComments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inspection.Infrastructure.Configurations.DMS.DocumentComments
{
    public class DocumentCommentConfiguration : IEntityTypeConfiguration<DocumentComment>
    {
        public void Configure(EntityTypeBuilder<DocumentComment> builder)
        {
            // TABLE
            builder.ToTable("DocumentComment", "DMS");

            // PRIMARY KEY
            builder.HasKey(x => x.Id);

            // INDEXES (recommended)
            builder.HasIndex(x => new { x.Tenant_ID, x.CompanyId, x.DocumentId }).IsUnique();
            builder.HasIndex(x => x.ParentCommentId);

            // REQUIRED FIELDS
            builder.Property(x => x.Tenant_ID).IsRequired().HasMaxLength(50);
            builder.Property(x => x.CompanyId).IsRequired();
            builder.Property(x => x.DocumentId).IsRequired();
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.CommentText).IsRequired().HasColumnType("nvarchar(max)");

            // DEFAULT VALUES
            builder.Property(x => x.IsResolved).HasDefaultValue(false);

            // RESOLUTION
            builder.Property(x => x.ResolvedAt).IsRequired(false).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(x => x.ResolvedById).IsRequired(false);

            // AUDIT
            builder.Property(x => x.In_User).IsRequired().HasMaxLength(100);
            builder.Property(x => x.In_Date).IsRequired();
            builder.Property(x => x.Mod_User).HasMaxLength(100);
            builder.Property(x => x.Mod_Date);

            // RELATIONSHIPS

            // Document (Required)
            builder.HasOne(x => x.Document)
                   .WithMany()
                   .HasForeignKey(x => x.DocumentId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Comment Author (User)
            builder.HasOne(x => x.User_Code)
                   .WithMany()
                   .HasForeignKey(x => x.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Resolved By User (Optional)
            builder.HasOne(x => x.ResolvedBy)
                   .WithMany()
                   .HasForeignKey(x => x.ResolvedById)
                   .OnDelete(DeleteBehavior.Restrict);

            // Parent Comment (Self Reference)
            builder.HasOne<DocumentComment>()
                   .WithMany()
                   .HasForeignKey(x => x.ParentCommentId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}