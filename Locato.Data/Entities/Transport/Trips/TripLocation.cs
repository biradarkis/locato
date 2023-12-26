using Locato.Data.Contracts;
using Locato.Data.Web;
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
    public class TripLocation : Entity, IValidatableObject
    {
        public long TripId { get; set; }
        public virtual Trip Trip { get; set; }

        public Coordinate Location { get; set; }

        public TripLocation()
        {
            Location = new Coordinate();
        }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return Array.Empty<ValidationResult>(); 
        }
    }
    internal class TripLocationConfiguration : IEntityTypeConfiguration<TripLocation>
    {
        public void Configure(EntityTypeBuilder<TripLocation> builder)
        {
            builder.HasOne(x => x.Trip).WithMany(x => x.TripLocations).HasForeignKey(x => x.TripId).IsRequired();
            builder.OwnsOne(x => x.Location);
         
        }
    }

}
