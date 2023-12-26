using Locato.Data.Contracts;
using Locato.Data.Entities.Media;
using Locato.Data.Entities.Transport.Trips;
using Locato.Data.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locato.Data.Entities.Communication
{
    public class Message : Entity, IValidatableObject
    {
        public string Text
        {
            get { return EncodedText == null ? null : Encoding.UTF8.GetString(EncodedText); }
            set { EncodedText = Encoding.UTF8.GetBytes(value); }
        }
        /// <summary>
        /// <see cref="Category"/>
        /// </summary>
        public string Category { get; set; }
        public bool Delivered { get; set; }
        public bool ExpiredBeforeSeen { get; set; }
        public long TripId { get;set; }
        public virtual Trip Trip { get;set; }
        public long CreatedById { get;set; }
        public virtual User CreatedBy { get;set; }
        public long? ForUserId { get; set; }
        public virtual User CreatedFor { get; set; }
        public bool IsUnicodeSms { get; set; }
        /// <summary>
        /// Only For Individual Messages
        /// </summary>
        public DateTime DeliverOn { get; set; }
        public long? AttachmentId { get; set; }
        public virtual Attachment Attachment { get; set; }

        protected internal byte[] EncodedText { get; set; }


        public string GetMimeType()
        {
            return Attachment == null ? "text/plain" : Attachment.MimeType;
        }

        public byte[] GetRawContent()
        {
            return Attachment?.RawContent;
        }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return Array.Empty<ValidationResult>();
        }

    }

    internal class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.Ignore(p => p.Text);
            builder.Property(p => p.EncodedText).HasColumnName("Text");
            builder.HasOne(p => p.Trip).WithMany(x => x.Messages).HasForeignKey(x => x.TripId);
            builder.HasOne(p => p.CreatedBy).WithOne().HasForeignKey<Message>(x => x.CreatedById).IsRequired();
            builder.HasOne(p => p.CreatedFor).WithOne().HasForeignKey<Message>(x => x.ForUserId);
        }
    }

    public enum Category
   {
        USER_TO_DRIVER,
        DRIVER_TO_USER,
        DRIVER_TO_TRIPSUBSCRIBERS
   }
}
