using Locato.Data.Entities.Transport.Routes;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Locato.Data.EntityFramework.Seed
{
    public partial class ApplicationContextSeed
    {
        public async Task SeedRoutes(CancellationToken cancellationToken)
        {
            var routes = new List<Route>
            {
                new Route
                {
                    Name = "Route 1",
                    StartTime = DateTimeOffset.UtcNow.AddHours(1),
                    EndTime = DateTimeOffset.UtcNow.AddHours(4),
                    OnTimeFrom = DateTimeOffset.UtcNow.AddHours(1),
                    OnTimeTo = DateTimeOffset.UtcNow.AddHours(4),
                    OrganizationId = 1, // Assign an existing organization ID
                    VehicleId = 1, // Assign an existing vehicle ID or set it to null
                    Track = "Track1",
                    AverageSpeed = 60,
                    NotifyOnTripStart = true,
                    NotifyOnTripStop = true,
                    NotifyForEta = false,
                    CalculateEta = true,
                    Type = "Type1",
                    DrawnRoute = "RouteDetails1"
                },
                new Route
                {
                    Name = "Route 2",
                    StartTime = DateTimeOffset.UtcNow.AddHours(2),
                    EndTime = DateTimeOffset.UtcNow.AddHours(5),
                    OnTimeFrom = DateTimeOffset.UtcNow.AddHours(2),
                    OnTimeTo = DateTimeOffset.UtcNow.AddHours(5),
                    OrganizationId = 2, // Assign an existing organization ID
                    VehicleId = 2, // Assign an existing vehicle ID or set it to null
                    Track = "Track2",
                    AverageSpeed = 55,
                    NotifyOnTripStart = true,
                    NotifyOnTripStop = true,
                    NotifyForEta = true,
                    CalculateEta = false,
                    Type = "Type2",
                    DrawnRoute = "RouteDetails2"
                }
            };

            _context.Routes.AddRange(routes);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
