using Locato.Data.Entities.Business;
using Locato.Data.Entities.Communication;
using Locato.Data.Entities.Media;
using Locato.Data.Entities.Scheduling;
using Locato.Data.Entities.Transport.Routes;
using Locato.Data.Entities.Transport.Tracker;
using Locato.Data.Entities.Transport.Trips;
using Locato.Data.Entities.Transport.VehicleEntites;
using Locato.Data.Entities.Transport.VehicleEntities;
using Locato.Data.Entities.UserEntities;
using Locato.Data.Entities.Validation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locato.Data.EntityFramework
{
    public interface IApplicationDbContext
    {
        public DbSet<User> Users { get;  }
        public DbSet<Profile> Profiles { get;  }
        public DbSet<Photo> Photos { get;  }
        public DbSet<UserDeviceInfo> UserDeviceInfoes { get;  }
        public DbSet<Message> Messages { get;  }
        public DbSet<EmailNotification> EmailNotifications { get;  }
        public DbSet<SmsNotification> SmsNotification { get;  }
        public DbSet<PushNotification> PushNotification { get;  }
        public DbSet<Organization> Organizations { get;  }
        public DbSet<Attachment> Attachments { get;  }
        public DbSet<StaticMedia> StaticMedias { get;  }
        public DbSet<Event> Events { get;  }
        public DbSet<OrganizationOffDay> OrganizationOffDays { get;  }
        public DbSet<Route> Routes { get;  }
        public DbSet<RouteGeoFenceCoordinate> RouteGeoFenceCoordinates { get;  }
        public DbSet<RouteStop> RouteStops { get;  }
        public DbSet<RouteStopGeoFence> RouteStopGeoFences { get;  }
        public DbSet<RouteTiming> RouteTimings { get;  }
        public DbSet<OrganizationTrackerDevice> OrganizationTrackerDevices { get;  }
        public DbSet<TrackerDevice> TrackerDevices { get;  }
        public DbSet<TrackerDeviceAlarm> TrackerDeviceAlarms { get;  }
        public DbSet<TrackerDeviceLocation> TrackerDeviceLocations { get;  }
        public DbSet<Trip> Trips { get;  }
        public DbSet<JWTToken> JWTTokens { get; }
        public DbSet<TripActiveGeoFence> TripActiveGeoFences { get;  }
        public DbSet<TripLocation> TripLocations { get;  }
        public DbSet<TripNotification> TripNotifications { get;  }
        public DbSet<TripSubscriber> TripSubscribers { get;  }
        public DbSet<Vehicle> Vehicles { get;  }
        public DbSet<VehicleAlert> VehicleAlerts { get;  }
        public DbSet<VehicleAlertUser> VehicleAlertUsers { get;  }
        public DbSet<VehicleMedia> VehicleMedias { get;  }
        public DbSet<VehicleTrackerDeviceLog> VehicleTrackerDeviceLogs { get;  }
        public DbSet<LoginUser> LoginUsers { get;  }
        public DbSet<UserOTP> UserOTPs { get;  }
        public DbSet<UserTemporaryPassword> UserTemporaryPasswords { get;  }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        int SaveChanges();

    }
}
