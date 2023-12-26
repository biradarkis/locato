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

namespace Locato.Data.Entities.Transport.Trips
{
    public class TripNotification : Entity, IValidatableObject
    {
        public long UserId { get; set; }
        public virtual User User { get; set; }

        public long TripId { get; set; }
        public virtual Trip Trip { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return Array.Empty<ValidationResult>();
        }
    }

    internal class TripNotificationConfiguration : IEntityTypeConfiguration<TripNotification>
    {
        public void Configure(EntityTypeBuilder<TripNotification> builder)
        {
            builder.HasOne(x=>x.User).WithMany().HasForeignKey(x=>x.UserId).IsRequired();
            builder.HasOne(x=>x.Trip).WithMany().HasForeignKey(x=>x.TripId).IsRequired();
        }
    }
}
