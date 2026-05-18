using Inspection.Domain.Models.Accounting.AR.MasterData;
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
    public class PostingDocumentTypeConfig : IEntityTypeConfiguration<PostingDocumentType>
    {
        public void Configure(EntityTypeBuilder<PostingDocumentType> builder)
        {
            builder.ToTable("PostingDocumentType", "Accounting");

            builder.Property(x => x.DocumentCode).HasMaxLength(50);
            builder.Property(x => x.DocumentName).HasMaxLength(150);

            builder.HasOne(x => x.Screen_Code)
                .WithMany()
                .HasForeignKey(x => x.Screen_CodeId)
                .OnDelete(DeleteBehavior.NoAction);

        }
            
    }
}
