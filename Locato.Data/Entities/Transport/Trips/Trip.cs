using Locato.Data.Contracts;
using Locato.Data.Entities.Communication;
using Locato.Data.Entities.Transport.Routes;
using Locato.Data.Entities.Transport.Tracker;
using Locato.Data.Entities.UserEntities;
using Locato.Data.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locato.Data.Entities.Transport.Trips
{
    public class Trip : Entity, IValidatableObject
    {
        public Coordinate StartLocation { get; set; }

        public Coordinate EndLocation { get; set; }
        public Coordinate LastKnownLocation { get; set; }

        public virtual ICollection<TripLocation> TripLocations { get; set; }

        public long? DriverId { get; set; }
        public virtual Driver Driver { get; set; }

        public long? TrackerDeviceId { get; set; }
        public virtual TrackerDevice TrackerDevice { get; set; }

        public long RouteId { get; set; }
        public virtual Route Route { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public string VehicleLicenseNumber { get; set; }

        public bool InProgress { get; set; }

        public string? EndReason { get; set; }

        public DateTimeOffset? StartedOn { get; set; }

        public DateTimeOffset? EndedOn { get; set; }

        public double? DistanceTravelled { get; set; }
        /// <summary>
        /// <see cref="TripTimingStatus"/>
        /// </summary>
        public string TimingStatus { get; set; }

        public Trip()
        {
            
            TripLocations = new HashSet<TripLocation>();
            StartLocation = new Coordinate();
            EndLocation = new Coordinate();
            LastKnownLocation = new Coordinate();
        }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return Array.Empty<ValidationResult>(); 
        }

    }

    public enum TripTimingStatus
    {
        OnTime,
        Early,
        Late
    }

    internal class TripConfiguration : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            builder.HasOne(x=>x.Route).WithMany(x=>x.Trips).HasForeignKey(x=>x.RouteId).IsRequired();
            builder.HasOne(x => x.Driver);
            builder.HasMany(x => x.TripLocations);
            builder.HasMany(x=>x.Messages).WithOne(x=>x.Trip).HasForeignKey(x=>x.TripId).IsRequired();
            builder.OwnsOne(x => x.StartLocation);
            builder.OwnsOne(x => x.EndLocation);
            builder.OwnsOne(x => x.LastKnownLocation);

        }
    }
}
