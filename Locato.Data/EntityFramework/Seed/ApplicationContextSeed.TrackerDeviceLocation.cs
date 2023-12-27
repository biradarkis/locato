using Locato.Data.Entities.Transport.Tracker;
using Locato.Data.Web;
using Microsoft.EntityFrameworkCore;
using System;

namespace Locato.Data.Seeding
{
    public static class TrackerDeviceLocationSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TrackerDeviceLocation>().HasData(
                new TrackerDeviceLocation
                {
                    Id = 1,
                    TrackerDeviceId = 1, // Fill in the Tracker Device ID
                    Location = new Coordinate
                    {
                        Latitude = 40.7128, // Your latitude value
                        Longitude = -74.0060 // Your longitude value
                    },
                    Timestamp = DateTimeOffset.UtcNow,
                    Speed = 60, // Speed value
                },
                new TrackerDeviceLocation
                {
                    Id = 2,
                    TrackerDeviceId = 2, // Fill in the Tracker Device ID
                    Location = new Coordinate
                    {
                        Latitude = 34.0522, // Your latitude value
                        Longitude = -118.2437 // Your longitude value
                    },
                    Timestamp = DateTimeOffset.UtcNow,
                    Speed = 45, // Speed value
                }
            );
        }
    }
}
