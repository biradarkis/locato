using Locato.Data.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locato.Data.Entities.Media
{
    [Index( nameof(Key) , Name="Ix_Key", IsUnique = true)]
    public class StaticMedia : Entity, IValidatableObject
    {
        public required string MimeType { get; set; }

        public required string FileName { get; set; }

        public required string Uri { get; set; }
        public required string Key { get; set; }

        public byte[] RawContent { get; set; }
        public required string StorageURL { get; set; }

        public bool Processed { get; set; }

        public bool IsReady { get; set; }
        
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return Array.Empty<ValidationResult>();
        }
    }

    internal class StaticMediaConfiguration : IEntityTypeConfiguration<StaticMedia>
    {
        public void Configure(EntityTypeBuilder<StaticMedia> builder)
        {
            builder.Property(t => t.MimeType)
               .IsRequired()
               .HasMaxLength(50)
               .IsUnicode(false);

            builder.Property(t => t.FileName)
               .HasMaxLength(255)
               .IsUnicode(false);

            builder.Property(t => t.Uri)
                .IsRequired()
                .HasMaxLength(512)
                .IsUnicode(false);

            builder.Property(t => t.Key)
                .IsRequired()
                .HasMaxLength(128)
                .IsUnicode(false);
                

            builder.Property(t => t.RawContent)
               .IsRequired()
               .HasColumnName("Content");
        }
    }
}
