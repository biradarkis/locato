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

namespace Locato.Data.Entities.Transport.Routes
{
    [Table("routegeofencecords")]
    public class RouteGeoFenceCoordinate : Entity, IValidatableObject
    {
        public long RouteId { get; set; }
        public virtual Route Route { get; set; }

        public Coordinate GeofencePoint { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return Array.Empty<ValidationResult>(); 
        }

    }

    internal class RouteGeoFenceCoordincateConfiguration : IEntityTypeConfiguration<RouteGeoFenceCoordinate>
    {
        public void Configure(EntityTypeBuilder<RouteGeoFenceCoordinate> builder)
        {
            builder.OwnsOne(x => x.GeofencePoint);
        }
    }
}
