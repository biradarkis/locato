using Locato.Data.Contracts;
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
    public class EmailNotification : Entity, IValidatableObject
    {
        [Required, EmailAddress]
        public string EmailId { get; set; }
        public string NotificationType { get; set; }
        public string Body { get; set; }
        public int Retries { get; set; }
        public bool IsSuccess { get; set; }
        public virtual User User { get; set; }
        public long UserId { get; set; }    
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return Array.Empty<ValidationResult>();
        }
    }

    internal class EmailNotificationConfiguration : IEntityTypeConfiguration<EmailNotification>
    {
        public void Configure(EntityTypeBuilder<EmailNotification> builder)
        {
            builder.HasOne(x=>x.User).WithMany().HasForeignKey(x=>x.UserId).IsRequired();
        }
    }

    public enum EmailNotificationType
    {
        OTP ,
        PasswordReset,
        Info
    }
}
