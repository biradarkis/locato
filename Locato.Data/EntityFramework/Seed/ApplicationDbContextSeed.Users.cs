using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locato.Data.Entities.UserEntities;
using Locato.Data.Web;

namespace Locato.Data.EntityFramework.Seed
{
    partial class ApplicationDbContextSeed
    {
        private async Task SeedUsers(CancellationToken  cancellationToken)
        {
            if (_context.Users.Count() > 2)
            {
                return;
            }

            var organizationIds = await _context.Organizations.Select(x => x.Id).ToArrayAsync(cancellationToken);
            var profileIds  = await _context.Profiles.Select(x=>x.Id).ToArrayAsync(cancellationToken);
            var routeIds = await _context.Routes.Select(x => x.Id).ToArrayAsync(cancellationToken);
            var shiftIds = await _context.OrganizationShifts.Select(x => x.Id).ToArrayAsync(cancellationToken);
            for (int i = 0;i < profileIds.Length;i++)
            {
                var user = new User(email: $"user{profileIds[i]}@example.com", unhashedPassword:"aaaaa");

                user.UpdatePhone(new Phone
                {
                    CountryCode = 91,
                    NationalNumber = 123456789,
                    RawInput = "+91123456789",
                    E164Format = 91123456789
                });
                user.LastSeen = null;
                user.ProfileId = profileIds[i];
                user.EmailVerified = true;
                user.PhoneVerified = true;
                user.AccountStatus = "Active";
                user.Designation = "Engineer";
                user.Location = new Location
                {

                    City = "Pimple Saudagar",
                    Country = "India",
                    Latitude = 18.33333,
                    Longitude = 78.23,
                    State = "Maharastra",
                    Street = "Roseland commercial complex",
                    Zip = "411057"
                };
                user.RouteId = routeIds[i%routeIds.Length];
                user.OrganizationId = organizationIds[i % organizationIds.Length];
                user.ShiftId = shiftIds[i%shiftIds.Length];
                _context.Users.Add(user);
            }

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
