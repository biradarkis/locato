using Locato.Data.Contracts;
using Locato.Data.Entities.Transport.Routes;
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
    public class TripActiveGeoFence : Entity, IValidatableObject
    {
        public long TripId { get; set; }
        public virtual Trip Trip { get; set; }

        public long StopGeofenceId { get; set; }
        public virtual RouteStopGeoFence StopGeofence { get; set; }

        public Coordinate FirstCoordinate { get; set; }

        public Coordinate LastKnownCoordinate { get; set; } 
        /// <summary>
        /// <see cref="GeoFenceStatus"/>
        /// </summary>
        public string GeofenceStatus { get; set; }

        public DateTimeOffset EntryTime { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return Array.Empty<ValidationResult>(); 
        }

    }

    public enum GeoFenceStatus
    {
        In ,
        Out ,
        Unknown
    }
    internal class TripActiveGeoFenceConfiguration : IEntityTypeConfiguration<TripActiveGeoFence>
    {
        public void Configure(EntityTypeBuilder<TripActiveGeoFence> builder)
        {
            builder.HasOne(x => x.Trip).WithMany().HasForeignKey(x => x.TripId).IsRequired();
            builder.OwnsOne(x => x.FirstCoordinate);
            builder.OwnsOne(x => x.LastKnownCoordinate);
        }
    }
}
