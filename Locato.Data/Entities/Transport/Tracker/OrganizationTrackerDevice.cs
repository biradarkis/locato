using Locato.Data.Entities.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locato.Data.Entities.Transport.Tracker
{
    [Table("orgtrackerdevices")]
    public class OrganizationTrackerDevice
    {
        public long TrackerDeviceId { get; set; }
        public virtual TrackerDevice TrackerDevice { get; set; }

        public long OrganizationId { get; set; }
        public virtual Organization Organization { get; set; }
    }
    internal class OrganizationTrackerDeviceConfiguration : IEntityTypeConfiguration<OrganizationTrackerDevice>
    {
        public void Configure(EntityTypeBuilder<OrganizationTrackerDevice> builder)
        {
            builder.HasKey(x=> new {x.TrackerDeviceId, x.OrganizationId});
        }
    }
}
