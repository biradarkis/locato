using Locato.Data.Entities.UserEntities;
using Locato.Data.Web;

namespace Locato.Web.Application.Users.Models
{
    public class LoginResponse
    {
        public bool Success { get; set; }

        public string Error { get; set; }

        public long Id { get; private set; }

        public string Name { get; private set; }
        public string PicUrl { get; private set; }  

        public string Email { get; private set; }

        public string Token { get; private set; }

        public string RefreshToken { get; private set; }

        public string Role { get; private set; }
        public Phone Phone { get; private set; }    

        public LoginResponse(string error)
        {
            Success = false;
            Error = error;
        }

        public LoginResponse(User user, string token, string refreshToken)
        {
            Success = true;
            Id = user.Id;
            Name = user.Profile.FullName;
            PicUrl = user.Profile.Photo.StorageURL;
            Phone = user.Phone;
            Email = user.Email;
            Token = token;
            RefreshToken = refreshToken;
        }
    }
}
