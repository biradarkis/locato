using Locato.Data.Entities.Transport.Routes;
using Locato.Data.Web;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Locato.Data.EntityFramework.Seed
{
    public partial class ApplicationContextSeed
    {
        public async Task SeedRouteGeoFenceCoordinates(CancellationToken cancellationToken)
        {
            var geoFenceCoordinates = new List<RouteGeoFenceCoordinate>
            {
                new RouteGeoFenceCoordinate
                {
                    RouteId = 1,
                    GeofencePoint = new Coordinate { Latitude = 123.456, Longitude = 456.789 }
                },
                new RouteGeoFenceCoordinate
                {
                    RouteId = 2,
                    GeofencePoint = new Coordinate { Latitude = 111.222, Longitude = 333.444 }
                }
            };

            _context.RouteGeoFenceCoordinates.AddRange(geoFenceCoordinates);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
