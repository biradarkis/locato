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
    public class TripSubscriber : Entity, IValidatableObject
    {
        public long SubscriberId { get; set; }
        public virtual User Subscriber { get; set; }

        public string ConnectionId { get; set; }

        public string Source { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return Array.Empty<ValidationResult>(); 
        }
    }

    public class TripSubscriberConfiguration : IEntityTypeConfiguration<TripSubscriber>
    {
        public void Configure(EntityTypeBuilder<TripSubscriber> builder)
        {
            builder.HasOne(x => x.Subscriber).WithMany().HasForeignKey(x => x.SubscriberId);
        }
    }
}
