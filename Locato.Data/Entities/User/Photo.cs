using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locato.Data.Entities.UserEntities
{
    public class Photo : IValidatableObject
    {
        public long ProfileId { get; set; }
        public virtual Profile Profile { get; set; }

        public string Key { get; set; }

        /// <summary>
        /// Mime type; e.g. image/jpg
        /// </summary>
        public string MimeType { get; set; }

        /// <summary>
        /// Image binary
        /// </summary>
        public byte[] RawBytes { get; set; }


        public string ThumbnailLargeKey { get; set; }

        /// <summary>
        /// Image binary
        /// </summary>
        public byte[] ThumbnailLarge { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return  Array.Empty<ValidationResult>();
        }

        /// <summary>
        /// remote storageURL of the media
        /// </summary>
        public string StorageURL { get; set; } = "";

    }

    internal class PhotoConfiguaration : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder.Property(p => p.RawBytes).IsRequired();


            builder.Property(p => p.Key)
                .IsRequired()
                .HasMaxLength(40); /* 32 (guid) + 1 (size specifier) + 4 (ext) + 3 (buffer) */


            builder.Property(p => p.MimeType)
                .IsRequired()
                .HasMaxLength(128); /* based on http://tools.ietf.org/html/rfc6838#section-4.2 */

            builder.HasOne(p => p.Profile).WithOne(Profile => Profile.Photo).HasForeignKey<Photo>(p => p.ProfileId);

            builder.HasKey(p => p.ProfileId);
        }
    }
}


