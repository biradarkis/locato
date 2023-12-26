using Locato.Data.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locato.Data.Entities.UserEntities
{
    public class BaseUser : Entity, IValidatableObject
    {
        /// <summary>
        /// Username can be email or Phone Number in E164Format
        /// </summary>
        [MaxLength(255)]
        public string Username { get; set; }

        public string Password { get; set; }
        /// <summary>
        /// Determines whether the account is in good standing or requires intervention.
        /// Acceptable Values are members of <see cref="LoginStatus"/> enum.
        /// </summary>
        public string AccountStatus { get; set; }

        public int LoginAttempts { get; set; }
        public virtual ICollection<User> Users { get; set; }

        public bool IsDeleted { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return Array.Empty<ValidationResult>();
        }
    }

    internal class BaseUserConfiguration : IEntityTypeConfiguration<BaseUser>
    {
        public void Configure(EntityTypeBuilder<BaseUser> builder)
        {
            builder.HasMany(x => x.Users).WithOne(x => x.BaseUser).HasForeignKey(x => x.BaseUserId).IsRequired().OnDelete(DeleteBehavior.Restrict);
        }
    }
}
