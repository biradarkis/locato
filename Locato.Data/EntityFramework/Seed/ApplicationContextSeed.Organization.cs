using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locato.Data.Entities.Business;

namespace Locato.Data.EntityFramework.Seed
{
    public partial class ApplicationContextSeed
    {
        private async Task SeedOrganization(CancellationToken cancellationToken)
        {
            if (_context.Organizations.Count() > 1)
                return;

            _context.Organizations.Add(new Organization
            {
                Name = "ufony services pvt ltd",
                Address = new Web.Location
                {
                    City = "Pimple Saudagar",
                    Country = "India",
                    Latitude = 18.33333,
                    Longitude = 78.23,
                    State ="Maharastra",
                    Street = "Roseland commercial complex",
                    Zip = "411057"
                },
                Currency = "INR",
                API_URL = "api.schooldiary.me",
                IsActive = true,
                PANNumber = "GMMPEH1234A",
                Website ="Web.zoment.com",
                ShortName = "Ufony",
                Phone =  new Web.Phone
                {
                    CountryCode = 91,
                    E164Format = 91123456789,
                    NationalNumber = 123456789,
                    RawInput ="+91123456789"
                },

            });

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
