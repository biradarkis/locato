using Locato.Data.Web;

namespace Locato.API.Application.Users.Models
{
    public class AddUserProfileRequest
    {
        public required string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Sex Sex { get; set; }
    }
}
