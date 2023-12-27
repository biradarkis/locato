using Locato.Data.Contracts;
using Locato.Data.Entities.Business;
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
    public class TrackerDevice : Entity, IValidatableObject
    {
        //IMEI
        public string Identity { get; set; }

        public string Name { get; set; }

        public string Remarks { get; set; }
        /// <summary>
        /// TODo : ask viren about this 
        /// </summary>
        public virtual Organization Organization { get; set; }
        public long OrgId { get; set; }
        public virtual ICollection<TrackerDeviceLocation> LocationsLog { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return Array.Empty<ValidationResult>();
        }

    }
    internal class TrackerDeviceConfiguration : IEntityTypeConfiguration<TrackerDevice>
    {
        public void Configure(EntityTypeBuilder<TrackerDevice> builder)
        {
            builder.HasOne(x => x.Organization).WithMany(x => x.TrackerDevices).HasForeignKey(x => x.OrgId).IsRequired();

        }
    }
}
