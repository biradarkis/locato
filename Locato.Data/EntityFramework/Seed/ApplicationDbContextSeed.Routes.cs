using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locato.Data.Entities.Transport.Routes;

namespace Locato.Data.EntityFramework.Seed
{
    partial class ApplicationDbContextSeed
    {
        private async Task SeedRoutes(CancellationToken cancellationToken)
        {
            if(_context.Routes.Count()>2) 
            {
                return;
            }

            var orgids = _context.Organizations.Select(x => x.Id).ToArray();
            var shiftIds  = _context.OrganizationShifts.Select(x => x.Id).ToArray();
            for (int i = 0; i < orgids.Length; i++)
            {
                var r = new Route
                {
                    Name = $"Route {i + 1}",
                    StartTime = DateTimeOffset.Now,
                    EndTime = DateTimeOffset.Now.AddHours(2),
                    OnTimeFrom = DateTimeOffset.Now.AddMinutes(30),
                    OnTimeTo = DateTimeOffset.Now.AddHours(3),
                    OrganizationId = orgids[i], // Replace with actual OrganizationId
                    Track = "Sample Track",
                    AverageSpeed = 50,
                    ShiftId = shiftIds[i],
                    NotifyOnTripStart = true,
                    NotifyOnTripStop = true,
                    NotifyForEta = false,
                    CalculateEta = true,
                    DrawnRoute = "Sample Drawn Route",
                    Type = "Sample Type",
                    EndLocation = new Web.BaseLocation
                    {
                        Latitude = 18.0 + i,
                        Longitude = 70.0 + i,
                        Address = $"Sample Address {i + 1}",
                        PlaceId = $"SamplePlaceId{i + 1}"
                    },
                    StartLocation = new Web.BaseLocation
                    {
                        Latitude = 18.0 + i,
                        Longitude = 70.0 + i,
                        Address = $"Sample Address {i + 1}",
                        PlaceId = $"SamplePlaceId{i + 1}"
                    }
                };
                _context.Routes.Add(r);
            }

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
