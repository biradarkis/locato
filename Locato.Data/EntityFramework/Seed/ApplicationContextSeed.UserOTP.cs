using Locato.Data.Entities.Validation;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Locato.Data.EntityFramework.Seed
{
    public partial class ApplicationContextSeed
    {
        public async Task SeedUserOTP(CancellationToken cancellationToken)
        {
            var userOTPs = new List<UserOTP>
            {
                new UserOTP
                {
                    UserId = 1,
                    Otp = 123456,
                    ExpiryDate = DateTime.UtcNow.AddMinutes(10)
                },
                new UserOTP
                {
                    UserId = 2,
                    Otp = 654321,
                    ExpiryDate = DateTime.UtcNow.AddMinutes(10)
                }
            };

            _context.UserOTPs.AddRange(userOTPs);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
