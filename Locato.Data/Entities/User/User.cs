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
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Xml.Linq;

namespace Locato.Data.Entities.UserEntities
{
    public class User : Entity, IValidatableObject, IEquatable<User>, IUser
    {
        [Required, EmailAddress]
        public string Email { get;  protected set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return Array.Empty<ValidationResult>();

        }
        [Phone]
        public Phone Phone { get; protected set; }
        /// <summary>
        /// <see cref="UserRole"/>
        /// </summary>
        public int RoleId { get;set; }

        public Phone? AlternatePhone { get; set; }

        public DateTime? LastSeen { get; set; }

        public long ProfileId { get; set; }
        public virtual Profile Profile { get; set; }

        public string Password { get; set; }

        public bool EmailVerified { get; set; } = false;
        public bool PhoneVerified { get; set; } = false;

        /// <summary>
        /// Determines whether the account is in good standing or requires intervention.
        /// Acceptable Values are members of <see cref="LoginStatus"/> enum.
        /// </summary>
        public string AccountStatus { get; set; } = "created";
        public Location Location { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual Route Route { get; set; }
        public long? RouteId { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public long OrganizationId  { get; set; }
        /// <summary>
        /// Password reset Date
        /// </summary>
        public DateTime? ClearToken { get;set; }
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

    

        public User(string email, Phone phone, int roleId, string password, bool phoneVerified, Location location, long organizationId, DateTime? clearToken, string designation)
        {
            Email = email;
            Phone = phone;
            RoleId = roleId;
            if (!string.IsNullOrEmpty(password))
            {
                Password = passwordHasher.HashPassword(this, password);
            }
            PhoneVerified = phoneVerified;
            Location = location;
            OrganizationId = organizationId;
            ClearToken = clearToken;
            Designation = designation;
        }

        public void ClearPassword()
        {
            Password = "";
        }

        public void UpdatePassword(string UnHashedPassword)
        {
            if (string.IsNullOrEmpty(UnHashedPassword))
            {
                Password = passwordHasher.HashPassword(user: this, UnHashedPassword);
            }
        }
        public User(string email,  string unhashedPassword)
        {
            Email = email;
            Password = passwordHasher.HashPassword(this, unhashedPassword);
        }
        public void UpdateEmail (string Email)
        {
            this.Email = Email;
        }

        public void UpdatePhone (Phone phone)
        {
            this.Phone = phone;
        }
        private PasswordHasher<User> _passwordHasher;
        private PasswordHasher<User> passwordHasher
        {
            get
            {
                return _passwordHasher ??= new PasswordHasher<User>();
            }
        }

        public bool MatchPassword(string unhashedPassword)
        {
            var result = passwordHasher.VerifyHashedPassword(this, Password, unhashedPassword);
            return result == PasswordVerificationResult.Success || result == PasswordVerificationResult.SuccessRehashNeeded;
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

    public enum UserRole
    {
        Driver,
        User,
        Vendor,
        Admin
    }
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.RouteId).IsRequired(false);
            builder.HasMany(x=>x.Events).WithOne(x=>x.User).HasForeignKey(x=>x.UserId).IsRequired();
            builder.HasOne(x => x.Route).WithMany().HasForeignKey(x => x.RouteId).IsRequired();
            builder.OwnsOne(x => x.Phone);
            builder.OwnsOne(x => x.Location);
            builder.OwnsOne(x => x.AlternatePhone);
        }
    }
}