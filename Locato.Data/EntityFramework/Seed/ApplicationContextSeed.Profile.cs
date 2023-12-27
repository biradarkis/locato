using Locato.Data.Entities.UserEntities;
using Locato.Data.Web;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Locato.Data.EntityFramework.Seed
{
    public partial class ApplicationContextSeed
    {
        public async Task SeedProfiles(CancellationToken cancellationToken)
        {
            var profiles = new List<Profile>
            {
                new Profile
                {
                    FirstName = "John",
                    LastName = "Doe",
                    MiddleName = "Henry",
                    DateOfBirth = new DateTime(1990, 5, 15),
                    Sex = Sex.Male,
                },
                new Profile
                {
                    FirstName = "Jane",
                    LastName = "Doe",
                    DateOfBirth = new DateTime(1992, 9, 23),
                    Sex = Sex.Female,
                }
            };

            _context.Profiles.AddRange(profiles);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
