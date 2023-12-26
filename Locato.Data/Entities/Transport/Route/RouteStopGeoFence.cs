using Locato.Data.Contracts;
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
    public class RouteStopGeoFence : Entity , IValidatableObject
    {
        public long RouteStopId { get; set; }
        public virtual RouteStop Stop { get; set; }
        public double RadiusInMeters { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return Array.Empty<ValidationResult>(); 
        }
    }

    class RouteStopGeoFenceConfiguration : IEntityTypeConfiguration<RouteStopGeoFence>
    {
        public void Configure(EntityTypeBuilder<RouteStopGeoFence> builder)
        {
            builder.HasOne(x => x.Stop).WithOne(x => x.Geofence);
        }
    }

}
