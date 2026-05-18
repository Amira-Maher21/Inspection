using Inspection.Domain.Models.Accounting.PostingEngine;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Infrastructure.Configurations.Accounting.PostingEngine
{
    public class PostingAccountMappingConfig : IEntityTypeConfiguration<PostingAccountMapping>
    {
        public void Configure(EntityTypeBuilder<PostingAccountMapping> builder)
        {
            builder.ToTable("PostingAccountMapping", "Accounting");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.PostingKey)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.AccountSource)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Side)
                .IsRequired();

            builder.Property(x => x.Priority)
                .IsRequired();

            // Relationship: PostingDocumentType (Required)
            builder.HasOne(x => x.PostingDocumentType)
                .WithMany()
                .HasForeignKey(x => x.PostingDocumentTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relationship: ChartOfAccount (Optional)
            builder.HasOne(x => x.ChartOfAccount)
                .WithMany()
                .HasForeignKey(x => x.ChartOfAccountId)
                .OnDelete(DeleteBehavior.Restrict);

        }

    }
}
