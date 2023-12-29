using Locato.Data.Contracts;
using Locato.Data.Entities.Transport.Trips;
using Locato.Data.Entities.Transport.VehicleEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locato.Data.Entities.Transport.VehicleEntities
{
    public class VehicleDistanceTraveled : Entity, IValidatableObject
    {
        public long VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }

        public DateTime Date { get; set; }

        public long? TripId { get; set; }
        public virtual Trip Trip { get;set; }
        public double DistanceTraveled { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return Array.Empty<ValidationResult>(); 
        }
    }

    internal class VehicleDistanceTraveledConfiguration : IEntityTypeConfiguration<VehicleDistanceTraveled>
    {
        public void Configure(EntityTypeBuilder<VehicleDistanceTraveled> builder)
        {
            builder.HasOne(x => x.Trip).WithOne().HasForeignKey<VehicleDistanceTraveled>(x => x.TripId);
        }
    }
}
