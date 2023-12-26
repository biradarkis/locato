using Locato.Data.Contracts;
using Locato.Data.Entities.Business;
using Locato.Data.Entities.Transport.Routes;
using Locato.Data.Entities.Transport.VehicleEntites;
using Locato.Data.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locato.Data.Entities.Transport.VehicleEntities
{
    public class Vehicle : Entity, IValidatableObject
    {
        public string Name { get; set; }

        public string RegistrationNumber { get; set; }

        public string VehicleType { get; set; }
        public int SeatCapacity { get; set; }
        public long? TrackerDeviceId { get; set; }
      
        public long? BusdriverId { get; set; }
        [ForeignKey(nameof(BusdriverId))]
        public Driver BusDriver { get; set; }

        public bool OwnedByOrg { get; set; }

        public bool BGV { get; set; }

        public bool CCTV { get; set; }

        public bool FireExtinguisher { get; set; }

        public bool FirstAidBox { get; set; }

        //public bool BusBranding { get; set; }

        public long OrgId { get; set; }
        public  Organization Organization{ get; set; }

        public string EngineNumber { get; set; }

        public string ModelNameAndNumber { get; set; }

        public int? MakeYear { get; set; }

        public int? SpeedLimit { get; set; }

        public string ChassisNumber { get; set; }

        public DateTime? InsuranceStartDate { get; set; }

        public DateTime? InsuranceEndDate { get; set; }

        public DateTime? PermitStartDate { get; set; }

        public DateTime? PermitEndDate { get; set; }

        public DateTime? TaxStartDate { get; set; }

        public DateTime? TaxEndDate { get; set; }

        public DateTime? OrgPermitStartDate { get; set; }

        public DateTime? OrgPermitEndDate { get; set; }

        public DateTime? FitnessCertificateStartDate { get; set; }

        public DateTime? FitnessCertificateEndDate { get; set; }

        public DateTime? FireExtinguisherStartDate { get; set; }

        public DateTime? FireExtinguisherEndDate { get; set; }

        public DateTime? FirstAidBoxStartDate { get; set; }

        public DateTime? FirstAidBoxEndDate { get; set; }

        public DateTime? VehicleNextInspectionDate { get; set; }
        /// <summary>
        /// <see cref="VehicleFuelType"/>
        /// </summary>
        public string FuelType { get; set; }

        public double? OdometerReading { get; set; }

        public ICollection<VehicleAlert> Alerts { get; set; }

        public ICollection<Route> Routes { get; set; }

        public ICollection<VehicleDistanceTraveled> DistanceTraveled { get; set; }

        public ICollection<VehicleMedia> Media { get; set; }

        public bool IsBlackedout { get; set; }

        public Vehicle()
        {
            Alerts = new HashSet<VehicleAlert>();
            Routes = new HashSet<Route>();
            DistanceTraveled = new HashSet<VehicleDistanceTraveled>();
            Media = new HashSet<VehicleMedia>();
        }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return Array.Empty<ValidationResult>(); 
        }
    }
    internal class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasMany(x => x.Routes).WithOne(x => x.Vehicle).HasForeignKey(x => x.VehicleId);
            builder.HasOne(x=>x.Organization).WithMany(x => x.Vehicles).HasForeignKey(x => x.OrgId);
        }
    }

    public enum VehicleFuelType
    {
       PEROL,
       DIESEL,
       CNG
    }
}
