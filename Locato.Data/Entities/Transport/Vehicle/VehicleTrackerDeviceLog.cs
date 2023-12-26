using Locato.Data.Contracts;
using Locato.Data.Entities.Transport.Tracker;
using Locato.Data.Entities.Transport.VehicleEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locato.Data.Entities.Transport.VehicleEntites
{
    [Table("vehicletdlogs")]
    public class VehicleTrackerDeviceLog : Entity, IValidatableObject
    {
        public long VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }

        public long TrackerDeviceId { get; set; }
        public virtual TrackerDevice TrackerDevice { get; set; }
        /// <summary>
        /// <see cref="OrgBusTrackerDeviceLogType"/>
        /// </summary>
        public string LogEntryType { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return Array.Empty<ValidationResult>(); 
        }
    }

    public enum OrgBusTrackerDeviceLogType
    {
        Assigned,
        Removed
    }
}
