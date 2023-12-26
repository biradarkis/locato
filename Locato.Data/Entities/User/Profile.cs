using Locato.Data.Contracts;
using Locato.Data.Web;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uFony.Data.Web;

namespace Locato.Data.Entities.UserEntities
{
    public class Profile : Entity, IValidatableObject
    {
        public string FirstName { get;set; }
        public string LastName { get;set; }
        public string MiddleName { get;set; }
        public string FullName => $"{FirstName}{(!string.IsNullOrEmpty(MiddleName) ? " " + MiddleName : "")} {(!string.IsNullOrEmpty(LastName) ? " " + LastName : "")}";
        public DateTime? DateOfBirth { get; set; }
        public int Age =>  DateOfBirth.HasValue ? DateTime.Now.Year - DateOfBirth.Value.Year:0;
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return Array.Empty<ValidationResult>();
        }

        public Sex Sex { get; set; }
        public virtual Photo Photo { get; set; }

    }
}
