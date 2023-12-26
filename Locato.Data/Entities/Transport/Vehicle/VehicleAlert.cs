using Locato.Data.Contracts;
using Locato.Data.Entities.Transport.Tracker;
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

namespace Locato.Data.Entities.Transport.VehicleEntites
{
    public class VehicleAlert : Entity, IValidatableObject
    {

        public long OrgBusId { get; set; }
        public virtual Vehicle Vehicle{ get; set; }

        public long TrackerDeviceId { get; set; }
        public virtual TrackerDevice TrackerDevice { get; set; }

        public string Text { get; set; }

        public Coordinate Location { get; set; }

        public DateTimeOffset Timestamp { get; set; }
        /// <summary>
        /// <see cref="OrgBusAlertType"/>
        /// </summary>
        public string AlertType { get; set; }

        public long? TrackerDeviceAlarmId { get; set; }
        public virtual TrackerDeviceAlarm TrackerDeviceAlarm { get; set; }

        public long? TripId { get; set; }
        public virtual Trip Trip { get; set; }

        public virtual ICollection<VehicleAlertUser> Users { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return Array.Empty<ValidationResult>();
        }
        public VehicleAlert()
        {
            Location = new Coordinate();
        }
    }

    public enum OrgBusAlertType
    {
        DeviceAlarm,
        RouteGeofence,
        Blackout
    }


    internal class VehicleAlertConfiguration : IEntityTypeConfiguration<VehicleAlert>
    {
        public void Configure(EntityTypeBuilder<VehicleAlert> builder)
        {
            builder.OwnsOne(x => x.Location);   
        }
    }
}
