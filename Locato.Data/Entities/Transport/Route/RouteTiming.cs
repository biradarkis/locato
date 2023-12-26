using Locato.Data.Contracts;
using Locato.Data.Entities.Transport.VehicleEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Locato.Data.Entities.Transport.Routes
{
    public class RouteTiming : Entity, IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return Array.Empty<ValidationResult>(); 
        }

        public long RouteId { get; set; }
        public virtual Route Route { get; set; }

        public DateTimeOffset StartTime { get; set; }

        public DateTimeOffset EndTime { get; set; }

        public DateTime Date { get; set; }

        public long VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }

    class RouteTimingConfiguration : IEntityTypeConfiguration<RouteTiming>
    {
        public void Configure(EntityTypeBuilder<RouteTiming> builder)
        {
            builder.HasOne(x => x.Route).WithMany(x => x.Timings).HasForeignKey(x => x.RouteId);
        }
    }
}
