using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locato.Data.Entities.Business;
using Locato.Data.Entities.UserEntities;

namespace Locato.Data.EntityFramework.Seed
{
    public partial class ApplicationContextSeed
    {
        private async Task SeedBaseUser(CancellationToken cancellationToken)
        {
            new BaseUser
            {
                Username = "user1@example.com",
                Password = "password1",
                AccountStatus = "Active",
                LoginAttempts = 0,
                IsDeleted = false
            };
            new BaseUser
            {
                Username = "+911234567890",
                Password = "password2",
                AccountStatus = "Inactive",
                LoginAttempts = 3,
                IsDeleted = false
            };

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
