using Locato.Data.Entities.Transport.Routes;
using Locato.Data.Web;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Locato.Data.EntityFramework.Seed
{
    public partial class ApplicationContextSeed
    {
        public async Task SeedRouteStops(CancellationToken cancellationToken)
        {
            var routeStops = new List<RouteStop>
            {
                new RouteStop
                {
                    PlaceId = "PlaceId1",
                    Coordinate = new Coordinate { Latitude = 12.345, Longitude = 67.890 },
                    Address = "Address 1",
                    Index = 1,
                    RouteId = 1
                },
                new RouteStop
                {
                    PlaceId = "PlaceId2",
                    Coordinate = new Coordinate { Latitude = 98.765, Longitude = 43.210 },
                    Address = "Address 2",
                    Index = 2,
                    RouteId = 2
                }
            };

            _context.RouteStops.AddRange(routeStops);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
