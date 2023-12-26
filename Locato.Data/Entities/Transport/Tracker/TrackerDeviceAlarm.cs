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

namespace Locato.Data.Entities.Transport.Tracker
{
    public class TrackerDeviceAlarm : Entity, IValidatableObject
    {
        public long TrackerDeviceId { get; set; }
        public virtual TrackerDevice TrackerDevice { get; set; }

        public Coordinate Location { get; set; }

        public DateTimeOffset Timestamp { get; set; }

        public TrackerDeviceAlarmType AlarmType { get; set; }

        public string Meta { get; set; }

        public TrackerDeviceAlarm()
        {
            Location = new Coordinate();
        }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return Array.Empty<ValidationResult>();
        }

    }

    internal class TrackeDeviceAlaramConfiguration : IEntityTypeConfiguration<TrackerDeviceAlarm>
    {
        public void Configure(EntityTypeBuilder<TrackerDeviceAlarm> builder)
        {
            builder.OwnsOne(x => x.Location);
        }
    }

    public enum TrackerDeviceAlarmType
    {
        Normal,
        Sos,
        PowerCut,
        Shock,
        FenceIn,
        FenceOut,
        OverSpeed,
        Idling,
        GreenDriving,
        Towing,
        Crash,
        Jamming,
        Trip,
        Unknown

    }

    internal class TrackeDeviceAlarmConfiguration : IEntityTypeConfiguration<TrackerDeviceAlarm>
    {
        public void Configure(EntityTypeBuilder<TrackerDeviceAlarm> builder)
        {
            builder.OwnsOne(x => x.Location);
        }
    }
}

