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

namespace Locato.Data.Entities.Transport.Routes
{
    public class RouteStop : Entity, IValidatableObject
    {
        public string PlaceId { get; set; }

        public Coordinate Coordinate { get; set; }

        public string Address { get; set; }

        public int Index { get; set; }

        public long RouteId { get; set; }
        public virtual Route Route { get; set; }

        public virtual RouteStopGeoFence Geofence { get; set; }

        public RouteStop()
        {
            Coordinate = new Coordinate();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
           return Array.Empty<ValidationResult>();  
        }
    }

    class RouteStopConfiguration : IEntityTypeConfiguration<RouteStop>
    {
        public void Configure(EntityTypeBuilder<RouteStop> builder)
        {
            builder.HasOne(x => x.Route).WithMany(x => x.Stops).HasForeignKey(x => x.RouteId).IsRequired();
            builder.HasOne(x => x.Geofence).WithOne(x=>x.Stop).HasForeignKey<RouteStopGeoFence>(x=>x.RouteStopId);
            builder.OwnsOne(x => x.Coordinate);
        }
    }
}
