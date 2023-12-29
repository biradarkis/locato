using Locato.Data.Contracts;
using Locato.Data.Entities.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locato.Data.Entities.Transport.VehicleEntities
{
    [Table("vehicleavailbility")]
    public class VehicleAvailabilityLog : Entity, IValidatableObject
    {
        public VehicleAvailabilityLog(long orgId, long vehicleId, DateTime from, DateTime to)
        {
            OrgId = orgId;
            VehicleId = vehicleId;
            From = from;
            To = to;
        }

        public long OrgId { get; private set; }
        public Organization Organization { get; set; }
        public long VehicleId { get; private set; }
        public Vehicle Vehicle { get;set; }
        public DateTime From { get; private set; }
        public DateTime To { get; private set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return Array.Empty<ValidationResult>();
        }
        
    }


    internal class VehicleAvailabilityLogConfiguration : IEntityTypeConfiguration<VehicleAvailabilityLog>
    {
        public void Configure(EntityTypeBuilder<VehicleAvailabilityLog> builder)
        {
            builder.HasOne(x => x.Organization).WithMany().HasForeignKey(x => x.OrgId).IsRequired();
            builder.HasOne(x=>x.Vehicle).WithMany().HasForeignKey(x=>x.VehicleId).IsRequired();
        }
    }
}
