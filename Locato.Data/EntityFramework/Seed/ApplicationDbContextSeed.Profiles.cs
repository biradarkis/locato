using Locato.Data.Entities.UserEntities;
using Locato.Data.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locato.Data.EntityFramework.Seed
{
    partial class ApplicationDbContextSeed
    {
        private async Task SeedProfiles (CancellationToken cancellationToken)
        {
            if (_context.Profiles.Count() > 2)
                return;
            var profiles = new List<Profile>
            {
                new Profile
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Sex = Sex.Male,
                    DateOfBirth = DateTime.UtcNow.AddYears(-20).AddMonths(-2)
                },
                new Profile
                {
                    FirstName = "Jane",
                    LastName = "Doe",
                    Sex = Sex.Female,
                    DateOfBirth = DateTime.UtcNow.AddYears(-30).AddMonths(-2)
                }
            };

            _context.Profiles.AddRange(profiles);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
