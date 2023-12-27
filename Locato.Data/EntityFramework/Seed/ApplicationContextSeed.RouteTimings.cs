using Locato.Data.Entities.Transport.Routes;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Locato.Data.EntityFramework.Seed
{
    public partial class ApplicationContextSeed
    {
        public async Task SeedRouteTimings(CancellationToken cancellationToken)
        {
            var routeTimings = new List<RouteTiming>
            {
                new RouteTiming
                {
                    RouteId = 1,
                    StartTime = DateTimeOffset.UtcNow,
                    EndTime = DateTimeOffset.UtcNow.AddHours(2),
                    Date = DateTime.UtcNow.Date,
                    VehicleId = 1
                },
                new RouteTiming
                {
                    RouteId = 2,
                    StartTime = DateTimeOffset.UtcNow.AddHours(3),
                    EndTime = DateTimeOffset.UtcNow.AddHours(5),
                    Date = DateTime.UtcNow.Date.AddDays(1),
                    VehicleId = 2
                }
            };

            _context.RouteTimings.AddRange(routeTimings);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
