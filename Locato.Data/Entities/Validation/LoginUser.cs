using Locato.Data.Contracts;
using Locato.Data.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locato.Data.Entities.Validation
{
    public class LoginUser : Entity, IValidatableObject
    {
        [EmailAddress, MaxLength(255)]
        public required string Username { get; set; }
        public long UserId { get; set; }
        public virtual User User { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return Array.Empty<ValidationResult>();
        }
    }
}
