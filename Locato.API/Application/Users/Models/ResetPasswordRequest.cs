namespace Locato.API.Application.Users.Models
{
    public class ResetPasswordRequest
    {
        public required string NewPassword { get;set; }
        public required string CurrentPassword { get;set; }  
    }
}
