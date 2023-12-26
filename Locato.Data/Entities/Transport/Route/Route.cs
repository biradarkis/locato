using Locato.Data.Contracts;    
using Locato.Data.Entities.Business;
using Locato.Data.Entities.Transport.Trips;
using Locato.Data.Entities.Transport.VehicleEntities;
using Locato.Data.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locato.Data.Entities.Transport.Routes
{
    public class Route : TrackedEntity, IValidatableObject
    {
        public string Name { get; set; }

        public DateTimeOffset? StartTime { get; set; }
        public DateTimeOffset? EndTime { get; set; }

        public DateTimeOffset? OnTimeFrom { get; set; }
        public DateTimeOffset? OnTimeTo { get; set; }

        public  long OrganizationId { get; set; }
        public virtual Organization Organization { get; set; }

        public long? VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }

        public virtual ICollection<RouteStop> Stops { get; set; }

        public BaseLocation StartLocation { get; set; }
        public BaseLocation EndLocation { get; set; }

        public string Track { get; set; }

        public int AverageSpeed { get; set; }

        public bool NotifyOnTripStart { get; set; } = true;

        public bool NotifyOnTripStop { get; set; } = true;

        public bool NotifyForEta { get; set; }

        public bool CalculateEta { get; set; }

        public string DrawnRoute { get; set; }
        /// <summary>
        /// <see cref="RouteType"/>
        /// </summary>
        public string? Type { get; set; }

        public virtual ICollection<RouteTiming> Timings { get; set; }

        public virtual ICollection<RouteGeoFenceCoordinate> GeofenceCoordinates { get; set; }

        public virtual ICollection<Trip> Trips { get; set; }

        public Route()
        {
            Stops = new HashSet<RouteStop>();
            StartLocation = new BaseLocation();
            EndLocation = new BaseLocation();
            Timings = new HashSet<RouteTiming>();
            GeofenceCoordinates = new HashSet<RouteGeoFenceCoordinate>();
            Trips = new HashSet<Trip>();
        }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return Array.Empty<ValidationResult>();
        }
    }

    internal class RouteConfiguration : IEntityTypeConfiguration<Route>
    {
        public void Configure(EntityTypeBuilder<Route> builder)
        {
            builder.HasOne(x=>x.Organization).WithMany(x=>x.Routes).HasForeignKey(x=>x.OrganizationId).OnDelete(DeleteBehavior.Restrict).IsRequired();
            builder.HasMany(x => x.Trips).WithOne(x => x.Route).HasForeignKey(x => x.RouteId).OnDelete(DeleteBehavior.Restrict).IsRequired();
            builder.HasMany(x => x.Stops).WithOne(x => x.Route).HasForeignKey(x => x.RouteId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.GeofenceCoordinates).WithOne(x => x.Route).HasForeignKey(x => x.RouteId);
            builder.OwnsOne(x => x.StartLocation);
            builder.OwnsOne(x => x.EndLocation);
        }
    }
}
