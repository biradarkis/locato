using Locato.Data.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;


namespace Locato.Data.Entities.Media
{
    public class Attachment : Entity
    {
        public string MimeType { get; set; }
        public string FileName { get; set; }
        public byte[] RawContent { get; set; }

        /// <summary>
        ///     Column to store Thumbnail for Pic messages.
        /// </summary>
        public byte[] Thumbnail { get; set; }

        public string ThumbnailKey { get; set; }

        public string Extension => MimeType.Split('/')[1].ToLower();

        public bool IsImage => MimeType.StartsWith("image", StringComparison.OrdinalIgnoreCase);

        // TODO: Redesign so that app doesn't rely on this pass thru property
        public string AppSideIdentifier { get; set; }
        public string StorageURL { get; set; }
        public string ThumbnailStorageURL { get; set; }
    }

    internal class AttachmentConfiguration : IEntityTypeConfiguration<Attachment>
    {
        public void Configure(EntityTypeBuilder<Attachment> builder)
        {
            builder.Ignore(p => p.Extension);
            builder.Ignore(p => p.IsImage);

            builder.Property(t => t.MimeType)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            // guids plus qualifiers (l, m, s etc.)
            builder.Property(p => p.ThumbnailKey)
                .IsUnicode(false)
                .HasMaxLength(40);

            builder.Property(t => t.FileName)
                           .HasMaxLength(255);

            builder.Property(t => t.RawContent)
                .IsRequired()
                .HasColumnName("Content");

            builder.Ignore(p => p.AppSideIdentifier);
        }
    }
}