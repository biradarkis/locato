using Locato.Data.Contracts;
using Locato.Data.Entities.Business;
using Locato.Data.Entities.Media;
using Locato.Data.Entities.Transport.Routes;
using Locato.Data.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Locato.Data.Entities.Scheduling
{
    /// <summary>
    /// While Adding new Entities check if there's already a event on that day 
    /// </summary>
    public class Holiday : Entity , IValidatableObject
    {
        public DateTime DateTime { get; set; }
        public required string Description { get; set; }
        public bool IsHoliday { get; set; }
        public long? MediaId { get; set; }
        public virtual StaticMedia Media { get; set; }
        public virtual Organization Organization { get; set; }  
        public long? OrganizationId { get; set; }
        public long? UserId { get;set; }
        public virtual User User { get;set; }
        public virtual Route Route { get; set; }
        public long? RouteId { get; set; }
        /// <summary>
        /// Type of the event , either a holiday by organization or leave by employee
        /// <see cref="EventType"/>
        /// </summary>
        public string Type { get; set; }
        [Column("isuserevent")]
        public bool IsUserEvent { get;set; }
        [Column("isorgevent")]
        public bool IsOrganizationEvent { get;set; }
        [Column("isrouteevent")]
        public bool IsRouteEvent { get;set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if((IsUserEvent && IsOrganizationEvent && IsRouteEvent ) || (IsOrganizationEvent && IsRouteEvent) || (IsOrganizationEvent && IsUserEvent) || (IsUserEvent && IsRouteEvent))
            {
                yield return new ValidationResult(
                 "An Event can only of one type",
                 new[] { nameof(IsUserEvent), nameof(IsUserEvent) });
            }
            if(IsUserEvent && UserId==null)
            {
                yield return new ValidationResult(
                  "UserId can't be null if it's a Employee Event",
                  new[] { nameof(IsUserEvent), nameof(UserId) });
            }

            if(IsOrganizationEvent && OrganizationId == null)
            {
                yield return new ValidationResult(
                                "OrganizationId can't be null if it's a Organization Event",
                                new[] { nameof(IsOrganizationEvent), nameof(OrganizationId) });
            }

            if(IsRouteEvent && RouteId == null)
            {
                yield return new ValidationResult(
                               "OrganizationId can't be null if it's a Organization Event",
                               new[] { nameof(IsRouteEvent), nameof(RouteId) });
            }
        }
    }

    internal class EventConfiguration : IEntityTypeConfiguration<Holiday>
    {
        public void Configure(EntityTypeBuilder<Holiday> builder)
        {
            
        }
    }

    public enum  EventType
    {
        HOLIDAY,
        LEAVE,
        ROUTEEVENT
    }
}
