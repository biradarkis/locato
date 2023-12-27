using Locato.Data.Entities.UserEntities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Locato.Data.EntityFramework.Seed
{
    public partial class ApplicationContextSeed
    {
        public async Task SeedUserDeviceInfo(CancellationToken cancellationToken)
        {
            var userDeviceInfos = new List<UserDeviceInfo>
            {
                new UserDeviceInfo
                {
                    DeviceToken = "APNSToken123",
                    OsVersion = "iOS 15.2",
                    DeviceType = "Apple"
                    // Add other UserDeviceInfo properties if needed
                },
                new UserDeviceInfo
                {
                    DeviceToken = "GCMToken456",
                    OsVersion = "Android 12",
                    DeviceType = "Android"
                    // Add other UserDeviceInfo properties if needed
                }
            };

            _context.UserDeviceInfo.AddRange(userDeviceInfos);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
