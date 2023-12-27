using Locato.Data.Entities.Communication;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using uFony.Data.Web;
using Locato.Data.Entities.UserEntities;
using Locato.Data.Entities.Business;
using Locato.Data.Entities.Media;
using Locato.Data.Entities.Scheduling;
using Locato.Data.Entities.Transport.Routes;
using Locato.Data.Entities.Transport.Tracker;
using Locato.Data.Entities.Transport.Trips;
using Locato.Data.Entities.Transport.VehicleEntities;
using Locato.Data.Entities.Transport.VehicleEntites;
using Locato.Data.Entities.Validation;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Locato.Data.Contracts;
using Services.Interfaces;

namespace Locato.Data.EntityFramework
{
    public class ApplicationContext : DbContext , IApplicationDbContext
    {
        #region Users
        public DbSet<User> Users { get; set; }
        public DbSet<BaseUser> BaseUsers { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Photo> Photos{ get; set; }
        public DbSet<UserDeviceInfo> UserDeviceInfoes { get; set; }
        #endregion 
        #region Communication 
        public DbSet<Message> Messages { get; set; }
        public DbSet<EmailNotification> EmailNotifications { get; set; }
        public DbSet<SmsNotification> SmsNotification { get; set; }
        public DbSet<PushNotification> PushNotification { get; set; }
        #endregion

        #region Business
        public DbSet<Organization> Organizations { get; set; }
        #endregion
        #region Media
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<StaticMedia> StaticMedias{ get; set; }
        #endregion
        #region Scheduling 
        public DbSet<Event> Events{ get; set; }
        public DbSet<OrganizationOffDay> OrganizationOffDays { get; set; }
        #endregion

        #region Routes
        public DbSet<Route> Routes { get; set; }
        public DbSet<RouteGeoFenceCoordinate> RouteGeoFenceCoordinates { get; set; }
        public DbSet<RouteStop> RouteStops { get; set; }
        public DbSet<RouteStopGeoFence> RouteStopGeoFences { get; set; }
        public DbSet<RouteTiming> RouteTimings { get; set; }
        #endregion

        #region  TrackerDevice
        public DbSet<OrganizationTrackerDevice> OrganizationTrackerDevices { get; set; }
        public DbSet<TrackerDevice> TrackerDevices { get; set; }
        public DbSet<TrackerDeviceAlarm> TrackerDeviceAlarms { get; set; }
        public DbSet<TrackerDeviceLocation> TrackerDeviceLocations { get; set; }
        #endregion

        #region Trips
        public DbSet<Trip> Trips { get; set; }
        public DbSet<TripActiveGeoFence> TripActiveGeoFences { get; set; }
        public DbSet<TripLocation> TripLocations { get; set; }
        public DbSet<TripNotification> TripNotifications { get; set; }
        public DbSet<TripSubscriber> TripSubscribers { get; set; }
        #endregion

        #region Vehicles
        public DbSet<Vehicle> Vehicles{ get; set; }
        public DbSet<VehicleAlert> VehicleAlerts { get; set; }
        public DbSet<VehicleAlertUser> VehicleAlertUsers { get; set; }
        public DbSet<VehicleMedia> VehicleMedias { get; set; }
        public DbSet<VehicleTrackerDeviceLog> VehicleTrackerDeviceLogs { get; set; }
        #endregion

        #region Validation
        public DbSet<LoginUser> LoginUsers { get; set; }
        public DbSet<UserOTP> UserOTPs { get; set; }
        public DbSet<UserTemporaryPassword> UserTemporaryPasswords { get; set; }
        #endregion
        private readonly IIdGenerator<long> _idGenerator;
        private readonly ICurrentUserService _userService;

        public ApplicationContext(IIdGenerator<long> idGenerator , ICurrentUserService userService) : base() 
        {
          _idGenerator = idGenerator;
          _userService = userService;
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=ufony-local2;Username=postgres;Password=2455").UseSnakeCaseNamingConvention();
            base.OnConfiguring(optionsBuilder);
        }

        public override int SaveChanges()
        {
            try
            {
                OnSaveChanges();
                return base.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new DbUpdateConcurrencyException("concurency error occured while updating the database" + GetExceptions(ex)+ex.Message);
                
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateConcurrencyException("concurency error occured while updating the database" + GetExceptions(null,ex) + ex.Message);
            }
          
        }


        private string GetExceptions(DbUpdateConcurrencyException? dbupdateconcurrency = null, DbUpdateException? dbupdateexception = null )
        {
            var sb = new StringBuilder();
            if(dbupdateconcurrency!= null)
            {
                foreach(var item in dbupdateconcurrency.Entries)
                {
                    sb.AppendLine("Error occured in entity "+item.Entity.GetType().Name);
                    sb.AppendLine();
                }
            } else  if(dbupdateexception != null)
            {
                foreach (var item in dbupdateexception.Entries)
                {
                    sb.AppendLine("Error occured in entity " + item.Entity.GetType().Name);
                    sb.AppendLine();
                }
            }


            return sb.ToString();   
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            OnSaveChanges();
            return base.SaveChangesAsync(cancellationToken);
        }
        
        private void OnSaveChanges()
        {
            var now = DateTime.UtcNow;
            try
            {
                foreach(var dbEntityEntry  in ChangeTracker.Entries<TrackedEntity>())
                {
                    if (dbEntityEntry.State == EntityState.Added)
                    {
                        dbEntityEntry.Entity.Created = now;
                        dbEntityEntry.Entity.Updated = now;

                        if (dbEntityEntry.Entity.Id == 0)
                            dbEntityEntry.Entity.Id = NextId();
                        dbEntityEntry.Entity.CreatedBy = this._userService.UserId;
                        dbEntityEntry.Entity.ModifiedBy = this._userService.UserId;
                    } 
                    if(dbEntityEntry.State == EntityState.Modified)
                    {
                        dbEntityEntry.Entity.Updated = now;
                        dbEntityEntry.Entity.ModifiedBy = _userService.UserId;
                    }
                }
                foreach (var dbEntityEntry in ChangeTracker.Entries<Entity>())
                {
                    if (dbEntityEntry.State == EntityState.Added)
                    {
                        dbEntityEntry.Entity.Created= now;
                        dbEntityEntry.Entity.Updated = now;

                        if (dbEntityEntry.Entity.Id == 0)
                            dbEntityEntry.Entity.Id = NextId();
                    }

                    if (dbEntityEntry.State == EntityState.Modified)
                    {
                        dbEntityEntry.Entity.Updated = now;
                    }
                }
            }
            catch (Exception ex)
            {
                var e = ex;
            }
        }

     
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateTimeOffset>()
                .HaveConversion<DateTimeOffsetConverter>();

            base.ConfigureConventions(configurationBuilder);
        }

        public long NextId()
        {
            return _idGenerator.GenerateId();
        }

       
    }

    public class DateTimeOffsetConverter : ValueConverter<DateTimeOffset, DateTimeOffset>
    {
        public DateTimeOffsetConverter()
            : base(
                d => d.ToUniversalTime(),
                d => d.ToUniversalTime())
        {
        }
    }


}
