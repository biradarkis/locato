using Locato.Data.Entities.Transport.Routes;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Locato.Data.EntityFramework.Seed
{
    public partial class ApplicationContextSeed
    {
        public async Task SeedRouteStopGeoFences(CancellationToken cancellationToken)
        {
            var routeStopGeoFences = new List<RouteStopGeoFence>
            {
                new RouteStopGeoFence
                {
                    RouteStopId = 1,
                    RadiusInMeters = 100.0
                },
                new RouteStopGeoFence
                {
                    RouteStopId = 2,
                    RadiusInMeters = 150.0
                }
            };

            _context.RouteStopGeoFences.AddRange(routeStopGeoFences);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
