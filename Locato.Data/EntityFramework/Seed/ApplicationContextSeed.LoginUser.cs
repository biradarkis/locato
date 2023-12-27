using Locato.Data.Entities.Validation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace Locato.Data.EntityFramework.Seed
{
    public partial class ApplicationContextSeed
    {
        public async Task SeedLoginUsers(CancellationToken cancellationToken)
        {
            var loginUsers = new List<LoginUser>
            {
                new LoginUser
                {
                    Username = "user1@example.com",
                    UserId = 1
                },
                new LoginUser
                {
                    Username = "user2@example.com",
                    UserId = 2
                }
            };

            _context.LoginUsers.AddRange(loginUsers);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
