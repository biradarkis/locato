using Locato.Data.Contracts;
using Locato.Data.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locato.Data.Entities.Transport.Tracker
{
    [Table("trackerlocations")]
    public class TrackerDeviceLocation : Entity, IValidatableObject
    {
        public long TrackerDeviceId { get; set; }
        public virtual TrackerDevice TrackerDevice { get; set; }

        public Coordinate Location { get; set; }

        public DateTimeOffset Timestamp { get; set; }

        public int? Speed { get; set; }

        public int? InformationLength { get; set; }

        public int? SatellitesUsed { get; set; }

        public long? SerialNumber { get; set; }

        public bool? Acc { get; set; }

        public bool? RealTimeGps { get; set; }

        public bool? EastLongitude { get; set; }

        public bool? NorthLatitude { get; set; }

        public int? Course { get; set; }

        public double? Voltage { get; set; }

        public TrackerDeviceLocation()
        {
            Location = new Coordinate();
        }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return Array.Empty<ValidationResult>(); 
        }
    }

    internal class TrackerDeviceLocationConfiguration : IEntityTypeConfiguration<TrackerDeviceLocation>
    {
        public void Configure(EntityTypeBuilder<TrackerDeviceLocation> builder)
        {
            builder.OwnsOne(x => x.Location);
        }
    }
}
