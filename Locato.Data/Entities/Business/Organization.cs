using Locato.Data.Contracts;
using Locato.Data.Entities.Media;
using Locato.Data.Entities.Scheduling;
using Locato.Data.Entities.Transport.Routes;
using Locato.Data.Entities.Transport.Tracker;
using Locato.Data.Entities.Transport.VehicleEntities;
using Locato.Data.Entities.UserEntities;
using Locato.Data.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uFony.Data.Web;

namespace Locato.Data.Entities.Business
{
    public class Organization : Entity, IValidatableObject
    {
        [MaxLength(255)]
        public string Name { get; set; }
        public string? ShortName { get; set; }

        public Phone Phone { get; set; }

        public Phone? AlternatePhone { get; set; }

        public Location Address { get; set; }
        public string? Website { get; set; }
        public string? API_URL { get; set; }
        public long? LogoId { get; set; }
        public virtual StaticMedia Logo { get; set; }
        public virtual ICollection<Route> Routes { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
        public virtual ICollection<TrackerDevice> TrackerDevices { get; set; }
        public virtual ICollection<OrganizationShift> Shifts { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Holiday> Events { get; set; }
        public bool IsActive { get; set; }
        public string? Locale { get; set; }
        public string Currency { get; set; }
        public string PANNumber { get; set; }
        public string? TANNumber { get; set; }
        public string GSTNumber { get; set; }
        /// <summary>
        /// <see cref="OrganizatinType"/>
        /// </summary>
        public string Type { get;set; }
        public long? VendorId { get; set; }
        public Organization Vendor { get; set; }
        public Organization()
        {
            IsActive = true;
            Users = new HashSet<User>();
            Routes = new HashSet<Route>();
            Shifts = new  HashSet<OrganizationShift>(); 
            Events = new HashSet<Holiday>();   
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
                if (Type == OrganizatinType.ORGANIZATION.ToString() && VendorId == null)
                {
                return new[]
                {
                    new ValidationResult("Cannnot insert an organization without vendorId if the organization type is a Vendor Dependent Organization",new []{"VendorId"})
                };
                };
             return Array.Empty<ValidationResult>();
        }
    }

    internal class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.HasMany(x=>x.Events).WithOne(x=>x.Organization).HasForeignKey(x=>x.OrganizationId);
            builder.HasMany(x=>x.Users).WithOne(x=>x.Organization).HasForeignKey(x=>x.OrganizationId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Routes).WithOne(x => x.Organization).HasForeignKey(x => x.OrganizationId).IsRequired();
            builder.OwnsOne(x => x.Phone);
            builder.OwnsOne(x => x.Address);
            builder.OwnsOne(x => x.AlternatePhone);
            builder.HasOne(x => x.Vendor).WithMany().HasForeignKey(x => x.VendorId).IsRequired(false);
        }
    }

    public enum OrganizatinType
    {
        VENDOR ,
        INDEPENDENT_ORGANIZATION,
        ORGANIZATION
    }
}
    