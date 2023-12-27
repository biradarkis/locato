using Locato.Data.Contracts;
using Locato.Data.Entities.Business;
using Locato.Data.Entities.Communication;
using Locato.Data.Entities.Scheduling;
using Locato.Data.Entities.Transport.Routes;
using Locato.Data.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using uFony.Data.Web;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Locato.Data.Entities.UserEntities
{
    public class User : Entity, IValidatableObject , IEquatable<User>
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return Array.Empty<ValidationResult>();

        }
        [Phone]
        public Phone Phone { get; set; }
        public int RoleId { get;set; }

        public Phone? AlternatePhone { get; set; }

        public DateTime? LastSeen { get; set; }

        public long ProfileId { get; set; }
        public virtual Profile Profile { get; set; }

        public required string Password { get; set; }

        public bool EmailVerified { get; set; }
        public bool PhoneVerified { get; set; }

        /// <summary>
        /// Determines whether the account is in good standing or requires intervention.
        /// Acceptable Values are members of <see cref="LoginStatus"/> enum.
        /// </summary>
        public string AccountStatus { get; set; }
        public Location Location { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual Route Route { get; set; }
        public long RouteId { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public long OrganizationId  { get; set; }
        
        public virtual ICollection<SmsNotification> SmsNotifications { get; set; }

        public virtual ICollection<UserDeviceInfo> UserDevices { get; set; }

        public string Designation { get; set; }

        public bool Equals(User other)
        {
            // If parameter is null, return false. 
            if (ReferenceEquals(other, null))
                return false;

            // Optimization for a common success case. 
            if (ReferenceEquals(this, other))
                return true;

            // if user ids match, return true
            return Id == other.Id;
        }

        

        public User()
        {
            Phone = new Phone();
            Location = new Location();
            RoleId = (int) Roles.User;
        }
    }
    public class UserEqualityComparer : IEqualityComparer<User>
    {
        public bool Equals(User x, User y)
        {
            return x.Id.Equals(y.Id);
        }

        public int GetHashCode(User obj)
        {
            return obj.Id.GetHashCode();
        }
    }

    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(x=>x.Events).WithOne(x=>x.User).HasForeignKey(x=>x.UserId).IsRequired();
            builder.HasOne(x => x.Route).WithMany().HasForeignKey(x => x.RouteId).IsRequired();
            builder.OwnsOne(x => x.Phone);
            builder.OwnsOne(x => x.Location);
            builder.OwnsOne(x => x.AlternatePhone);
        }
    }
}