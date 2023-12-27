using Locato.Data.Entities.Business;
using Locato.Data.Entities.Transport.Tracker;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Locato.Data.EntityFramework.Seed
{
    public partial class ApplicationContextSeed
    {
        public async Task SeedTrackerDevices(CancellationToken cancellationToken)
        {
            var trackerDevices = new List<TrackerDevice>
            {
                new TrackerDevice
                {
                    Identity = "IMEI12345",
                    Name = "Device 1",
                    Remarks = "Some remarks for Device 1",
                    OrgId = 1
                },
                new TrackerDevice
                {
                    Identity = "IMEI67890",
                    Name = "Device 2",
                    Remarks = "Some remarks for Device 2",
                    OrgId = 2
                }
            };

            _context.TrackerDevices.AddRange(trackerDevices);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
